using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendingService.Models;

namespace VndrMVC
{
    public class LogViewModel
    {
        public IList<UserItem> Users { get; set; }
        public IList<ProductItem> Products { get; set; }
        public IList<OperationTypeItem> OperationTypes { get; set; }
    }
}