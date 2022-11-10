using System;

namespace Teste_GFT_CreditSuisse.DomainTrade
{
    public interface ITrade
    {
        double Value { get; } //indicates the transaction amount in dollars
        string ClientSector { get; } //indicates the client´s sector which can be "Public" or "Private"
        DateTime NextPaymentDate { get; } //indicates when the next payment from the client to the bank is expected
        string category { get; }

        //Question 2. 
        //bool IsPoliticallyExposed { get; }
    }
}
