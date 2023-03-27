using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Zero.Data.Projects
{
    /// <summary>图片。打卡记录与疗程总结里的图片</summary>
    public partial class PictureModel : IPicture
    {
        #region 属性
        /// <summary>编号</summary>
        public Int32 ID { get; set; }

        /// <summary>名称</summary>
        public String Content { get; set; }

        /// <summary>打卡总结表编号</summary>
        public Int32 DailyOrSumID { get; set; }

        /// <summary>备注</summary>
        public String Remark { get; set; }
        #endregion

        #region 拷贝
        /// <summary>拷贝模型对象</summary>
        /// <param name="model">模型</param>
        public void Copy(IPicture model)
        {
            ID = model.ID;
            Content = model.Content;
            DailyOrSumID = model.DailyOrSumID;
            Remark = model.Remark;
        }
        #endregion
    }
}