using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace inln_bootstrap.Areas.Admin.Models
{
    public class ClientModel
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        [Display(Name = "ID")]
        public int ClientId { get; set; }

        /// <summary>
        /// GUID
        /// </summary>
        [ScaffoldColumn(false)]
        [Display(Name = "GUID")]
        public Guid Guid { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        [ScaffoldColumn(false)]
        [Display(Name = "Дата создания")]
        public DateTime EntryCreated { get; set; }

        /// <summary>
        /// Видимость
        /// </summary>
        [Display(Name = "Видимость")]
        public bool IsVisible { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        [Required]
        [StringLength(255)]
        [DataType(DataType.Text)]
        [Display(Name = "Название")]
        public string Name { get; set; }

        /// <summary>
        /// Логотип
        /// </summary>
        [StringLength(255)]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Логотип")]
        public string Logo { get; set; }

        /// <summary>
        /// Описание логотипа (alt)
        /// </summary>
        public string LogoAlt { get { return "Логотип " + this.Name; } }

        /// <summary>
        /// Подсказка логотипа (title)
        /// </summary>
        public string LogoTitle { get { return this.Name; } }

        /// <summary>
        /// Флаг удаления логотипа
        /// </summary>
        [Display(Name = "Удалить логотип")]
        public bool LogoToDelete { get; set; }

        /// <summary>
        /// URL адрес
        /// </summary>
        [StringLength(255)]
        [DataType(DataType.Url)]
        [Display(Name = "URL адрес")]
        public string LogoUrl { get; set; }

        /// <summary>
        /// Описание клиента
        /// </summary>
        [StringLength(512)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Краткое описание")]
        public string Description { get; set; }

        /// <summary>
        /// Флаг добавления в карусель
        /// </summary>
        [Display(Name = "В карусель")]
        public bool IsSpecial { get; set; }

        /// <summary>
        /// Порядок вывода
        /// </summary>
        [Display(Name = "Порядок сортировки")]
        public int? Order { get; set; }

        /// <summary>
        /// Дочерние проекты
        /// </summary>
        public virtual List<ProjectModel> Projects { get; set; }

        /// <summary>
        /// Метод получения миниатюры
        /// </summary>
        /// <param name="imagePath">Путь до оригинального изображения</param>
        /// <param name="width">Требуемая ширина миниатюры</param>
        /// <param name="height">Требуемая высота миниатюры</param>
        /// <returns>Возвращает путь до миниатюры</returns>
        public string GetThumb(string imagePath, int width, int height)
        {
            return Utils.ImageHandler.ResizeAndCrop(imagePath, "Clients", this.Guid, width, height);
        }
    }
}