namespace McarthyDataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Style_Master
    {
        public int group_id { get; set; }

        public DateTime last_update { get; set; }

       
        public string last_update_by { get; set; }

        public DateTime? record_delete_date { get; set; }

        public int style_category_id { get; set; }

      
        public string style_code { get; set; }

       
        public string style_desc { get; set; }       

        [Key]
        public int style_id { get; set; }

        
        public string style_picture_back { get; set; }

        
        public string style_picture_front { get; set; }

        
        public string style_sex { get; set; }

        public int supplier_id { get; set; }

        
        public string style_type { get; set; }

        public int? style_plain_id { get; set; }

        public bool? style_exclude_plain_forecast { get; set; }

       
        public string style_fabric_desc { get; set; }

      
        public string style_catalog_name { get; set; }

        public int? old_style_id { get; set; }

        public int? pur_acc_id { get; set; }

        public int? subgroup_id { get; set; }

        public int? style_class_id { get; set; }

        public DateTime? created_date { get; set; }

      
        public string spec_pdf { get; set; }

      
        public string style_desc_fr { get; set; }
    }
}
