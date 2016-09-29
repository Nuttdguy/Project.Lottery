<%@ Page Title="" Language="C#" Theme="Main" MasterPageFile="~/MasterPages/BaseSkin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Project.Lottery.Webforms.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<div class="Container_ContentBody_Nav"> FOR SECONDARY PAGE NAVIGATION </div>

	<div class="Container_ContentBody cf"> <%--FOR PAGE BODY CONTAINER --%>
		<div class="Container_ContentBody_Form"> FOR FORM CONTAINER</div>
		<div class="Container_ContentBody_ListView"> FOR LIST VIEW CONTAINER</div>
	</div>
</asp:Content>
