using SIS.MvcFramework;
using SIS.MvcFramework.DependencyContainer;
using SIS.MvcFramework.Routing;
using SULS.Data;
using SULS.Services;

namespace SULS.App
{
    public class StartUp : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            using (var db = new SULSContext())
            {
                db.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(IServiceProvider serviceProvider)
        {
			serviceProvider.Add<IUsersService, UsersService>();
			serviceProvider.Add<ISubmissionsService, SubmissionsService>();
			serviceProvider.Add<IProblemsService, ProblemsService>();
		}
    }
}