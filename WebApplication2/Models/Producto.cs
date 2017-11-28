using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    [BsonDiscriminator(Required = true)]
    public class Producto
    {
        public ObjectId Id { get; set; }
        
        public string IdProducto { get; set; }
        
        public string Nombre { get; set; }
        
        public string Descripcion { get; set; }
        
        public double CantidadDisponible { get; set; }
        
        public double PrecioCompra { get; set; }
        public double PrecioVenta { get; set; }
    }
}
