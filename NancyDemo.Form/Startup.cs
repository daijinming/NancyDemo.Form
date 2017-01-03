using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NancyDemo.Form.Startup))]
namespace NancyDemo.Form
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
            app.UseNancy();

        }
    }
}
