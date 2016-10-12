<%@ Page Title="Game Manage Client" Theme="Main" Language="C#" MasterPageFile="~/MasterPages/BaseSkin.Master" AutoEventWireup="true" CodeBehind="DrawingManageClient.aspx.cs" Inherits="Project.Lottery.Webforms.Admin.DrawingManageClient" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<script type="text/javascript" src="../Scripts/DrawingManageClient.js" ></script>
	
	<%--  ||  BEGIN-INSET-3  ||==  { CONTENT-PLACEHOLDER-BODY } ==||  --%>
	<div class="Container_ContentBody cf"> 

		<%--  ||  BEGIN-INSET-4  ||==  { GAME-CONTROL } ==||  --%>
		<div class="Container_ContentBody_Form cf">

			<%-- ||  BEGIN  ||====  FORM PANEL FOR ADDING NEW LOTTERY GAME  ====||--%>
			<div id="Form_Generic" >

				<div>
					<label>Drawing ID</label>
					<input disabled id="js_txtDrawingId" class="js_txtDrawing" type="number" />
				</div>

				<div>
					<label>Jackpot Amount</label>
					<input id="js_txtJackpot" class="js_txtJackpot" />
					<%--<asp:TextBox runat="server" ID="txtJackpot"  CssClass="txtJackpot"  />--%>
				</div>

				<div>
					<label>Cash Amount</label>
					<input id="js_txtCashOption" class="js_txtCashOption" />
					<%--<asp:TextBox runat="server" ID="txtCashOption"  />--%>
				</div>

				<div>
					<label>Drawing Date</label>
					<input placeholder="MM/DD/YYYY" id="js_txtDrawingDate" class="txtDrawingDate" />
					<%--<asp:TextBox runat="server" ID="txtDrawingDate" CssClass="txtDrawingDate" />--%>
				</div>

				<div class="Button Button_Save">
					<button ID="SaveItemButton" OnClick="js_SaveItemButton_Click()" > Add New Game </button>
				</div>

			</div> <%-- ||  END  ||====  FORM PANEL FOR ADDING NEW LOTTERY GAME  ====||--%>

		</div> 	<%--||  END  ||==  { GAME-CONTROL } ==||  --%>



		<%--  ||  BEGIN-INSET-4  ||==  { GAME-LIST-VIEW } ==||  --%>
		<div class="Container_ContentBody_ListView">

			<table>
				<thead>
					<tr>
						<th class="editCol">&nbsp;</th>
						<th>Drawing ID</th>
						<th>Jackpot</th>
						<th>Cash Amount</th>
						<th>Drawing Date</th>
					</tr>
				</thead>

				<tbody class="js_LotteryList">
<%--					<tr>
						<td class="editCol">
							<button runat="server" ID="Edit" Text="Edit" />
							<button runat="server" ID="Delete" Text="Delete" />
						</td>
						<td><%# Eval("LotteryDrawingId") %></td>
						<td><%# Eval("Jackpot") %></td>
						<td><%# Eval("DrawDates") %></td> 
					</tr>--%>
				</tbody>

			</table>

		</div>  <%--||  END  ||==  { GAME-LIST-VIEW } ==||  --%>

	</div>  <%--||  END  ||==  { CONTENT-PLACEHOLDER-BODY } ==||  --%>

</asp:Content>
