using MccarthyMeasurementService;
using McCarthyMeasurementViewDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MccarthyMeasurmentWeb.Controllers
{
    public class HomeController : Controller
    {
        private IMeasurementService _service;

        public HomeController(IMeasurementService service)
        {
            _service = service;
        }
        public ActionResult Index(int groupId, int styleId, string mode= "view")
        {
            var vm  =   _service.GetMeasurementData(groupId, styleId);
            vm.GroupId = groupId;
            vm.StyleId = styleId;
            vm.viewMode = mode;
            return View(vm);
        }

        [HttpPost]
        public ActionResult SaveMeasument(MeasurementSizePostViewDomain measurementSizePostViewDomain)
        {
            _service.SaveMeasurementData(measurementSizePostViewDomain);
            var vm = _service.GetMeasurementData(measurementSizePostViewDomain.groupId, measurementSizePostViewDomain.styleId);
            vm.GroupId = measurementSizePostViewDomain.groupId;
            vm.StyleId = measurementSizePostViewDomain.styleId;
            vm.viewMode = measurementSizePostViewDomain.viewMode;
            return View("Index",vm);
        }

      
    }
}