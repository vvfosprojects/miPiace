using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Classes
{
    public class Service
    {
        //Rappresenta l'ID Mongo del servizio
        public string Id { get; protected set; }

        //Rappresenta l'identificativo che verrà esposto al pubblico per richiamare il servizio
        public string PublicToken { get; set; }

        //Rappresenta l'identificativo che verrà fornito al proprietario del servizio, che utilizzerà per accedere alla statistiche relative al servizio
        public string PrivateToken { get; set; }

        //Rappresenta il messaggio che verrà mostrato all'utente in fase di rilascio del feedback
        public string WelcomeMessage { get; set; }
    }
}