using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using inz.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace inz.DAL
{
    public class AppInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var firms = new List<Firm>
                {
                new Firm{Name="Carson Alexander",Adress="Alexander 21",Mail="example@fe.com", Www="www.example.org", Phone=333444555, Consent=true},
                new Firm{Name="Ago Nintendo",Adress="ul. Bora 21",Mail="example@fe.com", Www="www.example.org", Phone=333444555, Consent=true},
                new Firm{Name="Nino Olivetto",Adress="Olivetto 42/303",Mail="example@fe.com", Www="www.example.org", Phone=333444555, Consent=true}
                };

            firms.ForEach(s => context.Firms.Add(s));
            context.SaveChanges();
            var agents = new List<Agent>
                {
                new Agent{Name="Done Corleone",Title="Agent",Mail="example@fe.com", Phone=333444555, Place="Pokój 21", ImgName=""},
                new Agent{Name="Alek Pacino",Title="Agent",Mail="example@fe.com", Phone=333444555, Place="Pokój 1", ImgName=""},
                new Agent{Name="Ferdek Kiepski",Title="Agent",Mail="example@fe.com", Phone=333444555, Place="Pokój 2", ImgName=""}
                };
            agents.ForEach(s => context.Agents.Add(s));
            context.SaveChanges();

            var categories = new List<Category>
                {
                new Category{Name="Biotechnologia"},
                new Category{Name="Medycyna"},
                };

            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();

            var news = new List<News>
                    {
                    new News{Title="Random News", Description="Random description description description", Author="John Smith", Date=DateTime.Parse("2018-09-01"), ImgName="", Rating=0, RatingCount=0},
                    new News{Title="News of Todat", Description="Random description description description", Author="John Smith", Date=DateTime.Parse("2018-09-01"), ImgName="", Rating=0, RatingCount=0}
                    };

            news.ForEach(s => context.News.Add(s));
            context.SaveChanges();

            var offers = new List<Offer>
                    {
                    new Offer{Title="Random Offer", Description="Random offer description", Author="John Smith", Date=DateTime.Parse("2018-09-01"), ImgName=""},
                    new Offer{Title="Next Offer Git", Description="Random offer description", Author="John Smith", Date=DateTime.Parse("2018-09-01"), ImgName=""}
                    };

            offers.ForEach(s => context.Offers.Add(s));
            context.SaveChanges();

            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext()));

            roleManager.Create(new IdentityRole("Admin"));
            roleManager.Create(new IdentityRole("User"));

            roleManager.Create(new IdentityRole("Agent"));
            roleManager.Create(new IdentityRole("Firm"));
            roleManager.Create(new IdentityRole("Scientist"));

            context.SaveChanges();

            var admin = new ApplicationUser { UserName = "admin", Email = "admin@admin.com" };
            string password = "Admin!1";

            userManager.Create(admin, password);
            userManager.AddToRole(admin.Id, "Admin");

            context.SaveChanges();

        }
    }
}