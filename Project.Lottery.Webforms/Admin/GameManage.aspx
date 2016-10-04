<%@ Page Title="Lottery | Game Manage" Theme="Main" Language="C#" MasterPageFile="~/MasterPages/BaseSkin.Master" AutoEventWireup="true" CodeBehind="GameManage.aspx.cs" Inherits="Project.Lottery.Webforms.Admin.GameManage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	

	<%--  ||  BEGIN-INSET-3  ||==  { CONTENT-PLACEHOLDER-BODY } ==||  --%>
	<div class="Container_ContentBody cf"> 
		<asp:HiddenField ID="hidLotteryId" runat="server" />

		<%--  ||  BEGIN-INSET-4  ||==  { GAME-CONTROL } ==||  --%>
		<div class="Container_ContentBody_Form cf">

			<asp:Panel ID="MessageArea" runat="server" >TEMP ERROR MESSAGE AREA </asp:Panel>

			<%-- ||  BEGIN  ||====  FORM PANEL FOR ADDING NEW LOTTERY GAME  ====||--%>
			<div id="Form_Generic" >
				<asp:Panel runat="server" ID="panelForm" >

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
						<asp:TextBox runat="server" ID="txtNumberOfBalls" TextMode="Number" MaxLength="2" />
					</div>

					<div class="Button Button_Save">
						<asp:Button runat="server" ID="SaveItemButton" Text="Add New Game" OnClick="SaveItemButton_Click"  />
					</div>

				</asp:Panel>
			</div> <%-- ||  END  ||====  FORM PANEL FOR ADDING NEW LOTTERY GAME  ====||--%>

		</div> 	<%--||  END  ||==  { GAME-CONTROL } ==||  --%>



		<%--  ||  BEGIN-INSET-4  ||==  { GAME-LIST-VIEW } ==||  --%>
		<div class="Container_ContentBody_ListView cf">

			<asp:Label ID="lblMessageArea" runat="server" ></asp:Label>
	
			<asp:Repeater runat="server" ID="rptListView" OnItemDataBound="rptListView_ItemDataBound" >
				<HeaderTemplate>
					<table>
						<tr>
							<th>&nbsp;</th>
							<th>LotteryId</th>
							<th>Lottery Name</th>
							<th>Special Ball</th>
							<th>Regular Ball</th>
							<th># Game Balls</th>
						</tr>
				</HeaderTemplate>

				<ItemTemplate>
					<tr>
						<td>
							<asp:Button runat="server" ID="Edit" CommandName="Edit" Text="Edit" OnCommand="Game_Command" />
							<asp:Button runat="server" ID="Delete" CommandName="Delete" Text="Delete"  OnCommand="Game_Command"/>
						</td>
						<td><%# Eval("LotteryId") %></td>
						<td><%# Eval("LotteryName") %></td>
						<td><%# string.Format("{0}", (bool)Eval("HasSpecialBall") ? "Yes" : "No") %></td>
						<td><%# string.Format("{0}", (bool)Eval("HasRegularBall") ? "Yes" : "No") %></td>
						<td><%# Eval("NumberOfBalls") %></td>
					</tr>
				</ItemTemplate>

				<AlternatingItemTemplate>
					<tr>
						<td>
							<asp:Button runat="server" ID="Edit" CommandName="Edit" Text="Edit" OnCommand="Game_Command" />
							<asp:Button runat="server" ID="Delete" CommandName="Delete" Text="Delete"  OnCommand="Game_Command"/>
						</td>
						<td><%# Eval("LotteryId") %></td>
						<td><%# Eval("LotteryName") %></td>
						<td><%# string.Format("{0}", (bool)Eval("HasSpecialBall") ? "Yes" : "No") %></td>
						<td><%# string.Format("{0}", (bool)Eval("HasRegularBall") ? "Yes" : "No") %></td>
						<td><%# Eval("NumberOfBalls") %></td>
					</tr>
				</AlternatingItemTemplate>

				<FooterTemplate>
					</table>
				</FooterTemplate>

			</asp:Repeater>


		</div>  <%--||  END  ||==  { GAME-LIST-VIEW } ==||  --%>


	</div>  <%--||  END  ||==  { CONTENT-PLACEHOLDER-BODY } ==||  --%>


</asp:Content>
