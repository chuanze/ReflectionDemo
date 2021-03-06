﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Demo;
using System.Runtime.Remoting;

namespace SimpleExplort
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyExplore();
            Type t = typeof(DemoClass);
            TypeExplore(t);

            MemberExplore(t);

            FieldExplore(t);

            Console.WriteLine(string.Empty.PadLeft(50, '-'));
            Console.WriteLine("特性使用");
            TestClass.ShowMsg();
            TestClass.ShowMsg("yse");
            Console.WriteLine("自定以特性");
            DemoClass demo = new DemoClass();
            Console.WriteLine(demo.ToString());

            Console.WriteLine(string.Empty.PadLeft(50, '-'));
            Console.WriteLine("通过反射获得自定义反射信息");
            CustomAttributeExplore(t);

            Console.WriteLine(string.Empty.PadLeft(50, '-'));
            Console.WriteLine("调用方法1");
            InvokeMethod1(typeof(Calculator));
            InvokeStaticMethod1(typeof(Calculator));
            Console.WriteLine(string.Empty.PadLeft(50, '-'));
            Console.WriteLine("调用方法2");
            InvokeMethod2(typeof(Calculator));
            InvokeStaticMethod2(typeof(Calculator));
            //Console.ReadKey();
        }
        public static void AssemblyExplore()
        {
            //Console.WriteLine("左60".PadLeft(10));
            //Console.WriteLine("右60".PadRight(60));
            StringBuilder sb = new StringBuilder();
            Assembly asm = Assembly.Load("Demo");
            sb.AppendLine("FullName(全名):" + asm.FullName);
            sb.AppendLine("Location(路径):" + asm.Location);
            Module[] modules = asm.GetModules();
            foreach (Module module in modules)
            {
                sb.AppendLine("模块：" + module);
                Type[] types = module.GetTypes();
                foreach (Type type in types)
                {
                    sb.AppendLine("类型：" + type);
                }
            }
            Console.WriteLine(sb.ToString());
        }
        #region 类型基本信息
        /// <summary>
        /// 获取类型基本信息
        /// </summary>
        /// <param name="t"></param>
        public static void TypeExplore(Type t)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("名称信息：\n");
            sb.Append("Name:" + t.Name + "\n");
            sb.Append("FullName:" + t.FullName + "\n");
            sb.Append("Namespace:" + t.Namespace + "\n");
            sb.Append("\n其他信息:\n");
            sb.Append("BaseType(基类型):" + t.BaseType + "\n");
            sb.Append("UnderlyingSystemType:" + t.UnderlyingSystemType + "\n");
            sb.Append("\n类型信息：\n");
            sb.AppendLine("Attributes(TypeAttributes位标记)：" + t.Attributes);
            sb.AppendLine("IsValueType(值类型)：" + t.IsValueType);
            sb.AppendLine("IsEnum(枚举)：" + t.IsEnum);
            sb.AppendLine("IsClass(类)：" + t.IsClass);
            sb.AppendLine("IsArray(数组)：" + t.IsArray);
            sb.AppendLine("IsInterface(接口)：" + t.IsInterface);
            sb.AppendLine("IsPointer(指针)：" + t.IsPointer);
            sb.AppendLine("IsSealed(密封)：" + t.IsSealed);
            sb.AppendLine("IsSealed(基类型)：" + t.IsPrimitive);
            sb.AppendLine("IsAbstract(抽象)：" + t.IsAbstract);
            sb.AppendLine("IsPublic(公开)：" + t.IsPublic);
            sb.AppendLine("IsNotPublic(不公开)：" + t.IsNotPublic);
            sb.AppendLine("IsVisible：" + t.IsVisible);
            sb.AppendLine("IsByRef(由引用传递)：" + t.IsByRef);
            Console.WriteLine(sb.ToString());

        }
        #endregion

        #region 类成员基本信息
        /// <summary>
        /// 类成员基本信息
        /// </summary>
        /// <param name="t"></param>
        public static void MemberExplore(Type t)
        {
            StringBuilder sb = new StringBuilder();
            //MemberInfo[] memberinfos = t.GetMembers();//默认没有打印出私有成员
            //↓↓↓↓↓↓↓获取所有得公有、私有、静态、实例成员--同时继承基类System.Object的方法如：GetType()和Equals()都被过滤掉了↓↓↓↓↓↓↓
            //MemberInfo[] memberinfos = t.GetMembers(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            //↓↓↓↓↓↓↓获取所有方法↓↓↓↓↓↓↓
            MemberInfo[] memberinfos = t.FindMembers(
                MemberTypes.Method, //说明查找得成员类型为Method
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.DeclaredOnly,
                Type.FilterName,    //返回一个MemberFilter类型的委托，说明按照方法名称进行过滤
                "*"                 //返回所有方法（如果使用"Get*",则返回所有以Get开头的方法）
                );
            sb.AppendLine("查看类型" + t.Name + "的成员信息：");
            foreach(MemberInfo mi in memberinfos)
            {
                sb.AppendLine("成员：" + mi.ToString().PadRight(40) + "类型："+mi.MemberType);
            }
            Console.WriteLine(sb.ToString());
        }
        #endregion

        #region 字段信息FieldInfo
        public static void FieldExplore(Type t)
        {
            StringBuilder sb = new StringBuilder();
            FieldInfo[] fields = t.GetFields();
            sb.AppendLine("查看类型" + t.Name + "的字段信息：\n");
            sb.AppendLine(string.Empty.PadLeft(50, '-'));
            foreach(FieldInfo fi in fields)
            {
                sb.AppendLine("名称：" + fi.Name);
                sb.AppendLine("类型：" + fi.FieldType);
                sb.AppendLine("特性：" + fi.Attributes);
            }
            Console.WriteLine(sb.ToString());
        }
        #endregion

        #region 属性信息
        public static void PropertyExplore(Type t)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("查看类型" + t.Name + "的属性信息：");
            sb.AppendLine(string.Empty.PadLeft(50, '-'));
            PropertyInfo[] properties = t.GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                sb.AppendLine("名称：" + pi.Name);
                sb.AppendLine("类型：" + pi.PropertyType);
                sb.AppendLine("可读：" + pi.CanRead);
                sb.AppendLine("可写：" + pi.CanWrite);
                sb.AppendLine("特性：" + pi.Attributes);
            }
            Console.WriteLine(sb.ToString());
        }
        #endregion

        #region 方法信息
        public static void MethodExplore(Type t)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("查看类型" + t.Name + "的方法信息");
            sb.AppendLine(string.Empty.PadLeft(50, '-'));
            MethodInfo[] methods = t.GetMethods();
            foreach (MethodInfo method in methods)
            {
                sb.AppendLine("名称：" + method.Name);
                sb.AppendLine("签名：" + method.ToString());
                sb.AppendLine("属性：" + method.Attributes);
                sb.AppendLine("返回类型：" + method.ReturnType);
                ParameterInfo[] parameterInfo = method.GetParameters();

            }
        }
        #endregion

        #region 构造函数
        public static void ConstructorExplore(Type t)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("查看类型" + t.Name + "的构造函数信息");
            sb.AppendLine(string.Empty.PadLeft(50, '-'));
            ConstructorInfo[] cis = t.GetConstructors();
            foreach(ConstructorInfo ci in cis)
            {
                sb.AppendLine("名称" + ci.Name);
            }
            Console.WriteLine(sb.ToString());
        }
        #endregion

        #region 事件
        public static void EventExplore(Type t)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("查看类型" + t.Name + "的构造事件信息");
            sb.AppendLine(string.Empty.PadLeft(50, '-'));
            EventInfo[] cis = t.GetEvents();
            foreach (EventInfo ci in cis)
            {
                sb.AppendLine("名称" + ci.Name);
            }
            Console.WriteLine(sb.ToString());
        }
        #endregion

        #region 通过反射获得自定义特性
        public static void CustomAttributeExplore(Type t)
        {
            object[] records = t.GetCustomAttributes(typeof(Attribute), false);
            foreach(RecordAttribute record in records)
            {
                Console.WriteLine("{0}", record);
                Console.WriteLine("类型{0}", record.RecordType);
                Console.WriteLine("作者{0}", record.Author);
                Console.WriteLine("日期{0}", record.Date.ToShortDateString());
                if (!string.IsNullOrEmpty(record.Memo))
                {
                    Console.WriteLine("备注：{0}", record.Memo);
                }
            }
        }
        #endregion

        #region 无参动态创建对象
        public static void CreateObject1()
        {
            Assembly currentAssem = Assembly.GetExecutingAssembly();
            object obj = currentAssem.CreateInstance("Calculator", false);
        }
        public static void CreateObject2()
        {
            ObjectHandle handler = Activator.CreateInstance(null, "Calculator");
            object obj = handler.Unwrap();
        }
        #endregion

        #region 有参动态创建对象
        public static void CreateObject3()
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            Object[] objs = new Object[2];
            objs[0]= 3;
            objs[1]= 5;
            object obj = currentAssembly.CreateInstance("Calcutor", true, BindingFlags.Default,null, objs, null, null);
        }
        #endregion

        #region 动态调用方法1
        public static void InvokeMethod1(Type t)
        {
            Calculator c = new Calculator(3, 5);
            int result = (int)t.InvokeMember("Add", BindingFlags.InvokeMethod, null, c, null);
            Console.WriteLine(String.Format("The result is {0}", result));
        }
        public static void InvokeStaticMethod1(Type t)
        {
            Object[] parameters = { 6, 9 };
            t.InvokeMember("Add", BindingFlags.InvokeMethod, null, t, parameters);
        }
        #endregion

        #region 动态调用方法2
        public static void InvokeMethod2(Type t)
        {
            Calculator c = new Calculator(3, 5);
            MethodInfo mi = t.GetMethod("Add", BindingFlags.Instance|BindingFlags.Public);
            mi.Invoke(c, null);
        }

        public static void InvokeStaticMethod2(Type t)
        {
            Calculator c = new Calculator();
            object[] parameters = { 5, 6 };
            MethodInfo mi = t.GetMethod("Add", BindingFlags.Static|BindingFlags.Public);
            mi.Invoke(null, parameters);
        }
        #endregion
    }
}
 