using System;
using System.Collections.Generic;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Ro.Assist.AssistBot;
using Ro.Common.Args;
using Ro.Common.EnumType;
using Ro.Common.UserType.ActionType;
using Ro.WebEvents.ElementDriver;

namespace Ro.WebEvents.EventDriver
{
    public class WaitUntilEDA
    {
        private readonly WaitUntilAction _waitUntilAction;
        private readonly WebDriverWait _webDriverWait;

        private readonly GuiViewEvent _guiViewEvent=new GuiViewEvent();
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
                        var javaScriptExecutor = ComArgs.WebTestDriver as IJavaScriptExecutor;
                        return javaScriptExecutor != null && javaScriptExecutor.ExecuteScript("return document.readyState").Equals("complete");
                    });
                    return temp;
                }
                catch (Exception e)
                {
                    ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                    return false;
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
                        return false;
                    }
                    else
                    {
                        return StrLengthPrvFunc(findele.WebElement);
                    }
                }
                catch (Exception e)
                {
                    ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                    return false;
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
                        IWebElement ele;
                        //获取webelement
                        FindWebElement findWeb = new FindWebElement(sigAreInfo.ElementId, _waitUntilAction.Timeout);
                        if (findWeb.WebElement == null)
                        {
                            ele = null;
                        }
                        else
                        {
                            ele = findWeb.WebElement;
                        }

                        rebackBools.Add(StrContainsPrvFunc(ele, sigAreInfo));
                    }
                    if (rebackBools.Contains(false))
                    {
                        return false;
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
                        IWebElement ele;
                        //获取webelement
                        FindWebElement findWeb = new FindWebElement(sigAreInfo.ElementId, _waitUntilAction.Timeout);
                        if (findWeb.WebElement == null)
                        {
                            ele = null;
                        }
                        else
                        {
                            ele = findWeb.WebElement;
                        }

                        rebackBools.Add(AreEqualPrvFunc(ele, sigAreInfo));
                    }
                    if (rebackBools.Contains(false))
                    {
                        return false;
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
                        IWebElement ele;
                        //获取webelement
                        FindWebElement findWeb = new FindWebElement(sigAreInfo.ElementId, _waitUntilAction.Timeout);
                        if (findWeb.WebElement == null)
                        {
                            ele = null;
                        }
                        else
                        {
                            ele = findWeb.WebElement;
                        }

                        rebackBools.Add(AreNotEqualPrvFunc(ele, sigAreInfo));
                    }
                    if (rebackBools.Contains(false))
                    {
                        return false;
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
                        IWebElement ele;
                        //获取webelement
                        FindWebElement findWeb = new FindWebElement(sigAreInfo.ElementId, _waitUntilAction.Timeout);
                        if (findWeb.WebElement == null)
                        {
                            ele = null;
                        }
                        else
                        {
                            ele = findWeb.WebElement;
                        }

                        rebackBools.Add(IsTruePrvFunc(ele, sigAreInfo));
                    }
                    if (rebackBools.Contains(false))
                    {
                        return false;
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
                        IWebElement ele;
                        //获取webelement
                        FindWebElement findWeb = new FindWebElement(sigAreInfo.ElementId, _waitUntilAction.Timeout);
                        if (findWeb.WebElement == null)
                        {
                            ele = null;
                        }
                        else
                        {
                            ele = findWeb.WebElement;
                        }

                        rebackBools.Add(IsFalsePrvFunc(ele, sigAreInfo));
                    }
                    if (rebackBools.Contains(false))
                    {
                        return false;
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


        /// <summary>
        /// 构造函数
        /// 初始化
        /// </summary>
        /// <param name="waitUntilAction"></param>
        public WaitUntilEDA(WaitUntilAction waitUntilAction)
        {
            _waitUntilAction = waitUntilAction;
            //提取超时
            TimeSpan timeSpan = TimeSpan.FromSeconds(_waitUntilAction.Timeout);
            _webDriverWait = new WebDriverWait(ComArgs.WebTestDriver, timeSpan);
        }


        #region 私有方法

        /// <summary>
        /// 字符长度
        /// </summary>
        /// <param name="ele"></param>
        /// <returns></returns>
        private bool StrLengthPrvFunc(IWebElement ele)
        {
            try
            {
                //首先要判断是否是easyui
                IWebElement temp = ele.FindElement(By.XPath("following-sibling::input"));
                //非 EasyUI,直接处理
                int temple = temp?.GetAttribute("value").Length ?? ele.Text.Length;

                //查找
                int dvalue = _waitUntilAction.Length - temple;

                //结果
                bool revaluel = dvalue == 0 && _waitUntilAction.LenghtType == "Equal" || dvalue > 0 && _waitUntilAction.LenghtType == "Longer" || dvalue < 0 && _waitUntilAction.LenghtType == "Lower";


                ComArgs.ViewType.StepName = _waitUntilAction.ActionType;
                ComArgs.ViewType.ControlId = _waitUntilAction.ElementId;
                ComArgs.ViewType.Result = revaluel ? "成功" : "失败";
                ComArgs.ViewType.ExtraInfo = $"预期长度:{_waitUntilAction.Length}, 实际长度:{dvalue}";
                _guiViewEvent.OnUiViewSteps(ComArgs.ViewType);

                return revaluel;
            }
            catch (Exception e)
            {
                ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                return false;
            }
        }

        /// <summary>
        /// 字符包含
        /// </summary>
        /// <param name="ele"></param>
        /// <param name="areInfo"></param>
        /// <returns></returns>
        private bool StrContainsPrvFunc(IWebElement ele, AreInfo areInfo)
        {
            try
            {
                bool re = false;
                string actV=String.Empty;
                //更改预期值为无参数
                string expvalue = new ArgsIntoValue().BackNormalString(areInfo.ExpectedValue);
                List<string> actvalue = new List<string>();
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

                foreach (string sigvalue in actvalue)
                {
                    if (string.IsNullOrEmpty(sigvalue)) continue;
                    if (!sigvalue.Contains(expvalue)) continue;
                    re = true;
                    //ComArgs.WebLog.WriteLog(LogStatus.LDeb, $"AreNotEqualPrvFunc 预期值:{expvalue},实际值:{sigvalue}");
                    actV = sigvalue;
                    break;
                }

                ComArgs.ViewType.StepName = _waitUntilAction.ActionType;
                ComArgs.ViewType.ControlId = areInfo.ElementId;
                ComArgs.ViewType.Result = re ? "成功" : "失败";
                ComArgs.ViewType.ExtraInfo = $"预期值:{expvalue}, 实际值:{actV},实际类型:{areInfo.ActualType}";
                _guiViewEvent.OnUiViewSteps(ComArgs.ViewType);

                return re;
            }
            catch (Exception e)
            {
                ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                return false;
            }
        }

        /// <summary>
        /// 是否相等
        /// </summary>
        /// <param name="ele"></param>
        /// <param name="sigAreInfo"></param>
        /// <returns></returns>
        private bool AreEqualPrvFunc(IWebElement ele, AreInfo sigAreInfo)
        {
            try
            {
                bool re = false;
                string actV = String.Empty;
                //更改预期值为无参数
                string expvalue = new ArgsIntoValue().BackNormalString(sigAreInfo.ExpectedValue);
                List<string> actvalue = new List<string>();
                switch (sigAreInfo.ActualType)
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
                        actvalue.Add(ele.GetAttribute(sigAreInfo.Name));
                        break;
                }


                foreach (string sigvalue in actvalue)
                {
                    if (string.IsNullOrEmpty(sigvalue)) continue;
                    if (!sigvalue.Equals(expvalue)) continue;
                    re = true;
                    //ComArgs.WebLog.WriteLog(LogStatus.LDeb, $"AreNotEqualPrvFunc 预期值:{expvalue},实际值:{sigvalue}");
                    actV = sigvalue;
                    break;
                }
                ComArgs.ViewType.StepName = _waitUntilAction.ActionType;
                ComArgs.ViewType.ControlId = sigAreInfo.ElementId;
                ComArgs.ViewType.Result = re ? "成功" : "失败";
                ComArgs.ViewType.ExtraInfo = $"预期值:{expvalue}, 实际值:{actV},实际类型:{sigAreInfo.ActualType}";
                _guiViewEvent.OnUiViewSteps(ComArgs.ViewType);
                return re;
            }
            catch (Exception e)
            {
                ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                return false;
            }
        }

        /// <summary>
        /// 是否不等
        /// </summary>
        /// <param name="ele"></param>
        /// <param name="sigAreInfo"></param>
        /// <returns></returns>
        private bool AreNotEqualPrvFunc(IWebElement ele, AreInfo sigAreInfo)
        {
            try
            {
                bool re = true;
                string actV = String.Empty;
                //更改预期值为无参数
                string expvalue = new ArgsIntoValue().BackNormalString(sigAreInfo.ExpectedValue);
                List<string> actvalue = new List<string>();
                switch (sigAreInfo.ActualType)
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
                        actvalue.Add(ele.GetAttribute(sigAreInfo.Name));
                        break;
                }

                foreach (string sigvalue in actvalue)
                {
                    if (string.IsNullOrEmpty(sigvalue)) continue;
                    if (!sigvalue.Equals(expvalue)) continue;
                    re = false;
                    //ComArgs.WebLog.WriteLog(LogStatus.LDeb, $"AreNotEqualPrvFunc 预期值:{expvalue},实际值:{sigvalue}");
                    actV = sigvalue;
                    break;
                }
                ComArgs.ViewType.StepName = _waitUntilAction.ActionType;
                ComArgs.ViewType.ControlId = sigAreInfo.ElementId;
                ComArgs.ViewType.Result = re ? "成功" : "失败";
                ComArgs.ViewType.ExtraInfo = $"预期值:{expvalue}, 实际值:{actV},实际类型:{sigAreInfo.ActualType}";
                _guiViewEvent.OnUiViewSteps(ComArgs.ViewType);
                return re;
            }
            catch (Exception e)
            {
                ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                return false;
            }
        }


        /// <summary>
        /// 是否为真
        /// </summary>
        /// <param name="ele"></param>
        /// <param name="sigAreInfo"></param>
        /// <returns></returns>
        private bool IsTruePrvFunc(IWebElement ele, AreInfo sigAreInfo)
        {
            try
            {
                bool actvalue = new bool();
                switch (sigAreInfo.ActualType)
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
                //ComArgs.WebLog.WriteLog(LogStatus.LDeb, $"预期值:{true.ToString()},实际值:{actvalue}");

                ComArgs.ViewType.StepName = _waitUntilAction.ActionType;
                ComArgs.ViewType.ControlId = sigAreInfo.ElementId;
                ComArgs.ViewType.Result = actvalue ? "成功" : "失败";
                ComArgs.ViewType.ExtraInfo = $"预期值:{sigAreInfo.ExpectedValue}, 实际值:{actvalue},实际类型:{sigAreInfo.ActualType}";
                _guiViewEvent.OnUiViewSteps(ComArgs.ViewType);
                return actvalue;
            }
            catch (Exception e)
            {
                ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                return false;
            }
        }

        /// <summary>
        /// 是否为假
        /// </summary>
        /// <param name="ele"></param>
        /// <param name="sigAreInfo"></param>
        /// <returns></returns>
        private bool IsFalsePrvFunc(IWebElement ele, AreInfo sigAreInfo)
        {
            try
            {
                bool actvalue = new bool();
                switch (sigAreInfo.ActualType)
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
                //ComArgs.WebLog.WriteLog(LogStatus.LDeb, $"预期值:{false.ToString()},实际值:{actvalue}");
                ComArgs.ViewType.StepName = _waitUntilAction.ActionType;
                ComArgs.ViewType.ControlId = sigAreInfo.ElementId;
                ComArgs.ViewType.Result = actvalue ? "成功" : "失败";
                ComArgs.ViewType.ExtraInfo = $"预期值:{sigAreInfo.ExpectedValue}, 实际值:{actvalue},实际类型:{sigAreInfo.ActualType}";
                _guiViewEvent.OnUiViewSteps(ComArgs.ViewType);
                return !actvalue;
            }
            catch (Exception e)
            {
                ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                return false;
            }
        }

        #endregion
    }
}