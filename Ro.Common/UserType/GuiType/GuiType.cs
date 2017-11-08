using System.Xml.Linq;

namespace Ro.Common.UserType.GuiType
{
    /// <summary>
    /// gui中使用的各类型
    /// </summary>
    public class GuiType
    {
        public string RosPath { get; set; }
        public string RoiPath { get; set; }
        public string RocPath { get; set; }
    }


    /// <summary>
    /// 脚本上下文逻辑对应的Xelement
    /// </summary>
    public class ScriptsType
    {
        public XElement AnnXEle { get; set; }
        public XElement ConfXEle { get; set; }
        public XElement StartXEle { get; set; }
        public XElement TestsXEle { get; set; }
        public XElement CloseXEle { get; set; }
        public XElement LogFuncXEle { get; set; }
    }


    /// <summary>
    /// UI层展示执行结果
    /// UI层的ResultView控件
    /// </summary>
    public class UViewType
    {
        public int No { get; set; }
        public string StepName { get; set; }
        public string ControlId { get; set; }
        public string Result { get; set; }
        public string ExtraInfo { get; set; }
    }


    /// <summary>
    /// UI层展示通过率
    /// 底部Menu
    /// </summary>
    public class UResultType
    {
        public int NowNums { get; set; }
        public int SuccNums { get; set; }
        public int FailNums { get; set; }
        public string Cover { get; set; }
    }
}
