namespace OnlineShop.Common.Dto
{
    public class CreateResultDto
    {
        public bool IsSuccess{ get; set; }
        public string Message { get; set; }
    }

    public class CreateResultDto<T> 
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
