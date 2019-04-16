using DotNetCore.CAP;
using FeesMgmt.Models;

namespace FeesMgmt.Services
{
    public class SubscriberService : ISubscriberService, ICapSubscribe
    {
        private readonly FeesDbContext _feesDbContext;
        public SubscriberService(FeesDbContext feesDbContext)
        {
            _feesDbContext = feesDbContext;
        }

        [CapSubscribe("customer")]
        public void CheckReceivedMessage(CustomerRegistered customerRegistered)
        {
           _feesDbContext.Customers.Add(customerRegistered);
           _feesDbContext.SaveChanges();
        }
    }
}