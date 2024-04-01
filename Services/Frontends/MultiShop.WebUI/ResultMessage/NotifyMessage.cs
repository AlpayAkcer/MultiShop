namespace MultiShop.WebUI.ResultMessage
{
    public static class NotifyMessage
    {
        public static class ResultTitle
        {
            public static string Add(string title)
            {
                return $"{title} Başarılı bir şekilde eklendi";
            }

            public static string Update(string title)
            {
                return $"{title} başarıyla güncellenmiştir";
            }

            public static string Delete(string title)
            {
                return $"{title} başarıyla silinmiştir";
            }

            public static string Warning(string title)
            {
                return $"{title} Kontrol edilmesi gerekiyor";
            }

            public static string UndoDelete(string title)
            {
                return $"{title} başarıyla geri alınmıştır";
            }

            public static string Info()
            {
                return $"Yükleniyor";
            }
        }
    }
}
