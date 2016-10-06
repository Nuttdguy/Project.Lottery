using System;
using System.Net;
using System.Net.Http;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using Project.Lottery.Models.Collections;
using Project.Lottery.Models.Delegates;
using Project.Lottery.Models.Extensions;
using Project.Lottery.Models;
using Project.Lottery.Webforms.Models;
using Project.Lottery.BLL;
using Newtonsoft.Json;



namespace Project.Lottery.Webforms.Admin
{
    public partial class DrawingManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UCDropDownEventDelegate.selectedEvent += new UCDropDownEventDelegate.OnSelectedChangeEvent(UCDropDownEvent);
        }

        private string _baseServiceUrl = "http://localhost:64999/Game/Drawing/";

        #region SECTION 1 ||=======  BIND EVENTS  =======||

        #region ||=======  BIND SELECTED INFO FROM LIST-VIEW TO TEXT-BOX FIELDS  =======||
        public void BindUpdateInfo(int id)
        {
            using (WebClient webClient = new WebClient())
            {
                if (id != 0) //==|| FORMAT VALUES BEFORE SET ||==\\
                {
                    JsonSerialize jsonItem = new JsonSerialize();
                    string json = webClient.DownloadString(_baseServiceUrl + id.ToString());
                    ClientLotteryDetailDTO tmpItem = jsonItem.SerializeItem<ClientLotteryDetailDTO>(json);

                    txtDrawingId.Text = tmpItem.LotteryDrawingId.ToString();

                    double jp = tmpItem.Jackpot.ToInt(); ;
                    txtJackpot.Text = string.Format("{0:N0}", jp);

                    double cashVal = (tmpItem.Jackpot.ToInt() * .60);
                    txtCashOption.Text = string.Format("{0:N0}", cashVal);

                    string dd = string.Format("{0:MM/dd/yyyy}", tmpItem.DrawDates);
                    txtDrawingDate.Text = dd;

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

        }

        #endregion

        #region ||=======  REQUEST DATA | BIND RESULT TO LIST-VIEW | FILTER BY GAME | PARAM LOTTERY-ID  =======||
        public void BindListView(int id)
        {

            using (WebClient webClient = new WebClient())
            {

                JsonSerialize jsonItem = new JsonSerialize();
                string json = webClient.DownloadString(_baseServiceUrl + "List/" + id.ToString());
                List<ClientLotteryDetailDTO> jsonList = jsonItem.SerializeCollection<ClientLotteryDetailDTO>(json);

                ClearTextValue();
                rptListView.DataSource = jsonList;
                rptListView.DataBind();
            }

        }
        #endregion

        #region ||=======  UTILIZE DELEGATE | CAPTURE SELECTED VALUE FROM GAME-NAME DROPDOWN | SET HIDDEN FIELD  =======|| 
        void UCDropDownEvent(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            int id = ddl.SelectedValue.ToInt();

            hidLotteryId.Value = id.ToString(); ;
            BindListView(id);
        }
        #endregion

        #region ||=======  BIND EDIT/DELETE BUTTON | ASSOCIATE DESIRED ID FOR EACH OCCURANCE  =======||
        protected void rptListView_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ClientLotteryDetailDTO tmpItem = (ClientLotteryDetailDTO)e.Item.DataItem;

                Button edit = (Button)e.Item.FindControl("Edit");
                Button delete = (Button)e.Item.FindControl("Delete");

                edit.CommandArgument = tmpItem.LotteryDrawingId.ToString();
                delete.CommandArgument = tmpItem.LotteryDrawingId.ToString();

            }
        }

        #endregion

        #endregion



        #region SECTION 2 ||=======  PROCESS  =======||

        #region ||=======  RELOAD PAGE | REDIRECT TO SELF  =======||
        protected void ReloadPage()
        {
            Response.Redirect("DrawingManage.aspx");
        }

        #endregion

        #region ||=======  CLEAR | TEXT-BOX FIELDS  ========||
        public void ClearTextValue()
        {
            txtDrawingId.Text = string.Empty;
            txtJackpot.Text = string.Empty;
            txtCashOption.Text = string.Empty;
            txtDrawingDate.Text = string.Empty;
        }


        #endregion

        #endregion



        #region SECTION 3 ||=======  EVENTS  =======||

        #region ||=======  CLICK-BTN | DELETE OBJECT | PARAM LOTTERY-DRAWING-ID  =======||
        protected void DeleteItem(int id)
        {
            int deletedRecord = LotteryDrawingBLL.DeleteItem(id);
        }
        #endregion

        #region ||=======  CLICK-BTN | SAVE OBJECT | SEND OBJECT TO SAVE | SET HIDDEN TEXT FIELD VALUES  =======||
        protected void SaveItemButton_Click(object sender, EventArgs e)
        {
            LotteryDetail tmpItem = new LotteryDetail();

            tmpItem.LotteryId = hidLotteryId.Value.ToInt();
            tmpItem.LotteryDrawingId = txtDrawingId.Text.ToInt();
            tmpItem.Jackpot = txtJackpot.Text;
            tmpItem.LotteryDrawingDate = txtDrawingDate.Text.ToDate();

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

        #region ||=======  REPEATER CLICK-BTN | EDIT OR DELETE GAME-COMMAND  =======||
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