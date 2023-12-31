using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MAUISqliteDemo
{

    [Table("BankInfo")]
    public class BankInfo
    {


        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Column("DepositAmount")]
        public double DepositAmount { get; set; }

        [Column("CardNumber")]
        public string CardNumber { get; set; }

        [Column("CardName")]
        public string CardName { get; set; }

        [Column("ExpDate")]
        public string ExpDate { get; set; }

        [Column("CVV")]
        public int CVV { get; set; }

        [Column("BillingAdd")]
        public string BillingAdd { get; set; }

        [Column("Balance")]
        public double Balance { get; set; }
    }
}
