using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_mart_final_project.models
{
    public class Payment
    {
        [Key]
        public int PayID { get; set; }

        [ForeignKey("User")]
        public string? UserName { get; set; }

        [ForeignKey("Order")]
        public int OrderTID { get; set; }

        public string? PaymentType { get; set; }
        public string? PaymentMode { get; set; }

        //navigation property many to one
        public User? Users { get; set; }
        public Order? Orders { get; set; }
    }
}