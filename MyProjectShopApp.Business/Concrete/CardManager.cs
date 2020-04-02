using MyProjectShopApp.Business.Abstract;
using MyProjectShopApp.DataAccess.Abstract;
using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectShopApp.Business.Concrete
{
    public class CardManager : ICardService
    {
        private ICardRepository _cardRepository;

        public CardManager(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public void AddToCard(string userid, int productid, int quantity)
        {
            var card = GetCard(userid);

            if (card!=null)
            {
                var index = card.CardItems.FindIndex(i => i.ProductID == productid);

                if (index<0)
                {
                    card.CardItems.Add(new CardItems() {ProductID=productid,Quantity=quantity,CardID=card.ID });
                }

                else
                {
                    card.CardItems[index].Quantity += quantity;
                }

                _cardRepository.Update(card);


            }

           
        }

        public void CardObject(string userid)
        {
            _cardRepository.Create(new Card() { UserID = userid });
        }

        public void ClearCard(string cardid)
        {
            _cardRepository.ClaearCard(cardid);
        }

        public void DeleteToFromCard(string userid, int productid)
        {
            var card = GetCard(userid);

            if (card!=null)
            {
                var cardID = card.ID;

                _cardRepository.DeleteFromCard(card.ID,productid);
            }
        }

        public Card GetCard(string userid)
        {
           return _cardRepository.GetUserid(userid);
        }
    }
}
