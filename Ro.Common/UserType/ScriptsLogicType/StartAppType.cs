using System.Collections.Generic;

namespace Ro.Common.UserType.ScriptsLogicType
{
    /// <summary>
    /// 
    /// </summary>
    public class StartAppType
    {
        public AppInfo AppInfo { get; set; }
    }


    public class AppInfo
    {
        public string AppName { get; set; }
        public string ExecuePath { get; set; }
        public bool BaseWindowsBits { get; set; }
        public string Version { get; set; }
        /// <summary>
        /// App的参数集
        /// </summary>
        public List<string> Parameters { get; set; }
    }
}
