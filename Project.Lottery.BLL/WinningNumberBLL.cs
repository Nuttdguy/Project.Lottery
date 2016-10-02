using Project.Lottery.Models.Collections;
using Project.Lottery.Models;
using Project.Lottery.DAL;


namespace Project.Lottery.BLL
{
    public static class WinningNumberBLL
    {

        #region SECTION 1 ||=======  GET ITEM  =======||

        #region ||=======  GET WINNNG-NUMBER-ITEM | PARAM ~ DRAWING-ID  =======||
        public static LotteryDetail GetItem(int id)
        {
            LotteryDetail tmpObj = WinningNumberDAL.GetItem(id);
            return tmpObj;

        }
        #endregion

        #endregion


        #region SECTION 2 ||=======  GET COLLECTION  =======||

        #region ||=======  GET COLLECTION | ALL  =======||
        public static LotteryDetailCollection GetCollection()
        {
            LotteryDetailCollection tmpCollect = WinningNumberDAL.GetCollection();
            return tmpCollect;
        }
        #endregion

        #region ||=======  GET COLLECTION | PARAM DRAWING-ID  =======||
        public static LotteryDetailCollection GetCollection(int id)
        {
            LotteryDetailCollection tmpCollect = WinningNumberDAL.GetCollection(id);
            return tmpCollect;
        }
        #endregion

        #endregion


        #region SECTION 3 ||=======  SAVE/UPDATE ITEM  =======||

        #region ||=======  SAVE/UPDATE WINNING-NUMBER-ITEM | PARAM ~ NONE, DRAWING-ID [OP]  =======||
        public static int SaveItem(LotteryDetail lottoItem)
        {
            int recordId = WinningNumberDAL.SaveItem(lottoItem);
            return recordId;
        }
        #endregion

        #endregion


        #region SECTION 4 ||=======  DELETE ITEM  =======||

        #region ||=======  DELETE WINNING-NUMBER-ITEM | PARAM ~ DRAWING-ID  =======||
        public static int DeleteItem(int id)
        {
            int deletedRecord = WinningNumberDAL.DeleteItem(id);
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
