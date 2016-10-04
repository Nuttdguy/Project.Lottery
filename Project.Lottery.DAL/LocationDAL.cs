using Project.Lottery.Models;
using Project.Lottery.Models.Collections;
using Project.Lottery.Models.Enums;
using System.Data.SqlClient;
using System.Data;

namespace Project.Lottery.DAL
{
    public static class LocationDAL
    {

        #region SECTION 1 ||=======  GET ITEM  =======||

        #region ||=======  GET | SINGLE-ITEM | LOCATION BY LOCATION-ID | PARAM LOCATION-ID  =======||
        public static LotteryDetail GetItem(int id)
        {
            LotteryDetail tmpObj = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLocation", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetItem);
                    myCommand.Parameters.AddWithValue("@LocationId", id);

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

        #region ||=======  GET COLLECTION | LOCATION | ALL  =======||
        public static LotteryDetailCollection GetCollection()
        {
            LotteryDetailCollection tmpCollection = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLocation", myConnection))
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

        #region ||=======  GET COLLECTION | LOCATION BY LOTTERY-ID | PARAM LOTTERY-NAME-ID  =======||
        public static LotteryDetailCollection GetCollection(int id)
        {
            LotteryDetailCollection tmpCollection = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLocation", myConnection))
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

        #region ||=======  GET COLLECTION | LOCATION BY SELECTED-LOTTERY-ID | PARAM LOTTERY-ID  =======||
        public static LotteryDetailCollection GetCollection(int id, int idType)
        {
            LotteryDetailCollection tmpCollection = null;
            string idTypeToUse = "";
            string prefix = "@";
            QuerySelectType query = QuerySelectType.GetCollectionDrawing_ByLotteryId;


            if (idType == (int)IdType.LocationId)
            {
                idTypeToUse = prefix + IdType.LocationId.ToString();
            }
            else
            {
                idTypeToUse = prefix + IdType.LotteryId.ToString();
            }



            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLocation", myConnection))
                {

                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", query);
                    myCommand.Parameters.AddWithValue(idTypeToUse, id);

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

        //==||  INTERNAL LOGIC NEEDS TO BE MOVED TO BLL-LAYER  ||==\\
        #region ||=======  SAVE/UPDATE ITEM(S) | LOCATION & ASSOCIATED GAME NAME | PARAM OBJECT  =======||
        public static int SaveItem(LotteryDetail lottoItem)
        {
            int recordId = 0;
            string spToUse = null;
            int locId = lottoItem.LocationId;
            int lottoId = lottoItem.LotteryId;
            QueryExecuteType queryId = QueryExecuteType.InsertItem;

            //===  USE LOGIC TO DECIDE WHICH STORED PROCEDURE TO UTILIZE
            if (locId > 0 && lottoId > 0 )
            {
                //==  INSERT LOTTERY & STATE RELATIONSHIP INTO JOIN TABLE
                //==  SETS THE STORED PROCEDURE TO THE JOIN TABLE
                spToUse = StoredProcedureNameEnum.usp_ExecuteLotteryLocation.ToString();
            }
            else if (locId > 0 )
            {
                //==  UPDATES THE LOCATION ID OF AN EXISTING RECORD
                spToUse = StoredProcedureNameEnum.usp_ExecuteLocation.ToString();
                queryId = QueryExecuteType.UpdateItem;
            }
            else
            {
                //==  INSERTS AND NEW RECORD INTO LOCATION TABLE
                spToUse = StoredProcedureNameEnum.usp_ExecuteLocation.ToString();
            }


            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand(spToUse, myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", queryId);

                    if (lottoItem.LocationId != 0)
                        myCommand.Parameters.AddWithValue("@LocationId", lottoItem.LocationId);

                    if (lottoItem.LotteryId != 0)
                        myCommand.Parameters.AddWithValue("@LotteryId", lottoItem.LotteryId);

                    if (!string.IsNullOrEmpty(lottoItem.State) && lottoId <= 0)
                        myCommand.Parameters.AddWithValue("@State", lottoItem.State);


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

        //==||  INTERNAL LOGIC NEEDS TO BE MOVED TO BLL-LAYER  ||==\\
        #region ||=======  DELETE ITEM(S) | LOCATION & ASSOCIATED GAME NAME | PARAM LOCATION-ID, LOTTERY-ID [OP] =======||
        public static int DeleteItem(int locId, int lottoId)
        {
            int deletedRecord = 0;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                //===   DELETE A SINGLE RECORD RELATIONSHIP BETWEEN LOCATION AND LOTTERY
                if (lottoId > 0 && locId > 0)
                {
                    using (SqlCommand myCommand = new SqlCommand("usp_ExecuteLotteryLocation", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.AddWithValue("@QueryId", QueryExecuteType.DeleteItem);
                        myCommand.Parameters.AddWithValue("@LocationId", locId);
                        myCommand.Parameters.AddWithValue("@LotteryId", lottoId);


                        myCommand.Parameters.Add(HelperDAL.GetReturnParameterInt("ReturnValue"));

                        myConnection.Open();
                        myCommand.ExecuteNonQuery();

                        deletedRecord = (int)myCommand.Parameters["@ReturnValue"].Value;

                    }
                    myConnection.Close();
                }
                //=======  DELETE A SINGLE RECORD PRIMARY LOCATION & ALL RECORDS ASSOCIATED WITH THAT LOCATION
                else if (locId > 0)
                {
                    if (lottoId == 0)
                    {
                        using (SqlCommand myCommand_1 = new SqlCommand("usp_ExecuteLotteryLocation", myConnection))
                        {
                            myCommand_1.CommandType = CommandType.StoredProcedure;
                            myCommand_1.Parameters.AddWithValue("@QueryId", QueryExecuteType.DeleteAll_ByLocationId);
                            myCommand_1.Parameters.AddWithValue("@LocationId", locId);
                            myCommand_1.Parameters.Add(HelperDAL.GetReturnParameterInt("ReturnValue"));

                            myConnection.Open();
                            myCommand_1.ExecuteNonQuery();

                            deletedRecord = (int)myCommand_1.Parameters["@ReturnValue"].Value;

                        }
                        myConnection.Close();

                        using (SqlCommand myCommand_2 = new SqlCommand("usp_ExecuteLocation", myConnection))
                        {
                            myCommand_2.CommandType = CommandType.StoredProcedure;
                            myCommand_2.Parameters.AddWithValue("@QueryId", QueryExecuteType.DeleteItem);
                            myCommand_2.Parameters.AddWithValue("@LocationId", locId);

                            myCommand_2.Parameters.Add(HelperDAL.GetReturnParameterInt("ReturnValue"));

                            myConnection.Open();
                            myCommand_2.ExecuteNonQuery();

                            deletedRecord = (int)myCommand_2.Parameters["@ReturnValue"].Value;
                        }
                        myConnection.Close();
                    }
                    else
                    {
                        using (SqlCommand myCommand_3 = new SqlCommand("usp_ExecuteLocation", myConnection))
                        {
                            myCommand_3.CommandType = CommandType.StoredProcedure;
                            myCommand_3.Parameters.AddWithValue("@QueryId", QueryExecuteType.DeleteItem);
                            myCommand_3.Parameters.AddWithValue("@LocationId", locId);

                            myCommand_3.Parameters.Add(HelperDAL.GetReturnParameterInt("ReturnValue"));

                            myConnection.Open();
                            myCommand_3.ExecuteNonQuery();

                            deletedRecord = (int)myCommand_3.Parameters["@ReturnValue"].Value;
                        }
                        myConnection.Close();
                    }

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

            tmpItem.LocationId = myReader.GetInt32(myReader.GetOrdinal("LocationId"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("State")))
                tmpItem.State = myReader.GetString(myReader.GetOrdinal("State"));


            return tmpItem;

        }


        #endregion
    }
}
