using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isvb.dev.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Email { get; set; }
        
        public string UserName { get; set; }

        [Required]
        public bool EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public bool PhoneNumberConfirmed { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public int AccessFailedCount { get; set; }
        public string Name { get; set; }
    }
}
