﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class UfespViewModel
    {
        public int ufesp_id { get; set; }
        public DateTime? mes_ano { get; set; }
        public double valor { get; set; }
        public double p_calculado { get; set; }
    }
}