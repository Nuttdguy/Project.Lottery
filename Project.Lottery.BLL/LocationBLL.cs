using Project.Lottery.Models.Collections;
using Project.Lottery.Models;
using Project.Lottery.DAL;



namespace Project.Lottery.BLL
{
    public static class LocationBLL
    {

        #region SECTION 1 ||=======  GET ITEM  =======||

        #region ||=======  GET | SINGLE-ITEM | LOCATION BY LOCATION-ID | PARAM LOCATION-ID  =======||
        public static LotteryDetail GetItem(int id)
        {
            LotteryDetail tmpObj = LocationDAL.GetItem(id);
            return tmpObj;

        }
        #endregion

        #endregion


        #region SECTION 2 ||=======  GET COLLECTION  =======||

        #region ||=======  GET COLLECTION | LOCATION | ALL  =======||
        public static LotteryDetailCollection GetCollection()
        {
            LotteryDetailCollection tmpCollect = LocationDAL.GetCollection();
            return tmpCollect;
        }
        #endregion

        #region ||=======  GET COLLECTION | LOCATION BY LOTTERY-ID | PARAM LOTTERY-NAME-ID  =======||
        public static LotteryDetailCollection GetCollection(int lottoId)
        {
            LotteryDetailCollection tmpCollect = LocationDAL.GetCollection(lottoId);
            return tmpCollect;
        }
        #endregion

        #region ||=======  GET COLLECTION | LOCATION BY SELECTED-LOTTERY-ID | PARAM LOTTERY-ID  =======||
        public static LotteryDetailCollection GetCollection(int id, int idType)
        {
            LotteryDetailCollection tmpCollect = LocationDAL.GetCollection(id, idType);
            return tmpCollect;
        }
        #endregion

        #endregion


        #region SECTION 3 ||=======  SAVE/UPDATE ITEM  =======||

        #region ||=======  SAVE/UPDATE ITEM(S) | LOCATION & ASSOCIATED GAME NAME | PARAM OBJECT  =======||
        public static int SaveItem(LotteryDetail lottoItem)
        {
            int recordId = LocationDAL.SaveItem(lottoItem);
            return recordId;
        }
        #endregion

        #endregion


        #region SECTION 4 ||=======  DELETE ITEM  =======||

        #region ||=======  DELETE ITEM(S) | LOCATION & ASSOCIATED GAME NAME | PARAM LOCATION-ID, LOTTERY-ID [OP] =======||
        public static int DeleteItem(int locId, int lottoId)
        {
            int deletedRecord = LocationDAL.DeleteItem(locId, lottoId);
            return deletedRecord;
        }
        #endregion

        #endregion


        #region SECTION 5 ||=======  VALIDATION  =======||

        #region ||=======  VALIDATE FORM DATA  =======||

        #endregion

        #endregion

    }
}
