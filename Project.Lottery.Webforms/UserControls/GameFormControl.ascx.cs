using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Lottery.Models.Delegates;
using Project.Lottery.Models.Extensions;
using Project.Lottery.Models;
using Project.Lottery.BLL;

namespace Project.Lottery.Webforms.UserControls
{
    public partial class GameFormControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            UCDropDownEventDelegate.selectedEvent += new UCDropDownEventDelegate.OnSelectedChangeEvent(UCDropDownEvent);
        }


        public void BindUpdateInfo(int id)
        {

            // string id = (string)(Session["CurrentGameId"]);
            if (id != 0)
            {
                LotteryDetail tmpItem = LotteryDetailBLL.GetItem(id);

                txtLotteryName.Text = tmpItem.LotteryName;
                if (tmpItem.HasSpecialBall)
                    chkHasSpecialBall.Checked = true;
                if (tmpItem.HasRegularBall)
                    chkHasRegularBall.Checked = true;
                txtNumberOfBalls.Text = tmpItem.NumberOfBalls.ToString();
                //Session["CurrentGameId"] = tmpItem.LotteryId.ToString();
            }
        }

        void UCDropDownEvent(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            int id = ddl.SelectedValue.ToInt();
            BindUpdateInfo(id);
        }


    }
}