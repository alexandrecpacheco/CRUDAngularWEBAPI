namespace CRUD.WebAPI.Utils
{
    public class Validations
    {
        public static bool ValidateCPF(string vrCPF)
        {
            int[] multiplicator1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicator2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digit;

            int sum;
            int rest;

            vrCPF = vrCPF.Trim();
            vrCPF = vrCPF.Replace(".", "").Replace("-", "");

            if (vrCPF.Length != 11)
            {
                return false;
            }
            tempCpf = vrCPF.Substring(0, 9);

            sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(tempCpf[i].ToString()) * (multiplicator1[i]);
            }
            rest = sum % 11;

            if (rest < 2)
            {
                rest = 0;
            }
            else
            {
                rest = 11 - rest;
            }

            digit = rest.ToString();
            tempCpf = tempCpf + digit;
            int sum2 = 0;

            for (int i = 0; i < 10; i++)
            {
                sum2 += int.Parse(tempCpf[i].ToString()) * multiplicator2[i];
            }

            rest = sum2 % 11;

            if (rest < 2)
            {
                rest = 0;
            }
            else
            {
                rest = 11 - rest;
            }

            digit = digit + rest.ToString();
            return vrCPF.EndsWith(digit);
        }

    }
}
