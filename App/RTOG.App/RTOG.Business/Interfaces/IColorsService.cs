﻿using RTOG.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Business.Interfaces
{
    public interface IColorsService
    {
        public Task<PlayerColor> Get(int colorID);
        public List<PlayerColor> getColors();
    }
}
