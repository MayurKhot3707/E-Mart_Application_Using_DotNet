using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace E_mart_final_project.models
{
    public class User
    {

        [Key]
        public string? UserName { get; set; }

        [Required]
        [PasswordPropertyText]
        public string? Password { get; set; }

        public string? Email { get; set; }

        public long MobileNumber { get; set; }
        public int Points { get; set; }

        public string? Address { get; set; }
        public string? CardHolder { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }

        //navigation property (One to Many)
        public ICollection<AddToCart>? AddToCarts { get; set; }
        public ICollection<Payment>? Payments { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}