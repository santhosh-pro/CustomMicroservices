using FeesMgmt.Models;

namespace FeesMgmt.Services
{
    public interface ISubscriberService
    {
        void CheckReceivedMessage(CustomerRegistered customerRegistered);
    }
}