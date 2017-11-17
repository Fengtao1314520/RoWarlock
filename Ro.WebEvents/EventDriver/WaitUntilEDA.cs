using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Ro.Assist.AssistBot;
using Ro.Common.Args;
using Ro.Common.UserType.ActionType;
using Ro.Common.UserType.ScriptsLogicType;
using Ro.WebEvents.ElementDriver;

namespace Ro.WebEvents.EventDriver
{
    public class WaitUntilEDA
    {
        private readonly WaitUntilAction _waitUntilAction;
        private readonly WebDriverWait _webDriverWait;

        private readonly GuiViewEvent _guiViewEvent = new GuiViewEvent();

        #region 返回GET值

        /// <summary>
        /// 页面是否读取完毕
        /// </summary>
        public bool PageIsLoaded
        {
            get
            {
                try
                {
                    bool temp = _webDriverWait.Until((wdriver) =>
                    {
                        IJavaScriptExecutor javaScriptExecutor = ComArgs.WebTestDriver as IJavaScriptExecutor;
                        return javaScriptExecutor != null && javaScriptExecutor.ExecuteScript("return document.readyState").Equals("complete");
                    });

                    if (temp)
                    {
                        ComArgs.SigTestStep.ResultStr = "成功";
                        ComArgs.SigTestStep.Result = true;
                        ComArgs.SigTestStep.ExtraInfo = $"当前页面已载入完成";
                    }
                    else
                    {
                        ComArgs.SigTestStep.ResultStr = "失败";
                        ComArgs.SigTestStep.Result = false;
                        ComArgs.SigTestStep.ExtraInfo = $"当前页面未在设定时间内载入完成";
                    }

                    return temp;
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
                    ComArgs.SigTestStep.StepName = _waitUntilAction.ActionType;
                    ComArgs.SigTestStep.ControlId = "未使用";
                    _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
                }
            }
        }

