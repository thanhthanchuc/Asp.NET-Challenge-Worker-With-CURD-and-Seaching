using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Worker_Assignment.Startup))]
namespace Worker_Assignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
