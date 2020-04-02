using MyProjectShopApp.Entities.ORM.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectShopApp.Entities.ORM.Entity.Concrete
{
    public class Order: BaseEntity
    {
        public Order()
        {
            orderLines = new List<OrderLine>();
        }
        public string OrderNumber { get; set; }

        public DateTime OrderDate { get; set; }

        public string UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string Adress { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string OrderNote { get; set; }

        //Ödeme bilgileri için bu kayıtları tuttuk

        public string PaymentID { get; set; } //Ödeme bilgilerinin detaylarını görüntülemek için 
        public string PaymentToken { get; set; }

        public string ConversationID { get; set; } // Hangi Ödeme API sini kullanıcağımı düşünmedim.Eğer Iyzico kullanırsam gerekli

        //

        public OrderStatus orderStatus { get; set; }

        public OrderPayment orderPayment { get; set; }

        public List<OrderLine> orderLines { get; set; }
    }
}
