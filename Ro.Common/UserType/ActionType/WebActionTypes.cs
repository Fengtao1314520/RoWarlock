using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Ro.Common.Args;
using static System.String;

namespace Ro.Common.UserType.ActionType
{
    #region 对外访问

    /// <summary>
    /// web操作
    /// 所有的web操作均会被写入
    /// 对外
    /// </summary>
    public class WebAction
    {
        public object Action { get; set; }
        public XElement ActionXElement { get; set; }
    }

    #endregion


    #region 各类操作

    /// <summary>
    /// Web类型的操作
    /// 前3项为必填
    /// ElementId为基础项
    /// </summary>
    public class BasicAction
    {
        public string ActionType { get; set; }
        public bool TreatErrorsAsWarnings { get; set; }
        public int Timeout { get; set; }
        public string ElementId { get; set; }

        /// <summary>
        /// 构造函数
        /// 解析基础信息
        /// </summary>
        /// <param name="element">传入的基础元素</param>
        public BasicAction(XElement element)
        {
            //解析元素
            ActionType = element.Name.LocalName;

            //获取是否转为警告
            XAttribute eaw = element.Attribute(XName.Get("TreatErrorsAsWarnings", ComArgs.RosStr));
            if (eaw == null)
            {
                TreatErrorsAsWarnings = false;
            }
            else
            {
                TreatErrorsAsWarnings = Convert.ToBoolean(eaw.Value);
            }

            //获取超时
            XAttribute timeout = element.Attribute(XName.Get("Timeout", ComArgs.WebStr));
            if (timeout == null)
            {
                Timeout = ComArgs.DefaultTimeout;
            }
            else
            {
                Timeout = Convert.ToInt32(timeout.Value);
            }

            //获取控件id
            XAttribute eleid = element.Attribute(XName.Get("RoWebElementID", ComArgs.WebStr));
            if (eleid == null)
            {
                ElementId = Empty;
            }
            else
            {
                ElementId = eleid.Value;
            }
        }
    }

    /// <summary>
    /// 启动浏览器
    /// </summary>
    public class LaunchAction : BasicAction
    {
        public string BrowserType { get; set; }
        public bool Run64Bit { get; set; }
        public string Url { get; set; }

        /// <summary>
        /// 构造函数
        /// 解析启动浏览器信息
        /// </summary>
        /// <param name="element">传入的基础元素</param>
        public LaunchAction(XElement element) : base(element)
        {
            //获取浏览器类型,默认为chrome
            XAttribute brotype = element.Attribute(XName.Get("BrowserType", ComArgs.WebStr));
            if (brotype == null)
            {
                BrowserType = "chrome";
            }
            else
            {
                BrowserType = brotype.Value;
            }

            //是否为64位
            XAttribute bits = element.Attribute(XName.Get("Run64Bit", ComArgs.WebStr));
            if (bits == null)
            {
                Run64Bit = false;
            }
            else
            {
                Run64Bit = Convert.ToBoolean(bits.Value);
            }

            //url值,默认为http://localhost:8090/mtstar/
            XAttribute url = element.Attribute(XName.Get("Url", ComArgs.WebStr));
            if (url == null)
            {
                Url = "http://localhost:8090/mtstar/"; //优先给定本定环境
            }
            else
            {
                Url = url.Value;
            }
        }
    }

    /// <summary>
    /// 弹窗
    /// </summary>
    public class AlertAction : BasicAction
    {
        public string SendKeysValue { get; set; }

        /// <summary>
        /// 构造函数
        /// 解析弹窗
        /// </summary>
        /// <param name="element">传入的基础元素</param>
        public AlertAction(XElement element) : base(element)
        {
            //输入值
            XElement sendkeys = element.Element(XName.Get("Value", ComArgs.WebStr));
            if (sendkeys == null)
            {
                SendKeysValue = Empty;
            }
            else
            {
                SendKeysValue = sendkeys.Value;
            }
        }
    }

    /// <summary>
    /// 浏览器操作
    /// </summary>
    public class BrowserAction : BasicAction
    {
        public string JavaScript { get; set; }
        public string Url { get; set; }
        public bool AutoStopLoad { get; set; }
        public bool SwitchToNew { get; set; }
        public string TabName { get; set; }
        public string ImageFile { get; set; }

