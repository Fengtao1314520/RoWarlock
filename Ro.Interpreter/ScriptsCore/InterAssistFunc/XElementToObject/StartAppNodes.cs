using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Ro.Common.Args;
using Ro.Common.UserType.ScriptsLogicType;

namespace Ro.Interpreter.ScriptsCore.InterAssistFunc.XElementToObject
{
    /// <summary>
    /// StartApp节点处理
    /// </summary>
    public class StartAppNodes
    {
        #region 只读Get值

        public StartAppType StartApp_Info { get; }

        #endregion

        #region 构造函数

        /// <summary>
        /// StartApp节点处理
        /// </summary>
        /// <param name="startXElement"></param>
        public StartAppNodes(XElement startXElement)
        {
            //1.转为对象
            StartAppType startAppType = new StartAppType
            {
                AppInfo = new AppInfo()
            };

            XElement appinfoEle = startXElement.Element(XName.Get("AppInfo", ComArgs.RosStr));

            AppInfo appInfo = new AppInfo
            {
                ExecuePath = appinfoEle?.Element(XName.Get("ExecuePath", ComArgs.RosStr))?.Value,
                BaseWindowsBits = appinfoEle?.Element(XName.Get("BaseWindowsBits", ComArgs.RosStr))?.Attribute(XName.Get("Bits", ComArgs.RosStr))?.Value != "32Bits",
                Version = appinfoEle?.Element(XName.Get("Version", ComArgs.RosStr))?.Value,
                Parameters = new List<string>(),
                AppName = appinfoEle?.Attribute(XName.Get("AppName", ComArgs.RosStr))?.Value
            };
            //需要验证是否有追加的参数
            XElement temps = appinfoEle?.Element(XName.Get("Parameters", ComArgs.RosStr));

            if (temps != null && !temps.Elements().Any())
            {
                foreach (XElement variable in temps.Elements(XName.Get("Parameter", ComArgs.RosStr)))
                {
                    appInfo.Parameters.Add(variable.Value);
                }
            }

            //2.根据实际情况进行解压
            startAppType.AppInfo = appInfo;
            StartApp_Info = startAppType;
        }

        #endregion
    }
}
