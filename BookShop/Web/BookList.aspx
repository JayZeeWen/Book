<%@ Page Title="" Language="C#" MasterPageFile="~/Member/List.Master" AutoEventWireup="true" EnableViewState="false" CodeBehind="BookList.aspx.cs" Inherits="BookShop.Web.BookList" %>
<%@ Register src="Member/PageBar.ascx" tagname="PageBar" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/pageBar.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <asp:Repeater runat="server" ID="rptBook">
        <ItemTemplate>
            <table>
                <tbody>
                    <tr>
                        <td rowspan="2"><a href="/StaticPage/<%# this.GetDir(Eval("Id")) %>">
                            <img
                                id="ctl00_cphContent_dl_Books_ctl01_imgBook"
                                style="cursor: hand" height="121"
                                alt="<%#Eval("Title") %>" hspace="4"
                                src="<%#Eval("ISBN","/Images/BookCovers/{0}.jpg") %>" width="95"></img></a>
                        </td>
                        <td style="font-size: small; color: red" width="650"><a
                            class="booktitle" id="link_prd_name"
                            href="/StaticPage/<%# this.GetDir(Eval("Id")) %>" target="_blank"
                            name="link_prd_name"><%#Eval("Title") %></a>
                        </td>
                    </tr>
                    <tr>
                        <td align="left"><span
                            style="font-size: 12px; line-height: 20px"><%#Eval("Author") %></span><br>
                            <br>
                            <span
                                style="font-size: 12px; line-height: 20px"><%#this.CutString(Eval("ContentDescription").ToString(),150)%></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2"><span
                            style="font-weight: bold; font-size: 13px; line-height: 20px">&yen; 
                      <%#Eval("UnitPrice") %></span> </td>
                    </tr>
                </tbody>
            </table>
        </ItemTemplate>
        <SeparatorTemplate>
            <hr />
        </SeparatorTemplate>
    </asp:Repeater>
    <div class="contentstyle" style="margin: 20px 0px; text-align: left"> 
        <uc1:PageBar ID="PageBar1" runat="server" />
    </div>
    
</asp:Content>
