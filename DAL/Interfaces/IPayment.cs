using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPayment
    {
        Task ProcessPaymentAsync(Payment paymentDetails);
        Task<string> GetPaymentStatusAsync(int paymentId);
        Task RefundPaymentAsync(int paymentId, decimal amount);
        //Task<List<Transaction>> GetTransactionHistoryAsync(string userId);
        bool ValidatePaymentData(Payment paymentDetails);
        Task CancelPaymentAsync(int paymentId);
        Task<string> GenerateInvoiceAsync(Payment invoiceDetails);
        bool VerifyPayment(Payment paymentDetails);

        Task<List<Payment>> ReadAsync();
        Task<Payment> ReadAsync(int id);
        Task<Payment> CreateAsync(Payment payment);

        List<Payment> GetPaymentsByStatus(PaymentStatus status);
        List<Payment> GetPaymentsByCardHolder(string cardHolderName);
        List<Payment> GetPendingPayments();
        List<Payment> GetRefundedPayments();
        List<Payment> GetCanceledPayments();

    }
}
