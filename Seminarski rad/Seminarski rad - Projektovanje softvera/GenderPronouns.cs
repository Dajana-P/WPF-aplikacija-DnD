using System;
using System.Collections.Generic;
using System.Text;

namespace Seminarski_rad___Projektovanje_softvera
{
    public class GenderPronouns
    {
        public static string KrajReci(string Gender)
        {
            if (Gender == "Žensko")
                return "la";
            else if (Gender == "Muško")
                return "o";
            else return "lo";

        }

        public static string BioBilaBilo(string Gender)
        {
            if (Gender == "Žensko")
                return "bila";
            else if (Gender == "Muško")
                return "bio";
            else return "bilo";
        }

        public static string AnNaNo(string Gender)
        {
            if (Gender == "Žensko")
                return "na";
            else if (Gender == "Muško")
                return "an";
            else return "no";
        }

        public static string KrajImena(string Gender, string Name)
        {
            Name.Remove(Name.Length - 1);
            if (Gender == "Žensko")
                return Name + "u";
            else if (Gender == "Muško")
                return Name + "a";
            else return "o";
        }
    }
}