        /// <summary>
        /// 字符长度
        /// </summary>
        public bool StringLength
        {
            get
            {
                try
                {
                    FindWebElement findele = new FindWebElement(_waitUntilAction.ElementId, _waitUntilAction.Timeout);
                    if (findele.WebElement == null)
                    {
                        ComArgs.SigTestStep.ResultStr = "失败";
                        ComArgs.SigTestStep.Result = false;
                        ComArgs.SigTestStep.ExtraInfo = $"查找元素:{_waitUntilAction.ElementId}不存在,请仔细检查对应控件";
                        return false;
                    }
                    else
                    {
                        //首先要判断是否是easyui
                        IWebElement temp = findele.WebElement.FindElement(By.XPath("following-sibling::input"));
                        //非 EasyUI,直接处理
                        int temple = temp?.GetAttribute("value").Length ?? findele.WebElement.Text.Length;

                        //查找
                        int dvalue = _waitUntilAction.Length - temple;

                        //结果
                        bool revaluel = dvalue == 0 && _waitUntilAction.LenghtType == "Equal" || dvalue > 0 && _waitUntilAction.LenghtType == "Longer" || dvalue < 0 && _waitUntilAction.LenghtType == "Lower";

                        if (revaluel)
                        {
                            ComArgs.SigTestStep.ResultStr = "成功";
                            ComArgs.SigTestStep.Result = true;
                            ComArgs.SigTestStep.ExtraInfo = $"控件文本预期长度:{_waitUntilAction.Length}, 实际长度:{temp}";
                        }
                        else
                        {
                            ComArgs.SigTestStep.ResultStr = "失败";
                            ComArgs.SigTestStep.Result = false;
                            ComArgs.SigTestStep.ExtraInfo = $"控件文本预期长度:{_waitUntilAction.Length}, 实际长度:{temp}";
                        }

                        return revaluel;
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
                    ComArgs.SigTestStep.StepName = _waitUntilAction.ActionType;
                    ComArgs.SigTestStep.ControlId = _waitUntilAction.ElementId;
                    _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
                }
            }
        }

        /// <summary>
        /// 字符包含
        /// </summary>
        public bool StringContains
        {
            get
            {
                try
                {
                    List<bool> rebackBools = new List<bool>();
                    foreach (AreInfo sigAreInfo in _waitUntilAction.AreInfo)
                    {
                        rebackBools.Add(StrContainsPrvFunc(sigAreInfo));
                    }
                    if (rebackBools.Contains(false))
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception e)
                {
                    //ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                    return false;
                }
            }
        }

        /// <summary>
        /// 验证为等
        /// </summary>
        public bool AreEqual
        {
            get
            {
                try
                {
                    List<bool> rebackBools = new List<bool>();
                    foreach (AreInfo sigAreInfo in _waitUntilAction.AreInfo)
                    {
                        rebackBools.Add(AreEqualPrvFunc(sigAreInfo));
                    }
                    if (rebackBools.Contains(false))
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception e)
                {
                    //ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                    return false;
                }
            }
        }


        /// <summary>
        /// 验证不等
        /// </summary>
        public bool AreNotEqual
        {
            get
            {
                try
                {
                    List<bool> rebackBools = new List<bool>();
                    foreach (AreInfo sigAreInfo in _waitUntilAction.AreInfo)
                    {
                        rebackBools.Add(AreNotEqualPrvFunc(sigAreInfo));
                    }
                    if (rebackBools.Contains(false))
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception e)
                {
                    //ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                    return false;
                }
            }
        }


        /// <summary>
        /// 验证为真
        /// </summary>
        public bool IsTrue
        {
            get
            {
                try
                {
                    List<bool> rebackBools = new List<bool>();
                    foreach (AreInfo sigAreInfo in _waitUntilAction.AreInfo)
                    {
                        rebackBools.Add(IsTruePrvFunc(sigAreInfo));
                    }
                    if (rebackBools.Contains(false))
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception e)
                {
                    //ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                    return false;
                }
            }
        }


        /// <summary>
        /// 验证为假
        /// </summary>
        public bool IsFalse
        {
            get
            {
                try
                {
                    List<bool> rebackBools = new List<bool>();
                    foreach (AreInfo sigAreInfo in _waitUntilAction.AreInfo)
                    {
                        rebackBools.Add(IsFalsePrvFunc(sigAreInfo));
                    }
                    if (rebackBools.Contains(false))
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception e)
                {
                    //ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                    return false;
                }
            }
        }

        #endregion


        /// <summary>
        /// 构造函数
        /// 初始化
        /// </summary>
        /// <param name="waitUntilTestStep"></param>
        public WaitUntilEDA(TestStep waitUntilTestStep)
        {
            _waitUntilAction = waitUntilTestStep.WebAction.Action as WaitUntilAction;
            ComArgs.SigTestStep = waitUntilTestStep;
            //提取超时
            if (_waitUntilAction != null)
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds(_waitUntilAction.Timeout);
                _webDriverWait = new WebDriverWait(ComArgs.WebTestDriver, timeSpan);
            }
        }


        #region 私有方法

