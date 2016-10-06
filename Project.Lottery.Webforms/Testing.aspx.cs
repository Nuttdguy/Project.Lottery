using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;


namespace Project.Lottery.Webforms
{
    public partial class Testing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TestBO tmpItem = new TestBO()
            {
                LotteryDrawingId = 48,
                BallTypeId = 1,
                BallNumber = 99
            };


            using (HttpClient httpClient = new HttpClient())
            {
                //==||  TESTED SERVICE, BLL, DAL ALL WORKING >> CONTENT-TYPE: APPLICATION/JSON IS CAUSING ERROR  ||==\\
                using (HttpResponseMessage responseMessage = httpClient.PutAsJsonAsync("http://localhost:64999/Game/WinningNumber/", tmpItem).Result)
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        lblMessage.Text = responseMessage.StatusCode.ToString();
                    }
                    else
                        lblMessage.Text = responseMessage.StatusCode.ToString();
                }
            }
        }
    }


    public class TestBO
    {
        public int LotteryDrawingId { get; set; }
        public int BallTypeId { get; set; }
        public int BallNumber { get; set; }

        public DateTime DrawDatexx { get; set; }
    }
}