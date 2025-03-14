using CQRSCrud.Context;
using Dapper;
using MediatR;
using System.Data;

namespace CQRSCrud.Feature.Productos.Command;

#region command

public record DeleteProductCommand(int Id) : IRequest<bool>;

#endregion command

#region handler

public class DeleteProductCommandHandler(ConexionDB _conexion)
    : IRequestHandler<DeleteProductCommand, bool>
{
    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var query = "delete from Producto where Id = @Id";
        var parameters = new DynamicParameters();
        parameters.Add("@Id", request.Id, DbType.Int32);

        using (var cn = _conexion.ObtenerSql())
        {
            var rowsAffect = await cn.ExecuteAsync(query, parameters, commandType: CommandType.Text);
            return rowsAffect > 0;

        }
    }
}

#endregion handler


