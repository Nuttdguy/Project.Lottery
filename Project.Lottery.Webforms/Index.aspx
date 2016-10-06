<%@ Page Title="" Language="C#" Theme="Main" MasterPageFile="~/MasterPages/BaseSkin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Project.Lottery.Webforms.Index" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


	<%--  ||  BEGIN-INSET-3  ||==  { CONTENT-PLACEHOLDER-BODY } ==||  --%>
	<div class="Container_ContentBody cf"> 
		
		<div class="Container_ContentBody_Form"> 


			<label>Winning # ID</label>
			<asp:TextBox runat="server" ID="txtWinningNumber" />
			<br />
			<br />

			<label>Drawing ID</label>
			<asp:TextBox runat="server" ID="txtDrawingId" />
			<br />
			<br />

			<label>BallNumber</label>
			<asp:TextBox runat="server" ID="txtBallNumber" />
			<br />
			<br />
			
			<label>Ball Type</label>
			<asp:TextBox runat="server" ID="txtBallType" />
			<br />
			<br />


			<asp:Button runat="server" Text="Win Number" OnClick="WinNumber_Click1"  />




<%--			<label>Location ID</label>
			<asp:TextBox runat="server" ID="txtLocationId" />
			<br />
			<br />

			<label>Lottery ID</label>
			<asp:TextBox runat="server" ID="txtLotteryId" />
			<br />
			<br />

			<label>StateName</label>
			<asp:TextBox runat="server" ID="txtStateName" />
			<br />
			<br />

			<asp:Button runat="server" Text="btnSubmit" OnClick="Unnamed_Click" />--%>

		</div>
		<div class="Container_ContentBody_ListView"> FOR LIST VIEW CONTAINER</div>

	</div> <%--  ||  BEGIN-INSET-3  ||==  { CONTENT-PLACEHOLDER-BODY } ==||  --%>


</asp:Content>
