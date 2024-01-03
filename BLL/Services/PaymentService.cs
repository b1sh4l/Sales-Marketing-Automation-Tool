using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using DAL.Migrations;

namespace BLL.Services
{
    public class PaymentService
    {

        public static List<PaymentDTO> GetAll()
        {
            var data = DataAccessFactory.PaymentData().Read();
            if (data == null)
            {
                return null;
            }
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Payment, PaymentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PaymentDTO>>(data);
            return mapped;
        }

        public static PaymentDTO Get(int id)
        {
            var data = DataAccessFactory.PaymentData().Read(id);

            if (data == null)
            {
                return null;
            }

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Payment, PaymentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PaymentDTO>(data);
            return mapped;
        }

        public static PaymentDTO Create(PaymentDTO payment)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PaymentDTO, Payment>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Payment>(payment);
            var data = DataAccessFactory.PaymentData().Create(mapped);
            if (data == null)
            {
                return null;
            }
            var cfg2 = new MapperConfiguration(c =>
            {
                c.CreateMap<Payment, PaymentDTO>();
            });
            var mapper2 = new Mapper(cfg2);
            var mapped2 = mapper2.Map<PaymentDTO>(data);
            return mapped2;
        }

        public static PaymentDTO Update(int id, PaymentDTO payment)
        {
            var existingPayment = DataAccessFactory.PaymentData().Read(id);

            if (existingPayment != null)
            {
                existingPayment.CardNumber = payment.CardNumber;
                existingPayment.CardHolderName = payment.CardHolderName;
                existingPayment.ExpirationDate = payment.ExpirationDate;
                existingPayment.CVV = payment.CVV;
                existingPayment.BillingAddress = payment.BillingAddress;
                existingPayment.City = payment.City;
                existingPayment.StateProvince = payment.StateProvince;
                existingPayment.ZipPostalCode = payment.ZipPostalCode;
                existingPayment.Country = payment.Country;
                existingPayment.PhoneNumber = payment.PhoneNumber;
                existingPayment.EmailAddress = payment.EmailAddress;
                existingPayment.Amount = payment.Amount;
                existingPayment.PaymentStatus = payment.PaymentStatus;

                var updatedPayment = DataAccessFactory.PaymentData().Update(existingPayment);
                if (updatedPayment != null)
                {
                    var cfg = new MapperConfiguration(c =>
                    {
                        c.CreateMap<Payment, PaymentDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    var mapped = mapper.Map<PaymentDTO>(updatedPayment);
                    return mapped;
                }
            }
            return null;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.PaymentData().Delete(id);
        }

        public async Task<List<PaymentDTO>> GetAsync()
        {
            var data = await DataAccessFactory.PaymentData2.ReadAsync();
            var mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<Payment, PaymentDTO>()));
            var mapped = mapper.Map<List<PaymentDTO>>(data);
            return mapped;
        }

        public async Task<PaymentDTO> GetAsync(int id)
        {
            var data = await DataAccessFactory.PaymentData2.ReadAsync(id);
            var mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<Payment, PaymentDTO>()));
            var mapped = mapper.Map<PaymentDTO>(data);
            return mapped;
        }


        public async Task<PaymentDTO> CreateAsync(PaymentDTO payment)
        {
            var mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<PaymentDTO, Payment>()));
            var mapped = mapper.Map<Payment>(payment);
            var data = await DataAccessFactory.PaymentData2.CreateAsync(mapped);
            var mapper2 = new Mapper(new MapperConfiguration(c => c.CreateMap<Payment, PaymentDTO>()));
            var mapped2 = mapper2.Map<PaymentDTO>(data);
            return mapped2;
        }

        public static async Task<string> GenerateInvoiceAsync(PaymentDTO paymentDto)  
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PaymentDTO, Payment>()));

            var mappedPayment = mapper.Map<Payment>(paymentDto);

            return await DataAccessFactory.PaymentData3().GenerateInvoiceAsync(mappedPayment);
        }

        public static async Task<string> GetPaymentStatusAsync(int paymentId)
        {
            return await DataAccessFactory.PaymentData3().GetPaymentStatusAsync(paymentId);
        }

        public static async Task ProcessPaymentAsync(PaymentDTO paymentDto)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PaymentDTO, Payment>()));
            var mappedPayment = mapper.Map<Payment>(paymentDto);

            await DataAccessFactory.PaymentData3().ProcessPaymentAsync(mappedPayment);
        }

        public static async Task RefundPaymentAsync(int paymentId, decimal amount)
        {
            await DataAccessFactory.PaymentData3().RefundPaymentAsync(paymentId, amount);
        }

        public static bool ValidatePaymentData(PaymentDTO paymentDto)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PaymentDTO, Payment>()));
            var mappedPayment = mapper.Map<Payment>(paymentDto);

            return DataAccessFactory.PaymentData3().ValidatePaymentData(mappedPayment);
        }

        public static bool VerifyPayment(PaymentDTO paymentDto)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<PaymentDTO, Payment>()));
            var mappedPayment = mapper.Map<Payment>(paymentDto);

            return DataAccessFactory.PaymentData3().VerifyPayment(mappedPayment);
        }

        public static List<PaymentDTO> GetPaymentsByCardHolder(string cardHolderName)
        {
            var data = DataAccessFactory.PaymentData3().GetPaymentsByCardHolder(cardHolderName);
            var mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<Payment, PaymentDTO>()));
            var mapped = mapper.Map<List<PaymentDTO>>(data);
            return mapped;
        }

        public static List<PaymentDTO> GetPendingPayments()
        {
            var data = DataAccessFactory.PaymentData3().GetPendingPayments();
            var mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<Payment, PaymentDTO>()));
            var mapped = mapper.Map<List<PaymentDTO>>(data);
            return mapped;
        }

        public static List<PaymentDTO> GetRefundedPayments()
        {
            var data = DataAccessFactory.PaymentData3().GetRefundedPayments();
            var mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<Payment, PaymentDTO>()));
            var mapped = mapper.Map<List<PaymentDTO>>(data);
            return mapped;
        }

        public static List<PaymentDTO> GetCanceledPayments()
        {
            var data = DataAccessFactory.PaymentData3().GetCanceledPayments();
            var mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<Payment, PaymentDTO>()));
            var mapped = mapper.Map<List<PaymentDTO>>(data);
            return mapped;
        }
    }
}
