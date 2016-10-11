using System;
using System.ServiceModel.Activation;
using Project.Lottery.BLL;
using Project.Lottery.Models;
using Project.Lottery.Models.Extensions;
using Project.Lottery.Models.Collections;
using Project.Lottery.Services.DataContracts;
using Project.Lottery.Services.ServiceContracts;


namespace Project.Lottery.Services.REST
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class LotteryDetailService : ILotteryDetailService
    {

        #region SECTION 1 ||=======  GET ITEM  =======||

        #region || GAME-MANAGE OPERATION ||=======  GET SINGLE-ITEM | LOTTERY-GAMES BY ID | PARAM, LOTTERY-ID  =======||
        public LotteryDetailDTO GetLotteryDetailItem(string id)
        {
            LotteryDetail item = LotteryDetailBLL.GetItem(id.ToInt());
            return item_ToDto(item);
        }
        #endregion 

        #region || DRAWING OPERATION ||=======  GET SINGLE-ITEM | DRAWING BY LOTTERY-ID | PARAM, LOTTERY-ID  =======||  
        public LotteryDetailDTO GetDrawingItem(string id)
        {
            LotteryDetail tmpItem = LotteryDrawingBLL.GetItem(id.ToInt());
            return item_ToDto(tmpItem);
        }
        #endregion

        #region || LOCATION OPERATION ||=======  GET SINGLE-ITEM | DRAWING BY LOTTERY-ID | PARAM, LOTTERY-NAME-ID  =======||  
        public LotteryDetailDTO GetLocationItem(string id)
        {
            LotteryDetail tmpItem = LocationBLL.GetItem(id.ToInt());
            return item_ToDto(tmpItem);
        }
        #endregion

        #region || WINNING-NUMBER OPERATION ||=======  GET SINGLE-ITEM | DRAWING BY WINNING-ID | PARAM, WINNING-NUMBER-ID  =======||  
        public LotteryDetailDTO GetWinningNumberItems(string id)
        {
            LotteryDetail tmpItem = WinningNumberBLL.GetItem(id.ToInt());
            return item_ToDto(tmpItem);
        }
        #endregion 

        #endregion //==||  END-GROUP  ||==  ITEM SECTION  ||==\\

        #region SECTION 2 ||=======  GET COLLECTION  =======||


        #region ||======= GAME-MANAGE OPERATIONS  =======||

        #region || GAME-MANAGE OPERATION ||=======  GET COLLECTION | LOTTERY-GAMES BY ALL | PARAMS, NONE  =======||
        public LotteryDetailDTOCollection GetLotteryDetailCollection()
        {
            LotteryDetailCollection tmpCollect = LotteryDetailBLL.GetCollection();
            return itemList_ToDto(tmpCollect);
        }
        #endregion

        #region || GAME-MANAGE OPERATION ||=======  GET COLLECTION | LOTTERY-GAMES BY LOTTERY-ID | PARAMS, LOTTERY-ID  =======||
        public LotteryDetailDTOCollection GetLotteryDetailCollectionById(string id)
        {
            LotteryDetailCollection tmpCollect = LotteryDetailBLL.GetCollection(id.ToInt());
            return itemList_ToDto(tmpCollect);
        }
        #endregion

        #region || GAME-MANAGE OPERATION ||=======  GET COLLECTION | LOTTERY-GAMES BY ALL | PARAMS, NONE  =======||
        //public LotteryDetailDTOCollection GetLotteryDetailCollectionByType(string id, string type)
        //{
        //    LotteryDetailCollection tmpCollect = LocationBLL.GetCollection(id.ToInt(), id.ToInt());
        //    return itemList_ToDto(tmpCollect);
        //}
        #endregion

        #endregion //==||  END  ||==  GAME-MANAGE COLLECTION  ==||==\\

        #region ||=======  DRAWING OPERATIONS  =======||

        #region || DRAWING OPERATION ||=======  GET COLLECTION | DRAWINGS BY ALL | PARAMS, NONE  =======||
        public LotteryDetailDTOCollection GetDrawingCollection()
        {
            LotteryDetailCollection tmpCollect = LotteryDrawingBLL.GetCollection();
            return itemList_ToDto(tmpCollect);
        }
        #endregion

        #region || DRAWING OPERATION ||=======  GET COLLECTION | DRAWINGS BY LOTTERY-ID | PARAMS, LOTTERY-ID  =======||
        public LotteryDetailDTOCollection GetDrawingCollectionById(string id)
        {
            LotteryDetailCollection tmpCollect = LotteryDrawingBLL.GetCollection(id.ToInt());
            return itemList_ToDto(tmpCollect);
        }
        #endregion //==||  END  ||== DRAWING COLLECTION SECTION ==||==\\

        #endregion //==||  END  ||==  DRAWING-COLLECTION SECTION  ==\\

        #region ||======= LOCATION OPERATIONS  =======||

        #region || LOCATION-MANAGE OPERATION ||=======  GET COLLECTION | LLOCATION BY ALL | PARAMS, NONE  =======||
        public LotteryDetailDTOCollection GetLocationCollection()
        {
            LotteryDetailCollection tmpCollect = LocationBLL.GetCollection();
            return itemList_ToDto(tmpCollect);
        }
        #endregion

        #region || LOCATION-MANAGE OPERATION ||=======  GET COLLECTION | LOCATION BY LOTTERY-ID | PARAMS, LOTTERY-NAME-ID  =======||
        public LotteryDetailDTOCollection GetLocationCollectionById(string id)
        {
            LotteryDetailCollection tmpCollect = LocationBLL.GetCollection(id.ToInt());
            return itemList_ToDto(tmpCollect);
        }
        #endregion

        #region || LOCATION-MANAGE OPERATION ||=======  GET COLLECTION | LOCATION BY SELECTED-LOTTERY-ID | PARAMS, LOTTERY-ID  =======||
        public LotteryDetailDTOCollection GetLocationCollectionByType(string id, string type)
        {
            LotteryDetailCollection tmpCollect = LocationBLL.GetCollection(id.ToInt(), id.ToInt());
            return itemList_ToDto(tmpCollect);
        }
        #endregion

        #endregion //==||  END  ||==  LOCATION-MANAGE COLLECTION  ==||==\\

        #region ||======= WINNING-NUMBER OPERATIONS  =======||

        #region || WINNING-NUMBER-MANAGE OPERATION ||=======  GET COLLECTION | WINNING-NUMBER BY ALL | PARAMS, NONE  =======||
        public LotteryDetailDTOCollection GetWinningNumberCollection()
        {
            LotteryDetailCollection tmpCollect = WinningNumberBLL.GetCollection();
            return itemList_ToDto(tmpCollect);
        }
        #endregion

        #region || WINNING-NUMBER-MANAGE OPERATION ||=======  GET COLLECTION | WINNING-NUMBER BY LOTTERY-ID | PARAMS, LOTTERY-NAME-ID  =======||
        public LotteryDetailDTOCollection GetWinningNumberCollectionById(string id)
        {
            LotteryDetailCollection tmpCollect = WinningNumberBLL.GetCollection(id.ToInt());
            return itemList_ToDto(tmpCollect);
        }
        #endregion

        #region || WINNING-NUMBER-MANAGE OPERATION ||=======  GET COLLECTION | WINNING-NUMBER BY DRAW-ID | PARAMS, DRAW-ID, ID-TYPE =======||
        public LotteryDetailDTOCollection GetWinningNumberCollectionByType(string drawId, string idType)
        {
            LotteryDetailCollection tmpCollect = WinningNumberBLL.GetCollection(drawId.ToInt(), idType.ToInt());
            return itemList_ToDto(tmpCollect);
        }
        #endregion

        #endregion //==||  END  ||==  LOCATION-MANAGE COLLECTION  ==||==\\

        #endregion //==||  END-GROUP  ||==  SECTION-2-COLLECTIONS-ALL  ======\\






        #region SECTION 3 ||=======  SAVE ITEM  =======||

        #region || LOTTERY-DETAIL OPERATION ||=======  SAVE/UPDATE SINGLE ITEM | LOTTERY-GAME NAME | PARAM OBJECT  =======||
        public int SaveDetailItem(LotteryDetailDTO lottoDTOObject)
        {
            int returnValue = LotteryDetailBLL.SaveItem(DTO_ToItem(lottoDTOObject));
            return returnValue;

        }
        #endregion

        #region || DRAWING OPERATION ||=======  SAVE/UPDATE ITEM | LOTTERY-DRAWING-ITEM | PARAM LOTTERY-DRAWING-OBJECT  =======||
        public int SaveDrawingItem(LotteryDetailDTO drawObjectDTO)
        {
            int saveRecord = LotteryDrawingBLL.SaveItem(DTO_ToItem(drawObjectDTO));
            return saveRecord;
        }
        #endregion //==||  END  ||==  LOCATION-MANAGE SAVE  ==||==\\

        #region || WINNNG-NUMBER OPERATION ||=======  SAVE/UPDATE SINGLE ITEM | WINNING-NUMBER | PARAM WINNING-NUMBER-OBJECT  =======||
        public int SaveWinningNumberItem(LotteryDetailDTO winNumberObjectDto)
        {
            int saveRecord = WinningNumberBLL.SaveItem(DTO_ToItem(winNumberObjectDto));
            return saveRecord;
        }
        #endregion //==||  END  ||==  LOCATION-MANAGE SAVE  ==||==\\

        #region || LOCATION OPERATION ||=======  SAVE/UPDATE ITEM(S) | LOCATION & ASSOCIATED GAME NAME | PARAM OBJECT  =======||
        public int SaveLocationItem(LotteryDetailDTO locObjectDTO)
        {
            int saveRecord = LocationBLL.SaveItem(DTO_ToItem(locObjectDTO));
            return saveRecord;
        }
        #endregion //==||  END  ||==  LOCATION-MANAGE SAVE  ==||==\\

        #endregion //==|| END-GROUP ||==  SECTION-3-SAVE-ALL  ======\\





        #region SECTION 4 ||=======  DELETE ITEM  =======||

        #region || LOTTERY-DETAIL OPERATION ||=======  DELETE SINGLE ITEM | LOTTERY-GAME NAME BY LOTTERY-ID | PARAM LOTTERY-ID  =======||
        public int DeleteDetailItem(string id)
        {
            int returnValue = LotteryDetailBLL.DeleteItem(id.ToInt());
            return returnValue;
        }
        #endregion

        #region || DRAWING OPERATION ||=======  DELETE | LOTTERY-DRAWING-ITEM | PARAM LOTTERY-DRAWING-ID  =======||
        public int DeleteDrawingItem(string drawId)
        {
            int delRecord = LotteryDrawingBLL.DeleteItem(drawId.ToInt());
            return delRecord;
        }
        #endregion //==||  END  ||==  LOCATION-MANAGE DELETE  ==||==\\

        #region || WINNNG-NUMBER OPERATION ||=======  DELETE ITEM COLLECTION | WINNING-NUMBER-ITEM(S) BY DRAWING-ID | PARAM, DRAWING-ID  =======||
        public int DeleteWinningNumberItem(string winningId)
        {
            int delRecord = WinningNumberBLL.DeleteItem(winningId.ToInt());
            return delRecord;
        }
        #endregion //==||  END  ||==  LOCATION-MANAGE DELETE  ==||==\\

        #region || LOCATION/GAME AVAILABLE OPERATION ||=======  DELETE ITEM(S) | LOCATION & ASSOCIATED GAME NAME | PARAM LOCATION-ID, LOTTERY-ID [OP] =======||
        public int DeleteLocationItem(string locId, string lottoId)
        {
            int delRecord = LocationBLL.DeleteItem(locId.ToInt(), lottoId.ToInt());
            return delRecord;
        }

        #endregion //==||  END  ||==  LOCATION-MANAGE DELETE  ==||==\\

        #endregion  //==|| END-GROUP ||==  SECTION-4-DELETE-ALL  ======\\



        #region SECTION 5 ||=======  HYDRATE OBJECTS  =======||

        #region ||=======  LOTTERY-DETAIL-DTO || TO > LOTTERY-DETAIL-ITEM | INCOMING  =======||
        private LotteryDetail DTO_ToItem(LotteryDetailDTO dtoItem)
        {

            LotteryDetail tmpItem = new LotteryDetail();

            tmpItem.LotteryId = dtoItem.LotteryId;
            tmpItem.LotteryName = dtoItem.LotteryName;
            tmpItem.HasSpecialBall = dtoItem.HasSpecialBall;
            tmpItem.HasRegularBall = dtoItem.HasRegularBall;
            tmpItem.NumberOfBalls = dtoItem.NumberOfBalls;

            ////==||  INTERFACE PROPERTIES  ||==\\
            tmpItem.LocationId = dtoItem.LocationId;
            tmpItem.State = dtoItem.State;

            tmpItem.LotteryDrawingId = dtoItem.LotteryDrawingId;
            tmpItem.Jackpot = dtoItem.Jackpot;

            tmpItem.LotteryDrawingDate = dtoItem.DrawDates.ToDate();

            tmpItem.WinningNumberId = dtoItem.WinningNumberId;
            tmpItem.BallNumber = dtoItem.BallNumber;

            tmpItem.BallTypeId = dtoItem.BallTypeId;
            tmpItem.BallTypeDescription = dtoItem.BallTypeDescription;

            return tmpItem;


        }
        #endregion

        #region ||=======  LOTTERY-DETAIL-ITEM || TO > LOTTERY-DETAIL-DTO | OUTGOING  =======||
        private LotteryDetailDTO item_ToDto(LotteryDetail itemIn)
        {
            LotteryDetailDTO tmpDto = new LotteryDetailDTO();

            tmpDto.LotteryId = itemIn.LotteryId;
            tmpDto.LotteryName = itemIn.LotteryName;
            tmpDto.HasSpecialBall = itemIn.HasSpecialBall;
            tmpDto.HasRegularBall = itemIn.HasRegularBall;
            tmpDto.NumberOfBalls = itemIn.NumberOfBalls;

            //==||  INTERFACE PROPERTIES  ||==\\
            tmpDto.LocationId = itemIn.LocationId;
            tmpDto.State = itemIn.State;

            tmpDto.LotteryDrawingId = itemIn.LotteryDrawingId;
            tmpDto.Jackpot = itemIn.Jackpot;

            tmpDto.DrawDates = itemIn.LotteryDrawingDate.ToShortDateString();

            tmpDto.WinningNumberId = itemIn.WinningNumberId;
            tmpDto.BallNumber = itemIn.BallNumber;

            tmpDto.BallTypeId = itemIn.BallTypeId;
            tmpDto.BallTypeDescription = itemIn.BallTypeDescription;

            return tmpDto;

        }
        #endregion

        #region ||=======  LOTTERY-DETAIL-ITEM-COLLECTION || TO > LOTTERY-DETAIL-DTO | OUTGOING  =======||
        private LotteryDetailDTOCollection itemList_ToDto(LotteryDetailCollection itemsInList)
        {
            LotteryDetailDTOCollection tmpCollect = new LotteryDetailDTOCollection();

            if (itemsInList != null)
            {
                foreach (LotteryDetail item in itemsInList)
                {
                    tmpCollect.Add(item_ToDto(item));
                }
            }

            return tmpCollect;

        }

        #endregion

        #endregion

    }
}