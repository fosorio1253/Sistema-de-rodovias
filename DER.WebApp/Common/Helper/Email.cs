using DER.WebApp.Domain.Business;
using DER.WebApp.Domain.Models;
using DER.WebApp.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;

namespace DER.WebApp.Common.Helper
{
    public class Email
    {
        private EmailBLL emailBLL;
        public Email()
        {
            emailBLL = new EmailBLL();
        }

        public string Enviar(Emails emails) 
        {
            var fromAddress = new MailAddress("faixadedominio@der.sp.gov.br");
            const string fromPassword = "N@x19792";
            var toAddress = new MailAddress(emails.Destinatario);

            try

            {
                var smtp = new SmtpClient
                {
                    Host = "smtp.office365.com",
                    Port = 587,
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = emails.Assunto,
                    Body = emails.CorpoEmail
                })
                {
                    smtp.Send(message);
                }

                emailBLL.SaveEmail(emails);

                return "Enviado com sucesso";
            }
            catch (Exception ex)
            {
                return "Não foi possivel enviar o email";
            }
        }

        public string EnviarEmail(Emails email, bool save = true)
        {
            try
            {
                var client = new SmtpClient("smtp.office365.com", 587)
                {
                    Credentials = new NetworkCredential("faixadedominio@der.sp.gov.br", "N@x19792"),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };

                MailMessage message = new MailMessage("faixadedominio@der.sp.gov.br", email.Destinatario, email.Assunto, email.CorpoEmail);
                message.IsBodyHtml = true;

                if(email.Anexo != null)
                {
                    Attachment data = new Attachment(email.Anexo.InputStream, email.Anexo.FileName);
                    message.Attachments.Add(data);
                }

                client.Send(message);
                if(save)
                {
                    emailBLL.SaveEmail(email);
                }
                else
                {
                    emailBLL.UpdateEmail(email);
                }
                return "Enviado com sucesso";
            }
            catch (Exception ex)
            {
                emailBLL.SaveEmail(email);
                return "Não foi possivel enviar o email";
            }
        }
    }
}