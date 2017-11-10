using System;
using System.Linq;
using System.Xml.Linq;
using Ro.Common.Args;
using Ro.Common.EnumType;
using Ro.Common.UserType.GuiType;
using Ro.Interpreter.ScriptsCore;


/*
 * 脚本解释器入口
 * 解析XML直接使用LINQ的方法，原方法总要考虑命名空间
 * 1.脚本解释器只接收tcs/ros文件
 */
namespace Ro.Interpreter
{
    /// <summary>
    /// 脚本解释器入口
    /// 创建构造函数
    /// </summary>
    public class MainEntrance
    {
        #region 只读值

        /// <summary>
        /// 最终结果，对应单个ros文件的结果
        /// </summary>
        public bool FinalResult { get; }

        /// <summary>
        /// 总计测试步骤数
        /// </summary>
        public int TotalSteps { get; }

        /// <summary>
        /// 使用的Tci的文件数量
        /// </summary>
        public int UseTciNums { get; }

        #endregion

        #region 构造函数

        /// <summary>
        /// 脚本解释器入口
        /// 初始化整个测试脚本，并且能反馈部分有效信息
        /// 构造函数
        /// </summary>
        /// <param name="rospath">单个ros文件路径</param>
        public MainEntrance(string rospath)
        {
            //前置:初始化整个测试脚本,初始化可能应用的方法
            ScriptsType scriptsType= new ScriptsType();

            try
            {
                //1.解析tcs文件

                //读取tcs文件
                XDocument tcsDocument = XDocument.Load(rospath,LoadOptions.SetLineInfo);
               
                //提取根节点
                XElement rootElement = tcsDocument.Element(XName.Get("TestDefinition", ComArgs.RosStr));

                //提取各个分类节点
                if (rootElement != null)
                {
                    scriptsType.AnnXEle = rootElement.Element(XName.Get("Annotation", ComArgs.RosStr));
                    scriptsType.ConfXEle = rootElement.Element(XName.Get("TestConfig", ComArgs.RosStr));
                    scriptsType.StartXEle = rootElement.Element(XName.Get("StartApp", ComArgs.RosStr));
                    scriptsType.TestsXEle = rootElement.Element(XName.Get("Tests", ComArgs.RosStr));
                    scriptsType.CloseXEle = rootElement.Element(XName.Get("CloseApp", ComArgs.RosStr));
                    scriptsType.LogFuncXEle = rootElement.Element(XName.Get("LogFunction", ComArgs.RosStr));
                }


                TotalSteps = scriptsType.TestsXEle.Elements().Count(); //提取步骤数量 
                UseTciNums = scriptsType.ConfXEle.Element(XName.Get("Imports", ComArgs.RosStr)).Elements().Count(); //提取使用的roi文件数量

                //2.执行步骤
                ScriptEntrance scriptsEntrance = new ScriptEntrance(scriptsType);
                //3.返回结果
                FinalResult = scriptsEntrance.Result; //最终结果
            }
            catch (Exception e)
            {
                ComArgs.RoLog.WriteLog(LogStatus.LExpt, "脚本解析器入口发生异常",e.ToString());
            }
        }

        #endregion

    }


}
