
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using MongoDB.Bson;
using WebApplication2.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiPOSMobile.Controllers
{
    public class UsuarioController : ApiController
    {
        DataAccessUsuario objds;
        public UsuarioController()
        {
            objds = new DataAccessUsuario();
        }

        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return objds.GetUsuarios();
        }

        [HttpGet]
        public Usuario Get(string id)
        {
            var Usuario = objds.GetUsuario(new ObjectId(id));
            if (Usuario == null)
            {
                return null;
            }
            return Usuario;
        }

        [HttpPost]
        public string Post([FromBody]Usuario p)
        {
            var result = "false";
            if (objds.Create(p) == "1")
                result = "true";
            return result;
        }

        [HttpPut]
        public string Put(string id, [FromBody]Usuario p)
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
