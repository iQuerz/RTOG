﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Data.Models
{
    public class OngoingGame : BaseEntity
    {
        public List<Account> Players { get; set; }
    }
}
