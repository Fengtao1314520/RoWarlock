using System;
using System.Reflection;
using System.Threading;
using OpenQA.Selenium;
using Ro.Assist.AssistBot;
using Ro.Common.Args;
using Ro.Common.UserType.ActionType;
using Ro.Common.UserType.ScriptsLogicType;

namespace Ro.WebEvents.EventDriver
{
    public class SleepEDA
    {
        private readonly SleepAction _sleepAction;
        private readonly GuiViewEvent _guiViewEvent = new GuiViewEvent();
        public bool Sleep
        {
            get
            {
                try
                {
                    Thread.Sleep(_sleepAction.Seconds * 1000);
                    ComArgs.SigTestStep.ResultStr = "成功";
                    ComArgs.SigTestStep.Result = true;
                    ComArgs.SigTestStep.ExtraInfo = $"等待时间:{_sleepAction.Seconds} 秒, 等待信息:{_sleepAction.Message}";
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
                    ComArgs.SigTestStep.StepName = _sleepAction.ActionType;
                    ComArgs.SigTestStep.ControlId = "未使用";
                    _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
                }
            }
        }

        public SleepEDA(TestStep sleepTestStep)
        {
            _sleepAction = sleepTestStep.WebAction.Action as SleepAction;
            ComArgs.SigTestStep = sleepTestStep;
        }
    }
}