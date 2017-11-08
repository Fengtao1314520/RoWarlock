using System.Collections.Generic;
using System.Xml.Linq;
using Ro.Common.Args;
using Ro.Common.UserType.ActionType;
using Ro.Common.UserType.ScriptsLogicType;
using Ro.Interpreter.ScriptsCore.InterAssistFunc.PublicInterface;

namespace Ro.Interpreter.ScriptsCore.InterAssistFunc.XElementToObject
{
    /// <summary>
    /// tests节点信息
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
                TestCase testCase = new TestCase();

                //annotationXElement节点
                XElement annotationXElement = element.Element(XName.Get("Annotation", ComArgs.RosStr));
                AnnotationType annotationType = new AnnotationType
                {
                    Description = annotationXElement?.Element(XName.Get("Description", ComArgs.RosStr))?.Value,
                    Created = new AuthorData
                    {
                        Author = annotationXElement?.Element(XName.Get("Created", ComArgs.RosStr))?.Attribute(XName.Get("Author", ComArgs.RosStr))?.Value,
                        Data = annotationXElement?.Element(XName.Get("Created", ComArgs.RosStr))?.Attribute(XName.Get("Date", ComArgs.RosStr))?.Value
                    },
                    LastUpdated = new AuthorData
                    {
                        Author = annotationXElement?.Element(XName.Get("LastUpdated", ComArgs.RosStr))?.Attribute(XName.Get("Author", ComArgs.RosStr))?.Value,
                        Data = annotationXElement?.Element(XName.Get("LastUpdated", ComArgs.RosStr))?.Attribute(XName.Get("Date", ComArgs.RosStr))?.Value
                    }
                };
                testCase.Annotation = annotationType;

                //给定Id值
                testCase.Id = element.Attribute(XName.Get("ID", ComArgs.RosStr))?.Value;

                //绑定一个testcase的步骤
                testCase.TestSteps = new Queue<WebAction>();
                foreach (XElement onestep in element.Element(XName.Get("TestSteps", ComArgs.RosStr)).Elements())
                {
                    testCase.TestSteps.Enqueue(new ExtractWebAction(onestep).ExtractWeb);
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
