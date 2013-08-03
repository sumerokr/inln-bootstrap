using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace inln_bootstrap.Areas.Admin.Models
{
    public class InfoBlockModel
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        [Display(Name = "ID")]
        public int InfoBlockId { get; set; }

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
        /// Изображение
        /// </summary>
        [StringLength(255)]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Изображение")]
        public string Image { get; set; }

        /// <summary>
        /// Описание изображения (alt атрибут)
        /// </summary>
        [StringLength(255)]
        [DataType(DataType.Text)]
        [Display(Name = "Описание изображения (alt атрибут)")]
        public string ImageAlt { get; set; }

        /// <summary>
        /// Подсказка изображения (title атрибут)
        /// </summary>
        [StringLength(255)]
        [DataType(DataType.Text)]
        [Display(Name = "Подсказка изображения (title атрибут)")]
        public string ImageTitle { get; set; }

        /// <summary>
        /// Флаг удаления изображения
        /// </summary>
        [Display(Name = "Удалить изображение")]
        public bool ImageToDelete { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        /// <summary>
        /// ID родительского проекта
        /// </summary>
        [ScaffoldColumn(false)]
        [Display(Name = "ID родительского проекта")]
        public int ProjectId { get; set; }

        /// <summary>
        /// Родительский проект
        /// </summary>
        public virtual ProjectModel Project { get; set; }

        /// <summary>
        /// Метод получения миниатюры
        /// </summary>
        /// <param name="imagePath">Путь до оригинального изображения</param>
        /// <param name="width">Требуемая ширина миниатюры</param>
        /// <param name="height">Требуемая высота миниатюры</param>
        /// <returns>Возвращает путь до миниатюры</returns>
        public string GetThumb(string imagePath, int width, int height)
        {
            return Utils.ImageHandler.ResizeAndCrop(imagePath, "Projects", this.Project.Guid, width, height);
        }
    }
}