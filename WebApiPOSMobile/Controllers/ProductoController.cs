using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiPOSMobile.Models;
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/Producto")]
    public class ProductoController : Controller
    {
        DataAccessProducto objds;

        public ProductoController(DataAccessProducto d)
        {
            objds = d;
        }

        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return objds.GetProductos();
        }
        [HttpGet("{id:length(24)}")]
        public IActionResult Get(string id)
        {
            var Producto = objds.GetProducto(new ObjectId(id));
            if (Producto == null)
            {
                return NotFound();
            }
            return new ObjectResult(Producto);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Producto p)
        {
            objds.Create(p);
            return new OkObjectResult(p);
        }
        [HttpPut("{id:length(24)}")]
        public IActionResult Put(string id, [FromBody]Producto p)
        {
            var recId = new ObjectId(id);
            var Producto = objds.GetProducto(recId);
            if (Producto == null)
            {
                return NotFound();
            }

            objds.Update(recId, p);
            return new OkResult();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Producto = objds.GetProducto(new ObjectId(id));
            if (Producto == null)
            {
                return NotFound();
            }

            objds.Remove(Producto.Id);
            return new OkResult();
        }
    }
}
