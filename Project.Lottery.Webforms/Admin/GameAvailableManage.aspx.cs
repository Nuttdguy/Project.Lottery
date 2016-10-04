﻿using System;
using System.Web.UI.WebControls;
using Project.Lottery.Models.Collections;
using Project.Lottery.Models.Delegates;
using Project.Lottery.Models.Extensions;
using Project.Lottery.Models.Enums;
using Project.Lottery.Models;
using Project.Lottery.BLL;

namespace Project.Lottery.Webforms.Admin
{
    public partial class GameAvailableManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UCDropDownEventDelegate.selectedEvent += new UCDropDownEventDelegate.OnSelectedChangeEvent(UCDropDownEvent);

        }


        #region SECTION 1 ||=======  BIND EVENTS  =======||
        public void BindUpdateInfo(int id)
        {
            //===  GET THE SELECTED LOCATION RECORD; BIND TO TEXT BOX FIELD  ===\\
            if (id > 0 && string.IsNullOrEmpty(txtState.Text))
            {
                LotteryDetail tmpItem = LocationBLL.GetItem(id);

                txtLocationId.Text = tmpItem.LocationId.ToString();
                txtState.Text = tmpItem.State.ToString();

                hidLotteryId.Value = tmpItem.LotteryId.ToString();
            }
            if (!string.IsNullOrEmpty(txtState.Text))
                drpLotteryGames.Enabled = true;

            SetButtonTextValue();

        }

        public void BindLotteryNames()
        {
            LotteryDetailCollection tmpItem = LotteryDetailBLL.GetCollection();
            drpLotteryGames.SelectedValue = hidLotteryId.Value;

            tmpItem.Insert(0, new LotteryDetail { LotteryName = "(Select Game)", LotteryId = 0 });

            drpLotteryGames.DataSource = tmpItem;
            drpLotteryGames.DataBind();

        }


        public void BindListView(int id)
        {
            LotteryDetailCollection tmpCollect = null;
            ClearTextValue();

            if (id > 0)
            {
                tmpCollect = LocationBLL.GetCollection(id);
                if (tmpCollect == null)
                    drpLotteryGames.Enabled = true;
                else
                    drpLotteryGames.Enabled = false;
            }
            else
            {
                tmpCollect = LocationBLL.GetCollection();
                if (!string.IsNullOrEmpty(txtState.Text))
                    drpLotteryGames.Enabled = true;
                else
                    drpLotteryGames.Enabled = false;
            }

            hidLotteryId.Value = id.ToString();
            rptListView.DataSource = tmpCollect;
            rptListView.DataBind();
        }


        void UCDropDownEvent(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            int id = ddl.SelectedValue.ToInt();

            hidLotteryId.Value = id.ToString();

            BindLotteryNames();
            BindListView(id);
            SetButtonTextValue();

            if (id > 0)
            {
                drpLotteryGames.SelectedValue = hidLotteryId.Value;
                ClearTextValue();
            }
        }


        protected void rptListView_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LotteryDetail tmpItem = (LotteryDetail)e.Item.DataItem;

                Button edit = (Button)e.Item.FindControl("Edit");
                Button delete = (Button)e.Item.FindControl("Delete");

                edit.CommandArgument = tmpItem.LocationId.ToString();
                delete.CommandArgument = tmpItem.LocationId.ToString();
            }
        }

        #endregion




        #region SECTION 2 ||=======  PROCESS  =======||

        #region ||=======  DELETE CLICK-BTN
        protected void DeleteItem(int locId, int lottoId)
        {
            int deletedRecord = LocationBLL.DeleteItem(locId, lottoId);
        }


        #endregion

        #region ||=======  RELOAD PAGE
        protected void ReloadPage()
        {
            Response.Redirect("GameAvailableManage.aspx");
            DisplayResultMessage();
        }

        #endregion

        #region ||=======  CLEAR TEXTBOX FIELDS  ========||
        public void ClearTextValue()
        {
            txtLocationId.Text = string.Empty;
            txtState.Text = string.Empty;

        }

        #region ||=======  SET BUTTON TEXT VALUE
        protected void SetButtonTextValue()
        {
            if (string.IsNullOrEmpty(txtState.Text))
            {
                ClearTextValue();
                SaveItemButton.Text = "Add State";
            }
            else
                SaveItemButton.Text = "Update State";
       
        }

        #endregion


        #endregion

        #region ||=======  DISPLAY RESULT MESSAGE
        protected void DisplayResultMessage()
        {
            //hidResultMessageArea.Value = "Operation was a success!";
            //hidResultMessageArea.Visible = true;
        }

        #endregion


        #endregion





        #region SECTION 3 ||=======  EVENTS  =======||

        #region ||=======  SAVE CLICK-BTN
        protected void SaveItemButton_Click(object sender, EventArgs e)
        {
            LotteryDetail tmpItem = new LotteryDetail();

            tmpItem.LocationId = txtLocationId.Text.ToInt();
            tmpItem.State = txtState.Text;

            if (drpLotteryGames.SelectedValue != "0")
                tmpItem.LotteryId = drpLotteryGames.SelectedValue.ToInt();
            else
                tmpItem.LotteryId = hidLotteryId.Value.ToInt();


            int recordId = LocationBLL.SaveItem(tmpItem);

            hidLotteryId.Value = tmpItem.LotteryId.ToString();

            if (recordId > 0)
            {
                ClearTextValue();
                drpLotteryGames.Enabled = false;
                drpLotteryGames.SelectedValue = "0";
            }
            else
                ClearTextValue();
        }

        #endregion

        #region ||=======  EDIT/DELETE GAME COMMAND BUTTON  =======||
        protected void Game_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Edit":
                    ClearTextValue();
                    BindUpdateInfo(e.CommandArgument.ToString().ToInt());
                    break;
                case "Delete":
                    DeleteItem(e.CommandArgument.ToString().ToInt(), hidLotteryId.Value.ToInt() );
                    ReloadPage();
                    break;
            }
        }


        #endregion

        #endregion

        protected void viewByDrawingId_Click(object sender, EventArgs e)
        {
            //int drawId = txtDrawingId.Text.ToInt();
            //int idType = (int)IdType.LotteryDrawingId;
            //BindListView(drawId, idType);
        }
    }
}