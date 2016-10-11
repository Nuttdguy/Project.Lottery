<%@ Page Title="Game Manage Client" Theme="Main" Language="C#" MasterPageFile="~/MasterPages/BaseSkin.Master" AutoEventWireup="true" CodeBehind="GameManageClient.aspx.cs" Inherits="Project.Lottery.Webforms.Admin.GameManageClient" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<script type="text/javascript" src="../Scripts/GameManageClient.js" ></script>

		<%--  ||  BEGIN-INSET-3  ||==  { CONTENT-PLACEHOLDER-BODY } ==||  --%>
	<div class="Container_ContentBody cf"> 

		<%--  ||  BEGIN-INSET-4  ||==  { GAME-CONTROL } ==||  --%>
		<div class="Container_ContentBody_Form cf">

			<%-- ||  BEGIN  ||====  FORM PANEL FOR ADDING NEW LOTTERY GAME  ====||--%>
			<div id="Form_Generic" >

				<div>
					<label>Lottery Name</label>
					<input id="js_txtLotteryName" placeholder="LotteryName" />
				</div>

				<div>
					<label for="js_txtHasSpecialBall">Has Special Ball</label>
					<input type="checkbox" id="js_txtHasSpecialBall" />
				</div>

				<div>
					<label for="js_txtHasRegularBall">Has Regular Ball</label>
					<input type="checkbox" id="js_txtHasRegularBall" />
				</div>

				<div>
					<label>Number of Game Ball(s)</label>
					<input type="number" id="js_txtNumberOfBalls" max="80" />
				</div>

				<div class="Button Button_Save">
					<button id="SaveItemButton" onclick="SaveGameName_OnClick()">Add New Game</button>
					<%--<asp:Button ID="SaveItemButton" runat="server" Text="Add New Game" OnClientClick="return SaveGameNameButton_Click()"  />--%>
				</div>

			</div> <%-- ||  END  ||====  FORM PANEL FOR ADDING NEW LOTTERY GAME  ====||--%>

		</div> 	<%--||  END  ||==  { GAME-CONTROL } ==||  --%>



		<%--  ||  BEGIN-INSET-4  ||==  { GAME-LIST-VIEW } ==||  --%>
		<div class="Container_ContentBody_ListView cf">

			<table>
				<thead>
					<tr>
						<th>&nbsp;</th>
						<th>LotteryId</th>
						<th>Lottery Name</th>
						<th>Special Ball</th>
						<th>Regular Ball</th>
						<th># Game Balls</th>
					</tr>
				</thead>
				
				<tbody class="js_LotteryList" >
<%--					<tr>
						<td>
							<button value="LotteryId" class="js_EditButton"  onclick="js_EditOnClick()">Edit</button>
							<button value="LotteryId" class="js_DeleteButton" onclick="js_DeleteOnClick() ">Delete</button>
						</td>
						<td class="js_LotteryId" ></td>
						<td class="js_LotteryName" ></td>
						<td class="js_HasSpecialBall" ></td>
						<td class="js_HasRegularBall" ></td>
						<td class="js_NumberOfBalls" ></td> 
					</tr>--%>
				</tbody>
			</table>

		</div>  <%--||  END  ||==  { GAME-LIST-VIEW } ==||  --%>


	</div>  <%--||  END  ||==  { CONTENT-PLACEHOLDER-BODY } ==||  --%>

</asp:Content>
