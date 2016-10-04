using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Lottery.Models;
using Project.Lottery.Models.Collections;
using System.Data.SqlClient;
using System.Data;

namespace Project.Lottery.DAL
{
    public static class LotteryDetailDAL
    {

        #region SECTION 1 ||=======  GET ITEM  =======||

        #region ||=======  GET | SINGLE-LOTTERY-ITEM | PARAM LOTTERY-ID  =======||
        public static LotteryDetail GetItem(int id)
        {
            LotteryDetail tmpObj = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLottery", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetItem);
                    myCommand.Parameters.AddWithValue("@LotteryId", id);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if(myReader.Read())
                        {
                            tmpObj = FillDataRecord(myReader);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
            }
            return tmpObj;

        }
        #endregion

        #endregion


        #region SECTION 2 ||=======  GET COLLECTION  =======||

        #region ||=======  GET COLLECTION | LOTTERY-GAME NAMES | ALL  =======||
        public static LotteryDetailCollection GetCollection()
        {
            LotteryDetailCollection tmpCollection = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLottery", myConnection))
                {

                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetCollection);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tmpCollection = new LotteryDetailCollection();
                            while (myReader.Read())
                            {
                                tmpCollection.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
            }
            return tmpCollection;
        }

        #endregion

        #region ||=======  GET COLLECTION | LOTTERY-GAME NAMES BY LOTTERY-ID | PARAM LOTTERY-ID  =======||
        public static LotteryDetailCollection GetCollection(int id)
        {
            LotteryDetailCollection tmpCollection = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLottery", myConnection))
                {

                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetCollectionName_ByLotteryId);
                    myCommand.Parameters.AddWithValue("@LotteryId", id);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tmpCollection = new LotteryDetailCollection();
                            while (myReader.Read())
                            {
                                tmpCollection.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
            }
            return tmpCollection;
        }

        #endregion
        #endregion


        #region SECTION 3 ||=======  SAVE/UPDATE ITEM  =======||

        #region ||=======  SAVE/UPDATE SINGLE ITEM | LOTTERY-GAME NAME | PARAM OBJECT  =======||
        public static int SaveItem(LotteryDetail lottoItem)
        {
            int recordId = 0;

            QueryExecuteType queryId = QueryExecuteType.InsertItem;

            if (lottoItem.LotteryId > 0)
                queryId = QueryExecuteType.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteLottery", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", queryId);

                    if (lottoItem.LotteryId != 0)
                        myCommand.Parameters.AddWithValue("@LotteryId", lottoItem.LotteryId);

                    if (!string.IsNullOrEmpty(lottoItem.LotteryName))
                        myCommand.Parameters.AddWithValue("@LotteryName", lottoItem.LotteryName);

                    myCommand.Parameters.AddWithValue("@HasSpecialBall", lottoItem.HasSpecialBall);
                    myCommand.Parameters.AddWithValue("@HasRegularBall", lottoItem.HasRegularBall);

                    if (lottoItem.NumberOfBalls != 0)
                        myCommand.Parameters.AddWithValue("@NumberOfBalls", lottoItem.NumberOfBalls);

                    myCommand.Parameters.Add(HelperDAL.GetReturnParameterInt("ReturnValue"));

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                    recordId = (int)myCommand.Parameters["@ReturnValue"].Value;
                }
                myConnection.Close();
            }
            return recordId;

        }

        #endregion

        #endregion


        #region SECTION 4 ||=======  DELETE ITEM  =======||

        #region ||=======  DELETE SINGLE ITEM | LOTTERY-GAME NAME BY LOTTERY-ID | PARAM LOTTERY-ID  =======||
        public static int DeleteItem(int id)
        {
            int deletedRecord = 0;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteLottery", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QueryExecuteType.DeleteItem);
                    myCommand.Parameters.AddWithValue("@LotteryId", id);
                    myCommand.Parameters.Add(HelperDAL.GetReturnParameterInt("ReturnValue"));

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                    deletedRecord = (int)myCommand.Parameters["@ReturnValue"].Value;

                }
                myConnection.Close();
            }
            return deletedRecord;
        }

        #endregion

        #endregion


        #region SECTION 5 ||=======  HYDRATE OBJECT  =======||
        public static LotteryDetail FillDataRecord(IDataReader myReader)
        {
            LotteryDetail tmpItem = new LotteryDetail();

            tmpItem.LotteryId = myReader.GetInt32(myReader.GetOrdinal("LotteryId"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("LotteryName")))
                tmpItem.LotteryName = myReader.GetString(myReader.GetOrdinal("LotteryName"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("HasSpecialBall")))
                tmpItem.HasSpecialBall = myReader.GetBoolean(myReader.GetOrdinal("HasSpecialBall"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("HasRegularBall")))
                tmpItem.HasRegularBall = myReader.GetBoolean(myReader.GetOrdinal("HasRegularBall"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("NumberOfBalls")))
                tmpItem.NumberOfBalls = myReader.GetInt32(myReader.GetOrdinal("NumberOfBalls"));

            return tmpItem;

        }
        

        #endregion
    }
}
