<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContentBodyNavControl.ascx.cs" Inherits="Project.Lottery.Webforms.UserControls.ContentBodyNavControl" %>


<div class="Container_ContentBody_Nav cf">
	<script type="text/javascript" src="../Scripts/ContentBodyNavControl.js" ></script>

	<%--  ||  BEGIN-INSET-3  ||==  { INNER-CONTAINER-CONTENTBODY-NAV } ==||  --%>
	<div class="IContainer_ContentBody_Nav">

		<asp:Label runat="server" ID="lblTestUC"> </asp:Label>

		<%--  ||  BEGIN-INSET-4  ||==  { LOTTERY-GAME-DROPDOWNLIST } ==||  --%>
		<div class="ILotteryGame_DropDownList">
			<label>Select A Lottery Game</label>
			<select id="js_drpDownGameName" class="js_drpDownGameName" onchange="onChange_drpDownGameName()" >
				<option value="0" >(Select a game)</option>
			</select>
<%--			<asp:DropDownList ID="drp_LotteryGameName" runat="server" DataTextField="LotteryName" DataValueField="LotteryId" AutoPostBack="true" OnSelectedIndexChanged="drp_LotteryGameName_SelectedIndexChanged"></asp:DropDownList>--%>
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
