using System.ServiceModel;
using System.ComponentModel;
using System.ServiceModel.Web;
using Project.Lottery.Services.DataContracts;

namespace Project.Lottery.Services.ServiceContracts
{
    [ServiceContract]
    public interface ILotteryDetailService
    {
        [Description("Get Lottery Detail Item By ID")]
        [OperationContract]
        [WebGet(UriTemplate = "/Lottery/{id}", ResponseFormat = WebMessageFormat.Json)]
        LotteryDetailDTO GetItem(string id);

        [Description("Get Collection By All")]
        [OperationContract]
        [WebGet(UriTemplate = "/Lottery/List/", ResponseFormat = WebMessageFormat.Json)]
        LotteryDetailDTOCollection GetCollection();

        [Description("Get Collection by ID")]
        [OperationContract]
        [WebGet(UriTemplate = "/Lottery/List/{id}", ResponseFormat = WebMessageFormat.Json)]
        LotteryDetailDTOCollection GetCollectionById(string id);

        [Description("Get Collection by ID, ID-Type")]
        [OperationContract]
        [WebGet(UriTemplate = "/Lottery/List/{id},{type}")]
        LotteryDetailDTOCollection GetCollectionByType(string id, string type);

    }
}
