using Kitab.Data.Base;
using Kitab.Models;

namespace Kitab.Data.Services
{
    public class PublisherService: EntityBaseRepository<Publisher>, IPublisherService
    {
        public PublisherService(KitabDbContext context) : base(context)
        {

        }
    }
}
