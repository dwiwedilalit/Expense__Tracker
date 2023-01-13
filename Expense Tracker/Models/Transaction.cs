using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Expense_Tracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualBasic;

namespace Expense_Tracker.Models
{
	public class Transaction
	{
		[Key]
		public int TransactionId { get; set; }

		//CategoryId
		[Range(1, int.MaxValue, ErrorMessage = "Please select a category.")]
		public int CategoryId { get; set; }
		public Category? Category { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than 0.")]
		public int Amount { get; set; }
		[Column(TypeName = "nvarchar(75)")]
		public string? Note { get; set; }

		public DateTime Date { get; set; } = DateTime.Now;

		[NotMapped]
		public string? FormattedAmount
		{
			get
			{
				return ((Category == null || Category.Type == "Expense") ? "-" : "+") + Amount.ToString(" ₹ 0");
			}
		}
	}
}