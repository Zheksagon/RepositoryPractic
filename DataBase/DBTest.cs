using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Zadacha1zhd.Models;

namespace Zadacha1zhd.DataBase
{
    public static class DBTest
    {
        public static async Task InitializeAsync(DataBaseContext context, UserManager<AuthenticationModel> userManager)
        {
            context.Database.EnsureCreated();

            // 1. Добавляем категории, если их ещё нет
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new CategoryModel { Name = "Велосипеды" },
                    new CategoryModel { Name = "Самокаты" },
                    new CategoryModel { Name = "Туризм" }
                );
                await context.SaveChangesAsync();
            }

            // 2. Добавляем товары, если каталог пуст
            if (!context.Products.Any())
            {
                var catBike = context.Categories.First(c => c.Name == "Велосипеды").Id;
                var catScooter = context.Categories.First(c => c.Name == "Самокаты").Id;
                var catCamp = context.Categories.First(c => c.Name == "Туризм").Id;

                context.Products.AddRange(
                    new RentProductModel { Title = "Велосипед горный", Description = "Алюминиевая рама, 21 скорость", PricePerDay = 800, URLImage = "/Images/Велосипед.png", CategoryId = catBike, TotalQuantity = 5 },
                    new RentProductModel { Title = "Рюкзак туристический 65л", Description = "Анатомическая спинка, влагозащитный чехол", PricePerDay = 400, URLImage = "/Images/Рюкзак.png", CategoryId = catCamp, TotalQuantity = 4 },
                    new RentProductModel { Title = "Палатка 4-местная", Description = "Водонепроницаемая, двухслойная", PricePerDay = 600, URLImage = "/Images/Палатка.png", CategoryId = catCamp, TotalQuantity = 4 }
                );
                await context.SaveChangesAsync();
            }

            // 3. Создаём готового Менеджера (Логин: manager, Пароль: 123456, ПИН: 1111)
            if (await userManager.FindByNameAsync("manager") == null)
            {
                var manager = new AuthenticationModel { UserName = "manager", Login = "manager", FirstName = "Алексей", LastName = "Менеджеров", Email = "mgr@mail.ru", Role = 1 };
                await userManager.CreateAsync(manager, "123456");
                context.PinCodes.Add(new PinCodeModel { PinCode = "1111", UserId = manager.Id });
                await context.SaveChangesAsync();
            }

            // 4. Создаём готового Админа (Логин: admin, Пароль: 123456, ПИН: 2222)
            if (await userManager.FindByNameAsync("admin") == null)
            {
                var admin = new AuthenticationModel { UserName = "admin", Login = "admin", FirstName = "Дмитрий", LastName = "Админов", Email = "adm@mail.ru", Role = 2 };
                await userManager.CreateAsync(admin, "123456");
                context.PinCodes.Add(new PinCodeModel { PinCode = "2222", UserId = admin.Id });
                await context.SaveChangesAsync();
            }
        }
    }
}
