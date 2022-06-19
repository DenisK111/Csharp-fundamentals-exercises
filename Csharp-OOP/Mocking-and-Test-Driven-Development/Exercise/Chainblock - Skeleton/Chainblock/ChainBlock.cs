using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock
{
    public class ChainBlock : IChainblock
    {
        private Dictionary<int, ITransaction> transactionList;

        public ChainBlock()
        {
            transactionList = new Dictionary<int, ITransaction>();
        }
        public int Count => transactionList.Count;

        public void Add(ITransaction tx)
        {
            if (transactionList.ContainsKey(tx.Id))
            {
                return;
            }

            transactionList.Add(tx.Id, tx);


        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!transactionList.ContainsKey(id))
            {
                throw new ArgumentException("Transaction not found");
            }

            transactionList[id].Status = newStatus;
        }

        public bool Contains(ITransaction tx) => transactionList.ContainsKey(tx.Id);


        public bool Contains(int id) => transactionList.ContainsKey(id);


        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi) => transactionList.Values.Where(x => x.Amount >= lo && x.Amount <= hi);


        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById() => transactionList.Values.OrderByDescending(x => x.Amount).ThenBy(x => x.Id);


        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            var toBeReturned = transactionList.Values.Where(x => x.Status == status).OrderByDescending(x => x.Amount).Select(x => x.To);

            if (toBeReturned.Count() == 0)
            {
                throw new InvalidOperationException("No matches found");
            }

            return toBeReturned;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            var toBeReturned = transactionList.Values.Where(x => x.Status == status).OrderByDescending(x => x.Amount).Select(x => x.From);

            if (toBeReturned.Count() == 0)
            {
                throw new InvalidOperationException("No matches found");
            }

            return toBeReturned;
        }

        public ITransaction GetById(int id)
        {
            var toBeReturned = transactionList.FirstOrDefault(x => x.Key == id);

            if (toBeReturned.Value == null)
            {
                throw new InvalidOperationException("No matches found");
            }

            return toBeReturned.Value;

        }


        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {

            var returned = transactionList.Values.Where(x => x.To == receiver && x.Amount >= lo && x.Amount < hi).OrderByDescending(x => x.Amount).ThenBy(x => x.Id);

            if (returned.Count() == 0)
            {
                throw new InvalidOperationException("No matches found");
            }

            return returned;

        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
       => transactionList
            .Any(x => x.Value.To == receiver)
            ? transactionList.Values
                .Where(x => x.To == receiver)
                .OrderByDescending(x => x.Amount)
                .ThenBy(x => x.Id)
            : throw new InvalidOperationException();

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        => transactionList
            .Any(x => x.Value.From == sender && x.Value.Amount > amount)
            ? transactionList.Values
                .Where(x => x.From == sender && x.Amount > amount)
                .OrderByDescending(x => x.Amount)
            : throw new InvalidOperationException();

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
         => transactionList
            .Any(x => x.Value.From == sender)
            ? transactionList.Values
                .Where(x => x.From == sender)
                .OrderByDescending(x => x.Amount)
            : throw new InvalidOperationException();

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        => transactionList
            .Any(x => x.Value.Status == status)
            ? transactionList.Values
                .Where(x => x.Status == status)
                .OrderByDescending(x => x.Amount)
            : throw new InvalidOperationException();

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
       => transactionList.Values
            .Where(x => x.Status == status && x.Amount <= amount)
            .OrderByDescending(x => x.Amount);

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (var item in transactionList)
            {
                yield return item.Value;
            }
        }

        public void RemoveTransactionById(int id) 
        {
            if (!transactionList.ContainsKey(id))
            {
             throw new InvalidOperationException("No match found");
            }

                
            transactionList.Remove(id);
            return;
        }
        

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
