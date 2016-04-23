<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowMsg.aspx.cs" Inherits="BookShop.Web.ShowMsg" %>

<!DOCTYPE html>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        window.onload = function () {
            setTimeout(changeTime,1000);
        }

        function changeTime() {
            var time = document.getElementById("time").innerHTML;
            time = parseInt(time);
            time--;
            if (time < 1) {
                window.location.href = document.getElementById("url").href;
            } else {
                document.getElementById("time").innerHTML = time;
                setTimeout(changeTime, 1000);
            }
        }

    </script>    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="490" height="325" border="0" align="center" cellpadding="0" cellspacing="0" background="Images/showinfo.png">
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="50">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td width="40">&nbsp;</td>
                            </tr>
                            <tr>
                                <td width="50">&nbsp;</td>
                                <td style="text-align: center">
                                    <asp:Label ID="Label1" runat="server" ForeColor="#CC0000" Width="98%">
                                        <%=this.msg %>
                                    </asp:Label>
                                </td>
                                <td width="40">&nbsp;</td>
                            </tr>
                            <tr>
                                <td width="50">&nbsp;</td>
                                <td>
                                    <span style="font-size:18px;color:red" id="time">5</span>秒后自动跳转到<a id="url" href="<%=this.url %>"><%=this.txt %></a>
                                </td>
                                <td width="40">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

