using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RutinApp.Models
{
    public static class TokenManager
    {
        private static string _token;

        public static string Token
        {
            get { return _token; }
            set { _token = value; }
        }

        public static void ClearToken()
        {
            _token = null;
        }
    }

}
