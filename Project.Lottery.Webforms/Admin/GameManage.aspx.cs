﻿using System;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Project.Lottery.Webforms.Models;
using Project.Lottery.Models.Delegates;
using Project.Lottery.Models.Extensions;

using Project.Lottery.Models.Enums;
using Project.Lottery.Models;
using Project.Lottery.BLL;


namespace Project.Lottery.Webforms.Admin
{
    public partial class GameManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            UCDropDownEventDelegate.selectedEvent += new UCDropDownEventDelegate.OnSelectedChangeEvent(UCDropDownEvent);
        }

        private string _baseGameServiceUrl = "http://localhost:64999/Game/";

        #region SECTION 1 ||=======  BIND EVENTS  =======||

        #region ||=======  BIND SELECTED INFO FROM LIST-VIEW  =======||
        public void BindUpdateInfo(int id)
        {
            using (WebClient webClient = new WebClient())
            {
                if (id != 0)
                {
                    JsonSerialize tmp = new JsonSerialize();
                    string json = webClient.DownloadString(_baseGameServiceUrl + "Detail/" + id.ToString());
                    LotteryDetailDTO tmpItem = tmp.SerializeItem<LotteryDetailDTO>(json);

                    txtLotteryName.Text = tmpItem.LotteryName;

                    if (tmpItem.HasSpecialBall)
                        chkHasSpecialBall.Checked = true;
                    else
                        chkHasSpecialBall.Checked = false;

                    if (tmpItem.HasRegularBall)
                        chkHasRegularBall.Checked = true;
                    else
                        chkHasRegularBall.Checked = false;

                    txtNumberOfBalls.Text = tmpItem.NumberOfBalls.ToString();
                    SaveItemButton.Text = "Update Game";
                }
                else if (id == 0)
                {
                    txtLotteryName.Text = string.Empty;
                    txtNumberOfBalls.Text = string.Empty;
                    chkHasRegularBall.Checked = false;
                    chkHasSpecialBall.Checked = false;
                    SaveItemButton.Text = "Add New Game";
                }

                hidLotteryId.Value = id.ToString();

            }


        }
        #endregion

        #region ||=======  REQUEST DATA | BIND RESULT IN LIST-VIEW  =======||
        public void BindListView()
        {
            using (WebClient webClient = new WebClient())
            {
                JsonSerialize tmp = new JsonSerialize();
                string json = webClient.DownloadString(_baseGameServiceUrl + "Detail/List/");
                List<LotteryDetailDTO> tmpCollect = tmp.SerializeCollection<LotteryDetailDTO>(json);

                rptListView.DataSource = tmpCollect;
                rptListView.DataBind();
            }

        }
        #endregion

        #region ||=======  UTILIZE DELEGATE; CAPTURE SELECTED VALUE FROM GAME-NAME DROPDOWN  =======||
        private void UCDropDownEvent(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            int id = ddl.SelectedValue.ToInt();
            BindUpdateInfo(id);
            BindListView();
        }
        #endregion

        #region ||=======  BIND EDIT/DELETE BUTTON; ASSOCIATE DESIRED ID TO EACH  =======||
        protected void rptListView_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LotteryDetailDTO tmpItem = (LotteryDetailDTO)e.Item.DataItem;

                Button edit = (Button)e.Item.FindControl("Edit");
                Button delete = (Button)e.Item.FindControl("Delete");

                edit.CommandArgument = tmpItem.LotteryId.ToString();
                delete.CommandArgument = tmpItem.LotteryId.ToString();
            }
        }
        #endregion

        #endregion



        #region SECTION 2 ||=======  PROCESS  =======||

        #region ||=======  RELOAD PAGE; REDIRECT TO SELF  =======||
        protected void ReloadPage()
        {
            Response.Redirect("GameManage.aspx");
        }

        #endregion

        #endregion



        #region SECTION 3 ||=======  EVENTS  =======||

        #region ||=======  CLICK-BTN | DELETE  =======||
        protected void DeleteItem(int id)
        {
            int deletedRecord = LotteryDetailBLL.DeleteItem(id);
            ReloadPage();

        }

        #endregion

        #region ||=======  CLICK-BTN | SAVE BUTTON  =======||
        protected void SaveItemButton_Click(object sender, EventArgs e)
        {
            LotteryDetail tmpItem = new LotteryDetail();

            tmpItem.LotteryId = hidLotteryId.Value.ToInt();
            tmpItem.LotteryName = txtLotteryName.Text;
            tmpItem.HasSpecialBall = chkHasSpecialBall.Checked;
            tmpItem.HasRegularBall = chkHasRegularBall.Checked;
            tmpItem.NumberOfBalls = txtNumberOfBalls.Text.ToInt();

            int recordId = LotteryDetailBLL.SaveItem(tmpItem);
            ReloadPage();
            
            if (recordId > 0)
            {
                txtLotteryName.Text = string.Empty;
                txtNumberOfBalls.Text = string.Empty;
                chkHasRegularBall.Checked = false;
                chkHasSpecialBall.Checked = false;
                SaveItemButton.Text = "Add New Game";
            }
        }

        #endregion

        #region ||=======  REPEATER CLICK-BTN | EDIT OR DELETE GAME-COMMAND  =======||
        protected void Game_Command(object sender, CommandEventArgs e)
        {
            switch(e.CommandName)
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