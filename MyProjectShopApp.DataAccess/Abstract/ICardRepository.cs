using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectShopApp.DataAccess.Abstract
{
    public interface ICardRepository : IRepository<Card>
    {
        Card GetUserid(string userid);

        void DeleteFromCard(int cardid, int productid);

        void ClaearCard(string cardid);
    }
}
