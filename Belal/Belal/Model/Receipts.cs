using System;

namespace Belal.Model
{
    class Receipts
    {
        public int Id { get; set; }

        public DateTime Receipt_data { get; set; }

        public int Client_id { get; set; }

        public float Past_Balance { get; set; }

        public float receipt_total { get; set; }

        public float Paid { get; set; }

        public float Newbalance { get; set; }

        public string Readable_balance { get; set; }

        public string Notes { get; set; }
    }
}
