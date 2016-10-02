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

            //if (id != 0)
            //{
            //    LotteryDetail tmpItem = LotteryDetailBLL.GetItem(id);

            //    txtDrawingId.Text = tmpItem.LotteryDrawingId.ToString();

            //    if (!string.IsNullOrEmpty(tmpItem.Jackpot))
            //        chkHasSpecialBall.Checked = true;
            //    else
            //        chkHasSpecialBall.Checked = false;

            //    if (tmpItem.HasRegularBall)
            //        chkHasRegularBall.Checked = true;
            //    else
            //        chkHasRegularBall.Checked = false;

            //    txtNumberOfBalls.Text = tmpItem.NumberOfBalls.ToString();
            //    SaveItemButton.Text = "Update Game";
            //}
            //else if (id == 0)
            //{
            //    txtLotteryName.Text = string.Empty;
            //    txtNumberOfBalls.Text = string.Empty;
            //    chkHasRegularBall.Checked = false;
            //    chkHasSpecialBall.Checked = false;
            //    SaveItemButton.Text = "Add New Game";
            //}

            //hidLotteryId.Value = id.ToString();

        }

        public void BindListView(int id)
        {
            LotteryDetailCollection tmpCollect = LotteryDrawingBLL.GetCollection();

            rptListView.DataSource = tmpCollect;
            rptListView.DataBind();

        }

        void UCDropDownEvent(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            int id = ddl.SelectedValue.ToInt();
            //BindUpdateInfo(id);
            BindListView(id);
        }


        protected void rptListView_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LotteryDetail tmpItem = (LotteryDetail)e.Item.DataItem;

                Button edit = (Button)e.Item.FindControl("Edit");
                Button delete = (Button)e.Item.FindControl("Delete");

                edit.CommandArgument = tmpItem.LotteryDrawingId.ToString();
                delete.CommandArgument = tmpItem.LotteryDrawingId.ToString();
            }
        }


        #endregion





        #region SECTION 2 ||=======  PROCESS  =======||

        #region ||=======  DELETE CLICK-BTN
        protected void DeleteItem(int id)
        {
            //int deletedRecord = LotteryDetailBLL.DeleteItem(id);
            //ReloadPage();

        }


        #endregion

        #region ||=======  RELOAD PAGE
        protected void ReloadPage()
        {
            //Response.Redirect("GameManage.aspx");
        }

        #endregion

        #region ||=======


        #endregion


        #endregion





        #region SECTION 3 ||=======  EVENTS  =======||

        #region ||=======  SAVE CLICK-BTN
        protected void SaveItemButton_Click(object sender, EventArgs e)
        {
            //LotteryDetail tmpItem = new LotteryDetail();

            //tmpItem.LotteryId = hidLotteryId.Value.ToInt();
            //tmpItem.LotteryName = txtLotteryName.Text;
            //tmpItem.HasSpecialBall = chkHasSpecialBall.Checked;
            //tmpItem.HasRegularBall = chkHasRegularBall.Checked;
            //tmpItem.NumberOfBalls = txtNumberOfBalls.Text.ToInt();

            //int recordId = LotteryDetailBLL.SaveItem(tmpItem);
            //ReloadPage();

            //if (recordId > 0)
            //{
            //    txtLotteryName.Text = string.Empty;
            //    txtNumberOfBalls.Text = string.Empty;
            //    chkHasRegularBall.Checked = false;
            //    chkHasSpecialBall.Checked = false;
            //    SaveItemButton.Text = "Add New Game";
            //}
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
                    break;
            }
        }


        #endregion

        #endregion

    }
}