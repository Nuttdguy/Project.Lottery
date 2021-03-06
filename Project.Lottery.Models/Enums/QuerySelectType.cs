﻿


namespace Project.Lottery.Models
{
    public enum QuerySelectType
    {

        #region SECTION 1 ||=======  GET SINGLE ITEM  =======||

        #region ||=======  GENERAL ITEM QUERIES  =======||
        None = 0,
        GetItem = 10,
        #endregion

        #endregion

        #region ||=======  ITEM QUERIES | BY NAME  =======||
        GetItem_ByName = 100,
        GetItemDrawing_ByName = 110,
        #endregion

        #region ||=======  ITEM QUERIES | BY DRAW-DATE  =======||
        GetItem_ByDrawDate = 200,
        #endregion

        #region ||=======  ITEM QUERIES | BY DRAW-DATE, MISC SORT  =======||
        GetItem_ByDrawDate_MostRecent = 300,
        #endregion





        #region SECTION 2 ||=======  GET COLLECTION  =======||

        #region ||=======  GENERAL COLLECTION QUERIES  =======||

        GetCollection = 510,
        #endregion

        #region ||=======  GENERAL COLLECTION QUERIES  =======||

        GetCollectionName_ByLotteryId = 600,
        GetCollectionDrawing_ByLotteryId = 610,
        GetCollectionDrawing_ByLotteryDrawingId = 620,
        #endregion

        #region ||=======  COLLECTION QUERIES | BY ID'S =======||

        GetDrawingResultCollection_DrawingAll = 750,
        GetDrawingResultCollection_ByLotteryId = 760,
        #endregion

        #endregion

    }
}
