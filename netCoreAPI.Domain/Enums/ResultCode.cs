namespace netCoreAPI.Domain.Enums
{
    public class ResultCode
    {
        public ResultCode(int statusCode, object value)
        {
            this.statusCode = statusCode;
            this.value = value;
        }
        public int statusCode;
        public object value;
    }
}
