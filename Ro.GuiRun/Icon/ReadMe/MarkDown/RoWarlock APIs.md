RoWarlock APIs
===
 
# ros:TestDefinition
- **请求参数**
 
| 请求参数|  参数类型   |  是否必填| 参数含义 |
| --------   | -----  | ----  |----  |
|   ros:Annotation  | ChildNode |不可为空|   脚本描述信息     |
|   ros:TestConfig   | ChildNode |不可为空|   脚本配置信息     |
|   ros:StartApp   | ChildNode |不可为空|   脚本测试程序信息    |
|   ros:Tests   | ChildNode |不可为空|   脚本用例步骤    |
|   ros:Close  | ChildNode |不可为空|   脚本关闭程序配置     |
|   ros:LogFunction | ChildNode |不可为空|   脚本Log配置     |
 
----------
 
 
## 1 ros:Annotation
 
- **请求参数**
 
| 请求参数|  参数类型   |  是否必填| 参数含义 |
| --------   | -----  | ----  |----  |
|   ros:Description  | ChildNode |不可为空|   描述     |
|   ros:Created   | ChildNode |不可为空|   创建者信息     |
|   ros:LastUpdated | ChildNode |不可为空|   更新者信息     |
 
 
### 1.1 ros:Description
 
- **请求参数**
 
| 请求参数|  参数类型   |  是否必填| 参数含义 |
| --------   | -----  | ----  |----  |
|   N/A   | InnerText |可为空|   填充描述     |
 
- **使用示例**
 
```
<ros:Description>对整个测试脚本进行描述</ros:Description>
```
 
 
### 1.2 ros:Created
- **请求参数**
 
| 请求参数|  参数类型   |  是否必填| 参数含义 |
| --------   | -----  | ----  |----  |
|   ros:Author  | AttributeValue |不可为空|   创建作者     |
|   ros:Date  | AttributeValue |不可为空|   创建时间     |
 
 
- **使用示例**
 
```
<ros:Created ros:Author="nate" ros:Date="2017-03-16" />
```
 
 
- **请求参数**
 
| 请求参数|  参数类型   |  是否必填| 参数含义 |
| --------   | -----  | ----  |----  |
|   ros:Author  | AttributeValue |不可为空|   最后更新作者     |
|   ros:Date  | AttributeValue |不可为空|   最后更新时间     |
 
 
 
### 1.3 ros:LastUpdated
- **使用示例**
 
```
<ros:LastUpdated ros:Author="nate" ros:Date="2017-03-16" />
```
 
 
----------
 
## 2 ros:TestConfig
- **请求参数**
 
| 请求参数|  参数类型   |  是否必填| 参数含义 |
| --------   | -----  | ----  |----  |
|  ros:Properties  | ChildNode |不可为空|   设定参数     |
|  ros:Imports  | ChildNode |不可为空|   引入Tci文件     |
 
 
### 2.1 ros:Properties
- **请求参数**
 
| 请求参数|  参数类型   |  是否必填| 参数含义 |
| --------   | -----  | ----  |----  |
|  ros:Property| ChildNode |不可为空|   设定参数     |
 
- **使用示例**
 
```
    <ros:Properties>
 
      <ros:Property ros:ID="Username">
        <ros:Value>admin</ros:Value>
        <ros:Description>用户名</ros:Description>
      </ros:Property>
 
      <ros:Property ros:ID="Path">
        <ros:Value>C://Windows</ros:Value>
        <ros:Description></ros:Description>
      </ros:Property>
 
    </ros:Properties>
 
```
 
 
#### 2.1.1 ros:Property
- **请求参数**
 
| 请求参数|  参数类型   |  是否必填| 参数含义 |
| --------   | -----  | ----  |----  |
|   ros:ID  | AttributeValue |不可为空|   参数名称     |
|   ros:Value  | InnerText |不可为空|   参数值     |
|   ros:Description  | InnerText  |不可为空|   参数描述     |
 
 
- **使用示例**
 
```
<!--对参数赋予唯一的Id值-->
      <ros:Property ros:ID="Username">
        <!--参数值，参数值唯一-->
        <ros:Value>admin</ros:Value>
        <!--参数描述-->
        <ros:Description>用户名</ros:Description>
      </ros:Property>
 
```
 
 
### 2.2 ros:Imports
- **请求参数**
 
| 请求参数|  参数类型   |  是否必填| 参数含义 |
| --------   | -----  | ----  |----  |
|  ros:ConfigurationFile  | ChildNode |不可为空|   设定参数     |
 
- **使用示例**
 
```
   <ros:Imports>
      <ros:ConfigurationFile ros:ID="A" ros:Type="RoWeb">
        <ros:Path>${参数1}\${参数2}\A.tci</ros:Path>
      </ros:ConfigurationFile>
      <ros:ConfigurationFile ros:ID="B" ros:Type="RoClient">
        <ros:Path>${Path}\B.tci</ros:Path>
      </ros:ConfigurationFile>
      <ros:ConfigurationFile ros:ID="C" ros:Type="RoMobile">
        <ros:Path>C.tci</ros:Path>
      </ros:ConfigurationFile>
    </ros:Imports>
 
```
 
