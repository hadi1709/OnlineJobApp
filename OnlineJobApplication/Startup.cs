using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using OnlineJobApplication.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineJobApplication.Startup))]
namespace OnlineJobApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
        }

        /// <summary>
        /// Jobseeker and Admin role will be added automatically if it does not exist in db.
        /// Admin user will be added automatically if it does not exist in db.
        /// </summary>
        private void CreateRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Jobseeker"))
            {
                var role = new IdentityRole();
                role.Name = "Jobseeker";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            var user = new ApplicationUser();
            user.UserName = "Admin@gmail.com";
            user.Email = "Admin@gmail.com";

            string userPWD = "P@$$w0rd";

            var chkUser = UserManager.Create(user, userPWD);

            //Add default User to Role Admin    
            if (chkUser.Succeeded)
            {
                UserManager.AddToRole(user.Id, "Admin");
                string roleId = roleManager.FindByName("Admin").Id;
                using (db_1526890_onlinejobEntities db = new db_1526890_onlinejobEntities())
                {                  
                    User obj = new User()
                    {
                        Name = "Admin",
                        PhoneNumber = "12345678",
                        ReligionId = 1,
                        CountryId = "BN",
                        Address = "Posh Avenue",
                        AspUserId = user.Id,
                        RoleId = roleId,
                        IcNumber = "1234567",                     
                    };

                    db.Users.Add(obj);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Create admin user if not yet existed
        /// </summary>
        private void CreateAdmin()
        {

        }
    }
}
