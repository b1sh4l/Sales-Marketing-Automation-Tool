using DAL.Interfaces;
using DAL.Models;
using iText.Kernel.Exceptions;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Repos
{
    internal class PaymentRepo : Repo, IRepo<Payment, int, Payment>, IPayment
    {

        public Task CancelPaymentAsync(int paymentId)
        {
            var payment = db.Payment.FirstOrDefault(p => p.Id == paymentId);
            if (payment != null)
            {
                payment.PaymentStatus = PaymentStatus.Canceled;
                db.SaveChanges();
            }

            return Task.CompletedTask;
        }

        public Payment Create(Payment obj)
        {
            db.Payment.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;

        }

        public bool Delete(int id)
        {
            var PaymentToDelete = db.Payment.Find(id);
            if (PaymentToDelete != null)
            {
                db.Payment.Remove(PaymentToDelete);
                return db.SaveChanges() > 0;
            }

            return false;
        }

        public Task<string> GenerateInvoiceAsync(Payment invoiceDetails)
        {
            var invoiceNumber = $"INV-{DateTime.Now:yyyyMMddHHmmss}";
            var invoiceFilePath = GenerateInvoicePdf(invoiceDetails, invoiceNumber);


            return Task.FromResult(invoiceFilePath);
        }

        private string GenerateInvoicePdf(Payment invoiceDetails, string invoiceNumber)
        {
            var filePath = @"C:\Users\sudar\OneDrive\Desktop\Invoice-" + invoiceNumber + ".pdf";
            try
            {
                using (var writer = new PdfWriter(filePath))
                {
                    using (var pdf = new PdfDocument(writer))
                    {
                        using (var document = new iText.Layout.Document(pdf))
                        {
                            document.Add(new Paragraph($"Invoice Number: {invoiceNumber}"));
                            document.Add(new Paragraph($"Invoice Date: {DateTime.Now:dd/MM/yyyy}"));
                            document.Add(new Paragraph($"Amount: {invoiceDetails.Amount}"));
                            document.Add(new Paragraph($"Status: {invoiceDetails.PaymentStatus}"));
                            document.Add(new Paragraph($"Card Number: {invoiceDetails.CardNumber}"));
                            document.Add(new Paragraph($"Card Holder Name: {invoiceDetails.CardHolderName}"));
                            document.Add(new Paragraph($"Expiration Date: {invoiceDetails.ExpirationDate}"));
                            document.Add(new Paragraph($"Email Address: {invoiceDetails.EmailAddress}"));

                            document.Close();
                        }
                    }
                }
            }
            catch (PdfException ex)
            {
                Console.WriteLine($"PdfException: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                return null;
            }
                return filePath;
        }
            
       

        public Payment GetAll()
        {
            return db.Payment.FirstOrDefault();
        }

        public Task<string> GetPaymentStatusAsync(int paymentId)
        {
            var payment = db.Payment.FirstOrDefault(p => p.Id == paymentId);
            if (payment != null)
            {
                return Task.FromResult(payment.PaymentStatus.ToString());
            }

            return Task.FromResult("Payment not found");
        }


        public Task ProcessPaymentAsync(Payment paymentDetails)
        {
            paymentDetails.PaymentStatus = PaymentStatus.Processed;
            db.SaveChanges();

            return Task.CompletedTask;
        }

        public Payment Read(int id)
        {
           return db.Payment.Find(id);
        }


        public List<Payment> Read()
        {
            return db.Payment.ToList();
        }



        public Task RefundPaymentAsync(int paymentId, decimal amount)
        {
            var payment = db.Payment.FirstOrDefault(p => p.Id == paymentId);
            if (payment != null)
            {
                payment.PaymentStatus = PaymentStatus.Refunded;
                db.SaveChanges();
            }

            return Task.CompletedTask;
        }

        public Payment Update(Payment obj)
        {
            var existingPayment = db.Payment.Find(obj.Id);
            Console.WriteLine($"existingPayment: {existingPayment}");

            if(existingPayment != null)
            {

                db.Entry(existingPayment).CurrentValues.SetValues(obj);

                if (db.SaveChanges() > 0)
                {
                    return existingPayment;
                }
            }
            return null;
        }

        public bool ValidatePaymentData(Payment paymentDetails)
        {
            return true;
        }

        public bool VerifyPayment(Payment paymentDetails)
        {
            return true;
        }

        public async Task<List<Payment>> ReadAsync()
        {
            return await db.Payment.ToListAsync();
        }

        public async Task<Payment> ReadAsync(int id)
        {
            return await db.Payment.FindAsync(id);
        }

        public async Task<Payment> CreateAsync(Payment payment)
        {
            db.Payment.Add(payment);
            await db.SaveChangesAsync();
            return payment;
        }

        object IRepo<Payment, int, Payment>.Read()
        {
            return db.Payment.ToList();
        }

    }
    
    
}
