using System.Collections.Generic;

namespace WebApp.Web.Models
{
    public class ApplicationGroupViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ApplicationRoleViewModel> Roles { set; get; }
    }
}