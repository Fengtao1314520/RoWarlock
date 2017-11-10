using System;
using System.IO;
using Ro.Common.EnumType;
using Ro.Common.UserType.ScriptsLogicType;


namespace Ro.Common.Info
{
    /// <summary>
    /// 基础log，可以被其他log继承
    /// </summary>
    public class BasicLog
    {
        #region 私有值

        /// <summary>
        /// 通过初始化传入的log文件名称
        /// </summary>
        private string _filename;

        /// <summary>
        /// log文件夹
        /// </summary>
        private readonly string _logFolder;

        /// <summary>
        /// log文件路径
        /// </summary>
        private string _filepath;

        /// <summary>
        /// log流
        /// </summary>
        private FileStream _logStream;

        /// <summary>
        /// log文件信息
        /// </summary>
        private FileInfo _logFileInfo;

        #endregion


        /// <summary>
        /// 初始化log
        /// 用以方法可被调用
        /// </summary>
        public BasicLog()
        {
            _logFolder = "C://Temp/Ro_Auto_Logs";
            DirectoryInfo directoryInfo = new DirectoryInfo(_logFolder);
            if (!directoryInfo.Exists)
            {
                Directory.CreateDirectory(_logFolder);
                Directory.CreateDirectory($"{_logFolder}/Backup");
                string back = $"{_logFolder}/Backup";
                Directory.CreateDirectory($"{back}/ToolLog");
                Directory.CreateDirectory($"{back}/ActionLog");
            }
        }


        #region 私有方法

        /// <summary>
        /// 检查log文件是否已存在，如果存在则追加对应信息
        /// </summary>
        private void CheckLogFile()
        {
            _logFileInfo = new FileInfo(_filepath);
            string date = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH-mm-ss");
            //判断文件是否存在，如果不存在则创建
            if (_logFileInfo.Exists)
            {
                if (_filename.Contains("RoUIA"))
                {
                    File.Move(_filepath, $"{_logFolder}/Backup/ToolLog/{_filename}({date}).log"); //如果存在则自动改名
                }
                else
                {
                    File.Move(_filepath, $"{_logFolder}/Backup/ActionLog/{_filename}({date}).log"); //如果存在则自动改名
                }
                _logFileInfo.Delete(); //删除原文件
            }

            //清空Image
            string imagepath = $"{_logFolder}/Image";
            if (Directory.Exists(imagepath))
            {
                Directory.Delete(imagepath, true);
            }
            Directory.CreateDirectory(imagepath);


            _logStream = File.Create(_filepath);
            _logStream.Close();
            _logFileInfo = new FileInfo(_filepath);
        }

        #endregion

        #region 通用方法

        /// <summary>
        /// 创建log文件
        /// </summary>
        /// <param name="filename">文件名称</param>
        public void CreateLog(string filename)
        {
            _filename = filename;
            _filepath = $"{_logFolder}/{_filename}.log"; //存放在temp文件中
            CheckLogFile(); //检查Log
        }


        /// <summary>
        /// 写log
        /// <para>标准</para>
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="message">信息</param>
        /// <param name="extrainfo">额外信息</param>
        public void WriteLog(string status, string message, string extrainfo)
        {
            lock (_logFileInfo)
            {
                _logStream = _logFileInfo.OpenWrite();
                //根据上面创建的文件流创建写数据流
                StreamWriter streamWriter = new StreamWriter(_logStream);
                streamWriter.AutoFlush = true;
                //设置写数据流的起始位置为文件流的末尾
                streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                string log = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} " +
                             $"{status} " +
                             $"{message}\r\n" +
                             $"{extrainfo}\r\n" +
                             $"{Environment.NewLine}";

                //写入日志
                streamWriter.Write(log);
                //清空缓冲区内容，并把缓冲区内容写入基础流
                streamWriter.Flush();
                //关闭写数据流
                streamWriter.Close();
            }
        }

