using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Lottery.Models;
using Project.Lottery.Models.Delegates;
using Project.Lottery.Models.Collections;
using Project.Lottery.BLL;

namespace Project.Lottery.Webforms.UserControls
{
    public partial class ContentBodyNavControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindLotteryGameDropDownList();

        }

        public string currentGameId { get; set; }


        //====  FOR BINDING LOTTERY GAME NAME TO DROP DOWN BOX  ====||
        public void BindLotteryGameDropDownList()
        {
            LotteryDetailCollection tmpCollect = LotteryDetailBLL.GetCollection();

            tmpCollect.Insert(0, new LotteryDetail { LotteryName = "(Select a Game)", LotteryId = 0 });

            drp_LotteryGameName.DataSource = tmpCollect;
            drp_LotteryGameName.DataBind();

        }

        protected void drp_LotteryGameName_SelectedIndexChanged(object sender, EventArgs e)
        {
            UCDropDownEventDelegate ddEvent = new UCDropDownEventDelegate();
            ddEvent.OnEventRefresh(sender, e);

        }
    }
}