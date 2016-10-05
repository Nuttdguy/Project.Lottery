using System;
using System.Web.Routing;
using System.ServiceModel.Activation;
using Project.Lottery.Services.REST;


namespace Project.Lottery.Services
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add(new ServiceRoute("Game", new WebScriptServiceHostFactory(), typeof(LotteryDetailService)));
            RouteTable.Routes.Add(new ServiceRoute("Ball", new WebScriptServiceHostFactory(), typeof(BallTypeService)));
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}