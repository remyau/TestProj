using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProj.ViewModel
{
    public class MOCKTBLViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Required Last Name")]
        public string LastName { get; set; }
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = ("Must be a valid Email"))]
        public string Email { get; set; }
    }
}