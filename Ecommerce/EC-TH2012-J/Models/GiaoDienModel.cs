using Ecommerce.Domain.Infrastructure;
using Ecommerce.Domain.Model;
using System.Linq;

namespace  Ecommerce.Web.Models
{
    public class GiaoDienModel
    {
        private EcommerceModel_DbContext db = new EcommerceModel_DbContext();

        internal IQueryable<GiaoDien> GetDD()
        {
            return db.GiaoDiens;
        }

        internal IQueryable<Link> GetSlideShow()
        {
            return db.Links.Where(m => m.Group.Contains("SlideShow"));
        }
    }
}