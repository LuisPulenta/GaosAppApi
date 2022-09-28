using System.ComponentModel.DataAnnotations;

namespace GenericApp.Common.Requests
{
    public class ChangePasswordRequest
    {
        [Required]
        public int IDUsuario { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
    }
}