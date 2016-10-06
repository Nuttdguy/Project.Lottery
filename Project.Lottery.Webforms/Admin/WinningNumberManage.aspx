<%@ Page Title="Winning Number Manage" Theme="Main" Language="C#" MasterPageFile="~/MasterPages/BaseSkin.Master" AutoEventWireup="true" CodeBehind="WinningNumberManage.aspx.cs" Inherits="Project.Lottery.Webforms.Admin.WinningNumberManage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

		<%--  ||  BEGIN-INSET-3  ||==  { CONTENT-PLACEHOLDER-BODY } ==||  --%>
	<div class="Container_ContentBody cf"> 
		<asp:HiddenField ID="hidLotteryId" runat="server" />
		<asp:HiddenField ID="hidDrawingId" runat="server" />
		<asp:HiddenField ID="hidWinningNumberId" runat="server" />

		<%--  ||  BEGIN-INSET-4  ||==  { WINNING-NUMBER-CONTROL } ==||  --%>
		<div class="Container_ContentBody_Form cf">

			<%--<asp:Panel ID="MessageArea" runat="server" >TEMP ERROR MESSAGE AREA </asp:Panel>--%>
			<asp:HiddenField ID="hidResultMessageArea" runat="server" ></asp:HiddenField>
			

			<%-- ||  BEGIN  ||====  FORM PANEL FOR SAVE AND UPDATE  ====||--%>

			<div id="Form_Generic" >
				<asp:Panel runat="server" ID="panelForm" >

					<div>
						<label>Winning Number ID</label>
						<asp:TextBox runat="server" Enabled="false" ID="txtWinningNumberId" TextMode="Number" />
					</div>

					<div>
						<label>Drawing ID</label>
						<asp:TextBox runat="server" ID="txtDrawingId" />
						<asp:Button runat="server" ID="viewByDrawingId" OnClick="viewByDrawingId_Click" Text="View By ID" />
					</div>

					<div>
						<label>Ball #</label>
						<asp:TextBox runat="server" ID="txtBallNumber" />
					</div>

					<div>
						<label>Ball Type</label>
						<asp:DropDownList runat="server" ID="drpBallType" DataTextField="BallTypeDescription" DataValueField="BallTypeId" />
					</div>

					<div class="Button Button_Save">
						<asp:Button runat="server" ID="SaveItemButton" Text="Add New Game"  OnClick="SaveItemButton_Click" />
					</div>

				</asp:Panel>
			</div> <%-- ||  END  ||====  FORM PANEL FOR SAVE AND UPDATE  ====||--%>



		</div> 	<%--||  END  ||==  { GAME-CONTROL } ==||  --%>



		<%--  ||  BEGIN-INSET-4  ||==  { WINNING-NUMBER-LIST-VIEW } ==||  --%>
		<div class="Container_ContentBody_ListView cf">

			<asp:Label ID="lblMessageArea" runat="server" ></asp:Label>
	
			<asp:Repeater runat="server" ID="rptListView" OnItemDataBound="rptListView_ItemDataBound" >
				<HeaderTemplate>
					<table>
						<tr>
							<th class="editCol">&nbsp;</th>
							<th>Winning # ID</th>
							<th>Drawing ID</th>
							<th>Ball #</th>
							<th>Ball Type</th>
							<th>Ball Description</th>
						</tr>
				</HeaderTemplate>

				<ItemTemplate>
					<tr>
						<td class="editCol">
							<asp:Button runat="server" ID="Edit" CommandName="Edit" Text="Edit" OnCommand="Game_Command" />
							<asp:Button runat="server" ID="Delete" CommandName="Delete" Text="Delete"  OnCommand="Game_Command"/>
						</td>
						<td><%# Eval("WinningNumberId") %></td>
						<td><%# Eval("LotteryDrawingId") %></td>
						<td><%# Eval("BallNumber") %></td>
						<td><%# Eval("BallTypeId") %></td>
						<td><%# Eval("BallTypeDescription")  %></td>
					</tr>
				</ItemTemplate>

				<AlternatingItemTemplate>
					<tr>
						<td class="editCol">
							<asp:Button runat="server" ID="Edit" CommandName="Edit" Text="Edit" OnCommand="Game_Command" />
							<asp:Button runat="server" ID="Delete" CommandName="Delete" Text="Delete"  OnCommand="Game_Command"/>
						</td>
						<td><%# Eval("WinningNumberId") %></td>
						<td><%# Eval("LotteryDrawingId") %></td>
						<td><%# Eval("BallNumber") %></td>
						<td><%# Eval("BallTypeId") %></td>
						<td><%# Eval("BallTypeDescription") %></td>
					</tr>
				</AlternatingItemTemplate>

				<FooterTemplate>
					</table>
				</FooterTemplate>

			</asp:Repeater>


		</div>  <%--||  END  ||==  { WINNING-NUMBER-LIST-VIEW  } ==||  --%>


	</div>  <%--||  END  ||==  { CONTENT-PLACEHOLDER-BODY } ==||  --%>

</asp:Content>
