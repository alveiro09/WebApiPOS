using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    [BsonDiscriminator(Required = true)]
    public class Transaccion
    {
        public ObjectId Id { get; set; }
        
        public string IdUsuario { get; set; }

        public int TipoTransaccion { get; set; }     

        public double Neto { get; set; }

        public double Bruto { get; set; }
        
        public double Descuento { get; set; }
        
        public string Fecha { get; set; }
        
        public List<Producto> Detalles { get; set; }

    }
    public enum EnumTipoTransaccion
    {
        Compra,
        Venta
    }
}
