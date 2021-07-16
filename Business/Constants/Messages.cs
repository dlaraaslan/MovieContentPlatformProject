using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {

        public static string MovieAdded = "Film eklendi";
        public static string MovieUpdated = "Film güncellendi";
        public static string MovieDeleted = "Film silindi";
        public static string MovieListed = "Filmler listelendi";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserListed = "Kullanıcı listelendi";

        public static string ImageAdded = "Film resmi eklendi!";
        public static string ImageUpdated = "Film resmi güncellendi!";
        public static string ImageDeleted = "Film resmi silindi!";

      
        public static string ImageCountExceeded = "Bir filme maksimum 5 resim eklenebilir!";
        public static string ImageNotFound = "Film resmi bulunamadı!";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok";

    }
}
