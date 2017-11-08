using System;
using System.Collections.Generic;
using Ro.Common.Args;
using Ro.Common.EnumType;
using Ro.Common.UserType.ScriptsLogicType;
using Ro.Interpreter.ElementsCore;

namespace Ro.Interpreter.ScriptsCore.InterAssistFunc.ObjectAssist
{
    /// <summary>
    /// 测试配置节点主要配置参数和roi/tci元素集文件
    /// </summary>
    public class TestConfigEvents
    {
        /// <summary>
        /// 构造函数
        /// 测试配置
        /// <para>主要是2类，一类是ros中定义的参数，一类是对应的所有的控件文件</para>
        /// </summary>
        /// <param name="testConfigType">测试配置对象</param>
        public TestConfigEvents(TestConfigType testConfigType)
        {

            try
            {
                //1.新增参数
                /*
                 * 配置文件中的优先级比本文中的参数优先级高
                 * 所以只有新增，参数自身不支持参数化
                 * 
                 */

                if (testConfigType.Properties != null)
                {

                    foreach (Property sigpros in testConfigType.Properties)
                    {
                        if (ComArgs.PropertiesDic.ContainsKey(sigpros.Id))
                        {
                            ComArgs.PropertiesDic[sigpros.Id] = sigpros.Value;
                        }
                        else
                        {
                            ComArgs.PropertiesDic.Add(sigpros.Id,sigpros.Value);
                        }
                    }
                }



                ComArgs.ElementDic = new Dictionary<string, object>(); //初始化
                //2.配置roi/tci元素集
                foreach (ConfigurationFile sigconf in testConfigType.Imports)
                {
                    ElementEntrance elementEntrance = new ElementEntrance(sigconf); //一个roi/tci元素集的起点
                    Dictionary<string, object> eledic = elementEntrance.ElementDic;
                    foreach (KeyValuePair<string, object> item in eledic) //追加元素字典
                    {
                        ComArgs.ElementDic.Add(item.Key, item.Value);
                    }
                }
                ComArgs.RoLog.WriteLog(LogStatus.LInfo, $"当前元素字典共计 {ComArgs.ElementDic.Count} 个数据...");
            }
            catch (Exception e)
            {
                ComArgs.RoLog.WriteLog(LogStatus.LExpt, "TestConfigEvents发生异常", e.ToString());
            }
            
        }
    }
}