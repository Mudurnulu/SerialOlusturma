using System;
using System.IO;
using System.Windows.Forms;
using System.Management;

namespace SerialOlusturma
{
    class SerialCreated
    {
        public SerialCreated()
        {
        }


        public static void Dosya_Oluştur(string sifre, enumapp enumapp)
        {
            if (!File.Exists(Application.StartupPath + "\\Lisance.dll"))
            {
                try
                {
                    int[] karakter = new int[36];
                    KarakterOlustur(karakter, enumapp);
                    FileStream fs = new FileStream(Application.StartupPath + "\\Lisance.dll",
            FileMode.CreateNew, FileAccess.Write, FileShare.None);
                    System.IO.StreamWriter yaz = new StreamWriter(fs);
                    Random rnd = new Random();
                    for (int i = 0; i < 200; i++)
                    {
                        if (i % 5 == 0)
                        {
                            yaz.Write("-");
                        }
                        yaz.Write((char)karakter[rnd.Next(36)]);
                    }
                    yaz.Write(sifre);
                    yaz.Close();

                }
                catch (Exception e)
                {

                    MessageBox.Show(e.Message);
                }
            }


        }

        private string Sifre_icin_done()
        {
            string SerialBoard = "";
            ManagementObjectSearcher mos;
            ManagementObjectCollection mosList = null;
            mos = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
            mosList = mos.Get();
            foreach (ManagementObject mo in mosList)
            {
                SerialBoard = mo["SerialNumber"].ToString();
            }
            return ConvertToHex(SerialBoard).ToUpper();
        }

