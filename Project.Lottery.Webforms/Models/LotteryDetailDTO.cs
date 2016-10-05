using System;
using Project.Lottery.Models;
using System.Collections.Generic;
using System.Web.Script.Serialization;


namespace Project.Lottery.Webforms.Models
{

    public class LotteryDetailDTO 
    {
        public int LotteryId { get; set; }
        public string LotteryName { get; set; }
        public bool HasSpecialBall { get; set; }
        public bool HasRegularBall { get; set; }
        public int NumberOfBalls { get; set; }


        #region INTERFACE 1 ||=======  ILocationDTO

        public int LocationId { get; set; }
        public string State { get; set; }
        #endregion

        #region INTERFACE 2 ||=======  ILotteryDrawingDTO

        public int LotteryDrawingId { get; set; }
        public string Jackpot { get; set; }
        public DateTime DrawDate { get; set; }
        #endregion

        #region INTERFACE 3 ||=======  IWinningNumberDTO

        public int WinningNumberId { get; set; }
        public int BallNumber { get; set; }
        #endregion

        #region INTERFACE 4 ||=======  IBallTypeDTO

        public int BallTypeId { get; set; }
        public string BallTypeDescription { get; set; }

        #endregion

        #region SECTION 2 ||======= JSON SERIALIZATION  =======||
        public T SerializeItem<T>(string json)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            T item = serializer.Deserialize<T>(json);

            return item;
        }

        public List<T> SerializeCollection<T>(string json)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<T> collection = serializer.Deserialize<List<T>>(json);

            return collection;
        }

        #endregion

    }

}