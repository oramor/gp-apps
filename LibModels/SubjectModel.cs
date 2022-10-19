using LibCore;
using LibModels.Interfaces;
using System.Collections.Generic;
using System.Net.Http;

namespace LibModels
{
    public class SubjectModel : BaseModel
    {
        static SubjectModel()
        {
            HttpClient client = new HttpClient();
        }

        public class Item : ISubjectItem
        {
            private readonly int _id;
            private string _username;
            private string _email;
            private string _phone;

            public Item(int subjectId)
            {
                // Здесь будет запрос к API и разбор JSON
                _id = subjectId;
                _username = "Roma";
                _email = "ssdsd@sdsd.ru";
                _email = "79797897788";
            }

            public int Id { get { return _id; } }
            public string Username { get { return _username; } }
            public string Email { get { return _email; } }
            public string Phone { get { return _phone; } }
        }

        public static List<Item> GetList()
        {
            List<Item> list = new List<Item>();
            list.Add(new Item(1));
            list.Add(new Item(2));
            list.Add(new Item(3));

            return list;
        }

        public static int TryAuth(string login, string password)
        {
            return 1;
        }
    }
}
