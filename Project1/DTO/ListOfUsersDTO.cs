using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public partial class ListOfUsersDTO

    {

        public long Page { get; set; }
        public long PerPage { get; set; }
        public long Total { get; set; }
        public long TotalPages { get; set; }
        public List<Data> Data { get; set; }
        public Support Support { get; set; }

    }


    public partial class Data

    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string Avatar { get; set; }

    }


    public partial class Support

    {
        public string Url { get; set; }
        public string Text { get; set; }
    }


}
