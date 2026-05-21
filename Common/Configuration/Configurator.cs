using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace PetClinicTests.Common.Configuration
{
    public class Configurator
    {
        private static readonly Lazy<IConfiguration> s_configuration;
        public static IConfiguration Configuration => s_configuration.Value;

        static Configurator()
        {
            s_configuration = new Lazy<IConfiguration>(BuildConfiguration);
        }

        private static IConfiguration BuildConfiguration()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath ?? throw new InvalidOperationException())
                .AddJsonFile("generalCredentials.json");

            return builder.Build();
        }

        //public static List<User> Users
        //{
        //    get
        //    {
        //        List<User> users = new List<User>();
        //        var child = Configuration.GetSection("Users");
        //        foreach (var section in child.GetChildren())
        //        {
        //            var user = new User
        //            {
        //                Password = section["Password"],
        //                Username = section["Username"],
        //                Email = section["Email"]
        //            };

        //            users.Add(user);
        //        }

        //        return users;
        //    }
        //}

        //public static User UserByUsername(string username) => Users.Find(x => x?.Username == username);

        //public static User GetAuthUser
        //{
        //    get
        //    {
        //        var authUser = new User();
        //        var child = Configuration.GetSection("AuthUser");
        //        authUser.Username = child["Username"];
        //        authUser.Password = child["Password"];
        //        authUser.Email = child["Email"];

        //        return authUser;
        //    }
        //}
    }
}
