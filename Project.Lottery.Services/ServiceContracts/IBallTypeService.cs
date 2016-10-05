using System;
using System.ServiceModel;
using Project.Lottery.Services.DataContracts;
using System.ServiceModel.Web;
using System.ComponentModel;

namespace Project.Lottery.Services.ServiceContracts
{
    [ServiceContract]
    public interface IBallTypeService
    {
        [Description("Get Ball Type Collection")]
        [OperationContract]
        [WebGet(UriTemplate = "/BallType/", ResponseFormat = WebMessageFormat.Json)]
        BallTypeDTOCollection GetBallTypeCollection();
    }
}
