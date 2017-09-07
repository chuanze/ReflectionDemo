<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ColorShow.aspx.cs" Inherits="WebSite.ColorShow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        body{font-size:14px;}
        h1 {
            font-size:26px;
        }
        #pnColors div{
            float:left;width:140px;
            padding:7px 0;
            text-align:center;
            margin:3px;
            border:1px solid #aaa;
            font-size:11px;
            font-family:Verdana,Arial;
        }
    </style>
</head>
<body>
    <h1>遍历System.Drawing.Color结构</h1>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="pnColors" runat="server"></asp:Panel>
        </div>
    </form>
</body>
</html>
