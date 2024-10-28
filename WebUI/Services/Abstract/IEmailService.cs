﻿namespace WebUI.Services.Abstract
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body);

    }
}