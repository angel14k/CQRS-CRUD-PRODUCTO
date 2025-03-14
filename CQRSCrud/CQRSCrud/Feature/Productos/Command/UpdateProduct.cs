using CQRSCrud.Context;
using Dapper;
using MediatR;
using System.Data;

namespace CQRSCrud.Feature.Productos.Command;


#region command

public record UpdateProductCommand(int Id, string Nombre, int Precio) : IRequest<bool>;

#endregion command


#region handler

public class UpdateProductCommandHandler(ConexionDB _conexion)
    : IRequestHandler<UpdateProductCommand, bool>
{
    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var query = "Update Producto set Nombre = @Nombre, Precio = @Precio where Id = @Id";
        var parameters = new DynamicParameters();

        parameters.Add("@Id", request.Id, DbType.Int32);
        parameters.Add("@Nombre", request.Nombre, DbType.String);
        parameters.Add("@Precio", request.Precio, DbType.Int64);

        using (var cn = _conexion.ObtenerSql())
        {
            var rowsAffect = await cn.ExecuteAsync(query, parameters, commandType: CommandType.Text);
            return rowsAffect > 0;
        }

    }
}

#endregion handler


