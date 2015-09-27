<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="K_Mean_Clustring_Data_Algorithm.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/style.css" type="text/css" rel="stylesheet" />
    <title>K-Mean Algorithm</title>
</head>

<body>
    <form id="form1" runat="server">
        <div>

            <div id="controls">
                <asp:TextBox ID="TextBox1" class="controlItem" placeholder="Points Number" runat="server"></asp:TextBox>
                <asp:TextBox ID="TextBox2" class="controlItem" placeholder="Clusters Number" runat="server"></asp:TextBox>
                <asp:Button ID="Button1" class="controlItem" runat="server" Text="Draw Points" OnClick="Button1_Click" OnPreRender="Button1_PreRender" />
                <asp:Button ID="Button2" class="controlItem" runat="server" Text="Clustring Points" OnClick="Button2_Click" OnPreRender="Button2_PreRender" />

            </div>

            <div id="panel">


                <div id="kmeans-vis">
                    <svg width="600" height="600">
                        <g id="points" runat="server"></g>
                        <g id="centroids" runat="server"></g>
                    </svg>
                </div>
            </div>

           

        </div>
    </form>
</body>
</html>
