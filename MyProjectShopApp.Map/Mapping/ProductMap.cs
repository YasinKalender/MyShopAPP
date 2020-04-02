using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using MyProjectShopApp.Entities.ORM.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectShopApp.Map.Mapping
{
    public class ProductMap:KernalMap<Product>
    {

        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(i => i.ProductName).HasMaxLength(255).IsRequired(true);
            builder.Property(i => i.Price).IsRequired(true);
            builder.Property(i => i.ImgURL).IsRequired(false);
            builder.Property(i => i.ProductDescription).IsRequired(true).HasMaxLength(255);

         


            base.Configure(builder);
        }
    }
}
