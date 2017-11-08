using System;
using System.IO;
using System.Text;
using Ionic.Zip;
using Ro.Common.Args;
using Ro.Common.EnumType;
using Ro.Common.UserType.ScriptsLogicType;

namespace Ro.Interpreter.ScriptsCore.InterAssistFunc.ObjectAssist
{
    public class LogFunctionEvents
    {
        /// <summary>
        /// 构造函数
        /// log功能相关处理
        /// </summary>
        /// <param name="logFunctionType">log相关对象</param>
        public LogFunctionEvents(LogFunctionType logFunctionType)
        {
            try
            {
                //如果路径没有，直接在桌面给出一个包
                //1.打包log文件
                string savepath = new Assist.AssistBot.ArgsIntoValue().BackNormalString(logFunctionType.LogFilePath);
                if (!Directory.Exists(savepath))
                {
                    Directory.CreateDirectory(savepath);
                }

                ZipFile zipFile = new ZipFile(Encoding.UTF8);
                zipFile.AddDirectory("C:/Temp/Ro_Auto_Logs/image");
                zipFile.AddFile($"C:/Temp/Ro_Auto_Logs/WebAction_{ComArgs.UseRosName}.log");
                //获取当前时间
                string nowtime = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                //存放
                zipFile.Save($"{savepath}/Ro_Auto_Logs_{ComArgs.UseRosName}({nowtime}).zip");
            }
            catch (Exception e)
            {
                //添加输出
                ComArgs.RoLog.WriteLog(LogStatus.LExpt, "LogFunctionEvents发生异常", e.ToString());
            }
           
        }
    }
}