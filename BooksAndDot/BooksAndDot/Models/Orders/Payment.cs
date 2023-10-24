﻿using BooksAndDot.Models.DTO.Orders;
using BooksAndDot.Models.Users;
using System;

namespace BooksAndDot.Models.Orders {
    public class Payment {
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public double Sum { get; set; }
        public DateTime DatePayment { get; set; }

        public PaymentDTO PaymentExtension() {
            PaymentDTO paymentDTO = new PaymentDTO() { 
                PaymentId = PaymentId,
                UserId = UserId,
                Sum = Sum,
                DatePayment = DatePayment
            };
            return paymentDTO;
        }

    }
}
