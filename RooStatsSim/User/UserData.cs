﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using RooStatsSim.AbstractClass;

namespace RooStatsSim.User
{
    enum LEVEL_ENUM : int
    {
        BASE = 0,
        BASE_POINT,
        JOB,
        JOB_POINT,
    }
    enum STATUS_ENUM : int
    {
        STR = 0,
        AGI,
        VIT,
        INT,
        DEX,
        LUK
    }

    class ABILITTY
    {
        public int Point;
        public int AddPoint;
        public ABILITTY() { Point = 1; AddPoint = 0; }
    }
    class UserData
    {
        public List<ABILITTY> Level = new List<ABILITTY>()
        {
           new ABILITTY(),  //BASE
           new ABILITTY(),
           new ABILITTY(),  //JOB
           new ABILITTY(),
        };

        public List<ABILITTY> Status = new List<ABILITTY>()
        {
           new ABILITTY(),  //STR
           new ABILITTY(),
           new ABILITTY(),  
           new ABILITTY(),
           new ABILITTY(),
           new ABILITTY(),  //LUK
        };
    }
}
