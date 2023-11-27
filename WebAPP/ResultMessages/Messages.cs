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
    } 
    public static class Category
    {
        public static string Add(string name)
        {
            return $"{name} isimli kategori başarıyla eklenmiştir.";
        }

        public static string Update(string name)
        {
            return $"{name} isimli makale başarıyla güncellenmiştir.";
        } 
        public static string Delete(string name)
        {
            return $"{name} isimli makale başarıyla silinmiştir.";
        }
    }
}
