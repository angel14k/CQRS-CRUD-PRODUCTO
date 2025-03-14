using CQRSCrud.Context;
using Dapper;
using MediatR;
using System.Data;

namespace CQRSCrud.Feature.Productos.Command;


#region command

public record CreateProductCommand(string Nombre, int Precio) : IRequest<bool>;


#endregion command

#region handler

public class CreateProductCommandHanlder(ConexionDB _conexion)
    : IRequestHandler<CreateProductCommand, bool>
{
    public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var query = "insert into Producto(Nombre,Precio) values(@Nombre,@Precio)";
        var parameters = new DynamicParameters();
        parameters.Add("@Nombre", request.Nombre, DbType.String);
        parameters.Add("@Precio", request.Precio, DbType.Int32);

        using (var con = _conexion.ObtenerSql())
        {
            var rowsAffected = await con.ExecuteAsync(query, parameters, commandType: CommandType.Text);
            return rowsAffected > 0;

        }
    }
}
#endregion handler