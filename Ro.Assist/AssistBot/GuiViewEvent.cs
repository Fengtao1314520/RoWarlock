using Ro.Common.UserType.GuiType;

namespace Ro.Assist.AssistBot
{
    /// <summary>
    /// Gui的显示事件、委托和其他
    /// </summary>
    public class GuiViewEvent
    {
        /// <summary>
        /// 委托
        /// 显示步骤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="item">UViewType</param>
        public delegate void ViewSteps(object sender, UViewType item);


        /// <summary>
        /// 委托
        /// 显示结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="item">UResultType</param>
        public delegate void ViewResult(object sender, UResultType item);


        /// <summary>
        /// 事件
        /// 显示步骤
        /// </summary>
        public static event ViewSteps UiViewSteps;


        /// <summary>
        /// 事件
        /// 显示结果
        /// </summary>
        public static event ViewResult UiViewResult;

        /// <summary>
        /// 事件具体
        /// 显示步骤
        /// </summary>
        /// <param name="item">UViewType</param>
        public  void OnUiViewSteps(UViewType item)
        {
            UiViewSteps?.Invoke(null, item);
        }


        /// <summary>
        /// 事件具体
        /// 显示结果
        /// </summary>
        /// <param name="item">UResultType</param>
        public  void OnUiViewResult(UResultType item)
        {
            UiViewResult?.Invoke(null, item);
        }
    }
}
