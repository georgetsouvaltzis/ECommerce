namespace ECommerce.Service.Infrastructure
{

    public interface IResponse<TResponse, TData> where TResponse : class
    {
        public TData Data { get; set; }
        public bool IsSuccess { get; set; }

    }

}
