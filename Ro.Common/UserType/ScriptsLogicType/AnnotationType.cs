namespace Ro.Common.UserType.ScriptsLogicType
{

    /// <summary>
    /// Annotation节点类型对象
    /// </summary>
    public class AnnotationType
    {
        public string Description { get; set; }

        public AuthorData Created { get; set; }

        public AuthorData LastUpdated { get; set; }

    }

    public class AuthorData
    {
        public string Author { get; set; }
        public string Data { get; set; }
    }
}
