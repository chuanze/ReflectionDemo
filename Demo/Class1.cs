using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Class1
    {
    }
    public abstract class BaseClass
    {
       
    }
    public struct DemoStruct { }
    public delegate void DemoDelegate(Object sender, EventArgs e);
    public enum DemoEnum
    {
        terrible, bad, common = 4, good, wonderful = 8
    }
    public interface IDemoInterface
    {
        void SayGreeting(string name);
    }
    public interface IDemoInterface2 { }
    [Record("更新","jim","2017-09-07",Memo ="修改了 ToString()方法")]
    [Record("创建","chuanze","2017-09-07")]
    public sealed class DemoClass : BaseClass, IDemoInterface, IDemoInterface2
    {
        private string name;
        public string city;
        public readonly string title;
        public const string text = "Const Field";
        public event DemoDelegate myEvent;
        public string Name
        {
            private get { return name; }
            set { name = value; }
        }
        public DemoClass()
        {
            title = "Readonly Field";
        }
        public class NestedClass { }
        public void SayGreeting(string name)
        {
            Console.WriteLine("Morning:" + name);
        }
        public override string ToString()
        {
            return "This is demo class";
        }
    }
    public class TestClass
    {
        [Obsolete("请使用新的ShowMsg(string sr)重载方法")]
        public static void ShowMsg()
        {
            Console.WriteLine("旧的方法");
        }
        public static void ShowMsg(string str)
        {
            Console.WriteLine("新的方法");
        }
    }
}
