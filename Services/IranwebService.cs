using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IranwebService
    {
        List<user> Get();
        user Get(string id);

        user Create(user user);

        void Update(string id, user user);

        void Remove(string id); 
    }
}