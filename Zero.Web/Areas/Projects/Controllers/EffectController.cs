using Zero.Data.Projects;
using NewLife;
using NewLife.Cube;
using NewLife.Cube.Extensions;
using NewLife.Cube.ViewModels;
using NewLife.Web;
using XCode.Membership;
using Zero.Web.Areas.Projects;

namespace Zero.Web.Areas.Projects.Controllers
{
    /// <summary>评价效果种类</summary>
    [Menu(20, true, Icon = "fa-table")]
    [ProjectsArea]
    public class EffectController : EntityController<Effect>
    {
        static EffectController()
        {
            //LogOnChange = true;

            //ListFields.RemoveField("Id", "Creator");
            ListFields.RemoveCreateField();
            ListFields.RemoveUpdateField();
            ListFields.RemoveRemarkField();
            //{
            //    var df = ListFields.GetField("Code") as ListField;
            //    df.Url = "?code={Code}";
            //}
            //{
            //    var df = ListFields.AddListField("devices", null, "Onlines");
            //    df.DisplayName = "查看设备";
            //    df.Url = "Device?groupId={Id}";
            //    df.DataVisible = e => (e as Effect).Devices > 0;
            //}
            //{
            //    var df = ListFields.GetField("Kind") as ListField;
            //    df.GetValue = e => ((Int32)(e as Effect).Kind).ToString("X4");
            //}
            //ListFields.TraceUrl("TraceId");
        }

        /// <summary>高级搜索。列表页查询、导出Excel、导出Json、分享页等使用</summary>
        /// <param name="p">分页器。包含分页排序参数，以及Http请求参数</param>
        /// <returns></returns>
        protected override IEnumerable<Effect> Search(Pager p)
        {
            //var deviceId = p["deviceId"].ToInt(-1);

            var start = p["dtStart"].ToDateTime();
            var end = p["dtEnd"].ToDateTime();

            return Effect.Search(start, end, p["Q"], p);
        }
    }
}