using Demos.DTO;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demos
{
    public class MailHelper
    {
        private static void Enviar(List<DestinatarioEmail> destinatarios, string assunto, string texto)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("ONLINE", "emailt@email.com"));
            foreach (DestinatarioEmail destinatario in destinatarios)
            {
                if (EmailValido(destinatario.Email))
                {
                    message.To.Add(new MailboxAddress(destinatario.Nome, destinatario.Email));
                }
            }

            if (message.To.Count > 0)
            {
                message.Subject = assunto;

                message.Body = new TextPart("html")
                {
                    Text = texto
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate("top1soft@email.co,", "senhaaqui");
#if !DEBUG
                    client.Send(message);
#endif
                    client.Disconnect(true);
                }
            }
        }

        public static void EnviarEmail(List<DestinatarioEmail> destinatarios, string assunto, string texto)
        {
            Enviar(destinatarios, assunto, texto);
        }

        public static void EnviarEmail(string nomeDestinatario, string emailDestinatario, string assunto, string texto)
        {
            Enviar(new List<DestinatarioEmail>() { new DestinatarioEmail() { Nome = nomeDestinatario, Email = emailDestinatario } }, assunto, texto);
        }

        public static bool EmailValido(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                return false;
            }
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}
