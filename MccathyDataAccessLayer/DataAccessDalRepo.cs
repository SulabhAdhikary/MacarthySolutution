using McarthyDataEntity;
using McarthyDataEntity.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MccathyDataAccessLayer
{
    public class DataAccessDalRepo : IDataAccessDalRepo
    {
        MaccarthyDataContext db = new MaccarthyDataContext();
        public IEnumerable<Style_Group_Measurement_Parameter> GetStyleGroupMasterByGroupId(int groupId)
        {
            var measurementParemsQuery = from mp in db.Style_Group_Measurement_Parameter
                                         where mp.group_id == groupId
                                         select mp;
            return measurementParemsQuery.ToList();
        }

        public IEnumerable<Style_Size_Master> GetStyleSizeMasterByGroupIdAndStyleId(int groupId, int styleId)
        {
            var styleSizeMasterQuery  = from sm in db.Style_Master
                      join ssd in db.Style_Size_Detail on sm.style_id equals ssd.style_id
                      join ssm in db.Style_Size_Master on ssd.size_id equals ssm.size_id
                      where sm.style_id == styleId
                      select ssm;

            return styleSizeMasterQuery.ToList();
        }

        public IEnumerable<StyleSizeSpecificationDomain> GetStyleSizeSpecification(int groupId, int styleId)
        {
            var styleSizeSpecificationQuery = from sm in db.Style_Master
                                              join ssd in db.Style_Size_Detail on sm.style_id equals ssd.style_id
                                              join ssm in db.Style_Size_Master on ssd.size_id equals ssm.size_id
                                              join sss1 in db.Style_Size_Specification on ssm.size_id equals sss1.size_id into sspAndSSm
                                              from sss in sspAndSSm.DefaultIfEmpty()
                                              where  sm.style_id == styleId && sss.style_id == ssd.style_id
                                              select new StyleSizeSpecificationDomain
                                              {
                                                 //sss_id = sss.sss_id,
                                                 sgmp_id =  sss.sgmp_id,
                                                 style_id = sm.style_id,
                                                 style_code = sm.style_code,
                                                 group_id = sm.group_id,
                                                 size_id = ssd.size_id,
                                                 size_code =  ssm.size_code,
                                                 measurement = sss.measurement
                                              };

            return styleSizeSpecificationQuery.ToList();
        }


        public IEnumerable<Style_Size_Specification> GetAllStyleSizeSpecification( int styleId, int sizeId)
        {
            var query = from sss in db.Style_Size_Specification
                        where sss.style_id == styleId && sss.size_id == sizeId
                        select sss;
            return query.ToList();

        }




        public int SaveMeasurementData(List<Style_Size_Specification> measurementDatas)
        {


            foreach(var data in measurementDatas)
            {
                
                    db.Entry(data).State =  data.sss_id == 0 ?
                                   EntityState.Added :
                                   EntityState.Modified;
               
            }
           return  db.SaveChanges();
        }

        public int UpdateMeasurementData(List<Style_Size_Specification> measurementDatas)
        {
            return 1;
        }
    }
}
