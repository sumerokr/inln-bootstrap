using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace inln_bootstrap.Areas.Admin.Models
{
    public class ProjectModel
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        [Display(Name = "ID")]
        public int ProjectId { get; set; }

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
        /// URL адрес
        /// </summary>
        [StringLength(255)]
        [DataType(DataType.Url)]
        [Display(Name = "URL адрес")]
        public string UrlAddress { get; set; }

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
        /// Главное изображение
        /// </summary>
        [StringLength(255)]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Главное изображение")]
        public string MainImage { get; set; }

        /// <summary>
        /// Описание главного изображения (alt)
        /// </summary>
        public string MainImageAlt { get { return this.Name; } }

        /// <summary>
        /// Подсказка главного изображения (title)
        /// </summary>
        public string MainImageTitle { get { return this.Name; } }

        /// <summary>
        /// Флаг удаления главного изображения
        /// </summary>
        [Display(Name = "Удалить главное изображение")]
        public bool MainImageToDelete { get; set; }

        /// <summary>
        /// Флаг добавления в слайдер
        /// </summary>
        [Display(Name = "В слайдер")]
        public bool IsSpecial { get; set; }

        /// <summary>
        /// Изображение для слайдера
        /// </summary>
        [StringLength(255)]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Изображение для слайдера")]
        public string SliderImage { get; set; }

        /// <summary>
        /// Описание изображения для слайдера
        /// </summary>
        public string SliderImageAlt { get { return this.Name; } }

        /// <summary>
        /// Подсказка изображения для слайдера
        /// </summary>
        public string SliderImageTitle { get { return this.Name; } }

        /// <summary>
        /// Флаг удаления изображение для слайдера
        /// </summary>
        [Display(Name = "Удалить изображение для слайдера")]
        public bool SliderImageToDelete { get; set; }

        /// <summary>
        /// Краткое описание
        /// </summary>
        [StringLength(512)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Краткое описание")]
        public string IntroText { get; set; }

        /// <summary>
        /// Полное описание
        /// </summary>
        [DataType(DataType.MultilineText)]
        [Display(Name = "Полное описание")]
        public string FullText { get; set; }

        /// <summary>
        /// Скан отзыва
        /// </summary>
        [StringLength(255)]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Скан отзыва")]
        public string ResponseImage { get; set; }

        /// <summary>
        /// Описание скана отзыва
        /// </summary>
        public string ResponseImageAlt { get { return "Скан отзыва " + this.Name; } }

        /// <summary>
        /// Подсказка скана отзыва
        /// </summary>
        public string ResponseImageTitle { get { return "Отзыв " + this.Name; } }

        /// <summary>
        /// Флаг удаления скана отзыва
        /// </summary>
        [Display(Name = "Удалить скан отзыва")]
        public bool ResponseImageToDelete { get; set; }

        /// <summary>
        /// Дочерние инфо-блоки
        /// </summary>
        public virtual List<InfoBlockModel> InfoBlocks { get; set; }

        /// <summary>
        /// ID родительского клиента
        /// </summary>
        [ScaffoldColumn(false)]
        [Display(Name = "ID родительского клиента")]
        public int ClientId { get; set; }

        /// <summary>
        /// Родительский клиент
        /// </summary>
        public virtual ClientModel Client { get; set; }

        /// <summary>
        /// Метод получения миниатюры
        /// </summary>
        /// <param name="imagePath">Путь до оригинального изображения</param>
        /// <param name="width">Требуемая ширина миниатюры</param>
        /// <param name="height">Требуемая высота миниатюры</param>
        /// <returns>Возвращает путь до миниатюры</returns>
        public string GetThumb(string imagePath, int width, int height)
        {
            return Utils.ImageHandler.ResizeAndCrop(imagePath, "Projects", this.Guid, width, height);
        }
    }
}