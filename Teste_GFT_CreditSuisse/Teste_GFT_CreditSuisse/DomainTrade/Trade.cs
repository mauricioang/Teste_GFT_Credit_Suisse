using System;
using System.Collections.Generic;
using System.Text;

namespace Teste_GFT_CreditSuisse.DomainTrade
{
    public class Trade : ITrade
    {
        private readonly double _value;
        private readonly string _clientSector;
        private readonly DateTime _nextPayment;
        private readonly DateTime _referenceDate;

        //Question 2.
        //private readonly bool _IsPoliticallyExposed;

        public Trade(double value, string clientSector, DateTime nextPayment, DateTime referenceDate /*,bool isPoliticallyExposed = false*/)
        {
            _value = value;
            _clientSector = clientSector;
            _nextPayment = nextPayment;
            _referenceDate = referenceDate;

            //Question 2.
            //_IsPoliticallyExposed = isPoliticallyExposed;
        }

        public double Value => _value;

        public string ClientSector => _clientSector;

        public DateTime NextPaymentDate => _nextPayment;

        public string category => defineCategory(_referenceDate);

        //Question 2.
        //public bool IsPoliticllyExposed => _IsPoliticallyExposed;

        public string defineCategory(DateTime referenceDate)
        {
            //Question 2
            ////New Category
            //if (this.IsPoliticallyExposed == true)
            //{
            //    return "PEP";
            //}

            TimeSpan time = referenceDate - this.NextPaymentDate;

            //1. EXPIRED: Trades whose next payment date is late by more than 30 days based on a reference date which will be given.
            if (time.TotalDays > 30)
            {
                return "EXPIRED";
            }

            //2. HIGHRISK: Trades with value greater than 1,000,000 and client from Private Sector.
            if (this.Value > 1000000 && this.ClientSector.ToUpper().Trim() == "PRIVATE")
            {
                return "HIGHRISK";
            }

            //3. MEDIUMRISK: Trades with value greater than 1,000,000 and client from Public Sector.
            if (this.Value > 1000000 && this.ClientSector.ToUpper().Trim() == "PUBLIC")
            {
                return "MEDIUMRISK";
            }

            return "UNDEFINED";
        }
    }
}
