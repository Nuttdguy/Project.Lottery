using Project.Lottery.Models.Collections;
using Project.Lottery.Models;
using Project.Lottery.DAL;


namespace Project.Lottery.BLL
{
    public static class WinningNumberBLL
    {

        #region SECTION 1 ||=======  GET ITEM  =======||

        #region ||=======  GET | SINGLE-ITEM | BY WINNING-NUMBER | PARAM WINNING-NUMBER-ID  =======||
        public static LotteryDetail GetItem(int id)
        {
            LotteryDetail tmpObj = WinningNumberDAL.GetItem(id);
            return tmpObj;

        }
        #endregion

        #endregion

        #region SECTION 2 ||=======  GET | COLLECTION  =======||

        #region ||=======  GET COLLECTION | WINNING-NUMBERS | ALL  =======||
        public static LotteryDetailCollection GetCollection()
        {
            LotteryDetailCollection tmpCollect = WinningNumberDAL.GetCollection();
            return tmpCollect;
        }
        #endregion

        #region ||=======  GET COLLECTION | WINNING-NUMBERS | PARAM LOTTERY-NAME-ID  =======||
        public static LotteryDetailCollection GetCollection(int lottoId)
        {
            LotteryDetailCollection tmpCollect = WinningNumberDAL.GetCollection(lottoId);
            return tmpCollect;
        }
        #endregion

        #region ||=======  GET COLLECTION | WINNING-NUMBERS BY DRAWING-ID | PARAM DRAW-ID, ID-TYPE =======||
        public static LotteryDetailCollection GetCollection(int drawId, int idType)
        {
            LotteryDetailCollection tmpCollect = WinningNumberDAL.GetCollection(drawId, idType);
            return tmpCollect;
        }
        #endregion

        #endregion


        #region SECTION 3 ||=======  SAVE/UPDATE ITEM  =======||

        #region ||=======  SAVE/UPDATE SINGLE ITEM | WINNING-NUMBER | PARAM WINNING-NUMBER-OBJECT  =======||
        public static int SaveItem(LotteryDetail lottoItem)
        {
            int recordId = WinningNumberDAL.SaveItem(lottoItem);
            return recordId;
        }
        #endregion

        #endregion


        #region SECTION 4 ||=======  DELETE ITEM  =======||

        #region ||=======  DELETE ITEM COLLECTION | WINNING-NUMBER-ITEM(S) BY DRAWING-ID | PARAM, DRAWING-ID  =======||
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
