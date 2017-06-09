using System;

namespace Iyzipay
{
    public class IyzipayResource
    {
        public String Status { get; set; }
        public String ErrorCode { get; set; }
        public String ErrorMessage { get; set; }
        public String ErrorGroup { get; set; }
        public String Locale { get; set; }
        public long SystemTime { get; set; }
        public String ConversationId { get; set; }

        public IyzipayResource()
        {
        }
    }
}