using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewVidly.Models
{
    public class MembershipType 
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationsInMonth { get; set; }
        public byte DiscountRate { get; set; }

        public static string PayasYouGO;
        public static string Monthly;
    }
}