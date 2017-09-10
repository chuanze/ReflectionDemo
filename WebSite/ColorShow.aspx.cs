using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace WebSite
{
    public partial class ColorShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Div> list = new List<Div>();
            Type t = typeof(Color);
            //获得全部静态属性
            PropertyInfo[] properties = t.GetProperties(BindingFlags.Static | BindingFlags.Public);
            Div div;
            //遍历属性
            foreach(PropertyInfo p in properties)
            {
                Color c = (Color)t.InvokeMember(p.Name, BindingFlags.GetProperty, null, null, null);
                div = new Div(c);
                list.Add(div);
            }
            list = list.OrderBy(x => x.ColorValue).ToList();
            foreach(Div item in list)
            {
                pnColors.Controls.Add(item);
            }
        }
    }
}