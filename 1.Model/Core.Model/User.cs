using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class User : Base.BaseModel
    {
        [StringLength(30)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }


        public string Roles { get; set; }

    }
}
