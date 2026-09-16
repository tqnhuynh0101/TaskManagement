using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ProjectAggregate.Interfaces;

public interface IEmailSender
{
    Task SendEmailAsync(string to, string from, string subject, string body);

}
