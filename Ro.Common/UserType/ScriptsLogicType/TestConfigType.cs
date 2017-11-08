using System.Collections.Generic;

namespace Ro.Common.UserType.ScriptsLogicType
{
    /// <summary>
    /// TestConfig节点对象信息
    /// </summary>
    public class TestConfigType
    {
        /// <summary>
        /// 参数列表
        /// </summary>
        public List<Property> Properties { get; set; }


        /// <summary>
        /// 引入tci文件列表
        /// </summary>
        public List<ConfigurationFile> Imports { get; set; }
    }

    public class Property
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }

    public class ConfigurationFile
    {

        public string Id { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
    }
}

