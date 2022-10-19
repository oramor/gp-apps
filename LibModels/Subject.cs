using LibCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LibModels
{
    struct Endpoints
    {
        public readonly static string apiList = "/v1/subject/list";
        public readonly static string apiItem = "/v1/subject/item";
    }

    public class Subject : BaseModel
    {
        static Subject()
        {
            // Fetcher для обращения к API
        }

        public class Item
        {
            public int? Id { get; set; }
            public string? Username { get; set; }
            public string? Email { get; set; }
            public string? Phone { get; set; }

            public async void UpdatePhone(string phone)
            {
                throw new NotImplementedException();
            }
        }

        // Этот метод будет асинхронно получать список
        // экземпляров сущности с сервера
        public static List<Item> GetList()
        {
            List<Item> list = new() {
                GetItem(1),
                GetItem(2),
                GetItem(3)
            };

            return list;
        }

        // Этот метод будет запрашивать конкретный экземпляр
        // сущности по API
        public static Item GetItem(int id)
        {
            return new Item() {
                Id = id,
                Username = "ffff",
                Email = "roror@ggg.ru",
                Phone = "7878787878"
            };
        }

        // Этот метод будет предпринимать асинхронную попытку
        // аутентификации
        public async Task<int> TryAuth(string login, string password)
        {
            //string json = "{\"subjectId\":1}";
            Thread.Sleep(3);
            return 1;
        }
    }
}
