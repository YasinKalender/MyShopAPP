using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectShopApp.Entities.ORM.Map
{
    public abstract class KernalMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(i => i.ID);
            builder.Property(i => i.AddDate).IsRequired(true);
            builder.Property(i => i.DeleteDate).IsRequired(false);
            builder.Property(i => i.status).IsRequired(true);
            builder.Property(i => i.UpdateDate).IsRequired(false);
        }
    }
}
