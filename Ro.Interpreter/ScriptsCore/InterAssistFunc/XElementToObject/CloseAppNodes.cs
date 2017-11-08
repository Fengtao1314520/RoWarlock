using System;
using System.Xml.Linq;
using Ro.Common.Args;
using Ro.Common.UserType.ScriptsLogicType;

namespace Ro.Interpreter.ScriptsCore.InterAssistFunc.XElementToObject
{
    /// <summary>
    /// CloseApp节点处理
    /// </summary>
    public class CloseAppNodes
    {
        #region 只读Get值

        public CloseAppType CloseApp_Info { get; }
        

        #endregion



        #region 构造函数

        /// <summary>
        /// CloseApp节点处理
        /// xml转为对象
        /// </summary>
        /// <param name="closeXElement"></param>
        public CloseAppNodes(XElement closeXElement)
        {
            //1.转为对象
            CloseAppType closeAppType = new CloseAppType();
            closeAppType.Keep = Convert.ToBoolean(closeXElement.Attribute(XName.Get("Keep", ComArgs.RosStr))?.Value);
            //2.进行close的相应处理
            CloseApp_Info = closeAppType;
        }

        #endregion
    }
}
