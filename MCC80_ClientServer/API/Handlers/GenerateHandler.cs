namespace API.Handlers
{
    public class GenerateHandler
    {
        public static string Nik(string? nik = null)
        {
            /* Random random = new Random();

             // Generate random digits for the NIK (assumes a 16-digit NIK).
             int[] nikDigits = new int[16];
             for (int i = 0; i < 16; i++)
             {
                 nikDigits[i] = random.Next(10); // Generates a random digit between 0 and 9.
             }

             // Format the NIK (Indonesia's NIK might have specific rules for each region).
             string formattedNIK = string.Join("", nikDigits);

             return formattedNIK;*/

            if (nik == null)
            {
             //Untuk memasukkan data pertama kali
             return "111111";
            }

            var generatedNik = int.Parse(nik) + 1;

            return generatedNik.ToString();
        }
    }
}
