namespace Ro.Common.UserType.ElementType
{
  
    #region 元素类型

    /// <summary>
    /// 单元素
    /// 独立的元素，通过locator和value可以直接定位到本元素
    /// </summary>
    public class SingleWebEle
    {
        public string Id { get; set; }
        public string Locator { get; set; }
        public string Index { get; set; }
        public string Value { get; set; }
    }


    /// <summary>
    /// 复合元素
    /// 复合元素是同父元素的派生写法，复合元素的子元素都拥有自己的id,只共享使用locator和前缀value
    /// </summary>
    public class CpxWebELe : CpxHead
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public string Index { get; set; }
    }

    #endregion


    #region 头部


    public class CpxHead
    {
        public string HeadLocator { get; set; }
        public string HeadValue { get; set; }
        public string HeadIndex { get; set; }
    }

    #endregion
}
