# RoWarlock User Guide

RoWarlock is an Automation tool base on UI, Using Selenium(Web), MSUIAutomation(Client), Appium(Mobile) as the event-driven.

[RoWarlock](https://github.com/Fengtao1314520/RoWarlock)
[RoWarlock Test Scripts Tool](https://github.com/Fengtao1314520/RoWarlock-Test-Scripts-Tool)

## 1. Construction

RoWarlock has two constructions, "RoWarlock" and "RoWarlock Test Scripts Tool". The "RoWarlock" is the script execution tool, and other one is the test scripts tool.
Because RoWarlock use some WindowsForms APIs and developed by Visual Studio. Now, RoWarlock only support Microsoft Windows OS.

### 1.1 Update version Infomation
* 2017-03-28： Complete the development of EAP version
* 2017-04-01： Complete the test of EAP version
* 2017-05-24： Complete the development of V1.1 version. Support command line and GUI.
* 2017-11-07： Complete the development of V1.5 version. Refactoring the entire project.Delete command line and only saved GUI.

### 1.2 Environment configuration
* Installed .Net 4.5 On windows OS(better than Windows XP)
* please copy this text "C:\Browser" on your Environment Path
  ![Like this](https://github.com/Fengtao1314520/RoWarlock/raw/master/Ro.GuiRun/Icon/ReadMe/Images/envpath.png)
* Please update Chrome to lastest version. RoWarlock only support Chrome v60-62

## 2. How to use the tool

If you have created and writed test scripts, just open RoWarlock and select test scripts documents, click "run", the tool will execute the selected scripts on automatic. Please see the image.
  ![1.select scripts dolder](https://github.com/Fengtao1314520/RoWarlock/raw/master/Ro.GuiRun/Icon/ReadMe/Images/1select.png)
  
  (1) Select scripts folder
  1. click button and show select dialog.
  2. select one folder that include "ros","roi","roc" files's folder.
  3. click "ok" button  and exit dialog.
  ---
  
  ![2.select run scripts](https://github.com/Fengtao1314520/RoWarlock/raw/master/Ro.GuiRun/Icon/ReadMe/Images/2run.png)
  
  (2) Select run scripts
  1. on the listview, you can select that you want to run scirtps.
  2. click run button after selected done.
  3. wait the result.
  ---
  
On the tool's UI, you can see the details for every test script step, the pass step using Green backcolor, and the failed step is Red.
  
## 3. Result and log files
  
RoWarlock support two types log, The one is Web action log, the other one is the tools log
   
### 3.1 Web action log

Web action log will record all web steps result. just like this:
    
```
    操作时间:2017-11-13 15:51:13
    操作结果:PASS
    Case名称:BeforeLogin   行号:21   操作名称:WaitUntil.PageIsLoaded   使用控件:未使用  执行结果:成功
    其他信息:当前页面已载入完成
```
    
The fist line is time record. The second line is test result. The third line will record case name, use script step code line number, control id. the fourth line is other infomation, if this step will failed, it will recorded on the fourth line. If this step encounters an exception, it will record more infomation that include exception message, StackTrace and so on...

### 3.2 Tools log

Tools log will record RoWarlock tools. if tool encounters an exception, it will record it, also ,it will record some debug infomations for developer.
    
``` 
2017-11-13 14:51:21 INFO 脚本执行工具正式开始工作...
2017-11-13 15:50:29 INFO 脚本执行工具准备开始执行脚本...
2017-11-13 15:50:29 INFO 脚本执行工具执行GuiCore方法...
2017-11-13 15:50:29 INFO 脚本执行工具载入MacroUnit.roc配置文件...
2017-11-13 15:50:29 INFO 脚本执行工具载入PropertiesUnit.roc配置文件...
2017-11-13 15:50:29 INFO 当前参数字典共计 40 个数据...
2017-11-13 15:50:29 INFO 当前宏字典共计 7 个数据...
2017-11-13 15:50:29 INFO ElementEntrance中当前处理的路径为:
2017-11-13 15:50:29 INFO ElementEntrance中当前处理的路径为:
2017-11-13 15:50:29 INFO ElementEntrance中当前处理的路径为:
2017-11-13 15:50:29 INFO ElementEntrance中当前处理的路径为:
2017-11-13 15:50:29 INFO 当前元素字典共计 162 个数据...
2017-11-13 15:50:32 INFO WEB测试日志将写入WebAction_Dev.log中，具体详情，请查看WebAction_Dev.log日志
2017-11-13 15:50:33 DEBUG 当前宏操作BeforeLogin提取步骤数量为:8
2017-11-13 15:50:33 INFO 准备开启ChromeDriver服务，浏览器
2017-11-13 15:50:34 INFO 准备替换的参数为:LocalUrl, 替换值为:http://127.0.0.1:8090/
2017-11-13 15:50:34 DEBUG 当前的CurrentWindowHandle是:CDwindow-a516c8ab-171b-403b-a7f9-74467194e3e8
2017-11-13 15:50:34 INFO 准备替换的参数为:LoginName, 替换值为:admin
2017-11-13 15:50:35 INFO 准备替换的参数为:Password, 替换值为:admin
2017-11-13 15:50:39 DEBUG 当前宏操作CreateScale_First提取步骤数量为:8
2017-11-13 15:50:40 INFO 准备替换的参数为:IpAdd_1, 替换值为:172.30.218.1
2017-11-13 15:50:47 DEBUG 当前宏操作CreateScale_Second提取步骤数量为:8
2017-11-13 15:50:47 INFO 准备替换的参数为:IpAdd_2, 替换值为:172.30.18.2
2017-11-13 15:50:52 DEBUG 当前宏操作CreateScale_Unuse提取步骤数量为:7
2017-11-13 15:50:52 INFO 准备替换的参数为:IpAdd_3, 替换值为:172.30.218.3
2017-11-13 15:50:57 DEBUG 当前宏操作DeleteAllScale提取步骤数量为:5
2017-11-13 15:51:03 INFO 准备关闭浏览器、服务和释放资源
```

## 4 Write test scripts

If the tester need write one tet script,  he or she need use "RoWarlock Test Scripts Tool". It's a [visual studio](https://www.visualstudio.com/) solution. if you want open it, you need a [visual studio or better](https://www.visualstudio.com/) . Somettimes, you can also use [visual studio code](https://code.visualstudio.com/) to open it, but it not have Intelligent.

Ros file is the script logic file. every step is an actual action on the web.
Roc file is the config file, all properties and all macros on this file. also, it will inculde others.
Roi file is the element-set file, it inculdes a lots element for one web page.

Open solution by visual studio, and you can see this layered

+ Sample          --- three files samples
  - Json          --- tool will support json language on the 2.0 version.
  - Ro            --- version 1.5 uesed.inculde three files about "ros", "roc", "roi"
+ Schemas         --- define XML format
  - 脚本           --- define XML format for "ros", "roc", "roi" scripts
  - other files   --- define XML format for others


### 4.1 Ros file (Ro-scripts file)

1. create xml file and change suffix name to the "ros".
2. copy this text

```
<?xml version="1.0" encoding="utf-8"?>

<ros:TestDefinition xmlns:ros="http://tempuri.org/RoFramework.xsd"
                    xmlns:web="http://tempuri.org/RoWebAutomation.xsd"
                    xmlns:xs="http://www.w3.org/2001/XMLSchema"
                    xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <ros:Annotation>
    <ros:Description>
    
    (Don't delete this text)
      版权、著作权归属冯涛所有
      基于Apache-2.0开源协议，授权给其他人员使用。如需修改Ros文件对应框架文件，需在被修改文件中，对本著作权人进行描述和引申
      Author: 冯涛
      E-mail: fengtao.1314520@163.com
      Skype/MSN: fengtao.1314520@hotmail.com
      Gmail: fengtao.1314520@gmail.com
  
    </ros:Description>
    <ros:Created ros:Author="nate" ros:Date="2017-08-16" />
    <ros:LastUpdated ros:Author="nate" ros:Date="2017-08-16" />
  </ros:Annotation>


  <ros:TestConfig>
  
    <ros:Properties>
      <ros:Property ros:ID="Username">
        <ros:Value>admin</ros:Value>
        <ros:Description></ros:Description>
      </ros:Property>
    </ros:Properties>

    <ros:Imports>
      <ros:ConfigurationFile ros:ID="A" ros:Type="RoWeb">
        <ros:Path>${PropertyID 1}\${PropertyID 2}\filename.roi</ros:Path>
      </ros:ConfigurationFile>
      <ros:ConfigurationFile ros:ID="C" ros:Type="RoMobile">
        <ros:Path>filename.roi</ros:Path>
      </ros:ConfigurationFile>
      <ros:ConfigurationFile ros:ID="C" ros:Type="RoMobile">
        <ros:Path>foldername/filename.roi</ros:Path>
      </ros:ConfigurationFile>
    </ros:Imports>

  </ros:TestConfig>


  <ros:StartApp>
    <ros:AppInfo ros:AppName="Chrome">
      <ros:ExecuePath>C://Browser</ros:ExecuePath>
      <ros:BaseWindowsBits ros:Bits="32Bits" />
      <ros:Version></ros:Version>
      <ros:Parameters>
        <ros:Parameter />
      </ros:Parameters>
    </ros:AppInfo>
  </ros:StartApp>

  
  <ros:Tests>
    <ros:TestCase ros:ID="WebControl">
      <ros:Annotation>
        <ros:Description>
          对本测试用例进行描述
        </ros:Description>
        <ros:Created ros:Author="fengtao" ros:Date="2016-01-22" />
        <ros:LastUpdated ros:Author="fengtao" ros:Date="2016-01-22" />
      </ros:Annotation>
      <ros:TestSteps>
      </ros:TestSteps>
    </ros:TestCase>
  </ros:Tests>


  <ros:CloseApp ros:Keep="true" />


  <ros:LogFunction>
    <ros:LogFilePath></ros:LogFilePath>
  </ros:LogFunction>


</ros:TestDefinition>
```

3. fill in the corresponding information

#### 4.1.1 Single element node explanation

Explain the roles and uses of each node. 
Script file includes 7 nodes, and the "ros:TestDefinition" is root node, the starting and ending node of the "ros" script. other 6 nodes inclued on "ros:TestDefinition" node.

The Rowarlock scripts APIs file is here,[RoWarlock APIs](https://github.com/Fengtao1314520/RoWarlock/blob/master/Ro.GuiRun/Icon/ReadMe/MarkDown/RoWarlock%20APIs.md), you can download file and see it.

#### 4.1.2 <span id="Annotation">Annotation</span>

Explain the role of the script and used test case like this:
```
<ros:Annotation>
    <ros:Description>
      版权、著作权归属冯涛所有
      基于Apache-2.0开源协议，授权给其他人员使用。如需修改Ros文件对应框架文件，需在被修改文件中，对本著作权人进行描述和引申
      Author: 冯涛
      E-mail: fengtao.1314520@163.com
      Skype/MSN: fengtao.1314520@hotmail.com
      Gmail: fengtao.1314520@gmail.com
    </ros:Description>
    <ros:Created ros:Author="nate" ros:Date="2017-08-16" />
    <ros:LastUpdated ros:Author="nate" ros:Date="2017-08-16" />
  </ros:Annotation>
```
You need modify the text between `ros:Description`, and there is the a standard user information,including user, Open-Source license, contact information and other useful information. 
After completed `ros:Description`,you also modify `ros:Author` and `ros:Date`. this text only support this type `xxxx-xx-xx`.

#### 4.1.3 <span id="TestConfig">TestConfig</span>

Set test properties and import "roi" files.

##### 4.1.3.1 <span id="Property">Property</span>

On node `ros:Properties`, saved properties that script need used. you can create a considerable number of properties. One property need this type:
```
 <ros:Property ros:ID="">
        <ros:Value>admin</ros:Value>
        <ros:Description></ros:Description>
      </ros:Property>
    </ros:Properties>
```
you need modify ID's value  for `ros:ID`, this ID is unique, then fill in the value on `ros:Value` and description of this property on `ros:Description`.

##### 4.1.3.2 <span id="ConfigurationFile">ConfigurationFile</span>

On node `ros:Imports`, saved "roi" files path that this script used. One import need this type:
```
<ros:ConfigurationFile ros:ID="" ros:Type="RoWeb">
        <ros:Path></ros:Path>
      </ros:ConfigurationFile>
```
you need modify ID's value  for `ros:ID`, this ID is unique, then fill in the value on `ros:Path`. `ros:Path` support parameterization,like this:`${PropertyID 1}\${PropertyID 2}\filename.roi`. in fact, `ros:Path` support three wording. (1) only roi file name `<ros:Path>filename.roi</ros:Path>`. (2) foldername and file name `<ros:Path>foldername/filename.roi</ros:Path>`.


#### 4.1.4 StartApp

set browser infomation, include browser name, unzip folder path and others. like this type:
```
 <ros:AppInfo ros:AppName="Chrome">
      <ros:ExecuePath>C://Browser</ros:ExecuePath>
      <ros:BaseWindowsBits ros:Bits="32Bits" />
      <ros:Version></ros:Version>
      <ros:Parameters>
        <ros:Parameter />
      </ros:Parameters>
    </ros:AppInfo>
```
`ros:AppName` only supports three formats, "Chrome","Firefox" and "InternetExplorer". and `ros:ExecuePath` is the unzip file path, `ros:Bits` only supoort "32Bits".

#### 4.1.5 Tests
Contains all the test cases, and each test case corresponds to a manual test case, the test case like this type:
```
<ros:TestCase ros:ID="WebControl">
      <ros:Annotation>
        <ros:Description>
        </ros:Description>
        <ros:Created ros:Author="fengtao" ros:Date="2016-01-22" />
        <ros:LastUpdated ros:Author="fengtao" ros:Date="2016-01-22" />
      </ros:Annotation>
      <ros:TestSteps>
      </ros:TestSteps>
    </ros:TestCase>
```
you need modify ID's value  for `ros:ID`, this ID is unique, then fill in the value on `ros:Annotation`, this node same as [Annotation](#Annotation). `ros:TestSteps` is the test steps recorder. every step is an actual action on the web. If you don't know how to develop the Web step, please see this document, [Web Steps APIs](https://github.com/Fengtao1314520/RoWarlock/blob/master/Ro.GuiRun/Icon/ReadMe/MarkDown/RoWarlock%20Web%20APIs.md)

#### 4.1.6 CloseApp
If you want delete browser drivers ,you can use `ros:Keep="false"`, and `ros:Keep="true"` that if you keep the test environment.

#### 4.1.7 LogFunction
This is the last scripts node. In the end of testing, RoWarlock needs save log file. this node's InnerText allow of empty. The logs zip package will saved on Desktop. if you modify value, the logs zip package will saved in yourself's folder path.

### 4.2 Roi file(Ro-Elements file)
1. create xml file and change suffix name to the "roi".
2. copy this text

```
<?xml version="1.0" encoding="utf-8"?>

<roi:roi xmlns:roi="http://tempuri.org/RoiFile.xsd"
         xmlns:ros="http://tempuri.org/RoFramework.xsd">
<!--******************************************************************************
    TODO 2017-06-05更新roi文件中控件的命名规则
    By:冯涛(Nate Ford)
    
    1.控件名称需要明确表达控件的作用，具有简单明了的表现形式
    2.控件名称以'驼峰形式表达'，首字母为大写字母，允许简写形式，但不允许使用拼音。正确表达例如:FindElement
    3.控件名称需要跟随控件形式，以"_"下划线跟随控件形式，且放置于表形式的最后，正确表达例如:FindElement_Btn
    4.控件名称中附属的限定值跟随在名称后，以"_"+"限定值"的形式表现，正确表达例如:FindElement_Left_Btn、FindElement_1_Btn等
    
    控件形式为:
    按钮/Button ——> _Btn
    显示字符/Label ——> _Lbl
    文本框/Text ——> _Text
    复选项/RadioBoxButton ——> _Rbn
    勾选项/CheckBoxButton ——> _Cbn
    列表/Table ——> _Tbl
    单行或单列数据/List  ——> _Lst
    
    Web特有的:
    IFrame ——> _Frm
    ******************************************************************************-->
  <roi:annotation>
    <ros:Description>
      版权、著作权归属冯涛所有
      基于Apache-2.0开源协议，授权给其他人员使用。如需修改Roi文件对应框架文件，需在被修改文件中，对本著作权人进行描述和引申
      Author: 冯涛
      E-mail: fengtao.1314520@163.com
      Skype/MSN: fengtao.1314520@hotmail.com
      Gmail: fengtao.1314520@gmail.com

      对整个测试元素文件进行描述详情
    </ros:Description>
    <ros:Created ros:Author="nate" ros:Date="2017-08-16" />
    <ros:LastUpdated ros:Author="nate" ros:Date="2017-08-16" />
  </roi:annotation>

  <roi:meta>

    <!--元素的写法，单元素-->
    <roi:sigele roi:id="" roi:explain="单元素独立的元素，通过locator和value可以直接定位到本元素">
      <roi:valueinfo roi:locator="XPath" roi:index="1"></roi:valueinfo>
    </roi:sigele>

    <!--元素的写法，复合元素-->
    <roi:cpxele roi:explain="复合元素是同父元素的派生写法，复合元素的子元素都拥有自己的id,只共享使用locator和前缀value">
      <roi:valueinfo roi:locator="Class" roi:index=""></roi:valueinfo>
      <roi:complexs>
        <roi:cpxchild roi:id="" roi:childvalue="" roi:index="" />
      </roi:complexs>
    </roi:cpxele>

    <!--超集，文件逻辑结构-->
    <roi:superset roi:explain="超集，仅仅是文件逻辑结构">
      <roi:subset roi:explain="子集，仅仅是文件逻辑结构">
        <roi:sigele roi:id="" roi:explain="单元素">
          <roi:valueinfo roi:locator="XPath"></roi:valueinfo>
        </roi:sigele>
        
        <roi:cpxele roi:explain="复合元素">
          <roi:valueinfo roi:locator="Class" roi:index="" />
          <roi:complexs>
            <roi:cpxchild roi:id="" roi:childvalue="" roi:index="" />
          </roi:complexs>
        </roi:cpxele>
      </roi:subset>

      <roi:subset roi:explain="子集，仅仅是文件逻辑结构">
        <roi:sigele roi:id="" roi:explain="单元素">
          <roi:valueinfo roi:locator="XPath"></roi:valueinfo>
        </roi:sigele>
       
        <roi:cpxele roi:explain="复合元素">
          <roi:valueinfo roi:locator="Class" roi:index="" />
          <roi:complexs>
            <roi:cpxchild roi:id="" roi:childvalue="" roi:index="" />
          </roi:complexs>
        </roi:cpxele>
      </roi:subset>
    </roi:superset>


  </roi:meta>
</roi:roi>

```

3. fill in the corresponding information

#### 4.2.1 Element name rules

* The name of the element(`roi:id=""`) needs to be simple and clear, and contains the effect of this element.
* The name of the element is expressed in the form of a hump. The first letter is uppercase, allowing abbreviations, but not the pinyin. like this type:`roi:id="FindElement"`
* The element name needs additional control types or target,like this:`roi:id="FindElement_Btn"`,`roi:id="FindElement_Text"`
* If the name contains other restrictions, please add it to the middle of the name. lile this type `roi:id="FindElement_Left_Btn`

#### 4.2.2 Control types rules

    * Button ——> _Btn
    * Label ——> _Lbl
    * Text ——> _Text
    * RadioBoxButton ——> _Rbn
    * CheckBoxButton ——> _Cbn
    * Table ——> _Tbl
    * List  ——> _Lst
    * IFrame ——> _Frm

#### 4.2.3 <span id="sigele">sigele</span>

This is a single element, the tpye is:
```
<roi:sigele roi:id="" roi:explain="单元素独立的元素，通过locator和value可以直接定位到本元素">
      <roi:valueinfo roi:locator="XPath" roi:index="1">//*span[@id='abc']</roi:valueinfo>
    </roi:sigele>
```
You need modify ID's value  for `roi:id`, this id is unique. and `roi:explain` is is the explanation of this element. `roi:locator` is the query method of this element, RoWarlock support 6 method

* id
* name
* class
* css
* link
* XPath

If the number of elements is not unique, please add `roi:index="1"`, the index value is the element serial number. like this:
`if you find this  number of elements is 3 and you just use N0.2 element, the serial number is 2 (roi:index="2") `

`//*span[@id='abc']` is the XPath value, you need modift this value to your using element's value.


#### 4.2.4 <span id="cpxele">cpxele</span>

You need modify ID's value  for `roi:id`, this id is unique
This is a complex elements list. this elements have a part of the same xpath value,Usually is the first half. like this:
there is two different elements,the first is `xpath=//*div[1]/span/span[@id='a']`. the second is `xpath=//*div[1]/span/span[@id='b']`, a part of the same xpath value is `xpath=//*div[1]/span`, so cpxele is: 
```
 <roi:cpxele>
      <roi:valueinfo roi:locator="XPath">//*div[1]/span</roi:valueinfo>
      <roi:complexs>
        <roi:cpxchild roi:id="A" roi:childvalue="span[@id='a']" />
        <roi:cpxchild roi:id="A" roi:childvalue="span[@id='b']" />
      </roi:complexs>
    </roi:cpxele>
```
`roi:explain` is is the explanation of this element. 

#### 4.2.5 superset & subset

superset and subset is the logical relationship between elements, superset allow contains subset, subset allow contains [sigele](#sigele) and [cpxele](#cpxele)
```
<roi:superset>
      <roi:subset>
        <roi:sigele roi:id="">
          <roi:valueinfo roi:locator="XPath"></roi:valueinfo>
        </roi:sigele>       
        <roi:cpxele>
          <roi:valueinfo roi:locator="Class" roi:index="" />
          <roi:complexs>
            <roi:cpxchild roi:id="" roi:childvalue="" roi:index="" />
          </roi:complexs>
        </roi:cpxele>
      </roi:subset>
    </roi:superset>
```

#### 4.2.6 How to use element on the ros file

When you create and complete the development of the roi file, plese rename this file and give this file a simple and clear name. Get this file path  [ConfigurationFile](#ConfigurationFile)'s in `ros:Imports`
```
<ros:ConfigurationFile ros:ID="" ros:Type="RoWeb">
        <ros:Path></ros:Path>
      </ros:ConfigurationFile>
```
`ros:ID` same as file name, when you want use a element on teststep, get this element `roi:id` and fill in `web:RoWebElementID=""`, you don't know `web:RoWebElementID=""`, plese see this document [Web Steps APIs](https://github.com/Fengtao1314520/RoWarlock/blob/master/Ro.GuiRun/Icon/ReadMe/MarkDown/RoWarlock%20Web%20APIs.md)


### 4.3 Roc File(Ro-config file)

1. create xml file and change suffix name to the "roc".
2. copy this text

```
<?xml version="1.0" encoding="utf-8"?>

<roc:Config xmlns:roc="http://tempuri.org/RocFile.xsd"
            xmlns:ros="http://tempuri.org/RoFramework.xsd"
            xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">

  <!--配置文件描述-->
  <roc:Annotation>
    <ros:Description>
      版权、著作权归属冯涛所有
      基于Apache-2.0开源协议，授权给其他人员使用。如需修改Roc文件对应框架文件，需在被修改文件中，对本著作权人进行描述和引申
      Author: 冯涛
      E-mail: fengtao.1314520@163.com
      Skype/MSN: fengtao.1314520@hotmail.com
      Gmail: fengtao.1314520@gmail.com
      
      脚本配置文件，用以存放脚本中的各类可能用到的参数
    </ros:Description>
    <ros:Created ros:Author="fengtao" ros:Date="2017-08-15" />
    <ros:LastUpdated ros:Author="fengtao" ros:Date="2017-08-15" />
  </roc:Annotation>

  <!--测试模式-->
  <roc:TestMode roc:SelectMode="Defalut" roc:LoopNum="1"/>
  
  
  <!--设定参数-->
  <roc:Properties>
    <ros:Property ros:ID="参数Id">
      <ros:Value>参数值</ros:Value>
      <ros:Description>参数描述</ros:Description>
    </ros:Property>
  </roc:Properties>
  
  
  <!--测试宏-->
  <roc:Macros>
    <roc:Macro roc:ID="宏Id">
      <roc:MacroActivities>
        填入对应步骤
      </roc:MacroActivities>
    </roc:Macro>
  </roc:Macros>
  
</roc:Config>

```

3. fill in the corresponding information


#### 4.3.1 TestMode

Don't modify this node value,

#### 4.3.2 Properties

Same as Properties on ros file,plese see [Porperty](#Porperty)

#### 4.3.3 Macros

Different test cases may use completely consistent test steps, Macro saved this steps
```
 <roc:Macro roc:ID="宏Id">
      <roc:MacroActivities>
        填入对应步骤
      </roc:MacroActivities>
    </roc:Macro>
  </roc:Macros>
```
You need modify ID's value  for `roc:ID`, this ID is unique
Please fill in same steps on the  `roc:MacroActivities`.

##### 4.3.3.1 How to use Macros on the ros file

When you create and complete the development of the roc file, plese rename this file and give this file a simple and clear name. Reopen RoWarlock tool, and re-select folder path.
when you want use a macro on teststep, get this macro `roc:iID` and fill in `<ros:MacroReference ros:MacroID="" />`, if you don't know `ros:MacroReference ros:MacroID=""`, plese see this document [Web Steps APIs](https://github.com/Fengtao1314520/RoWarlock/blob/master/Ro.GuiRun/Icon/ReadMe/MarkDown/RoWarlock%20Web%20APIs.md)

## 5 License

RoWarlock is licensed under [Apache Licence V2.0](http://www.apache.org/licenses/LICENSE-2.0.html) license.

## 6 Thanks

* [Selenium](http://www.seleniumhq.org/)(Completed)
* [Appium](http://appium.io/)(In development)
* MS UIAutomation(In development）
* Thanks [DMSkin](http://www.dmskin.com/), the UI based DMSkin











    
    
    
    
   
   
  
  



