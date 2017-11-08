using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Ro.Common.Args;
using Ro.Common.EnumType;
using Ro.Common.UserType.ElementType;

/*
 * Update Log
 * 2017-9-18创建
 * 2017-9-20更新（1.重写非单元素的2类元素集合）10-12续写
 *
 */

namespace Ro.WebEvents.ElementDriver
{
    /// <summary>
    /// 查询元素
    /// </summary>
    public class FindWebElement
    {
        private readonly TimeSpan _timeSpan; //超时

        #region 返回值

        /// <summary>
        /// 返回元素
        /// 全部返回的是单元素
        /// </summary>
        public IWebElement WebElement { get; }

        #endregion


        #region 构造函数

        /// <summary>
        /// 构造函数
        /// 查询元素
        /// 初始化类、方法等
        /// </summary>
        /// <param name="id">web:RoWebElementId</param>
        /// <param name="timeout">超时</param>
        public FindWebElement(string id, int timeout)
        {
            //清空
            _timeSpan = TimeSpan.FromSeconds(timeout); //提取超时

            //从ele字典中提取对应的id
            object value = ComArgs.ElementDic[id];
            //判断实体类型
            if (value is SingleWebEle)
            {
                WebElement = FindSigEle(value as SingleWebEle);
            }

            if (value is CpxWebELe)
            {
                WebElement = FindCpxEle(value as CpxWebELe);
            }
        }

        #endregion


        #region 私有函数 查询获取父元素，纯单元素

        /// <summary>
        /// 独立元素
        /// </summary>
        /// <param name="sigEle"></param>
        private IWebElement FindSigEle(SingleWebEle sigEle)
        {
            IWebElement sigElement = null;
            try
            {
                ReadOnlyCollection<IWebElement> eles = GetWebElesInHtml(sigEle.Locator, sigEle.Value);
                if (eles == null || eles.Count == 0)
                {
                    ComArgs.WebLog.WriteLog(LogStatus.LFail, $"FindSigEle查询到0个控件,控件:{sigEle.Value}");
                }
                else
                {
                    if (eles.Count == 1)
                    {
                        sigElement = eles[0];
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(sigEle.Index))
                        {
                            sigElement = eles[Convert.ToInt32(sigEle.Index) - 1];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"私有方法FindSigEle发生异常,sigID:{sigEle.Id}", e.ToString());
            }

            return sigElement;
        }

        /// <summary>
        /// 复合元素
        /// </summary>
        /// <param name="cpxEle"></param>
        private IWebElement FindCpxEle(CpxWebELe cpxEle)
        {
            IWebElement cpxElement = null;
            try
            {
                string value = $"{cpxEle.HeadValue}/{cpxEle.Value}";
                ReadOnlyCollection<IWebElement> eles = GetWebElesInHtml(cpxEle.HeadLocator, value);
                if (eles == null || eles.Count == 0)
                {
                    ComArgs.WebLog.WriteLog(LogStatus.LFail, $"FindCpxEle查询到0个控件,FindCpxEle,父值:{cpxEle.HeadValue},子值:{cpxEle.Value}");
                }
                else
                {
                    if (eles.Count == 1)
                    {
                        cpxElement = eles[0];
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(cpxEle.Index))
                        {
                            cpxElement = eles[Convert.ToInt32(cpxEle.Index) - 1];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"私有方法FindCpxEle发生异常,cpxID:{cpxEle.Id}", e.ToString());
            }

            return cpxElement;
        }

        #endregion


        #region 通用私有方法

        /// <summary>
        /// 从HTML中得到一个元素集
        /// </summary>
        /// <param name="locator">元素定位值</param>
        /// <param name="value">元素值</param>
        /// <returns></returns>
        private ReadOnlyCollection<IWebElement> GetWebElesInHtml(string locator, string value)
        {
            try
            {
                //设置等待
                WebDriverWait wait = new WebDriverWait(ComArgs.WebTestDriver, _timeSpan);
                ReadOnlyCollection<IWebElement> eles = null;
                switch (locator.ToLower())
                {
                    case "class":
                        eles = wait.Until(webDriver => webDriver.FindElements(By.ClassName(value)));
                        break;

                    case "css":
                        eles = wait.Until(webDriver => webDriver.FindElements(By.CssSelector(value)));
                        break;

                    case "id":
                        eles = wait.Until(webDriver => webDriver.FindElements(By.Id(value)));
                        break;

                    case "name":
                        eles = wait.Until(webDriver => webDriver.FindElements(By.Name(value)));
                        break;

                    case "xpath":
                        eles = wait.Until(webDriver => webDriver.FindElements(By.XPath(value)));
                        break;

                    case "link":
                        eles = wait.Until(webDriver => webDriver.FindElements(By.LinkText(value)));
                        break;
                }
                return eles;
            }
            catch (WebDriverTimeoutException)
            {
                ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"私有方法GetWebElesInHtml(2参数)查找控件超时,给定的Value值:{value}");
                return null;
            }
            catch (Exception e)
            {
                ComArgs.WebLog.WriteLog(LogStatus.LExpt, "私有方法GetWebElesInHtml(2参数)发生异常", e.ToString());
                return null;
            }
        }

        #endregion
    }
}
