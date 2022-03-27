using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public static class AllClaims
    {
        private static List<string> _list;

        static AllClaims()
        {
            _list = new List<string>
            {
                "Users-View",
                "Users-Edit",
                "Users-Details",
                "Users-Delete",
                "Roles-View",
                "Roles-Edit",
                "Roles-Details",
                "Roles-Delete"
            };
        }

        public static List<string> GetList()
        {
            return _list;
        }
    }
}