        /// <summary>
        /// 构造函数
        /// 解析浏览器
        /// </summary>
        /// <param name="element">传入的基础元素</param>
        public BrowserAction(XElement element) : base(element)
        {
            //JS代码输入值
            XElement js = element.Element(XName.Get("JavaScript", ComArgs.WebStr));
            if (js == null)
            {
                JavaScript = Empty;
            }
            else
            {
                JavaScript = js.Value;
            }


            //url值
            XAttribute url = element.Attribute(XName.Get("Url", ComArgs.WebStr));
            if (url == null)
            {
                Url = Empty;
            }
            else
            {
                Url = url.Value;
            }

            //tabname值
            XAttribute tabname = element.Attribute(XName.Get("TabName", ComArgs.WebStr));
            if (tabname == null)
            {
                TabName = Empty;
            }
            else
            {
                TabName = tabname.Value;
            }

            //imagefile值
            XElement im = element.Element(XName.Get("ImageFile", ComArgs.WebStr));
            if (im == null)
            {
                ImageFile = Empty;
            }
            else
            {
                ImageFile = im.Value;
            }

            //SwitchToNew值
            XAttribute stn = element.Attribute(XName.Get("SwitchToNew", ComArgs.WebStr));
            if (stn == null)
            {
                SwitchToNew = false;
            }
            else
            {
                SwitchToNew = Convert.ToBoolean(stn.Value);
            }

            //是否自动停止
            XAttribute sutos = element.Attribute(XName.Get("AutoStopLoad", ComArgs.WebStr));
            if (sutos == null)
            {
                AutoStopLoad = true;
            }
            else
            {
                AutoStopLoad = Convert.ToBoolean(sutos.Value);
            }
        }
    }

    /// <summary>
    /// 鼠标操作
    /// </summary>
    public class MouseAction : BasicAction
    {
        public string MouseType { get; set; }

        /// <summary>
        /// 构造函数
        /// 鼠标操作
        /// </summary>
        /// <param name="element">传入的基础元素</param>
        public MouseAction(XElement element) : base(element)
        {
            //mousetype值 ,默认左键单击
            XAttribute mouse = element.Attribute(XName.Get("MouseType", ComArgs.WebStr));
            if (mouse == null)
            {
                MouseType = "ClickLeft";
            }
            else
            {
                MouseType = mouse.Value;
            }
        }
    }

    /// <summary>
    /// 控件操作
    /// </summary>
    public class ElementAction : BasicAction
    {
        public string SelectType { get; set; }
        public string SelectValue { get; set; }
        public bool ClearFirst { get; set; }
        public string SendKeys { get; set; }
        public bool SetFocus { get; set; }

        /// <summary>
        /// 构造函数
        /// 解析控件操作
        /// </summary>
        /// <param name="element">传入的基础元素</param>
        public ElementAction(XElement element) : base(element)
        {
            //SelectType值
            SelectType = element.Attribute(XName.Get("SelectType", ComArgs.WebStr))?.Value ?? "ByText";

            //SelectValue值
            SelectValue = element.Element(XName.Get("Value", ComArgs.WebStr))?.Value ?? Empty;

            //是否优先清除
            XAttribute clearfirst = element.Attribute(XName.Get("ClearFirst", ComArgs.WebStr));
            ClearFirst = clearfirst != null && Convert.ToBoolean(clearfirst.Value);
            //发送信息值
            SendKeys = element.Element(XName.Get("Value", ComArgs.WebStr))?.Value ?? Empty;

            //是否设置焦点
            XElement focus = element.Element(XName.Get("SetFocus", ComArgs.WebStr));
            SetFocus = focus != null && Convert.ToBoolean(focus?.Value);
        }
    }

    /// <summary>
    /// 时间冻结
    /// </summary>
    public class SleepAction : BasicAction
    {
        public string Message { get; set; }
        public int Seconds { get; set; }

        /// <summary>
        /// 构造函数
        /// 解析Sleep操作
        /// </summary>
        /// <param name="element">传入的基础元素</param>
        public SleepAction(XElement element) : base(element)
        {
            //发送信息值
            Message = element.Attribute(XName.Get("Message", ComArgs.WebStr))?.Value ?? "等待操作...";

            //冻结时间
            XAttribute seconds = element.Attribute(XName.Get("Seconds", ComArgs.WebStr));
            Seconds = seconds == null ? ComArgs.DefaultTimeout : Convert.ToInt32(seconds.Value);
        }
    }

    /// <summary>
    ///  上传操作
    /// </summary>
    public class UpdateAction : BasicAction
    {
        public string FileValue { get; set; }

        /// <summary>
        /// 构造函数
        /// 解析上传操作
        /// </summary>
        /// <param name="element">传入的基础元素</param>
        public UpdateAction(XElement element) : base(element)
        {
            //发送信息值
            FileValue = element.Element(XName.Get("FileValue", ComArgs.WebStr))?.Value ?? Empty;
        }
    }

