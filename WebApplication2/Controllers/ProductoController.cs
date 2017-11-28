
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using MongoDB.Bson;
using WebApplication2.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiPOSMobile.Controllers
{
    public class ProductoController : ApiController
    {
        DataAccessProducto objds;
        public ProductoController()
        {
            objds = new DataAccessProducto();
        }

        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return objds.GetProductos();
        }

        [HttpGet]
        public Producto Get(string id)
        {
            var Producto = objds.GetProducto(new ObjectId(id));
            if (Producto == null)
            {
                return null;
            }
            return Producto;
        }

        [HttpPost]
        public string Post([FromBody]Producto p)
        {
            var result = "false";
            if (objds.Create(p) == "1")
                result = "true";
            return result;
        }

        [HttpPut]
        public string Put(string id, [FromBody]Producto p)
        {
            var result = "false";
            if (objds.Update(new ObjectId(id), p) == "1")
                result = "true";
            return result;
        }

        [HttpDelete]
        public string Delete(string id)
        {
            var result = "false";
            if (objds.Remove(new ObjectId(id)) == "1")
                result = "true";
            return result;
        }
    }
}
