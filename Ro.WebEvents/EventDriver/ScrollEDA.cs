using System;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Ro.Common.Args;
using Ro.Common.EnumType;
using Ro.Common.UserType.ActionType;

namespace Ro.WebEvents.EventDriver
{
    public class ScrollEDA
    {
        private readonly ScrollAction _scrollAction;

        /// <summary>
        /// 向上翻滚
        /// </summary>
        public bool Up
        {
            get
            {
                try
                {
                    //向上滚动
                    ComArgs.WebTestDriver.ExecuteJavaScript<IJavaScriptExecutor>("window.scrollTo(0,0)");
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
        /// 向下翻滚
        /// </summary>
        public bool Down
        {
            get
            {
                try
                {
                    ComArgs.WebTestDriver.ExecuteJavaScript<IJavaScriptExecutor>("window.scrollTo(0,document.body.scrollHeight");
                    return true;
                }
                catch (Exception e)
                {
                    ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                    return false;
                }
            }
        }

        public ScrollEDA(ScrollAction scrollAction)
        {
            _scrollAction = scrollAction;
        }
    }
}
