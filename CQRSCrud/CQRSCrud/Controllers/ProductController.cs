using CQRSCrud.Entities;
using CQRSCrud.Feature.Productos.Command;
using CQRSCrud.Feature.Productos.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ISender _sender) : ControllerBase
    {
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<Producto>>> GetAll()
        {
            var result = await _sender.Send(new GetAllProductsQuery());

            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult<Producto>> GetById(int id)
        {
            var result = await _sender.Send(new GetProductByIdQuery(id));

            return Ok(result);
        }


        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create(CreateProductCommand value)
        {
            var result = await _sender.Send(value);
            return Ok(result);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult> Update(UpdateProductCommand value)
        {
            var result = await _sender.Send(value);
            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _sender.Send(new DeleteProductCommand(id));
            return Ok(result);
        }


    }
}
