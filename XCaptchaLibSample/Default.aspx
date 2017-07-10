<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="XCaptchaLibSample.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        body {
            line-height:1.5em;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>
            此範例程式碼為使用 XCaptcha 進行驗證碼認證
        </p>

        <asp:Image runat="server" ID="CaptchaImage" />
        <div>請輸入圖形驗證碼：</div>
        <asp:TextBox runat="server" ID="CaptchaTextBox"></asp:TextBox>

        <hr />

        <asp:Button runat="server" ID="CaptchaButton" Text="驗證" OnClick="CaptchaButton_Click"/>
        <br />
        驗證結果：<asp:Literal runat="server" ID="Validator"></asp:Literal>

    </div>
    </form>
</body>
</html>