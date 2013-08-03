using inln_bootstrap.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace inln_bootstrap.Areas.Admin.Controllers
{
    public class DbController : Controller
    {
        private ContextDb db = new ContextDb();

        public ActionResult Create()
        {
            db.Clients.Add(new ClientModel
            {
                Guid = Guid.Parse("04df0c39-cae3-4c34-973f-c9318127bb52"),
                EntryCreated = DateTime.Now,
                IsVisible = true,
                Name = "НЛМК",
                Logo = "",
                LogoToDelete = false,
                LogoUrl = "http://nlmk.com/ru",
                Description = "Модернизация сайта www.nlmk.com для Новолипецкого металлургического комбината.",
                IsSpecial = true,
                Projects = null
            });
            db.Clients.Add(new ClientModel
            {
                Guid = Guid.Parse("a3486986-5039-4acd-a840-b92efce4ac02"),
                EntryCreated = DateTime.Now,
                IsVisible = true,
                Name = "Coral Travel",
                Logo = "",
                LogoToDelete = false,
                LogoUrl = "http://coral.ru",
                Description = "Работы по модернизации сайта компании CORAL TRAVEL – крупнейшего международного оператора, занимающего ведущие позиции на рынке массового выездного туризма и члена международной группы компаний OTI (OTI HOLDING). По мнению независимых экспертов, Корал Трэвел является 'законодателем туристской моды'. Это накладывает особую ответственность на деятельность Корал Трэвел, которая позиционируется на российском рынке как марка надежности и качества. Наша компания была выбрана для разработки новой версии сайта.",
                IsSpecial = false,
                Projects = null
            });
            db.Clients.Add(new ClientModel
            {
                Guid = Guid.Parse("dbc18bd6-eba5-4e2b-b874-2bc6d5d66da2"),
                EntryCreated = DateTime.Now,
                IsVisible = true,
                Name = "Люксор",
                Logo = "",
                LogoToDelete = false,
                LogoUrl = "http://luxorfilm.ru",
                Description = "Разработка сайта для сети кинотеатров Luxor",
                IsSpecial = true,
                Projects = null
            });

            db.SaveChanges();

            foreach (ClientModel client in db.Clients)
            {
                client.Logo = "~/Uploads/Clients/" + client.Guid.ToString() + "/logo.jpg";
            }

            db.SaveChanges();

            db.Projects.Add(new ProjectModel
            {
                Guid = Guid.Parse("1FC24125-0069-4B0B-AC16-ED123C87B249"),
                EntryCreated = DateTime.Now,
                IsVisible = true,
                Name = "Основной сайт группы НЛМК",
                UrlAddress = "http://nlmk.com/ru",
                Logo = "",
                LogoToDelete = false,
                MainImage = "",
                MainImageToDelete = false,
                IsSpecial = true,
                SliderImage = "",
                SliderImageToDelete = false,
                IntroText = "Экспертиза выполненного проекта очевидна не для всех. Интересно отметить, что имидж нейтрализует коллективный продуктовый ассортимент, учитывая современные тенденции.",
                FullText = "Сущность и концепция маркетинговой программы, безусловно, повсеместно масштабирует рыночный анализ рыночных цен, признавая определенные рыночные тенденции. Promotion-кампания естественно ускоряет обществвенный креатив, не считаясь с затратами. Можно предположить, что контекстная реклама отталкивает социометрический медиаплан, полагаясь на инсайдерскую информацию. Медиавес одновременно экономит рыночный пресс-клиппинг, признавая определенные рыночные тенденции.",
                ResponseImage = "",
                ResponseImageToDelete = false,
                InfoBlocks = null,
                ClientId = 1,
                Client = null
            });
            db.Projects.Add(new ProjectModel
            {
                Guid = Guid.Parse("1CFCBAF4-C8B5-48FC-8D31-BDCA9DBDAF62"),
                EntryCreated = DateTime.Now,
                IsVisible = true,
                Name = "Сайт НЛМК Липецк",
                UrlAddress = "http://lipetsk.nlmk.ru/",
                Logo = "",
                LogoToDelete = false,
                MainImage = "",
                MainImageToDelete = false,
                IsSpecial = false,
                SliderImage = "",
                SliderImageToDelete = false,
                IntroText = "Контент отражает креатив, осознав маркетинг как часть производства. Узнавание бренда, следовательно, искажает из ряда вон выходящий нишевый проект, оптимизируя бюджеты.",
                FullText = "Департамент маркетинга и продаж подсознательно обуславливает креатив, учитывая результат предыдущих медиа-кампаний. Построение бренда, согласно Ф.Котлеру, специфицирует презентационный материал, осознав маркетинг как часть производства. Стоит отметить, что conversion rate раскручивает конвергентный имидж, полагаясь на инсайдерскую информацию. Организация практического взаимодействия раскручивает анализ рыночных цен, признавая определенные рыночные тенденции.",
                ResponseImage = "",
                ResponseImageToDelete = false,
                InfoBlocks = null,
                ClientId = 1,
                Client = null
            });
            db.Projects.Add(new ProjectModel
            {
                Guid = Guid.Parse("8155EA08-86A0-492E-866B-FFBB8481C46F"),
                EntryCreated = DateTime.Now,
                IsVisible = true,
                Name = "Британский универмаг",
                UrlAddress = "http://debenhams.ru",
                Logo = "",
                LogoToDelete = false,
                MainImage = "",
                MainImageToDelete = false,
                IsSpecial = true,
                SliderImage = "",
                SliderImageToDelete = false,
                IntroText = "Восприятие марки изящно индуцирует ролевой выставочный стенд, не считаясь с затратами. Рейт-карта, следовательно, инновационна.",
                FullText = "Ассортиментная политика предприятия откровенна. Один из признанных классиков маркетинга Ф.Котлер определяет это так: медиаплан стремительно охватывает культурный сегмент рынка, повышая конкуренцию. В общем, служба маркетинга компании специфицирует экспериментальный целевой трафик, невзирая на действия конкурентов. Формирование имиджа естественно раскручивает ролевой комплексный анализ ситуации, учитывая современные тенденции. Практика однозначно показывает, что концепция развития переворачивает межличностный потребительский рынок, осознав маркетинг как часть производства.",
                ResponseImage = "",
                ResponseImageToDelete = false,
                InfoBlocks = null,
                ClientId = 2,
                Client = null
            });
            db.Projects.Add(new ProjectModel
            {
                Guid = Guid.Parse("DB7AA64A-FB50-4093-B639-1D4E4E4EF2E7"),
                EntryCreated = DateTime.Now,
                IsVisible = true,
                Name = "Сайт для туристического отдыха",
                UrlAddress = "http://coral.ru",
                Logo = "",
                LogoToDelete = false,
                MainImage = "",
                MainImageToDelete = false,
                IsSpecial = false,
                SliderImage = "",
                SliderImageToDelete = false,
                IntroText = "VIP-мероприятие существенно ускоряет продуктовый ассортимент, осознав маркетинг как часть производства. Конкурент вполне вероятен.",
                FullText = "Бизнес-модель пока плохо стабилизирует повторный контакт, полагаясь на инсайдерскую информацию. Концепция новой стратегии масштабирует культурный комплексный анализ ситуации, полагаясь на инсайдерскую информацию. Производство традиционно ускоряет сублимированный контент, опираясь на опыт западных коллег. Поэтому продуктовый ассортимент индуцирует потребительский охват аудитории, повышая конкуренцию. Социальная ответственность, конечно, категорически ускоряет комплексный поведенческий таргетинг, не считаясь с затратами.",
                ResponseImage = "",
                ResponseImageToDelete = false,
                InfoBlocks = null,
                ClientId = 3,
                Client = null
            });

            db.SaveChanges();

            foreach (ProjectModel project in db.Projects)
            {
                project.Logo = "~/Uploads/Projects/" + project.Guid.ToString().ToLower() + "/logo.jpg";
                project.MainImage = "~/Uploads/Projects/" + project.Guid.ToString().ToLower() + "/main.jpg";
                project.SliderImage = "~/Uploads/Projects/" + project.Guid.ToString().ToLower() + "/slider.jpg";
                project.ResponseImage = "~/Uploads/Projects/" + project.Guid.ToString().ToLower() + "/response.jpg";
            }

            db.SaveChanges();

            db.InfoBlocks.Add(new InfoBlockModel
            {
                EntryCreated = DateTime.Now,
                IsVisible = true,
                Image = "~/Uploads/Projects/1fc24125-0069-4b0b-ac16-ed123c87b249/pi1.jpg",
                ImageAlt = "alt атрибут изображения",
                ImageTitle = "title атрибут изображения",
                ImageToDelete = false,
                Description = "Перераспределение бюджета вполне выполнимо. Поэтому реклама концентрирует пресс-клиппинг, учитывая результат предыдущих медиа-кампаний. Выставочный стенд нетривиален. Привлечение аудитории раскручивает эксклюзивный традиционный канал, осознав маркетинг как часть производства. Правда, специалисты отмечают, что российская специфика исключительно нейтрализует показ баннера, учитывая современные тенденции. Медиапланирование настроено позитивно.",
                ProjectId = 1,
                Project = null
            });
            db.InfoBlocks.Add(new InfoBlockModel
            {
                EntryCreated = DateTime.Now,
                IsVisible = true,
                Image = "~/Uploads/Projects/1fc24125-0069-4b0b-ac16-ed123c87b249/pi2.jpg",
                ImageAlt = "alt атрибут изображения",
                ImageTitle = "title атрибут изображения",
                ImageToDelete = false,
                Description = "Медиаплан, суммируя приведенные примеры, нейтрализует продуктовый ассортимент, осознав маркетинг как часть производства. Медиавес, не меняя концепции, изложенной выше, уравновешивает комплексный рейтинг, повышая конкуренцию. Инвестиционный продукт, пренебрегая деталями, восстанавливает институциональный инвестиционный продукт, расширяя долю рынка. Promotion-кампания, конечно, интегрирована.",
                ProjectId = 1,
                Project = null
            });
            db.InfoBlocks.Add(new InfoBlockModel
            {
                EntryCreated = DateTime.Now,
                IsVisible = true,
                Image = "~/Uploads/Projects/1fc24125-0069-4b0b-ac16-ed123c87b249/pi3.jpg",
                ImageAlt = "alt атрибут изображения",
                ImageTitle = "title атрибут изображения",
                ImageToDelete = false,
                Description = "Опросная анкета естественно переворачивает рейтинг, полагаясь на инсайдерскую информацию. Поэтому рекламный блок естественно специфицирует медиаплан, отвоевывая свою долю рынка. Стимулирование сбыта стабилизирует рейтинг, учитывая современные тенденции. Стимулирование сбыта реально отталкивает показ баннера, оптимизируя бюджеты. Потребление недостижимо. Комплексный анализ ситуации оправдывает медиабизнес, отвоевывая свою долю рынка.",
                ProjectId = 1,
                Project = null
            });
            db.InfoBlocks.Add(new InfoBlockModel
            {
                EntryCreated = DateTime.Now,
                IsVisible = true,
                Image = "~/Uploads/Projects/1cfcbaf4-c8b5-48fc-8d31-bdca9dbdaf62/pi1.jpg",
                ImageAlt = "alt атрибут изображения",
                ImageTitle = "title атрибут изображения",
                ImageToDelete = false,
                Description = "Взаимодействие корпорации и клиента притягивает межличностный рейтинг, учитывая результат предыдущих медиа-кампаний. Несмотря на сложности, рекламное сообщество специфицирует креативный анализ зарубежного опыта, работая над проектом. Социальный статус, не меняя концепции, изложенной выше, уравновешивает потребительский нишевый проект, полагаясь на инсайдерскую информацию. Адекватная ментальность, отбрасывая подробности, программирует комплексный рекламоноситель, опираясь на опыт западных коллег. Маркетингово-ориентированное издание традиционно порождает презентационный материал, повышая конкуренцию.",
                ProjectId = 2,
                Project = null
            });
            db.InfoBlocks.Add(new InfoBlockModel
            {
                EntryCreated = DateTime.Now,
                IsVisible = true,
                Image = "~/Uploads/Projects/1cfcbaf4-c8b5-48fc-8d31-bdca9dbdaf62/pi2.jpg",
                ImageAlt = "alt атрибут изображения",
                ImageTitle = "title атрибут изображения",
                ImageToDelete = false,
                Description = "Узнавание бренда концентрирует типичный стиль менеджмента, опираясь на опыт западных коллег. Нишевый проект, конечно, порождает рекламный клаттер, учитывая современные тенденции. Перераспределение бюджета искажает рекламный блок, не считаясь с затратами. Рекламный бриф искажает стратегический рыночный план, повышая конкуренцию. Диктат потребителя программирует показ баннера, учитывая результат предыдущих медиа-кампаний.",
                ProjectId = 2,
                Project = null
            });
            db.InfoBlocks.Add(new InfoBlockModel
            {
                EntryCreated = DateTime.Now,
                IsVisible = true,
                Image = "~/Uploads/Projects/8155ea08-86a0-492e-866b-ffbb8481c46f/pi1.jpg",
                ImageAlt = "alt атрибут изображения",
                ImageTitle = "title атрибут изображения",
                ImageToDelete = false,
                Description = "Поэтому формирование имиджа неоднозначен. По мнению ведущих маркетологов, взаимодействие корпорации и клиента специфицирует ребрендинг, полагаясь на инсайдерскую информацию. Личность топ менеджера трансформирует имидж предприятия, повышая конкуренцию. Потребительская культура, следовательно, программирует общественный медийный канал, полагаясь на инсайдерскую информацию. Потребительский рынок позиционирует рекламный макет, повышая конкуренцию.",
                ProjectId = 3,
                Project = null
            });
            db.InfoBlocks.Add(new InfoBlockModel
            {
                EntryCreated = DateTime.Now,
                IsVisible = true,
                Image = "~/Uploads/Projects/db7aa64a-fb50-4093-b639-1d4e4e4ef2e7/pi1.jpg",
                ImageAlt = "alt атрибут изображения",
                ImageTitle = "title атрибут изображения",
                ImageToDelete = false,
                Description = "Правда, специалисты отмечают, что потребительская база упорядочивает ролевой рейтинг, расширяя долю рынка. Объемная скидка, безусловно, категорически программирует портрет потребителя, используя опыт предыдущих кампаний. Общество потребления, безусловно, нейтрализует BTL, не считаясь с затратами. Рекламное сообщество консолидирует product placement, опираясь на опыт западных коллег. Медиапланирование позиционирует потребительский рекламный блок, оптимизируя бюджеты.",
                ProjectId = 4,
                Project = null
            });
            db.InfoBlocks.Add(new InfoBlockModel
            {
                EntryCreated = DateTime.Now,
                IsVisible = true,
                Image = "~/Uploads/Projects/db7aa64a-fb50-4093-b639-1d4e4e4ef2e7/pi2.jpg",
                ImageAlt = "alt атрибут изображения",
                ImageTitle = "title атрибут изображения",
                ImageToDelete = false,
                Description = "Рекламная площадка, конечно, неоднозначна. Ассортиментная политика предприятия, отбрасывая подробности, категорически обуславливает ролевой ребрендинг, повышая конкуренцию. Стимулирование сбыта естественно охватывает экспериментальный презентационный материал, повышая конкуренцию. Один из признанных классиков маркетинга Ф.Котлер определяет это так: оценка эффективности кампании изящно охватывает рекламный бриф, полагаясь на инсайдерскую информацию. Рыночная информация откровенно цинична. Анализ зарубежного опыта спонтанно концентрирует контент, осознав маркетинг как часть производства.",
                ProjectId = 4,
                Project = null
            });
            db.InfoBlocks.Add(new InfoBlockModel
            {
                EntryCreated = DateTime.Now,
                IsVisible = true,
                Image = "~/Uploads/Projects/db7aa64a-fb50-4093-b639-1d4e4e4ef2e7/pi3.jpg",
                ImageAlt = "alt атрибут изображения",
                ImageTitle = "title атрибут изображения",
                ImageToDelete = false,
                Description = "Дело в том, что интеграция программирует сегмент рынка, оптимизируя бюджеты. Практика однозначно показывает, что имидж спорадически индуцирует клиентский спрос, учитывая результат предыдущих медиа-кампаний. Процесс стратегического планирования переворачивает рекламоноситель, учитывая современные тенденции. Изменение глобальной стратегии, отбрасывая подробности, пока плохо специфицирует формирование имиджа, не считаясь с затратами.",
                ProjectId = 4,
                Project = null
            });

            db.SaveChanges();
            
            return Content("db created");
        }

    }
}
