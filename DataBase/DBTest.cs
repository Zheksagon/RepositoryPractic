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
            await context.Database.EnsureCreatedAsync();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new CategoryModel { Name = "Транспорт" },
                    new CategoryModel { Name = "Мебель" },
                    new CategoryModel { Name = "Кухонное оборудование" },
                    new CategoryModel { Name = "Палатки" },
                    new CategoryModel { Name = "Рюкзаки" },
                    new CategoryModel { Name = "Инструменты" },
                    new CategoryModel { Name = "Разное" }
                );
                await context.SaveChangesAsync();
            }

            if (!context.Products.Any())
            {
                var catTransport = context.Categories.First(category => category.Name == "Транспорт").Id;
                var catFurniture = context.Categories.First(category => category.Name == "Мебель").Id;
                var catKitchen = context.Categories.First(category => category.Name == "Кухонное оборудование").Id;
                var catTents = context.Categories.First(category => category.Name == "Палатки").Id;
                var catBackpacks = context.Categories.First(category => category.Name == "Рюкзаки").Id;
                var catTools = context.Categories.First(category => category.Name == "Инструменты").Id;
                var catMisc = context.Categories.First(category => category.Name == "Разное").Id;

                context.Products.AddRange(

                    new RentProductModel
                    {
                        Title = "Велосипед",
                        Description = "Надёжный горный хардтейл с облегчённой алюминиевой рамой, амортизационной вилкой и 21 скоростью. Оснащён дисковыми тормозами и покрышками с глубоким протектором для уверенной езды по лесным тропам и пересечённой местности. В комплекте насос и велозамок.",
                        PricePerDay = 800,
                        URLImage = "/Images/Велосипед.png",
                        CategoryId = catTransport,
                        TotalQuantity = 5
                    },
                    new RentProductModel
                    {
                        Title = "Электро-велосипед",
                        Description = "Современный электровелосипед с мотором мощностью 500 Вт и съёмным литий-ионным аккумулятором, обеспечивающим запас хода до 45 км на одном заряде. Имеет 3 режима ассистента педалирования, яркую светодиодную фару и информативный дисплей на руле. Зарядное устройство в комплекте.",
                        PricePerDay = 1500,
                        URLImage = "/Images/Электровелосипед.png",
                        CategoryId = catTransport,
                        TotalQuantity = 3
                    },
                    new RentProductModel
                    {
                        Title = "Мотоцикл",
                        Description = "Лёгкий и манёвренный кроссовый эндуро-мотоцикл объёмом 250 куб. см с электростартером и усиленной подвеской. Идеально подходит для загородных грунтовых дорог, лесных маршрутов и бездорожья. Выдаётся с полным баком и защитным шлемом.",
                        PricePerDay = 3000,
                        URLImage = "/Images/Мотоцикл.png",
                        CategoryId = catTransport,
                        TotalQuantity = 2
                    },

                    // Мебель
                    new RentProductModel
                    {
                        Title = "Стол",
                        Description = "Складной кемпинговый стол с прочной алюминиевой столешницей размером 120×60 см и регулируемыми по высоте ножками. Выдерживает нагрузку до 30 кг, не боится влаги и горячей посуды. Легко складывается в компактный чемоданчик с ручкой для переноски.",
                        PricePerDay = 350,
                        URLImage = "/Images/Стол.png",
                        CategoryId = catFurniture,
                        TotalQuantity = 6
                    },
                    new RentProductModel
                    {
                        Title = "Стул",
                        Description = "Удобный складной туристический стул с высокой спинкой, подлокотниками и встроенным подстаканником. Каркас выполнен из стальных труб с антикоррозийным покрытием, сиденье — из износостойкой ткани Oxford 600D. Поставляется в чехле с плечевым ремнём.",
                        PricePerDay = 200,
                        URLImage = "/Images/Стул.png",
                        CategoryId = catFurniture,
                        TotalQuantity = 10
                    },
                    new RentProductModel
                    {
                        Title = "Раскладушка",
                        Description = "Усиленная походная раскладушка длиной 195 см с надёжным алюминиевым каркасом и плотным натяжным полотном. Обеспечивает комфортный сон высоко над холодной или неровной землёй внутри кемпинговой палатки. Вес 6,5 кг, чехол для хранения в комплекте.",
                        PricePerDay = 450,
                        URLImage = "/Images/Раскладушка.png",
                        CategoryId = catFurniture,
                        TotalQuantity = 4
                    },

                    new RentProductModel
                    {
                        Title = "Плита",
                        Description = "Портативная одноконфорочная газовая плита с пьезоподжигом, плавной регулировкой пламени и системой защиты от утечки газа. Работает от стандартных цанговых газовых баллонов. Поставляется в жёстком пластиковом кейсе для безопасной перевозки.",
                        PricePerDay = 400,
                        URLImage = "/Images/Плита.png",
                        CategoryId = catKitchen,
                        TotalQuantity = 5
                    },
                    new RentProductModel
                    {
                        Title = "Мангал",
                        Description = "Разборный мангал из жаропрочной стали толщиной 2 мм с прорезями для фиксации шампуров и вентиляционными отверстиями для равномерного жара. Собирается без инструментов за 1 минуту, не деформируется от высокой температуры. В комплекте 6 шампуров и чехол.",
                        PricePerDay = 300,
                        URLImage = "/Images/Мангал.png",
                        CategoryId = catKitchen,
                        TotalQuantity = 5
                    },
                    new RentProductModel
                    {
                        Title = "Горелка",
                        Description = "Ультралёгкая туристическая газовая горелка со складными лапками-держателями и встроенным пьезоподжигом. Способна вскипятить 1 литр воды всего за 3,5 минуты даже при сильном ветре. Помещается на ладони, в комплекте пластиковый защитный футляр.",
                        PricePerDay = 250,
                        URLImage = "/Images/Горелка.png",
                        CategoryId = catKitchen,
                        TotalQuantity = 7
                    },

                    new RentProductModel
                    {
                        Title = "Палатка 2-местная",
                        Description = "Лёгкая двухслойная треккинговая палатка с проклеенными швами и водостойкостью тента 4000 мм в. ст. Оснащена дугами из авиационного алюминия, вентиляционными клапанами и москитной сеткой на входе. Вес всего 2,4 кг — отличный выбор для пеших и велопоходов.",
                        PricePerDay = 500,
                        URLImage = "/Images/Палатка.png",
                        CategoryId = catTents,
                        TotalQuantity = 5
                    },
                    new RentProductModel
                    {
                        Title = "Палатка 4-местная",
                        Description = "Просторная кемпинговая палатка с большим защищённым тамбуром для хранения рюкзаков, обуви и снаряжения в непогоду. Имеет два входа, внутренние карманы для мелочей и подвес для фонаря. Надёжно защищает от сильного дождя и порывистого ветра.",
                        PricePerDay = 750,
                        URLImage = "/Images/Палатка.png",
                        CategoryId = catTents,
                        TotalQuantity = 4
                    },
                    new RentProductModel
                    {
                        Title = "Палатка 6-местная",
                        Description = "Большая семейная палатка в полный рост (высота потолка 200 см) с двумя изолированными спальными отсеками и просторной центральной кают-компанией. Идеальна для длительного отдыха большой компанией на природе. В комплекте колышки, штормовые оттяжки и сумка-баул.",
                        PricePerDay = 1100,
                        URLImage = "/Images/Палатка.png",
                        CategoryId = catTents,
                        TotalQuantity = 2
                    },

                    new RentProductModel
                    {
                        Title = "Рюкзак 35л",
                        Description = "Компактный штурмовой рюкзак объёмом 35 литров для однодневных выходов на природу и радиальных прогулок. Оснащён вентилируемой спинкой, грудной стяжкой, поясным ремнём и креплениями для треккинговых палок. Встроенный непромокаемый чехол-дождевик в нижнем кармане.",
                        PricePerDay = 250,
                        URLImage = "/Images/Рюкзак.png",
                        CategoryId = catBackpacks,
                        TotalQuantity = 6
                    },
                    new RentProductModel
                    {
                        Title = "Рюкзак 65л",
                        Description = "Универсальный треккинговый рюкзак объёмом 65 литров с регулируемой по росту анатомической подвесной системой и алюминиевыми латами. Имеет нижний вход для быстрого доступа к спальнику, боковые компрессионные ремни и множество карманов. В комплекте водозащитный накидной чехол.",
                        PricePerDay = 400,
                        URLImage = "/Images/Рюкзак.png",
                        CategoryId = catBackpacks,
                        TotalQuantity = 5
                    },
                    new RentProductModel
                    {
                        Title = "Рюкзак 90л",
                        Description = "Вместительный экспедиционный рюкзак объёмом 90 литров для сложных и многодневных автономных походов. Усиленное дно из ткани Cordura, широкий разгрузочный пояс и плавающий верхний клапан позволяют комфортно переносить тяжёлое снаряжение. Дождевик в комплекте.",
                        PricePerDay = 550,
                        URLImage = "/Images/Рюкзак.png",
                        CategoryId = catBackpacks,
                        TotalQuantity = 3
                    },

                    new RentProductModel
                    {
                        Title = "Саперная лопатка",
                        Description = "Складная многофункциональная сапёрная лопатка из закалённой высокоуглеродистой стали с зубчатой кромкой пилы и функцией мотыги. Незаменима для окапывания палатки в дождь, расчистки костровища или выкапывания застрявшего автомобиля. Поставляется в поясном чехле.",
                        PricePerDay = 150,
                        URLImage = "/Images/Лопатка.png",
                        CategoryId = catTools,
                        TotalQuantity = 8
                    },
                    new RentProductModel
                    {
                        Title = "Топор",
                        Description = "Туристический кованый топор с тефлоновым антифрикционным покрытием лезвия и лёгким эргономичным топорищем из армированного стекловолокна. Отлично сбалансирован для заготовки дров и колки поленьев в лагере. В комплекте пластиковый защитный чехол с ручкой.",
                        PricePerDay = 200,
                        URLImage = "/Images/Топор.png",
                        CategoryId = catTools,
                        TotalQuantity = 6
                    },
                    new RentProductModel
                    {
                    Title = "Пила по дереву",
                        Description = "Складная походная пила с закалённым полотном длиной 210 мм и трёхгранной заточкой зубьев для быстрого пиления как сырой, так и сухой древесины. Надёжный фиксатор исключает случайное складывание лезвия во время работы. Прорезиненная рукоятка не скользит в руке.",
                        PricePerDay = 200,
                        URLImage = "/Images/Пила.png",
                        CategoryId = catTools,
                        TotalQuantity = 6
                    },

                    new RentProductModel
                    {
                        Title = "Тренога",
                        Description = "Устойчивая костровая тренога из стального прутка с регулируемой по высоте цепью и крюком для подвешивания котелка или чайника над открытым огнём. Легко устанавливается на любом грунте и разбирается для транспортировки в длинном чехле.",
                        PricePerDay = 200,
                        URLImage = "/Images/Тренога.png",
                        CategoryId = catMisc,
                        TotalQuantity = 5
                    },
                    new RentProductModel
                    {
                        Title = "Фонарь",
                        Description = "Мощный аккумуляторный кемпинговый фонарь с мягким рассеянным светом на 360 градусов и 4 режимами яркости. Оснащён складным крюком для подвешивания под купол палатки, магнитным основанием и встроенным PowerBank-выходом для подзарядки телефона. Кабель USB в комплекте.",
                        PricePerDay = 150,
                        URLImage = "/Images/Фонарь.png",
                        CategoryId = catMisc,
                        TotalQuantity = 8
                    },
                    new RentProductModel
                    {
                        Title = "Походный кухонный набор",
                        Description = "Полный комплект походной посуды из анодированного алюминия на 4 персоны: котелок на 3 л с крышкой, сковорода, чайник на 1,1 л, 4 миски, 4 кружки, складной половник и лопатка. Все предметы компактно складываются друг в друга по принципу матрёшки и убираются в сетчатый мешок.",
                        PricePerDay = 350,
                        URLImage = "/Images/КухонныйНабор.png",
                        CategoryId = catMisc,
                        TotalQuantity = 5
                    }
                );
                await context.SaveChangesAsync();
            }

            if (await userManager.FindByNameAsync("client") == null)
            {
                var client = new AuthenticationModel 
                {
                    UserName = "client",
                    Login = "client",
                    FirstName = "Дмитрий",
                    LastName = "Юзеров",
                    Patronymic = "Матвеевич",
                    Email = "cnt@mail.ru",
                    Role = 0
                };
                await userManager.CreateAsync(client, "123456");
            }

            if (await userManager.FindByNameAsync("manager") == null)
            {
                var manager = new AuthenticationModel 
                {
                    UserName = "manager",
                    Login = "manager",
                    FirstName = "Алексей",
                    LastName = "Менеджеров",
                    Patronymic = "Алексеевич",
                    Email = "mgr@mail.ru",
                    Role = 1
                };
                await userManager.CreateAsync(manager, "123456");
                context.PinCodes.Add(new PinCodeModel { PinCode = "1111", UserId = manager.Id });
                await context.SaveChangesAsync();
            }

            if (await userManager.FindByNameAsync("admin") == null)
            {
                var admin = new AuthenticationModel
                {
                    UserName = "admin",
                    Login = "admin",
                    FirstName = "Дмитрий",
                    LastName = "Админов",
                    Patronymic = "Владимирович",
                    Email = "adm@mail.ru",
                    Role = 2
                };
                await userManager.CreateAsync(admin, "123456");
                context.PinCodes.Add(new PinCodeModel { PinCode = "2222", UserId = admin.Id });
                await context.SaveChangesAsync();
            }
        }
    }
}