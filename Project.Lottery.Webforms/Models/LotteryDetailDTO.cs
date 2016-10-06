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
        public DateTime DrawDates { get; set; }
        #endregion

        #region INTERFACE 3 ||=======  IWinningNumberDTO

        public int WinningNumberId { get; set; }
        public int BallNumber { get; set; }
        #endregion

        #region INTERFACE 4 ||=======  IBallTypeDTO

        public int BallTypeId { get; set; }
        public string BallTypeDescription { get; set; }

        #endregion

    }

}