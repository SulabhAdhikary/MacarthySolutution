namespace McarthyDataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Style_Group_Measurement_Parameter
    {
       [Key]
        public int sgmp_id { get; set; }

        public int? group_id { get; set; }

       
        public string sgmp_name { get; set; }

       
        public string sgmp_notes { get; set; }

       
        public DateTime? last_update { get; set; }

       
        public string last_update_by { get; set; }
    }
}
