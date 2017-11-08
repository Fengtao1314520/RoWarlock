using System;
using System.Reflection;
using OpenQA.Selenium.Support.UI;
using Ro.Assist.AssistBot;
using Ro.Common.Args;
using Ro.Common.EnumType;
using Ro.Common.UserType.ActionType;

namespace Ro.WebEvents.EventDriver
{
    /// <summary>
    /// Alert 事件驱动框架
    /// </summary>
    public class AlertEDA
    {
        private readonly WebDriverWait _webDriverWait;
        private readonly AlertAction _alertAction;


        #region 只读Get方法

        public bool Accept
        {
            get
            {
                try
                {
                    _webDriverWait.Until(ExpectedConditions.AlertIsPresent()).Accept();

                    return true;
                }
                catch (Exception e)
                {
                    ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                    return false;
                }
            }
        }


        public bool Dismiss
        {
            get
            {
                try
                {
                    _webDriverWait.Until(ExpectedConditions.AlertIsPresent()).Dismiss();
                    return true;
                }
                catch (Exception e)
                {
                    ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                    return false;
                }
            }
        }


        public bool SendKeys
        {
            get
            {
                try
                {
                    ArgsIntoValue argsIntoValue = new ArgsIntoValue();
                    string value = argsIntoValue.BackNormalString(_alertAction.SendKeysValue);
                    _webDriverWait.Until(ExpectedConditions.AlertIsPresent()).SendKeys(value);

                    return true;
                }
                catch (Exception e)
                {
                    ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                    return false;
                }
            }
        }

        #endregion


        /// <summary>
        /// Alert 事件驱动框架
        /// 构造函数
        /// 实体使用方法
        /// </summary>
        /// <param name="alertAction">alert操作</param>
        public AlertEDA(AlertAction alertAction)
        {
            _alertAction = alertAction;
            //提取超时
            TimeSpan timeSpan = TimeSpan.FromSeconds(_alertAction.Timeout);
            _webDriverWait = new WebDriverWait(ComArgs.WebTestDriver, timeSpan);
        }
    }
}