using System.Collections.Generic;
using MongoDB.Driver;
using Galerija.Models;

namespace Galerija.Services
{

    public class DrzavaService
    {
        private  IMongoCollection<Drzava> _drzava;

        public DrzavaService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _drzava = database.GetCollection<Drzava>("drzave");

        }

        public Drzava Create(Drzava drzava)
        {
            _drzava.InsertOne(drzava);
            return drzava;
        }

        public IList<Drzava> Read() =>
            _drzava.Find(sub => true).ToList();

        public Drzava Find(string id) =>
        
            _drzava.Find(sub=>sub.Id == id).SingleOrDefault();

        public void Update(Drzava drzava) =>
            _drzava.ReplaceOne(sub => sub.Id == drzava.Id, drzava);

        public void Delete(string id) =>
            _drzava.DeleteOne(sub => sub.Id == id);
    }
}