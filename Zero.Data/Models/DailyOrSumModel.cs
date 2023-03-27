using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Zero.Data.Projects
{
    /// <summary>打卡记录与用户疗程。存储用户疗程和打卡记录</summary>
    public partial class DailyOrSumModel : IDailyOrSum
    {
        #region 属性
        /// <summary>编号</summary>
        public Int32 ID { get; set; }

        /// <summary>用户ID</summary>
        public Int32 UserID { get; set; }

        /// <summary>效果ID</summary>
        public Int32 EffectID { get; set; }

        /// <summary>评价时间</summary>
        public DateTime EvaluateTime { get; set; }

        /// <summary>文字评论</summary>
        public String Evaluate { get; set; }

        /// <summary>录音</summary>
        public String Recording { get; set; }

        /// <summary>类型</summary>
        public Data.Projects.DailyOrSum.Kind Type { get; set; }

        /// <summary>备注</summary>
        public String Remark { get; set; }
        #endregion

        #region 拷贝
        /// <summary>拷贝模型对象</summary>
        /// <param name="model">模型</param>
        public void Copy(IDailyOrSum model)
        {
            ID = model.ID;
            UserID = model.UserID;
            EffectID = model.EffectID;
            EvaluateTime = model.EvaluateTime;
            Evaluate = model.Evaluate;
            Recording = model.Recording;
            Type = model.Type;
            Remark = model.Remark;
        }
        #endregion
    }
}