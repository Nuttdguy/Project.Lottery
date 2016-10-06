using System;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using Project.Lottery.Webforms.Models;
using Project.Lottery.Webforms.Delegates;
using Project.Lottery.Webforms.Extensions;


namespace Project.Lottery.Webforms.UserControls
{
    public partial class ContentBodyNavControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindLotteryGameDropDownList();
        }

        private string _baseGameServiceUrl = "http://localhost:64999/Game/Detail/List/";

        //====  FOR BINDING LOTTERY GAME NAME TO DROP DOWN BOX  ====||
        public void BindLotteryGameDropDownList()
        {
            using (WebClient webClient = new WebClient())
            {
                JsonSerialize tmp = new JsonSerialize();
                string json = webClient.DownloadString(_baseGameServiceUrl);
                List<ClientLotteryDetailDTO> tmpCollect = tmp.SerializeCollection<ClientLotteryDetailDTO>(json);

                tmpCollect.Insert(0, new ClientLotteryDetailDTO { LotteryName = "(Select a Game)", LotteryId = 0 });

                drp_LotteryGameName.DataSource = tmpCollect;
                drp_LotteryGameName.DataBind();
            } 

        }

        protected void drp_LotteryGameName_SelectedIndexChanged(object sender, EventArgs e)
        {
            UCDropDownEventDelegate ddEvent = new UCDropDownEventDelegate();
            ddEvent.OnEventRefresh(sender, e);

        }
    }
}