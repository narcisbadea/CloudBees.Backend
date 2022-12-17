using CloudBees.BLL.DTOs;
using CloudBees.DAL.Entities;

namespace CloudBees.BLL.Services.Interfaces
{
    public interface IEmailService
    {
        void Send(EmailRequestDTO emailRequest);
    }
}