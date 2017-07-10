## 在 ASP.Net WebForm 專案使用 XCaptcha 實作驗證碼功能

XCaptcha 套件範例是提供給 MVC 專案使用，此程式碼範例為將相關程式碼內容套用在 ASP.NET WebForm 專案。

套件路徑

https://www.nuget.org/packages/XCaptcha/

套件說明網站

http://xcaptcha.codeplex.com/


### 範例程式碼中
驗證碼的數值將儲存在 Session 物件中。

使用 Json 將圖片位元陣列轉換成 base64 Image 路徑輸出到 asp:Image 控制項，請依照情境進行修正。

更多客製化的項目請參考套件的說明網站。

### 套件還原指令碼

```
Install-Package XCaptcha
Install-Package Newtonsoft.Json
```
