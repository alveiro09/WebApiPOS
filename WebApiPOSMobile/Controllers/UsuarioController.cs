using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiPOSMobile.Models;
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiPOSMobile.Controllers
{
    [Route("api/Usuario")]
    public class UsuarioController : Controller
    {
        DataAccessUsuario objds;

        public UsuarioController(DataAccessUsuario d)
        {
            objds = d;
        }

        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return objds.GetUsuarios();
        }
        [HttpGet("{id:length(24)}")]
        public IActionResult Get(string id)
        {
            var Usuario = objds.GetUsuario(new ObjectId(id));
            if (Usuario == null)
            {
                return NotFound();
            }
            return new ObjectResult(Usuario);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Usuario p)
        {
            objds.Create(p);
            return new OkObjectResult(p);
        }
        [HttpPut("{id:length(24)}")]
        public IActionResult Put(string id, [FromBody]Usuario p)
        {
            var recId = new ObjectId(id);
            var Usuario = objds.GetUsuario(recId);
            if (Usuario == null)
            {
                return NotFound();
            }

            objds.Update(recId, p);
            return new OkResult();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Usuario = objds.GetUsuario(new ObjectId(id));
            if (Usuario == null)
            {
                return NotFound();
            }

            objds.Remove(Usuario.Id);
            return new OkResult();
        }
    }
}
