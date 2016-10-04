using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Lottery.Models.Helpers;
using Project.Lottery.Models.Extensions;
using Project.Lottery.Models.Delegates;
using Project.Lottery.Models.Enums;


namespace Project.Lottery.Webforms.UserControls
{
    public partial class HeaderControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UCDropDownEventDelegate.selectedEvent += new UCDropDownEventDelegate.OnSelectedChangeEvent(UCDropDownEvent);
            if (!IsPostBack)
                LoadPageTitle();
        }

        #region SECTION 1 ||========  PROPERTIES  =======||

        #region ||=======  STATIC PROPERTIES | IMAGE-URLS, PAGE-TITLE-CAPTION  =======||
        private string _Powerball = "~/App_Themes/Main/images/powerballLogo.png";
        private string _MegaMillions = "~/App_Themes/Main/Images/megaMillionsLogo.png";
        private string _Gopher5 = "~/App_Themes/Main/images/gopher5Logo.png";
        private string _NorthstarCash = "~/App_Themes/Main/images/northstarLogo.png";

        private string _PageTitle_GameManage = "Game Manage ";
        private string _PageTitle_DrawingManage = "Drawing Manage";
        private string _PageTitle_WinningNumberManage = "Winning Number Manage ";
        private string _PageTitle_GameAvailableManage = "Game Available Manage";

        #endregion


        #region ||=======  GET METHOD | RETRIEVE URL, SEPARATE INTO ARRAY  ======||
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

        #endregion

        #region SECTION 2 ||=======  SET HEADER ASSETS =======||

        #region ||=======  SET PAGE-TITLE-CAPTION  =======||
        public void LoadPageTitle()
        {

            string[] url = BaseUrl;
            string cUrl = url.Last();
            string ext = ".aspx";

            if (cUrl == UrlEnum.GameManage + ext)
            {
                HeaderTitle.Text = _PageTitle_GameManage;
            }
            else if (cUrl == UrlEnum.DrawingManage + ext)
            {
                HeaderTitle.Text = _PageTitle_DrawingManage;
            }
            else if (cUrl == UrlEnum.WinningNumberManage + ext)
            {
                HeaderTitle.Text = _PageTitle_WinningNumberManage;
            }
            else if (cUrl == UrlEnum.GameAvailableManage + ext)
            {
                HeaderTitle.Text = _PageTitle_GameAvailableManage;
            }
            else
            {
                HeaderImage.ImageUrl = _Powerball;
            }

        }

        #endregion


        #region ||=======  SET PAGE-TITLE-IMAGE  =======||
        public void LoadTitleImage(int id )
        {
            switch (id)
            {
                case 1:
                    HeaderImage.ImageUrl = _Powerball;
                    break;
                case 2:
                    HeaderImage.ImageUrl = _MegaMillions;
                    break;
                case 3:
                    HeaderImage.ImageUrl = _Gopher5;
                    break;
                case 4:
                    HeaderImage.ImageUrl = _NorthstarCash;
                    break;
                default:
                    HeaderImage.ImageUrl = null;
                    break;
            }
        }

        #endregion

        #endregion

        #region SECTION 3 ||=======  EVENTS  =======||

        #region ||=======  DROP-DOWN EVENT | INVOKES METHODS, LOADS HEADER ASSETS  =======||
        void UCDropDownEvent(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            int id = ddl.SelectedValue.ToInt();

            LoadTitleImage(id);
            LoadPageTitle();

        }
        #endregion

        #endregion

    }
}