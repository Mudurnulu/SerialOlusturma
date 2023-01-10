using System;
using System.Windows.Forms;
using System.Management;
using System.IO;

namespace SerialOlusturma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        int[] karakter = new int[36];
        private SerialCreated.enumapp enumapp;

        private void Form1_Load(object sender, EventArgs e)
        {
//            try
//            {
//var dosya= new FileStream(Application.StartupPath + "\\Lisance.dll",
//            FileMode.Open, FileAccess.Read, FileShare.Read);
//            if (dosya != null)
//            {
//                string rd = new StreamReader(dosya).ReadLine();
//                    var md =rd. Substring(rd.Length - 29, 29);
//                    string yd = SerialCreated. Sifre_Algoritmasi(SerialCreated.SifreOlustur());
//           if(yd==  md)
//                    MessageBox.Show("başarılı");
//           else
//                    MessageBox.Show("giremrdi");

//            }
//            }
//            catch (Exception)
//            {
//            }  
            //KarakterOlustur();

            //textBox1.Text = Sifre_icin_done();
            //txtson.Text = Sifre_Algoritmasi(textBox1.Text);
            //Dosya_Oluştur(txtson.Text);
        }

        private void Dosya_Oluştur(string sifre)
        {
            if (File.Exists(Application.StartupPath+"\\Lisance.dll")) ;
            {
                try
                {
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
                        if (i == 2)
                            yaz.Write(DateTime.Now.Day);
                        else if (i == 9)
                            yaz.Write(DateTime.Now.Month);
                        else if (i == 18)
                            yaz.Write(DateTime.Now.Year);
                        else
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
            string SerialBoard = string.Empty;
            //ManagementObjectSearcher mos;
            //ManagementObjectCollection mosList = null;
            //mos = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
            //mosList = mos.Get();
            //foreach (ManagementObject mo in mosList)
            //{
            //    SerialBoard = mo["SerialNumber"].ToString();
            //}
            Random sayi = new Random();
            for (int i = 0; i < 28; i++)
            {
                SerialBoard += sayi.Next(0, 10);
            }

            //return ConvertToHex(SerialBoard).ToUpper();
            return SerialBoard;
        }

        private void KarakterOlustur()
        {
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

        }
        public string ConvertToHex(string asciiString)
        {
            string hex = "";
            foreach (char c in asciiString)
            {
                int tmp = c;
                hex += (Math.Log(tmp)).ToString();
            }
            hex = hex.Replace(",", "");
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
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            char[] c = textBox2.Text.ToCharArray();
            int a = c[c.Length - 1];
            textBox3.Text = a.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text =SerialCreated. Sifre_Algoritmasi(textBox1.Text,enumapp);
        }

        private string Sifre_Algoritmasi(string done)
        {
            string text = "";
            if (done.Length>26)
            {
             text = done.Substring(done.Length -26, 26);

            }
            else
            {
                Random rn=new Random();
                
                for (int i= done.Length; i < 27; i++)
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
        }

        private int sayiayarla(int sayi1, int sayi2)
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

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text =SerialCreated. SifreOlustur();
            //txtson.Text=Sifre_Algoritmasi(textBox1.Text);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            var rd = sender as RadioButton;
            switch (rd.Tag)
            {
                case "i":
                    enumapp = SerialCreated.enumapp.image;
                    break;
                case "d":
                    enumapp = SerialCreated.enumapp.dizgi;
                    break;
                case "s":
                    enumapp = SerialCreated.enumapp.shell;
                    break;
                case "e":
                    enumapp = SerialCreated.enumapp.excel;
                    break;
                case "t":
                    enumapp = SerialCreated.enumapp.trc;
                    break;
                default:
                    break;
            }
        }
    }
}
