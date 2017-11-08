using System;
using System.Reflection;
using System.Threading;
using Ro.Common.Args;
using Ro.Common.EnumType;
using Ro.Common.UserType.ActionType;

namespace Ro.WebEvents.EventDriver
{
    public class SleepEDA
    {
        private readonly SleepAction _sleepAction;

        public bool Sleep
        {
            get
            {
                try
                {
                    Thread.Sleep(_sleepAction.Seconds * 1000);
                    return true;
                }
                catch (Exception e)
                {
                    ComArgs.WebLog.WriteLog(LogStatus.LExpt, $"类:{GetType().Name}中方法:{MethodBase.GetCurrentMethod().Name}发生异常", e.ToString());
                    return false;
                }
            }
        }

        public SleepEDA(SleepAction sleepAction)
        {
            _sleepAction = sleepAction;
        }
    }
}