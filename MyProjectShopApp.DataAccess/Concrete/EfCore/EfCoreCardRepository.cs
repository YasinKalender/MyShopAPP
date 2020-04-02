using Microsoft.EntityFrameworkCore;
using MyProjectShopApp.DAL.Context;
using MyProjectShopApp.DataAccess.Abstract;
using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyProjectShopApp.DataAccess.Concrete.EfCore
{
    public class EfCoreCardRepository : EfEntityRepository<Card, ProjectContext>, ICardRepository
    {
        public void ClaearCard(string cardid)
        {
            using (var context = new ProjectContext())
            {

                var cmd = @"Delete from CardItems where CardID=@p0";
                context.Database.ExecuteSqlRaw(cmd, cardid);

            };

        }

        public void DeleteFromCard(int cardid, int productid)
        {
            using(var context = new ProjectContext())
            {

                var cmd = @"Delete from CardItems where CardID=@p0 and ProductID=@p1";
                 context.Database.ExecuteSqlRaw(cmd, cardid, productid);

            };
        }

        public Card GetUserid(string userid)
        {
            using (var context = new ProjectContext())
            {
              return  context.Cards.Include(i => i.CardItems)
                    .ThenInclude(i => i.Product)
                    .FirstOrDefault(i => i.UserID == userid);



            };

            
        }

        public override void Update(Card entity)
        {
            using(var context = new ProjectContext())
            {

                context.Cards.Update(entity);
                context.SaveChanges();


            };
        }
    }
}
