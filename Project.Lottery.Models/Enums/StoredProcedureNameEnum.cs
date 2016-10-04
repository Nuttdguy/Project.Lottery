using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Lottery.Models.Enums
{
    public enum StoredProcedureNameEnum
    {
        None,
        usp_GetLottery,
        usp_GetLocation,
        usp_GetLotteryLocation,

        usp_ExecuteLottery,
        usp_ExecuteLocation,
        usp_ExecuteLotteryLocation

    }
}
