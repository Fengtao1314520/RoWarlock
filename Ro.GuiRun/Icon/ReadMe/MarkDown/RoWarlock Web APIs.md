Scripts For Web APIs
===

# web:Launch.Browser
- **说明**
启动浏览器
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:Timeout  | AttributeValue |可为空|  int值|超时配置    |
|  web:Url  | AttributeValue |不可为空| text值 |网址    |
|  web:BrowserType  | AttributeValue |不可为空| text值 |浏览器类型    |
|  web:Run64Bit  | AttributeValue |不可为空| true/false |否为为64位    |
----------

- **使用示例**

```
<web:Launch.Browser ros:TreatErrorsAsWarnings="true" web:BrowserType="Chrome" web:Run64Bit="true" web:Timeout="30" web:Url="" ros:Explain="设定浏览器,和进入网址" />
```
***


# web:Alert.Accept
- **说明**
Alert弹框，点击确认
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:Timeout  | AttributeValue |可为空|  int值|超时配置    |


----------

- **使用示例**

```
<web:Alert.Accept ros:TreatErrorsAsWarnings="true" web:Timeout="30" ros:Explain="弹窗确定"/>
```
***


# web:Alert.Dismiss
- **说明**
Alert弹框，点击取消
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:Timeout  | AttributeValue |可为空|  int值|超时配置    |


----------

- **使用示例**

```
<web:Alert.Dismiss ros:TreatErrorsAsWarnings="true" web:Timeout="30" ros:Explain="弹窗取消"/>
```
***


# web:Alert.SendKeys
- **说明**
Alert弹框，输入字符
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:Timeout  | AttributeValue |可为空|  int值|超时配置    |
|  web:Value  | ChildNode & InnerText | 不可为空|  text值| 输入字符串信息    |

----------

- **使用示例**

```
<web:Alert.SendKeys ros:TreatErrorsAsWarnings="true" web:Timeout="30" ros:Explain="弹窗输入文本">
  <web:Value></web:Value>
</web:Alert.SendKeys>

```
***


# web:Browser.Back
- **说明**
浏览器返回前一个页面
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:Timeout  | AttributeValue |可为空|  int值|超时配置    |

----------

- **使用示例**

```
<web:Browser.Back ros:TreatErrorsAsWarnings="true" web:Timeout="30" ros:Explain="浏览器退后"/>
```
***


# web:Browser.Close
- **说明**
浏览器关闭
如无特殊情况，禁止使用
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:Timeout  | AttributeValue |可为空|  int值|超时配置    |

----------

- **使用示例**

```
<web:Browser.Close ros:TreatErrorsAsWarnings="true" web:Timeout="30" ros:Explain="浏览器关闭"/>
```
***


# web:Browser.CloseTab
- **说明**
浏览器关闭一个标签页
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:Timeout  | AttributeValue |可为空|  int值|超时配置    |

----------

- **使用示例**

```
<web:Browser.CloseTab ros:TreatErrorsAsWarnings="true" web:Timeout="30" ros:Explain="浏览器当前tab关闭"/>
```
***


# web:Browser.ExecuteScript
- **说明**
浏览器执行一段JavaScript代码
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:Timeout  | AttributeValue |可为空|  int值|超时配置    |
|  eb:JavaScript  | ChildNode & InnerText |不可为空|  JavaScript 代码|Js代码输入 |
----------

- **使用示例**

```
<web:Browser.ExecuteScript ros:TreatErrorsAsWarnings="true" web:Timeout="30" ros:Explain="浏览器执行JS脚本">
  <web:JavaScript></web:JavaScript>
</web:Browser.ExecuteScript>
```
***

# web:Browser.Forward
- **说明**
浏览器向前操作
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:Timeout  | AttributeValue |可为空|  int值|超时配置    |

----------

- **使用示例**

```
<web:Browser.Forward ros:TreatErrorsAsWarnings="true" web:Timeout="30" ros:Explain="浏览器前进"/>
```
***

# web:Browser.GoToUrl
- **说明**
浏览器重新打开一个网址
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:Timeout  | AttributeValue |可为空|  int值|超时配置    |
|  web:AutoStopLoad  | AttributeValue |不可为空|  true/false|是否自动停止刷新    |
|  web:Url  | AttributeValue |不可为空|  text值|url网址    |
----------

