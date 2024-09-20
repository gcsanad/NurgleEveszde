using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurgleEveszdeWpf
{
    class User
    {
        public int accountID { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? mobil { get; set; }
        public string? email { get; set; }
        public string? address { get; set; }
        public string? status { get; set; }
        public DateOnly registrationDate { get; set; }

        public User(MySqlDataReader olvaso)
        {
            accountID = olvaso.GetInt32(0);
            username = olvaso.GetString(1);
            password = olvaso.GetString(2);
            mobil = olvaso.GetString(3);
            email = olvaso.GetString(4);
            address = olvaso.GetString(5);
            status = olvaso.GetString(6);
            registrationDate = DateOnly.Parse($"{olvaso.GetDateTime(7).Year}-{olvaso.GetDateTime(7).Month}-{olvaso.GetDateTime(7).Day}");
        }


    }
}
