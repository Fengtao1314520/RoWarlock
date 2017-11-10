using System.Collections.Generic;
using System.Xml.Linq;
using Ro.Common.Args;
using Ro.Common.UserType.ScriptsLogicType;
using Ro.Interpreter.ScriptsCore.InterAssistFunc.PublicInterface;

namespace Ro.Interpreter.ScriptsCore.InterAssistFunc.XElementToObject
{
    /// <summary>
    /// tests节点信息
    /// 修改
    /// </summary>
    public class TestsNodes
    {
        #region 只读Get值

        public TestsType TestsType_Info { get; }

        #endregion

        #region 构造函数

        /// <summary>
        /// tests信息
        /// </summary>
        /// <param name="testsXElement"></param>
        public TestsNodes(XElement testsXElement)
        {
            //1.转为对象
            TestsType testsType = new TestsType
            {
                TestCases = new Queue<TestCase>()
            };
            foreach (XElement element in testsXElement.Elements(XName.Get("TestCase", ComArgs.RosStr)))
            {
                TestCase testCase = new TestCase
                {
                    Id = element.Attribute(XName.Get("ID", ComArgs.RosStr))?.Value, //给定Id值
                    TestSteps = new Queue<TestStep>()
                }; //直接放弃了annotation

                //绑定一个testcase的步骤
                XElement xElement = element.Element(XName.Get("TestSteps", ComArgs.RosStr));
                if (xElement != null)
                    foreach (XElement onestep in xElement.Elements())
                    {
                        testCase.TestSteps.Enqueue(new ExtractWebAction(onestep, testCase.Id).ExtractWeb);
                    }


                //添加
                testsType.TestCases.Enqueue(testCase);
            }

            //根据实际情况进行配置
            TestsType_Info = testsType;
        }

        #endregion
    }
}
