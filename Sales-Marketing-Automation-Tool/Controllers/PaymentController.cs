using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BLL.DTOs;
using BLL.Services;

namespace Sales_Marketing_Automation_Tool.Controllers
{
    public class PaymentController : ApiController
    {
        [HttpGet]
        [Route("api/payment")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = PaymentService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/payment/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = PaymentService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("api/payment")]
        public HttpResponseMessage Post([FromBody] PaymentDTO paymentDto)
        {
            try
            {
                var data = PaymentService.Create(paymentDto);
                return Request.CreateResponse(HttpStatusCode.Created, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        [Route("api/payment/{id}")]
        public HttpResponseMessage Put(int id, [FromBody] PaymentDTO paymentDto)
        {
            try
            {

                if (id <= 0 || paymentDto == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid input parameters.");
                }


                var data = PaymentService.Update(id, paymentDto);

                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Payment not found or not updated.");
                }

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/payment/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = PaymentService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [HttpPost]
        [Route("api/payment/generate-invoice")]
        public async Task<HttpResponseMessage> GenerateInvoiceAsync([FromBody] PaymentDTO paymentDto)
        {
            try
            {
                var data = await PaymentService.GenerateInvoiceAsync(paymentDto);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/payment/status/{paymentId}")]
        public async Task<HttpResponseMessage> GetPaymentStatusAsync(int paymentId)
        {
            try
            {
                var data = await PaymentService.GetPaymentStatusAsync(paymentId);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        [Route("api/payment/process")]
        public async Task<HttpResponseMessage> ProcessPaymentAsync([FromBody] PaymentDTO paymentDto)
        {
            try
            {
                await PaymentService.ProcessPaymentAsync(paymentDto);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        [Route("api/payment/refund/{paymentId}/{amount}")]
        public async Task<HttpResponseMessage> RefundPaymentAsync(int paymentId, decimal amount)
        {
            try
            {
                await PaymentService.RefundPaymentAsync(paymentId, amount);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/payment/validate/{paymentId}")]
        public HttpResponseMessage ValidatePaymentData([FromBody] PaymentDTO paymentDto)
        {
            try
            {
                var data = PaymentService.ValidatePaymentData(paymentDto);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/payment/verify/{paymentId}")]
        public HttpResponseMessage VerifyPayment([FromBody] PaymentDTO paymentDto)
        {
            try
            {
                var data = PaymentService.VerifyPayment(paymentDto);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/payment/card-holder/")]
        public HttpResponseMessage GetPaymentsByCardHolder(string cardHolderName)
        {
            try
            {
                var data = PaymentService.GetPaymentsByCardHolder(cardHolderName);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/payment/pending")]
        public HttpResponseMessage GetPendingPayments()
        {
            try
            {
                var data = PaymentService.GetPendingPayments();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/payment/refunded")]
        public HttpResponseMessage GetRefundedPayments()
        {
            try
            {
                var data = PaymentService.GetRefundedPayments();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/payment/canceled")]
        public HttpResponseMessage GetCanceledPayments()
        {
            try
            {
                var data = PaymentService.GetCanceledPayments();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
