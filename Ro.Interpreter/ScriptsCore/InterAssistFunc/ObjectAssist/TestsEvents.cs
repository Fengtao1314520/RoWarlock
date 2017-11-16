using System;
using System.Linq;
using Ro.Common.Args;
using Ro.Common.EnumType;
using Ro.Common.UserType.ScriptsLogicType;
using Ro.Interpreter.ScriptsCore.LogicCores;

namespace Ro.Interpreter.ScriptsCore.InterAssistFunc.ObjectAssist
{
    /// <summary>
    /// tests事件
    /// TODO 重点重点重点，关键关键关键
    /// TODO VIPS VIPS VIPS
    /// </summary>
    public class TestsEvents
    {
        /// <summary>
        /// 构造函数
        /// Tests对应事件实例
        /// 处理整个Tests节点
        /// </summary>
        /// <param name="testsType">一个tests对象</param>
        public TestsEvents(TestsType testsType)
        {
            try
            {
               
                //标注web起始日志
                ComArgs.RoLog.WriteLog(LogStatus.LInfo, $"WEB测试日志将写入WebAction_{ComArgs.UseRosName}.log中，具体详情，请查看WebAction_{ComArgs.UseRosName}.log日志");

                //执行所有的TestCase
                while (testsType.TestCases.Any())
                {
                    TestCase sig = testsType.TestCases.Dequeue();
                    ExecuteLogicQueue executeLogicQueue = new ExecuteLogicQueue(sig);
                }
            }
            catch (Exception e)
            {
                ComArgs.RoLog.WriteLog(LogStatus.LExpt, "TestsEvents发生异常", e.ToString());
            }
        }
    }
}
