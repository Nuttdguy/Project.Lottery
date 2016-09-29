


namespace Project.Lottery.Models
{
    public enum QueryExecuteType
    {
        None = 0,
        GetItem = 10,
        GetItemById = 12,
        GetDrawingByLotteryName = 14,
        GetCollection = 20,
        GetGameResultCollectionByDrawId = 22,
        GetLotteryNameCollection = 24,
        GetNext10 = 30
    }
}
