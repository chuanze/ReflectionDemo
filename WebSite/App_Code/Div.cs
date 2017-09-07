using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

namespace WebSite
{
    public class Div:HtmlGenericControl
    {
        public int ColorValue { get; set; }
        public Div(Color c):base("div")//调用基类构造函数，创建一个 Div
        {
            //设置文本
            this.InnerHtml = String.Format("{0}<br/>RGB({1},{2},{3})", c.Name, c.R, c.G, c.B);
            this.ColorValue = c.R * 256 * 256 + c.G * 256 + c.B;
            int total = c.R + c.G + c.B;
            if(total<=255)//如果背景颜色太暗，前景色改为明色调
                this.Style.Add("color","#eee");
            //设置背景颜色
            this.Style.Add("background", String.Format("rgb{0},{1},{2}", c.R, c.B, c.G));
        }
    }
}