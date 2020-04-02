using MyProjectShopApp.Entities.ORM.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectShopApp.Entities.ORM.Entity.Abstract
{
    public interface IBase
    {
        int ID { get; set; }

        public DateTime AddDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public Status status { get; set; }

    }
}
