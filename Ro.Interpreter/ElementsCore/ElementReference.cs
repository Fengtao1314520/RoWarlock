using System.Collections.Generic;
using System.Xml.Linq;
using Ro.Common.Args;
using Ro.Common.UserType.ElementType;
using static System.String;

namespace Ro.Interpreter.ElementsCore
{
    /// <summary>
    /// Roi文件辅助类
    /// 解析Roi文件
    /// </summary>
    public class ElementReference
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// 元素检索类与辅助方法
        /// 初始化方法
        /// </summary>
        public ElementReference()
        {
        }

        #endregion

        #region 共用方法

        /// <summary>
        /// 返回SingleWebEle
        /// </summary>
        /// <param name="sigXElement"></param>
        /// <returns></returns>
        public SingleWebEle GetSingleWebEle(XElement sigXElement)
        {
            SingleWebEle singleWebEle = new SingleWebEle();

            XElement valueinfo = sigXElement.Element(XName.Get("valueinfo", ComArgs.RoiStr));
            singleWebEle.Id = sigXElement.Attribute(XName.Get("id", ComArgs.RoiStr))?.Value ?? Empty;
            if (valueinfo!=null)
            {
                singleWebEle.Index = valueinfo.Attribute(XName.Get("index", ComArgs.RoiStr))?.Value ?? Empty;
                singleWebEle.Locator = valueinfo.Attribute(XName.Get("locator", ComArgs.RoiStr))?.Value ?? Empty;
                singleWebEle.Value = valueinfo.Value;
            }

            return singleWebEle;
        }


        /// <summary>
        /// 返回CpxWebELe的队列
        /// </summary>
        /// <param name="sigXElement"></param>
        /// <returns></returns>
        public List<CpxWebELe> GetCpxWebELe(XElement sigXElement)
        {
            //复合元素是多个具有通用性质的元素的集合，本质上就是N个元素的集合
            List<CpxWebELe> cpxWebELelist = new List<CpxWebELe>();

            XElement valueinfo = sigXElement.Element(XName.Get("valueinfo", ComArgs.RoiStr));
            XElement element = sigXElement.Element(XName.Get("complexs", ComArgs.RoiStr));

            if (element != null && valueinfo!=null)
                foreach (XElement childEle in element.Elements(XName.Get("cpxchild",ComArgs.RoiStr)))
                {
                    CpxWebELe cpxWebELe = new CpxWebELe()
                    {
                        Id = childEle.Attribute(XName.Get("id", ComArgs.RoiStr))?.Value ?? Empty,
                        Index = childEle.Attribute(XName.Get("index", ComArgs.RoiStr))?.Value ?? Empty,
                        Value = childEle.Attribute(XName.Get("childvalue", ComArgs.RoiStr))?.Value ?? Empty,

                        HeadIndex = valueinfo.Attribute(XName.Get("index", ComArgs.RoiStr))?.Value ?? Empty,
                        HeadLocator = valueinfo.Attribute(XName.Get("locator", ComArgs.RoiStr))?.Value ?? Empty,
                        HeadValue = valueinfo.Value
                    };

                    cpxWebELelist.Add(cpxWebELe);
                }

            return cpxWebELelist;
        }

        #endregion
    }
}
