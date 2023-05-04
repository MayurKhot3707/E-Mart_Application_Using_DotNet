using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_mart_final_project.models
{
    public class ProductDtlMaster
    {
        [Key]
        public int ProductDtlID { get; set; }

        [ForeignKey("ProductMaster")]
        public int ProductID { get; set; }

        [ForeignKey("ConfigMaster")]
        public int ConfigID { get; set; }

        public string? ConfigDtl { get; set; }


        //navigation property many to one
        public ProductMaster? ProductMasters { get; set; }
        public ConfigMaster? ConfigMasters { get; set; }



    }
}