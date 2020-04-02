using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectShopApp.Business.Abstract
{
    public interface ICardService
    {

        void CardObject(string userid);

        Card GetCard(string userid);

        void AddToCard(string userid,int productid, int quantity);

        void DeleteToFromCard(string userid, int productid);
        void ClearCard(string cardid);

    }
}
