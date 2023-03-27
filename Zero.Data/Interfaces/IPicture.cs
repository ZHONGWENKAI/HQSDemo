using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Zero.Data.Projects
{
    /// <summary>图片。打卡记录与疗程总结里的图片</summary>
    public partial interface IPicture
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 ID { get; set; }

        /// <summary>名称</summary>
        String Content { get; set; }

        /// <summary>打卡总结表编号</summary>
        Int32 DailyOrSumID { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }
        #endregion
    }
}