        /// <summary>
        /// 字符包含
        /// </summary>
        /// <param name="areInfo"></param>
        /// <returns></returns>
        private bool StrContainsPrvFunc(AreInfo areInfo)
        {
            bool re = false;
            string actV = string.Empty;
            try
            {
                //获取ele

                IWebElement ele = new FindWebElement(areInfo.ElementId, _waitUntilAction.Timeout).WebElement;
                if (ele == null)
                {
                    ComArgs.SigTestStep.ResultStr = "失败";
                    ComArgs.SigTestStep.Result = false;
                    ComArgs.SigTestStep.ExtraInfo = $"查找元素:{areInfo.ElementId}不存在,请仔细检查对应控件";
                }
                else
                {
                    //更改预期值为无参数
                    string expvalue = new ArgsIntoValue().BackNormalString(areInfo.ExpectedValue);
                    List<string> actvalue = new List<string>();
                    //根据检索不同查询
                    switch (areInfo.ActualType)
                    {
                        case "Browser.Title":
                            actvalue.Add(ComArgs.WebTestDriver.Title);
                            break;

                        case "Browser.Url":
                            actvalue.Add(ComArgs.WebTestDriver.Url);
                            break;

                        case "RoWebElement.Text":

                            //还需要区分EasyUI的部分写法,不仅是value,还有其他的
                            actvalue.Add(ele.GetAttribute("value"));
                            actvalue.Add(ele.GetAttribute("innerText"));
                            actvalue.Add(ele.GetAttribute("textContent"));
                            actvalue.Add(ele.GetAttribute("text"));
                            actvalue.Add(ele.Text);

                            break;

                        case "RoWebElement.GetAttribute":
                            actvalue.Add(ele.GetAttribute(areInfo.Name));
                            break;
                    }
                    //结果检索
                    foreach (string sigvalue in actvalue)
                    {
                        if (sigvalue != null && sigvalue.Contains(expvalue))
                        {
                            re = true;
                            actV = sigvalue;
                            break;
                        }
                    }

                    if (re)
                    {
                        ComArgs.SigTestStep.ResultStr = "成功";
                        ComArgs.SigTestStep.Result = true;
                        ComArgs.SigTestStep.ExtraInfo = $"控件文本预期值:{expvalue}, 实际值:{actV}, 实际类型:{areInfo.ActualType}";
                    }
                    else
                    {
                        ComArgs.SigTestStep.ResultStr = "失败";
                        ComArgs.SigTestStep.Result = false;
                        StringBuilder abc = new StringBuilder();
                        foreach (string one in actvalue)
                        {
                            abc.Append($"{one}/");
                        }

                        ComArgs.SigTestStep.ExtraInfo = $"控件文本预期值:{expvalue}, 实际值:{abc.ToString()}, 实际类型:{areInfo.ActualType}";
                    }
                }
                return re;
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
                ComArgs.SigTestStep.StepName = _waitUntilAction.ActionType;
                ComArgs.SigTestStep.ControlId = areInfo.ElementId;
                _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
            }
        }

        /// <summary>
        /// 是否相等
        /// </summary>
        /// <param name="areInfo"></param>
        /// <returns></returns>
        private bool AreEqualPrvFunc(AreInfo areInfo)
        {
            bool re = false;
            string actV = string.Empty;
            try
            {
                //获取ele

                IWebElement ele = new FindWebElement(areInfo.ElementId, _waitUntilAction.Timeout).WebElement;
                if (ele == null)
                {
                    ComArgs.SigTestStep.ResultStr = "失败";
                    ComArgs.SigTestStep.Result = false;
                    ComArgs.SigTestStep.ExtraInfo = $"查找元素:{areInfo.ElementId}不存在,请仔细检查对应控件";
                }
                else
                {
                    //更改预期值为无参数
                    string expvalue = new ArgsIntoValue().BackNormalString(areInfo.ExpectedValue);
                    List<string> actvalue = new List<string>();
                    //根据检索不同查询
                    switch (areInfo.ActualType)
                    {
                        case "Browser.Title":
                            actvalue.Add(ComArgs.WebTestDriver.Title);
                            break;

                        case "Browser.Url":
                            actvalue.Add(ComArgs.WebTestDriver.Url);
                            break;

                        case "RoWebElement.Text":

                            //还需要区分EasyUI的部分写法,不仅是value,还有其他的
                            actvalue.Add(ele.GetAttribute("value"));
                            actvalue.Add(ele.GetAttribute("innerText"));
                            actvalue.Add(ele.GetAttribute("textContent"));
                            actvalue.Add(ele.GetAttribute("text"));
                            actvalue.Add(ele.Text);

                            break;

                        case "RoWebElement.GetAttribute":
                            actvalue.Add(ele.GetAttribute(areInfo.Name));
                            break;
                    }
                    //结果检索
                    foreach (string sigvalue in actvalue)
                    {
                        if (sigvalue != null && sigvalue.Equals(expvalue))
                        {
                            re = true;
                            actV = sigvalue;
                            break;
                        }
                    }

                    if (re)
                    {
                        ComArgs.SigTestStep.ResultStr = "成功";
                        ComArgs.SigTestStep.Result = true;
                        ComArgs.SigTestStep.ExtraInfo = $"控件文本预期值:{expvalue}, 实际值:{actV}, 实际类型:{areInfo.ActualType}";
                    }
                    else
                    {
                        ComArgs.SigTestStep.ResultStr = "失败";
                        ComArgs.SigTestStep.Result = false;
                        StringBuilder abc = new StringBuilder();
                        foreach (string one in actvalue)
                        {
                            abc.Append($"{one}/");
                        }

                        ComArgs.SigTestStep.ExtraInfo = $"控件文本预期值:{expvalue}, 实际值:{abc.ToString()}, 实际类型:{areInfo.ActualType}";
                    }
                }
                return re;
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
                ComArgs.SigTestStep.StepName = _waitUntilAction.ActionType;
                ComArgs.SigTestStep.ControlId = areInfo.ElementId;
                _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
            }
        }

