﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FactoryAndSingltoneBL
    {
        static IBL bl = null;
        static public IBL GetIBL()
        {
            if (bl == null)
            {
                bl = new BL_imp();
            }
            return bl;
        }
    }
}
