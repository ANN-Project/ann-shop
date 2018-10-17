using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;

namespace ann_shop.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual DbSet<tbl_Account> tbl_Account { get; set; }
        public virtual DbSet<tbl_Attribute> tbl_Attribute { get; set; }
        public virtual DbSet<tbl_AttributeValue> tbl_AttributeValue { get; set; }
        public virtual DbSet<tbl_Comment> tbl_Comment { get; set; }
        public virtual DbSet<tbl_Customer> tbl_Customer { get; set; }
        public virtual DbSet<tbl_Option> tbl_Option { get; set; }
        public virtual DbSet<tbl_Order> tbl_Order { get; set; }
        public virtual DbSet<tbl_OrderItem> tbl_OrderItem { get; set; }
        public virtual DbSet<tbl_Page> tbl_Page { get; set; }
        public virtual DbSet<tbl_Post> tbl_Post { get; set; }
        public virtual DbSet<tbl_PostCategory> tbl_PostCategory { get; set; }
        public virtual DbSet<tbl_PostInCategory> tbl_PostInCategory { get; set; }
        public virtual DbSet<tbl_PostInTag> tbl_PostInTag { get; set; }
        public virtual DbSet<tbl_PostTag> tbl_PostTag { get; set; }
        public virtual DbSet<tbl_Product> tbl_Product { get; set; }
        public virtual DbSet<tbl_ProductCategory> tbl_ProductCategory { get; set; }
        public virtual DbSet<tbl_ProductImage> tbl_ProductImage { get; set; }
        public virtual DbSet<tbl_ProductInCategory> tbl_ProductInCategory { get; set; }
        public virtual DbSet<tbl_ProductInTag> tbl_ProductInTag { get; set; }
        public virtual DbSet<tbl_ProductTag> tbl_ProductTag { get; set; }
        public virtual DbSet<tbl_ProductVariant> tbl_ProductVariant { get; set; }
        public virtual DbSet<tbl_ProductVariantValue> tbl_ProductVariantValue { get; set; }
        public virtual DbSet<tbl_Menu> tbl_Menu { get; set; }
        public virtual DbSet<tbl_MenuItem> tbl_MenuItem { get; set; }

    }
}