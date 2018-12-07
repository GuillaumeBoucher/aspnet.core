using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class CmdbContext : DbContext
    {

        public CmdbContext(DbContextOptions<CmdbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<PersonContact> PersonContacts { get; set; }
        public DbSet<AddressType> AddressType { get; set; }

        
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //Database.EnsureDeleted();
        ///Database.EnsureCreated();

        //modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory { CategoryID = 1, CategoryName = "prose" });


        //var a =    modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory { CategoryID = 2, CategoryName = "novel" });
        //modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory { CategoryName = "poetry" });


        //}



        //    this.ProductCategories.Add(new ProductCategory()
        //    {
        //        CategoryName = "poetry",
        //        ParentCategory = this.ProductCategories.Local.Single(p => p.CategoryName == "novel")
        //    });
        //    this.ProductCategories.Add(new ProductCategory()
        //    {
        //        CategoryName = "detective story"
        //    });
        //    this.ProductCategories.Add(new ProductCategory()
        //    {
        //        CategoryName = "fantasy",
        //        ParentCategory = this.ProductCategories.Local.Single(p => p.CategoryName == "novel")
        //    });
        //    this.ProductCategories.Add(new ProductCategory()
        //    {
        //        CategoryName = "pop art",
        //        ParentCategory = this.ProductCategories.Local.Single(p => p.CategoryName == "fantasy")
        //    });
        //    this.ProductCategories.Add(new ProductCategory()
        //    {
        //        CategoryName = "textbook"
        //    });
        //    this.ProductCategories.Add(new ProductCategory()
        //    {
        //        CategoryName = "research book",
        //        ParentCategory = this.ProductCategories.Local.Single(p => p.CategoryName == "textbook")
        //    });
        //    this.ProductCategories.Add(new ProductCategory()
        //    {
        //        CategoryName = "poem",
        //        ParentCategory = this.ProductCategories.Local.Single(p => p.CategoryName == "novel")
        //    });
        //    this.ProductCategories.Add(new ProductCategory()
        //    {
        //        CategoryName = "collection",
        //        ParentCategory = this.ProductCategories.Local.Single(p => p.CategoryName == "textbook")
        //    });
        //    this.ProductCategories.Add(new ProductCategory()
        //    {
        //        CategoryName = "dictionary",
        //        ParentCategory = this.ProductCategories.Local.Single(p => p.CategoryName == "collection")
        //    });

        //    this.Products.Add(new Product()
        //    {
        //        ProductName = "Shakespeare W. Shakespeare's dramatische Werke",
        //        Price = 78,
        //        Category = this.ProductCategories.Local.Single(p => p.CategoryName == "prose")
        //    });
        //    this.Products.Add(new Product()
        //    {
        //        ProductName = "King Stephen. 'Salem's Lot",
        //        Price = 67,
        //        Category = this.ProductCategories.Local.Single(p => p.CategoryName == "poetry")
        //    });
        //    this.Products.Add(new Product()
        //    {
        //        ProductName = "Plutarchus. Plutarch's moralia",
        //        Price = 89,
        //        Category = this.ProductCategories.Local.Single(p => p.CategoryName == "prose")
        //    });
        //    this.Products.Add(new Product()
        //    {
        //        ProductName = "Twain Mark. Ventures of Huckleberry Finn",
        //        Price = 34,
        //        Category = this.ProductCategories.Local.Single(p => p.CategoryName == "novel")
        //    });
        //    this.Products.Add(new Product()
        //    {
        //        ProductName = "Harrison G. B. England in Shakespeare's day",
        //        Price = 540,
        //        Category = this.ProductCategories.Local.Single(p => p.CategoryName == "novel")
        //    });
        //    this.Products.Add(new Product()
        //    {
        //        ProductName = "Corkett Anne. The salamander's laughter",
        //        Price = 5,
        //        Category = this.ProductCategories.Local.Single(p => p.CategoryName == "poem")
        //    });
        //    this.Products.Add(new Product()
        //    {
        //        ProductName = "Lightman Alan. Einstein''s dreams",
        //        Price = 5,
        //        Category = this.ProductCategories.Local.Single(p => p.CategoryName == "poem")
        //    });

        //    Companies.Add(new Company()
        //    {
        //        CompanyName = "Borland UK CodeGear Division",
        //        Web = "support.codegear.com/"
        //    });
        //    Companies.Add(new Company()
        //    {
        //        CompanyName = "Alfa-Bank",
        //        Web = "www.alfabank.com"
        //    });
        //    Companies.Add(new Company()
        //    {
        //        CompanyName = "Pioneer Pole Buildings, Inc.",
        //        Web = "www.pioneerpolebuildings.com"
        //    });
        //    Companies.Add(new Company()
        //    {
        //        CompanyName = "Orion Telecoms (Pty) Ltd.",
        //        Web = "www.oriontele.com"
        //    });
        //    Companies.Add(new Company()
        //    {
        //        CompanyName = "Orderbase Consulting GmbH",
        //        Web = "orderbase.de"
        //    });

        //    Orders.Add(new Order()
        //    {
        //        OrderDate = new DateTime(2007, 4, 11),
        //        Company = Companies.Local.Single(c => c.CompanyName == "Borland UK CodeGear Division")
        //    });
        //    Orders.Add(new Order()
        //    {
        //        OrderDate = new DateTime(2006, 3, 11),
        //        Company = Companies.Local.Single(c => c.CompanyName == "Borland UK CodeGear Division")
        //    });
        //    Orders.Add(new Order()
        //    {
        //        OrderDate = new DateTime(2006, 8, 6),
        //        Company = Companies.Local.Single(c => c.CompanyName == "Alfa-Bank")
        //    });
        //    Orders.Add(new Order()
        //    {
        //        OrderDate = new DateTime(2004, 7, 6),
        //        Company = Companies.Local.Single(c => c.CompanyName == "Alfa-Bank")
        //    });
        //    Orders.Add(new Order()
        //    {
        //        OrderDate = new DateTime(2006, 8, 8),
        //        Company = Companies.Local.Single(c => c.CompanyName == "Alfa-Bank")
        //    });
        //    Orders.Add(new Order()
        //    {
        //        OrderDate = new DateTime(2003, 3, 1),
        //        Company = Companies.Local.Single(c => c.CompanyName == "Pioneer Pole Buildings, Inc.")
        //    });
        //    Orders.Add(new Order()
        //    {
        //        OrderDate = new DateTime(2005, 8, 6),
        //        Company = Companies.Local.Single(c => c.CompanyName == "Orion Telecoms (Pty) Ltd.")
        //    });
        //    Orders.Add(new Order()
        //    {
        //        OrderDate = new DateTime(2006, 8, 1),
        //        Company = Companies.Local.Single(c => c.CompanyName == "Orion Telecoms (Pty) Ltd.")
        //    });
        //    Orders.Add(new Order()
        //    {
        //        OrderDate = new DateTime(2007, 7, 1),
        //        Company = Companies.Local.Single(c => c.CompanyName == "Orion Telecoms (Pty) Ltd.")
        //    });
        //    Orders.Add(new Order()
        //    {
        //        OrderDate = new DateTime(2007, 2, 6),
        //        Company = Companies.Local.Single(c => c.CompanyName == "Orderbase Consulting GmbH")
        //    });
        //    Orders.Add(new Order()
        //    {
        //        OrderDate = new DateTime(2007, 8, 1),
        //        Company = Companies.Local.Single(c => c.CompanyName == "Orderbase Consulting GmbH")
        //    });

        //    SaveChanges();
        //}



    }
}
