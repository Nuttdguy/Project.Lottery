using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lottery.Models.Helpers
{
    public static class PageTitleCaptionHelper
    {

        private const string _PageTitle = "Game Manage ";
        private const string _PageTitleResult = "Drawing Manage";

        public static string GetPageTitle
        {
            get
            {
                return _PageTitle;
            }
        }

        public static string GetPageTitleResult
        {
            get
            {
                return _PageTitleResult;
            }
        }

    }
}