#### 2.2.2 ros:ConfigurationFile
- **请求参数**
 
| 请求参数|  参数类型   |  是否必填| 参数含义 |
| --------   | -----  | ----  |----  |
|   ros:ID  | AttributeValue |不可为空|   Tci文件名称     |
|   ros:Type  | AttributeValue |不可为空|  Tci文件类型      |
|   ros:Path  | AttributeValue |不可为空|  Tci文件路径     |
 
- **使用示例**
 
```
 
      <ros:ConfigurationFile ros:ID="A" ros:Type="RoWeb">
        <ros:Path>${参数1}\${参数2}\A.tci</ros:Path>
      </ros:ConfigurationFile>
 
```
 
----------
 
 
## 3 ros:StartApp
- **请求参数**
 
| 请求参数|  参数类型   |  是否必填| 参数含义 |
| --------   | -----  | ----  |----  |
|  ros:AppInfo   | ChildNode |不可为空|   App参数设定 ，唯一值    |
 
 
### 3.1 ros:AppInfo
- **请求参数**
 
| 请求参数|  参数类型   |  是否必填| 参数含义 |
| --------   | -----  | ----  |----  |
|   ros:AppName  | AttributeValue |不可为空|   APP名称     |
|   ros:ExecuePath  | ChildNode & InnerText |不可为空| 驱动执行存放路径   |
|   ros:BaseWindowsBits  | ChildNode |不可为空|  系统位数     |
| ros:Bits | AttributeValue |不可为空| 系统位数具体定义     |
| ros:Version| ChildNode & InnerText |可为空| 版本号|
|   ros:Parameters| ChindNode |可为空|  程序追加参数    |
 
- **使用示例**
 
```
 
 <ros:AppInfo ros:AppName="Chrome">
      <ros:ExecuePath>C://Browser</ros:ExecuePath>
      <!--Windows 位数-->
      <ros:BaseWindowsBits ros:Bits="32Bits" />
      <!--版本号，注意，版本号一定要定义-->
      <ros:Version></ros:Version>
      <!--程序追加参数-->
      <ros:Parameters>
        <ros:Parameter>/css</ros:Parameter>
        <ros:Parameter></ros:Parameter>
      </ros:Parameters>
    </ros:AppInfo>  
```
 
#### 3.1.1 ros:Parameters
- **请求参数**
 
| 请求参数|  参数类型   |  是否必填| 参数含义 |
| --------   | -----  | ----  |----  |
|  ros:Property   | ChildNode & InnerText |不可为空|   单个程序追加参数     |
 
 
##### 3.1.1.1 ros:Parameter
- **请求参数**
 
| 请求参数|  参数类型   |  是否必填| 参数含义 |
| --------   | -----  | ----  |----  |
|   Parameter   | InnerText |不可为空|   单个追加参数     |
 
 
 
- **使用示例**
 
```
<ros:Parameter>参数</ros:Parameter>
```
 
 
----------
 
## 4 ros:Tests
- **请求参数**
 
| 请求参数|  参数类型   |  是否必填| 参数含义 |
| --------   | -----  | ----  |----  |
|   ros:TestCase    | ChildNode |不可为空|   测试用例    |
 
 
### 4.1 ros:TestCase
- **请求参数**
 
| 请求参数|  参数类型   |  是否必填| 参数含义 |
| --------   | -----  | ----  |----  |
|   ros:ID  | AttributeValue |不可为空|   测试用例名称     |
|   ros:Annotation   | ChildNoe |不可为空|   测试用例描述     |
|   ros:TestSteps  | ChildNode |不可为空|   测试用例步骤集     |
 
 
- **使用示例**
 
```
<ros:TestCase ros:ID="WebControl">
      <ros:Annotation>
        <ros:Description>
          对本测试用例进行描述
        </ros:Description>
        <ros:Created ros:Author="fengtao" ros:Date="2016-01-22" />
        <ros:LastUpdated ros:Author="fengtao" ros:Date="2016-01-22" />
      </ros:Annotation>
 
      <ros:TestSteps>
 
<!--测试步骤-->
 
      </ros:TestSteps>
    </ros:TestCase>
```
 
 
----------
## 5 ros:CloseApp
- **请求参数**
 
| 请求参数|  参数类型   |  是否必填| 参数含义 |
| --------   | -----  | ----  |----  |
|  ros:Keep  | AttributeValue |不可为空|   是否保存程序驱动     |
 
 
 
- **使用示例**
 
```
<ros:CloseApp ros:Keep="true" />
```
 
 
----------
 
 
## 6 ros:LogFunction
 
- **请求参数**
 
| 请求参数|  参数类型   |  是否必填| 参数含义 |
| --------   | -----  | ----  |----  |
|   ros:LogFilePath  | ChildNode　＆　InnerText |可为空|   Log指定存放路径，不填写，默认为桌面     |
 
 
 
- **使用示例**
 
```
<ros:LogFunction>
    <ros:LogFilePath>log指定存放路径</ros:LogFilePath>
  </ros:LogFunction>
```
 
 