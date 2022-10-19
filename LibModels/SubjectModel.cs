using LibCore;
using LibModels.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Runtime.CompilerServices;

namespace LibModels
{
    public class SubjectModel : BaseModel
    {
        private string readonly apiList = "/v1/subject/item";
        private string readonly apiItem = "/v1/subject/list";

        static SubjectModel()
        {
            HttpClient client = new HttpClient();
        }

        public class Item
        {
            private readonly int _id;
            private string _username;
            private string _email;
            private string _phone;

            public int Id { get => _id; set { _id = value } }
            public string Username { get => _username; set { _username = value } }
            public string Email { get => _email;  set { _email = value } }
            public string Phone { get => _phone; set { _phone = value } }

            public List<object> GetProfiles() { }
        }

        // Этот метод будет асинхронно получать список
        // экземпляров сущности с сервера
        public static List<Item> GetList()
        {
            List<Item> list = new List<Item>();
            list.Add(new Item(1));
            list.Add(new Item(2));
            list.Add(new Item(3));

            return list;
        }

        // Этот метод будет запрашивать конкретный экземпляр
        // сущности по API
        public static Item GetItem(int id)
        {
            return new Item() {
                Username = "ffff"
            };
        }

        // Этот метод будет предпринимать асинхронную попытку
        // аутентификации
        public static int TryAuth(string login, string password)
        {
            return 1;
        }
    }
}
