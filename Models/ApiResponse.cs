namespace InterfaceTestingDocument_Api.Models
{
    public class ApiResponse
    {
        public object Result { get; set; }
        public string TargetUrl { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
        public bool UnAuthorizedRequest { get; set; }
        public bool __abp { get; set; }
    }
}
