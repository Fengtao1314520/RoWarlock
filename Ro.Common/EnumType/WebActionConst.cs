namespace Ro.Common.EnumType
{
    /// <summary>
    /// 结构体
    /// Web所有操作的强制固定头
    /// XElement.Name.LocalName
    /// </summary>
    public struct WebActionConst
    {
        public const string LaunchBrowser = "Launch.Browser";

        public const string AlertAccept = "Alert.Accept";
        public const string AlertDismiss = "Alert.Dismiss";
        public const string AlertSendKeys = "Alert.SendKeys";

        public const string BrowserBack = "Browser.Back";
        public const string BrowserClose = "Browser.Close";
        public const string BrowserCloseTab = "Browser.CloseTab";
        public const string BrowserExecuteScript = "Browser.ExecuteScript";
        public const string BrowserForward = "Browser.Forward";
        public const string BrowserGoToUrl = "Browser.GoToUrl";
        public const string BrowserRefresh = "Browser.Refresh";
        public const string BrowserStop = "Browser.Stop";
        public const string BrowserSwitchFrame = "Browser.SwitchFrame";
        public const string BrowserSwitchToTab = "Browser.SwitchToTab";
        public const string BrowserTakeSnapshot = "Browser.TakeSnapshot";

        public const string MouseMove = "Mouse.Move";
        public const string MouseClick = "Mouse.Click";

        public const string RoWebElementClear = "RoWebElement.Clear";
        public const string RoWebElementClick = "RoWebElement.Click";
        public const string RoWebElementFocus = "RoWebElement.Focus";
        public const string RoWebElementSelect = "RoWebElement.Select";
        public const string RoWebElementSendKeys = "RoWebElement.SendKeys";

        public const string ScrollDown = "Scroll.Down";
        public const string ScrollUp = "Scroll.Up";

        public const string Sleep = "Sleep";

        public const string UpdateSelect = "Update.Select";

        public const string WaitUntilPageIsLoaded = "WaitUntil.PageIsLoaded";
        public const string WaitUntilAreEqual = "WaitUntil.AreEqual";
        public const string WaitUntilAreNotEqual = "WaitUntil.AreNotEqual";
        public const string WaitUntilIsFalse = "WaitUntil.IsFalse";
        public const string WaitUntilIsTrue = "WaitUntil.IsTrue";
        public const string WaitUntilStringContains = "WaitUntil.StringContains";
        public const string WaitUntilStringLength = "WaitUntil.StringLength";
        public const string MacroReference = "MacroReference";
    }
}