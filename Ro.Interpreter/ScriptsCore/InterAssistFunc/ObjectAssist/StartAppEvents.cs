using System;
using System.IO;
using System.Net;
using System.Threading;
using Ionic.Zip;
using Ro.Common.Args;
using Ro.Common.EnumType;
using Ro.Common.UserType.ScriptsLogicType;

namespace Ro.Interpreter.ScriptsCore.InterAssistFunc.ObjectAssist
{
    public class StartAppEvents
    {
        #region 私有定义

        private string chromdown = "http://chromedriver.storage.googleapis.com";
        private string firefoxdown = "https://github.com/mozilla/geckodriver/releases/download";
        private string iedown = "http://selenium-release.storage.googleapis.com";

        private string temppath = "C://temp";

        #endregion

        #region 构造函数

        /// <summary>
        /// 开始APP的信息
        /// <para>Version 1.5 版本开始,StartApp的事件将直接进行下载</para>
        /// <para>但支持资源模式</para>
        /// </summary>
        /// <param name="startAppType">单个startApp的信息</param>
        public StartAppEvents(StartAppType startAppType)
        {
            try
            {
                AppInfo sigAppInfo = startAppType.AppInfo;
                string brodriverzip = $"{temppath}/BroDriver.zip";
                if (Directory.Exists($"{temppath}/BroDriver"))
                {
                    Directory.Delete($"{temppath}/BroDriver", true); //删除文件夹
                }
                File.Delete(brodriverzip); //删除总ZIP包


                //资源解压，通过资源重新释放
                File.WriteAllBytes(brodriverzip, Resources.DriverRes.BroDriver);
                //设置路径
                ZipFile zip = new ZipFile(brodriverzip);
                //解压得到总文件
                zip.ExtractAll(temppath, ExtractExistingFileAction.OverwriteSilently); //存在则更新
                zip.Dispose();

                //将需要的文件解压至对应文件夹内
                DirectoryInfo directoryInfo = new DirectoryInfo($"{temppath}/BroDriver");
                foreach (FileInfo sigFile in directoryInfo.GetFiles())
                {
                    if (sigFile.Name.ToLower().Contains(sigAppInfo.AppName.ToLower()))
                    {
                        string usebropath = sigFile.FullName;
                        //设置路径
                        ZipFile brozip = new ZipFile(usebropath);
                        //解压得到总文件
                        brozip.ExtractAll(sigAppInfo.ExecuePath,ExtractExistingFileAction.OverwriteSilently); //存在则更新
                        brozip.Dispose();
                    }
                }

                Thread.Sleep(3000); //冻结3秒
                //再次删除包
                Directory.Delete($"{temppath}/BroDriver", true); //删除文件夹
                File.Delete(brodriverzip); //删除总ZIP包

                //写入环境变量
                //SetEnvPathValue.SetPathA(sigAppInfo.ExecuePath);
            }
            catch (Exception e)
            {
                //添加输出
                ComArgs.RoLog.WriteLog(LogStatus.LExpt, "StartAppEvents发生异常", e.ToString());
            }
           
        }


        #region 私有方法

        /// <summary>
        /// 下载方法
        /// 暂时不用
        /// </summary>
        /// <param name="startAppType"></param>
        private void DownLoadFunc(StartAppType startAppType)
        {
            AppInfo sigAppInfo = startAppType.AppInfo;
            string url = String.Empty;

            if (sigAppInfo.AppName.ToLower() == "chrome")
            {
                url = $"{chromdown}/{sigAppInfo.Version}/chromedriver_win32.zip";
            }
            if (sigAppInfo.AppName.ToLower() == "firefox")
            {
                url = $"{firefoxdown}/v{sigAppInfo.Version}/geckodriver-v{sigAppInfo.Version}-win32.zip";
            }
            if (sigAppInfo.AppName.ToLower() == "internetexplorer" && sigAppInfo.AppName.ToLower() == "ie")
            {
                //ie比较特殊，例如3.5.1是归属3.5中,所以这个地方要不定期修改
                url = $"{iedown}/{sigAppInfo.Version.Substring(0, 3).ToString()}/IEDriverServer_Win32_{sigAppInfo.Version}.zip";
            }
            //1.通过webclient进行下载
            WebClient webClient = new WebClient();
            webClient.DownloadFile(url, temppath);

            //2.解压文件
            string zippath = String.Empty;
            //设置路径
            ZipFile zip = new ZipFile(zippath);
            //解压
            zip.ExtractAll(sigAppInfo.ExecuePath);
            Thread.Sleep(1500); //静默1.5秒

            #endregion
        }

        #endregion
    }
}

