using DiplomenP.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DiplomenP.Data
{
    public static class DatabaseSeed
    {
        public static async Task Seed(ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Seed roles
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                var adminRole = new IdentityRole("Admin");
                await roleManager.CreateAsync(adminRole);
            }
            if (!await roleManager.RoleExistsAsync("User"))
            {
                var userRole = new IdentityRole("User");
                await roleManager.CreateAsync(userRole);
            }

            // Seed admin user
            if (await userManager.FindByEmailAsync("admin@example.com") == null)
            {
                var adminUser = new User
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com"
                };
                var result = await userManager.CreateAsync(adminUser, "AdminPassword123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // Seed regular user
            if (await userManager.FindByEmailAsync("user@example.com") == null)
            {
                var regularUser = new User
                {
                    UserName = "user@example.com",
                    Email = "user@example.com"
                };
                var result = await userManager.CreateAsync(regularUser, "UserPassword123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(regularUser, "User");
                }
            }

            // Seed products
            if (!context.Products.Any())
            {
                var products = new List<Product>
    {
        new Product { ProductName = "Shimano Sedona 2500S FI", Price = 145.00, Type = "Front_advance", ProductCount = 180, 
            Image = "https://www.mftackle.com/image/cache/catalog/Makari/shimano/shimano/Sedona/2500-500x500.jpg", 
            Description = "Ѕеdоnа FІ e нaй-eвтинaтa cпинингoвa мaĸapa в peдицитe нa Ѕhіmаnо, ĸoятo пpeдлaгa НАGАNЕ пpeдaвĸи. Тежи 245г.", 
            Brand = "Shimano"},
        new Product { ProductName = "Linesystem KAWAHAGI PE X8", Price = 42.00, Type = "Braided_line", ProductCount = 283,
            Image = "https://hook.bg/image/cache/catalog/stoka/Linesystem/Kawahagi%20PE%20X8%20200m/20210117_093913-1000x1000.jpg",
            Description = "Linesystem KAWAHAGI PE X8 е 8 нишково плетено влакно е с 5 различни цвята и смяна на цвета на всеки 10 метра. Безшумност при преминаване на водачите. Дължина 200м.",
            Brand = "Kawahagi"},
        new Product { ProductName = "Джиг глави JAXON SUMATO BLACK", Price = 4.20, Type = "Lure", ProductCount = 500,
            Image = "https://veidiportid.is/wp-content/uploads/2022/07/jaxon-sumato-black-jig-onglar-veidiportid.png",
            Description = "Висококачествени джиг глави. Кръгла форма. Химически заточени офсетни куки. Допълнителна кука фиксираща кука от стомана. Предлагани варианти: 3, 4, 5, 6, 8, 10 грама. Номер куки: 1/0. По 3 броя в опаковка. За джиг риболов.",
            Brand = "Jaxon"},
        new Product { ProductName = "Jackson R.A. Pop Попер", Price = 32.50, Type = "Lure", ProductCount = 150,
            Image = "https://fishingzone.bg/thumbs/1/2209131535041.jpg",
            Description = "Jackson R.A. POP е попер, невероятно повърхностно забавление.",
            Brand = "Jackson"},
        new Product { ProductName = "Owner HOOKED SNAP SWIVEL", Price = 6.00, Type = "Fishing_accessories", ProductCount = 175,
            Image = "https://topfish.bg/image/cache/catalog/Virbeli/Owner/%206.00%2052567-1000x1000.jpg",
            Description = "Owner Hooked Snap Swivel са висококачествени вирбели с карабина изработени от първокласна стомана. Карабинaта е с много надеждна конструкция.",
            Brand = "OWNER"},
        new Product { ProductName = "Realis Popper 64 CCC3177 Jewel Beetle", Price = 27.40, Type = "Lure", ProductCount = 140,
            Image = "https://www.vuk.bg/media/catalog/product/cache/2dbed21a0ce9153c587164303fc3c8b4/r/e/realispopper64.jpg",
            Description = "Realis Popper 64 е малък попер от серията Realis на DUO International. Дълъг е 64мм и тежи 9 грама. ",
            Brand = "Duo"},
        new Product { ProductName = "Shimano Beastmaster FX Predator Въдица", Price = 325.00, Type = "Spinning_rod", ProductCount = 50,
            Image = "https://cdncloudcart.com/14162/products/images/66845/spiningova-vadica-shimano-beastmaster-fx-predator-image_5e831c1ccc10e_800x800.jpeg",
            Description = "Новите въдици в серията FX Predator са още по-леки, балансирани и здрави. Моделите разполагат с бланки от Nano Carbon, които са изключително чувствителни и с бърза реакция. Пръчката е оборудвана с екстремно устойчивите Fuji K Fazlite водачи.",
            Brand = "Shimano"},
        new Product { ProductName = "Shimano tribal tx 2 12 325 Въдица", Price = 284.00, Type = "Carp_rod", ProductCount = 100,
            Image = "https://carpmojo.com/image/cache/catalog/1_product_photos/24112020/vaditsa-shimano-tribal-tx2-12ft-3-0lb-carpmojo-com-1400x1400.jpg",
            Description = "Чрез доказани технологии, които използват карбон XT60, е създадена въдица с мощна и тънка бланка, с невероятна точност и дистанция при кастинг. Дължина - 365см. Транспортна дължина - 187см. Секции - 2 броя Водачи - 6 броя. Тегло - 434гр.",
            Brand = "Shimano"},
        new Product { ProductName = "Shimano Ultegra c2000s fc Mакара", Price = 324.00, Type = "Front_advance", ProductCount = 150,
            Image = "https://twitchfishing.com/10493-large_default/makara-shimano-ultegra-c2000-hg-fc-2021.jpg",
            Description = "Cъoтнoшeниe - 5.1:1. Мах Drаg - 3ĸг. Teглo - 185гp. Лaгepи - 6. Haвивaнe нa влaĸнo c 1 oбopoт - 69cм. Kaпaцитeт нa шпyлaтa(мм-м) - 0.16-105. Kaпaцитeт нa шпyлaтa(ĸoнeц) - #0.6 - 150.",
            Brand = "Shimano"},
        new Product { ProductName = "Katran synapse wild carp влакно", Price = 38.00, Type = "Monofilament_line", ProductCount = 200,
            Image = "https://carpmojo.com/image/cache/catalog/1_product_photos/katranm5kov/katran_0016_DSC_1202-650x650.jpg",
            Description = "Шаранджийско влакно Katran Wild Carp е специално разработено за риболов на див шаран и амур на големи дистанции. Катран Уаил Карп е бързо потъващо влакно и добре лежи на дъното. Уникалното антиабразивно покритие увеличава значително живота на влакното. Katran Wild Carp има удобни маркери на всеки 250 метра. Дълго е 1000m. ",
            Brand = "Synapse"},
        new Product { ProductName = "Vmc 7132 CT Docan Куки", Price = 8.00, Type = "One_hook", ProductCount = 501,
            Image = "https://cdn11.bigcommerce.com/s-hkv3fnh/products/7843/images/10186/docan-ringed__11087.1626709471.451.416.jpg",
            Description = "Мощна и здрава кована кука, подходяща приоритетно за риболов на шаран. Специалното матово PTFE покритие премахва ефективно отблясъците. Ухото позволява лесно и бързо изработване на монтажите, а контрата за бързото осбождаване на рибата.",
            Brand = "VMC"},
        new Product { ProductName = "ДИП STARBAITS GRAB & GO - Pineapple", Price = 17.00, Type = "Fishing_accessories", ProductCount = 70,
            Image = "https://best-fishing.bg/wp-content/uploads/2023/02/%D0%94%D0%B8%D0%BF-StarBaits-Grab-and-Go-Pineapple.jpg",
            Description = "Диповете са разработени в съответствие с хранителните нужди на шарана и се приемат от тях като естествена храна. Запазва своята привлекателност дори при по-дълги риболовни излети и е много подходящ за водоеми с трудни за ловене шарани.",
            Brand = "Starbaits"},
        new Product { ProductName = "Стойка с нивелир за 4 ВЪДИЦИ OSAKO CARP 186", Price = 180.00, Type = "Fishing_accessories", ProductCount = 90,
            Image = "https://cdncloudcart.com/14162/products/images/67941/sarandzijska-stojka-osako-bp188-image_5f58f9656abc3_1280x1280.jpeg?1599666719",
            Description = "Моделът е снабден с нивелир. Надеждната рамка позволява регулиране на дължината - от 87 до 127 см. Окомплектвани с месингови резби за захващане на сигнализатори. Височина: от 63 до 95 см Дължина: от 87 до 127 см Дължина на краката: от 40 до 71 см Широчина на стойката (дължина на бъзбаровете): 70 см Тегло: 2.800 кг. Транспортни размери: 90 х 10 х 10.",
            Brand = "Osako"},
        new Product { ProductName = "Воблер Попер YO-ZURI 3DS POPPER PCL", Price = 18.90, Type = "Lure", ProductCount = 70,
            Image = "https://best-fishing.bg/wp-content/uploads/2020/11/%D0%92%D0%BE%D0%B1%D0%BB%D0%B5%D1%80-%D0%9F%D0%BE%D0%BF%D0%B5%D1%80-Yo-Zuri-3DS-Popper-65mm-F1134-PCL.jpg",
            Description = "Yo-Zuri 3DS Popper е отлично балансирана примамка с впечатляваща 3D окраска. Перфектен избор за морски и сладководен спининг риболов на повърхността. Дължина: 6.5 см. Тегло: 7.0 г.",
            Brand = "Yo-Zuri"},
        new Product { ProductName = "Комплект Силиконови Примамки MIKADO SPEEDO 4.5 СМ", Price = 8.00, Type = "Lure", ProductCount = 170,
            Image = "https://usercontent.one/wp/www.abcdirekt.se/wp-content/uploads/2022/04/Mikado-Speedo-45-cm-jigg-8-stpkt-5.jpg",
            Description = "Състои се от 8 броя висококачествени примамки с дължина 4.5 см. Speedo е сред най-ефективните модели за джиг риболов на костур.",
            Brand = "Mikado"},
        new Product { ProductName = "Тролинг Въдица UGLY STIK GOLD TIGER TUFF", Price = 120.00, Type = "Trolling_rod", ProductCount = 70,
            Image = "https://www.fishingmayhem.com/img/product/shakespeare-ugly-stik-gold-tiger-tuff-6ft-1225lb-3009866-1600.jpg",
            Description = "Въдицата е практически подходяща за почти всички типове риболов от лодка, като е предпочитана за тежък тролинг и дори за риболов на сом на кльонк. Тя е почти нечуплива и осигурява отличен строй и баланс, гарантиращи успеха. Дължина на въдицата: 2.40м. Акция: 25-50 lb. Тегло: 458 г.",
            Brand = "Ugly Stik"},
        new Product { ProductName = "Макара PENN SLAMMER 460", Price = 216.00, Type = "Front_advance", ProductCount = 60,
            Image = "https://s13emagst.akamaized.net/products/47259/47258767/images/res_23021474aaf6a80a08ca42ceb33ceaec.jpg",
            Description = "Eкстремно здрави, мощни и издръжливи макари. За морски риболов. 6 стоманени лагера, със защита от корозия. Капацитет 0,35-220. Предавателно число: 5,1:1. Тегло: 546 грама.",
            Brand = "Penn"},
        new Product { ProductName = "Плетено Влакно Daiwa J-BRAID X8", Price = 50.00, Type = "Braided_line", ProductCount = 125,
            Image = "https://topfish.bg/image/cache/catalog/Vlakna%20/Daiwa/DIWJBFS20-1000x1000.jpg",
            Description = " Може да се използва с най- различни риболовни техники, в море, реки и езера и винаги да се разчита на безкомпромисните му качества и надеждност. 8 нишково плетено влакно. Висока устойчивост на триене. Висока сила на опън. Дъглжина - 300м.",
            Brand = "Daiwa"},
        new Product { ProductName = "Redhead Rapala magnum 7 inch", Price = 25.00, Type = "Lure", ProductCount = 80,
            Image = "https://cdn1.ozone.ru/s3/multimedia-s/6250860736.jpg",
            Description = "Потъваща примамка тролинг и спининг в море и сладка вода. Размер - 7 cm. Тегло - 12гр. Работна дълбочина - 3.3м.",
            Brand = "Rapala"},
        new Product { ProductName = "Кукан", Price = 9.90, Type = "Fishing_accessories", ProductCount = 150,
            Image = "https://nakukata.bg/wp-content/uploads/2021/02/926935__5d0c8f9f1950b.jpg",
            Description = "Аксесоар, който замества живарника и помага за запазване на уловената риба. 2.5 м плетено въже с дебелина 3 мм и 5 броя \"куки\" като всяка от тях е снабдена с вирбел в горната част и шлаух между тях. Всяка \"кука\" е с дължина 10 см и максимална ширина 3 см.",
            Brand = "Filstar"},
        new Product { ProductName = "Aquantic inliner boat", Price = 130.00, Type = "Spinning_rod", ProductCount = 50,
            Image = "https://cdncloudcart.com/14162/products/images/69340/vadica-za-lodka-penn-regiment-inner-boat-image_6091176dd6b2a_800x800.jpeg",
            Description = "По-бързо достигане на дълбочина отколкото с конвенционалните пръчки. Проектирана за битка с по- големите хищници. Транспортна дължина: 109 см Дължина: 210 см Брай части: 2 Нетно тегло: 300 гр Акция: 30lb.",
            Brand = "Aquantic"},
        new Product { ProductName = "120 QT Sportsman Sand/Carbon", Price = 509.00, Type = "Fishing_accessories", ProductCount = 68,
            Image = "https://3774-cdn.doitbest.com/Data/ItemImage-823107-q5xcvy-27xqrk-fn0690.jpg",
            Description = "Чантата задържа леда и студа в продължение на 5 дни. Тестовете са правени при над 32 градуса температура. Капацитет: Тегло: 8.255 кг. Обем: 114 литра. Външни размери (Д x Ш x В): 97.3 x 44.1 x 45.1 см.",
            Brand = "Igloo"},
        new Product { ProductName = "Кеп Cortland Teardrop Net Wooden Black Mesh", Price = 60.00, Type = "Fishing_accessories", ProductCount = 276,
            Image = "https://cdn.shopify.com/s/files/1/1410/4056/products/043372664043_Main_900x.jpg",
            Description = "Дървената мрежа Teardrop се отличава с плътно изплетена мека черна мрежа. Въртящата се каишка помага да се предотврати усукване. Обръчът е с многопластова дървена рамка, която придава допълнителна здравина. Размер на рамката: 22-1/2 X 8-1/2.",
            Brand = "Cortland"},
        new Product { ProductName = "JMC Fly Fishing SYNERGY мухарка", Price = 170.00, Type = "Fly_rod", ProductCount = 172,
            Image = "https://flyandflies.com/images/jmc-passion-p-21862/8730/600x600/FLY21862.webp",
            Description = "Пръчка на 4 части, за риболов с изкуствена муха. Високомодулен карбон HR. Водачи - кръгли.",
            Brand = "JMC"},
        new Product { ProductName = "Мухарска макара JMC Mamba", Price = 285.00, Type = "Fly_reel", ProductCount = 93,
            Image = "https://flyandflies.com/images/fly-and-flies/jmc-mamba-p-21885/22057/800x800/FLY21885.jpg",
            Description = "Алуминиево тяло - Larg arbor. Специално анодизирана. Изключително фин, дисков - микрометричен аванс. Лесна смяна за десен или ляв захват. Доставя се в неопренов калъф. Размери: 24 - 75 мм диам. x 34 мм 110 гр. / клас 2-4. WF4 И 60m. бекинг 20 lbs.",
            Brand = "JMC"},
        new Product { ProductName = "Шнур WAVE JMC", Price = 67.00, Type = "Monofilament_line", ProductCount = 232,
            Image = "https://flyandflies.com/images/jmc-wave-intermediate-p-22033/20906/600x600/FLY22033.jpg",
            Description = "Шнур - плуващ, за риболов с изкуствена муха. Изключително тънък, мек и безпаметен. Изразеният му конус на главата, позволява безпроблемен кастинг на дистанция, във всякакви метеорологични условия. WF - F профил. DT - F профил. Цвят - маслено зелен.",
            Brand = "JMC"},
        new Product { ProductName = "Изкуствена муха Goddard Sedge Original", Price = 2.50, Type = "Lure", ProductCount = 192,
            Image = "https://www.lavezzinifly.it/download/decv/332373/fulling-mill-goddard-sedge-natural-711.jpg",
            Description = "Размер на куката - 14. Goddard Sedge Original наподобява ларва. Подходяща за риболов на речни риби.",
            Brand = "Poseidon"},
        new Product { ProductName = "Дишащ гащеризон JMC Hydrox", Price = 380.00, Type = "Fishing_clothes", ProductCount = 135,
            Image = "https://cdn.mydreamshop.io/source/private/flyfishing/products/images/80bcfa6a20cb7d3b155da75bf88e3b97/161229724954896019b421860fd861.jpg",
            Description = "Водоустойчив и дишащ гащеризон, изработен от трипластова висококачествена мембрана. Изключително лек и удобен, модела притежава вътрешен и външен джоб,фиксиран колан, презрамки с корекции, корекция на гърдите, неопренови гети, неопренови чорапи 4,5mm. с усилени ходила.",
            Brand = "JMC"},
        new Product { ProductName = "Очила JMC K10", Price = 55.00, Type = "Fishing_clothes", ProductCount = 83,
            Image = "https://img.pecheur.com/polarized-sunglasses-jmc-k10-suran-z-1408-140805.jpg",
            Description = "Очилата JMC K10 са поларизирани с поликарбонатно стъкло. Леката и удобна рамка, осигурява вашият конфорт, по време на риболов.",
            Brand = "JMC"},
        new Product { ProductName = "Shimano exage 4000 fd", Price = 200.00, Type = "Front_advance", ProductCount = 260,
            Image = "https://static.spinning-market.com/resources/exage-fd.jpg",
            Description = "Макарата разполага с 4 защитени неръждаеми лагера и един ролков. Модел 3000S е перфектен за мач или спининг риболов с тънко монофилно или плетено влакно. Макарите се продават с резервна шпула. Тегло - 320 гр.",
            Brand = "Shimano"},
        new Product { ProductName = "Shimano kaрiкi 8 yellow", Price = 60.00, Type = "Braided_line", ProductCount = 131,
            Image = "https://www.mftackle.com/image/cache/catalog/Shimano/59WPLA68R30_cover-1000x1000.jpg",
            Description = "Shimano Kairiki 8 е плетено влакно с нова оплетка с 8 нишки. Toвa e мнoгo здpaвa и глaдĸa РЕ линия, ĸoятo e идeaлнa зa ĸacтинг нa дaлeчни paзcтoяния. Moжe дa ce пoлзвa ĸaĸтo в cлaдĸa, тaĸa и в coлeнa вoдa, тъй ĸaтo e мнoгo чyвcтвитeлнo и глaдĸo. Дължина - 300м.",
            Brand = "Shimano"},
        new Product { ProductName = "Filstar Rainbow Pro S чепаре", Price = 7.00, Type = "Lure", ProductCount = 280,
            Image = "https://best-fishing.bg/wp-content/uploads/2022/12/%D0%A7%D0%B5%D0%BF%D0%B0%D1%80%D0%B5-Filstar-Rainbow-Pro-S-2.jpg",
            Description = "Чепаре, изработено от много здраво и устойчиво на абразия и UV лъчи прозрачно влакно. Чепарето намира приложение както за морски риболов – на сафрид, лефер, скумрия, така и за сладководен риболов, основно за скумрия, сабица и други видове. На куките е поставено разнообразно по цвят ламе – сребристо, оранжево, розово, зелено, жълто. Дължина - 2,5м.",
            Brand = "Filstar"},
        new Product { ProductName = "Tica Spinfocus GS3050R/HM", Price = 68.00, Type = "Back_advance", ProductCount = 229,
            Image = "https://cdncloudcart.com/14162/products/images/59872/spiningova-makara-tica-spinfocus-gt-image_5e79d14dc03f1_800x800.jpeg",
            Description = "Има плавен ход и много добро напасване на компонентите. Предавателно число: 6.3:1. Обрано влакно за един оборот: 92сm. Тегло: 329g. За спининг риболов, риболов на плувка. Лагери - 5.",
            Brand = "Tica"},
        new Product { ProductName = "Filstar Power Treble PT-148TN", Price = 7.90, Type = "Three_hook", ProductCount = 121,
            Image = "https://best-fishing.bg/wp-content/uploads/2019/12/%D0%9A%D1%83%D0%BA%D0%B8-%D1%82%D1%80%D0%BE%D0%B9%D0%BA%D0%B8-Filstar-Power-Treble-141BC-2X-2.jpg",
            Description = "Отличават се с широка извивка, завидна острота, надеждна контра и страхотна задържаща способност. Тройните куки са с широко приложение в риболова на хищници - както с натурална стръв, така и с изкуствени примамки.  Перфектен избор за оборудване на воблери, въртящи блесни, клатушки и дp. Надеждна контра.",
            Brand = "Filstar"},
        new Product { ProductName = "Шапка FilStar No.4", Price = 7.50, Type = "Fishing_clothes", ProductCount = 191,
            Image = "https://filstar.com/data/uploads/originals/products/935194__5d0c92cd61fb1.jpg",
            Description = "Удобна памучна шапка с логото на FilStar. Подходяща за летните слънчеви дни.",
            Brand = "Filstar"}
    };
                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }

        }
    }
}
