using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB.Gear
{
    public class Gear_DB
    {
        
        public Dictionary<string, GearInfo> Dic { get; set; }
        public Gear_DB()
        {
            Dic = new Dictionary<string, GearInfo>();
        }

        void MakeDB(params Dictionary<string, GearInfo>[] param)
        {
            Dic.Clear();
            foreach (Dictionary<string, GearInfo> buffs in param)
            {
                foreach (KeyValuePair<string, GearInfo> buff in buffs)
                {
                    Dic.Add(buff.Key, buff.Value);
                }
            }
        }

    }
}
