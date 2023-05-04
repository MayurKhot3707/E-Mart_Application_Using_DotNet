using System.ComponentModel.DataAnnotations;

namespace E_mart_final_project.models
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }

        public string UserName { get; set; }

        /*[Required]
       [MinLength(8)]
        [MaxLength(15)]*/
        public string Password { get; set; }

    }
}
