using System;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Ro.Assist.AssistBot;
using Ro.Common.Args;
using Ro.Common.UserType.ActionType;
using Ro.Common.UserType.ScriptsLogicType;

namespace Ro.WebEvents.EventDriver
{
    public class ScrollEDA
    {
        private readonly ScrollAction _scrollAction;
        private readonly GuiViewEvent _guiViewEvent = new GuiViewEvent();

        /// <summary>
        /// 向上翻滚
        /// </summary>
        public bool Up
        {
            get
            {
                try
                {
                    //向上滚动
                    ComArgs.WebTestDriver.ExecuteJavaScript<IJavaScriptExecutor>("window.scrollTo(0,0)");
                    ComArgs.SigTestStep.ResultStr = "成功";
                    ComArgs.SigTestStep.Result = true;
                    ComArgs.SigTestStep.ExtraInfo = "N/A";
                    return true;
                }
                catch (WebDriverTimeoutException)
                {
                    ComArgs.SigTestStep.ResultStr = "失败";
                    ComArgs.SigTestStep.Result = false;
                    ComArgs.SigTestStep.ExtraInfo = "RoWarlock操作超时";
                    return false;
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
                    ComArgs.SigTestStep.StepName = _scrollAction.ActionType;
                    ComArgs.SigTestStep.ControlId = "未使用";
                    _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
                }
            }
        }

        /// <summary>
        /// 向下翻滚
        /// </summary>
        public bool Down
        {
            get
            {
                try
                {
                    ComArgs.WebTestDriver.ExecuteJavaScript<IJavaScriptExecutor>("window.scrollTo(0,document.body.scrollHeight");
                    ComArgs.SigTestStep.ResultStr = "成功";
                    ComArgs.SigTestStep.Result = true;
                    ComArgs.SigTestStep.ExtraInfo = "N/A";
                    return true;
                }
                catch (WebDriverTimeoutException)
                {
                    ComArgs.SigTestStep.ResultStr = "失败";
                    ComArgs.SigTestStep.Result = false;
                    ComArgs.SigTestStep.ExtraInfo = "RoWarlock操作超时";
                    return false;
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
                    ComArgs.SigTestStep.StepName = _scrollAction.ActionType;
                    ComArgs.SigTestStep.ControlId = "未使用";
                    _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
                }
            }
        }


        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scrollTestStep"></param>
        public ScrollEDA(TestStep scrollTestStep)
        {
            _scrollAction = scrollTestStep.WebAction.Action as ScrollAction;
            ComArgs.SigTestStep = scrollTestStep;
        }

        #endregion
    }
}
