using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IyzipayCore;
using IyzipayCore.Model;
using IyzipayCore.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyProjectShopApp.Business.Abstract;
using MyProjectShopApp.Entities.ORM.Entity.Concrete;
using MyProjectShopApp.UI.Identity;
using MyProjectShopApp.UI.Models.Card;
using MyProjectShopApp.UI.Models.Order;

namespace MyProjectShopApp.UI.Controllers
{



    [Authorize]
    public class CardController : Controller
    {

        private ICardService _cardService;
        private UserManager<User> _userManager;
        private IOrderService _orderService;

        public CardController(ICardService cardService, UserManager<User> userManager, IOrderService orderService)
        {
            _cardService = cardService;
            _userManager = userManager;
            _orderService = orderService;
        }
        public IActionResult Index()
        {

            var card = _cardService.GetCard(_userManager.GetUserId(User));

            return View(new CardModel()
            {

                CardID = card.ID,
                carditemModels = card.CardItems.Select(i => new CarditemModel()
                {
                    CarditemID = i.ID,
                    ImgUrL = i.Product.ImgURL,
                    ProductName = i.Product.ProductName,
                    Price = i.Product.Price,
                    ProductID = i.ProductID,
                    Quantity = i.Quantity
                }).ToList()


            });
        }


        [HttpPost]
        public IActionResult AddToCard(int productid, int quantity)
        {

            _cardService.AddToCard(_userManager.GetUserId(User), productid, quantity);
            return RedirectToAction("Index", "Card");
        }

        [HttpPost]
        public IActionResult DeleteToFromCard(int productid)
        {

            _cardService.DeleteToFromCard(_userManager.GetUserId(User), productid);
            return RedirectToAction("Index", "Card");
        }


        //Sipariş Tamamlama Sayfası

        [HttpGet]
        public IActionResult CheckOut()
        {


            var card = _cardService.GetCard(_userManager.GetUserId(User));
            var ordermodel = new OrderModel();

            ordermodel.CardModel = new CardModel()
            {

                CardID = card.ID,
                carditemModels = card.CardItems.Select(i => new CarditemModel()
                {
                    CarditemID = i.ID,
                    ImgUrL = i.Product.ImgURL,
                    ProductName = i.Product.ProductName,
                    Price = i.Product.Price,
                    ProductID = i.ProductID,
                    Quantity = i.Quantity
                }).ToList()


            };

            return View(ordermodel);
        }


        [HttpPost]
        public IActionResult CheckOut(OrderModel model)
        {

            if (ModelState.IsValid)
            {
                var userid = _userManager.GetUserId(User);
                var card = _cardService.GetCard(userid);

                model.CardModel = new CardModel()
                {
                    CardID = card.ID,
                    carditemModels = card.CardItems.Select(i => new CarditemModel()
                    {
                        CarditemID = i.ID,
                        ImgUrL = i.Product.ImgURL,
                        ProductName = i.Product.ProductName,
                        Price = i.Product.Price,
                        ProductID = i.ProductID,
                        Quantity = i.Quantity
                    }).ToList()


                };


                var payment = PaymentProccess(model);


                if (payment.Status == "success")
                {

                    SaveOrder(model, payment, userid);
                    ClearCard(card.ID.ToString());
                    return View("Success");
                }

            }

            return View(model);
        }

        private void SaveOrder(OrderModel model, Payment payment, string userid)
        {
            var order = new Order();

            order.OrderNumber = new Random().Next(111111, 999999).ToString();
            order.orderStatus = Entities.ORM.Entity.Enum.OrderStatus.Completed;
            order.orderPayment = Entities.ORM.Entity.Enum.OrderPayment.CreditCard;
            order.PaymentID = payment.PaymentId;
            order.ConversationID = payment.ConversationId;
            order.OrderDate = new DateTime();
            order.FirstName = model.FirstName;
            order.LastName = model.LastName;
            order.Email = model.Email;
            order.Phone = model.Phone;
            order.Adress = model.Adress;
            order.City = model.City;
            order.UserID = userid;
            

            foreach (var item in model.CardModel.carditemModels)
            {
                var orderitem = new OrderLine()
                {
                    TotalPrice = item.Price,
                    Quantity = item.Quantity,
                    ProductID = item.ProductID
                };
                order.orderLines.Add(orderitem);
            }
            _orderService.Create(order);
        }

        private void ClearCard(string cardid)
        {
            _cardService.ClearCard(cardid);
        }

        private Payment PaymentProccess(OrderModel model)
        {

            Options options = new Options();
            options.ApiKey = "sandbox-a0XCQqKwQ86X8mvA3vHaiIZetjdzWKnA";
            options.SecretKey = "sandbox-BKIsoJigoRA9waiK27UUKaYkyMPcF5wc";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = Guid.NewGuid().ToString();
            request.Price = model.CardModel.Price().ToString().Split(",")[0];
            request.PaidPrice = model.CardModel.Price().ToString().Split(",")[0];
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = model.CardModel.CardID.ToString();
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = model.CardName;
            paymentCard.CardNumber = model.CardNumber;
            paymentCard.ExpireMonth = model.ExpireMonth;
            paymentCard.ExpireYear = model.ExpireYear;
            paymentCard.Cvc = model.Cvv;
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;


           
            //paymentCard.CardHolderName = "John Doe";
            //paymentCard.CardNumber = "5528790000000008";
            //paymentCard.ExpireMonth = "12";
            //paymentCard.ExpireYear = "2030";
            //paymentCard.Cvc = "123";


            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = "John";
            buyer.Surname = "Doe";
            buyer.GsmNumber = "+905350000000";
            buyer.Email = "email@email.com";
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "Istanbul";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem basketItem;

            foreach (var item in model.CardModel.carditemModels)
            {
                basketItem = new BasketItem();

                basketItem.Id = item.ProductID.ToString();
                basketItem.Name = item.ProductName;
                basketItem.Category1 = "Telefon";
                basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                basketItem.Price = item.Price.ToString().Split(",")[0];
                basketItems.Add(basketItem);
            }


         

           

            request.BasketItems = basketItems;

            return Payment.Create(request, options);



        }





        public IActionResult GetOrders()
        {
            var userid = _userManager.GetUserId(User);
            var orders = _orderService.GetOrders(userid);

            var orderslist = new List<OrderListModel>();
            OrderListModel orderListModel;

            foreach (var item in orders)
            {
                orderListModel = new OrderListModel();
                orderListModel.ID = item.ID;
                orderListModel.OrderNumber = item.OrderNumber;
                orderListModel.OrderDate = item.OrderDate;
                orderListModel.Phone = item.Phone;
                orderListModel.FirstName = item.FirstName;
                orderListModel.LastName = item.LastName;
                orderListModel.Email = item.Email;
                orderListModel.Address = item.Adress;
                orderListModel.City = item.City;

                orderListModel.OrderItemDetails = item.orderLines.Select(i => new OrderItemDetails()
                {

                    ID=i.ID,
                    Name=i.Product.ProductName,
                    Price=i.TotalPrice,
                    Quantity=i.Quantity,
                    ImageUrl=i.Product.ImgURL,


                    


                }).ToList();

                orderslist.Add(orderListModel);

            }

            





            return View(orderslist);
        }
    }
}
