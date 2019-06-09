namespace McarthyDataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Style_Size_Master
    {
        public DateTime last_update { get; set; }

        
        public string last_update_by { get; set; }

        public DateTime? record_delete_date { get; set; }

        
        public string size_code { get; set; }

        [Key]
        public int size_id { get; set; }

        public int size_print_sequence { get; set; }

        public bool size_special { get; set; }

      
        public string size_type { get; set; }
    }
}
