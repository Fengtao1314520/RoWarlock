using System.Xml.Linq;
using Ro.Common.Args;
using Ro.Common.UserType.ScriptsLogicType;

namespace Ro.Interpreter.ScriptsCore.InterAssistFunc.XElementToObject
{
    /// <summary>
    /// Annotation节点处理
    /// 10/18 重新处理
    /// </summary>
    public class AnnotationNodes
    {
        #region 只读Get值

        public AnnotationType Annotation_Info { get; }

        #endregion


        #region 构造函数

        /// <summary>
        /// Annotation节点处理
        /// xml转为对象
        /// </summary>
        /// <param name="annotationXElement"></param>
        public AnnotationNodes(XElement annotationXElement)
        {
            //1.将节点转为对象

            AnnotationType annotationType = new AnnotationType
            {
                Description = annotationXElement.Element(XName.Get("Description", ComArgs.RosStr))?.Value,
                Created = new AuthorData
                {
                    Author = annotationXElement.Element(XName.Get("Created", ComArgs.RosStr))?.Attribute(XName.Get("Author", ComArgs.RosStr))?.Value,
                    Data = annotationXElement.Element(XName.Get("Created", ComArgs.RosStr))?.Attribute(XName.Get("Date", ComArgs.RosStr))?.Value
                },
                LastUpdated = new AuthorData
                {
                    Author = annotationXElement.Element(XName.Get("LastUpdated", ComArgs.RosStr))?.Attribute(XName.Get("Author", ComArgs.RosStr))?.Value,
                    Data = annotationXElement.Element(XName.Get("LastUpdated", ComArgs.RosStr))?.Attribute(XName.Get("Date", ComArgs.RosStr))?.Value
                }
            };

            Annotation_Info = annotationType;
            //2.填入ExtentReport的有效信息
        }

        #endregion
    }
}
