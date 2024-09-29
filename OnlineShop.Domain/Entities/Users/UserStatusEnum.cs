using System.ComponentModel;

namespace OnlineShop.Domain.Entities.Users
{
    public enum UserStatus
    {
        [Description("فعال")]
        Active,
        [Description("غیرفعال")]
        Inactive,
        [Description("منتظر تایید")]
        Pending
    }
}