- **使用示例**

```
<web:Browser.GoToUrl ros:TreatErrorsAsWarnings="true" web:AutoStopLoad="true" web:Timeout="30" web:Url="" ros:Explain="浏览器千万某个网址"/>
```
***


# web:Browser.Refresh
- **说明**
浏览器刷新页面
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:Timeout  | AttributeValue |可为空|  int值|超时配置    |
|  web:AutoStopLoad  | AttributeValue |不可为空|  true/false|是否自动停止刷新    |

----------

- **使用示例**

```
<web:Browser.Refresh ros:TreatErrorsAsWarnings="true" web:AutoStopLoad="true" web:Timeout="30" ros:Explain="浏览器刷新"/>
```
***

# web:Browser.Stop
- **说明**
浏览器停止刷新
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:Timeout  | AttributeValue |可为空|  int值|超时配置    |


----------

- **使用示例**

```
<web:Browser.Stop ros:TreatErrorsAsWarnings="true" web:Timeout="30" ros:Explain="浏览器停止"/>
```
***


# web:Browser.SwitchFrame
- **说明**
浏览器切换IFrame控件
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:Timeout  | AttributeValue |可为空|  int值|超时配置    |
|  web:RoWebElementID  | AttributeValue |不可为空|  Control值|IFrame控件    |
|  web:SwitchToNew  | AttributeValue |不可为空|  true/false |是否切换至新的    |
----------

- **使用示例**

```
<web:Browser.SwitchFrame ros:TreatErrorsAsWarnings="true" web:RoWebElementID="" web:SwitchToNew="true" web:Timeout="30" ros:Explain="浏览器切换IFrame"/>
```
***

# web:Browser.SwitchToTab
- **说明**
浏览器切换Tab标签
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:Timeout  | AttributeValue |可为空|  int值|超时配置    |
|  web:TabName  |  AttributeValue|不可为空|  text值|tab的title名称    |
----------

- **使用示例**

```
<web:Browser.SwitchToTab ros:TreatErrorsAsWarnings="true" web:Timeout="30" web:TabName="" ros:Explain="浏览器切换tab"/>
```
***


# web:Browser.TakeSnapshot
- **说明**
浏览器截图
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:ImageFile  | ChildNode & InnerText |不可为空|  NA| 截图文件保存路径    |
----------

- **使用示例**

```
<web:Browser.TakeSnapshot ros:TreatErrorsAsWarnings="true" ros:Explain="浏览器截图">
          <web:ImageFile></web:ImageFile>
        </web:Browser.TakeSnapshot>
```
***

# web:Mouse.Move
- **说明**
鼠标移动操作
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:Timeout  | AttributeValue |可为空|  int值|超时配置    |
|  web:RoWebElementID  | AttributeValue |不可为空|  Control值| 需要移动到的控件    |
----------

- **使用示例**

```
<web:Mouse.Move ros:TreatErrorsAsWarnings="true" web:RoWebElementID="" web:Timeout="30" ros:Explain="鼠标移动"/>
```
***


# web:RoWebElement.Clear
- **说明**
清理Text属性
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:Timeout  | AttributeValue |可为空|  int值|超时配置    |
|  web:RoWebElementID  | AttributeValue |不可为空|  Control值| 清理Text的控件    |
----------

- **使用示例**

```
<web:RoWebElement.Clear ros:TreatErrorsAsWarnings="true" web:RoWebElementID="" web:Timeout="30" />
```
***


# web:RoWebElement.Click
- **说明**
控件点击操作
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:Timeout  | AttributeValue |可为空|  int值|超时配置    |
|  web:RoWebElementID  | AttributeValue |不可为空|  Control值| 需要点击的控件    |
|  web:MouseType  | AttributeValue |不可为空|  ClickLeft/ClickRight/DoubleLeft/DoubleRight | 需要点击的控件    |
----------

- **使用示例**

```
<web:Mouse.Click ros:TreatErrorsAsWarnings="true" web:RoWebElementID="" web:Timeout="30" web:MouseType="ClickLeft" ros:Explain="鼠标点击"/>
```
***



