using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;

namespace DER.WebApp.Helper
{
    public static class Email
    {
        public static string EnviaMensagemEmail(string Destinatario, string Assunto, string enviaMensagem)
        {
            string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
            string porta = ConfigurationManager.AppSettings["porta_smtp"].ToString();
            string login = ConfigurationManager.AppSettings["email_login"].ToString();
            string senha = ConfigurationManager.AppSettings["email_senha"].ToString();
            try
            {
                // valida o email
                bool bValidaEmail = ValidaEnderecoEmail(Destinatario);

                // Se o email não é validao retorna uma mensagem
                if (bValidaEmail == false)
                    return "Email do destinatário inválido: " + Destinatario;

                // cria uma mensagem
                MailMessage mensagemEmail = new MailMessage(login, Destinatario, Assunto, enviaMensagem);

                SmtpClient client = new SmtpClient(smtp, Convert.ToInt32(porta));
                client.EnableSsl = true;
                NetworkCredential cred = new NetworkCredential(login, senha);
                client.Credentials = cred;

                // inclui as credenciais
                client.UseDefaultCredentials = false;

                // envia a mensagem
                client.Send(mensagemEmail);

                return "Mensagem enviada para  " + Destinatario + " às " + DateTime.Now.ToString() + ".";
            }
            catch (Exception ex)
            {
                string erro = ex.InnerException.ToString();
                return ex.Message.ToString() + erro;
            }
        }

        public static bool ValidaEnderecoEmail(string enderecoEmail)
        {
            try
            {
                //define a expressão regulara para validar o email
                string texto_Validar = enderecoEmail;
                Regex expressaoRegex = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");

                // testa o email com a expressão
                if (expressaoRegex.IsMatch(texto_Validar))
                {
                    // o email é valido
                    return true;
                }
                else
                {
                    // o email é inválido
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}