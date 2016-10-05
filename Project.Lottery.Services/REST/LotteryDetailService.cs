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
        public LotteryDetailDTO GetItem(string id)
        {
            LotteryDetail item = LotteryDetailBLL.GetItem(id.ToInt());
            return item_ToDto(item);
        }
        #endregion


        #region SECTION 2 ||=======  GET COLLECTION  =======||
        public LotteryDetailDTOCollection GetCollection()
        {
            LotteryDetailCollection tmpCollect = LotteryDetailBLL.GetCollection();
            return itemList_ToDto(tmpCollect);
        }

        public LotteryDetailDTOCollection GetCollectionById(string id)
        {
            LotteryDetailCollection tmpCollect = LotteryDetailBLL.GetCollection(id.ToInt());
            return itemList_ToDto(tmpCollect);
        }

        //==||  FOR LOCATION USE
        public LotteryDetailDTOCollection GetCollectionByType(string id, string type)
        {
            LotteryDetailCollection tmpCollect = LocationBLL.GetCollection(id.ToInt(), id.ToInt());
            return itemList_ToDto(tmpCollect);
        }
        #endregion

        #region SECTION 3 ||=======  SAVE ITEM  =======||

        #endregion

        #region SECTION 4 ||=======  DELETE ITEM  =======||

        #endregion

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

            //==||  INTERFACE PROPERTIES  ||==\\
            tmpItem.LocationId = dtoItem.LocationId;
            tmpItem.State = dtoItem.State;

            tmpItem.LotteryDrawingId = dtoItem.LotteryDrawingId;
            tmpItem.Jackpot = dtoItem.Jackpot;
            tmpItem.DrawDate = dtoItem.DrawDate;

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
            tmpDto.DrawDate = itemIn.DrawDate;

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