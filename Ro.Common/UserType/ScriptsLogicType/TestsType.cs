using System.Collections.Generic;
using Ro.Common.UserType.ActionType;
using Ro.Common.UserType.GuiType;

namespace Ro.Common.UserType.ScriptsLogicType
{
    /// <summary>
    /// Tests节点对象信息
    /// </summary>
    public class TestsType
    {
        public Queue<TestCase> TestCases { get; set; }
    }


    public class TestCase
    { 
        public string Id { get; set; }
        public Queue<TestStep> TestSteps { get; set; }
    }


    /// <summary>
    /// 带入一个TestStep，再带出一个TestStep
    /// </summary>
    public class TestStep : OutPutInfo
    {
        public int LineNum { get; set; }
        public string CaseName { get; set; }
        public WebAction WebAction { get; set; }

    }
}
