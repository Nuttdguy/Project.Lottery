<%@ Page Title="Game Available Manage" Theme="Main" Language="C#" MasterPageFile="~/MasterPages/BaseSkin.Master" AutoEventWireup="true" CodeBehind="GameAvailableManage.aspx.cs" Inherits="Project.Lottery.Webforms.Admin.GameAvailableManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

			<%--  ||  BEGIN-INSET-3  ||==  { CONTENT-PLACEHOLDER-BODY } ==||  --%>
	<div class="Container_ContentBody cf"> 
		<asp:HiddenField ID="hidLotteryId" runat="server" />


		<%--  ||  BEGIN-INSET-4  ||==  { WINNING-NUMBER-CONTROL } ==||  --%>
		<div class="Container_ContentBody_Form cf">


			<%-- ||  BEGIN  ||====  FORM PANEL FOR SAVE AND UPDATE  ====||--%>

			<div id="Form_Generic" >
				<asp:Panel runat="server" ID="panelForm" >

					<div>
						<label>Location ID</label>
						<asp:TextBox runat="server" Enabled="false" ID="txtLocationId" TextMode="Number" />
					</div>


					<div>
						<label>State</label>
						<asp:TextBox runat="server" ID="txtState" />
					</div>

					<div>
						<label>New State to Game</label>
						<asp:DropDownList Enabled="false" runat="server" ID="drpLotteryGames" DataTextField="LotteryName" DataValueField="LotteryId" />
					</div>

					<div class="Button Button_Save">
						<asp:Button runat="server" ID="SaveItemButton" Text="Add State"  OnClick="SaveItemButton_Click" />
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
							<th>Location ID</th>
							<th>State</th>
						</tr>
				</HeaderTemplate>

				<ItemTemplate>
					<tr>
						<td class="editCol">
							<asp:Button runat="server" ID="Edit" CommandName="Edit" Text="Edit" OnCommand="Game_Command" />
							<asp:Button runat="server" ID="Delete" CommandName="Delete" Text="Delete"  OnCommand="Game_Command"/>
						</td>
						<td><%# Eval("LocationId") %></td>
						<td><%# Eval("State") %></td>
					</tr>
				</ItemTemplate>

				<AlternatingItemTemplate>
					<tr>
						<td class="editCol">
							<asp:Button runat="server" ID="Edit" CommandName="Edit" Text="Edit" OnCommand="Game_Command" />
							<asp:Button runat="server" ID="Delete" CommandName="Delete" Text="Delete"  OnCommand="Game_Command"/>
						</td>
						<td><%# Eval("LocationId") %></td>
						<td><%# Eval("State") %></td>
					</tr>
				</AlternatingItemTemplate>

				<FooterTemplate>
					</table>
				</FooterTemplate>

			</asp:Repeater>


		</div>  <%--||  END  ||==  { WINNING-NUMBER-LIST-VIEW  } ==||  --%>


	</div>  <%--||  END  ||==  { CONTENT-PLACEHOLDER-BODY } ==||  --%>

</asp:Content>
