namespace AC.Project.Application.Web.Payloads
{
    public class ResponseDTO
    {
        public string message { get; }

        public ResponseDTO(string message)
        {
            this.message = message;
        }
    }
}
