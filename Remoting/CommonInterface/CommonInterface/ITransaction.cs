using System;
using System.Collections.Generic;
using System.Text;

namespace CommonInterface
{
    /// <summary>The interface to the transaction object</summary>
    public interface ITransaction
    {
        long ID { get; set;}
        DateTime PostingDate { get;set;}
        string Description { get;set;}
        double Amount { get;set;}
        double Balance { get; set;}
    }
}
