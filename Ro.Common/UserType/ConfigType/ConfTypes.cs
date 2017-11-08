using System.Collections.Generic;
using Ro.Common.UserType.ActionType;

namespace Ro.Common.UserType.ConfigType
{
    /// <summary>
    /// 测试模式
    /// </summary>
    public class TestMode
    {
        public string Mode { get; set; }
        public int Loop { get; set; }
    }

    /// <summary>
    /// 语言选项
    /// </summary>
    public class Language
    {
        /// <summary>
        /// 语言字典
        /// </summary>
        public Dictionary<string, List<string>> LanguageList { get; set; }
    }

    /// <summary>
    /// 参数是一种特殊的类，可以通过字典的方式进行存放
    /// </summary>
    public class Properties
    {
        /// <summary>
        /// 全部参数字典
        /// </summary>
        public Dictionary<string, string> PropertyDic { get; set; }
    }

    /// <summary>
    /// 宏操作
    /// </summary>
    public class Macro
    {
        /// <summary>
        /// 全部宏操作字典
        /// </summary>
        public Dictionary<string, Queue<MacroAction>> MacroDic { get; set; }
    }
}
