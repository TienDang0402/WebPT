using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShopOnl.Common
{
    [Serializable]
    public class UserLogin
    {
        
        public long UserId { set; get; }
        public string UserName { set; get; }
        
        
    }
}