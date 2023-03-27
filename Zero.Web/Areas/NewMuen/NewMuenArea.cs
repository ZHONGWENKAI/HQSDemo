using System;
using System.ComponentModel;
using NewLife;
using NewLife.Cube;

namespace Zero.Web.Areas.NewMuen
{
    [DisplayName("花青素客户端")]
    public class NewMuenArea : AreaBase
    {
        public NewMuenArea() : base(nameof(NewMuenArea).TrimEnd("Area")) { }

        static NewMuenArea() => RegisterArea<NewMuenArea>();
    }
}