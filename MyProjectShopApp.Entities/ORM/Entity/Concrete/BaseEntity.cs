using MyProjectShopApp.Entities.ORM.Entity.Abstract;
using MyProjectShopApp.Entities.ORM.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectShopApp.Entities.ORM.Entity.Concrete
{
    public class BaseEntity : IBase
    {
        public int ID { get; set; }

        private DateTime _addDate = DateTime.Now;
        public DateTime AddDate { get { return _addDate; } set { _addDate = value; } }
        public DateTime? DeleteDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        private Status _status = Status.Active;
        public Status status { get { return _status; } set { _status = value; } }
    }
}