        /// <summary>
        /// 写log
        /// <para>只包含状态和信息</para>
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="message">信息</param>
        public void WriteLog(string status, string message)
        {
            lock (_logFileInfo)
            {
                _logStream = _logFileInfo.OpenWrite();
                //根据上面创建的文件流创建写数据流
                StreamWriter streamWriter = new StreamWriter(_logStream);
                streamWriter.AutoFlush = true;
                //设置写数据流的起始位置为文件流的末尾
                streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                string log = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} " +
                             $"{status} " +
                             $"{message}\r\n" +
                             $"{Environment.NewLine}";

                //写入日志
                streamWriter.Write(log);
                //清空缓冲区内容，并把缓冲区内容写入基础流
                streamWriter.Flush();
                //关闭写数据流
                streamWriter.Close();
            }
        }

        /// <summary>
        /// 写log
        /// 写入OutPutInfo状态的信息
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="sigTestStep">信息</param>
        public void WriteLog(string status, TestStep sigTestStep)
        {
            //基本使用此类的都是涉及weblog输出
            lock (_logFileInfo)
            {
                _logStream = _logFileInfo.OpenWrite();
                //根据上面创建的文件流创建写数据流
                StreamWriter streamWriter = new StreamWriter(_logStream);
                streamWriter.AutoFlush = true;
                //设置写数据流的起始位置为文件流的末尾
                streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                string log = $"操作时间:{DateTime.Now:yyyy-MM-dd HH:mm:ss}\r\n" +
                             $"操作结果:{status}\r\n" +
                             $"Case名称:{sigTestStep.CaseName}   " +
                             $"行号:{sigTestStep.LineNum}   " +
                             $"操作名称:{sigTestStep.StepName}   " +
                             $"使用控件:{sigTestStep.ControlId}  " +
                             $"执行结果:{sigTestStep.ResultStr}\r\n" +
                             $"其他信息:{sigTestStep.ExtraInfo}\r\n" +
                             $"{Environment.NewLine}";

                //写入日志
                streamWriter.Write(log);
                //清空缓冲区内容，并把缓冲区内容写入基础流
                streamWriter.Flush();
                //关闭写数据流
                streamWriter.Close();
            }
        }

        /// <summary>
        /// 写log
        /// 写入OutPutInfo状态的信息
        /// 异常
        /// </summary>
        /// <param name="sigTestStep">信息</param>
        public void WriteExptLog(TestStep sigTestStep)
        {
            //基本使用此类的都是涉及weblog输出
            lock (_logFileInfo)
            {
                _logStream = _logFileInfo.OpenWrite();
                //根据上面创建的文件流创建写数据流
                StreamWriter streamWriter = new StreamWriter(_logStream);
                streamWriter.AutoFlush = true;
                //设置写数据流的起始位置为文件流的末尾
                streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                string log = $"操作时间:{DateTime.Now:yyyy-MM-dd HH:mm:ss}\r\n" +
                             $"操作结果:{LogStatus.LExpt}\r\n" +
                             $"Case名称:{sigTestStep.CaseName}   " +
                             $"行号:{sigTestStep.LineNum}   " +
                             $"操作名称:{sigTestStep.StepName}   " +
                             $"使用控件:{sigTestStep.ControlId}  " +
                             $"执行结果:{sigTestStep.ResultStr}\r\n" +
                             $"其他信息:{sigTestStep.ExtraInfo}\r\n" +
                             "=======================================================================\r\n" +
                             $"Message:{sigTestStep.Message}\r\n" +
                             $"FullName:{sigTestStep.FullName}\r\n" +
                             $"StackTrace:{sigTestStep.StackTrace}\r\n" +
                             $"{Environment.NewLine}";

                //写入日志
                streamWriter.Write(log);
                //清空缓冲区内容，并把缓冲区内容写入基础流
                streamWriter.Flush();
                //关闭写数据流
                streamWriter.Close();
            }
        }

        /// <summary>
        /// 清理托管内存
        /// </summary>
        public void DisposeLog()
        {
            _logStream.Close();
            _logStream.Dispose();
            GC.Collect(); //是否资源
        }

        #endregion
    }
}
