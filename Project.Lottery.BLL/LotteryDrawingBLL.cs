using Project.Lottery.Models.Collections;
using Project.Lottery.Models;
using Project.Lottery.DAL;


namespace Project.Lottery.BLL
{
    public static class LotteryDrawingBLL
    {

        #region SECTION 1 ||=======  GET ITEM  =======||

        #region ||=======  GET LOTTERY-ITEM | PARAM ~ LOTTERY-ID  =======||
        public static LotteryDetail GetItem(int id)
        {
            LotteryDetail tmpObj = LotteryDrawingDAL.GetItem(id);
            return tmpObj;

        }
        #endregion

        #endregion


        #region SECTION 2 ||=======  GET COLLECTION  =======||

        #region ||=======  GET COLLECTION | ALL  =======||
        public static LotteryDetailCollection GetCollection()
        {
            LotteryDetailCollection tmpCollect = LotteryDrawingDAL.GetCollection();
            return tmpCollect;
        }
        #endregion

        #region ||=======  GET COLLECTION | PARAM LOTTERY-ID  =======||
        public static LotteryDetailCollection GetCollection(int id)
        {
            LotteryDetailCollection tmpCollect = LotteryDrawingDAL.GetCollection(id);
            return tmpCollect;
        }
        #endregion

        #endregion


        #region SECTION 3 ||=======  SAVE/UPDATE ITEM  =======||

        #region ||=======  SAVE/UPDATE LOTTERY-ITEM | PARAM ~ NONE, LOTTERY-ID [OP]  =======||
        public static int SaveItem(LotteryDetail lottoItem)
        {
            int recordId = LotteryDrawingDAL.SaveItem(lottoItem);
            return recordId;
        }
        #endregion

        #endregion


        #region SECTION 4 ||=======  DELETE ITEM  =======||

        #region ||=======  DELETE LOTTERY-ITEM | PARAM ~ LOTTERY-ID  =======||
        public static int DeleteItem(int id)
        {
            int deletedRecord = LotteryDrawingDAL.DeleteItem(id);
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
