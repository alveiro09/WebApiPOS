﻿using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public class DataAccessProducto
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        public DataAccessProducto()
        {

            //_client = new MongoClient("mongodb://localhost:27017");
            // emuladorLocal   _client = new MongoClient("mongodb://localhost:C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==@localhost:10255/admin?ssl=true");
            //MongoClient client = new MongoClient($"mongodb://{configuracion.Producto}:{configuracion.Password}@{configuracion.Host}:{configuracion.Port}/?ssl=true&replicaSet=globaldb");
            _client = new MongoClient($"mongodb://proyectointegrador:ub4RSbjNXrF5Mm7BoFSA9NxTXzw4r0OujHTBMoyZ86J5lrWom6YKPl1uAR7QGh3LM5on43zL4a0RXrJZBCpdMQ==@proyectointegrador.documents.azure.com:10255/?ssl=true&replicaSet=globaldb");
            _server = _client.GetServer();
            _db = _server.GetDatabase("proyecto");
        }

        public List<Producto> GetProductos()
        {
            // return _db.GetCollection<Producto>("posmobile").FindAll();
            //  var filter = Builders<Producto>.Filter.Eq("_t", "Producto");
            IMongoQuery query = Query.And(Query.EQ("_t", "Producto"));
            return new List<Producto>(_db.GetCollection<Producto>("posmobile").Find(query));
        }


        public Producto GetProducto(ObjectId id)
        {
            var res = Query<Producto>.EQ(p => p.Id, id);
            return _db.GetCollection<Producto>("posmobile").FindOne(res);
        }

        //public Producto GetProducto(string Producto, string contrasena)
        //{
        //    var res = Query<Producto>.EQ(p => p.NombreProducto, Producto  & q=> q., contrasena);
        //    return _db.GetCollection<Producto>("posmobile").FindOne(res);
        //}

        public string Create(Producto p)
        {
            var insert = _db.GetCollection<Producto>("posmobile").Save(p);
            return insert.Response.GetElement("n").Value.ToString();
        }

        public string Update(ObjectId id, Producto p)
        {
            p.Id = id;
            var res = Query<Producto>.EQ(pd => pd.Id, id);
            var operation = Update<Producto>.Replace(p);
            var operationUpdate = _db.GetCollection<Producto>("posmobile").Update(res, operation);
            return operationUpdate.Response.GetElement("n").Value.ToString();
        }
        public string Remove(ObjectId id)
        {
            var res = Query<Producto>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<Producto>("posmobile").Remove(res);
            return operation.Response.GetElement("n").Value.ToString();
        }
    }
}
