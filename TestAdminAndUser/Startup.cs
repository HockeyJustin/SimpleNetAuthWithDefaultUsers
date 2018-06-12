using Microsoft.Owin;
using Owin;
using System.Threading.Tasks;

[assembly: OwinStartupAttribute(typeof(TestAdminAndUser.Startup))]
namespace TestAdminAndUser
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        { 
            ConfigureAuth(app);

            AuthSetup.AuthInitialize initDb = new AuthSetup.AuthInitialize();
            Task.Run(() => initDb.SetupDefaultUsers());
        }
    }
}
