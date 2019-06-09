namespace McarthyDataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public partial class Style_Group_Master
    {
       [Key]
        public int group_id { get; set; }

        public string group_name { get; set; }

        public DateTime last_update { get; set; }

       
        public string last_update_by { get; set; }

        public DateTime? record_delete_date { get; set; }

        public int? group_print_sequence { get; set; }

       
        public string group_catalog_name { get; set; }

       
        public string group_performance_report_name { get; set; }

       
        public string gropu_category { get; set; }

       
        public decimal? group_category_id { get; set; }

        public bool? group_allow_subgroup { get; set; }

        public int gt_id { get; set; }

        public byte? sales_volume_rank { get; set; }

        public bool? active_status { get; set; }
    }
}
