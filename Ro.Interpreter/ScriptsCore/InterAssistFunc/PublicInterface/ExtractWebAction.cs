using System;
using System.Xml.Linq;
using Ro.Common.Args;
using Ro.Common.EnumType;
using Ro.Common.UserType.ActionType;

namespace Ro.Interpreter.ScriptsCore.InterAssistFunc.PublicInterface
{
    /// <summary>
    /// 提取WebAction
    /// </summary>
    public class ExtractWebAction
    {
        public WebAction ExtractWeb { get; }

        /// <summary>
        /// 构造函数
        /// 提取WebAction
        /// <param name="sigXElement">一个单独的节点</param>
        /// </summary>
        public ExtractWebAction(XElement sigXElement)
        {
            try
            {
                WebAction backAction = new WebAction
                {
                    ActionXElement = sigXElement
                };
                string name = sigXElement.Name.LocalName;


                if (name.Contains("Launch.Browser"))
                {
                    backAction.Action = new LaunchAction(sigXElement);
                }
                if (name.Contains("Alert"))
                {
                    backAction.Action = new AlertAction(sigXElement);
                }
                if (name.Contains("Browser") && !name.Contains("Launch"))
                {
                    backAction.Action = new BrowserAction(sigXElement);
                }
                if (name.Contains("Element"))
                {
                    backAction.Action = new ElementAction(sigXElement);
                }
                if (name.Contains("Sleep"))
                {
                    backAction.Action = new SleepAction(sigXElement);
                }
                if (name.Contains("Update"))
                {
                    backAction.Action = new UpdateAction(sigXElement);
                }
                if (name.Contains("WaitUntil"))
                {
                    backAction.Action = new WaitUntilAction(sigXElement);
                }
                if (name.Contains("Macro"))
                {
                    backAction.Action = new MacroAction(sigXElement);
                }
                if (name.Contains("Mouse"))
                {
                    backAction.Action = new MouseAction(sigXElement);
                }
                if (name.Contains("Scroll"))
                {
                    backAction.Action = new ScrollAction(sigXElement);
                }
                ExtractWeb = backAction;
            }
            catch (Exception e)
            {
                ComArgs.RoLog.WriteLog(LogStatus.LExpt, "ExtractWebAction导出操作实体类发生异常...", e.ToString());
            }
            
        }
    }
}
