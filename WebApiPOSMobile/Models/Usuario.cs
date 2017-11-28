using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPOSMobile.Models
{
    [BsonDiscriminator(Required = true)]
    public class Usuario
    {
        public ObjectId Id { get; set; }
        
        public string NumeroIdentificacion { get; set; }
        
        public string PrimerNombre { get; set; }
        
        public string SegundoNombre { get; set; }
        
        public string PrimerApellido { get; set; }
        
        public string SegundoApellido { get; set; }
        
        public string Contrasena { get; set; }
        
        public string NombreDeUsuario { get; set; }
    }
}