        /// <summary>
        /// 是否不等
        /// </summary>
        /// <param name="areInfo"></param>
        /// <returns></returns>
        private bool AreNotEqualPrvFunc(AreInfo areInfo)
        {
            bool re = true;
            string actV = string.Empty;
            try
            {
                //获取ele
                IWebElement ele = new FindWebElement(areInfo.ElementId, _waitUntilAction.Timeout).WebElement;
                if (ele == null)
                {
                    ComArgs.SigTestStep.ResultStr = "失败";
                    ComArgs.SigTestStep.Result = false;
                    ComArgs.SigTestStep.ExtraInfo = $"查找元素:{areInfo.ElementId}不存在,请仔细检查对应控件";
                }
                else
                {
                    //更改预期值为无参数
                    string expvalue = new ArgsIntoValue().BackNormalString(areInfo.ExpectedValue);
                    List<string> actvalue = new List<string>();
                    //根据检索不同查询
                    switch (areInfo.ActualType)
                    {
                        case "Browser.Title":
                            actvalue.Add(ComArgs.WebTestDriver.Title);
                            break;

                        case "Browser.Url":
                            actvalue.Add(ComArgs.WebTestDriver.Url);
                            break;

                        case "RoWebElement.Text":

                            //还需要区分EasyUI的部分写法,不仅是value,还有其他的
                            actvalue.Add(ele.GetAttribute("value"));
                            actvalue.Add(ele.GetAttribute("innerText"));
                            actvalue.Add(ele.GetAttribute("textContent"));
                            actvalue.Add(ele.GetAttribute("text"));
                            actvalue.Add(ele.Text);

                            break;

                        case "RoWebElement.GetAttribute":
                            actvalue.Add(ele.GetAttribute(areInfo.Name));
                            break;
                    }
                    //结果检索
                    foreach (string sigvalue in actvalue)
                    {
                        if (sigvalue != null && sigvalue.Equals(expvalue))
                        {
                            re = false;
                            actV = sigvalue;
                            break;
                        }
                    }

                    if (re)
                    {
                        ComArgs.SigTestStep.ResultStr = "成功";
                        ComArgs.SigTestStep.Result = true;
                        ComArgs.SigTestStep.ExtraInfo = $"控件文本预期值:{expvalue}, 实际值:{actV}, 实际类型:{areInfo.ActualType}";
                    }
                    else
                    {
                        ComArgs.SigTestStep.ResultStr = "失败";
                        ComArgs.SigTestStep.Result = false;
                        StringBuilder abc = new StringBuilder();
                        foreach (string one in actvalue)
                        {
                            abc.Append($"{one}/");
                        }

                        ComArgs.SigTestStep.ExtraInfo = $"控件文本预期值:{expvalue}, 实际值:{abc.ToString()}, 实际类型:{areInfo.ActualType}";
                    }
                }
                return re;
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
                ComArgs.SigTestStep.StepName = _waitUntilAction.ActionType;
                ComArgs.SigTestStep.ControlId = areInfo.ElementId;
                _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
            }
        }


