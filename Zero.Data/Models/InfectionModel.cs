using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Zero.Data.Projects
{
    /// <summary>新冠感染状态</summary>
    public partial class InfectionModel : IInfection
    {
        #region 属性
        /// <summary>编号</summary>
        public Int32 ID { get; set; }

        /// <summary>名称</summary>
        public String Name { get; set; }

        /// <summary>备注</summary>
        public String Remark { get; set; }
        #endregion

        #region 拷贝
        /// <summary>拷贝模型对象</summary>
        /// <param name="model">模型</param>
        public void Copy(IInfection model)
        {
            ID = model.ID;
            Name = model.Name;
            Remark = model.Remark;
        }
        #endregion
    }
}