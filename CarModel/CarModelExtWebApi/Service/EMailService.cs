using CarModelExtWebApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace CarModelExtWebApi.Service
{
    public class EMailService
    {

        private SmtpClient _smtpClient;
        private const string _login = "gym550182@gmail.com";
        private const string _pass = "!QAZ2wsx#EDC";
        private const string destAddress = "radek.db@gmail.com";

        public EMailService()
        {
            Initalize();
        }

        private void Initalize()
        {
            _smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(_login, _pass)
            };
        }

        //public MailMessage CreateMailMessage(CarModel carModel)
        //{
        //    var message = new MailMessage
        //    {
        //        Sender = new MailAddress(_login),
        //        From = new MailAddress(_login),
        //        To = { destAddress },
        //        Subject = $"Warning - unathorised adding records {carModel.DateCreate}",
        //        Body = $"Model: {carModel.Model} </br> Reg number: {carModel.RegNumber} </br>",
        //        IsBodyHtml = true
        //    };

        //    return message;

        //}

        public void SendEmail(MailMessage mailMessage)
        {
            _smtpClient.Send(mailMessage);
        }
    }
}