        /// <summary>
        /// 是否为真
        /// </summary>
        /// <param name="areInfo"></param>
        /// <returns></returns>
        private bool IsTruePrvFunc(AreInfo areInfo)
        {
            try
            {
                //获取ele
                IWebElement ele = new FindWebElement(areInfo.ElementId, _waitUntilAction.Timeout).WebElement;
                if (ele == null)
                {
                    ComArgs.SigTestStep.ResultStr = "失败";
                    ComArgs.SigTestStep.Result = false;
                    ComArgs.SigTestStep.ExtraInfo = $"查找元素:{areInfo.ElementId}不存在,请仔细检查对应控件";
                    return false;
                }
                else
                {
                    bool actvalue = new bool();
                    switch (areInfo.ActualType)
                    {
                        case "Browser.IsPageLoaded":
                            IJavaScriptExecutor jsExecutor = ComArgs.WebTestDriver as IJavaScriptExecutor;
                            string com = (string) jsExecutor?.ExecuteScript("return document.readyState");
                            actvalue = com == "complete";
                            break;
                        case "RoWebElement.Displayed":
                            actvalue = ele.Displayed;
                            break;
                        case "RoWebElement.Enabled":
                            //还需要区分EasyUI的部分写法
                            actvalue = ele.Enabled;
                            break;
                        case "RoWebElement.Selected":
                            actvalue = ele.Selected;
                            break;
                    }


                    if (actvalue)
                    {
                        ComArgs.SigTestStep.ResultStr = "成功";
                        ComArgs.SigTestStep.Result = true;
                        ComArgs.SigTestStep.ExtraInfo = $"预期值:{areInfo.ExpectedValue}, 实际值:{actvalue}, 实际类型:{areInfo.ActualType}";
                    }
                    else
                    {
                        ComArgs.SigTestStep.ResultStr = "失败";
                        ComArgs.SigTestStep.Result = false;
                        ComArgs.SigTestStep.ExtraInfo = $"预期值:{areInfo.ExpectedValue}, 实际值:{actvalue}, 实际类型:{areInfo.ActualType}";
                    }

                    return actvalue;
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
                ComArgs.SigTestStep.StepName = _waitUntilAction.ActionType;
                ComArgs.SigTestStep.ControlId = areInfo.ElementId;
                _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
            }
        }

        /// <summary>
        /// 是否为假
        /// </summary>
        /// <param name="areInfo"></param>
        /// <returns></returns>
        private bool IsFalsePrvFunc(AreInfo areInfo)
        {
            try
            {
                bool actvalue = new bool();
                //获取ele
                IWebElement ele = new FindWebElement(areInfo.ElementId, _waitUntilAction.Timeout).WebElement;
                if (ele == null)
                {
                    if (areInfo.ActualType == "RoWebElement.Displayed")
                    {
                        ComArgs.SigTestStep.ResultStr = "成功";
                        ComArgs.SigTestStep.Result = true;
                        ComArgs.SigTestStep.ExtraInfo = $"预期值:{areInfo.ExpectedValue}, 实际值:{actvalue}, 实际类型:{areInfo.ActualType}";
                        actvalue = true;
                    }
                    else
                    {
                        ComArgs.SigTestStep.ResultStr = "失败";
                        ComArgs.SigTestStep.Result = false;
                        ComArgs.SigTestStep.ExtraInfo = $"查找元素:{areInfo.ElementId}不存在,请仔细检查对应控件";
                    }
                }
                else
                {
                    switch (areInfo.ActualType)
                    {
                        case "Browser.IsPageLoaded":
                            IJavaScriptExecutor jsExecutor = ComArgs.WebTestDriver as IJavaScriptExecutor;
                            string com = (string) jsExecutor?.ExecuteScript("return document.readyState");
                            actvalue = com != "complete";
                            break;
                        case "RoWebElement.Displayed":
                            actvalue = !ele.Displayed;
                            break;
                        case "RoWebElement.Enabled":
                            //还需要区分EasyUI的部分写法
                            actvalue = !ele.Enabled;
                            break;
                        case "RoWebElement.Selected":
                            actvalue = !ele.Selected;
                            break;
                    }
                    if (actvalue)
                    {
                        ComArgs.SigTestStep.ResultStr = "成功";
                        ComArgs.SigTestStep.Result = true;
                        ComArgs.SigTestStep.ExtraInfo = $"预期值:{areInfo.ExpectedValue}, 实际值:{actvalue}, 实际类型:{areInfo.ActualType}";
                    }
                    else
                    {
                        ComArgs.SigTestStep.ResultStr = "失败";
                        ComArgs.SigTestStep.Result = false;
                        ComArgs.SigTestStep.ExtraInfo = $"预期值:{areInfo.ExpectedValue}, 实际值:{actvalue}, 实际类型:{areInfo.ActualType}";
                    }
                }
                return actvalue;
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
                ComArgs.SigTestStep.StepName = _waitUntilAction.ActionType;
                ComArgs.SigTestStep.ControlId = areInfo.ElementId;
                _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
            }
        }

        #endregion
    }
}