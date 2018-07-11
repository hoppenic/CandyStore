using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CandyStore.Models
{
    public class SignInViewModel
    {
        
        [Required]
        public string UserName { get; set; }

        [Required]
        [MinLength(8,ErrorMessage ="Password must be at least 8 characters")]
        public string Password { get; set; }

    }
}
