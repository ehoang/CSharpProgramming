using System;
using System.Collections;
using System.Text;


namespace CommonLibrary
{
    /// <summary>Represents a collection of <see cref="Transaction"/> objects.</summary>
    [Serializable]
    public class TransactionCollection : CollectionBase
    {
        /// <summary>Adds a <see cref="Transaction"/> to the collection.</summary>
        /// <param name="item">The <see cref="Transaction"/> to be added.</param>
        public void Add(Transaction item)
        {
            List.Add(item);
        }

        /// <summary>Determines whether a <see cref="Transaction"/> is in the collection.</summary>
        /// <param name="item">The <see cref="Transaction"/> to be checked.</param>
        /// <returns></returns>
        public bool Contains(Transaction item)
        {
            return List.Contains(item);
        }

        /// <summary>Copy all <see cref="Transaction"/> in this collection into an array.</summary>
        /// <param name="array">An array of <see cref="Transaction"/> to hold all of <see cref="Transaction"/> in this collection</param>
        /// <param name="arrayIndex">starting index.</param>
        public void CopyTo(Transaction[] array, int arrayIndex)
        {
            List.CopyTo(array, arrayIndex);
        }

        /// <summary>Gets the <see cref="Transaction"/> at this index</summary>
        /// <param name="index">Index of <see cref="Transaction"/>.</param>
        /// <returns><see cref="Transaction"/> at the specified index.</returns>
        public Transaction this[int index]
        {
            get
            {
                return (Transaction)this.List[index];
            }
            set
            {
                this.List[index] = value;
            }
        }
    }
}
