using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace E_mart_final_project.models
{
    public class AddToCart
    {

        [Key]
        public int CartID { get; set; }

        [ForeignKey("User")]
        public string? UserName { get; set; }

        [ForeignKey("ProductMaster")]
        public int ProductID { get; set; }
        public string? ProductImage { get; set; }
        public string? ProductName { get; set; }
        public string? ProductShortDesc { get; set; }
        public int Price { get; set; }

        public double Discount { get; set; }

        public double CardHolderPrice { get; set; }
        public int PointRedm { get; set; }
        public int Qty { get; set; }

        //navigation property (many to one)
        public ProductMaster? ProductMasters { get; set; }
        public User? Users { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}