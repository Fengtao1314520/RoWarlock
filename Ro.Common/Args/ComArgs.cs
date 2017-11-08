using System.Collections.Generic;
using OpenQA.Selenium;
using Ro.Common.Info;
using Ro.Common.UserType.ActionType;
using Ro.Common.UserType.GuiType;

namespace Ro.Common.Args
{
    /// <summary>
    /// 全局通用参数设定类
    /// </summary>
    public class ComArgs
    {
        #region Const值

        public const string RosStr = "http://tempuri.org/RoFramework.xsd";
        public const string WebStr = "http://tempuri.org/RoWebAutomation.xsd";
        public const string RocStr = "http://tempuri.org/RocFile.xsd";
        public const string RoiStr = "http://tempuri.org/RoiFile.xsd";

        /// <summary>
        /// 默认超时
        /// </summary>
        public const int DefaultTimeout = 15;

        /// <summary>
        /// 默认是否将错误转为警告
        /// </summary>
        public const bool DefaultErrorsAsWarnings = false;

        #endregion


        #region 字典

        /// <summary>
        /// 参数字典
        /// </summary>
        public static Dictionary<string, string> PropertiesDic;

        /// <summary>
        /// 语言字典
        /// </summary>
        public static Dictionary<string, List<string>> LanguageDic;

        /// <summary>
        /// 宏字典
        /// </summary>
        public static Dictionary<string, Queue<WebAction>> MacroDic;

        /// <summary>
        /// 元素字典
        /// </summary>
        public static Dictionary<string, object> ElementDic;

        #endregion


        #region Log定义

        /*
        * 创建2个log,一个是工具自身的操作，一个是web操作
        */

        /// <summary>
        /// 工具自身log
        /// 从工具开始启动到结束
        /// </summary>
        public static BasicLog RoLog = new BasicLog();

        /// <summary>
        /// web操作log
        /// 单个ros的生命周期内
        /// </summary>
        public static BasicLog WebLog = new BasicLog();

        #endregion


        #region Status值

        /// <summary>
        /// 浏览器驱动路径
        /// </summary>
        public static string BroswerDriverPath;

        /// <summary>
        /// webdriver对象
        /// </summary>
        public static IWebDriver WebTestDriver;

        /// <summary>
        /// 一个新的GuiType
        /// </summary>
        public static GuiType GuiType;

        /// <summary>
        /// 当前运行的Ros脚本
        /// </summary>
        public  static string UseRosName { get; set; }

        public static UResultType ResultType;
        public static UViewType ViewType;


        #endregion
    }
}
