using System;
using System.Collections.Generic;
using Ro.Common.Args;
using Ro.Common.EnumType;
using Ro.Common.UserType.ActionType;
using Ro.Common.UserType.ScriptsLogicType;
using Ro.WebEvents.EventDriver;
using System.Linq;
using Ro.Assist.AssistBot;

namespace Ro.Interpreter.ScriptsCore.LogicCores
{
    /// <summary>
    /// 执行逻辑队列
    /// TODO 重点重点重点，关键关键关键
    /// </summary>
    public class ExecuteLogicQueue
    {
        #region 构造函数

        private readonly GuiViewEvent _guiViewEvent = new GuiViewEvent();
        private ArgsIntoValue _argsIntoValue = new ArgsIntoValue();
        /// <summary>
        /// 执行逻辑队列
        /// 构造函数
        /// </summary>
        /// <param name="testCase">单个testcase节点</param>
        public ExecuteLogicQueue(TestCase testCase)
        {
            //传入一个完整的执行逻辑队列，由解析核心传入，并使用此方法

            //TODO 1. Annotation处理, Id处理

            //TODO 2. teststep处理

            while (testCase.TestSteps.Any())
            {
                //1.单个web的操作对象
                WebAction sig = testCase.TestSteps.Dequeue();
                bool res = SingleStepExec(sig);
            }
        }

        #endregion


        #region 私有方法

