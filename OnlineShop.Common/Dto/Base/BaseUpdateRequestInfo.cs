namespace OnlineShop.Common.Dto.Base
{
    public class BaseUpdateRequestInfo<IIdType>
    {
        public IIdType Id { get; set; }
    }

    public class BaseUpdateRequestInfo : BaseUpdateRequestInfo<ulong>
    {
    }
}