# web:RoWebElement.Select
- **说明**
下拉框选择操作
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:Timeout  | AttributeValue |可为空|  int值|超时配置    |
|  web:RoWebElementID  | AttributeValue |不可为空|  Control值| 下拉框控件    |
|  web:SelectType  | AttributeValue |不可为空|  ByIndex/ByValue/ByText| 选择类型    |
|  web:Value  | ChildNode & InnerText |不可为空|  text值| 下拉值    |
----------

- **使用示例**

```
<web:RoWebElement.Select ros:TreatErrorsAsWarnings="true" web:RoWebElementID="" web:SelectType="ByIndex" web:Timeout="30" ros:Explain="当前控件下拉选择">
  <web:Value></web:Value>
</web:RoWebElement.Select>
```
***


# web:RoWebElement.SendKeys
- **说明**
控件输入操作
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:Timeout  | AttributeValue |可为空|  int值|超时配置    |
|  web:RoWebElementID  | AttributeValue |不可为空|  Control值| 需要输出操作的控件    |
|  web:ClearFirst | AttributeValue |不可为空|  true/false| 是否优先清楚    |
|  web:Value  | ChildNode & InnerText |不可为空|  Text值| 输入值    |
----------

- **使用示例**

```
<web:RoWebElement.SendKeys ros:TreatErrorsAsWarnings="true" web:ClearFirst="true" web:RoWebElementID="" web:Timeout="30" ros:Explain="当前控件输入文本">
  <web:Value></web:Value>
</web:RoWebElement.SendKeys>
```
***


# web:Scroll.Down
- **说明**
滚动操作向下
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |

----------

- **使用示例**

```
<web:Scroll.Down ros:TreatErrorsAsWarnings="true" ros:Explain="向下滚动" />
```
***


# web:Scroll.Up
- **说明**
滚动操作向上
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |

----------

- **使用示例**

```
<web:Scroll.Up ros:TreatErrorsAsWarnings="true" ros:Explain="向上滚动" />
```
***


# web:Sleep
- **说明**
程序强制等待
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  ros:Message  | AttributeValue |可为空| true/false | 等待时输出信息    |
|  ros:Seconds  | AttributeValue |可为空| true/false | 等待时间    |

----------

- **使用示例**

```
<web:Sleep ros:TreatErrorsAsWarnings="true" web:Message="" web:Seconds="30" ros:Explain="工具强制等待"/>
```
***


# web:Update.Select
- **说明**
上传文件操作
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:Timeout  | AttributeValue |可为空|  int值|超时配置    |
|  web:RoWebElementID  | AttributeValue |不可为空|  Control值| 上传控件    |
|  web:FileValue | ChildNode & InnerText |不可为空|  text值| 上传文件路径    |
----------

- **使用示例**

```
<web:Update.Select ros:TreatErrorsAsWarnings="true" web:RoWebElementID="" web:Timeout="30" ros:Explain="选择文件">
  <web:FileValue></web:FileValue>
</web:Update.Select>
```
***


# web:WaitUntil.PageIsLoaded
- **说明**
等待页面读取完成
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:Timeout  | AttributeValue |可为空|  int值|超时配置    |
----------

- **使用示例**

```
<web:WaitUntil.PageIsLoaded ros:TreatErrorsAsWarnings="true" web:Timeout="30" ros:Explain="等待页面载入完成"/>
```
***

# web:WaitUntil.AreEqual
- **说明**
验证是否相同
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:Timeout  | AttributeValue |可为空|  int值|超时配置    |
|  web:IgnoreCase  | AttributeValue |不可为空|  true/false |是否更改大小写    |
|  web:WaitInfo  | ChildNode |可为空|  NA|验证信息    |

----------

- **使用示例**

```
<web:WaitUntil.AreEqual ros:TreatErrorsAsWarnings="true" web:IgnoreCase="true" web:Timeout="5" ros:Explain="验证是否为真">
  <web:WaitInfo web:ExpectedValue="" web:ActualType="Browser.Title" web:RoWebElementID="" web:Name="" />
  <web:WaitInfo web:ExpectedValue="" web:ActualType="Browser.Title" web:RoWebElementID="" web:Name="" />
</web:WaitUntil.AreEqual>
```
***

# web:WaitUntil.AreNotEqual
- **说明**
验证是否不等
- **请求参数**

| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:Timeout  | AttributeValue |可为空|  int值|超时配置    |
|  web:IgnoreCase  | AttributeValue |不可为空|  true/false |是否更改大小写    |
|  web:WaitInfo  | ChildNode |可为空|  NA|验证信息    |

