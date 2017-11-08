using System.Collections.Generic;
using Ro.Common.UserType.ActionType;

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
        public AnnotationType Annotation { get; set; }
        public Queue<WebAction> TestSteps { get; set; }
    }
}
