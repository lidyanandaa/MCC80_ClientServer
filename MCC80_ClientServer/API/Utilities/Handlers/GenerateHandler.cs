namespace API.Utilities.Handlers
{
    public class GenerateHandler
    {
        //public static string Nik(string? nik = null)
        //{
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
        //}

        private static int lastNik = 11111; // NIK terakhir, ganti dengan NIK terakhir yang sesuai

        public static string Nik(string? nik = null)
        {
            // Tambahkan 1 pada NIK terakhir untuk mendapatkan NIK berikutnya
            lastNik++;

            // Format angka menjadi 5 digit dengan leading zeros jika diperlukan
            string nextSerialFormatted = lastNik.ToString("D5");

            // Buat NIK baru berdasarkan NIK terakhir dan serial berikutnya
            string NIK = nextSerialFormatted;
            return NIK;
        }
    }
}
