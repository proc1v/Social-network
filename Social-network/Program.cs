using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Social_network.Repositories;


namespace Social_network
{
    internal class Program
    {
        static string ConnectionString
        {
            get
            {
                return new ConfigurationBuilder().AddJsonFile(@"D:\Універ\Лаби\NoSQL Course\Social-network\Social-network\appsettings.json").Build().GetConnectionString("SN");
            }
        }
        static void Main(string[] args)
        {
            var usersRepository = new UsersRepository(ConnectionString);
            foreach(var user in usersRepository.GetAllUsers())
            {
                Console.WriteLine(user);
            }
        }
    }
}
