﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finance.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public string Day { get; set; }
        public TransactionType Type { get; set; }
        public bool IsPaidThisMonth { get; set; }
        public DateTime? LastPaymentDate { get; set; }
        [ForeignKey("CategoryFinance")]
        public int CategoryId { get; set; }
        public CategoryFinance Category { get; set; }
    }

    public enum TransactionType
    {
        Income,
        Expense
    }
}
