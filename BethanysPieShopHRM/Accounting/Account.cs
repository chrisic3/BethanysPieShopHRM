using System;

namespace BethanysPieShopHRM.Accounting
{
    //internal record Account
    //{
    //    private string accountNumber;

    //    public string AccountNumber
    //    {
    //        get
    //        {
    //            return accountNumber;
    //        }

    //        set
    //        {
    //            accountNumber = value;
    //        }
    //    }
    //}

    // Positional record
    public record Account(string AccountNumber);
}