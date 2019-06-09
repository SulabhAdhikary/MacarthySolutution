using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace McarthyDataEntity
{
    public partial class Style_Size_Specification
    {
        [Key]
        public int sss_id { get; set; }

        public int? sgmp_id { get; set; }

        public int? style_id { get; set; }

        public int? size_id { get; set; }

       
        public string measurement { get; set; }

       
        public DateTime? last_update { get; set; }

      
        public string last_update_by { get; set; }
    }
}
