using System;
using System.Reflection;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Ro.Common.Args;
using Ro.Common.UserType.ActionType;
using Ro.Assist.AssistBot;
using Ro.Common.EnumType;

namespace Ro.WebEvents.EventDriver
{
    /// <summary>
    /// 启动浏览器 事件驱动框架
    /// </summary>
    public class LaunchEDA
    {
        private readonly LaunchAction _launchAction;

        #region 只读Get方法

        /// <summary>
        /// 返回启动浏览器的执行结果
        /// </summary>
        public bool Launch
        {
            get
            {
                bool result = LaunchMethod();
                return result;
            }
        }

        #endregion


        #region 构造函数

        /// <summary>
        /// 启动浏览器
        /// 构造函数
        /// 实体使用方法
        /// </summary>
        /// <param name="launchAction"></param>
        public LaunchEDA(LaunchAction launchAction)
        {
            //初始化赋值
            _launchAction = launchAction;
        }

        #endregion


        #region 私有方法

        /// <summary>
        /// 启动浏览器私有方法
        /// Update 9-15 不再关心是否为64bits, 全部使用为32bits
        /// </summary>
        /// <returns>返回执行结果</returns>
        private bool LaunchMethod()
        {
            bool rel = false;
            string brtype = _launchAction.BrowserType; //启动浏览器类型
            //分拆类型
            switch (brtype)
            {
                case "Firefox":
                    rel = LaunchFirefox();
                    break;
                case "Chrome":
                    rel = LaunchChrome();
                    break;
                case "InternetExplorer":
                    rel = LaunchIE();
                    break;
            }
            return rel;
        }

        #endregion

        #region 3个浏览器的启动方式

        private bool LaunchFirefox()
        {

            //提取超时
            TimeSpan timeout = new TimeSpan(_launchAction.Timeout);
            FirefoxOptions options = new FirefoxOptions { BrowserExecutableLocation = ComArgs.BroswerDriverPath };

            //下载设置
            options.Profile.SetPreference("browser.download.dir", "C:/Users/%username%/Downloads/"); //指定下载路径
            options.Profile.SetPreference("browser.download.folderList", 2);
            options.Profile.SetPreference("browser.download.manager.showWhenStarting", false);
            options.Profile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "images/jpeg, application/pdf, application/octet-stream"); //指定下载文件格式

            //启动firefox浏览器
            ComArgs.WebTestDriver = new FirefoxDriver(options);
            ComArgs.WebTestDriver.Manage().Timeouts().PageLoad = timeout;

            //获取url值
            ComArgs.WebTestDriver.Navigate().GoToUrl(_launchAction.Url);
            //设置长和高
            ComArgs.WebTestDriver.Manage().Window.Maximize();

            return true;

        }


        private bool LaunchChrome()
        {
            try
            {
                ComArgs.RoLog.WriteLog(LogStatus.LInfo, "准备开启ChromeDriver服务，浏览器");
                //提取超时
                TimeSpan timeout = TimeSpan.FromSeconds(_launchAction.Timeout);
                ChromeOptions chromeOptions = new ChromeOptions();
                //ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
                //chromeDriverService.HideCommandPromptWindow = true;

                //下载设置
                chromeOptions.AddUserProfilePreference("download.default_directory", @"C:/Users/%username%/Downloads/");
                chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
                //chromeOptions.BinaryLocation = "C:/Browser/chromedriver.exe";
                //启动chrome浏览器
                ComArgs.WebTestDriver = new ChromeDriver("C:/Browser",  chromeOptions);
                ComArgs.WebTestDriver.Manage().Timeouts().PageLoad = timeout;

                //获取url值
                ArgsIntoValue asArgsIntoValue = new ArgsIntoValue();
                string url = asArgsIntoValue.BackNormalString(_launchAction.Url);
                ComArgs.WebTestDriver.Navigate().GoToUrl(url);
                ComArgs.RoLog.WriteLog(LogStatus.LDeb, $"当前的CurrentWindowHandle是:{ComArgs.WebTestDriver.CurrentWindowHandle}");
                //设置长和高
                //ComArgs.WebTestDriver.Manage().Window.Maximize();

                return true;
            }
            catch (Exception e)
            {
                ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                return false;
            }
           

        }

        private bool LaunchIE()
        {

            //提取超时
            TimeSpan timeout = new TimeSpan(_launchAction.Timeout);
            InternetExplorerOptions ieOptions = new InternetExplorerOptions(); //ie不需要设置
            
         
            //启动ie浏览器
            ComArgs.WebTestDriver = new InternetExplorerDriver(ieOptions);
            ComArgs.WebTestDriver.Manage().Timeouts().PageLoad = timeout;

            //获取url值
            ComArgs.WebTestDriver.Navigate().GoToUrl(_launchAction.Url);
            //设置长和高
            ComArgs.WebTestDriver.Manage().Window.Maximize();

            return true;

        }

        #endregion
    }
}
