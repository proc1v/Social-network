using Microsoft.Extensions.Configuration;
using Social_network.Objects;
using Social_network.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network
{
    public class Command
    {
        static string ConnectionString
        {
            get
            {
                return new ConfigurationBuilder().AddJsonFile(@"D:\Універ\Лаби\NoSQL Course\Social-network\Social-network\appsettings.json").Build().GetConnectionString("SN");
            }
        }
        private UsersRepository usersRepository = new UsersRepository(ConnectionString);
        private PostsRepository postsRepository = new PostsRepository(ConnectionString);
        private User currentUser;

        public bool Authtentificate(string username, string pass)
        {
            var found = usersRepository.GetUsersByField("username", username);
            if (found.Count == 0)
            {
                return false;
            }
            currentUser = found[0];
            return true;
        }
    }
}
