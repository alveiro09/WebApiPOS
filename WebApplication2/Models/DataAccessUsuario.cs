using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;

namespace WebApplication2.Models
{
        public class DataAccessUsuario
        {
            MongoClient _client;
            MongoServer _server;
            MongoDatabase _db;

            public DataAccessUsuario()
            {

            //_client = new MongoClient("mongodb://localhost:27017");
            // emuladorLocal   _client = new MongoClient("mongodb://localhost:C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==@localhost:10255/admin?ssl=true");
            //MongoClient client = new MongoClient($"mongodb://{configuracion.Usuario}:{configuracion.Password}@{configuracion.Host}:{configuracion.Port}/?ssl=true&replicaSet=globaldb");
            _client = new MongoClient($"mongodb://proyectointegrador:ub4RSbjNXrF5Mm7BoFSA9NxTXzw4r0OujHTBMoyZ86J5lrWom6YKPl1uAR7QGh3LM5on43zL4a0RXrJZBCpdMQ==@proyectointegrador.documents.azure.com:10255/?ssl=true&replicaSet=globaldb");
            _server = _client.GetServer();
                _db = _server.GetDatabase("proyecto");
            }

            public List<Usuario> GetUsuarios()
            {
            // return _db.GetCollection<Usuario>("posmobile").FindAll();
          //  var filter = Builders<Usuario>.Filter.Eq("_t", "Usuario");
            IMongoQuery query = Query.And(Query.EQ("_t", "Usuario"));
            return new List<Usuario> (_db.GetCollection<Usuario>("posmobile").Find(query));
        }


            public Usuario GetUsuario(ObjectId id)
            {
                var res = Query<Usuario>.EQ(p => p.Id, id);
                return _db.GetCollection<Usuario>("posmobile").FindOne(res);
            }

        public Usuario GetUsuario(string nombreUsuario, string contrasena)
        {
            var res = Query<Usuario>.EQ(p => p.NombreDeUsuario, nombreUsuario);
            var user = _db.GetCollection<Usuario>("posmobile").FindOne(res);
            if ((user.NombreDeUsuario.Equals(nombreUsuario)) && (user.Contrasena.Equals(contrasena)))
                return user;
            else
                return null;
        }

        //public Usuario GetProducto(string usuario, string contrasena)
        //{
        //    var res = Query<Usuario>.EQ(p => p.NombreUsuario, usuario  & q=> q., contrasena);
        //    return _db.GetCollection<Usuario>("posmobile").FindOne(res);
        //}

        public string Create(Usuario p)
            {
             var insert = _db.GetCollection<Usuario>("posmobile").Save(p);
                return insert.Response.GetElement("n").Value.ToString();
        }

            public string Update(ObjectId id, Usuario p)
            {
                p.Id = id;
                var res = Query<Usuario>.EQ(pd => pd.Id, id);
                var operation = Update<Usuario>.Replace(p);
                var operationUpdate = _db.GetCollection<Usuario>("posmobile").Update(res, operation);
                return operationUpdate.Response.GetElement("n").Value.ToString();
        }
            public string Remove(ObjectId id)
            {
                var res = Query<Usuario>.EQ(e => e.Id, id);
                var operation = _db.GetCollection<Usuario>("posmobile").Remove(res);
                return operation.Response.GetElement("n").Value.ToString();
            }
        }
    }
