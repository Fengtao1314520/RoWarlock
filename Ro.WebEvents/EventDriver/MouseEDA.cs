using System;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Ro.Common.Args;
using Ro.Common.EnumType;
using Ro.Common.UserType.ActionType;
using Ro.WebEvents.ElementDriver;

namespace Ro.WebEvents.EventDriver
{
    public class MouseEDA
    {
        private readonly MouseAction _mouseAction;
        private readonly WebDriverWait _webDriverWait;

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
                        return false;
                    }
                    else
                    {
                        Actions action = new Actions(ComArgs.WebTestDriver);
                        action.MoveToElement(ele).Perform();

                        return true;
                    }
                }
                catch (Exception e)
                {
                    ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                    return false;
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

        #region MyRegion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mouseAction"></param>
        public MouseEDA(MouseAction mouseAction)
        {
            _mouseAction = mouseAction;
            //提取超时
            TimeSpan timeSpan = TimeSpan.FromSeconds(mouseAction.Timeout);
            _webDriverWait = new WebDriverWait(ComArgs.WebTestDriver, timeSpan);
        }

        #endregion
    }
}