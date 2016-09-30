<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContentBodyNavControl.ascx.cs" Inherits="Project.Lottery.Webforms.UserControls.ContentBodyNavControl" %>


<div class="Container_ContentBody_Nav">

	<%--  ||  BEGIN-INSET-3  ||==  { INNER-CONTAINER-CONTENTBODY-NAV } ==||  --%>
	<div class="IContainer_ContentBody_Nav cf">


		<%--  ||  BEGIN-INSET-4  ||==  { LOTTERY-GAME-DROPDOWNLIST } ==||  --%>
		<div class="ILotteryGame_DropDownList">
			<label>Select A Lottery Game</label>
			 <asp:DropDownList ID="drp_LotteryGameName" runat="server" DataTextField="LotteryName" DataValueField="LotteryId" ></asp:DropDownList>
		</div>  <%--  ||  END ||==  { LOTTERY-GAME-DROPDOWNLIST } ==||  --%>



		<%--  ||  BEGIN-INSET-4  ||==  { LOTTERY-GAME-ADDBUTTON } ==||  --%>
		<div class="ILotteryGame_AddButton" >
			<span>
				<label> Add New Record </label>
				<asp:Button ID="LotteryGameAdd" runat="server" Text="Add"/>
			</span>
		</div>  <%--  ||  END  ||==  { LOTTERY-GAME-ADDBUTTON } ==||  --%>


	</div>  <%--  ||  END  ||==  { INNER-CONTAINER-CONTENTBODY-NAV } ==||  --%>

</div>
