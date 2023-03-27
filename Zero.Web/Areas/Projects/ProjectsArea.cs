using System;
using System.ComponentModel;
using NewLife;
using NewLife.Cube;

namespace Zero.Web.Areas.Projects
{
    [DisplayName("花青素管理平台")]
    public class ProjectsArea : AreaBase
    {
        public ProjectsArea() : base(nameof(ProjectsArea).TrimEnd("Area")) { }

        static ProjectsArea() => RegisterArea<ProjectsArea>();
    }
}