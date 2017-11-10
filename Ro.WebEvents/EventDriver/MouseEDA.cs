using System;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Ro.Assist.AssistBot;
using Ro.Common.Args;
using Ro.Common.UserType.ActionType;
using Ro.Common.UserType.ScriptsLogicType;
using Ro.WebEvents.ElementDriver;

namespace Ro.WebEvents.EventDriver
{
    public class MouseEDA
    {
        private readonly MouseAction _mouseAction;
        private readonly WebDriverWait _webDriverWait;
        private readonly GuiViewEvent _guiViewEvent = new GuiViewEvent();
        #region 只读Get方法

        public bool Move
        {
            get
            {
                try
                {
                    IWebElement ele = new FindWebElement(_mouseAction.ElementId, _mouseAction.Timeout).WebElement;
                    //判断元素是否存在
                    if (ele == null)
                    {

                        ComArgs.SigTestStep.ResultStr = "失败";
                        ComArgs.SigTestStep.Result = false;
                        ComArgs.SigTestStep.ExtraInfo = $"查找元素:{_mouseAction.ElementId}不存在,请仔细检查对应控件";
                        return false;
                    }
                    else
                    {

                        Actions action = new Actions(ComArgs.WebTestDriver);
                        action.MoveToElement(ele).Perform();

                        ComArgs.SigTestStep.ResultStr = "成功";
                        ComArgs.SigTestStep.Result = true;
                        ComArgs.SigTestStep.ExtraInfo = "N/A";
                        return true;
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
                    ComArgs.SigTestStep.StepName = _mouseAction.ActionType;
                    ComArgs.SigTestStep.ControlId = _mouseAction.ElementId;
                    _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
                }

            }
        }

        public bool Click
        {
            get
            {

                try
                {
                    IWebElement ele = new FindWebElement(_mouseAction.ElementId, _mouseAction.Timeout).WebElement;
                    //判断元素是否存在
                    if (ele == null)
                    {
                        ComArgs.SigTestStep.ResultStr = "失败";
                        ComArgs.SigTestStep.Result = false;
                        ComArgs.SigTestStep.ExtraInfo = $"查找元素:{_mouseAction.ElementId}不存在,请仔细检查对应控件";
                        return false;
                    }
                    Actions action = new Actions(ComArgs.WebTestDriver);
                    switch (_mouseAction.MouseType)
                    {
                        case "ClickLeft":
                            action.Click(ele).Perform();
                            break;

                        case "ClickRight":
                            action.ContextClick(ele).Perform();
                            break;

                        case "DoubleLeft":
                            action.DoubleClick(ele).Perform();
                            break;
                        //右键双击其实挺无聊的
                        case "DoubleRight":
                            action.ContextClick(ele).Perform();
                            action.ContextClick(ele).Perform();
                            break;
                    }
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
                    ComArgs.SigTestStep.StepName = _mouseAction.ActionType;
                    ComArgs.SigTestStep.ControlId = _mouseAction.ElementId;
                    _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
                }

            }
        }

        #endregion

        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mouseTestStep"></param>
        public MouseEDA(TestStep mouseTestStep)
        {
            _mouseAction = mouseTestStep.WebAction.Action as MouseAction;
            ComArgs.SigTestStep = mouseTestStep;
            //提取超时
            if (_mouseAction != null)
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds(_mouseAction.Timeout);
                _webDriverWait = new WebDriverWait(ComArgs.WebTestDriver, timeSpan);
            }
        }

        #endregion
    }
}