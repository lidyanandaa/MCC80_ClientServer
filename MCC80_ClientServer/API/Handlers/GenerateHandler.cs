﻿namespace API.Handlers
{
    public class GenerateHandler
    {
        public static string Nik(string? nik=null)
        {
        if (nik == null)
            {
                return "111111";
            }
        
            var generatedNik = int.Parse(nik) + 1;
        
            return generatedNik.ToString();
        }
    }
}