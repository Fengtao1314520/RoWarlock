using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Threading;
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
    public class RoWebElementEDA
    {
        private readonly ElementAction _elementAction;
        private readonly WebDriverWait _webDriverWait;
        private readonly GuiViewEvent _guiViewEvent = new GuiViewEvent();

        #region 只读Get方法

        public bool Clear
        {
            get
            {
                try
                {
                    FindWebElement findele = new FindWebElement(_elementAction.ElementId, _elementAction.Timeout);
                    if (findele.WebElement == null)
                    {
                        ComArgs.SigTestStep.ResultStr = "失败";
                        ComArgs.SigTestStep.Result = false;
                        ComArgs.SigTestStep.ExtraInfo = $"查找元素:{_elementAction.ElementId}不存在,请仔细检查对应控件";
                        return false;
                    }
                    else
                    {
                        findele.WebElement.Clear();
                        if (string.IsNullOrEmpty(findele.WebElement.Text))
                        {
                            ComArgs.SigTestStep.ResultStr = "成功";
                            ComArgs.SigTestStep.Result = true;
                            ComArgs.SigTestStep.ExtraInfo = "N/A";
                            return true;
                        }
                        else
                        {
                            ComArgs.SigTestStep.ResultStr = "失败";
                            ComArgs.SigTestStep.Result = false;
                            ComArgs.SigTestStep.ExtraInfo = $"清除文本失败，当前控件依然残留文本:{findele.WebElement.Text},考虑EasyUI,此步骤不一定会导致剩余步骤的失败";
                            return false;
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
                    ComArgs.SigTestStep.StepName = _elementAction.ActionType;
                    ComArgs.SigTestStep.ControlId = _elementAction.ElementId;
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
                    FindWebElement findele = new FindWebElement(_elementAction.ElementId, _elementAction.Timeout);
                    if (findele.WebElement == null)
                    {
                        ComArgs.SigTestStep.ResultStr = "失败";
                        ComArgs.SigTestStep.Result = false;
                        ComArgs.SigTestStep.ExtraInfo = $"查找元素:{_elementAction.ElementId}不存在,请仔细检查对应控件";
                        return false;
                    }
                    else
                    {
                        //同父元素享有同一个父节点
                        findele.WebElement.Click();
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
                    ComArgs.SigTestStep.StepName = _elementAction.ActionType;
                    ComArgs.SigTestStep.ControlId = _elementAction.ElementId;
                    _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
                }
            }
        }

        public bool Select
        {
            get
            {
                try
                {
                    var useele = new FindWebElement(_elementAction.ElementId, _elementAction.Timeout).WebElement;
                    if (useele == null)
                    {
                        ComArgs.SigTestStep.ResultStr = "失败";
                        ComArgs.SigTestStep.Result = false;
                        ComArgs.SigTestStep.ExtraInfo = $"查找元素:{_elementAction.ElementId}不存在,请仔细检查对应控件";
                        return false;
                    }

                    else
                    {
                        ArgsIntoValue asArgsIntoValue = new ArgsIntoValue(); //需要转话为真实值
                        string value = asArgsIntoValue.BackNormalString(_elementAction.SelectValue);

                        //适配easyui
                        if (useele.TagName.Equals("input"))
                        {
                            useele.Click(); //优先点击一次控件，让selectdiv出现

                            string xpath = "//div[@class='panel combo-p']";
                            ReadOnlyCollection<IWebElement> classeles = ComArgs.WebTestDriver.FindElements(By.XPath(xpath));
                            IWebElement tempdiv = (from temp in classeles where temp.GetAttribute("outerHTML").Contains("display: block") select temp).SingleOrDefault();
                            //判断是否存在
                            if (tempdiv != null)
                            {
                                //控件存在，按照给定的text值进行点击选择
                                ReadOnlyCollection<IWebElement> tempdivs = tempdiv.FindElements(By.XPath(".//div/descendant::div"));
                                IWebElement tempele = (from temp in tempdivs where temp.Text == value select temp).SingleOrDefault();
                                tempele?.Click();
                            }
                        }
                        //普通选项
                        else
                        {
                            //下拉菜单选项  
                            SelectElement sel = new SelectElement(useele);

                            switch (_elementAction.SelectType)
                            {
                                case "ByIndex":
                                    sel.SelectByIndex(Convert.ToInt32(value));
                                    break;

                                case "ByValue":
                                    sel.SelectByValue(value);
                                    break;

                                case "ByText":
                                    sel.SelectByText(value);
                                    break;
                            }
                        }

                        //还需要区分EasyUI的部分写法,不仅是value,还有其他的
                        List<string> actvalue = new List<string>
                        {
                            useele.GetAttribute("value"),
                            useele.GetAttribute("innerText"),
                            useele.GetAttribute("textContent"),
                            useele.GetAttribute("text"),
                            useele.Text
                        };


                        if (!actvalue.Contains(value))
                        {
                            ComArgs.SigTestStep.ResultStr = "失败";
                            ComArgs.SigTestStep.Result = false;
                            ComArgs.SigTestStep.ExtraInfo = $"下拉框选择文本失败，当前控件文本不包含{value},考虑EasyUI,此步骤不一定会导致剩余步骤的失败";
                            return false;
                        }
                        else
                        {
                            ComArgs.SigTestStep.ResultStr = "成功";
                            ComArgs.SigTestStep.Result = true;
                            ComArgs.SigTestStep.ExtraInfo = $"下拉框选择文本:{value}";
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
                    ComArgs.SigTestStep.StepName = _elementAction.ActionType;
                    ComArgs.SigTestStep.ControlId = _elementAction.ElementId;
                    _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
                }
            }
        }

        public bool SendKeys
        {
            get
            {
                try
                {
                    IWebElement useele = new FindWebElement(_elementAction.ElementId, _elementAction.Timeout).WebElement;
                    if (useele == null)
                    {
                        ComArgs.SigTestStep.ResultStr = "失败";
                        ComArgs.SigTestStep.Result = false;
                        ComArgs.SigTestStep.ExtraInfo = $"查找元素:{_elementAction.ElementId}不存在,请仔细检查对应控件";
                        return false;
                    }

                    else
                    {
                        Thread.Sleep(100);
                        ArgsIntoValue asArgsIntoValue = new ArgsIntoValue(); //需要转话为真实值
                        string value = asArgsIntoValue.BackNormalString(_elementAction.SendKeys);

                        //EasyUI的一种特殊模式，需要返回同层节点span的下一层input
                        ReadOnlyCollection<IWebElement> eles = useele.FindElements(By.XPath(".//following-sibling::*"));
                        IWebElement tempele = (from temp in eles where temp.TagName.Equals("span") select temp).FirstOrDefault();

                        if (tempele == null)
                        {
                            if (_elementAction.ClearFirst)
                            {
                                useele.Clear();
                            }
                            useele.SendKeys(value);
                        }
                        //确实存在一个span
                        else
                        {
                            useele = tempele.FindElement(By.XPath(".//input[1]"));
                            if (_elementAction.ClearFirst)
                            {
                                useele.Clear();
                            }
                            useele.SendKeys(value);
                        }
                        //还需要区分EasyUI的部分写法,不仅是value,还有其他的
                        List<string> actvalue = new List<string>
                        {
                            useele.GetAttribute("value"),
                            useele.GetAttribute("innerText"),
                            useele.GetAttribute("textContent"),
                            useele.GetAttribute("text"),
                            useele.Text
                        };

                        //结果检索
                        foreach (string sigvalue in actvalue)
                        {
                            if ((sigvalue != null && value.Contains(sigvalue)) || (sigvalue != null && sigvalue.Contains(value)))
                            {
                                ComArgs.SigTestStep.ResultStr = "成功";
                                ComArgs.SigTestStep.Result = true;
                                ComArgs.SigTestStep.ExtraInfo = $"输入文本值:{value}";
                                return true;
                            }
                        }

                        ComArgs.SigTestStep.ResultStr = "成功";
                        ComArgs.SigTestStep.Result = true;
                        ComArgs.SigTestStep.ExtraInfo = $"输入文本存在问题，输入文本值:{value}，但当前控件文本不包含{value},考虑EasyUI,此步骤不一定会导致剩余步骤的失败";
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
                    ComArgs.SigTestStep.StepName = _elementAction.ActionType;
                    ComArgs.SigTestStep.ControlId = _elementAction.ElementId;
                    _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
                }
            }
        }

        public bool Focus
        {
            get
            {
                try
                {
                    FindWebElement ele = new FindWebElement(_elementAction.ElementId, _elementAction.Timeout);
                    if (ele.WebElement == null)
                    {
                        ComArgs.SigTestStep.ResultStr = "失败";
                        ComArgs.SigTestStep.Result = false;
                        ComArgs.SigTestStep.ExtraInfo = $"查找元素:{_elementAction.ElementId}不存在,请仔细检查对应控件";
                        return false;
                    }
                    //同父元素直接给定到父元素
                    else
                    {
                        new Actions(ComArgs.WebTestDriver).MoveToElement(ele.WebElement).Perform();
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
                    ComArgs.SigTestStep.StepName = _elementAction.ActionType;
                    ComArgs.SigTestStep.ControlId = _elementAction.ElementId;
                    _guiViewEvent.OnUiViewSteps(ComArgs.SigTestStep);
                }
            }
        }

        #endregion

        #region 构造函数

        public RoWebElementEDA(TestStep elementTestStep)
        {
            _elementAction = elementTestStep.WebAction.Action as ElementAction;
            ComArgs.SigTestStep = elementTestStep;
            //提取超时
            if (_elementAction != null)
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds(_elementAction.Timeout);
                _webDriverWait = new WebDriverWait(ComArgs.WebTestDriver, timeSpan);
            }
        }

        #endregion
    }
}