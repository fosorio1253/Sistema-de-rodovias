﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Models
{
    public class DivisaoRegional
    {
        public int divisao_regional_id { get; set; }
        public string sigla { get; set; }
        public string descricao { get; set; }
        public double fator_regional { get; set; }
    }
}