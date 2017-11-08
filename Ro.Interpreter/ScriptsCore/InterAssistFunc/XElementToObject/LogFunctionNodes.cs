using System;
using System.Xml.Linq;
using Ro.Common.Args;
using Ro.Common.UserType.ScriptsLogicType;

namespace Ro.Interpreter.ScriptsCore.InterAssistFunc.XElementToObject
{
    /// <summary>
    /// LogFunction节点处理
    /// </summary>
    public class LogFunctionNodes
    {
        #region 只读Get值

        public LogFunctionType LogFunction_Info { get; }

        #endregion


        #region 构造函数
        /// <summary>
        /// logfunction节点处理
        /// </summary>
        /// <param name="logXElement"></param>
        public LogFunctionNodes(XElement logXElement)
        {
            //1.转为对象
            LogFunctionType logFunctionType = new LogFunctionType();

            XElement logpathele = logXElement.Element(XName.Get("LogFilePath", ComArgs.RosStr));
            if (logpathele != null && string.IsNullOrEmpty(logpathele.Value))
            {
                logFunctionType.LogFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            else
            {
                if (logpathele != null) logFunctionType.LogFilePath = logpathele.Value;
            }


            
            //2.根据要求进行log的操作
            LogFunction_Info = logFunctionType;
        }
        #endregion


    }
}
