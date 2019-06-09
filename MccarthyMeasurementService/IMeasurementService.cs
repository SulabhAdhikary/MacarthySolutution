using McCarthyMeasurementViewDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MccarthyMeasurementService
{
    public interface IMeasurementService
    {
        MeasurementParameterAndValueViewDomain GetMeasurementData(int groupId, int styleId);
        int SaveMeasurementData(MeasurementSizePostViewDomain measurementSizePostViewDomain);
    }
}
