<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GameFormControl.ascx.cs" Inherits="Project.Lottery.Webforms.UserControls.GameFormControl" %>


<div class="Container_ContentBody_Form">

	<asp:Panel ID="MessageArea" runat="server" >TEMP ERROR MESSAGE AREA </asp:Panel>

	<%-- ||  BEGIN  ||====  FORM PANEL FOR ADDING NEW LOTTERY GAME  ====||--%>
	<div id="NewLotteryGame_Form" >
		<asp:Panel runat="server" ID="NewGameLottery" >

			<div>
				<label>Lottery Name</label>
				<asp:TextBox runat="server" ID="txtLotteryName" />
			</div>

			<div>
				<label>Has Special Ball</label>
				<asp:CheckBox runat="server" ID="chkHasSpecialBall" />
			</div>

			<div>
				<label>Has Regular Ball</label>
				<asp:CheckBox runat="server" ID="chkHasRegularBall" />
			</div>

			<div>
				<label>Number of Game Ball(s)</label>
				<asp:TextBox runat="server" TextMode="Number" MaxLength="2" />
			</div>

			<div class="Button Button_Save">
				<asp:Button runat="server" ID="btn_NewLotteryGame" Text="Add New Game" />
			</div>

		</asp:Panel>
	</div> <%-- ||  END  ||====  FORM PANEL FOR ADDING NEW LOTTERY GAME  ====||--%>

</div>
