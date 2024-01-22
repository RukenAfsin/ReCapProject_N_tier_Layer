using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Message
    {
        public static string CarAdded = "Araba sistemimize kayıt edilmiştir";
        public static string CarDeleted = " Araba kaydı sistemimizden kaldırılmıştır";
        public static string CarUpdated = "Araba bilgileri güncellenmiştir";
        public static string BrandAdded = "Marka sistemimize kayıt edilmiştir";
        public static string BrandDeleted = " Marka kaydı sistemimizden kaldırılmıştır";
        public static string BrandUpdated = "Marka bilgileri güncellenmiştir";
        public static string CustomerAdded = "Müşteri sistemimize kayıt edilmiştir";
        public static string CustomerDeleted = " Müşteri kaydı sistemimizden kaldırılmıştır";
        public static string CustomerUpdated = "Müşteri bilgileri güncellenmiştir";
        public static string RentalAdded = "Araç kiralanmıştır";
        public static string RentalNotAdded = "Aracı henüz teslim edilmedi, kiralayamazsınız";
        public static string AuthorizationNotAllowed= "Yetkiniz yok";
        public static string PaymentAdded = "Araç kiralama başarılı";
        public static string ImageError = "Image error";
        public static string ImageSuccess = "Image success";

        //public static string RentalListed = "Kiralık araçlar listelenmiştir";

    }
}
