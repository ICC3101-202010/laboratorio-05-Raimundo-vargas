using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

namespace LAB5
{
    public class User
    {
        public delegate void EmailVerifiedEventHandler(object source, EmailVerifiedEventArgs args);
        public event EmailVerifiedEventHandler EmailVerifieds;
        protected virtual void EmailVerified()
        {
            // Verifica si hay alguien suscrito al evento
            if (EmailVerifieds != null)
            {
                // Engatilla el evento
                EmailVerifieds(this, new EmailVerifiedEventArgs());
            }
        }
        public void OnEmailSent(object source, EmailSentEventArgs e)
        {
            Console.WriteLine("Desea verificar su correo? 1 = si, otro valor = no");
            string respuesta = Console.ReadLine();
            switch (respuesta)
            {
                case "1":
                    EmailVerified();
                    break;
                default: 
                    Console.WriteLine("error");
                    break;
            }
        }
    }
}
