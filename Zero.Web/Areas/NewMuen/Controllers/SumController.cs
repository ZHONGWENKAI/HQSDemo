using Zero.Data.Projects;
using NewLife;
using NewLife.Cube;
using NewLife.Cube.Extensions;
using NewLife.Cube.ViewModels;
using NewLife.Web;

using Zero.Web.Areas.Projects;
using Microsoft.AspNetCore.Mvc;


namespace Zero.Web.Areas.NewMuen.Controllers
{
    /// <summary>存储用户信息</summary>
    [Menu(60, true, Icon = "fa-table")]
    [NewMuenArea]
    public class SumController : EntityController<DailyOrSum>
    {
        public override ActionResult Index(Pager p)
        {

            List<DailyOrSum> dailyOrSumList = (List<DailyOrSum>)DailyOrSum.FindAllByType(DailyOrSum.Kind.疗程总结);
            //ViewBag.user = user;
            //ViewData.Model = user;
            return View("Sum", dailyOrSumList);
        }
    }
}