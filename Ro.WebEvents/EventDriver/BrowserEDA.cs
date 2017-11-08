using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using Ro.Assist.AssistBot;
using Ro.Common.Args;
using Ro.Common.EnumType;
using Ro.Common.UserType.ActionType;
using Ro.WebEvents.ElementDriver;

namespace Ro.WebEvents.EventDriver
{
    /// <summary>
    /// Browser 事件驱动框架
    /// </summary>
    public class BrowserEDA
    {
        private readonly WebDriverWait _webDriverWait;
        private readonly BrowserAction _browserAction;


        #region 只读Get方法

        public bool Back
        {
            get
            {
                try
                {
                    //当前句柄
                    string firsttab = ComArgs.WebTestDriver.CurrentWindowHandle;
                    //后退
                    ComArgs.WebTestDriver.Navigate().Back();
                    //再次获取当前句柄
                    string secondtab = ComArgs.WebTestDriver.CurrentWindowHandle;
                    //如果回退与前一个页面句柄相同，或直接回退至new tabs 
                    if (secondtab == firsttab && ComArgs.WebTestDriver.Title == "New Tab")
                    {
                        ComArgs.WebLog.WriteLog(LogStatus.LFail, "没有回退成功，或直接回退至新的tab标签页");
                        return false;
                    }
                    else
                    {
                        ComArgs.WebLog.WriteLog(LogStatus.LPass, "浏览器回退成功");
                        return true;
                    }
                }
                catch (Exception e)
                {
                    ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{System.Reflection.MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                    return false;
                }
            }
        }


        public bool Forward
        {
            get
            {
                try
                {
                    //当前句柄
                    string tab1 = ComArgs.WebTestDriver.CurrentWindowHandle;
                    //前进
                    ComArgs.WebTestDriver.Navigate().Forward();
                    //再次获取当前句柄
                    string tab2 = ComArgs.WebTestDriver.CurrentWindowHandle;

                    if (tab2 == tab1 && ComArgs.WebTestDriver.Title == "New Tab")
                    {
                        ComArgs.WebLog.WriteLog(LogStatus.LFail, "浏览器前进未成功或直接进入了新标签页");
                        return false;
                    }
                    else
                    {
                        ComArgs.WebLog.WriteLog(LogStatus.LPass, "浏览器前进成功");
                        return true;
                    }
                }
                catch (Exception e)
                {
                    ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{System.Reflection.MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                    return false;
                }
            }
        }


        public bool Stop
        {
            get
            {
                try
                {
                    //更改为js
                    IJavaScriptExecutor jsExecutor = ComArgs.WebTestDriver as IJavaScriptExecutor;
                    jsExecutor?.ExecuteScript("window.stop();");
                    //验证状态
                    string com = (string) jsExecutor?.ExecuteScript("return document.readyState");
                    if (com != "complete")
                    {
                        ComArgs.WebLog.WriteLog(LogStatus.LFail, "浏览器无法停止刷新");
                        return false;
                    }
                    else
                    {
                        ComArgs.WebLog.WriteLog(LogStatus.LPass, "浏览器停止刷新成功");
                        return true;
                    }
                }
                catch (Exception e)
                {
                    ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{System.Reflection.MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                    return false;
                }
            }
        }


        /// <summary>
        /// 关闭浏览器
        /// 慎用
        /// </summary>
        public bool Close
        {
            get
            {
                try
                {
                    //关闭浏览器
                    ComArgs.WebTestDriver.Quit();
                    if (!ComArgs.WebTestDriver.ToString().Contains("null"))
                    {
                        ComArgs.WebLog.WriteLog(LogStatus.LFail, "浏览器无法关闭");
                        return false;
                    }
                    else
                    {
                        ComArgs.WebLog.WriteLog(LogStatus.LPass, "浏览器已关闭");
                        return true;
                    }
                }
                catch (Exception e)
                {
                    ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{System.Reflection.MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                    return false;
                }
            }
        }


        /// <summary>
        /// 关闭Tab窗口
        /// </summary>
        public bool CloseTab
        {
            get
            {
                try
                {
                    //关闭页面
                    //所有的窗口句柄
                    IList<string> handles = ComArgs.WebTestDriver.WindowHandles;
                    string firsthandle = handles[0];
                    //当前句柄
                    string tab1 = ComArgs.WebTestDriver.CurrentWindowHandle;

                    //执行关闭
                    ComArgs.WebTestDriver.Close();
                    ComArgs.WebTestDriver.SwitchTo().Window(firsthandle);

                    string tab2 = ComArgs.WebTestDriver.CurrentWindowHandle;
                    //验证
                    if (tab1 == tab2 && tab2 == null && ComArgs.WebTestDriver.Title == "New Tab")
                    {
                        ComArgs.WebLog.WriteLog(LogStatus.LFail, "浏览器无法关闭当前Tab,或当前Tab是唯一活动Tab且造成测试主体已不存在");
                        return false;
                    }
                    else
                    {
                        ComArgs.WebLog.WriteLog(LogStatus.LPass, "浏览器已关闭当前Tab");
                        return true;
                    }
                }
                catch (Exception e)
                {
                    ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{System.Reflection.MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                    return false;
                }
            }
        }


        public bool ExecuteScript
        {
            get
            {
                try
                {
                    //获取js代码
                    IJavaScriptExecutor jsExecutor = ComArgs.WebTestDriver as IJavaScriptExecutor;
                    jsExecutor?.ExecuteScript(_browserAction.JavaScript);
                    return true;
                }
                catch (Exception e)
                {
                    ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{System.Reflection.MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                    return false;
                }
            }
        }


        public bool GoToUrl
        {
            get
            {
                try
                {
                    //设置超时
                    ComArgs.WebTestDriver.Manage().Timeouts().PageLoad = new TimeSpan(_browserAction.Timeout);
                    //执行载入
                    ArgsIntoValue argsIntoValue = new ArgsIntoValue();
                    string value = argsIntoValue.BackNormalString(_browserAction.Url);
                    ComArgs.WebTestDriver.Navigate().GoToUrl(value);
                    //当前句柄
                    string tab1 = ComArgs.WebTestDriver.CurrentWindowHandle;
                    //验证
                    if (tab1 == null && ComArgs.WebTestDriver.Title == "New Tab")
                    {
                        ComArgs.WebLog.WriteLog(LogStatus.LFail, "浏览器没有进入对应网址");
                        return false;
                    }
                    else
                    {
                        ComArgs.WebLog.WriteLog(LogStatus.LPass, "浏览器进入对应网址");
                        return true;
                    }
                }
                catch (Exception e)
                {
                    ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{System.Reflection.MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                    return false;
                }
            }
        }


        public bool Refresh
        {
            get
            {
                try
                {
                    //更改为js
                    IJavaScriptExecutor jsExecutor = ComArgs.WebTestDriver as IJavaScriptExecutor;
                    //设置超时
                    ComArgs.WebTestDriver.Manage().Timeouts().PageLoad = new TimeSpan(_browserAction.Timeout);
                    //执行载入
                    ComArgs.WebTestDriver.Navigate().Refresh();

                    if (_browserAction.AutoStopLoad)
                    {
                        Thread.Sleep(_browserAction.Timeout * 100);

                        jsExecutor?.ExecuteScript("window.stop();");
                    }
                    //验证状态
                    string com = (string) jsExecutor?.ExecuteScript("return document.readyState");
                    if (com != "complete")
                    {
                        ComArgs.WebLog.WriteLog(LogStatus.LFail, "浏览器无法停止刷新");
                        return false;
                    }
                    else
                    {
                        ComArgs.WebLog.WriteLog(LogStatus.LPass, "浏览器停止刷新成功");
                        return true;
                    }
                }
                catch (Exception e)
                {
                    ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{System.Reflection.MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                    return false;
                }
            }
        }


        public bool SwitchFrame
        {
            get
            {
                try
                {
                    FindWebElement findele = new FindWebElement(_browserAction.ElementId, _browserAction.Timeout);
                    if (_browserAction.SwitchToNew == false)
                    {
                        //更改测试对象
                        ComArgs.WebTestDriver = ComArgs.WebTestDriver.SwitchTo().DefaultContent();
                    }
                    else
                    {
                        //更改测试对象
                        ComArgs.WebTestDriver = ComArgs.WebTestDriver.SwitchTo().Frame(findele.WebElement);
                    }

                    return true;
                }
                catch (Exception e)
                {
                    ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{System.Reflection.MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                    return false;
                }
            }
        }


        public bool SwitchToTab
        {
            get
            {
                try
                {
                    //所有的窗口句柄
                    IList<string> handles = ComArgs.WebTestDriver.WindowHandles;


                    foreach (string sigHandle in handles)
                    {
                        ComArgs.WebTestDriver.SwitchTo().Window(sigHandle);
                        if (ComArgs.WebTestDriver.Title.Contains(_browserAction.TabName))
                        {
                            break;
                        }
                    }
                    return true;
                }
                catch (Exception e)
                {
                    ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{System.Reflection.MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                    return false;
                }
            }
        }


        public bool TakeSnapshot
        {
            get
            {
                try
                {
                    //获取路径和名称
                    string imagepath = _browserAction.ImageFile; //后期修改
                    //浏览器截图
                    ArgsIntoValue argsIntoValue = new ArgsIntoValue();
                    string value = argsIntoValue.BackNormalString(imagepath);

                    string temp = "c:/temp/Ro_Auto_Logs/image";
                    if (!Directory.Exists(temp))
                    {
                        Directory.CreateDirectory(temp);
                    }
                    ComArgs.WebTestDriver.TakeScreenshot().SaveAsFile($"{temp}/{value}", ScreenshotImageFormat.Jpeg);
                    return true;
                }
                catch (Exception e)
                {
                    ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{System.Reflection.MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                    return false;
                }
            }
        }

        #endregion


        #region 构造函数

        /// <summary>
        /// Browser 事件驱动框架
        /// 构造函数
        /// 实体使用方法
        /// </summary>
        /// <param name="browserAction"></param>
        public BrowserEDA(BrowserAction browserAction)
        {
            _browserAction = browserAction;
            //提取超时
            TimeSpan timeSpan = TimeSpan.FromSeconds(_browserAction.Timeout);
            _webDriverWait = new WebDriverWait(ComArgs.WebTestDriver, timeSpan);
        }

        #endregion
    }
}