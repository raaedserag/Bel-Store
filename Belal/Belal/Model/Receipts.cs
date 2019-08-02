using System;

namespace Belal.Model
{
    class Receipts
    {
        public string Id { get; set; }
        
        public string Receipt_date { get; set; }

        public string Client_name { get; set; }

        public string Client_address { get; set; }

        public string Client_phone { get; set; }

        public string Receipt_type { get; set; }

        public string Pay_type { get; set; }

        public string Past_Balance { get; set; }

        public string receipt_total { get; set; }
        
        public string receipt_dis { get; set; }

        public string receipt_dis_total { get; set; }

        public string Paid { get; set; }

        public string Newbalance { get; set; }

        public string Readable_balance { get; set; }

        public string Notes { get; set; }
    }
}
