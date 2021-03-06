﻿using Project.Lottery.Models;
using Project.Lottery.Models.Collections;
using System.Data.SqlClient;
using System.Data;


namespace Project.Lottery.DAL
{
    public static class LotteryDrawingDAL
    {

        #region SECTION 1 ||=======  GET ITEM  =======||

        #region ||=======  GET | SINGLE-ITEM | BY LOTTERY-ITEM | PARAM, LOTTERY-ID  =======||
        public static LotteryDetail GetItem(int id)
        {
            LotteryDetail tmpObj = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLotteryDrawing", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetItem);
                    myCommand.Parameters.AddWithValue("@LotteryDrawingId", id);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
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

        #region ||=======  GET COLLECTION | LOTTERY-DRAWING | ALL  =======||
        public static LotteryDetailCollection GetCollection()
        {
            LotteryDetailCollection tmpCollection = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLotteryDrawing", myConnection))
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

        #region ||=======  GET COLLECTION | LOTTERY-DRAWING BY LOTTERY-ID | PARAM LOTTERY-ID  =======||
        public static LotteryDetailCollection GetCollection(int id)
        {
            LotteryDetailCollection tmpCollection = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLotteryDrawing", myConnection))
                {

                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetCollectionDrawing_ByLotteryId);
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

        #region ||=======  SAVE/UPDATE ITEM | LOTTERY-DRAWING-ITEM | PARAM LOTTERY-DRAWING-OBJECT  =======||
        public static int SaveItem(LotteryDetail lottoItem)
        {
            int recordId = 0;

            QueryExecuteType queryId = QueryExecuteType.InsertItem;

            if (lottoItem.LotteryDrawingId > 0)
                queryId = QueryExecuteType.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteLotteryDrawing", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", queryId);

                    if (lottoItem.LotteryDrawingId != 0)
                        myCommand.Parameters.AddWithValue("@LotteryDrawingId", lottoItem.LotteryDrawingId);

                    if (lottoItem.LotteryId != 0)
                        myCommand.Parameters.AddWithValue("@LotteryId", lottoItem.LotteryId);

                    if (!string.IsNullOrEmpty(lottoItem.Jackpot))
                        myCommand.Parameters.AddWithValue("@Jackpot", lottoItem.Jackpot);

                    if (lottoItem.LotteryDrawingDate != null)
                        myCommand.Parameters.AddWithValue("@DrawDate", lottoItem.LotteryDrawingDate);


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

        #region ||=======  DELETE | LOTTERY-DRAWING-ITEM | PARAM LOTTERY-DRAWING-ID  =======||
        public static int DeleteItem(int id)
        {
            int deletedRecord = 0;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand_1 = new SqlCommand("usp_ExecuteWinningNumber", myConnection))
                {
                    myCommand_1.CommandType = CommandType.StoredProcedure;
                    myCommand_1.Parameters.AddWithValue("@QueryId", QueryExecuteType.DeleteItem_ByDrawingId);
                    myCommand_1.Parameters.AddWithValue("@LotteryDrawingId", id);

                    myConnection.Open();
                    myCommand_1.ExecuteNonQuery();
                }
                myConnection.Close();

                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteLotteryDrawing", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QueryExecuteType.DeleteItem_ByDrawingId);
                    myCommand.Parameters.AddWithValue("@LotteryDrawingId", id);

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

            tmpItem.LotteryDrawingId = myReader.GetInt32(myReader.GetOrdinal("LotteryDrawingId"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("LotteryId")))
                tmpItem.LotteryId = myReader.GetInt32(myReader.GetOrdinal("LotteryId"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("Jackpot")))
                tmpItem.Jackpot = myReader.GetString(myReader.GetOrdinal("Jackpot"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("DrawDate")))
                tmpItem.LotteryDrawingDate = myReader.GetDateTime(myReader.GetOrdinal("DrawDate"));

            return tmpItem;

        }


        #endregion

    }
}
