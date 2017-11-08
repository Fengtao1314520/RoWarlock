using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Ro.Common.Args;
using Ro.Common.UserType.ScriptsLogicType;

namespace Ro.Interpreter.ScriptsCore.InterAssistFunc.XElementToObject
{
    /// <summary>
    /// TestConfig节点处理
    /// </summary>
    public class TestConfigNodes
    {
        #region 只读Get值

        public TestConfigType TestConfig_Info { get; }

        #endregion

        #region 构造函数

        /// <summary>
        /// TestConfig节点处理
        /// </summary>
        /// <param name="testconfigXElement"></param>
        public TestConfigNodes(XElement testconfigXElement)
        {
            //1.转为对象
            TestConfigType testConfigType = new TestConfigType
            {
                Imports = new List<ConfigurationFile>(),
                Properties = new List<Property>()
            };

            //需要判断Properties下是否包含参数
            XElement proele = testconfigXElement.Element(XName.Get("Properties", ComArgs.RosStr));
            if (proele != null && proele.Elements().Count() != 0)
            {
                foreach (XElement sigXElement in proele.Elements())
                {
                    Property property = new Property
                    {
                        Id = sigXElement.Attribute(XName.Get("ID", ComArgs.RosStr))?.Value,
                        Value = sigXElement.Element(XName.Get("Value", ComArgs.RosStr))?.Value,
                        Description = sigXElement.Element(XName.Get("Description", ComArgs.RosStr))?.Value
                    };


                    //添加
                    testConfigType.Properties.Add(property);
                }
            }

            //需要判断Imports是否包含参数
            XElement impele = testconfigXElement.Element(XName.Get("Imports", ComArgs.RosStr));
            if (impele != null && impele.Elements().Count() != 0)
            {
                foreach (XElement sigXElement in impele.Elements())
                {
                    ConfigurationFile configurationFile = new ConfigurationFile
                    {
                        Id = sigXElement.Attribute(XName.Get("ID", ComArgs.RosStr))?.Value,
                        Type = sigXElement.Attribute(XName.Get("Type", ComArgs.RosStr))?.Value,
                        Path = sigXElement.Element(XName.Get("Path", ComArgs.RosStr))?.Value
                    };


                    //添加
                    testConfigType.Imports.Add(configurationFile);
                }
            }

            //2.根据要求配置testconfig节点
            TestConfig_Info = testConfigType;
        }

        #endregion
    }
}
