namespace WebAPP.ResultMessages;

public static class Messages
{
    public static class Article
    {
        public static string Add(string articleTitle)
        {
            return $"{articleTitle} başlıklı makale başarıyla eklenmiştir.";
        }

        public static string Update(string articleTitle)
        {
            return $"{articleTitle} başlıklı makale başarıyla güncellenmiştir.";
        } 
        public static string Delete(string articleTitle)
        {
            return $"{articleTitle} başlıklı makale başarıyla silinmiştir.";
        }
        public static string UndoDelete(string articleTitle)
        {
            return $"{articleTitle} başlıklı makale başarıyla geri alınmıştır.";
        }
    } 
    public static class Category
    {
        public static string Add(string name)
        {
            return $"{name} isimli kategori başarıyla eklenmiştir.";
        }

        public static string Update(string name)
        {
            return $"{name} isimli kategori başarıyla güncellenmiştir.";
        } 
        public static string Delete(string name)
        {
            return $"{name} isimli kategori başarıyla silinmiştir.";
        }
        public static string UndoDelete(string name)
        {
            return $"{name} isimli kategori başarıyla geri alınmıştır.";
        }
    }
    public static class User
    {
        public static string Add(string userName)
        {
            return $"{userName} email adresli kullanıcı başarıyla eklenmiştir.";
        }

        public static string Update(string userName)
        {
            return $"{userName} email adresli kullanıcı başarıyla güncellenmiştir.";
        } 
        public static string Delete(string userName)
        {
            return $"{userName} email adresli kullanıcı başarıyla silinmiştir.";
        }
        public static string ChangedPasswordAndProfile()
        {
            return $"Şifreniz ve bilgileriniz başarıyla güncellenmiştir.";
        }
        public static string ChangedProfile()
        {
            return $"Bilgileriniz başarıyla güncellenmiştir.";
        } 
        public static string ErrorChangedProfile()
        {
            return $"Bilgileriniz güncellenirken bir hata oluştu.";
        }
    }
}
