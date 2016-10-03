using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Lottery.Models.Collections;
using Project.Lottery.Models.Delegates;
using Project.Lottery.Models.Extensions;
using Project.Lottery.Models;
using Project.Lottery.BLL;

namespace Project.Lottery.Webforms.Admin
{
    public partial class WinningNumberManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UCDropDownEventDelegate.selectedEvent += new UCDropDownEventDelegate.OnSelectedChangeEvent(UCDropDownEvent);
            if (!IsPostBack)
            {
                BindBallType();
            }
        }


        #region SECTION 1 ||=======  BIND EVENTS  =======||
        public void BindUpdateInfo(int id)
        {

            if (id != 0)
            {
                LotteryDetail tmpItem = WinningNumberBLL.GetItem(id);

                txtWinningNumberId.Text = tmpItem.WinningNumberId.ToString();

                txtDrawingId.Text = tmpItem.LotteryDrawingId.ToString();
                txtBallNumber.Text = tmpItem.BallNumber.ToString();
                drpBallType.SelectedValue = tmpItem.BallTypeId.ToString();


                hidLotteryId.Value = tmpItem.LotteryId.ToString();
                hidDrawingId.Value = tmpItem.LotteryDrawingId.ToString();
                hidWinningNumberId.Value = tmpItem.WinningNumberId.ToString();

                SaveItemButton.Text = "Update Drawing";
            }
            else if (id == 0)
            {
                ClearTextValue();
                SaveItemButton.Text = "Add Winning #";
            }


        }

        public void BindBallType()
        {
            BallTypeCollection tmpCollect = BallTypeBLL.GetCollection();
            tmpCollect.Insert(0, new BallType { BallTypeDescription = "(Select Ball Type)", BallTypeId = 0 });

            drpBallType.DataSource = tmpCollect;
            drpBallType.DataBind();
        }

        public void BindListView(int id)
        {
            LotteryDetailCollection tmpCollect = WinningNumberBLL.GetCollection(id);

            ClearTextValue();
            rptListView.DataSource = tmpCollect;
            rptListView.DataBind();


        }

        void UCDropDownEvent(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            int id = ddl.SelectedValue.ToInt();

            if (id <= 0)
                SaveItemButton.Text = "Add Winning #";

            hidLotteryId.Value = id.ToString();
            BindListView(id);
        }


        protected void rptListView_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LotteryDetail tmpItem = (LotteryDetail)e.Item.DataItem;

                Button edit = (Button)e.Item.FindControl("Edit");
                Button delete = (Button)e.Item.FindControl("Delete");

                edit.CommandArgument = tmpItem.WinningNumberId.ToString();
                delete.CommandArgument = tmpItem.WinningNumberId.ToString();
            }
        }


        #endregion





        #region SECTION 2 ||=======  PROCESS  =======||

        #region ||=======  DELETE CLICK-BTN
        protected void DeleteItem(int id)
        {
            int deletedRecord = WinningNumberBLL.DeleteItem(id);
        }


        #endregion

        #region ||=======  RELOAD PAGE
        protected void ReloadPage()
        {
            Response.Redirect("WinningNumberManage.aspx");
            DisplayResultMessage();
        }

        #endregion

        #region ||=======  CLEAR TEXTBOX FIELDS  ========||
        public void ClearTextValue()
        {
            txtBallNumber.Text = string.Empty;
            txtDrawingId.Text = string.Empty;
            txtWinningNumberId.Text = string.Empty;
            drpBallType.SelectedValue = "0";
        }


        #endregion

        #region ||=======  DISPLAY RESULT MESSAGE
        protected void DisplayResultMessage()
        {
            hidResultMessageArea.Value = "Operation was a success!";
            hidResultMessageArea.Visible = true;
        }

        #endregion


        #endregion





        #region SECTION 3 ||=======  EVENTS  =======||

        #region ||=======  SAVE CLICK-BTN
        protected void SaveItemButton_Click(object sender, EventArgs e)
        {
            LotteryDetail tmpItem = new LotteryDetail();

            tmpItem.WinningNumberId = txtWinningNumberId.Text.ToInt();

            tmpItem.LotteryDrawingId = txtDrawingId.Text.ToInt();
            tmpItem.BallNumber = txtBallNumber.Text.ToInt();
            tmpItem.BallTypeId = drpBallType.SelectedValue.ToInt();

            int recordId = WinningNumberBLL.SaveItem(tmpItem);

            if (recordId > 0)
            {
                ClearTextValue();
                SaveItemButton.Text = "Add Winning #";
            }

            hidLotteryId.Value = tmpItem.LotteryId.ToString();
            hidDrawingId.Value = tmpItem.LotteryDrawingId.ToString();
            hidWinningNumberId.Value = tmpItem.WinningNumberId.ToString();

            ClearTextValue();
        }

        #endregion

        #region ||=======  EDIT/DELETE GAME COMMAND BUTTON  =======||
        protected void Game_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Edit":
                    BindUpdateInfo(e.CommandArgument.ToString().ToInt());
                    break;
                case "Delete":
                    DeleteItem(e.CommandArgument.ToString().ToInt());
                    ReloadPage();
                    break;
            }
        }


        #endregion

        #endregion

    }
}