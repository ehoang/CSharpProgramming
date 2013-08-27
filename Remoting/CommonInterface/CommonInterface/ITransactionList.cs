using System;
using System.Collections.Generic;
using System.Text;

namespace CommonInterface
{
    public interface ITransactionList : IList<ITransaction>, ICollection<ITransaction>, IEnumerable<ITransaction>
    {
    }
}
