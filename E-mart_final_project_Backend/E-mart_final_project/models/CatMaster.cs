using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_mart_final_project.models
{
    public class CatMaster
    {
            [Key]
        public int CatMasterID { get; set; }
        public string? CatID { get; set; }
        public string? SubCatID { get; set; }
        public string? CatName { get; set; }

        [ForeignKey("ProductMaster")]
        public int? ProductID { get; set; }
        public string? CatImagPath { get; set; }
        public string? Flag { get; set; }

        //navigation property (many to one)
        public ProductMaster? ProductMasters { get; set; }

    }
}
