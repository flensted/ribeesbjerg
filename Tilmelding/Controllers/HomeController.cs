using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RibeEsbjergHH.Models;
using SendGridMail;
using SendGridMail.Transport;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace RibeEsbjergHH.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View("Create");
        }


        [HttpPost]
        public ActionResult Index(Participant newParticipant)
        {
            try
            {
                var repo = new ParticipantRepository();
                repo.Add(newParticipant);
                SendEmails(newParticipant);
                return RedirectToAction("Betaling");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        private void SendEmails(Participant participant)
        {
            var username = ConfigurationManager.AppSettings["SENDGRID_USERNAME"];
            var password = ConfigurationManager.AppSettings["SENDGRID_PASSWORD"];
            var from = ConfigurationManager.AppSettings["NotifyFrom"];
            var toAdmins = ConfigurationManager.AppSettings["NotifyAdmins"].Split(',').ToList<string>();
            var subject = ConfigurationManager.AppSettings["NotifySubject"];

            var toParticipant = participant.ParentEmail;

            var message = SendGrid.GetInstance();
            message.AddTo(toParticipant);
            message.AddCc(toAdmins);
            message.AddBcc("nfj@flensted-jensen.com");
            message.From = new MailAddress(from);
            message.Subject = subject;

            message.Text = "Kære " + participant.Name + ",\n\nTak for tilmeldingen til Ribe Esbjerg HH's håndboldskole i efterårsferien, mandag d. 15. til onsdag den 17. oktober. " +
                "Det foregår i Guldager Idrætscenter den 15. - 17. oktober, mandag 9-15, tirsdag 9-15 og onsdag 9-17.\n" +
                "Vi ser frem til en masse spændende og sjove timer sammen med dig!" +
                "\n" +
                "Hvis du har nogen spørgsmål eller problemer med betalingen er du velkommen til at kontakte Mark Bendixen på telefon 26 17 31 72 eller ved at svare på denne mail.\n\n" +
                "Venlig hilsen,\n\nRibe Esbjerg HH";

            message.Text += "\n\n\nHer er de oplysninger du har indtastet:\n" +
                "Navn: " + participant.Name + "\n" +
                "Køn: " + participant.Sex + "\n" +
                "Fødselsår: " + participant.BornYear + "\n" +
                "Adresse: " + participant.Address + "\n" +
                "Postnummer: " + participant.PostalCode + "\n" +
                "By: " + participant.City + "\n" +
                "Hjemmetelefon: " + participant.HomePhone + "\n" +
                "Mobiltelefon: " + participant.ParentMobile + "\n" +
                "Forælders navn: " + participant.ParentName + "\n" +
                "Forening: " + participant.Club + "\n" +
                "År med håndbold: " + participant.YearsOfHandball + "\n" +
                "Position: " + participant.PlayerPosition + "\n" +
                "T-shirt størrelse: " + participant.TShirtSize + "\n" +
                "Antal ligabilletter: " + participant.ExtraTickets + "\n" +
                "Øvrige kommentarer: " + participant.Comments;

            var transportInstance = SMTP.GetInstance(new NetworkCredential(username, password));
            transportInstance.Deliver(message);
        }

        public ActionResult Betaling()
        {
            return View("Betaling");
        }

    }
}
