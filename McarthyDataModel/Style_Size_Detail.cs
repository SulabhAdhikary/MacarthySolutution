namespace McarthyDataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Style_Size_Detail
    {
        [Key, Column(Order = 0)]
        public int style_id { get; set; }

        [Key, Column(Order = 1)]
        public int size_id { get; set; }

        public DateTime last_update { get; set; }

        public DateTime? record_delete_date { get; set; }
    }
}
