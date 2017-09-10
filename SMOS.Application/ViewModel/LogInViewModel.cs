using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Balanca.Application.ViewModel
{
    public class LogInViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [HiddenInput]
        public string ReturnUrl { get; set; }
    }
}