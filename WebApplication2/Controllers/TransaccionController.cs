
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using MongoDB.Bson;
using WebApplication2.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiPOSMobile.Controllers
{
    public class TransaccionController : ApiController
    {
        DataAccessTransaccion objds;
        public TransaccionController()
        {
            objds = new DataAccessTransaccion();
        }

        [HttpGet]
        public IEnumerable<Transaccion> Get()
        {
            return objds.GetTransaccions();
        }

        [HttpGet]
        public Transaccion Get(string id)
        {
            var Transaccion = objds.GetTransaccion(new ObjectId(id));
            if (Transaccion == null)
            {
                return null;
            }
            return Transaccion;
        }

        [HttpPost]
        public string Post([FromBody]Transaccion p)
        {
            var result = "false";
            if (objds.Create(p) == "1")
                result = "true";
            return result;
        }

        [HttpPut]
        public string Put(string id, [FromBody]Transaccion p)
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
