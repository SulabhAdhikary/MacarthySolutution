using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McCarthyMeasurementViewDomain
{
    public class MeasurementParameterAndValueViewDomain
    {
        public List<SizeStyleMasterViewDomain> MeasurementSizes { get; set; }

        public List<StyleGroupMeasurementParameterViewDomain> StyleMeasurementParametre { get; set; }
        public Dictionary<string, List<MeasurementSizeViewDomain>> MeasurementAndData { get; set; }

        public int GroupId { get; set; }
        public int StyleId { get; set; }

        public string viewMode { get; set; }
    }

    public class MeasurementSizeViewDomain
    {
        public int? sss_id { get; set; }
        public int? sgmpId { get; set; }
        public int? sizeId { get; set; }

        public string sizeCode { get; set; }
        public string measurement { get; set; }
    }

    public class SizeStyleMasterViewDomain
    {
        public string size_code { get; set; }
        public int size_id { get; set; }
    }

    public class StyleGroupMeasurementParameterViewDomain
    {
        public int sgmp_id { get; set; }
        public string sgmp_name { get; set; }
        public string sgmp_notes { get; set; }

    }


    public class MeasurementSizePostViewDomain
    {
      
        public int styleId { get; set; }

        public int groupId { get; set; }

        public string viewMode { get; set; }

        public List<MeasurementSizePostViewModelMetaData> measurementData { get; set; }

      
    }

    public class MeasurementSizePostViewModelMetaData
    {
        public int sizeId { get; set; }
        public int sgmpId { get; set; }
        public string measurement { get; set; }

    }
}
