using System;
using System.Collections.Generic;
using RooStatsSim.DB.Table;

namespace RooStatsSim.DB.Gear
{
    public enum NORMAL_GEAR_ITEM
    {

    }
    public class NormalGear
    {
        public static Dictionary<string, string> NORMAL_GEAR_ITEM_KOR = new Dictionary<string, string>()
        {

        };
        public Dictionary<string, GearInfo> Dic { get; set; }
        public NormalGear()
        {

        }
    }
}
