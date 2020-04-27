using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LAB5
{
    public class MailSender
    {
        public delegate void EmailSentEventHandler(object source, EmailSentEventArgs args);
        public event EmailSentEventHandler EmailSents;
        protected virtual void EmailSent()
        {
            // Verifica si hay alguien suscrito al evento
            if (EmailSents != null)
            {
                // Engatilla el evento
                EmailSents(this, new EmailSentEventArgs());
            }
        }
        public void OnRegistered(object source, RegisterEventArgs e)
        {
            Thread.Sleep(2000);
            Console.WriteLine($"\nCorreo enviado a {e.Email}: \n Gracias por registrarte, {e.Username}!\n Por favor, para poder verificar tu correo, has click en: {e.VerificationLink}\n");
            EmailSent();
            Thread.Sleep(2000);
        }

        public void OnPasswordChanged(object source, ChangePasswordEventArgs e)
        {
            Thread.Sleep(2000);
            Console.WriteLine($"\nCorreo enviado a {e.Email}:  \n {e.Username}, te notificamos que la contrasena de tu cuenta PlusCorp ha sido cambiada. \n");
            Thread.Sleep(2000);
        }
        
    }
}
