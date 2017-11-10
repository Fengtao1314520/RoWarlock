using System.Xml.Linq;

namespace Ro.Common.UserType.GuiType
{
    /// <summary>
    /// gui中使用的各路径
    /// </summary>
    public class GuiUsePath
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
    /// 产出对应输出信息
    /// </summary>
    public class OutPutInfo : UViewType
    {
        
    }


    /// <summary>
    /// UI层展示执行结果
    /// UI层的ResultView控件
    /// </summary>
    public class UViewType : ExpcetionInfo
    {

        /// <summary>
        /// True/False形式的结果
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// 步骤名称
        /// </summary>
        public string StepName { get; set; }

        /// <summary>
        /// 使用的控件Id
        /// </summary>
        public string ControlId { get; set; }

        /// <summary>
        /// 结果
        /// 成功，失败
        /// </summary>
        public string ResultStr { get; set; }

        /// <summary>
        /// 额外产出信息
        /// </summary>
        public string ExtraInfo { get; set; }
    }

    /// <summary>
    /// 异常信息
    /// </summary>
    public class ExpcetionInfo
    {
        public string Message { get; set; }
        /// <summary>
        /// 对应类的位置信息
        /// </summary>
        public string StackTrace { get; set; }

        public string FullName { get; set; }
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
