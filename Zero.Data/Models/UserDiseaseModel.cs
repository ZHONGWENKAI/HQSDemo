using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Zero.Data.Projects
{
    /// <summary>用户疾病。用户疾病对应表</summary>
    public partial class UserDiseaseModel : IUserDisease
    {
        #region 属性
        /// <summary>编号</summary>
        public Int32 ID { get; set; }

        /// <summary>用户ID</summary>
        public Int32 UserID { get; set; }

        /// <summary>疾病ID</summary>
        public Int32 DiseaseID { get; set; }

        /// <summary>备注</summary>
        public String Remark { get; set; }
        #endregion

        #region 拷贝
        /// <summary>拷贝模型对象</summary>
        /// <param name="model">模型</param>
        public void Copy(IUserDisease model)
        {
            ID = model.ID;
            UserID = model.UserID;
            DiseaseID = model.DiseaseID;
            Remark = model.Remark;
        }
        #endregion
    }
}