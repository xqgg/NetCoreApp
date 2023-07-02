using System.ComponentModel.DataAnnotations;


namespace Core.ViewModel.Request
{
    public class AddUserRequest
    {
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

    }
}
