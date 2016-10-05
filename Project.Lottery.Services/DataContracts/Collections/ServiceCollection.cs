using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Project.Lottery.Services.DataContracts
{

    [CollectionDataContract(Name = "LotteryDetailDTOCollection")]
    public class LotteryDetailDTOCollection : Collection<LotteryDetailDTO> { };

}