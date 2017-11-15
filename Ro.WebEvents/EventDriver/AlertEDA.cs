using System;
using System.Reflection;
using OpenQA.Selenium.Support.UI;
using Ro.Assist.AssistBot;
using Ro.Common.Args;
using Ro.Common.UserType.ActionType;
using Ro.Common.UserType.ScriptsLogicType;

namespace Ro.WebEvents.EventDriver
{
    /// <summary>
    /// Alert 事件驱动框架
    /// </summary>
    public class AlertEDA
    {
        private readonly WebDriverWait _webDriverWait;
        private readonly AlertAction _alertAction;
        private readonly GuiViewEvent _guiViewEvent = new GuiViewEvent();



        #region 只读Get方法

        public bool Accept
        {
            get
            {
                
                try
                {
                    _webDriverWait.Until(ExpectedConditions.AlertIsPresent()).Accept();

                    ComArgs.SigTestStep.ResultStr = "成功";
                    ComArgs.SigTestStep.Result = true;
                    ComArgs.SigTestStep.ExtraInfo = "N/A";
                    return true;
                }
                catch (Exception e)
                {
                    ComArgs.SigTestStep.ResultStr = "异常";
                    ComArgs.SigTestStep.Result = false;
                    ComArgs.SigTestStep.ExtraInfo = $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常";
                    ComArgs.SigTestStep.Message = e.Message;
                    ComArgs.SigTestStep.StackTrace = e.StackTrace;
                    ComArgs.SigTestStep.FullName = e.TargetSite.DeclaringType?.FullName;
                    return false;
                }
                finally
                {
                    ComArgs.SigTestStep.StepName = _alertAction.ActionType;
                    ComArgs.SigTestStep.ControlId = "未使用";
                    _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);

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

                    ComArgs.SigTestStep.ResultStr = "成功";
                    ComArgs.SigTestStep.Result = true;
                    ComArgs.SigTestStep.ExtraInfo = "N/A";
                    return true;
                }
                catch (Exception e)
                {
                    ComArgs.SigTestStep.ResultStr = "异常";
                    ComArgs.SigTestStep.Result = false;
                    ComArgs.SigTestStep.ExtraInfo = $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常";
                    ComArgs.SigTestStep.Message = e.Message;
                    ComArgs.SigTestStep.StackTrace = e.StackTrace;
                    ComArgs.SigTestStep.FullName = e.TargetSite.DeclaringType?.FullName;
                    return false;
                }
                finally
                {
                    ComArgs.SigTestStep.StepName = _alertAction.ActionType;
                    ComArgs.SigTestStep.ControlId = "未使用";
                    _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
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

                    ComArgs.SigTestStep.ResultStr = "成功";
                    ComArgs.SigTestStep.Result = true;
                    ComArgs.SigTestStep.ExtraInfo = "N/A";

                    return true;
                }
                catch (Exception e)
                {
                    ComArgs.SigTestStep.ResultStr = "异常";
                    ComArgs.SigTestStep.Result = false;
                    ComArgs.SigTestStep.ExtraInfo = $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常";
                    ComArgs.SigTestStep.Message = e.Message;
                    ComArgs.SigTestStep.StackTrace = e.StackTrace;
                    ComArgs.SigTestStep.FullName = e.TargetSite.DeclaringType?.FullName;
                    return false;
                }
                finally
                {
                    ComArgs.SigTestStep.StepName = _alertAction.ActionType;
                    ComArgs.SigTestStep.ControlId = "未使用";
                    _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
                }
            }
        }

        #endregion


        /// <summary>
        /// Alert 事件驱动框架
        /// 构造函数
        /// 实体使用方法
        /// </summary>
        /// <param name="alertTestStep">alert步骤所有信息</param>
        public AlertEDA(TestStep alertTestStep)
        {
            _alertAction = alertTestStep.WebAction.Action as AlertAction;
            ComArgs.SigTestStep = alertTestStep;
            if (_alertAction != null)
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds(_alertAction.Timeout); //提取超时
                _webDriverWait = new WebDriverWait(ComArgs.WebTestDriver, timeSpan);
            }
        }
    }
}