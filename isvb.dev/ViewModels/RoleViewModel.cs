using isvb.dev.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isvb.dev.ViewModels
{
    public class RoleViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string  RoleName { get; set; }
        public List<ApplicationUser> Users{ get; set; }
    }
}
