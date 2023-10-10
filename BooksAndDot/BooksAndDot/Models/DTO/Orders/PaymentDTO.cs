using BooksAndDot.Models.Users;
using System;

namespace BooksAndDot.Models.DTO.Orders {
    public class PaymentDTO {
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public double Sum { get; set; }
        public DateTime DatePayment { get; set; }
    }
}
