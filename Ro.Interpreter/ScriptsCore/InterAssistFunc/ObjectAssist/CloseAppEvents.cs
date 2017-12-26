using System;
using System.IO;
using Ro.Common.Args;
using Ro.Common.EnumType;
using Ro.Common.UserType.ScriptsLogicType;

namespace Ro.Interpreter.ScriptsCore.InterAssistFunc.ObjectAssist
{
    /// <summary>
    /// CloseApp事件
    /// </summary>
    public class CloseAppEvents
    {
        /// <summary>
        /// CloseApp事件实例
        /// </summary>
        /// <param name="closeAppType"></param>
        public CloseAppEvents(CloseAppType closeAppType)
        {
            //主要作用是 是否关闭相关进程，并做事情
            //删除对应程序，根据true,false选择

            try
            {
                //创建Web操作日志
                ComArgs.WebLog.DisposeLog(); //结束WebLog的生命周期

                ComArgs.RoLog.WriteLog(LogStatus.LInfo, "准备关闭浏览器、服务和释放资源");
                ComArgs.WebTestDriver.Close();
                ComArgs.WebTestDriver.Quit();
                ComArgs.WebTestDriver.Dispose();
                GC.Collect(); //释放系统资源

                //如果选择false 删除文件夹
                if (!closeAppType.Keep)
                {
                    Directory.Delete("C:/Browser", true);
                }
            }
            catch (Exception e)
            {
                //添加输出
                ComArgs.RoLog.WriteLog(LogStatus.LExpt, "CloseAppEvents发生异常", e.ToString());
            }
        }
    }
}
