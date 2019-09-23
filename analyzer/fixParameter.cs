using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace analyzer
{
    public partial class fixParameter : Form
    {

        public static int parNo;
       public static string parameter;

        string[] sParameter;
        string parStatus;
        public fixParameter()
        {
            InitializeComponent();
        }

        private void FixParameter_Load(object sender, EventArgs e)
        {
            sParameter =parameter.Split(',');

            txtParName.Text = sParameter[0];
            txtParID.Text = sParameter[1];
            txtParSt.Text = sParameter[2];
            txtParStBit.Text = sParameter[3];
            txtParLt.Text = sParameter[4];
            txtParLtBit.Text = sParameter[5];

            txtFak.Text = sParameter[7];
            txtBirim.Text = sParameter[8];

            if (sParameter[6] == "l")
            {
                chLittle.Checked = true;
                chBig.Checked = false;
            }
            else
            {
                chLittle.Checked = false;
                chLittle.Checked = true;
            }

            
        }

        private void BtnFixRegister_Click(object sender, EventArgs e)
        {
            string parAd = txtParName.Text.Trim();
            string parID = txtParID.Text.Trim();

            int dur = 0;

            string parBas = txtParSt.Text.Trim();
            string parBasBit = txtParStBit.Text.Trim();
            string parBit = txtParLt.Text.Trim();
            string parBitbit = txtParLtBit.Text.Trim();

            string faktor = txtFak.Text.Trim();
            string birim = txtBirim.Text.Trim();

            if (chLittle.Checked==true)
            {
                parStatus = "l";
            }
            if (chBig.Checked==true)
            {
                parStatus = "b";
            }



            if (parBas == "" || parBasBit == "" || parBit == "" || parBitbit == "" || parAd == "" || parID == "")
            {
                MessageBox.Show("Lütfen tüm değerleri giriniz!");
                dur = 1;
            }
            else
            {
                if (Int32.Parse(parBit) < Int32.Parse(parBas))
                {
                    MessageBox.Show("Parametre başlangıç byte değeri bitiş değerinden büyük olamaz!");
                    dur = 1;
                }
                else
                {
                    dur = 0;
                }
                if (parBas == parBit)
                {
                    if (parBasBit == parBitbit)
                    {
                        MessageBox.Show("Başlangıç Byte ve Bit değerleri ile Bitiş Byte ve Bit değerleri aynı olamaz!");
                        dur = 1;
                    }
                }
                else
                {
                    dur = 0;
                }
                if (Int32.Parse(parBas) > 7 || Int32.Parse(parBit) > 7)
                {
                    MessageBox.Show("Başlangıç/Bitiş Byte değeri 0-7 arasında olmalıdır!");
                    dur = 1;
                }

                if (Int32.Parse(parBasBit) > 7 || Int32.Parse(parBitbit) > 7)
                {
                    MessageBox.Show("Başlangıç/Bitiş Bit değeri 0-7 arasında olmalıdır!");
                    dur = 1;
                }

                if (dur == 0)
                {
                    string parameter = parAd + "," + parID + "," + parBas + "," + parBasBit + "," + parBit + "," + parBitbit + "," + parStatus + "," + faktor.Replace(',','.') + "," + birim;
                    filter.parametersL[parNo]=parameter;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void ChLittle_Click(object sender, EventArgs e)
        {
            if (chLittle.Checked = true)
            {
                parStatus = "l";
                chBig.Checked = false;
            }
        }

        private void ChBig_Click(object sender, EventArgs e)
        {
            if (chBig.Checked = true)
            {
                parStatus = "b";

                chLittle.Checked = false;
            }
        }
    }
}
