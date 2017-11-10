using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Ro.Common.Args;
using Ro.Common.EnumType;
using Ro.Common.UserType.ScriptsLogicType;
using Ro.Interpreter.ScriptsCore.InterAssistFunc.PublicInterface;

namespace Ro.Interpreter.ConfigsCore
{
    /// <summary>
    /// 配置文件解析入口
    /// </summary>
    public class ConfigEntrance
    {
        #region 私有值

        private XElement _testMode;
        private XElement _properties;
        private XElement _languages;
        private XElement _macros;

        #endregion


        #region 对应字典

        public Dictionary<string, string> PropertiesDic { get; }
        public Dictionary<string, Queue<TestStep>> MacroDic { get; }

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// 配置文件解析入口
        /// 解析roc/tcc文件
        /// </summary>
        /// <param name="configpath">单个配置文件入口</param>
        public ConfigEntrance(string configpath)
        {
            PropertiesDic = new Dictionary<string, string>();
            MacroDic = new Dictionary<string, Queue<TestStep>>();


            try
            {
                FileInfo confFileInfo = new FileInfo(configpath);
                //获取后缀名
                string execname = confFileInfo.Extension;
                //只有当后缀名为roc或tcc或json时才处理，1.5暂时只支持roc/tcc
                if (execname.ToLower().Equals(".roc") || execname.ToLower().Equals(".tcc"))
                {
                    //读取配置文件
                    XDocument confDocument = XDocument.Load(configpath,LoadOptions.SetLineInfo);
                    //提取根节点
                    XElement rootElement = confDocument.Element(XName.Get("Config", ComArgs.RocStr));

                    _testMode = rootElement?.Element(XName.Get("TestMode", ComArgs.RocStr));
                    _properties = rootElement?.Element(XName.Get("Properties", ComArgs.RocStr));
                    _languages = rootElement?.Element(XName.Get("Languages", ComArgs.RocStr));
                    _macros = rootElement?.Element(XName.Get("Macros", ComArgs.RocStr));
                }

                //解析完单个文件，提取XElement后，需要转为字典

                //判断各个XElement是否为null
                if (_properties != null)
                {
                    foreach (XElement sig in _properties.Elements(XName.Get("Property", ComArgs.RosStr)))
                    {
                        string id = sig.Attribute(XName.Get("ID", ComArgs.RosStr))?.Value;
                        string value = sig.Element(XName.Get("Value", ComArgs.RosStr))?.Value;
                        if (id != null) PropertiesDic.Add(id, value);
                    }
                }
                if (_macros != null)
                {
                    foreach (XElement sig in _macros.Elements(XName.Get("Macro", ComArgs.RocStr)))
                    {
                        Queue<TestStep> queue = new Queue<TestStep>();
                        string id = sig.Attribute(XName.Get("ID", ComArgs.RocStr))?.Value;
                        var elements = sig.Element(XName.Get("MacroActivities", ComArgs.RocStr))?.Elements();
                        if (elements != null)
                            foreach (XElement temp in elements)
                            {
                                queue.Enqueue(new ExtractWebAction(temp, id).ExtractWeb);
                            }
                        if (id != null) MacroDic.Add(id, queue);
                    }
                }
            }
            catch (Exception e)
            {
                ComArgs.RoLog.WriteLog(LogStatus.LExpt, "ConfigEntrance入口发生异常", e.ToString());
            }
        }

        #endregion
    }
}
