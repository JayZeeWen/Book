<%@ Page Title="" Language="C#" MasterPageFile="~/Member/Reg.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BookShop.Web.Member.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="font-size: small">
        <table width="80%" height="22" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 10px">
                    <img src="../Images/az-tan-top-left-round-corner.gif" width="10" height="28" /></td>
                <td bgcolor="#DDDDCC"><span class="STYLE1">注册新用户</span></td>
                <td width="10">
                    <img src="../Images/az-tan-top-right-round-corner.gif" width="10" height="28" /></td>
            </tr>
        </table>


        <table width="80%" height="22" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="2" bgcolor="#DDDDCC">&nbsp;</td>
                <td>
                    <div align="center">
                        <table height="61" cellpadding="0" cellspacing="0" style="height: 332px">
                            <tr>
                                <td height="33" colspan="6">
                                    <p class="STYLE2" style="text-align: center">注册新帐户方便又容易</p>
                                </td>
                            </tr>
                            <tr>
                                <td width="24%" align="center" valign="top" style="height: 26px">用户名</td>
                                <td valign="top" width="37%" align="left" style="height: 26px">
                                    <input type="text" name="txtUserName" />
                                </td>
                            </tr>
                            <tr>
                                <td width="24%" height="26" align="center" valign="top">真实姓名：</td>
                                <td valign="top" width="37%" align="left">
                                    <input type="text" name="txtRealName" />
                                </td>
                            </tr>
                            <tr>
                                <td width="24%" height="26" align="center" valign="top">密码：</td>
                                <td valign="top" width="37%" align="left">
                                    <input type="password" name="txtPwd" />
                                </td>
                            </tr>
                            <tr>
                                <td width="24%" height="26" align="center" valign="top">确认密码：</td>
                                <td valign="top" width="37%" align="left">
                                    <input type="password" name="txtConfirmPwd" />
                                </td>
                            </tr>
                            <tr>
                                <td width="24%" height="26" align="center" valign="top">Email：</td>
                                <td valign="top" width="37%" align="left">
                                    <input type="text" name="txtEmail" />
                                </td>
                            </tr>
                            <tr>
                                <td width="24%" height="26" align="center" valign="top">地址：</td>
                                <td valign="top" width="37%" align="left">
                                    <input type="text" name="txtAddress" />
                                </td>
                            </tr>
                            <tr>
                                <td width="24%" height="26" align="center" valign="top">手机：</td>
                                <td valign="top" width="37%" align="left">
                                    <input type="text" name="txtPhone" />
                                </td>
                            </tr>
                            <tr>
                                <td width="24%" height="26" align="center" valign="top">验证码：</td>
                                <td valign="top" width="37%" align="left">
                                    <input type="text" name="txtCode" /><img src="../ashx/ValidateCode.ashx" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <input type="submit" value="注册" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">&nbsp;</td>
                            </tr>
                        </table>
                        <div class="STYLE5">---------------------------------------------------------</div>
                    </div>
                </td>
                <td width="2" bgcolor="#DDDDCC">&nbsp;</td>
            </tr>
        </table>

        <table width="80%" height="3" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td height="3" bgcolor="#DDDDCC">
                    <img src="../Images/touming.gif" width="27" height="9" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