    /// <summary>
    /// 验证操作
    /// </summary>
    public class WaitUntilAction : BasicAction
    {
        public bool IgnoreCase { get; set; }
        public int Length { get; set; }
        public string LenghtType { get; set; }
        public List<AreInfo> AreInfo { get; set; }

        /// <summary>
        /// 构造函数
        /// 解析WaitUntil操作
        /// </summary>
        /// <param name="element">传入的基础元素</param>
        public WaitUntilAction(XElement element) : base(element)
        {
            //IgnoreCase值
            XAttribute ignorecase = element.Attribute(XName.Get("IgnoreCase", ComArgs.WebStr));
            IgnoreCase = ignorecase != null && Convert.ToBoolean(ignorecase.Value);

            //验证长度
            XElement lengthele = element.Element(XName.Get("LengthType", ComArgs.WebStr));
            if (lengthele == null)
            {
                Length = 0;
                LenghtType = Empty;
            }
            else
            {
                var length = lengthele.Attribute(XName.Get("Length", ComArgs.WebStr));
                var lengthtype = lengthele.Attribute(XName.Get("LenghtType", ComArgs.WebStr));
                //长度值
                Length = length == null ? 0 : Convert.ToInt32(length.Value);
                //长度验证类型
                LenghtType = lengthtype?.Value ?? "Equal";
            }

            //WaitInfo信息，包含一个预期值和一个实际等待验证的对应信息
            AreInfo = new List<AreInfo>();
            //areequal/notequal
            IEnumerable<XElement> waitInfo = element.Elements(XName.Get("WaitInfo", ComArgs.WebStr));
            foreach (XElement oneeles in waitInfo)
            {
                AreInfo areInfo = new AreInfo
                {
                    //预期值
                    ExpectedValue = oneeles.Attribute(XName.Get("ExpectedValue", ComArgs.WebStr))?.Value ?? Empty,
                    //实际值类型
                    ActualType = oneeles.Attribute(XName.Get("ActualType", ComArgs.WebStr))?.Value ?? "RoWebElement.Text",
                    //attribute名称
                    Name = oneeles.Attribute(XName.Get("Name", ComArgs.WebStr))?.Value ?? Empty,
                    //新获取elementid
                    ElementId = oneeles.Attribute(XName.Get("RoWebElementID", ComArgs.WebStr))?.Value ?? Empty
                };
                AreInfo.Add(areInfo);
            }
            //istrue/isfalse
            IEnumerable<XElement> actuals = element.Elements(XName.Get("ActualValue", ComArgs.WebStr));
            foreach (XElement oneeles in actuals)
            {
                AreInfo areInfo = new AreInfo
                {
                    //实际值类型
                    ActualType = oneeles.Attribute(XName.Get("ActualType", ComArgs.WebStr))?.Value ?? Empty,
                    //新获取elementid
                    ElementId = oneeles.Attribute(XName.Get("RoWebElementID", ComArgs.WebStr))?.Value ?? Empty,
                    Name = Empty,
                    //预期值
                    ExpectedValue = ActionType == "WaitUntil.IsTrue" ? "true" : "false"
                };
                AreInfo.Add(areInfo);
            }

            //字符串包含
        }
    }

    /// <summary>
    /// 宏操作
    /// </summary>
    public class MacroAction : BasicAction
    {
        public string MacroId { get; set; }

        /// <summary>
        /// 构造函数
        /// 解析macro操作
        /// macro是一个操作宏
        /// </summary>
        /// <param name="element">传入的基础元素</param>
        public MacroAction(XElement element) : base(element)
        {
            //获取控件id
            MacroId = element.Attribute(XName.Get("MacroID", ComArgs.RosStr))?.Value ?? Empty;
        }
    }

    /// <summary>
    /// 滚动操作
    /// </summary>
    public class ScrollAction : BasicAction
    {
        /// <summary>
        /// 构造函数
        /// 解析scroll操作
        /// </summary>
        /// <param name="element">传入的基础元素</param>
        public ScrollAction(XElement element) : base(element)
        {
        }
    }

    #endregion


    #region  WaitUntilAction使用

    /// <summary>
    /// 实际值
    /// 私有
    /// </summary>
    public class AreInfo
    {
        public string ExpectedValue { get; set; }
        public string ActualType { get; set; }
        public string Name { get; set; }
        public string ElementId { get; set; }
    }

    #endregion
}
