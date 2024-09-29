namespace OnlineShop.Common.Dto
{
    public class BaseUpdateRequestInfo<IIdType>
    {
        public IIdType Id { get; set; }
    }

    public class BaseUpdateRequestInfo : BaseUpdateRequestInfo<ulong>
    {
    }
}
