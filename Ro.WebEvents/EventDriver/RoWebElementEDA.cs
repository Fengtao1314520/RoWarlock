using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Ro.Assist.AssistBot;
using Ro.Common.Args;
using Ro.Common.EnumType;
using Ro.Common.UserType.ActionType;
using Ro.WebEvents.ElementDriver;

namespace Ro.WebEvents.EventDriver
{
    public class RoWebElementEDA
    {
        private readonly ElementAction _elementAction;
        private readonly WebDriverWait _webDriverWait;

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
                        return false;
                    }
                    else
                    {
                        findele.WebElement.Clear();
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
                    FindWebElement findele = new FindWebElement(_elementAction.ElementId, _elementAction.Timeout);
                    if (findele.WebElement == null)
                    {
                        return false;
                    }
                    else
                    {
                        //同父元素享有同一个父节点
                        findele.WebElement.Click();
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

        public bool Select
        {
            get
            {
                try
                {
                    FindWebElement findele = new FindWebElement(_elementAction.ElementId, _elementAction.Timeout);
                    if (findele.WebElement == null)
                    {
                        return false;
                    }

                    else
                    {
                        SelectPriFunc(findele.WebElement, _elementAction.SelectType, _elementAction.SelectValue);
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

        public bool SendKeys
        {
            get
            {
                try
                {
                    FindWebElement findele = new FindWebElement(_elementAction.ElementId, _elementAction.Timeout);
                    if (findele.WebElement == null)
                    {
                        return false;
                    }

                    else
                    {
                        SendKeysPriFunc(findele.WebElement, _elementAction.ClearFirst, _elementAction.SendKeys);
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

        public bool Focus
        {
            get
            {
                try
                {
                    FindWebElement ele = new FindWebElement(_elementAction.ElementId, _elementAction.Timeout);
                    if (ele.WebElement == null)
                    {
                        return false;
                    }
                    //同父元素直接给定到父元素
                    else
                    {
                        new Actions(ComArgs.WebTestDriver).MoveToElement(ele.WebElement).Perform();
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

        #endregion

        #region 构造函数

        public RoWebElementEDA(ElementAction elementAction)
        {
            _elementAction = elementAction;
            //提取超时
            TimeSpan timeSpan = TimeSpan.FromSeconds(_elementAction.Timeout);
            _webDriverWait = new WebDriverWait(ComArgs.WebTestDriver, timeSpan);
        }

        #endregion


        #region 私有方法

        /// <summary>
        /// 下拉菜单的使用
        /// </summary>
        /// <param name="ele"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        private void SelectPriFunc(IWebElement ele, string type, string value)
        {
            try
            {
                if (ele.TagName.Equals("input"))
                {
                    ele.Click(); //优先点击一次控件，让selectdiv出现

                    string xpath = "//div[@class='panel combo-p']";
                    ReadOnlyCollection<IWebElement> classeles = ComArgs.WebTestDriver.FindElements(By.XPath(xpath));
                    IWebElement tempdiv = (from temp in classeles where temp.GetAttribute("outerHTML").Contains("display: block") select temp).SingleOrDefault();
                    //判断是否存在
                    if (tempdiv != null)
                    {
                        //控件存在，按照给定的text值进行点击选择
                        ReadOnlyCollection<IWebElement> tempdivs = tempdiv.FindElements(By.XPath(".//div/descendant::div"));
                        IWebElement useele = (from temp in tempdivs where temp.Text == value select temp).SingleOrDefault();
                        useele?.Click();
                    }
                }
                else
                {
                    //下拉菜单选项  
                    SelectElement sel = new SelectElement(ele);

                    switch (type)
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
            }
            catch (Exception e)
            {
                ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                throw;
            }
        }

        /// <summary>
        /// 输入数据
        /// </summary>
        /// <param name="ele"></param>
        /// <param name="clear"></param>
        /// <param name="value"></param>
        private void SendKeysPriFunc(IWebElement ele, bool clear, string value)
        {
            try
            {
                Thread.Sleep(100);
                ArgsIntoValue asArgsIntoValue = new ArgsIntoValue(); //需要转话为真实值
                string truevalue = asArgsIntoValue.BackNormalString(value);

                //EasyUI的一种特殊模式，需要返回同层节点span的下一层input
                ReadOnlyCollection<IWebElement> eles = ele.FindElements(By.XPath(".//following-sibling::*"));
                IWebElement tempele = (from temp in eles where temp.TagName.Equals("span") select temp).FirstOrDefault();

                if (tempele == null)
                {
                    if (clear)
                    {
                        ele.Clear();
                    }
                    ele.SendKeys(truevalue);
                }
                //确实存在一个span
                else
                {
                    IWebElement useele = tempele.FindElement(By.XPath(".//input[1]"));
                    if (clear)
                    {
                        useele.Clear();
                    }
                    useele.SendKeys(truevalue);
                }
            }
            catch (Exception e)
            {
                ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                throw;
            }
        }

        #endregion
    }
}