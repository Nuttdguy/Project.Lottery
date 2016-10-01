using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Lottery.Models;
using Project.Lottery.Models.Extensions;
using Project.Lottery.Models.Delegates;
using Project.Lottery.Models.Collections;
using Project.Lottery.BLL;

namespace Project.Lottery.Webforms.UserControls
{
    public partial class GameListViewControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            UCDropDownEventDelegate.selectedEvent += new UCDropDownEventDelegate.OnSelectedChangeEvent(UCDropDownEvent);

        }

        public void BindListView(int id)
        {
            LotteryDetailCollection tmpCollect = LotteryDetailBLL.GetCollection();
            
            rptListView.DataSource = tmpCollect;
            rptListView.DataBind();

        }

        void UCDropDownEvent(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            int id = ddl.SelectedValue.ToInt();
            BindListView(id);
        }


        protected void rptListView_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                LotteryDetail tmpItem = (LotteryDetail)e.Item.DataItem;

                Button edit = (Button)e.Item.FindControl("Edit");
                Button delete = (Button)e.Item.FindControl("Delete");

                edit.CommandArgument = tmpItem.LotteryId.ToString();
                delete.CommandArgument = tmpItem.LotteryId.ToString();
            }
        }


    }
}