using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Lottery.Models;
using Project.Lottery.Models.Extensions;
using Project.Lottery.BLL;

namespace Project.Lottery.Webforms
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

            LotteryDetail tmp = new LotteryDetail();

            tmp.LotteryId = txtLotteryId.Text.ToInt();
            tmp.LocationId = txtLocationId.Text.ToInt();
            tmp.State = txtStateName.Text;

            int recordId = LocationBLL.SaveItem(tmp);
        }
    }
}