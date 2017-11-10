using System;
using System.Text.RegularExpressions;
using Ro.Common.Args;
using Ro.Common.EnumType;

namespace Ro.Assist.AssistBot
{
    /// <summary>
    /// 检索参数字典，将参数转为正常值传出
    /// </summary>
    public class ArgsIntoValue
    {
        private string _back = string.Empty;
        /// <summary>
        /// 构造函数，初始化
        /// </summary>
        public ArgsIntoValue()
        {
           
        }

        /// <summary>
        /// 返回普通字符串
        /// </summary>
        /// <param name="args">需要解析的字符串</param>
        /// <returns>返回参数列表中的字符串</returns>
        public string BackNormalString(string args)
        {
            try
            {
                //如果不包含${,说明是纯字符串
                if (!args.Contains("${"))
                {
                    _back = args;
                }
                //如果包含，则说明携带参数话的字符
                else
                {
                    //参数形式为${abcdef}、${abc${def}}、${${abc}def}
                    string pattern = Regex.Escape("${") + "(.*?)}";
                    string sigstr = Regex.Match(args, pattern).Value;
                    //提取参数
                    string arg = sigstr.Replace("${", "").Replace("}", "");
                    string value = ComArgs.PropertiesDic[arg];
                    ComArgs.RoLog.WriteLog(LogStatus.LInfo, $"准备替换的参数为:{arg}, 替换值为:{value}");
                    BackNormalString(value); //递归函数，直至获得一个全文本值
                }
            }
            catch (Exception e)
            {
                ComArgs.RoLog.WriteLog(LogStatus.LExpt, $"BackNormalString反馈真实值发生异常...{args}", e.ToString());
            }
            return _back;
        }
    }
}
