using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using Ro.Assist.AssistBot;
using Ro.Common.Args;
using Ro.Common.UserType.ActionType;
using Ro.Common.UserType.ScriptsLogicType;
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
        private readonly GuiViewEvent _guiViewEvent = new GuiViewEvent();

        #region 只读Get方法

        public bool Back
        {
            get
            {
                try
                {
                    //当前句柄
                    string firsttab = ComArgs.WebTestDriver.CurrentWindowHandle;

                    string secondtab = _webDriverWait.Until(wd =>
                    {
                        wd.Navigate().Back();
                        //再次获取当前句柄
                        return wd.CurrentWindowHandle;
                    });

                    //如果回退与前一个页面句柄相同，或直接回退至new tabs 
                    if (secondtab == firsttab && ComArgs.WebTestDriver.Title == "New Tab")
                    {
                        ComArgs.SigTestStep.ResultStr = "失败";
                        ComArgs.SigTestStep.Result = false;
                        ComArgs.SigTestStep.ExtraInfo = "没有回退成功，或直接回退至新的tab标签页";

                        return false;
                    }
                    else
                    {
                        ComArgs.SigTestStep.ResultStr = "成功";
                        ComArgs.SigTestStep.Result = true;
                        ComArgs.SigTestStep.ExtraInfo = "浏览器回退成功";

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
                    ComArgs.SigTestStep.StepName = _browserAction.ActionType;
                    ComArgs.SigTestStep.ControlId = "未使用";
                    _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
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
                    string firsttab = ComArgs.WebTestDriver.CurrentWindowHandle;

                    string secondtab = _webDriverWait.Until(wd =>
                    {
                        wd.Navigate().Forward(); //前进
                        //再次获取当前句柄
                        return wd.CurrentWindowHandle;
                    });

                    //如果回退与前一个页面句柄相同，或直接回退至new tabs 
                    if (secondtab == firsttab && ComArgs.WebTestDriver.Title == "New Tab")
                    {
                        ComArgs.SigTestStep.ResultStr = "失败";
                        ComArgs.SigTestStep.Result = false;
                        ComArgs.SigTestStep.ExtraInfo = "没有前进成功,直接停留在当前页或新页";

                        return false;
                    }
                    else
                    {
                        ComArgs.SigTestStep.ResultStr = "成功";
                        ComArgs.SigTestStep.Result = true;
                        ComArgs.SigTestStep.ExtraInfo = "浏览器前进成功";

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
                    ComArgs.SigTestStep.StepName = _browserAction.ActionType;
                    ComArgs.SigTestStep.ControlId = "未使用";
                    _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
                }
            }
        }


        public bool Stop
        {
            get
            {
                try
                {
                    string com = _webDriverWait.Until(wd =>
                    {
                        //更改为js
                        IJavaScriptExecutor jsExecutor = wd as IJavaScriptExecutor;
                        jsExecutor?.ExecuteScript("window.stop();");
                        //验证状态
                        return (string) jsExecutor?.ExecuteScript("return document.readyState");
                    });

                    if (com != "complete")
                    {
                        ComArgs.SigTestStep.ResultStr = "失败";
                        ComArgs.SigTestStep.Result = false;
                        ComArgs.SigTestStep.ExtraInfo = "浏览器无法停止刷新";

                        return false;
                    }
                    else
                    {
                        ComArgs.SigTestStep.ResultStr = "成功";
                        ComArgs.SigTestStep.Result = true;
                        ComArgs.SigTestStep.ExtraInfo = "浏览器停止刷新成功";
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
                    ComArgs.SigTestStep.StepName = _browserAction.ActionType;
                    ComArgs.SigTestStep.ControlId = "未使用";
                    _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
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
                    bool com = _webDriverWait.Until(wd =>
                    {
                        wd.Quit();
                        //验证状态
                        return wd.ToString().Contains("null");
                    });

                    if (!com)
                    {
                        ComArgs.SigTestStep.ResultStr = "失败";
                        ComArgs.SigTestStep.Result = false;
                        ComArgs.SigTestStep.ExtraInfo = "浏览器无法关闭,某个进程在使用Webdriver!";
                        return false;
                    }
                    else
                    {
                        ComArgs.SigTestStep.ResultStr = "成功";
                        ComArgs.SigTestStep.Result = true;
                        ComArgs.SigTestStep.ExtraInfo = "浏览器已关闭";
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
                    ComArgs.SigTestStep.StepName = _browserAction.ActionType;
                    ComArgs.SigTestStep.ControlId = "未使用";
                    _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
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
                    string tab2 = _webDriverWait.Until(wd =>
                    {
                        //执行关闭
                        wd.Close();
                        wd.SwitchTo().Window(firsthandle);
                        //验证状态
                        return wd.CurrentWindowHandle;
                    });


                    //验证
                    if (tab1 == tab2 && tab2 == null && ComArgs.WebTestDriver.Title == "New Tab")
                    {
                        ComArgs.SigTestStep.ResultStr = "失败";
                        ComArgs.SigTestStep.Result = false;
                        ComArgs.SigTestStep.ExtraInfo = "浏览器无法关闭当前Tab,或当前Tab是唯一活动Tab且造成测试主体已不存在";

                        return false;
                    }
                    else
                    {
                        ComArgs.SigTestStep.ResultStr = "成功";
                        ComArgs.SigTestStep.Result = true;
                        ComArgs.SigTestStep.ExtraInfo = "浏览器已关闭当前Tab";
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
                    ComArgs.SigTestStep.StepName = _browserAction.ActionType;
                    ComArgs.SigTestStep.ControlId = "未使用";
                    _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
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
                    ComArgs.SigTestStep.ResultStr = "成功";
                    ComArgs.SigTestStep.Result = true;
                    ComArgs.SigTestStep.ExtraInfo = $"浏览器执行脚本为:{_browserAction.JavaScript}";
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
                    ComArgs.SigTestStep.StepName = _browserAction.ActionType;
                    ComArgs.SigTestStep.ControlId = "未使用";
                    _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
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

                    string tab1 = _webDriverWait.Until(wd =>
                    {
                        wd.Navigate().GoToUrl(value);
                        //当前句柄
                        return wd.CurrentWindowHandle;
                    });


                    //验证
                    if (tab1 == null && ComArgs.WebTestDriver.Title == "New Tab")
                    {
                        ComArgs.SigTestStep.ResultStr = "失败";
                        ComArgs.SigTestStep.Result = false;
                        ComArgs.SigTestStep.ExtraInfo = $"请检查网址:{value}是否存在";
                        return false;
                    }
                    else
                    {
                        ComArgs.SigTestStep.ResultStr = "成功";
                        ComArgs.SigTestStep.Result = true;
                        ComArgs.SigTestStep.ExtraInfo = $"浏览器进入对应网址:{value}";
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
                    ComArgs.SigTestStep.StepName = _browserAction.ActionType;
                    ComArgs.SigTestStep.ControlId = "未使用";
                    _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
                }
            }
        }


        public bool Refresh
        {
            get
            {
                try
                {
                    string com = _webDriverWait.Until(wd =>
                    {
                        //更改为js
                        IJavaScriptExecutor jsExecutor = ComArgs.WebTestDriver as IJavaScriptExecutor;
                        //执行载入
                        wd.Navigate().Refresh();

                        if (_browserAction.AutoStopLoad)
                        {
                            Thread.Sleep(_browserAction.Timeout * 200);
                            jsExecutor?.ExecuteScript("window.stop();");
                        }
                        return (string) jsExecutor?.ExecuteScript("return document.readyState");
                    });

                    if (com != "complete")
                    {
                        ComArgs.SigTestStep.ResultStr = "失败";
                        ComArgs.SigTestStep.Result = false;
                        ComArgs.SigTestStep.ExtraInfo = "浏览器一直处于刷新状态,请检查网站是否正常";
                        return false;
                    }
                    else
                    {
                        ComArgs.SigTestStep.ResultStr = "失败";
                        ComArgs.SigTestStep.Result = false;
                        ComArgs.SigTestStep.ExtraInfo = "浏览器刷新成功";
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
                    ComArgs.SigTestStep.StepName = _browserAction.ActionType;
                    ComArgs.SigTestStep.ControlId = "未使用";
                    _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
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
                        ComArgs.WebTestDriver = _webDriverWait.Until(wd => wd.SwitchTo().DefaultContent());
                    }
                    else
                    {
                        //更改测试对象
                        ComArgs.WebTestDriver = _webDriverWait.Until(wd => wd.SwitchTo().Frame(findele.WebElement));
                    }
                    ComArgs.SigTestStep.ResultStr = "成功";
                    ComArgs.SigTestStep.Result = true;
                    ComArgs.SigTestStep.ExtraInfo = "浏览器已切换至对应Iframe内";
                    return true;
                }
                catch (WebDriverTimeoutException)
                {
                    ComArgs.SigTestStep.ResultStr = "失败";
                    ComArgs.SigTestStep.Result = true;
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
                    ComArgs.SigTestStep.StepName = _browserAction.ActionType;
                    ComArgs.SigTestStep.ControlId = _browserAction.ElementId;
                    _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
                }
            }
        }


        public bool SwitchToTab
        {
            get
            {
                try
                {
                    //执行载入
                    ArgsIntoValue argsIntoValue = new ArgsIntoValue();
                    string value = argsIntoValue.BackNormalString(_browserAction.TabName);
                    //所有的窗口句柄
                    IList<string> handles = ComArgs.WebTestDriver.WindowHandles;


                    foreach (string sigHandle in handles)
                    {
                        ComArgs.WebTestDriver.SwitchTo().Window(sigHandle);
                        if (ComArgs.WebTestDriver.Title.Contains(value))
                        {
                            break;
                        }
                    }
                    ComArgs.SigTestStep.ResultStr = "成功";
                    ComArgs.SigTestStep.Result = true;
                    ComArgs.SigTestStep.ExtraInfo = $"浏览器已切换至对应Tab内,tab名称为:{value}";
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
                    ComArgs.SigTestStep.StepName = _browserAction.ActionType;
                    ComArgs.SigTestStep.ControlId = "未使用";
                    _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
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

                    string temp = "c:/temp/Ro_Auto_Logs/Image";
                    ComArgs.WebTestDriver.TakeScreenshot().SaveAsFile($"{temp}/{value}", ScreenshotImageFormat.Jpeg);
                    ComArgs.SigTestStep.ResultStr = "成功";
                    ComArgs.SigTestStep.Result = true;
                    ComArgs.SigTestStep.ExtraInfo = $"截图名称:{value}";
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
                    ComArgs.SigTestStep.StepName = _browserAction.ActionType;
                    ComArgs.SigTestStep.ControlId = "未使用";
                    _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
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
        /// <param name="browserTestStep">browser步骤所有信息</param>
        public BrowserEDA(TestStep browserTestStep)
        {
            _browserAction = browserTestStep.WebAction.Action as BrowserAction;
            ComArgs.SigTestStep = browserTestStep;
            //提取超时
            if (_browserAction != null)
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds(_browserAction.Timeout);
                _webDriverWait = new WebDriverWait(ComArgs.WebTestDriver, timeSpan);
            }
        }

        #endregion
    }
}