using System;

namespace CRUD.WebAPI.Utils
{
    /// <summary>
    /// Class responsable only to Calculate the Age
    /// </summary>
    public class CalculateAGe
    {
        public static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }
    }
}
