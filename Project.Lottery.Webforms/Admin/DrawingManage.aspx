<%@ Page Title="Drawing Manage" Theme="Main" Language="C#" MasterPageFile="~/MasterPages/BaseSkin.Master" AutoEventWireup="true" CodeBehind="DrawingManage.aspx.cs" Inherits="Project.Lottery.Webforms.Admin.DrawingManage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


	<%--  ||  BEGIN-INSET-3  ||==  { CONTENT-PLACEHOLDER-BODY } ==||  --%>
	<div class="Container_ContentBody cf"> 
		<asp:HiddenField ID="hidLotteryId" runat="server" />
		<asp:HiddenField ID="hidDrawingId" runat="server" />

		<%--  ||  BEGIN-INSET-4  ||==  { GAME-CONTROL } ==||  --%>
		<div class="Container_ContentBody_Form cf">

			<%--<asp:Panel ID="MessageArea" runat="server" >TEMP ERROR MESSAGE AREA </asp:Panel>--%>
			<asp:HiddenField ID="hidResultMessageArea" runat="server" ></asp:HiddenField>

			<%-- ||  BEGIN  ||====  FORM PANEL FOR ADDING NEW LOTTERY GAME  ====||--%>
			<div id="Form_Generic" >
				<asp:Panel runat="server" ID="panelForm" >

					<div>
						<label>Drawing ID</label>
						<asp:TextBox runat="server" Enabled="false" ID="txtDrawingId" TextMode="Number" />
					</div>

					<div>
						<label>Jackpot Amount</label>
						<asp:TextBox runat="server" ID="txtJackpot" />
					</div>

					<div>
						<label>Cash Amount</label>
						<asp:TextBox runat="server" ID="txtCashOption" />
					</div>

					<div>
						<label>Drawing Date</label>
						<asp:TextBox runat="server" ID="txtDrawingDate" />
					</div>

					<div class="Button Button_Save">
						<asp:Button runat="server" ID="SaveItemButton" Text="Add New Game"  OnClick="SaveItemButton_Click" />
					</div>

				</asp:Panel>
			</div> <%-- ||  END  ||====  FORM PANEL FOR ADDING NEW LOTTERY GAME  ====||--%>

		</div> 	<%--||  END  ||==  { GAME-CONTROL } ==||  --%>



		<%--  ||  BEGIN-INSET-4  ||==  { GAME-LIST-VIEW } ==||  --%>
		<div class="Container_ContentBody_ListView">

			<asp:Label ID="lblMessageArea" runat="server" ></asp:Label>
	
			<asp:Repeater runat="server" ID="rptListView" OnItemDataBound="rptListView_ItemDataBound" >
				<HeaderTemplate>
					<table>
						<tr>
							<th class="editCol">&nbsp;</th>
							<th>Drawing ID</th>
							<th>Jackpot</th>
							<th>Drawing Date</th>
						</tr>
				</HeaderTemplate>

				<ItemTemplate>
					<tr>
						<td class="editCol">
							<asp:Button runat="server" ID="Edit" CommandName="Edit" Text="Edit" OnCommand="Game_Command" />
							<asp:Button runat="server" ID="Delete" CommandName="Delete" Text="Delete"  OnCommand="Game_Command"/>
						</td>
						<td><%# Eval("LotteryDrawingId") %></td>
						<td><%# DataBinder.Eval(Container.DataItem, "Jackpot", "$ {0:C}") %></td>
						<td><%# DataBinder.Eval(Container.DataItem, "DrawDate", "{0:M/d/yyyy}" ) %></td>
					</tr>
				</ItemTemplate>

				<AlternatingItemTemplate>
					<tr>
						<td class="editCol">
							<asp:Button runat="server" ID="Edit" CommandName="Edit" Text="Edit" OnCommand="Game_Command" />
							<asp:Button runat="server" ID="Delete" CommandName="Delete" Text="Delete"  OnCommand="Game_Command"/>
						</td>
						<td><%# Eval("LotteryDrawingId") %></td>
						<td><%# DataBinder.Eval(Container.DataItem, "Jackpot", "$ {0:c}") %></td>
						<td><%# DataBinder.Eval(Container.DataItem, "DrawDate", "{0:M/d/yyyy}") %></td>
					</tr>
				</AlternatingItemTemplate>

				<FooterTemplate>
					</table>
				</FooterTemplate>

			</asp:Repeater>


		</div>  <%--||  END  ||==  { GAME-LIST-VIEW } ==||  --%>


	</div>  <%--||  END  ||==  { CONTENT-PLACEHOLDER-BODY } ==||  --%>

</asp:Content>
