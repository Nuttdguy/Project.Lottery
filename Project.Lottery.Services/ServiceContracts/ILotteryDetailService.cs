using System.ServiceModel;
using System.ComponentModel;
using System.ServiceModel.Web;
using Project.Lottery.Services.DataContracts;

namespace Project.Lottery.Services.ServiceContracts
{
    [ServiceContract]
    public interface ILotteryDetailService
    {
        #region SECTION 1 ||=======  LOTTERY-DETAIL / GAME-MANAGE OPERATION CONTRACTS  ======||

        #region ||=======  GET OPERATIONS  =======||

        [Description("Get Lottery Detail Item By ID")]
        [OperationContract]
        [WebGet(UriTemplate = "/Detail/{id}", ResponseFormat = WebMessageFormat.Json)]
        LotteryDetailDTO GetLotteryDetailItem(string id);

        [Description("Get Collection By All")]
        [OperationContract]
        [WebGet(UriTemplate = "/Detail/List/", ResponseFormat = WebMessageFormat.Json)]
        LotteryDetailDTOCollection GetLotteryDetailCollection();

        [Description("Get Collection by ID")]
        [OperationContract]
        [WebGet(UriTemplate = "/Detail/List/{id}", ResponseFormat = WebMessageFormat.Json)]
        LotteryDetailDTOCollection GetLotteryDetailCollectionById(string id);

        #endregion

        #region ||=======  SAVE OPERATIONS  =======||
        [Description("Save/Update Lottery Detail Item")]
        [OperationContract]
        [WebInvoke(UriTemplate = "/Detail/", Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int SaveDetailItem(LotteryDetailDTO lottoDTOObject);
        #endregion

        #region ||=======  DELETE OPERATIONS  =======||
        [Description("Delete Lottery Detail Item")]
        [OperationContract]
        [WebInvoke(UriTemplate = "/Detail/{id}", Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int DeleteDetailItem(string id);
        #endregion

        #endregion


        #region SECTION 2 ||=======  GAME-DRAWING OPERATION CONTRACTS  =======||

        #region ||=======  GET OPERATIONS  =======|| 
        [Description("Get Drawing Item Detail By ID")]
        [OperationContract]
        [WebGet(UriTemplate = "/Drawing/{id}", ResponseFormat = WebMessageFormat.Json)]
        LotteryDetailDTO GetDrawingItem(string id);

        [Description("Get Drawing Collection By All")]
        [OperationContract]
        [WebGet(UriTemplate = "/Drawing/List/", ResponseFormat = WebMessageFormat.Json)]
        LotteryDetailDTOCollection GetDrawingCollection();

        [Description("Get Drawing Collection By Id")]
        [OperationContract]
        [WebGet(UriTemplate = "/Drawing/List/{id}", ResponseFormat = WebMessageFormat.Json)]
        LotteryDetailDTOCollection GetDrawingCollectionById(string id);

        //[Description("Get Drawing Collection By ID and ID-Type")]
        //[OperationContract]
        //[WebGet(UriTemplate = "/Drawing/{id},{idType}", ResponseFormat = WebMessageFormat.Json)]
        //LotteryDetailDTOCollection GetDrawingCollectionByType(string id, string idType);

        #endregion

        #region ||=======  SAVE OPERATIONS  =======||
        [Description("Save Drawing Item")]
        [OperationContract]
        [WebInvoke(UriTemplate = "/Drawing/", Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int SaveDrawingItem(LotteryDetailDTO drawObjectDTO);
        #endregion

        #region ||=======  DELETE OPERATIONS  =======||
        [Description("Delete Drawing Item")]
        [OperationContract]
        [WebInvoke(UriTemplate = "/Drawing/{drawId}", Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int DeleteDrawingItem(string drawId);
        #endregion

        #endregion


        #region SECTION 3 ||=======  WINNING-NUMBER OPERATION CONTRACTS  =======||

        #region ||=======  GET OPERATIONS  =======||
        [Description("Get Winning Number Item By ID")]
        [OperationContract]
        [WebGet(UriTemplate = "/WinningNumber/{id}", ResponseFormat = WebMessageFormat.Json)]
        LotteryDetailDTO GetWinningNumberItems(string id);

        [Description("Get Winning Number Collection By All")]
        [OperationContract]
        [WebGet(UriTemplate = "/WinningNumber/List/", ResponseFormat = WebMessageFormat.Json)]
        LotteryDetailDTOCollection GetWinningNumberCollection();

        [Description("Get Winning Number Collection By Lottery-Name-Id")]
        [OperationContract]
        [WebGet(UriTemplate = "/WinningNumber/List/{id}", ResponseFormat = WebMessageFormat.Json)]
        LotteryDetailDTOCollection GetWinningNumberCollectionById(string id);

        [Description("Get Winning Number Collection By Draw-ID and ID-Type")]
        [OperationContract]
        [WebGet(UriTemplate = "/WinningNumber/List/{id},{idType}", ResponseFormat = WebMessageFormat.Json)]
        LotteryDetailDTOCollection GetWinningNumberCollectionByType(string id, string idType);
        #endregion

        #region ||=======  SAVE OPERATIONS  =======||
        [Description("Save Winning Number Item")]
        [OperationContract]
        [WebInvoke(UriTemplate = "/WinningNumber/", Method = "PUT", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int SaveWinningNumberItem(LotteryDetailDTO winNumberObjectDto);
        #endregion

        #region ||=======  DELETE OPERATIONS  =======||
        [Description("Delete Winning Number Item")]
        [OperationContract]
        [WebInvoke(UriTemplate = "/WinningNumber/{winningId}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int DeleteWinningNumberItem(string winningId);
        #endregion

        #endregion


        #region SECTION 4 ||=======  GAME-AVAILABLE / LOCATION OPERATION CONTRACTS  =======||

        #region ||=======  GET OPERATIONS  =======||
        [Description("Get Location Item Detail By ID")]
        [OperationContract]
        [WebGet(UriTemplate = "/Location/{id}", ResponseFormat = WebMessageFormat.Json)]
        LotteryDetailDTO GetLocationItem(string id);

        [Description("Get Location Collection By All")]
        [OperationContract]
        [WebGet(UriTemplate = "/Location/List/", ResponseFormat = WebMessageFormat.Json)]
        LotteryDetailDTOCollection GetLocationCollection();

        [Description("Get Location Collection By Lottery-Name-Id")]
        [OperationContract]
        [WebGet(UriTemplate = "/Location/List/{id}", ResponseFormat = WebMessageFormat.Json)]
        LotteryDetailDTOCollection GetLocationCollectionById(string id);

        [Description("Get Drawing Collection By ID and ID-Type")]
        [OperationContract]
        [WebGet(UriTemplate = "/Location/List/{id},{idType}", ResponseFormat = WebMessageFormat.Json)]
        LotteryDetailDTOCollection GetLocationCollectionByType(string id, string idType);
        #endregion

        #region ||=======  SAVE OPERATIONS  =======||
        [Description("Save Location Item ")]
        [OperationContract]
        [WebInvoke(UriTemplate = "/Location/", Method = "PUT", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int SaveLocationItem(LotteryDetailDTO locObjectDTO);
        #endregion

        #region ||=======  DELETE OPERATIONS  =======||
        [Description("Delete Location Item With LocationId and LotteryId")]
        [OperationContract]
        [WebInvoke(UriTemplate = "/Location/{locId},{lottoId}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int DeleteLocationItem(string locId, string lottoId);
        #endregion

        #endregion


    }
}
