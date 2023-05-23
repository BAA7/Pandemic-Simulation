using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandemicSimulation
{
    static class DataBase
    {
        public static int infectiousness; // chance to infect a healthy citizen in one step
        public static int symptomsVisibility; // chance for symptoms to appear in one step
        public static int cureResist; // number of days spent in isolation until recovery
        public static int economyLevel; // people available to get isolated at the same time
        public static int citizensAmount; // number of citizens
        public static int[] ill; // 0 = healthy ; 1 = sick ; 2 = symptoms appeared
        public static int[,] socialLink; // 0 = no link ; 1 = active link ; 2 = inactive link
        public static bool[] isolation; // 0 = free ; 1 = isolated
        public static int[] isolationDays; // number of days a citizen has spent in isolation
    }
}