----------

- **使用示例**

```
<web:WaitUntil.AreNotEqual ros:TreatErrorsAsWarnings="true" web:IgnoreCase="true" web:Timeout="5" ros:Explain="验证是否为真">
  <web:WaitInfo web:ExpectedValue="" web:ActualType="Browser.Title" web:RoWebElementID="" web:Name="" />
  <web:WaitInfo web:ExpectedValue="" web:ActualType="Browser.Title" web:RoWebElementID="" web:Name="" />
</web:WaitUntil.AreNotEqual>
```
***

## web:WaitInfo
- **说明**
` web:WaitUntil.AreEqual`/ `web:WaitUntil.AreNotEqual`中的实际值
- **请求参数**
| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:ExpectedValue  | AttributeValue |可为空| true/false | 预期值    |
|  web:ActualType  | AttributeValue |可为空|  int值|实际值    |
|  web:RoWebElementID  | AttributeValue |不可为空|  Control值| 使用控件    |
|  web:Timeout  | ChildNode |可为空|  NA|等待时间    |
|  web:Name  | ChildNode |可为空|  NA|GetAttribute 专用，填写target值    |
----------
- **使用示例**
```
<web:WaitInfo web:ExpectedValue="" web:ActualType="Browser.Title" web:RoWebElementID="" web:Name="" />
```
***

# web:WaitUntil.IsTrue
- **说明**
验证是否为真
- **请求参数**
| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:Timeout  | AttributeValue |可为空|  int值|超时配置    |
|  web:ActualValue  | ChildNode    |可为空|  NA|实际值    |
----------
- **使用示例**
```
<web:WaitUntil.IsTrue ros:TreatErrorsAsWarnings="true" web:Timeout="5" ros:Explain="验证是否为True">
  <web:ActualValue web:ActualType="RoWebElement.Displayed" web:RoWebElementID=""></web:ActualValue>
</web:WaitUntil.IsTrue>
```
***

# web:WaitUntil.IsFalse
- **说明**
验证是否为假
- **请求参数**
| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:Timeout  | AttributeValue |可为空|  int值|超时配置    |
|  web:ActualValue  | ChildNode    |可为空|  NA|实际值    |
----------
- **使用示例**
```
<web:WaitUntil.IsFalse ros:TreatErrorsAsWarnings="true" web:Timeout="5" ros:Explain="验证是否为False">
  <web:ActualValue web:ActualType="RoWebElement.Displayed" web:RoWebElementID=""></web:ActualValue>
</web:WaitUntil.IsFalse>
```
***

## web:ActualValue
- **说明**
` web:WaitUntil.IsTrue`/ `web:WaitUntil.IsFalse`中的实际值
- **请求参数**
| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |------- |----------
|  web:ActualType  | AttributeValue |可为空|  int值|实际值    |
|  web:RoWebElementID  | AttributeValue |不可为空|  Control值| 使用控件    |
----------
- **使用示例**
```
<web:ActualValue web:ActualType="RoWebElement.Displayed" web:RoWebElementID=""></web:ActualValue>
```
***

### ActualType类型(AreEqual/AreNotEqual使用前4个，IsTrue/IsFalse使用后面4个)
  *  RoWebElement.Text
  *  RoWebElement.GetAttribute
  *  Browser.Title
  *  Browser.Url
  *  Browser.IsPageLoaded
  *  RoWebElement.Displayed
  *  RoWebElement.Enabled
  *  RoWebElement.Selected
***

# ros:MacroReference
- **说明**
验证是否为假
- **请求参数**
| 请求参数|  参数类型  |  是否必填| 输入值|参数含义 |
| --------  | -----  | ----  |-------  |-------  |
|  ros:TreatErrorsAsWarnings  | AttributeValue |可为空| true/false | 是否将错误更改为警告    |
|  web:Timeout  | AttributeValue |可为空|  int值|超时配置    |
|  ros:MacroID  | ChildNode    |不可为空|  text值 |填写macro的id  |
----------
- **使用示例**
```
<ros:MacroReference ros:MacroID="ABC.abc" ros:TreatErrorsAsWarnings="true" ros:Explain="使用宏"/>
```
***

