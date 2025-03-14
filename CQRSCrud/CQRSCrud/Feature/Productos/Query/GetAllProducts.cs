using CQRSCrud.Context;
using CQRSCrud.Entities;
using Dapper;
using MediatR;
using System.Data;
namespace CQRSCrud.Feature.Productos.Query;

// vamos a crear dos objetos

//1.- la solicitud
//2.- la clase que se encargar de trabajar la solicitud


// dividmos dos regiones

// 1.- Region del query

#region query
public record GetAllProductsQuery : IRequest<List<Producto>>;
#endregion

// 2.- Region del handler

#region handler
public class GetAllProductsQueryHandler(ConexionDB _conexion)
    : IRequestHandler<GetAllProductsQuery, List<Producto>>
{
    public async Task<List<Producto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var query = "select * from producto";
        using (var con = _conexion.ObtenerSql())
        {
            var list = await con.QueryAsync<Producto>(query, commandType: CommandType.Text);
            return list.ToList();
        }
    }
}
#endregion



