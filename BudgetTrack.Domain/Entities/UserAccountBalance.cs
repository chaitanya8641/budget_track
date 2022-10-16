﻿using BudgetTrack.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetTrack.Domain.Entities
{
    public class UserAccountBalance
    {
        [Key]
        public Guid UserAccountBalanceId { get; set; }
        public Guid UserId { get; set; }
        public decimal AccounrBalance { get; set; }
        public TransactionType Type { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; } = null!;
    }
}