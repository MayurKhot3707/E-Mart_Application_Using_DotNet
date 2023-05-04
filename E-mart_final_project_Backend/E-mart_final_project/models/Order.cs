using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_mart_final_project.models
{
    public class Order
    {
        [Key]
        public int OrderTID { get; set; }

        [ForeignKey("User")]
        public string? UserName { get; set; }

        [ForeignKey("ProductMaster")]
        public int ProductID { get; set; }

        [ForeignKey("AddToCart")]
        public int CartID { get; set; }

        public double Price { get; set; }
        public float Discount { get; set; }
        public double CardHolderPrice { get; set; }
        public int PointRedm { get; set; }
        public DateTime OrderDate { get; set; }
        public double GrandTotal { get; set; }


        //navigation property many to one
        public User? Users { get; set; }
        public ProductMaster? ProductMasters { get; set; }
        public AddToCart? AddToCarts{ get; set; }

        public ICollection<Payment>? Payments { get; set; }


    }
}