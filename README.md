# RoWarlock
## 简介
RoWarlock是基于Selenium 3.X, Appium, MSUIAutomation开发的自动化测试工具。基于.Net 4.5开发，能够测试Web, Client, Mobile等程序。实现了代码与脚本分离，脚本与元素分离，能够实现对UI层进行复杂的自动化测试。
具体使用说明，请查看附件

## 当前完成度
- 2017-03-28： 完成EAP版本释放
- 2017-04-01： 完成EAP版本的DEBUG工作，由于原项目的MD文件有问题，所以重新开了本项目
- 2017-05-24： 完整正式版本V1.0的开发和Debug工作，新添加Pro的版本内容，支持宏、迭代和循环测试，支持Config配置文件(.tcc)进行参数、宏和测试执行模式的配置
- 2017-11-07： 完整正式版本V1.5的开发和Debug工作，几近重构了整个项目

### V1.0 版本
- 当前仅提供Web端测试支持

### V1.5 版本
- 不再使用Command的形式，只保留了UI显示结果
- 不再使用Extent Report保留log 只有界面显示和自定义的log文件


## 截图
![Pro](https://git.oschina.net/uploads/images/2017/0525/140836_98434e03_565898.png)
![Command](https://git.oschina.net/uploads/images/2017/0525/140946_ab24ee25_565898.jpeg)

## 环境配置
RoWarlock无需复杂的环境配置，仅需安装 .Net 4.5 Framework即可

## 注意事项
工程项目编码需要设置为UTF-8否则会出现中文乱码情况

## 已知问题
- 产出的Extent Reports中，使用的开源工具出现一处错误导致Tests和Steps数量会相等，已提交gitHub,等待解决
- Pro的版本(GUI) case、steps的成功统计率无法更新，后续版本进行添加该功能

## 框架APIs
- [框架API文档](https://doc.oschina.net/rowarlock?t=171808)
密码：RoWarlock

- [WebAPI文档](https://doc.oschina.net/rowarlock?t=171835)
密码：RoWarlock

- [Web脚本示例](https://doc.oschina.net/rowarlock?t=171650)
密码：RoWarlock

## 实现的功能
- 1、XML管理测试脚本和测试对象
- 2、脚本与测试对象文件强制书写，通过xsd框架文件操控
- 3、支持数据驱动 
- 4、支持关键字驱动 
- 5、自动生成html报表（通过[Extent Reports](https://github.com/anshooarora/extentreports-csharp)支持） 
- 6、支持生成.log文件，作为开发log保存。功能由[Log4Net](http://logging.apache.org/log4net/)支持
- 7、测试对象与测试流程分离，互不影响

## RoWarlock V1.1更新内容
RoWarlock V1.1


- 更新Tci的Samples
- 更新所有的Tci文件中的控件Id
- 更新xsd文件
- 更改了程序中关于读取tci文件的逻辑和方法
- 更改使用控件ID的方法，现在分为2种文件，一种是普通tci文件，如下文档


```

<?xml version="1.0" encoding="utf-8"?>

<xs:schema attributeFormDefault="qualified"
           elementFormDefault="qualified"
           targetNamespace="http://tempuri.org/DemoForWeb1.tci"
           xmlns:demoforweb1="http://tempuri.org/DemoForWeb1.tci"
           xmlns:xs="http://www.w3.org/2001/XMLSchema">
  
  <!--TODO 正式使用时，请将所有的后缀 “1”删除-->
  <!--
  ==============================================================================
  ******************************************************************************
                                  Documentation
  ******************************************************************************
  ==============================================================================
  -->

  <!--******************************************************************************
    TODO 2017-06-05更新Tci文件中控件的命名规则
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


  <xs:annotation>
    <xs:documentation>
      RoWarlock 测试脚本Web控件
      版权 著作权归属冯涛所有
      Author: 冯涛
      E-mail: fengtao.1314520@163.com
      Skype/MSN: fengtao.1314520@hotmail.com
      Gmail: fengtao.1314520@gmail.com

      DemoForWeb文件，控件书写的格式 样式
    </xs:documentation>
  </xs:annotation>


  <!--************************************************************************************************************************
      Todo 更新2017-06-06，为了在tcs文件中，可以智能输出控件，因此更改了tci文件的写法，基于SimpleType(简单类型)更改，利用已用的节点名称进行判断
      enumeration
      value:simpleType的Name值+enumeration的id值
      id:控件Id名 允许id名称不填写
      
      appinfo
      source:原Locator值，需要手动书写是Id,XPath或其他
             在尖括号之间填写控件值
      *************************************************************************************************************************-->


  <xs:simpleType name="DemoForWeb1"><!--文件名称即name-->
    <xs:restriction base="xs:string"><!--不用更改-->
      <!--单个控件-->
      <xs:enumeration value="DemoForWeb.Menu_01_Btn"><!--value是simpleType的Name值+控件名称-->
        <xs:annotation>
          <xs:appinfo source="XPath">//*[@id="MENU_01"]</xs:appinfo><!--第一行source:原Locator值，需要手动书写是Id,XPath或其他值。在尖括号之间填写控件值-->
          <xs:appinfo source="Index" /><!--第二行source:原Index值，如果没有则不填，如果有，则填写在尖括号之间-->
          <xs:documentation>
            菜单栏中按钮
          </xs:documentation>
        </xs:annotation>
      </xs:enumeration>

      <!--单个控件-->
      <xs:enumeration value="DemoForWeb.Menu_01_Btn"><!--value是simpleType的Name值+控件名称-->
        <xs:annotation>
          <xs:appinfo source="XPath">//*[@id="MENU_01"]</xs:appinfo><!--第一行source:原Locator值，需要手动书写是Id,XPath或其他值。在尖括号之间填写控件值-->
          <xs:appinfo source="Index">1</xs:appinfo><!--第二行source:原Index值，如果没有则不填，如果有，则填写在尖括号之间-->
          <xs:documentation>
            菜单栏中按钮
          </xs:documentation>
        </xs:annotation>
      </xs:enumeration>

    </xs:restriction>
  </xs:simpleType>

</xs:schema>


```
第二中是被总tci文件调用文件

```
<?xml version="1.0" encoding="utf-8"?>

<xs:schema attributeFormDefault="qualified"
           elementFormDefault="qualified"
           targetNamespace="http://tempuri.org/ComTci1.tci"
           xmlns:ComTci1="http://tempuri.org/ComTci1.tci"
           xmlns:demoforweb1="http://tempuri.org/DemoForWeb1.tci"
           xmlns:xs="http://www.w3.org/2001/XMLSchema">

 <!--TODO 正式使用时，请将所有的后缀 “1”删除-->
  <!--
  ==============================================================================
  ******************************************************************************
                                  Documentation
  ******************************************************************************
  ==============================================================================
  -->

  <xs:annotation>
    <xs:documentation>
      RoWarlock 测试脚本Web控件
      版权 著作权归属冯涛所有
      Author: 冯涛
      E-mail: fengtao.1314520@163.com
      Skype/MSN: fengtao.1314520@hotmail.com
      Gmail: fengtao.1314520@gmail.com

      控件tci文件集合
    </xs:documentation>
  </xs:annotation>

  <!--
  ==============================================================================
  ******************************************************************************
                                     Imports
                         TODO 每添加一个tci文件，都需要新增一次import
  ******************************************************************************
  ==============================================================================
  -->

  <xs:import namespace="http://tempuri.org/DemoForWeb1.tci" />


  <!--************************************************************************************************************************
      Todo 更新2017-06-06，为了在tcs文件中，可以智能输出控件，因此更改了tci文件的写法，基于SimpleType(简单类型)更改，利用已用的节点名称进行判断
      所有Tci文件的总控制，被RoWebAutomation.xsd调用
      每增加一个tci，都需要添加到memberTypes中，通过空格(" ")进行分拆，本身节点不被读取、解释
      *************************************************************************************************************************-->


  <!--被RoWebElement.xsd调用-->
  <xs:simpleType name="WebEleSimple">
    <xs:union memberTypes="demoforweb1:DemoForWeb1"/>
  </xs:simpleType>


</xs:schema>

```

# 感谢
- 感谢[Selenium](http://www.seleniumhq.org/)提供Web端的功能实现（开发完成）
- 感谢[Appium](http://appium.io/)提供Mobile端的功能实现（开发中）
- 感谢MSUIAutomation提供Client端的功能实现（开发中）

# 个人感悟
  暂无
