using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    [Serializable]
    [AttributeUsage(AttributeTargets.All,AllowMultiple =true,Inherited =true)]
    //[ComVisible(true)]
    public class RecordAttribute:Attribute
    {
        private string recordType;//记录类型：更新/创建
        private string author;//作者
        private DateTime date;//更新、创建时间
        private string memo;//备注
        //够造函数、构造函数的参数在特性中也称为“位置参数”
        public RecordAttribute(string recordType,string author,string date)
        {
            this.recordType = recordType;
            this.author = author;
            this.date = Convert.ToDateTime(date);
        }
        //对于位置参数，通常只提供get访问器
        public string RecordType { get { return recordType; } }
        public string Author { get { return author; } }
        public DateTime Date { get { return date; } }
        //构造一个属性，在特性中也叫“命名参数”
        public string Memo
        {
            get { return memo; }
            set { memo = value; }
        }
    }
}
