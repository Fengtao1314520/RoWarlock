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
    /// 所有的Log输出，包含log文本和UI层输出，放置到驱动底层
    /// </summary>
    public class ExecuteLogicQueue
    {
        #region 构造函数

        private readonly GuiViewEvent _guiViewEvent = new GuiViewEvent();

        /// <summary>
        /// 执行逻辑队列
        /// 构造函数
        /// </summary>
        /// <param name="testCase">单个testcase节点</param>
        public ExecuteLogicQueue(TestCase testCase)
        {
            //传入一个完整的执行逻辑队列，由解析核心传入，并使用此方法

            //TODO 1. Annotation处理, Id处理（新版本不再处理）

            //TODO 2. teststep处理
            while (testCase.TestSteps.Any())
            {
                //1.单个web的操作对象
                TestStep sig = testCase.TestSteps.Dequeue();
                SingleStepExec(sig);
            }
            
            
        }

        #endregion


        #region 私有方法

        /// <summary>
        /// 私有方法，执行一个单独的步骤，并返回对应的
        /// </summary>
        /// <param name="testStep"></param>
        /// <returns></returns>
        private bool SingleStepExec(TestStep testStep)
        {
            WebAction webAction = testStep.WebAction;
            //开始判断操作
            bool sigresult = false;
            try
            {
                MacroAction macroAction = webAction.Action as MacroAction;


                switch (webAction.ActionXElement.Name.LocalName)
                {
                    case WebActionConst.LaunchBrowser:
                        sigresult = new LaunchEDA(testStep).Launch;
                        break;

                    case WebActionConst.AlertAccept:
                        sigresult = new AlertEDA(testStep).Accept;

                        break;

                    case WebActionConst.AlertDismiss:
                        sigresult = new AlertEDA(testStep).Dismiss;

                        break;

                    case WebActionConst.AlertSendKeys:
                        sigresult = new AlertEDA(testStep).SendKeys;

                        break;

                    case WebActionConst.BrowserBack:
                        sigresult = new BrowserEDA(testStep).Back;

                        break;

                    case WebActionConst.BrowserClose:
                        sigresult = new BrowserEDA(testStep).Close;

                        break;

                    case WebActionConst.BrowserCloseTab:
                        sigresult = new BrowserEDA(testStep).CloseTab;


                        break;

                    case WebActionConst.BrowserExecuteScript:
                        sigresult = new BrowserEDA(testStep).ExecuteScript;

                        break;

                    case WebActionConst.BrowserForward:
                        sigresult = new BrowserEDA(testStep).Forward;

                        break;

                    case WebActionConst.BrowserGoToUrl:
                        sigresult = new BrowserEDA(testStep).GoToUrl;

                        break;

                    case WebActionConst.BrowserRefresh:
                        sigresult = new BrowserEDA(testStep).Refresh;

                        break;

                    case WebActionConst.BrowserStop:
                        sigresult = new BrowserEDA(testStep).Stop;

                        break;

                    case WebActionConst.BrowserSwitchFrame:
                        sigresult = new BrowserEDA(testStep).SwitchFrame;

                        break;

                    case WebActionConst.BrowserSwitchToTab:
                        sigresult = new BrowserEDA(testStep).SwitchToTab;

                        break;

                    case WebActionConst.BrowserTakeSnapshot:
                        sigresult = new BrowserEDA(testStep).TakeSnapshot;

                        break;

                    case WebActionConst.MouseMove:
                        sigresult = new MouseEDA(testStep).Move;

                        break;

                    case WebActionConst.MouseClick:
                        sigresult = new MouseEDA(testStep).Click;

                        break;

                    case WebActionConst.RoWebElementClear:
                        sigresult = new RoWebElementEDA(testStep).Clear;

                        break;

                    case WebActionConst.RoWebElementClick:
                        sigresult = new RoWebElementEDA(testStep).Click;

                        break;

                    case WebActionConst.RoWebElementFocus:
                        sigresult = new RoWebElementEDA(testStep).Focus;

                        break;

                    case WebActionConst.RoWebElementSelect:
                        sigresult = new RoWebElementEDA(testStep).Select;

                        break;

                    case WebActionConst.RoWebElementSendKeys:

                        sigresult = new RoWebElementEDA(testStep).SendKeys;

                        break;

                    case WebActionConst.ScrollDown:
                        sigresult = new ScrollEDA(testStep).Down;

                        break;

                    case WebActionConst.ScrollUp:
                        sigresult = new ScrollEDA(testStep).Up;

                        break;

                    case WebActionConst.Sleep:
                        sigresult = new SleepEDA(testStep).Sleep;

                        break;

                    case WebActionConst.UpdateSelect:
                        sigresult = new UpdateEDA(testStep).UpdateSelect;

                        break;

                    case WebActionConst.WaitUntilPageIsLoaded:
                        sigresult = new WaitUntilEDA(testStep).PageIsLoaded;

                        break;

                    case WebActionConst.WaitUntilAreEqual:
                        sigresult = new WaitUntilEDA(testStep).AreEqual;
                        break;

                    case WebActionConst.WaitUntilAreNotEqual:
                        sigresult = new WaitUntilEDA(testStep).AreNotEqual;
                        break;

                    case WebActionConst.WaitUntilIsFalse:
                        sigresult = new WaitUntilEDA(testStep).IsFalse;
                        break;

                    case WebActionConst.WaitUntilIsTrue:
                        sigresult = new WaitUntilEDA(testStep).IsTrue;
                        break;

                    case WebActionConst.WaitUntilStringContains:
                        sigresult = new WaitUntilEDA(testStep).StringContains;
                        break;

                    case WebActionConst.WaitUntilStringLength:
                        sigresult = new WaitUntilEDA(testStep).StringLength;
                        break;

                    case WebActionConst.MacroReference:
                        /*
                         * TODO Macro是高于各类webaction但低于TestSteps的优先级别，具有teststeps的操作逻辑
                         * TODO 因此需要在本方法中就直接处理Macro,
                         */
                        Queue<TestStep> macros = new MacroReferenceEDA(macroAction).Macro;
                        ComArgs.RoLog.WriteLog(LogStatus.LDeb, $"当前宏操作{macroAction?.MacroId}提取步骤数量为:{macros.Count}");
                        List<bool> reList = new List<bool>();
                        //此处有一个幽灵Bug,当macros被反馈后，如果使用队列的正常方法，字典中的值会直接被清空!!!
                        foreach (TestStep oneTestStep in macros)
                        {
                            bool res = SingleStepExec(oneTestStep); //递归方法
                            reList.Add(res);
                        }

                        if (!reList.Contains(false))
                        {
                            sigresult = true;
                        }

                        break;
                }

                return sigresult;
            }
            catch (Exception e)
            {
                //添加输出
                ComArgs.RoLog.WriteLog(LogStatus.LExpt, "私有方法SingleStepExec发生异常", e.ToString());
                return false;
            }
            finally
            {
                ComArgs.ResultType.NowNums = ComArgs.ResultType.NowNums + 1;

                if (sigresult)
                {
                    ComArgs.ResultType.SuccNums = ComArgs.ResultType.SuccNums + 1;
                }
                else
                {
                    ComArgs.ResultType.FailNums = ComArgs.ResultType.FailNums + 1;
                }

                ComArgs.ResultType.Cover = (((double) ComArgs.ResultType.SuccNums / ComArgs.ResultType.NowNums) * 100).ToString("F"); //默认为保留两位
                _guiViewEvent.OnUiViewResult(ComArgs.ResultType);
            }
        }

        #endregion
    }
}
