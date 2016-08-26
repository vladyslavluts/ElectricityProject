﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
namespace Electricity_Ui.Models
{
        public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
        {
            protected override void Seed(ApplicationDbContext context)
            {
                var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                // создаем две роли
                var role1 = new IdentityRole { Name = "admin" };
                var role2 = new IdentityRole { Name = "user" };
                // добавляем роли в бд
                roleManager.Create(role1);
                roleManager.Create(role2);
                // создаем пользователей
                var admin = new ApplicationUser { Email = "vladyslav.luts1@gmail.com", UserName = "vladyslav.luts1@gmail.com" };
                string password = "T05_01_2016";
                var result = userManager.Create(admin, password);
                // если создание пользователя прошло успешно
                if (result.Succeeded)
                {
                    // добавляем для пользователя роль
                    userManager.AddToRole(admin.Id, role1.Name);
                    userManager.AddToRole(admin.Id, role2.Name);
                }
                base.Seed(context);
            }
        }
    }
