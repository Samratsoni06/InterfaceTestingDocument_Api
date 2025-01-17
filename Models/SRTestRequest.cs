using System;
using System.Collections.Generic;

namespace InterfaceTestingDocument_Api.Models
{
    public class SRTestRequest
    {
        public string LotSnCode { get; set; }
        public string StationCode { get; set; }
        public string FailureReason { get; set; }
        public string WorkCenter { get; set; }
        public bool IsPass { get; set; }
        public string OrderNo { get; set; }
        public string TestFrameidNo { get; set; }
        public List<TestItem> TestItems { get; set; }
    }

    public class TestItem
    {
        public string ItemName { get; set; }
        public bool ItemResult { get; set; }
        public DateTime ItemStartTime { get; set; }
        public DateTime ItemEndTime { get; set; }
        public string ItemDuration { get; set; }
    }
}
