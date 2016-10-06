using System;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Project.Lottery.Webforms.Models;
using Project.Lottery.Models.Delegates;
using Project.Lottery.Models.Extensions;
using Project.Lottery.Models.Enums;



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

        private string _baseWinningNumberUrl = "http://localhost:64999/Game/WinningNumber/";
        private string _baseBallTypeUrl = "http://localhost:64999/Ball/";

        #region SECTION 1 ||=======  BIND EVENTS  =======||

        #region ||=======  BIND SELECTED INFO FROM LIST-VIEW TO TEXT-BOX-FIELDS =======||
        public void BindUpdateInfo(int id)
        {

            using (WebClient webClient = new WebClient())
            {

                if (id != 0)
                {
                    JsonSerialize tmp = new JsonSerialize();
                    string json = webClient.DownloadString(_baseWinningNumberUrl + id.ToString());
                    LotteryDetailDTO tmpItem = tmp.SerializeItem<LotteryDetailDTO>(json);

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

        }
        #endregion

        #region ||=======  REQUEST DATA | BIND RESULT TO DROP-DOWN  =======||
        public void BindBallType()
        {
            using (WebClient webClient = new WebClient())
            {
                JsonSerialize tmp = new JsonSerialize();
                string json = webClient.DownloadString(_baseBallTypeUrl + "BallType/");
                List<BallTypeDTO> tmpCollect = tmp.SerializeCollection<BallTypeDTO>(json);

                tmpCollect.Insert(0, new BallTypeDTO { BallTypeDescription = "(Select Ball Type)", BallTypeId = 0 });
                drpBallType.DataSource = tmpCollect;
                drpBallType.DataBind();
            }

        }
        #endregion

        #region ||=======  REQUEST DATA | BIND RESULT IN LIST-VIEW BY SELECTED-GAME | PARAM LOTTERY-ID  =======||
        public void BindListView(int lottoId)
        {
            using (WebClient webClient = new WebClient())
            {
                JsonSerialize tmp = new JsonSerialize();
                string json = webClient.DownloadString(_baseWinningNumberUrl + "List/" + lottoId.ToString());
                List<LotteryDetailDTO> tmpCollect = tmp.SerializeCollection<LotteryDetailDTO>(json);

                ClearTextValue();
                rptListView.DataSource = tmpCollect;
                rptListView.DataBind();

            }

        }
        #endregion

        #region ||=======  REQUEST DATA | BIND RESULT IN LIST-VIEW BY DRAW-ID | PARAM DRAW-ID, TYPE-OF-ID  =======||
        public void BindListView(int drawId, int idType)
        {
            string serviceUrl = _baseWinningNumberUrl + "List/" + drawId.ToString() + "," + idType.ToString();

            using (WebClient webClient = new WebClient())
            {
                JsonSerialize tmp = new JsonSerialize();
                string json = webClient.DownloadString(serviceUrl);
                List<LotteryDetailDTO> tmpCollect = tmp.SerializeCollection<LotteryDetailDTO>(json);

                ClearTextValue();
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

            if (id <= 0)
                SaveItemButton.Text = "Add Winning #";

            hidLotteryId.Value = id.ToString();
            BindListView(id);
        }
        #endregion

        #region ||=======  BIND EDIT/DELETE BUTTON | ASSOCIATE DESIRED ID TO EACH OCCURANCE  =======||
        protected void rptListView_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LotteryDetailDTO tmpItem = (LotteryDetailDTO)e.Item.DataItem;

                Button edit = (Button)e.Item.FindControl("Edit");
                Button delete = (Button)e.Item.FindControl("Delete");

                edit.CommandArgument = tmpItem.WinningNumberId.ToString();
                delete.CommandArgument = tmpItem.WinningNumberId.ToString();
            }
        }
        #endregion

        #endregion


        #region SECTION 2 ||=======  PROCESS  =======||

        #region ||=======  RELOAD PAGE | REDIRECT TO SELF  =======||
        protected void ReloadPage()
        {
            Response.Redirect("WinningNumberManage.aspx");
        }

        #endregion

        #region ||=======  CLEAR | TEXT FIELDS, SET DROP-DOWN-SELECTED  ========||
        public void ClearTextValue()
        {
            txtBallNumber.Text = string.Empty;
            txtDrawingId.Text = string.Empty;
            txtWinningNumberId.Text = string.Empty;
            drpBallType.SelectedValue = "0";
        }


        #endregion

        #region ||=======  RESULT MESSAGE | DISPLAY HIDDEN FIELD - MESSAGE  =======||
        protected void DisplayResultMessage()
        {
            hidResultMessageArea.Value = "Operation was a success!";
            hidResultMessageArea.Visible = true;
        }

        #endregion

        #endregion


        #region SECTION 3 ||=======  EVENTS  =======||

        #region ||=======  CLICK-BTN | DELETE OBJECT | PARAM WINNING-NUMBER-ID =======||
        protected void DeleteItem(int winNumId)
        {
            string serviceUrl = _baseWinningNumberUrl + winNumId.ToString();

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage responseMessage = httpClient.DeleteAsync(serviceUrl).Result)
                {
                    if (responseMessage.IsSuccessStatusCode)
                        ReloadPage();
                }
            }
        }
        #endregion


        #region ||=======  CLICK-BTN | SAVE OBJECT | SEND OBJECT TO SAVE | SET HIDDEN FIELD VALUES  =======||
        protected void SaveItemButton_Click(object sender, EventArgs e)
        {
            LotteryDetailDTO tmpItem = new LotteryDetailDTO();


            if (tmpItem.WinningNumberId != 0)
                tmpItem.WinningNumberId = txtWinningNumberId.Text.ToInt();

            tmpItem.LotteryDrawingId = txtDrawingId.Text.ToInt();
            tmpItem.BallNumber = txtBallNumber.Text.ToInt();
            tmpItem.BallTypeId = drpBallType.SelectedValue.ToInt();

            using (HttpClient httpClient = new HttpClient())
            {
                //==||  TESTED SERVICE, BLL, DAL ALL WORKING >> CONTENT-TYPE: APPLICATION/JSON IS CAUSING ERROR  ||==\\
                using (HttpResponseMessage responseMessage = httpClient.PutAsJsonAsync( _baseWinningNumberUrl, tmpItem).Result)
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        ReloadPage();
                        ClearTextValue();
                        SaveItemButton.Text = "Add Winning #";
                    }
                }
            }


            hidLotteryId.Value = tmpItem.LotteryId.ToString();
            hidDrawingId.Value = tmpItem.LotteryDrawingId.ToString();
            hidWinningNumberId.Value = tmpItem.WinningNumberId.ToString();

            ClearTextValue();
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

        #region ||=======  CLICK-BTN | NARROW LIST VIEW BY DRAW-ID | SEND REQUEST TO BIND-LIST-VIEW METHOD  =======||
        protected void viewByDrawingId_Click(object sender, EventArgs e)
        {
            int drawId = txtDrawingId.Text.ToInt();
            //=======  SET THE TYPE OF ID-PARAMETER THAT WILL BE UTILIZED FOR RETRIEVING DATA  ======\\
            int idType = (int)IdType.LotteryDrawingId;

            BindListView(drawId, idType);
        }

        #endregion

        #endregion


    }
}