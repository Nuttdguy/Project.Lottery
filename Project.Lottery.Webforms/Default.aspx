<%@ Page Language="C#" Theme="Main" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project.Lottery.Webforms.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
		<title>Home | Lottery Navigation </title>
</head>
<body>
		<form id="form1" runat="server">
		<div id="Container_Main">

			<div class="Container_Welcome">
				<h1>Lottery Management System</h1>
			</div>

<%--			<div class="Container_Image">
				<img src="http://www.rakeback.com/media/content/4e0ec-vip-lottery.jpg" alt="Lottery Balls" /> 
			</div>--%>

			<div class="Container_Navigation">
				<ul>
					<li><a href="Admin/GameManage.aspx"> Manage Lottery Names</a></li>
					<li><a href="Admin/DrawingManage.aspx"> Manage Lottery Drawings</a></li>
					<li><a href="Admin/WinningNumberManage.aspx"> Manage Winning Numbers</a></li>
					<li><a href="Admin/GameAvailableManage.aspx"> Manage Lottery Locations</a></li>
				</ul>
			</div>

		</div>
		</form>
</body>
</html>
