using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using MyProjectShopApp.Entities.ORM.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectShopApp.Map.Mapping
{
    public class CategoryMap:KernalMap<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.Property(i => i.CategoryName).IsRequired(true).HasMaxLength(50);

            

            base.Configure(builder);
        }


    }
}
