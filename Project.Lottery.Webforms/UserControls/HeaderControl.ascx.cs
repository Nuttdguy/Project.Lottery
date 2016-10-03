using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Lottery.Models.Helpers;

namespace Project.Lottery.Webforms.UserControls
{
    public partial class HeaderControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadBannerImage();
        }

        public void LoadBannerImage()
        {
            HeaderImage.ImageUrl = ImageUrl._Powerball;
            HeaderTitle.Text = PageTitleCaptionHelper.GetPageTitle;
        }
    }
}