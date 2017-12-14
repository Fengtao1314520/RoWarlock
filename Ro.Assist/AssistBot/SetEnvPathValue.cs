using System;

namespace Ro.Assist.AssistBot
{
    public class SetEnvPathValue
    {
        /// <summary>
        /// 添加到PATH环境变量（会检测路径是否存在，存在就不重复）
        /// </summary>
        /// <param name="strHome"></param>
        public static void SetPathA(string strHome)
        {
            string pathlist = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine);
            if (pathlist != null)
            {
                string[] list = pathlist.Split(';');
                bool isPathExist = false;

                foreach (string item in list)
                {
                    if (item == strHome)
                        isPathExist = true;
                }
                if (!isPathExist)
                {
                    Environment.SetEnvironmentVariable("PATH", pathlist + ";" + strHome, EnvironmentVariableTarget.Machine);
                }
            }
        }
    }
}
