using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Ro.Common.Args;
using Ro.Common.EnumType;
using Ro.Common.UserType.ActionType;
using Ro.WebEvents.ElementDriver;

namespace Ro.WebEvents.EventDriver
{
    public class UpdateEDA
    {
        private readonly UpdateAction _updateAction;
        private readonly WebDriverWait _webDriverWait;

        /// <summary>
        /// Windows专用
        /// </summary>
        public bool UpdateSelect
        {
            get
            {
                try
                {
                    //提取元素
                    IWebElement ele = new FindWebElement(_updateAction.ElementId, _updateAction.Timeout).WebElement;

                    //获取桌面路径
                    if (ele == null)
                    {
                        return false;
                    }
                    else
                    {
                        if (!File.Exists(_updateAction.FileValue))
                        {
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

                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                    return false;
                }
            }
        }

        public UpdateEDA(UpdateAction updateAction)
        {
            _updateAction = updateAction;
            //提取超时
            TimeSpan timeSpan = TimeSpan.FromSeconds(_updateAction.Timeout);
            _webDriverWait = new WebDriverWait(Common.Args.ComArgs.WebTestDriver, timeSpan);
        }
    }
}