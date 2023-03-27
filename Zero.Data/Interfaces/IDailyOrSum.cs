using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Zero.Data.Projects
{
    /// <summary>打卡记录与用户疗程。存储用户疗程和打卡记录</summary>
    public partial interface IDailyOrSum
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 ID { get; set; }

        /// <summary>用户ID</summary>
        Int32 UserID { get; set; }

        /// <summary>效果ID</summary>
        Int32 EffectID { get; set; }

        /// <summary>评价时间</summary>
        DateTime EvaluateTime { get; set; }

        /// <summary>文字评论</summary>
        String Evaluate { get; set; }

        /// <summary>录音</summary>
        String Recording { get; set; }

        /// <summary>类型</summary>
        Data.Projects.DailyOrSum.Kind Type { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }
        #endregion
    }
}