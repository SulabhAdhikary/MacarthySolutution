using McarthyDataEntity;
using MccarthyMeasurementService.Helper;
using McCarthyMeasurementViewDomain;
using MccathyDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MccarthyMeasurementService
{
    public class MeasurementService : IMeasurementService
    {
        private IDataAccessDalRepo _dal;
        public MeasurementService(IDataAccessDalRepo dal)
        {
            _dal = dal;
        }

        public MeasurementParameterAndValueViewDomain GetMeasurementData(int groupId, int styleId)
        {
            MeasurementParameterAndValueViewDomain objMeasurementParameterAndValueViewDomain = new MeasurementParameterAndValueViewDomain();
            var lstStyleGroupMaster = _dal.GetStyleGroupMasterByGroupId(groupId).Select(t=> new StyleGroupMeasurementParameterViewDomain
            {
                sgmp_id = t.sgmp_id,
                sgmp_name = t.sgmp_name,
                sgmp_notes = t.sgmp_notes
            });

            objMeasurementParameterAndValueViewDomain.StyleMeasurementParametre = lstStyleGroupMaster.ToList();

            var lstStyleSizeMaster = _dal.GetStyleSizeMasterByGroupIdAndStyleId(groupId, styleId).Select(t=> new SizeStyleMasterViewDomain
            {
                size_code = t.size_code,
                size_id = t.size_id
            });
            var lstStyleSizeSpecificationDomain = _dal.GetStyleSizeSpecification(groupId, styleId);

            objMeasurementParameterAndValueViewDomain.MeasurementSizes  = lstStyleSizeMaster.ToList();

            List<MeasurementSizeViewDomain> lstMeasurementSizeDomain = new List<MeasurementSizeViewDomain>();
            for (int i =0;i< lstStyleGroupMaster.Count(); ++i)
            {
                var perIndexMeasurementSpecs = lstStyleGroupMaster.ToList()[i];
                for(int  k =0;k< lstStyleSizeMaster.Count(); ++k)
                {
                    var perIndexMeausrmentSize = lstStyleSizeMaster.ToList()[k];
                    MeasurementSizeViewDomain objMeasurementSizeDomain = new MeasurementSizeViewDomain();
                    objMeasurementSizeDomain.sgmpId = perIndexMeasurementSpecs.sgmp_id;
                    objMeasurementSizeDomain.sizeId = perIndexMeausrmentSize.size_id;
                    objMeasurementSizeDomain.sizeCode = lstStyleSizeMaster.Where(t => t.size_id == perIndexMeausrmentSize.size_id).Select(t => t.size_code).FirstOrDefault();

                    var lstMeasurementResult = from sss in lstStyleSizeSpecificationDomain
                                            where sss.size_id == perIndexMeausrmentSize.size_id
                                            && sss.sgmp_id == perIndexMeasurementSpecs.sgmp_id
                                            select sss;
                    if(lstMeasurementResult != null && lstMeasurementResult.Count() > 0)
                    {
                        var objMeasurementResult = lstMeasurementResult.FirstOrDefault();
                        objMeasurementSizeDomain.sss_id = objMeasurementResult.sss_id;
                        objMeasurementSizeDomain.measurement = objMeasurementResult.measurement;
                    }
                    lstMeasurementSizeDomain.Add(objMeasurementSizeDomain);
                }
            }
            Dictionary<string,List<MeasurementSizeViewDomain>> measurmentUnitsAndSize  =  lstMeasurementSizeDomain.GroupBy(t => t.sizeCode).ToDictionary(gdc => gdc.Key, gdc => gdc.ToList());
            objMeasurementParameterAndValueViewDomain.MeasurementAndData = measurmentUnitsAndSize;
            return objMeasurementParameterAndValueViewDomain;
        }

        public int SaveMeasurementData(MeasurementSizePostViewDomain measurementSizePostViewDomain)
        {
            var sizeId = measurementSizePostViewDomain.measurementData.Select(t => t.sizeId).FirstOrDefault();
            var allExistingData = _dal.GetAllStyleSizeSpecification(measurementSizePostViewDomain.styleId, sizeId);

            var dataToBeInsertedTemp =  measurementSizePostViewDomain.measurementData.Select(t => new Style_Size_Specification
            {  
                last_update = DateTime.Now,
                size_id = sizeId,
                measurement = t.measurement,
                sgmp_id = t.sgmpId,
                style_id = measurementSizePostViewDomain.styleId
            });

            var dataToBeInserted = dataToBeInsertedTemp.Except(allExistingData, new  StyleSizeSpecificationComparer());
           
            foreach(var extData in allExistingData)
            {
                extData.measurement = measurementSizePostViewDomain.measurementData.Where(k => k.sgmpId == extData.sgmp_id && k.sizeId == extData.size_id).Select(m => m.measurement).FirstOrDefault();
            }

            var dataToBeinsertedOrUpdate = dataToBeInserted.Union(allExistingData);

            return   _dal.SaveMeasurementData(dataToBeinsertedOrUpdate.ToList());
        }

    }

   
}
