using isvb.dev.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isvb.dev.ViewModels
{
   
    public class EditRoleViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public Enums.Role Role { get; set; }
    }
}
