<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GameListViewControl.ascx.cs" Inherits="Project.Lottery.Webforms.UserControls.GameListViewControl" %>


<%--  ||  BEGIN-INSET-4  ||==  { GAME-LIST-VIEW } ==||  --%>
<div class="Container_ContentBody_ListView"> FOR LIST VIEW CONTAINER
	
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
					<asp:Button runat="server" ID="Edit" CommandName="Edit_Button" Text="Edit" />
					<asp:Button runat="server" ID="Delete" CommandName="Edit_Button" Text="Delete" />
				</td>
				<td><%# Eval("LotteryId") %></td>
				<td><%# Eval("LotteryName") %></td>
				<td><%# string.Format("{0}", (bool)Eval("HasSpecialBall") ? "Yes" : "No") %></td>
				<td><%# string.Format("{0}", (bool)Eval("HasRegularBall") ? "Yes" : "No") %></td>
				<td><%# Eval("NumberOfBalls") %></td>
			</tr>
		</ItemTemplate>

		<FooterTemplate>
			</table>
		</FooterTemplate>

	</asp:Repeater>


</div>  <%--||  END  ||==  { GAME-LIST-VIEW } ==||  --%>