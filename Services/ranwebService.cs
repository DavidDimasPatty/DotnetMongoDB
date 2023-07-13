using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Services;
using WebApi.Models;
namespace WebApi.Services
{
    public class ranwebService : IranwebService
    {
        private readonly IMongoCollection<user> _users;

        public ranwebService(IranwebStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
           var database= mongoClient.GetDatabase(settings.DatabaseName);
           _users=  database.GetCollection<user>(settings.userCollectionName);
        }

        public user Create(user user)
        {
            _users.InsertOne(user);
            return user;
        }

        public List<user> Get()
        {
           return _users.Find(user=>true).ToList();
        }

        public user Get(string id)
        {
            return _users.Find(user => user.Id==id).FirstOrDefault();
        }

        public void Remove(string id)
        {
             _users.DeleteOne(user => user.Id == id);
        }

        public void Update(string id, user user)
        {
            _users.ReplaceOne(users => users.Id == id, user);
        }
    }
}