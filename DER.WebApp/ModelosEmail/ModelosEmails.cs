using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DER.WebApp.ModelosEmail
{
    public static class ModelosEmails
    {
        public static string EmailExpiracaoCadastroCredenciado()
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine(< head >)


            //var html = string.Empty;
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<title>SGFD - Sistema de Gestão de Faixa de Domínio</title>");
            sb.AppendLine("<meta charset='utf-8'>");
            sb.AppendLine("<meta http-equiv='X-UA-Compatible' content='IE=edge'>");
            sb.AppendLine("<meta name = 'viewport' content= 'width = device-width, initial-scale=1'> ");
            sb.AppendLine("<meta name = 'description' content = 'SGFD - Sistema de Gestão de Faixa de Domínio'>");
            sb.AppendLine("<meta name = 'author' content = 'DER'> ");
            sb.AppendLine("<link rel = 'stylesheet' type = 'text/css' href = '/public/assets/app.styles.css' >");
            sb.AppendLine("<link rel = 'shortcut icon' type = 'image/png' sizes = '16x16' href = '/public/assets/images/favicon.ico'> ");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            sb.AppendLine("<p>Olá <b>{Nome}</b></p>");
            sb.AppendLine("<p>O seu cadastro no Sistema de Gestão de Faixas de Domínio vencerá em 30 dias. Por favor, acesse o sistema e realize o recadastramento dos seus dados.</p>");
            sb.AppendLine("");
            sb.AppendLine("<section id='root'></section>");
            sb.AppendLine("<script type='text/javascript' src ='/public/assets/app.vendor.bundle.js'></script>");
            sb.AppendLine("<script type='text/javascript' src='/public/assets/app.bundle.js'></script>");
            sb.AppendLine("<nav></nav>");            
            sb.AppendLine("<footer><p><img src= 'https://i.imgur.com/aB5gnGP.png' alt='Assinatura'></p>");
            sb.AppendLine("<div class='footer'> ");
            sb.AppendLine("<table role='presentation' border='0' cellpadding='0' cellspacing='0'>");
            sb.AppendLine("<tbody><tr>");
            sb.AppendLine("<td class='content-block'>");
            sb.AppendLine("<span class='apple-link'>Favor não responder este e-mail.</span>");
            sb.AppendLine("</td>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</tbody></table>");
            sb.AppendLine("</div>");
            sb.AppendLine("</footer>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            return sb.ToString();
        }
    }
}