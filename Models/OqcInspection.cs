namespace InterfaceTestingDocument_Api.Models
{
    public class OqcInspection
    {
        public string InspectionNo { get; set; } =string.Empty;
        public string MoOrderNo { get; set; } = string.Empty;
        public int Num { get; set; }
        public string LineId { get; set; } = string.Empty;
        public string StationCode { get; set; } = string.Empty;
        public int Pattern { get; set; }
        public int StatusCode { get; set; }
        public DateTime lastModificationTime { get; set; }
        public List<SnCode> SnCodes { get; set; } = new List<SnCode>();
        public List<ScanSnCode> ScanSnCodes { get; set; } = new List<ScanSnCode>();
        public List<InspItem> InspItems { get; set; } =new List<InspItem>();

    }
    public class InspItem
    {
        public string TestItemId { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string StdText { get; set; } = string.Empty;
        public int SampleNum { get; set; }
        public int AcceptNum { get; set; }
        public int RejectNum { get; set; }
        public int Grade { get; set; }
        public int InspectionType { get; set; }
    }
    public class ScanSnCode
    {
        public string SnCode { get; set; } = string.Empty;
        public int InspectionType { get; set; }
        public string Remark { get; set; } = string.Empty;
    }

    public class SnCode
    {
        public string snCode { get; set; } = string.Empty;
        public int Qty { get; set; }
        public int KeyType { get; set; }
    }

}
