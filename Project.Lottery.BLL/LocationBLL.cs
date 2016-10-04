using Project.Lottery.Models.Collections;
using Project.Lottery.Models;
using Project.Lottery.DAL;



namespace Project.Lottery.BLL
{
    public static class LocationBLL
    {

        #region SECTION 1 ||=======  GET ITEM  =======||

        #region ||=======  GET WINNNG-NUMBER-ITEM | PARAM ~ DRAWING-ID  =======||
        public static LotteryDetail GetItem(int id)
        {
            LotteryDetail tmpObj = LocationDAL.GetItem(id);
            return tmpObj;

        }
        #endregion

        #endregion


        #region SECTION 2 ||=======  GET COLLECTION  =======||

        #region ||=======  GET COLLECTION | ALL  =======||
        public static LotteryDetailCollection GetCollection()
        {
            LotteryDetailCollection tmpCollect = LocationDAL.GetCollection();
            return tmpCollect;
        }
        #endregion

        #region ||=======  GET COLLECTION | PARAM DRAWING-ID  =======||
        public static LotteryDetailCollection GetCollection(int id)
        {
            LotteryDetailCollection tmpCollect = LocationDAL.GetCollection(id);
            return tmpCollect;
        }
        #endregion

        #region ||=======  GET COLLECTION | PARAM ID, ID-TYPE =======||
        public static LotteryDetailCollection GetCollection(int id, int idType)
        {
            LotteryDetailCollection tmpCollect = LocationDAL.GetCollection(id, idType);
            return tmpCollect;
        }
        #endregion

        #endregion


        #region SECTION 3 ||=======  SAVE/UPDATE ITEM  =======||

        #region ||=======  SAVE/UPDATE WINNING-NUMBER-ITEM | PARAM ~ NONE, DRAWING-ID [OP]  =======||
        public static int SaveItem(LotteryDetail lottoItem)
        {
            int recordId = LocationDAL.SaveItem(lottoItem);
            return recordId;
        }
        #endregion

        #endregion


        #region SECTION 4 ||=======  DELETE ITEM  =======||

        #region ||=======  DELETE WINNING-NUMBER-ITEM | PARAM ~ DRAWING-ID  =======||
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
