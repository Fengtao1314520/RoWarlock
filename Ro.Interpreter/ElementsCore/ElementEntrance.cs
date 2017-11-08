using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Ro.Assist.AssistBot;
using Ro.Common.Args;
using Ro.Common.EnumType;
using Ro.Common.UserType.ElementType;
using Ro.Common.UserType.ScriptsLogicType;


/*
 * 元素集文件入口
 * 用以解析roi/tci文件，只解析脚本中需要用到的元素集文件
 */
namespace Ro.Interpreter.ElementsCore
{
    /// <summary>
    /// 元素集解析核心
    /// </summary>
    public class ElementEntrance
    {
        #region 私有&公有定义

        /// <summary>
        /// 元素字典，返回值
        /// </summary>
        public Dictionary<string, object> ElementDic { get; }

        #endregion


        #region 构造函数

        /// <summary>
        /// 元素集解析核心
        /// 解析传入的元素集tci文件
        /// 当运行Testsconfig的时候开始处理
        /// <param name="sigconf">单个conf实体类</param>
        /// </summary>
        public ElementEntrance(ConfigurationFile sigconf)
        {
            try
            {
                //尽量使用字典来处理一堆N多的而又复杂的逻辑对应关系,初始化
                ElementDic = new Dictionary<string, object>();

                /*
                 * 处理roi/tci文件的路径问题（还要考虑参数化问题） 
                 * 参数形式为${abcdef}、${abc${def}}、${${abc}def}
                */
                string noargspath = new ArgsIntoValue().BackNormalString(sigconf.Path); //返回一个没有参数的路径
                //开始查找对应的文件
                FileInfo fileInfo = new FileInfo(noargspath);
                //如果文件存在
                if (fileInfo.Exists)
                {
                    ElementAssist(sigconf, noargspath);
                }
                //如果文件不存在，说明可能就不存在，或简写为文件名，而不是全路径，也需要区别对待(暂未开发)
                else
                {
                    if (!string.IsNullOrEmpty(ComArgs.GuiType.RoiPath))
                    {
                        //如果值存在
                        string path = $"{ComArgs.GuiType.RoiPath}/{noargspath}"; //文件路径
                        ComArgs.RoLog.WriteLog(LogStatus.LDeb, $"ElementEntrance中当前处理的路径为:{path}");
                        //开始查找对应的文件
                        fileInfo = new FileInfo(path);
                        //如果文件存在
                        if (fileInfo.Exists)
                        {
                            ElementAssist(sigconf, path); //使用私有方法
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ComArgs.RoLog.WriteLog(LogStatus.LExpt, "Exception入口发生异常", e.ToString());
            }
        }

        #endregion


        #region 私有方法

        /// <summary>
        /// 元素协助方法，对已存在的roi/tci文件进行解析
        /// </summary>
        /// <param name="sigconf">配置实体类</param>
        /// <param name="path">实际路径</param>
        private void ElementAssist(ConfigurationFile sigconf, string path)
        {
            ElementReference elementReference = new ElementReference();

            try
            {
                //读取roi/tci文件
                XDocument doc = XDocument.Load(path);
                //提取根节点
                XElement rootEle = doc.Element(XName.Get("roi", ComArgs.RoiStr));
                //获取meta节点
                XElement metaele = rootEle?.Element(XName.Get("meta", ComArgs.RoiStr));
                if (metaele != null)
                {
                    foreach (XElement sigXElement in metaele.Elements())
                    {
                        string name = sigXElement.Name.LocalName;
                        switch (name)
                        {
                            case "sigele":

                                SingleWebEle sig = elementReference.GetSingleWebEle(sigXElement);
                                ElementDic.Add($"{sigconf.Id}.{sig.Id}", sig); //添加到字典
                                break;
                            case "cpxele":
                                List<CpxWebELe> cpx = elementReference.GetCpxWebELe(sigXElement);
                                foreach (CpxWebELe variable in cpx)
                                {
                                    ElementDic.Add($"{sigconf.Id}.{variable.Id}", variable); //添加到字典
                                }
                                break;

                            case "superset":

                                foreach (XElement oneeleFir in sigXElement.Elements(XName.Get("subset", ComArgs.RoiStr)))
                                {
                                    foreach (XElement oneeleSec in oneeleFir.Elements())
                                    {
                                        string nameSec = oneeleSec.Name.LocalName;
                                        switch (nameSec)
                                        {
                                            case "sigele":

                                                SingleWebEle sigSec = elementReference.GetSingleWebEle(oneeleSec);
                                                ElementDic.Add($"{sigconf.Id}.{sigSec.Id}", sigSec); //添加到字典
                                                break;
                                            case "cpxele":
                                                List<CpxWebELe> cpxSec = elementReference.GetCpxWebELe(oneeleSec);
                                                foreach (CpxWebELe variable in cpxSec)
                                                {
                                                    ElementDic.Add($"{sigconf.Id}.{variable.Id}", variable); //添加到字典
                                                }
                                                break;
                                        }
                                    }
                                }

                                break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ComArgs.RoLog.WriteLog(LogStatus.LExpt, "私有方法ElementAssist发生异常", e.ToString());
            }
        }

        #endregion
    }
}
