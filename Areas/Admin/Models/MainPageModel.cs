using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace inln_bootstrap.Areas.Admin.Models
{
    public class MainPageModel
    {
        /// <summary>
        /// Лист клиентов
        /// </summary>
        public IEnumerable<ClientModel> Clients { get; set; }

        /// <summary>
        /// Лист проектов
        /// </summary>
        public IEnumerable<ProjectModel> Projects { get; set; }
    }
}