using System.ComponentModel.DataAnnotations;

namespace E_mart_final_project.models
{
    public class ConfigMaster
    {
        [Key]
        public int ConfigID { get; set; }

        public string? ConfigName { get; set; }


        //navigation property (one to many)
        public ICollection<ProductDtlMaster>? ProductDtlMasters { get; set; }

    }
}
