using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McarthyDataEntity.DomainModel
{
    public class StyleSizeSpecificationDomain
    {
        public int sss_id { get; set; }
        public int? sgmp_id { get; set; }
        public int style_id { get; set; }
        public string style_code { get; set; }

        public int group_id { get; set; }

        public int size_id { get; set; }

        public string size_code { get; set; }

        public string measurement { get; set; }
    }
}
