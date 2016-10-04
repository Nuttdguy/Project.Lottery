using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Lottery.Models.Collections;
using Project.Lottery.Models;
using Project.Lottery.DAL;

namespace Project.Lottery.BLL
{
    public static class LotteryDetailBLL
    {

        #region SECTION 1 ||=======  GET ITEM  =======||

        #region ||=======  GET | SINGLE-LOTTERY-ITEM | PARAM LOTTERY-ID  =======||
        public static LotteryDetail GetItem(int lottoId)
        {
            LotteryDetail tmpObj = LotteryDetailDAL.GetItem(lottoId);
            return tmpObj;

        }
        #endregion

        #endregion


        #region SECTION 2 ||=======  GET COLLECTION  =======||

        #region ||=======  GET COLLECTION | LOTTERY-GAME NAMES | ALL  =======||
        public static LotteryDetailCollection GetCollection()
        {
            LotteryDetailCollection tmpCollect = LotteryDetailDAL.GetCollection();
            return tmpCollect;
        }
        #endregion

        #region ||=======  GET COLLECTION | LOTTERY-GAME NAMES BY LOTTERY-ID | PARAM LOTTERY-ID  =======||
        public static LotteryDetailCollection GetCollection(int lottoId)
        {
            LotteryDetailCollection tmpCollect = LotteryDetailDAL.GetCollection(lottoId);
            return tmpCollect;
        }
        #endregion

        #endregion


        #region SECTION 3 ||=======  SAVE/UPDATE ITEM  =======||

        #region ||=======  SAVE/UPDATE SINGLE ITEM | LOTTERY-GAME NAME | PARAM OBJECT  =======||
        public static int SaveItem(LotteryDetail lottoItem)
        {
            int recordId = LotteryDetailDAL.SaveItem(lottoItem);
            return recordId;
        }
        #endregion

        #endregion


        #region SECTION 4 ||=======  DELETE ITEM  =======||

        #region ||=======  DELETE SINGLE ITEM | LOTTERY-GAME NAME BY LOTTERY-ID | PARAM LOTTERY-ID  =======||
        public static int DeleteItem(int lottoId)
        {
            int deletedRecord = LotteryDetailDAL.DeleteItem(lottoId);
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
