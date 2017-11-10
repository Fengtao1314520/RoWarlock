using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Ro.Assist.AssistBot;
using Ro.Common.Args;
using Ro.Common.UserType.ActionType;
using Ro.Common.UserType.ScriptsLogicType;
using Ro.WebEvents.ElementDriver;

namespace Ro.WebEvents.EventDriver
{
    public class UpdateEDA
    {
        private readonly UpdateAction _updateAction;
        private readonly WebDriverWait _webDriverWait;
        private readonly GuiViewEvent _guiViewEvent = new GuiViewEvent();

        /// <summary>
        /// Windows专用
        /// </summary>
        public bool UpdateSelect
        {
            get
            {
                try
                {
                    ArgsIntoValue asArgsIntoValue = new ArgsIntoValue(); //需要转话为真实值
                    string value = asArgsIntoValue.BackNormalString(_updateAction.FileValue);
                    //提取元素
                    IWebElement ele = new FindWebElement(_updateAction.ElementId, _updateAction.Timeout).WebElement;

                    //获取桌面路径
                    if (ele == null)
                    {

                        ComArgs.SigTestStep.ResultStr = "失败";
                        ComArgs.SigTestStep.Result = false;
                        ComArgs.SigTestStep.ExtraInfo = $"查找元素:{_updateAction.ElementId}不存在,请仔细检查对应控件";
                        return false;
                    }
                    else
                    {
                        if (!File.Exists(value))
                        {
                            ComArgs.SigTestStep.ResultStr = "失败";
                            ComArgs.SigTestStep.Result = false;
                            ComArgs.SigTestStep.ExtraInfo = $"文件{value}不存在，请仔细检查对应文件";
                            return false;
                        }
                        else
                        {
                            ele.Click(); //点击控件

                            Thread.Sleep(1000);
                            //发送文件路径
                            SendKeys.SendWait(@"^a");
                            Thread.Sleep(500);
                            SendKeys.SendWait(@"{BACKSPACE}");
                            Thread.Sleep(500);
                            SendKeys.SendWait(_updateAction.FileValue);
                            Thread.Sleep(500);
                            SendKeys.SendWait(@"%o");
                            Thread.Sleep(500);

                            ComArgs.SigTestStep.ResultStr = "成功";
                            ComArgs.SigTestStep.Result = true;
                            ComArgs.SigTestStep.ExtraInfo = $"等待上传的文件:{value}";
                            return true;
                        }
                    }
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
                    ComArgs.SigTestStep.StepName = _updateAction.ActionType;
                    ComArgs.SigTestStep.ControlId = _updateAction.ElementId;
                    _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
                }
            }
        }

        public UpdateEDA(TestStep updateTestStep)
        {
            _updateAction = updateTestStep.WebAction.Action as UpdateAction;
            ComArgs.SigTestStep = updateTestStep;
            //提取超时
            if (_updateAction != null)
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds(_updateAction.Timeout);
                _webDriverWait = new WebDriverWait(ComArgs.WebTestDriver, timeSpan);
            }
        }
    }
}