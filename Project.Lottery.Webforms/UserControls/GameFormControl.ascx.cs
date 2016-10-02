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

            if (id != 0)
            {
                LotteryDetail tmpItem = LotteryDetailBLL.GetItem(id);

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
                btn_NewLotteryGame.Text = "Update Game";
            }
            else if (id == 0)
            {
                txtLotteryName.Text = string.Empty;
                txtNumberOfBalls.Text = string.Empty;
                chkHasRegularBall.Checked = false;
                chkHasSpecialBall.Checked = false;
                btn_NewLotteryGame.Text = "Add New Game";
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