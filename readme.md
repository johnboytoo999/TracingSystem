# TracingSystem文件


## DB 物件
#### RolePermission

| 欄位       |型態 | ISNULL   |  定義  |
| -------- | -----:  | -----:  | :----:  |
| Id      | int    | X  |   PK,流水號    |
| RoleName    |nvarchar(50)    |  X   |  角色名稱  |
| CreateIssue   | bit  |   X    |  製造issue權限  |
| ResolveIssue  | bit     |   X    |   解決issue權限 |
| UpdateIssue    | bit     |    X    |  更新issue權限  |
| DeleteIssue    | bit     |    X    |   刪除issue權限  |

#### IssueList

| 欄位       |型態 | ISNULL   |  定義  |
| -------- | -----:  | -----:  | :----:  |
| Id      | int    | X  |   PK,流水號    |
| Summary    |nvarchar(100)   |  X   |  標題  |
| Description   | nvarchar(MAX)  |   X    |  敘述  |
| serious   | int  |   X    |  嚴重性  |
| issueType  | int     |   X    |   單子類型|
| Status  | int     |   X    |   狀態 |
| CreateUserId    | int     |    X    |  FK TracingUser ID  |
| LstMaintUserId    | int     |    X    |  FK TracingUser ID   |
| CreateDt    | datetime     |    X    |  建立時間 |
| LstMaintDt    | datetime     |    X    |   修改日期  |

#### TracingUser

| 欄位       |型態 | ISNULL   |  定義  |
| -------- | -----:  | -----:  | :----:  |
| Id      | int    | X  |   PK,流水號    |
|  Account  | varchar(50)    |  X   |  帳號  |
| Password   |varchar(max)  |   X    |  密碼使用hash加密  |
| UserName  | nvarchar(50)   |   X    |   使用者名稱 |
| UserRole    | int     |    X    |  使用者角色  |
| CreateDt    | datetime     |    X    |  建立時間 |
| LstMaintDt    | datetime     |    X    |   修改日期  |



----

## 開發程式
- Asp.netCoreMVC + Razor
- MSSQL

## 使用套件
- Microsoft.AspNetCore.Authentication.Cookies
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- 若開放系統供第三方使用則會使用swagger

