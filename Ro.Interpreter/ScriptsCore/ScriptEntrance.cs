using System;
using Ro.Common.Args;
using Ro.Common.EnumType;
using Ro.Common.UserType.GuiType;
using Ro.Interpreter.ScriptsCore.InterAssistFunc.ObjectAssist;
using Ro.Interpreter.ScriptsCore.InterAssistFunc.XElementToObject;

namespace Ro.Interpreter.ScriptsCore
{
    /// <summary>
    /// 脚本解析器
    /// 核心类
    /// 入口
    /// 所谓的核心入口，其实就是连接脚本解释器入口和实体对象入口的中间层
    /// </summary>
    public class ScriptEntrance
    {
        #region 共用参数只读值

        /// <summary>
        /// 基本只针对TestsEvents，因此TestsEvents是关键核心
        /// </summary>
        public bool Result { get; }

        #endregion

        #region 构造函数

        /// <summary>
        /// 脚本解释器
        /// 构造函数
        /// </summary>
        /// <param name="scriptsType">tcs文件中所有的子节点</param>
        public ScriptEntrance(ScriptsType scriptsType)
        {
            try
            {
                //TODO 正式开始执行各个对象的实际对应操作
                AnnotationEvents annotationEvents = new AnnotationEvents(new AnnotationNodes(scriptsType.AnnXEle).Annotation_Info);
                TestConfigEvents testConfigEvents = new TestConfigEvents(new TestConfigNodes(scriptsType.ConfXEle).TestConfig_Info);
                StartAppEvents startAppEvents = new StartAppEvents(new StartAppNodes(scriptsType.StartXEle).StartApp_Info);
                TestsEvents testsEvents = new TestsEvents(new TestsNodes(scriptsType.TestsXEle).TestsType_Info);
                CloseAppEvents closeAppEvents = new CloseAppEvents(new CloseAppNodes(scriptsType.CloseXEle).CloseApp_Info);
                LogFunctionEvents logFunctionEvents = new LogFunctionEvents(new LogFunctionNodes(scriptsType.LogFuncXEle).LogFunction_Info);
            }
            catch (Exception e)
            {
                ComArgs.RoLog.WriteLog(LogStatus.LExpt, "脚本解析核心类发生异常", e.ToString());
            }
        }

        #endregion
    }
}
