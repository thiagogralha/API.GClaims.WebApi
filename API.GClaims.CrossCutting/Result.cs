namespace API.GClaims.CrossCutting
{
    public class Result<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public int ErrorCode { get; set; }
        public string Message { get; set; }
    }
}
