using System;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using Project.Lottery.Webforms.Models;
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

        private string _baseGameAvailableUrl = "http://localhost:64999/Game/Location/";
        private string _baseGameDetailUrl = "http://localhost:64999/Game/Detail/";

        #region SECTION 1 ||=======  BIND EVENTS  =======||

        #region ||=======  BIND SELECTED INFO FROM LIST-VIEW TO TEXT-BOX-FIELDS  =======||
        public void BindUpdateInfo(int id)
        {
            using (WebClient webClient = new WebClient())
            {
                //===  GET THE SELECTED LOCATION RECORD; BIND TO TEXT BOX FIELD  ===\\
                if (id > 0 && string.IsNullOrEmpty(txtState.Text))
                {
                    JsonSerialize jsonItem = new JsonSerialize();
                    string json = webClient.DownloadString(_baseGameAvailableUrl + id.ToString());
                    ClientLotteryDetailDTO tmpItem = jsonItem.SerializeItem<ClientLotteryDetailDTO>(json);

                    txtLocationId.Text = tmpItem.LocationId.ToString();
                    txtState.Text = tmpItem.State.ToString();

                    hidLotteryId.Value = tmpItem.LotteryId.ToString();
                }
                if (!string.IsNullOrEmpty(txtState.Text))
                    drpLotteryGames.Enabled = true;

                SetButtonTextValue();
            }

        }
        #endregion

        #region ||=======  REQUEST DATA | BIND RESULT TO LOTTERY-GAME DROP DOWN  =======||
        public void BindLotteryNames()
        {
            using (WebClient webClient = new WebClient())
            {
                JsonSerialize jsonCollect = new JsonSerialize();
                string json = webClient.DownloadString(_baseGameDetailUrl + "List/");
                List<ClientLotteryDetailDTO> tmpItem = jsonCollect.SerializeCollection<ClientLotteryDetailDTO>(json);

                drpLotteryGames.SelectedValue = hidLotteryId.Value;
                tmpItem.Insert(0, new ClientLotteryDetailDTO { LotteryName = "(Select Game)", LotteryId = 0 });

                drpLotteryGames.DataSource = tmpItem;
                drpLotteryGames.DataBind();

            }

        }
        #endregion

        #region ||=======  REQUEST DATA | BIND RESULT IN LIST-VIEW BY EITHER SELECTED GAME OR NOT | PARAM LOTTERY-ID, NONE(OP) ======||
        public void BindListView(int id)
        {
            using (WebClient webClient = new WebClient())
            {

                JsonSerialize tmp = new JsonSerialize();
                List<ClientLotteryDetailDTO> tmpCollect = null;


                if (id > 0) //==||  GET W/ LOTTERY-GAME FILTER  ||==\\
                {
                    string json = webClient.DownloadString(_baseGameAvailableUrl + "List/" + id.ToString());
                    tmpCollect = tmp.SerializeCollection<ClientLotteryDetailDTO>(json);

                    if (tmpCollect == null)
                        drpLotteryGames.Enabled = true;
                    else
                        drpLotteryGames.Enabled = false;
                }
                else //==||  GET W/O LOTTERY-GAME FILTER  ||==\\
                {
                    string json = webClient.DownloadString(_baseGameAvailableUrl + "List/");
                    tmpCollect = tmp.SerializeCollection<ClientLotteryDetailDTO>(json);

                    if (!string.IsNullOrEmpty(txtState.Text))
                        drpLotteryGames.Enabled = true;
                    else
                        drpLotteryGames.Enabled = false;
                }

                hidLotteryId.Value = id.ToString();
                rptListView.DataSource = tmpCollect;
                rptListView.DataBind();

            }

        }
        #endregion

        #region ||=======  UTILIZE DELEGATE | CAPTURE SELECTED VALUE FROM GAME-NAME DROPDOWN | SET HIDDEN FIELD  =======||
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
        #endregion

        #region ||=======  BIND EDIT/DELETE BUTTON | ASSOCIATE DESIRED ID TO EACH OCCURANCE  =======||
        protected void rptListView_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ClientLotteryDetailDTO tmpItem = (ClientLotteryDetailDTO)e.Item.DataItem;

                Button edit = (Button)e.Item.FindControl("Edit");
                Button delete = (Button)e.Item.FindControl("Delete");

                edit.CommandArgument = tmpItem.LocationId.ToString();
                delete.CommandArgument = tmpItem.LocationId.ToString();
            }
        }

        #endregion

        #endregion

        #region SECTION 2 ||=======  PROCESS  =======||

        #region ||=======  RELOAD PAGE | REDIRECT TO SELF  =======||
        protected void ReloadPage()
        {
            Response.Redirect("GameAvailableManage.aspx");
        }

        #endregion

        #region ||=======  CLEAR | TEXTBOX FIELDS  ========||
        public void ClearTextValue()
        {
            txtLocationId.Text = string.Empty;
            txtState.Text = string.Empty;
        }
        #endregion

        #region ||=======  SET BUTTON TEXT VALUE  =======||
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

        #region SECTION 3 ||=======  EVENTS  =======||

        #region ||=======  CLICK-BTN | DELETE OBJECT | PARAM LOCATION-ID, LOTTERY-ID  =======||
        protected void DeleteItem(int locId, int lottoId)
        {
            int deletedRecord = LocationBLL.DeleteItem(locId, lottoId);
        }
        #endregion

        #region ||=======  CLICK-BTN | SAVE OBJECT | SEND OBJECT TO SAVE | SET HIDDEN FIELD, SELECTED DORP-DOWN VALUE, CLEAR FIELDS  =======|| 
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

        #region ||=======  REPEATER CLICK-BTN | EDIT OR DELETE GAME-COMMAND  =======||
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

    }
}