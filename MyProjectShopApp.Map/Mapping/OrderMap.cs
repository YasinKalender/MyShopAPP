using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using MyProjectShopApp.Entities.ORM.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectShopApp.Map.Mapping
{
    public class OrderMap:KernalMap<Order>
    {

        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(i => i.Adress).HasMaxLength(255).IsRequired();
            builder.Property(i => i.City).HasMaxLength(100).IsRequired();
            builder.Property(i => i.Email).HasMaxLength(50).IsRequired();
            builder.Property(i => i.FirstName).HasMaxLength(20).IsRequired();
            builder.Property(i => i.LastName).HasMaxLength(20).IsRequired();
            builder.Property(i => i.OrderNumber).IsRequired();
            builder.Property(i => i.Phone).IsRequired();
            builder.Property(i => i.orderStatus).IsRequired();
            builder.Property(i => i.orderPayment).IsRequired();


            base.Configure(builder);
        }
    }
}