        public string ConvertToHex(string asciiString)
        {
            string hex = "";
            foreach (char c in asciiString)
            {
                int tmp = c;
                hex += (Math.Log(tmp)).ToString();
            }
            hex = hex.Replace(",", "").Replace(".", "");
            return hex;
        }
        private string sayiyacevir(string yazi)
        {
            string sy = "";
            foreach (char item in yazi)
            {
                int tmp = item;
                sy += tmp.ToString();
            }
            return sy;
        }
        public static string Sifre_Algoritmasi(string done, enumapp enumapp)
        {
            int[] karakter = new int[36];
            KarakterOlustur(karakter, enumapp);
            string text = "";
            if (done.Length > 26)
            {
                text = done.Substring(done.Length - 26, 26);

            }
            else
            {
                Random rn = new Random();

                for (int i = done.Length; i < 27; i++)
                {
                    done += rn.Next(0, 9);
                }
                text = done.Substring(done.Length - 26, 26);
            }
            string sifre = "";
            for (int i = 0; i < text.Length - 1; i++)
            {
                int sayi1 = int.Parse(text.Substring(i, 1));
                int sayi2 = int.Parse(text.Substring(i + 1, 1));
                int sayi3 = sayiayarla(sayi1, sayi2);
                sifre += (char)karakter[sayi3];
            }

            for (int i = 1; i < 5; i++)
            {
                sifre = sifre.Insert((i * 5) + i - 1, "-");
            }
            return sifre;
            int sayiayarla(int sayi1, int sayi2)
            {
                int sayi3 = 0;

                if (sayi1 == 9)
                {
                    sayi1 = 8;
                }
                sayi1 *= 4;
                if (sayi2 < 10 && sayi2 > 7)
                {
                    sayi2 = 3;
                }
                else if (sayi2 < 8 && sayi2 > 5)
                {
                    sayi2 = 1;
                }
                else if (sayi2 < 5 && sayi2 > 2)
                {
                    sayi2 = 2;
                }
                else
                {
                    sayi2 = 0;
                }
                sayi3 = sayi1 + sayi2;

                return sayi3;
            }
        }
        public enum enumapp
        {
            image,
            shell,
            dizgi,
            excel,
            trc,
            dizgiFull,
            trcFull,
            trolleyfeeder
        }
        static void KarakterOlustur(int[] karakter, enumapp applicarion)
        {
            switch (applicarion)
            {
                case enumapp.image:
                    karakter[5] = 48;
                    karakter[22] = 49;
                    karakter[2] = 50;
                    karakter[14] = 51;
                    karakter[32] = 52;
                    karakter[12] = 53;
                    karakter[7] = 54;
                    karakter[15] = 55;
                    karakter[16] = 56;
                    karakter[3] = 57;
                    karakter[1] = 65;
                    karakter[27] = 66;
                    karakter[25] = 67;
                    karakter[30] = 68;
                    karakter[19] = 69;
                    karakter[0] = 70;
                    karakter[23] = 71;
                    karakter[35] = 72;
                    karakter[29] = 73;
                    karakter[34] = 74;
                    karakter[20] = 75;
                    karakter[18] = 76;
                    karakter[11] = 77;
                    karakter[13] = 78;
                    karakter[31] = 79;
                    karakter[26] = 80;
                    karakter[4] = 81;
                    karakter[28] = 82;
                    karakter[6] = 83;
                    karakter[9] = 84;
                    karakter[8] = 85;
                    karakter[10] = 86;
                    karakter[21] = 87;
                    karakter[24] = 88;
                    karakter[33] = 89;
                    karakter[17] = 90;

                    break;
                case enumapp.shell:
                    karakter[2] = 48;
                    karakter[32] = 49;
                    karakter[25] = 50;
                    karakter[33] = 51;
                    karakter[15] = 52;
                    karakter[28] = 53;
                    karakter[20] = 54;
                    karakter[30] = 55;
                    karakter[8] = 56;
                    karakter[22] = 57;
                    karakter[10] = 65;
                    karakter[3] = 66;
                    karakter[27] = 67;
                    karakter[6] = 68;
                    karakter[14] = 69;
                    karakter[4] = 70;
                    karakter[18] = 71;
                    karakter[17] = 72;
                    karakter[35] = 73;
                    karakter[19] = 74;
                    karakter[13] = 75;
                    karakter[21] = 76;
                    karakter[9] = 77;
                    karakter[23] = 78;
                    karakter[24] = 79;
                    karakter[0] = 80;
                    karakter[26] = 81;
                    karakter[12] = 82;
                    karakter[5] = 83;
                    karakter[29] = 84;
                    karakter[7] = 85;
                    karakter[31] = 86;
                    karakter[1] = 87;
                    karakter[11] = 88;
                    karakter[34] = 89;
                    karakter[16] = 90;
                    break;
                case enumapp.dizgi:
                    karakter[33] = 48;
                    karakter[12] = 49;
                    karakter[22] = 50;
                    karakter[35] = 51;
                    karakter[7] = 52;
                    karakter[3] = 53;
                    karakter[1] = 54;
                    karakter[9] = 55;
                    karakter[16] = 56;
                    karakter[28] = 57;
                    karakter[31] = 65;
                    karakter[30] = 66;
                    karakter[23] = 67;
                    karakter[11] = 68;
                    karakter[2] = 69;
                    karakter[20] = 70;
                    karakter[10] = 71;
                    karakter[6] = 72;
                    karakter[0] = 73;
                    karakter[8] = 74;
                    karakter[26] = 75;
                    karakter[15] = 76;
                    karakter[34] = 77;
                    karakter[17] = 78;
                    karakter[21] = 79;
                    karakter[29] = 80;
                    karakter[5] = 81;
                    karakter[24] = 82;
                    karakter[32] = 83;
                    karakter[25] = 84;
                    karakter[4] = 85;
                    karakter[13] = 86;
                    karakter[27] = 87;
                    karakter[19] = 88;
                    karakter[14] = 89;
                    karakter[18] = 90;
                    break;
                case enumapp.dizgiFull:
                    karakter[32] = 48;
                    karakter[9]  = 49;
                    karakter[14] = 50;
                    karakter[17] = 51;
                    karakter[16]= 52;
                    karakter[8] = 53;
                    karakter[19]= 54;
                    karakter[20]= 55;
                    karakter[4]  = 56;
                    karakter[0]  = 57;
                    karakter[23] = 65;
                    karakter[25] = 66;
                    karakter[15] = 67;
                    karakter[12] = 68;
                    karakter[26]= 69;
                    karakter[3]  = 70;
                    karakter[21] = 71;
                    karakter[22]= 72;
                    karakter[34]= 73;
                    karakter[13]= 74;
                    karakter[2]  = 75;
                    karakter[1]  = 76;
                    karakter[11] = 77;
                    karakter[6]  = 78;
                    karakter[5]  = 79;
                    karakter[30] = 80;
                    karakter[28]= 81;
                    karakter[10] = 82;
                    karakter[24] = 83;
                    karakter[31] = 84;
                    karakter[33]= 85;
                    karakter[18] = 86;
                    karakter[29] = 87;
                    karakter[7]  = 88;
                    karakter[35] = 89;
                    karakter[27] = 90;
                    break;
                case enumapp.excel:
                    karakter[11] = 48;
                    karakter[22] = 49;
                    karakter[14] = 50;
                    karakter[1] = 51;
                    karakter[23] = 52;
                    karakter[34] = 53;
                    karakter[29] = 54;
                    karakter[28] = 55;
                    karakter[13] = 56;
                    karakter[5] = 57;
                    karakter[21] = 65;
                    karakter[27] = 66;
                    karakter[3] = 67;
                    karakter[16] = 68;
                    karakter[25] = 69;
                    karakter[19] = 70;
                    karakter[35] = 71;
                    karakter[0] = 72;
                    karakter[32] = 73;
                    karakter[24] = 74;
                    karakter[7] = 75;
                    karakter[20] = 76;
                    karakter[10] = 77;
                    karakter[33] = 78;
                    karakter[12] = 79;
                    karakter[17] = 80;
                    karakter[15] = 81;
                    karakter[18] = 82;
                    karakter[6] = 83;
                    karakter[8] = 84;
                    karakter[31] = 85;
                    karakter[26] = 86;
                    karakter[4] = 87;
                    karakter[30] = 88;
                    karakter[9] = 89;
                    karakter[2] = 90;
                    break;
                case enumapp.trc:
                    karakter[6] = 48;
                    karakter[22] = 49;
                    karakter[29] = 50;
                    karakter[10] = 51;
                    karakter[8] = 52;
                    karakter[0] = 53;
                    karakter[14] = 54;
                    karakter[33] = 55;
                    karakter[5] = 56;
                    karakter[13] = 57;
                    karakter[30] = 65;
                    karakter[27] = 66;
                    karakter[4] = 67;
                    karakter[16] = 68;
                    karakter[25] = 69;
                    karakter[9] = 70;
                    karakter[3] = 71;
                    karakter[34] = 72;
                    karakter[32] = 73;
                    karakter[18] = 74;
                    karakter[31] = 75;
                    karakter[2] = 76;
                    karakter[1] = 77;
                    karakter[28] = 78;
                    karakter[17] = 79;
                    karakter[12] = 80;
                    karakter[15] = 81;
                    karakter[24] = 82;
                    karakter[11] = 83;
                    karakter[23] = 84;
                    karakter[7] = 85;
                    karakter[26] = 86;
                    karakter[35] = 87;
                    karakter[21] = 88;
                    karakter[19] = 89;
                    karakter[20] = 90;
                    break;
                case enumapp.trolleyfeeder:
                    karakter[30] = 48;
                    karakter[14] = 49;
                    karakter[19] = 50;
                    karakter[15] = 51;
                    karakter[2] = 52;
                    karakter[6] = 53;
                    karakter[9] = 54;
                    karakter[17] = 55;
                    karakter[23] = 56;
                    karakter[27] = 57;
                    karakter[18] = 65;
                    karakter[7] = 66;
                    karakter[35] = 67;
                    karakter[11] = 68;
                    karakter[22] = 69;
                    karakter[24] = 70;
                    karakter[8] = 71;
                    karakter[20] = 72;
                    karakter[28] = 73;
                    karakter[21] = 74;
                    karakter[5] = 75;
                    karakter[3] = 76;
                    karakter[25] = 77;
                    karakter[12] = 78;
                    karakter[31] = 79;
                    karakter[16] = 80;
                    karakter[1] = 81;
                    karakter[33] = 82;
                    karakter[10] = 83;
                    karakter[4] = 84;
                    karakter[29] = 85;
                    karakter[26] = 86;
                    karakter[34] = 87;
                    karakter[13] = 88;
                    karakter[32] = 89;
                    karakter[0] = 90;
                    break;
                default:
                    karakter[30] = 48;
                    karakter[14] = 49;
                    karakter[19] = 50;
                    karakter[15] = 51;
                    karakter[2] = 52;
                    karakter[6] = 53;
                    karakter[9] = 54;
                    karakter[17] = 55;
                    karakter[23] = 56;
                    karakter[27] = 57;
                    karakter[18] = 65;
                    karakter[7] = 66;
                    karakter[35] = 67;
                    karakter[11] = 68;
                    karakter[22] = 69;
                    karakter[24] = 70;
                    karakter[8] = 71;
                    karakter[20] = 72;
                    karakter[28] = 73;
                    karakter[21] = 74;
                    karakter[5] = 75;
                    karakter[3] = 76;
                    karakter[25] = 77;
                    karakter[12] = 78;
                    karakter[31] = 79;
                    karakter[16] = 80;
                    karakter[1] = 81;
                    karakter[33] = 82;
                    karakter[10] = 83;
                    karakter[4] = 84;
                    karakter[29] = 85;
                    karakter[26] = 86;
                    karakter[34] = 87;
                    karakter[13] = 88;
                    karakter[32] = 89;
                    karakter[0] = 90;
                    break;
            }

        }


        public static string SifreOlustur()
        {
            var s = new SerialCreated();
            var done = s.Sifre_icin_done();
            return done;
        }

    }
}
