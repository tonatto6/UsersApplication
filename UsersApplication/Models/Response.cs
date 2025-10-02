namespace UsersApplication.Models
{
    public class Response
    {
        public Response(){}

        public Response(int statusCode,bool error,object body)
        {
            StatusCode = statusCode;
            Error = error;
            Body = body;
        }

        public int StatusCode { get; set; }
        public bool Error { get; set; }
        public object Body { get; set; }
    }
}
