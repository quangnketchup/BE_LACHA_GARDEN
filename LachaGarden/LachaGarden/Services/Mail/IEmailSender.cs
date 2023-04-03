﻿using LachaGarden.Models.Mail;

namespace LachaGarden.Services.Mail
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}