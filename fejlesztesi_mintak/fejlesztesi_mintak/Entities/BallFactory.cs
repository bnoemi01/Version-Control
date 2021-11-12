﻿using fejlesztesi_mintak.Abstarctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fejlesztesi_mintak.Entities
{
    public class BallFactory : IToyFactory
    {
        public Toy CreateNew()
        {
            return new Ball();
        }
    }
}
