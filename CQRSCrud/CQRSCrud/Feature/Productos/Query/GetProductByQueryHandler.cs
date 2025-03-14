using CQRSCrud.Context;
using CQRSCrud.Entities;
using Dapper;
using MediatR;
using System.Data;

namespace CQRSCrud.Feature.Productos.Query;

public class GetProductByQueryHandler(ConexionDB _conexion) : IRequestHandler<GetProductByIdQuery, Producto?>
{

    public async Task<Producto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var query = "select * from producto where Id = @Id";
        var parameters = new DynamicParameters();
        parameters.Add("@id", request.Id, DbType.Int32);

        using (var cn = _conexion.ObtenerSql())
        {
            var result = await cn.QueryFirstOrDefaultAsync<Producto>(query, parameters, commandType: CommandType.Text);
            return result;
        }
    }


}
