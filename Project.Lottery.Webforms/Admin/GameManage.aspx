<%@ Page Title="Lottery | Game Manage" Theme="Main" Language="C#" MasterPageFile="~/MasterPages/BaseSkin.Master" AutoEventWireup="true" CodeBehind="GameManage.aspx.cs" Inherits="Project.Lottery.Webforms.Admin.GameManage" %>

<%@ Register TagPrefix="CustomControl" TagName="GameFormControl" Src="~/UserControls/GameFormControl.ascx" %>
<%@ Register TagPrefix="CustomControl" TagName="GameListViewControl" Src="~/UserControls/GameListViewControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	

	<%--  ||  BEGIN-INSET-3  ||==  { CONTENT-PLACEHOLDER-BODY } ==||  --%>
	<div class="Container_ContentBody cf"> 


		<%--  ||  BEGIN-INSET-4  ||==  { GAME-CONTROL } ==||  --%>
		<CustomControl:GameFormControl runat="server" ID="gameFormControl">

		</CustomControl:GameFormControl> 	<%--||  END  ||==  { GAME-CONTROL } ==||  --%>



		<%--  ||  BEGIN-INSET-4  ||==  { GAME-LIST-VIEW } ==||  --%>
		<CustomControl:GameListViewControl runat="server" ID="gameListViewControl" >

		</CustomControl:GameListViewControl>  <%--||  END  ||==  { GAME-LIST-VIEW } ==||  --%>



	</div>  <%--||  END  ||==  { CONTENT-PLACEHOLDER-BODY } ==||  --%>


</asp:Content>
