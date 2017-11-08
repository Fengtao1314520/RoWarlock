using Ro.Common.Args;
using Ro.Common.UserType.ScriptsLogicType;

namespace Ro.Interpreter.ScriptsCore.InterAssistFunc.ObjectAssist
{
    /// <summary>
    /// Annotation处理事件
    /// </summary>
    public class AnnotationEvents
    {
        #region 构造函数

        /// <summary>
        /// Annotation处理事件
        /// </summary>
        /// <param name="annotationType">一个annotation对象类型</param>
        public AnnotationEvents(AnnotationType annotationType)
        {
            //一般就是创建log，暂不考虑本节点
            //创建Web操作日志
            ComArgs.WebLog.CreateLog($"WebAction_{ComArgs.UseRosName}");
        }

        #endregion
    }
}
