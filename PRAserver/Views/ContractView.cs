﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRAserver.Views
{
    public class ContractView
    {
        public int ContractId { get; set; }
        public int Duration { get; set; }
        public int Salary { get; set; }
        public string CrewMember { get; set; }
        public string MovieTitle { get; set; }
    }
}