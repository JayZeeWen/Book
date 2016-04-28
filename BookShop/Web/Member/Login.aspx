<%@ Page Title="" Language="C#" MasterPageFile="~/Member/Reg.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BookShop.Web.Member.Login" %>

<%@ Register Src="~/Member/LoginUser.ascx" TagPrefix="uc1" TagName="LoginUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:LoginUser runat="server" id="LoginUser" />
</asp:Content>
