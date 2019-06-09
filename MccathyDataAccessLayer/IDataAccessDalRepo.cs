using McarthyDataEntity;
using McarthyDataEntity.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MccathyDataAccessLayer
{
    public interface IDataAccessDalRepo
    {
        IEnumerable<Style_Group_Measurement_Parameter> GetStyleGroupMasterByGroupId(int groupId);
        /*
         *select sgmp.sgmp_id, sgmp.sgmp_name,sgmp.group_id, sgm.group_name  from [dbo].[Style_Group_Measurement_Parameter] sgmp  inner join [dbo].[Style_Group_Master] sgm 
          on sgmp.group_id = sgm.group_id  and  sgmp.group_id = 15
         * */

        IEnumerable<Style_Size_Master> GetStyleSizeMasterByGroupIdAndStyleId(int groupId, int styleId);
        /*
         * 
            select sm.style_id,
	               sm.style_code, 
	               sm.group_id,  
	               ssm.size_id,
	               ssm.size_code 
            from Style_Master sm inner  join Style_Size_Detail  ssd 
            on sm.style_id = ssd.style_id  
            inner join  Style_Size_Master ssm on ssd.size_id = ssm.size_id 
            where   sm.group_id = 15 and sm.style_id = 3806
         * */

        IEnumerable<StyleSizeSpecificationDomain> GetStyleSizeSpecification(int groupId, int styleId);

        IEnumerable<Style_Size_Specification> GetAllStyleSizeSpecification(int styleId, int sizeId);

       int SaveMeasurementData(List<Style_Size_Specification> measurementDatas);


        int UpdateMeasurementData(List<Style_Size_Specification> measurementDatas);
        
    }
}
