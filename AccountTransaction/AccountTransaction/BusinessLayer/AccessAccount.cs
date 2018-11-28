using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountTransaction.DataLayer;

namespace AccountTransaction.BusinessLayer
{
    public class AccessAccount
    {
        public List<Account> accounts = new List<Account>()
        {
            new Account(){AccountNumber=92920131323, CustomerName="Customer 1",Status="Active"},
            new Account(){AccountNumber=89234999233, CustomerName="Customer 2",Status="Active"},
            new Account(){AccountNumber=92342009022, CustomerName="Customer 3",Status="Active"},
            new Account(){AccountNumber=89989234992, CustomerName="Customer 4",Status="Inactive"},
            new Account(){AccountNumber=23900000002, CustomerName="Customer 5",Status="Inactive"},
            new Account(){AccountNumber=49398453948, CustomerName="Customer 6",Status="Active"}


        };

        public List<Transaction> transactions = new List<Transaction>()
        {
            new Transaction(){TransactionId="TX323423002",AccountNum=92920131323,TransactionType="Credit",Amount=10000,Remarks="Initial Deposit"},
            new Transaction(){TransactionId="TX234234234",AccountNum=89234999233,TransactionType="Credit",Amount=23560,Remarks="Initial Deposit"},
            new Transaction(){TransactionId="TX455611231",AccountNum=92342009022,TransactionType="Credit",Amount=2333,Remarks="Initial Deposit"},
            new Transaction(){TransactionId="TX324564542",AccountNum=89989234992,TransactionType="Credit",Amount=500,Remarks="Initial Deposit"},
            new Transaction(){TransactionId="TX223423222",AccountNum=23900000002,TransactionType="Credit",Amount=1000,Remarks="Initial Deposit"},
            new Transaction(){TransactionId="TX463463454",AccountNum=49398453948,TransactionType="Credit",Amount=199820,Remarks="Initial Deposit"},
            new Transaction(){TransactionId="TX234235233",AccountNum=89989234992,TransactionType="Debit",Amount=500,Remarks="ATM/929392"},
            new Transaction(){TransactionId="TX923989392",AccountNum=92920131323,TransactionType="Credit",Amount=3000,Remarks="NEFT/23322"},
            new Transaction(){TransactionId="TX239482938",AccountNum=49398453948,TransactionType="Credit",Amount=20000,Remarks="NEFT/44333"},
            new Transaction(){TransactionId="TX212312322",AccountNum=92920131323,TransactionType="Debit",Amount=1500,Remarks="ATM/30202"},
            new Transaction(){TransactionId="TX929828222",AccountNum=89234999233,TransactionType="Credit",Amount=4500,Remarks="NEFT/3322"},
            new Transaction(){TransactionId="TX239892282",AccountNum=23900000002,TransactionType="Debit",Amount=1000,Remarks="ATM/3232"},
            new Transaction(){TransactionId="TX239892003",AccountNum=49398453948,TransactionType="Debit",Amount=3000,Remarks="ATM/2342"}
        };

        /// <summary>
        /// Get the transaction details of all accounts
        /// </summary>
        /// <returns></returns>
        public List<object> AllAccounts()
        {
            //using linq
            var query = from acct in accounts
                        join trans in transactions on acct.AccountNumber equals trans.AccountNum
                        select new
                        {
                            Name = acct.CustomerName,
                            AcctNumber = acct.AccountNumber,
                            AcctStatus = acct.Status,
                            Balance = (transactions.Where(t => t.AccountNum == acct.AccountNumber && t.TransactionType == "Credit")
                                        .Sum(tr => tr.Amount) -
                                             transactions.Where(t => t.AccountNum == acct.AccountNumber && t.TransactionType == "Debit")
                                        .Sum(tr => tr.Amount))
                        };
            return query.Distinct().ToList<object>();
        }

        /// <summary>
        /// Get the transaction details of all active accounts
        /// </summary>
        /// <returns></returns>
        public List<object> GetActiveAccounts()
        {
            //using linq
            var query = from acct in accounts
                        join trans in transactions on acct.AccountNumber equals trans.AccountNum
                        where acct.Status == "Active"
                        select new
                        {
                            Name = acct.CustomerName,
                            AcctNumber = acct.AccountNumber,
                            AcctStatus = acct.Status,
                            Balance = (transactions.Where(t => t.AccountNum == acct.AccountNumber && t.TransactionType == "Credit")
                                        .Sum(tr => tr.Amount) -
                                             transactions.Where(t => t.AccountNum == acct.AccountNumber && t.TransactionType == "Debit")
                                        .Sum(tr => tr.Amount))
                        };
            return query.Distinct().ToList<object>();
        }

        /// <summary>
        /// Get the transaction details of accounts with minimum balance 10000/-
        /// </summary>
        /// <returns></returns>
        public List<object> GetValidBalanceAccounts()
        {
            //using linq
            var query = from acct in accounts
                        join trans in transactions on acct.AccountNumber equals trans.AccountNum
                        select new
                        {
                            Name = acct.CustomerName,
                            AcctNumber = acct.AccountNumber,
                            AcctStatus = acct.Status,
                            Balance = (transactions.Where(t => t.AccountNum == acct.AccountNumber && t.TransactionType == "Credit")
                                        .Sum(tr => tr.Amount) -
                                             transactions.Where(t => t.AccountNum == acct.AccountNumber && t.TransactionType == "Debit")
                                        .Sum(tr => tr.Amount))
                        };
            return query.Distinct().Where(ac => ac.Balance >= 10000).ToList<object>();
        }

        /// <summary>
        /// Get the transaction details of all active accounts
        /// </summary>
        /// <returns></returns>
        public List<object> GetLowBalanceAccounts()
        {
            //using linq
            var query = from acct in accounts
                        join trans in transactions on acct.AccountNumber equals trans.AccountNum
                        select new
                        {
                            Name = acct.CustomerName,
                            AcctNumber = acct.AccountNumber,
                            AcctStatus = acct.Status,
                            Balance = (transactions.Where(t => t.AccountNum == acct.AccountNumber && t.TransactionType == "Credit")
                                        .Sum(tr => tr.Amount) -
                                             transactions.Where(t => t.AccountNum == acct.AccountNumber && t.TransactionType == "Debit")
                                        .Sum(tr => tr.Amount))
                        };
            return query.Distinct().Where(ac => ac.Balance <= 500).ToList<object>();
        }
    }
}
