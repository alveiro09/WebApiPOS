using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;
using WebApiPOSMobile.Models;

namespace WebApplication2.Models
{
    public class DataAccessTransaccion
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        public DataAccessTransaccion()
        {

            //_client = new MongoClient("mongodb://localhost:27017");
            // emuladorLocal   _client = new MongoClient("mongodb://localhost:C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==@localhost:10255/admin?ssl=true");
            //MongoClient client = new MongoClient($"mongodb://{configuracion.Transaccion}:{configuracion.Password}@{configuracion.Host}:{configuracion.Port}/?ssl=true&replicaSet=globaldb");
            _client = new MongoClient($"mongodb://proyectointegrador:ub4RSbjNXrF5Mm7BoFSA9NxTXzw4r0OujHTBMoyZ86J5lrWom6YKPl1uAR7QGh3LM5on43zL4a0RXrJZBCpdMQ==@proyectointegrador.documents.azure.com:10255/?ssl=true&replicaSet=globaldb");
            _server = _client.GetServer();
            _db = _server.GetDatabase("proyecto");
        }

        public List<Transaccion> GetTransaccions()
        {
            // return _db.GetCollection<Transaccion>("posmobile").FindAll();
            //  var filter = Builders<Transaccion>.Filter.Eq("_t", "Transaccion");
            IMongoQuery query = Query.And(Query.EQ("_t", "Transaccion"));
            return new List<Transaccion>(_db.GetCollection<Transaccion>("posmobile").Find(query));
        }


        public Transaccion GetTransaccion(ObjectId id)
        {
            var res = Query<Transaccion>.EQ(p => p.Id, id);
            return _db.GetCollection<Transaccion>("posmobile").FindOne(res);
        }

        //public Transaccion GetProducto(string Transaccion, string contrasena)
        //{
        //    var res = Query<Transaccion>.EQ(p => p.NombreTransaccion, Transaccion  & q=> q., contrasena);
        //    return _db.GetCollection<Transaccion>("posmobile").FindOne(res);
        //}

        public string Create(Transaccion p)
        {
            var insert = _db.GetCollection<Transaccion>("posmobile").Save(p);
            return insert.Response.GetElement("n").Value.ToString();
        }

        public string Update(ObjectId id, Transaccion p)
        {
            p.Id = id;
            var res = Query<Transaccion>.EQ(pd => pd.Id, id);
            var operation = Update<Transaccion>.Replace(p);
            var operationUpdate = _db.GetCollection<Transaccion>("posmobile").Update(res, operation);
            return operationUpdate.Response.GetElement("n").Value.ToString();
        }
        public string Remove(ObjectId id)
        {
            var res = Query<Transaccion>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<Transaccion>("posmobile").Remove(res);
            return operation.Response.GetElement("n").Value.ToString();
        }
    }
}
