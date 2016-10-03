using Project.Lottery.Models;
using Project.Lottery.Models.Collections;
using System.Data.SqlClient;
using System.Data;



namespace Project.Lottery.DAL
{
    public static class WinningNumberDAL
    {

        #region SECTION 1 ||=======  GET ITEM  =======||

        #region ||=======  GET WINNING-NUMBER-ITEM | PARAM ~ DRAWING-ID  =======||
        public static LotteryDetail GetItem(int id)
        {
            LotteryDetail tmpObj = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetWinningNumber", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetItem);
                    myCommand.Parameters.AddWithValue("@WinningNumberId", id);

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

        #region ||=======  GET COLLECTION | ALL  =======||
        public static LotteryDetailCollection GetCollection()
        {
            LotteryDetailCollection tmpCollection = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetWinningNumber", myConnection))
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

        #region ||=======  GET COLLECTION | ALL  =======|| GETS THE DRAWING RESULT FILTERED BY SELECTED LOTTERY 
        public static LotteryDetailCollection GetCollection(int id)
        {
            LotteryDetailCollection tmpCollection = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetWinningNumber", myConnection))
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

        #region ||=======  SAVE/UPDATE LOTTERY-ITEM | PARAM ~ NONE, LOTTERY-ID [OP]  =======||
        public static int SaveItem(LotteryDetail lottoItem)
        {
            int recordId = 0;

            QueryExecuteType queryId = QueryExecuteType.InsertItem;

            if (lottoItem.LotteryDrawingId > 0 && lottoItem.WinningNumberId > 0)
                queryId = QueryExecuteType.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteWinningNumber", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", queryId);

                    if (lottoItem.WinningNumberId != 0)
                        myCommand.Parameters.AddWithValue("@WinningNumberId", lottoItem.WinningNumberId);

                    if (lottoItem.LotteryDrawingId != 0)
                        myCommand.Parameters.AddWithValue("@LotteryDrawingId", lottoItem.LotteryDrawingId);

                    if (lottoItem.BallTypeId != 0)
                        myCommand.Parameters.AddWithValue("@BallTypeId", lottoItem.BallTypeId);

                    if (lottoItem.BallNumber != 0)
                        myCommand.Parameters.AddWithValue("@BallNumber", lottoItem.BallNumber);


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

        #region ||=======  DELETE WINNING-NUMBER-ITEM | PARAM ~ DRAWING-ID  =======||
        public static int DeleteItem(int id)
        {
            int deletedRecord = 0;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteWinningNumber", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QueryExecuteType.DeleteItem);
                    myCommand.Parameters.AddWithValue("@WinningNumberId", id);

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

            tmpItem.WinningNumberId = myReader.GetInt32(myReader.GetOrdinal("WinningNumberId"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("LotteryDrawingId")))
                tmpItem.LotteryDrawingId = myReader.GetInt32(myReader.GetOrdinal("LotteryDrawingId"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("BallTypeId")))
                tmpItem.BallTypeId = myReader.GetInt32(myReader.GetOrdinal("BallTypeId"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("BallNumber")))
                tmpItem.BallNumber = myReader.GetInt32(myReader.GetOrdinal("BallNumber"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("BallTypeDescription")))
                tmpItem.BallTypeDescription = myReader.GetString(myReader.GetOrdinal("BallTypeDescription"));

            return tmpItem;

        }


        #endregion

    }
}
