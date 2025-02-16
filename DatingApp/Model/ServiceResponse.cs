namespace DatingApp.Model
{
    public class ServiceResponse
    {
        public bool IsSuccess { get; set; } = true;
        public string ErrorMessage { get; set; } = "";
        public object Data { get; set; }
    }
}
