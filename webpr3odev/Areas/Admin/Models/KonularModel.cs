using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webpr3odev.Areas.Admin.Models
{
    public class KonularModel
    {
        public int ID { get; set; }

        public Nullable<System.DateTime> Btarih { get; set; }
        public Nullable<System.DateTime> Bitarih { get; set; }
        public string KonuBaslik { get; set; }
        public HttpPostedFileBase Resim { get; set; }
    }
}