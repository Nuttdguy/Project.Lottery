using Project.Lottery.Models.Collections;
using Project.Lottery.Models;
using Project.Lottery.DAL;


namespace Project.Lottery.BLL
{
    public static class BallTypeBLL
    {

        #region SECTION 1 ||=======  GET ITEM  =======||

        #region ||=======  GET LOTTERY-ITEM | PARAM ~ LOTTERY-ID  =======||
        public static BallType GetItem(int id)
        {
            BallType tmpObj = BallTypeDAL.GetItem(id);
            return tmpObj;

        }
        #endregion

        #endregion


        #region SECTION 2 ||=======  GET COLLECTION  =======||

        #region ||=======  GET COLLECTION | ALL  =======||
        public static BallTypeCollection GetCollection()
        {
            BallTypeCollection tmpCollect = BallTypeDAL.GetCollection();
            return tmpCollect;
        }
        #endregion

        #region ||=======  GET COLLECTION | PARAM LOTTERY-ID  =======||
        public static BallTypeCollection GetCollection(int id)
        {
            BallTypeCollection tmpCollect = BallTypeDAL.GetCollection(id);
            return tmpCollect;
        }
        #endregion

        #endregion


        #region SECTION 3 ||=======  SAVE/UPDATE ITEM  =======||

        #region ||=======  SAVE/UPDATE LOTTERY-ITEM | PARAM ~ NONE, LOTTERY-ID [OP]  =======||
        public static int SaveItem(BallType lottoItem)
        {
            int recordId = BallTypeDAL.SaveItem(lottoItem);
            return recordId;
        }
        #endregion

        #endregion


        #region SECTION 4 ||=======  DELETE ITEM  =======||

        #region ||=======  DELETE LOTTERY-ITEM | PARAM ~ LOTTERY-ID  =======||
        public static int DeleteItem(int id)
        {
            int deletedRecord = BallTypeDAL.DeleteItem(id);
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
