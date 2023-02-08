using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeBomjour.Properties;

namespace LeBomjour
{
    public static class Data
    {
        public static float Money { get; set; }
        public static float XP { get; set; }
        public static int Days { get; set; }
        public static double Time { get; set; }
        public static float TimeMult { get; set; }
        public static float MoneyMult { get; set; }
        public static float XPMult { get; set; }

        public static void SaveData()
        {
            Save.Default[nameof(Money)] = Money;
            Save.Default[nameof(XP)] = XP;
            Save.Default[nameof(Days)] = Days;
            Save.Default[nameof(Time)] = Time;
            Save.Default[nameof(TimeMult)] = TimeMult;
            Save.Default[nameof(MoneyMult)] = MoneyMult;
            Save.Default[nameof(XPMult)] = XPMult;
            Save.Default.Save();
        }

        public static void LoadData()
        {
            Money = (float)Save.Default[nameof(Money)];
            XP = (float)Save.Default[nameof(XP)];
            Days = (int)Save.Default[nameof(Days)];
            Time = (double)Save.Default[nameof(Time)];
            TimeMult = (float)Save.Default[nameof(TimeMult)];
            MoneyMult = (float)Save.Default[nameof(MoneyMult)];
            XPMult = (float)Save.Default[nameof(XPMult)];
        }

        public static void ResetData()
        {
            Save.Default.Reset();
            LoadData();
            Save.Default.Save();
        }
    }
}
