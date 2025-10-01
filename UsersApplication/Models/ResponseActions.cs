namespace UsersApplication.Models
{
    public class ResponseActions<T>
    {
        public ResponseActions(){}

        public ResponseActions(T id, string message)
        {
            Id = id;
            Message = message;
        }

        public T Id { get; set; }
        public string Message { get; set; }
    }
}
