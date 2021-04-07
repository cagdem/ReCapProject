using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Bussiness.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Urun eklendi.";
        public static string ProductDeleted = "Urun silindi.";
        public static string ProductUpdated = "Urun guncellendi.";
        public static string ProductNameInvalid = "Urun ismi gecersiz.";
        public static string DailyPriceInvalid = "Urun ismi gecersiz.";
        public static string MaintenanceTime = "Sistem bakimda.";
        public static string ProductListed = "Urun listelendi";
        public static string CustomerAdded = "Musteri eklendi.";
        public static string CustomerDeleted = "Musteri silindi.";
        public static string CustomerListed = "Musteri listelendi.";
        public static string CustomerUpdated = "Musteri guncellendi.";
        public static string UserAdded = "Kullanici eklendi.";
        public static string UserDeleted = "Kullanici silindi.";
        public static string UserListed = "Kullanici listelendi.";
        public static string UserUpdated = "Kullanici guncellendi.";
        public static string RentalAdded = "Kiralik eklendi.";
        public static string RentalDeleted = "Kiralik silindi.";
        public static string RentalListed = "Kiralik listelendi.";
        public static string RentalUpdated = "Kiralik guncellendi.";
        public static string RentalDenied = "Araba musait degil.";
        public static string ImageLimitExceded = "5 fotograftan fazla yuklenemez.";
        public static string ImageAlreadyNull = "Lutfen fotograf ekleyin.";
        public static string AuthorizationDenied = "yetkiniz yok";

        public static string PaymentAdded = "Odeme secenegi eklendi";
        public static string PaymentDeleted = "Odeme secenegi silindi";
        public static string PaymentUpdated = "Odeme secenegi guncellendi";

        public static string PaymentIsValid = "Odeme onaylandi";
        public static string PaymentIsNotValid = "Odeme onaylanmadi";

        public static string FindeksIsEnough = "Findeks puaniniz yeterli. Isleme devam edebilirsiniz.";
        public static string FindeksIsNotEnough = "Findeks puaniniz bu araba icin yetersiz.";


    }
}
