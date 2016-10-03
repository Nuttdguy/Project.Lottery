using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Lottery.Models.Helpers;
using Project.Lottery.Models.Enums;


namespace Project.Lottery.Webforms.UserControls
{
    public partial class HeaderControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadBannerImage();
        }

        #region SECTION 1 ||========  PROPERTIES  =======||

        private string _Powerball = "~/App_Themes/Main/images/powerballLogo.png";
        private string _MegaMillions = "~/App_Themes/Main/Images/megaMillionsLogo.png";
        private string _Gopher5 = "~/App_Themes/Main/images/gopher5Logo.png";
        private string _NorthstarCash = "~/App_Themes/Main/images/northstarLogo.png";

        private string _PageTitle_GameManage = "Game Manage ";
        private string _PageTitle_DrawingManage = "Drawing Manage";
        private string _PageTitle_WinningNumberManage = "Winning Number Manage ";
        private string _PageTitle_GameAvailableManage = "Game Available Manage";


        public static string[] BaseUrl
        {
            get
            {
                HttpContext context = HttpContext.Current;
                string[] baseUrl = context.Request.Url.Segments;
                return baseUrl;
            }
        }

        #endregion



        public void LoadBannerImage()
        {

            string[] url = BaseUrl;
            string cUrl = url.Last();
            string ext = ".aspx";

            if (cUrl == UrlEnum.GameManage + ext)
            {
                HeaderImage.ImageUrl = _Powerball;
                HeaderTitle.Text = _PageTitle_GameManage;
            }
            else if (cUrl == UrlEnum.DrawingManage + ext)
            {
                HeaderImage.ImageUrl = _MegaMillions;
                HeaderTitle.Text = _PageTitle_DrawingManage;
            }
            else if (cUrl == UrlEnum.WinningNumberManage + ext)
            {
                HeaderImage.ImageUrl = _NorthstarCash;
                HeaderTitle.Text = _PageTitle_WinningNumberManage;
            }
            else if (cUrl == UrlEnum.GameAvailableManage + ext)
            {
                HeaderImage.ImageUrl = _Gopher5;
                HeaderTitle.Text = _PageTitle_GameAvailableManage;
            }
            else
            {
                HeaderImage.ImageUrl = HeaderImage.ImageUrl = _Powerball;
                HeaderTitle.Text = "";
            }

        }

    }
}