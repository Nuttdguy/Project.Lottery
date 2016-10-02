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
    public partial class DrawingManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UCDropDownEventDelegate.selectedEvent += new UCDropDownEventDelegate.OnSelectedChangeEvent(UCDropDownEvent);
        }

        #region SECTION 1 ||=======  BIND EVENTS  =======||
        public void BindUpdateInfo(int id)
        {

            if (id != 0)
            {
                LotteryDetail tmpItem = LotteryDrawingBLL.GetItem(id);

                txtDrawingId.Text = tmpItem.LotteryDrawingId.ToString();
                double jp = tmpItem.Jackpot.ToInt(); ;
                txtJackpot.Text = string.Format("{0:N0}", jp);
                double cashVal = (tmpItem.Jackpot.ToInt() * .60);
                txtCashOption.Text = string.Format("{0:N0}", cashVal);
                string dd = tmpItem.DrawDate.ToShortDateString() ;
                txtDrawingDate.Text = string.Format("{0:MM/dd/yyyy}", dd);

                hidLotteryId.Value = tmpItem.LotteryId.ToString();
                hidDrawingId.Value = tmpItem.LotteryDrawingId.ToString();

                SaveItemButton.Text = "Update Drawing";
            }
            else if (id == 0)
            {
                ClearTextValue();
                SaveItemButton.Text = "Add New Drawing";
            }


        }

        public void BindListView(int id)
        {
            LotteryDetailCollection tmpCollect = LotteryDrawingBLL.GetCollection(id);

            ClearTextValue();
            rptListView.DataSource = tmpCollect;
            rptListView.DataBind();


        }

        void UCDropDownEvent(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            int id = ddl.SelectedValue.ToInt();

            hidLotteryId.Value = id.ToString(); ;
            BindListView(id);
        }


        protected void rptListView_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LotteryDetail tmpItem = (LotteryDetail)e.Item.DataItem;

                Button edit = (Button)e.Item.FindControl("Edit");
                Button delete = (Button)e.Item.FindControl("Delete");
                Button view = (Button)e.Item.FindControl("View");

                edit.CommandArgument = tmpItem.LotteryDrawingId.ToString();
                delete.CommandArgument = tmpItem.LotteryDrawingId.ToString();
                view.CommandArgument = tmpItem.LotteryDrawingId.ToString();
            }
        }


        #endregion





        #region SECTION 2 ||=======  PROCESS  =======||

        #region ||=======  DELETE CLICK-BTN
        protected void DeleteItem(int id)
        {
            int deletedRecord = LotteryDrawingBLL.DeleteItem(id);
        }


        #endregion

        #region ||=======  RELOAD PAGE
        protected void ReloadPage()
        {
            Response.Redirect("DrawingManage.aspx");
            DisplayResultMessage();
        }

        #endregion

        #region ||=======  CLEAR TEXTBOX FIELDS  ========||
        public void ClearTextValue()
        {
            txtDrawingId.Text = string.Empty;
            txtJackpot.Text = string.Empty;
            txtCashOption.Text = string.Empty;
            txtDrawingDate.Text = string.Empty;
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

            tmpItem.LotteryId = hidLotteryId.Value.ToInt();
            tmpItem.LotteryDrawingId = txtDrawingId.Text.ToInt();
            tmpItem.Jackpot = txtJackpot.Text;
            tmpItem.DrawDate = txtDrawingDate.Text.ToDate();

            int recordId = LotteryDrawingBLL.SaveItem(tmpItem);

            if (recordId > 0)
            {
                ClearTextValue();
                SaveItemButton.Text = "Add New Drawing";
            }

            hidLotteryId.Value = tmpItem.LotteryId.ToString();
            hidDrawingId.Value = tmpItem.LotteryDrawingId.ToString();

            ReloadPage();
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
                case "View":
                    Response.Redirect("DrawingDetailManage.aspx");
                    break;
            }
        }


        #endregion

        #endregion

    }
}