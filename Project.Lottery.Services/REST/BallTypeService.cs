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
    public class BallTypeService : IBallTypeService
    {
        #region SECTION 1 ||=======  GET COLLECTION  =======||

        #region || BALL-TYPE-MANAGE OPERATION ||=======  GET COLLECTION | BALL-TYPE BY ALL | PARAMS, NONE  =======||
        public BallTypeDTOCollection GetBallTypeCollection()
        {
            BallTypeCollection tmpCollect = BallTypeBLL.GetCollection();
            return itemList_ToDto(tmpCollect);
        }
        #endregion

        #endregion

        #region SECTION 5 ||=======  HYDRATE OBJECTS  =======||

        #region ||=======  BALL-TYPE-DTO || TO > BALL-TYPE-ITEM | INCOMING  =======||
        private BallType DTO_ToItem(BallTypeDTO dtoItem)
        {
            BallType tmpItem = new BallType();

            tmpItem.BallTypeId = dtoItem.BallTypeId.ToInt();
            tmpItem.BallTypeDescription = dtoItem.BallTypeDescription;

            return tmpItem;

        }
        #endregion

        #region ||=======  LOTTERY-DETAIL-ITEM || TO > LOTTERY-DETAIL-DTO | OUTGOING  =======||
        private BallTypeDTO item_ToDto(BallType itemIn)
        {
            BallTypeDTO tmpDto = new BallTypeDTO();

            tmpDto.BallTypeId = itemIn.BallTypeId.ToString();
            tmpDto.BallTypeDescription = itemIn.BallTypeDescription;

            return tmpDto;

        }
        #endregion

        #region ||=======  LOTTERY-DETAIL-ITEM-COLLECTION || TO > LOTTERY-DETAIL-DTO | OUTGOING  =======||
        private BallTypeDTOCollection itemList_ToDto(BallTypeCollection itemsInList)
        {
            BallTypeDTOCollection tmpCollect = new BallTypeDTOCollection();

            if (itemsInList != null)
            {
                foreach (BallType item in itemsInList)
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