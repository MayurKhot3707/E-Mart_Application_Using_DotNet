using System.ComponentModel.DataAnnotations;

namespace E_mart_final_project.models
{
    public class ProductMaster
    {
        [Key]
        public int ProductID { get; set; }
        public string? ProductName { get; set; }

        public string? ProductImage { get; set; }
        public string? ProductShortDescription { get; set; }
        public string? ProductLongDescription { get; set; }
        public double Price { get; set; }
        public double CardHolderPrice { get; set; }
        public int PointRedm { get; set; }
        public int Discount { get; set; }

        //navigation property (One to Many)
        public ICollection<ProductDtlMaster>? ProductDtlMasters { get; set; }
        public ICollection<CatMaster>? CatMasters { get; set; }
        public ICollection<AddToCart>? AddToCarts { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }

}