using System;
using System.Collections.Generic;
using System.Reflection;
using Ro.Common.Args;
using Ro.Common.EnumType;
using Ro.Common.UserType.ActionType;
using Ro.Common.UserType.ScriptsLogicType;

namespace Ro.WebEvents.EventDriver
{
    /// <summary>
    /// 宏操作的事件驱动
    /// </summary>
    public class MacroReferenceEDA
    {
        private readonly MacroAction _macroAction;

        #region 只读Get方法

        /// <summary>
        /// Macro本质上依然是一种teststeps的集合，因此依然不断解析对应步骤
        /// </summary>
        public Queue<TestStep> Macro
        {
            get
            {
                try
                {
                    //1首先提取_macroaction的id


                    Queue<TestStep> value;
                    bool hasValue = ComArgs.MacroDic.TryGetValue(_macroAction.MacroId, out value);
                    if (hasValue)
                    {
                        Queue<TestStep> xmlfile = value;
                       
                        return xmlfile;
                    }
                    ComArgs.RoLog.WriteLog(LogStatus.LFail, $"字典ComArgs.MacroDic不包含{_macroAction.MacroId}");
                    return null;
                }
                catch (Exception e)
                {
                    ComArgs.RoLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                    return null;
                }
            }
        }

        #endregion

        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        /// <param name="macroAction"></param>
        public MacroReferenceEDA(MacroAction macroAction)
        {
            _macroAction = macroAction;
        }

        #endregion
    }
}