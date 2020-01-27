using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskBoardDemo.Startup))]
namespace TaskBoardDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