        /// <summary>
        /// 私有方法，执行一个单独的步骤，并返回对应的
        /// </summary>
        /// <param name="webAction"></param>
        /// <returns></returns>
        private bool SingleStepExec(WebAction webAction)
        {
            try
            {
                //对象转实体
                LaunchAction launchAction = webAction.Action as LaunchAction;
                AlertAction alertAction = webAction.Action as AlertAction;
                BrowserAction browserAction = webAction.Action as BrowserAction;
                MacroAction macroAction = webAction.Action as MacroAction;
                MouseAction mouseAction = webAction.Action as MouseAction;
                ElementAction elementAction = webAction.Action as ElementAction;
                ScrollAction scrollAction = webAction.Action as ScrollAction;
                SleepAction sleepAction = webAction.Action as SleepAction;
                UpdateAction updateAction = webAction.Action as UpdateAction;
                WaitUntilAction waitUntilAction = webAction.Action as WaitUntilAction;

                //开始判断操作
                bool sigresult = false;

                switch (webAction.ActionXElement.Name.LocalName)
                {
                    case WebActionConst.LaunchBrowser:
                        sigresult = new LaunchEDA(launchAction).Launch;
                        ComArgs.ViewType.StepName = launchAction.ActionType;
                        ComArgs.ViewType.ControlId = "未使用";
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = $"启动浏览器类型:{launchAction.BrowserType},网址:{launchAction.Url}";
                        break;

                    case WebActionConst.AlertAccept:
                        sigresult = new AlertEDA(alertAction).Accept;
                        ComArgs.ViewType.StepName = alertAction.ActionType;
                        ComArgs.ViewType.ControlId = "未使用";
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = "N/A";
                        break;

                    case WebActionConst.AlertDismiss:
                        sigresult = new AlertEDA(alertAction).Dismiss;
                        ComArgs.ViewType.StepName = alertAction.ActionType;
                        ComArgs.ViewType.ControlId = "未使用";
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = "N/A";
                        break;

                    case WebActionConst.AlertSendKeys:
                        sigresult = new AlertEDA(alertAction).SendKeys;
                        ComArgs.ViewType.StepName = alertAction.ActionType;
                        ComArgs.ViewType.ControlId = "未使用";
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = $"输入信息:{_argsIntoValue.BackNormalString(alertAction.SendKeysValue)}";
                        break;

                    case WebActionConst.BrowserBack:
                        sigresult = new BrowserEDA(browserAction).Back;
                        ComArgs.ViewType.StepName = browserAction.ActionType;
                        ComArgs.ViewType.ControlId = "未使用";
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = "N/A";
                        break;

                    case WebActionConst.BrowserClose:
                        sigresult = new BrowserEDA(browserAction).Close;
                        ComArgs.ViewType.StepName = browserAction.ActionType;
                        ComArgs.ViewType.ControlId = "未使用";
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = "N/A";
                        break;

                    case WebActionConst.BrowserCloseTab:
                        sigresult = new BrowserEDA(browserAction).CloseTab;
                        ComArgs.ViewType.StepName = browserAction.ActionType;
                        ComArgs.ViewType.ControlId = "未使用";
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = "N/A";

                        break;

                    case WebActionConst.BrowserExecuteScript:
                        sigresult = new BrowserEDA(browserAction).ExecuteScript;
                        ComArgs.ViewType.StepName = browserAction.ActionType;
                        ComArgs.ViewType.ControlId = "未使用";
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = $"执行脚本:{_argsIntoValue.BackNormalString(browserAction.JavaScript)}";
                        break;

                    case WebActionConst.BrowserForward:
                        sigresult = new BrowserEDA(browserAction).Forward;
                        ComArgs.ViewType.StepName = browserAction.ActionType;
                        ComArgs.ViewType.ControlId = "未使用";
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = "N/A";
                        break;

                    case WebActionConst.BrowserGoToUrl:
                        sigresult = new BrowserEDA(browserAction).GoToUrl;
                        ComArgs.ViewType.StepName = browserAction.ActionType;
                        ComArgs.ViewType.ControlId = "未使用";
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = $"跳转页面:{_argsIntoValue.BackNormalString(browserAction.Url)}";
                        break;

                    case WebActionConst.BrowserRefresh:
                        sigresult = new BrowserEDA(browserAction).Refresh;
                        ComArgs.ViewType.StepName = browserAction.ActionType;
                        ComArgs.ViewType.ControlId = "未使用";
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = "N/A";
                        break;

                    case WebActionConst.BrowserStop:
                        sigresult = new BrowserEDA(browserAction).Stop;
                        ComArgs.ViewType.StepName = browserAction.ActionType;
                        ComArgs.ViewType.ControlId = "未使用";
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = "N/A";
                        break;

                    case WebActionConst.BrowserSwitchFrame:
                        sigresult = new BrowserEDA(browserAction).SwitchFrame;
                        ComArgs.ViewType.StepName = browserAction.ActionType;
                        ComArgs.ViewType.ControlId = browserAction.ElementId;
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = $"等待切换IFrame,切换为新的IFrame:{browserAction.SwitchToNew}";
                        break;

                    case WebActionConst.BrowserSwitchToTab:
                        sigresult = new BrowserEDA(browserAction).SwitchToTab;
                        ComArgs.ViewType.StepName = browserAction.ActionType;
                        ComArgs.ViewType.ControlId = "未使用";
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = $"切换Tab名称:{_argsIntoValue.BackNormalString(browserAction.TabName)}";
                        break;

                    case WebActionConst.BrowserTakeSnapshot:
                        sigresult = new BrowserEDA(browserAction).TakeSnapshot;
                        ComArgs.ViewType.StepName = browserAction.ActionType;
                        ComArgs.ViewType.ControlId = "未使用";
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = $"截图名称:{_argsIntoValue.BackNormalString(browserAction.ImageFile)}";
                        break;

                    case WebActionConst.MouseMove:
                        sigresult = new MouseEDA(mouseAction).Move;
                        ComArgs.ViewType.StepName = mouseAction.ActionType;
                        ComArgs.ViewType.ControlId = mouseAction.ElementId;
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = $"鼠标移动方式:{mouseAction.MouseType}";
                        break;

                    case WebActionConst.MouseClick:
                        sigresult = new MouseEDA(mouseAction).Click;
                        ComArgs.ViewType.StepName = mouseAction.ActionType;
                        ComArgs.ViewType.ControlId = mouseAction.ElementId;
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = "N/A";
                        break;

                    case WebActionConst.RoWebElementClear:
                        sigresult = new RoWebElementEDA(elementAction).Clear;
                        ComArgs.ViewType.StepName = elementAction.ActionType;
                        ComArgs.ViewType.ControlId = elementAction.ElementId;
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = "N/A";
                        break;

                    case WebActionConst.RoWebElementClick:
                        sigresult = new RoWebElementEDA(elementAction).Click;
                        ComArgs.ViewType.StepName = elementAction.ActionType;
                        ComArgs.ViewType.ControlId = elementAction.ElementId;
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = "N/A";
                        break;

                    case WebActionConst.RoWebElementFocus:
                        sigresult = new RoWebElementEDA(elementAction).Focus;
                        ComArgs.ViewType.StepName = elementAction.ActionType;
                        ComArgs.ViewType.ControlId = elementAction.ElementId;
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = "N/A";
                        break;

                    case WebActionConst.RoWebElementSelect:
                        sigresult = new RoWebElementEDA(elementAction).Select;
                        ComArgs.ViewType.StepName = elementAction.ActionType;
                        ComArgs.ViewType.ControlId = elementAction.ElementId;
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = $"下拉类型:{elementAction.SelectType},下拉选取值:{_argsIntoValue.BackNormalString(elementAction.SelectValue)}";
                        break;

                    case WebActionConst.RoWebElementSendKeys:

                        sigresult = new RoWebElementEDA(elementAction).SendKeys;
                        ComArgs.ViewType.StepName = elementAction.ActionType;
                        ComArgs.ViewType.ControlId = elementAction.ElementId;
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = $"输入值:{_argsIntoValue.BackNormalString(elementAction.SendKeys)}";
                        break;

                    case WebActionConst.ScrollDown:
                        sigresult = new ScrollEDA(scrollAction).Down;
                        ComArgs.ViewType.StepName = scrollAction.ActionType;
                        ComArgs.ViewType.ControlId = "未使用";
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = "N/A";
                        break;

                    case WebActionConst.ScrollUp:
                        sigresult = new ScrollEDA(scrollAction).Up;
                        ComArgs.ViewType.StepName = sleepAction.ActionType;
                        ComArgs.ViewType.ControlId = "未使用";
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = "N/A";
                        break;

                    case WebActionConst.Sleep:
                        sigresult = new SleepEDA(sleepAction).Sleep;
                        ComArgs.ViewType.StepName = sleepAction.ActionType;
                        ComArgs.ViewType.ControlId = "未使用";
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = $"等待时间:{sleepAction.Seconds}, 等待信息:{sleepAction.Message}";
                        break;

                    case WebActionConst.UpdateSelect:
                        sigresult = new UpdateEDA(updateAction).UpdateSelect;
                        ComArgs.ViewType.StepName = updateAction.ActionType;
                        ComArgs.ViewType.ControlId = updateAction.ElementId;
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = $"上传文件路径:{_argsIntoValue.BackNormalString(updateAction.FileValue)}";
                        break;

                    case WebActionConst.WaitUntilPageIsLoaded:
                        sigresult = new WaitUntilEDA(waitUntilAction).PageIsLoaded;
                        ComArgs.ViewType.StepName = waitUntilAction.ActionType;
                        ComArgs.ViewType.ControlId = "未使用";
                        ComArgs.ViewType.Result = sigresult ? "成功" : "失败";
                        ComArgs.ViewType.ExtraInfo = "N/A";
                        break;

                    case WebActionConst.WaitUntilAreEqual:
                        sigresult = new WaitUntilEDA(waitUntilAction).AreEqual;
                        break;

                    case WebActionConst.WaitUntilAreNotEqual:
                        sigresult = new WaitUntilEDA(waitUntilAction).AreNotEqual;
                        break;

                    case WebActionConst.WaitUntilIsFalse:
                        sigresult = new WaitUntilEDA(waitUntilAction).IsFalse;
                        break;

                    case WebActionConst.WaitUntilIsTrue:
                        sigresult = new WaitUntilEDA(waitUntilAction).IsTrue;
                        break;

                    case WebActionConst.WaitUntilStringContains:
                        sigresult = new WaitUntilEDA(waitUntilAction).StringContains;
                        break;

                    case WebActionConst.WaitUntilStringLength:
                        sigresult = new WaitUntilEDA(waitUntilAction).StringLength;
                        break;

                    case WebActionConst.MacroReference:
                        /*
                         * TODO Macro是高于各类webaction但低于TestSteps的优先级别，具有teststeps的操作逻辑
                         * TODO 因此需要在本方法中就直接处理Macro,
                         */
                        Queue<WebAction> macros = new MacroReferenceEDA(macroAction).Macro;
                        ComArgs.WebLog.WriteLog(LogStatus.LDeb, $"当前宏操作{macroAction.MacroId}提取步骤数量为:{macros.Count}");
                        List<bool> reList = new List<bool>();
                        while (macros.Any())
                        {
                            //1.单个web的操作对象
                            WebAction sig = macros.Dequeue();
                            bool res = SingleStepExec(sig); //递归方法
                            reList.Add(res);
                        }

                        if (!reList.Contains(false))
                        {
                            sigresult = true;
                        }
                        break;
                }
                ComArgs.ResultType.NowNums = ComArgs.ResultType.NowNums + 1;
                if (sigresult)
                {
                    ComArgs.WebLog.WriteLog(LogStatus.LPass, $"当前操作{webAction.ActionXElement.Name.LocalName}成功");
                    ComArgs.ResultType.SuccNums = ComArgs.ResultType.SuccNums + 1;
                }
                else
                {
                    ComArgs.WebLog.WriteLog(LogStatus.LFail, $"当前操作{webAction.ActionXElement.Name.LocalName}失败");
                    ComArgs.ResultType.FailNums = ComArgs.ResultType.FailNums + 1;
                }

                ComArgs.ResultType.Cover = (((double) ComArgs.ResultType.SuccNums / ComArgs.ResultType.NowNums) * 100).ToString("F"); //默认为保留两位
                _guiViewEvent.OnUiViewResult(ComArgs.ResultType);
                _guiViewEvent.OnUiViewSteps(ComArgs.ViewType);
                //ComArgs.WebLog.WriteLog(LogStatus.LDeb, $"{ComArgs.ResultType.NowNums},{ComArgs.ResultType.SuccNums},{ComArgs.ResultType.FailNums},{ComArgs.ResultType.Cover}");
                return sigresult;
            }
            catch (Exception e)
            {
                //添加输出
                ComArgs.RoLog.WriteLog(LogStatus.LExpt, "私有方法SingleStepExec发生异常", e.ToString());
                return false;
            }
        }

        #endregion
    }
}
