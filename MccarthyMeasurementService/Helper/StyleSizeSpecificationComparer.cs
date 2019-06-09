using McarthyDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MccarthyMeasurementService.Helper
{
    public class StyleSizeSpecificationComparer : EqualityComparer<Style_Size_Specification>
    {
        public override bool Equals(Style_Size_Specification x, Style_Size_Specification y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null || y == null)
                return false;

            return x.sgmp_id == y.sgmp_id && x.size_id == y.size_id;
        }
                 

        public override int GetHashCode(Style_Size_Specification obj)
        {
            int hCode = obj.sgmp_id.Value * obj.size_id.Value;
            return hCode.GetHashCode();
        }
    }
}
