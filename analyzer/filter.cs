using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
namespace analyzer
{
    public  partial class filter : Form
    {
        public filter()
        {
            InitializeComponent();
        }




        OpenFileDialog fileGet = new OpenFileDialog();

       
        
        // datatable lar

        DataTable dt = new DataTable(); // unfilter
        DataTable dt2 = new DataTable(); // filted
      
        public static DataTable dt4 = new DataTable();

        DataTable dtProfRead = new DataTable(); // profil txt okunan dt
        DataTable dtProfWrite = new DataTable(); // profil txt yazılacak dt
        // list ler



        List<string> mainList = new List<string>();

        List<double> timeList = new List<double>();
        List<string> infoList = new List<string>();

        List<double> timeList2 = new List<double>();
        List<string> infoList2 = new List<string>();

        List<double> resultList1 = new List<double>();
        List<double> resultList2 = new List<double>();

        public static List<string> parametersL = new List<string>();

        List<string> profilNames = new List<string>();


        List<string> bS = new List<string>(); // bytes situation
        List<string> bS2 = new List<string>(); // bytes situation


        List<string> sepBin = new List<string>();

        List<List<string>> basliklar = new List<List<string>>();
        // diziler

        string[] pSelected;
        string[] scannedWord;
        string foundWord;
        string[] raw_text;
        List<string> profile_raw = new List<string>();

        // string ler

        string fileWay;
        string parName1, parName2;
        string parID1, parID2;
        string parS1, parS2, rawS, timeS; // little big statusler ve satır zaman statusleri
        string bugControl;
        string searchParID1, searchParID2;
        string deger;
        string hexValue;
        string binaryValue;
        string decValue;
        string timeSt, timeF, rawSt, rawF;
        string  birim1, birim2;
        string fileName;

        string exeFileWay;
        string sProfilN;
        string grafikSeri;


        // int ler
        int fileRawNo, unNecRaw;
        int bugCounter; // bugFix de //1 den sonraki sayım için
        int bugNoDel; // bugFix de fazla index silinmesini önleme durumu
        int parSt1, parStBit1, parLt1, parLtBit1;
        int parSt2, parStBit2, parLt2, parLtBit2;
        int a, b, d;
        int byteSira;
        int progMax, progMin, progValue;
        int z;
        int profil1, profil2;
        int kontrol;
        int profilIndex; // profil adının profilNames de ki index no karşılığı
        int newProStatus;
        int x, y;

        int zValue;
        int maxValue;

        double interValue = 40; // gerçek değerini grafikDraw da alıyor
        double factor1, factor2;
        double firstInterval;
        int eksenS;

        int proParNo;

       


        void readAgain()
        {
            profile_raw.Clear();
            parametersL.Clear();
            profilNames.Clear();
            cbProfil.Items.Clear();
           
            string[] profilDizi = System.IO.File.ReadAllLines(exeFileWay);
            profile_raw = profilDizi.ToList(); // profil_raw doldurma

            parChList.Items.Clear(); // parchlist temizleme

            for (int i = profilIndex + 2; i < profile_raw.Count; i++) // parametersL dolumu
            {
                if (profile_raw[i] == "---" || profile_raw[i] == "END")
                {
                    break;
                }
                parametersL.Add(profile_raw[i]);
            }

            for (int i = 0; i < parametersL.Count; i++) 
            {
                parChList.Items.Add(parametersL[i]);
            }

            for (int i = 0; i < profile_raw.Count; i++)
            {
                if (profile_raw[i] == "---")
                {
                    profilNames.Add(profile_raw[i + 1]);
                }
            }

            for (int i = 0; i < profilNames.Count; i++)
            {
                cbProfil.Items.Add(profilNames[i]);
            } // combobox pro

            cbProfil.Text = profilNames[profilNames.Count-1];
        }

        private void Filter_Load(object sender, EventArgs e)
        {
            zoomScrool.Minimum = 1;
            zoomScrool.Maximum = 10;


            txtSatBas.Enabled = false;
            txtSatBit.Enabled = false;
            txtZamBas.Enabled = false;
            txtZamBit.Enabled = false;


            resultDG.DataSource = dt4;

            // datatable kolon eklemeler
            dt.Columns.Add("Text");
            dt2.Columns.Add("Filtered Text");
     

            dt4.Columns.Add("Deger");
            dt4.Columns.Add("Zaman");

            txtSatBas.Enabled = false;
            txtSatBit.Enabled = false;
            txtZamBas.Enabled = false;
            txtZamBit.Enabled = false;

           
            profileRead();
            //İLK ÇALIŞMADA PROFİL OKUMA VE DOLDURMA



            for (int i = 0; i < profilNames.Count; i++)
            {
                cbProfil.Items.Add(profilNames[i]);
            } // combobox profil doldurma
            try
            {
                cbProfil.Text = profilNames[0];
            }
            catch (Exception)
            {

                MessageBox.Show("Profil kayıt dosyası resetlenecek!");
                System.IO.File.Delete(exeFileWay);
                using (StreamWriter sw = File.CreateText(Application.StartupPath.ToString() + "\\profil.txt"))
                {
                    sw.WriteLine("---");
                    sw.WriteLine("PROFIL");
                    sw.WriteLine("0,0,0,0,0,0");
                    sw.WriteLine("END");
                }

                Application.Restart();
                profileRead();
                profilIndex = 1;
            }

         

            //selectedProRead();

            if (chTime.Checked==true && chRaw.Checked==true)
            {
                chTime.Checked = false;
                timeS = "0";
                txtZamBas.Enabled = false;
                txtZamBit.Enabled = false;
            }
        }

        void uploadFile()
        {
            

            lblFileName.Text = fileGet.SafeFileName;
           
            System.IO.StreamReader file = new StreamReader(fileWay);
            raw_text = System.IO.File.ReadAllLines(fileWay); // raw_text doldurma

            while ((file.ReadLine()) != null)
            {
                fileRawNo++; // dosyadaki satır numaralarını öğrenme
            }

         
            progBar.Maximum = fileRawNo-7;
            progBar.Minimum = 0;
           
            

            unfilteredList();

            filteredList();
        }

        void unfilteredList()
        {

            foreach (string text_line in raw_text)
            {
                unNecRaw++;

                if (unNecRaw<8)
                {}
                else
                {
                    dt.Rows.Add(text_line); // dt doldur
                }

            }
        }

        private void BtnParRef_Click(object sender, EventArgs e)
        {
            refreshPar();
            
        }

        private void BtnCiz_Click(object sender, EventArgs e)
        {
            interValue = 0;
            infoList.Clear();
            infoList2.Clear();
            timeList.Clear();
            timeList2.Clear();
            dt4.Clear();
            grafikTool.Series["Series1"].Points.Clear();
            bS.Clear();

            resultList1.Clear();
            resultList2.Clear();
            if (chTime.Checked==true || chRaw.Checked==true)
            {
                if ((txtZamBas.Text.Trim()=="0" && txtZamBit.Text.Trim()=="0") || (txtSatBas.Text.Trim()=="0" && txtSatBit.Text.Trim()=="0"))
                {
                    MessageBox.Show("Başlangıç ve bitiş filtre değerleri aynı olamaz!");
                }
                else
                {
                    parWrite();
                }
            }
            else
            {
                parWrite();
            }
           
            

        }

        private void BtnFileSec_Click(object sender, EventArgs e)
        {
            fileGet.Filter = "Asc Dosyası |*.asc";
            fileGet.RestoreDirectory = true;
            fileGet.ShowDialog();

            fileWay = fileGet.FileName;
       
            loadFile();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnNewPar_Click(object sender, EventArgs e)
        {
            newParameter par = new newParameter();
            if (par.ShowDialog() == DialogResult.OK)
            {
                refreshPar();
            }
        }

        void filteredList()
        {
            for (int i = 0; i < fileRawNo-7; i++)
            {
                string[] seperate = { "  " };
                string rawText = dt.Rows[i][0].ToString(); // her satırı rawText yaz
                string[] words = rawText.Split(seperate, System.StringSplitOptions.RemoveEmptyEntries); // rawText ayrıştır

                foreach (var word in words)
                {
                    mainList.Add(word); // ana listeye word ekle

                    scannedWord = word.Trim().Split(' '); // eklenen word leri tek boşlukla ayır scanned word e ekle
                    foundWord = word;

                    bugFix();

                    
                }
                progBar.Value++;
            }

            foreach (var item in mainList)
            {
                dt2.Rows.Add(item);  // düzenlenmiş mainlist i dt2 ye doldurma
            }
        }

        private void BtnAxisC_Click(object sender, EventArgs e)
        {
            axisChange();
        }

        private void TxtSatBas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void GrafikTool_MouseClick(object sender, MouseEventArgs e)
        {
            if (z == 1)
            {
                int pixX = e.Location.X;
                int pixY = e.Location.Y;

                double yAxis = grafikTool.ChartAreas["ChartArea1"].AxisY.PixelPositionToValue(e.Location.Y);
                double xAxis = grafikTool.ChartAreas["ChartArea1"].AxisX.PixelPositionToValue(e.Location.X);

              // grafikTool.ChartAreas["ChartArea1"].AxisY.ScaleView.Zoom(yAxis - 15, yAxis + 15);
                grafikTool.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoom(xAxis - zValue, xAxis + zValue);

             
                grafikTool.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -45;
                grafikTool.ChartAreas["ChartArea1"].AxisY.LabelStyle.Angle = -45;

                

                // grafikTool.ChartAreas["ChartArea1"].AxisY.Interval = yAxis;
                //   grafikTool.ChartAreas["ChartArea1"].AxisX.Interval = xAxis;
            }
           
        }

        private void BtnZoomAktif_Click(object sender, EventArgs e)
        {
            z = 1;
        }

        private void GrafikTool_KeyPress(object sender, KeyPressEventArgs e)
        {

       
        }

        private void GrafikTool_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void BtnZoomKapa_Click(object sender, EventArgs e)
        {
            z = 0;
            grafikTool.ChartAreas[0].AxisX.ScaleView.ZoomReset(1);
            grafikTool.ChartAreas[0].AxisY.ScaleView.ZoomReset(1);
        }

        private void BtnIntPlus_Click(object sender, EventArgs e)
        {

           

    

            if (interValue <= ((firstInterval * 8) / 30))
            {

            }
            else
            {

                if (chTime.Checked == true || chRaw.Checked == true)
                {
                    x = 1;
                    dt4.Clear();
                    grafikTool.Series["Series1"].Points.Clear();
                    interValue = interValue / 2;
                    grafikFill();
                }
                else { 


                grafikTool.Series["Series1"].Points.Clear();
                interValue = interValue / 2;
                if (eksenS == 0)
                {

                    if (parChList.CheckedItems.Count > 1)
                    {
                        for (int i = 0; i < dt4.Rows.Count; i++)
                        {
                            DataPoint dp = new DataPoint();
                            dp.SetValueXY(resultList1[i], resultList2[i]);
                            grafikTool.Series["Series1"].Points.Add(dp);
                        }
                    } // eksen default 0 ise
                    else
                    {
                        for (int i = 0; i < dt4.Rows.Count; i++)
                        {
                            DataPoint dp = new DataPoint();
                            dp.SetValueXY(timeList[i], resultList1[i]);
                            grafikTool.Series["Series1"].Points.Add(dp);
                        }
                    }


                    resultDG.DataSource = dt4;
             
                    grafikTool.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    grafikTool.ChartAreas[0].AxisY.LabelStyle.Format = "";

                    grafikTool.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -45;
                    grafikTool.ChartAreas["ChartArea1"].AxisY.LabelStyle.Angle = -45;

                    grafikTool.ChartAreas["ChartArea1"].AxisX.Interval = interValue;

                }
                else
                {

                    if (parChList.CheckedItems.Count > 1)
                    {
                        for (int i = 0; i < dt4.Rows.Count; i++)
                        {
                            DataPoint dp = new DataPoint();
                            dp.SetValueXY(resultList2[i], resultList1[i]);
                            grafikTool.Series["Series1"].Points.Add(dp);
                        }
                    } // eksen default 0 ise
                    else
                    {
                        for (int i = 0; i < dt4.Rows.Count; i++)
                        {
                            DataPoint dp = new DataPoint();
                            dp.SetValueXY(resultList1[i], timeList[i]);
                            grafikTool.Series["Series1"].Points.Add(dp);
                        }
                    }


                    resultDG.DataSource = dt4;
                    //grafikTool.DataSource = dt4;
                    //grafikTool.Series["Series1"].XValueMember = "Zaman";
                    //grafikTool.Series["Series1"].YValueMembers = "Deger";
                    grafikTool.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    grafikTool.ChartAreas[0].AxisY.LabelStyle.Format = "";

                    grafikTool.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -45;
                    grafikTool.ChartAreas["ChartArea1"].AxisY.LabelStyle.Angle = -45;

                    grafikTool.ChartAreas["ChartArea1"].AxisX.Interval = interValue;



                }

            }



        }


    }

        private void TxtSatBit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtZamBas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ChRaw_Click(object sender, EventArgs e)
        {
            if (chRaw.Checked==true)
            {
                chTime.Checked = false;
                txtZamBas.Enabled = false;
                txtZamBit.Enabled = false;

                txtSatBas.Enabled = true;
                txtSatBit.Enabled = true;
                rawS = "1";
                timeS = "0";

                txtSatBas.Text = rawSt;
                txtSatBit.Text = rawF;
            }
            else
            {
                txtSatBas.Enabled = false;
                txtSatBit.Enabled = false;

                rawS = "0";
            }
        }

        private void ChTime_Click(object sender, EventArgs e)
        {
     

            if (chTime.Checked == true)
            {
                chRaw.Checked = false;
                txtSatBas.Enabled = false;
                txtSatBit.Enabled = false;

                txtZamBas.Enabled = true;
                txtZamBit.Enabled = true;
                timeS = "1";
                rawS = "0";

                txtZamBas.Text = timeSt;
                txtZamBit.Text = timeF;

            }
            else
            {
                txtZamBas.Enabled = false;
                txtZamBit.Enabled = false;
                timeS = "0";
            }
        }

        private void TxtZamBit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtZamBit_TextChanged(object sender, EventArgs e)
        {

        }

        private void CbProfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                parametersL.Clear();
                sProfilN = cbProfil.SelectedItem.ToString();
            try
            {
               // profilIndex = Array.IndexOf(profile_raw, sProfilN);
                profilIndex = profile_raw.IndexOf(sProfilN);
                selectedProRead();
                timeRawRead();
            }
            catch (Exception)
            {

                
            }


                parChList.Items.Clear();
                for (int i = 0; i < parametersL.Count; i++)
                {
                    parChList.Items.Add(parametersL[i]);
                }
            
           
        }

        private void BtnNewPro_Click(object sender, EventArgs e)
        {
            y = 0;
            if (txtNewPro.Text.Trim() != "")
            {
                for (int i = 0; i < profilNames.Count; i++)
                {
                    if (txtNewPro.Text.Trim()==profilNames[i])
                    {
                        MessageBox.Show("Profil adı halihazırda kayıtlı!\nLütfen farklı bir profil adı giriniz.");
                        y = 1; // don't register
                    }

                }

                if (y == 0)
                {
                    profilNames.Add(txtNewPro.Text.Trim());
                    parametersL.Clear();
                    //rawS = "0";
                    rawSt = "0";
                    rawF = "0";
                    //timeS = "0";
                    timeSt = "0";
                    timeF = "0";
                    cbProfil.Items.Clear();
                    for (int i = 0; i < profilNames.Count; i++)
                    {
                        cbProfil.Items.Add(profilNames[i]);
                    }
                    //  cbProfil.SelectedItem = txtNewPro.Text.Trim();
                    txtNewPro.Clear();
                    newProStatus = 1;

                    newProfile();

                    readAgain();
                }
            
            }
            else
            {
                MessageBox.Show("Lütfen Profil Adı Giriniz!");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            profileWrite();
            readAgain();
           // Application.Restart();
        }

        private void BtnParDel_Click(object sender, EventArgs e)
        {
            if (parChList.CheckedItems.Count < 1)
            {
                MessageBox.Show("En az 1 adet parametre seçiniz!");
            }
            else
            {
                for (int i = 0; i < parChList.CheckedItems.Count; i++)
                {
                    int parIndexNo = parametersL.IndexOf(parChList.CheckedItems[i].ToString());
                    parametersL.Remove(parChList.CheckedItems[i].ToString());

                    // seçilen parametre profile_raw da kayıtlı ise oradan silmek için

                    if (profile_raw.Count >= profilIndex + 2 + parIndexNo)
                    {
                       if (profile_raw[profilIndex + 2 + parIndexNo] == parChList.CheckedItems[i].ToString())
                    {
                        profile_raw.RemoveAt(profilIndex + 2 + parIndexNo);
                        proParNo--;
                    }
                    }
                }
                btnParRef.PerformClick();
            }
        }

        private void BtnProDel_Click(object sender, EventArgs e)
        {
            int profilIndexNo = profile_raw.IndexOf(cbProfil.SelectedItem.ToString());

            if (MessageBox.Show("Seçili Profili Silmek İstiyor Musunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    for (int i = 0; i < parametersL.Count + 2; i++)
                    {
                        profile_raw.RemoveAt(profilIndexNo); 
                    }
                    profile_raw.RemoveAt(profilIndexNo - 1);
                    parametersL.Clear();
                    //uygulama konumu alma ve yol yazma
                    exeFileWay = Application.StartupPath.ToString() + "\\profil.txt";
                   // File.WriteAllText(exeFileWay, null); // txt içini temizleme
                    
                   


                    using (StreamWriter sw2 = File.CreateText(exeFileWay))
                    {
                        sw2.WriteLine("");
                    }

                    FileStream fs = new FileStream(exeFileWay, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);

                    for (int i = 0; i < profile_raw.Count; i++)
                    {
                        sw.WriteLine(profile_raw[i]);
                    }

                    sw.Flush();
                    sw.Close();
                    fs.Close();
                    parChList.Items.Clear();
                    MessageBox.Show(cbProfil.SelectedItem.ToString() + " profili başarı ile silindi!");
                    //Application.Restart();
                    profilIndexNo = 1;
                    readAgain();
                }
                catch (Exception)
                {

                    MessageBox.Show("Program yeniden başlatılacak...");
                    Application.Restart();
                }
            }

            
           
        }

       


        void bugFix()
        {
             
            if (scannedWord[0]=="Length")  // length bilgisi parafını sil
            {
                mainList.RemoveAt((mainList.Count - 1));
            }

            if (scannedWord.Length>1 && scannedWord[1] == "Diag:")
            {
                mainList.RemoveAt((mainList.Count - 1));
            }

            if (scannedWord[0] == "Statistic:") // statistic yazan satırı sil
            {
                mainList.RemoveAt((mainList.Count - 1));
                mainList.RemoveAt((mainList.Count - 1));
            }

            if (foundWord == " Tx" || foundWord == " Rx")
            {
                mainList.RemoveAt((mainList.Count - 1));
            }

            if (bugCounter >=1)
            {
                bugCounter++;
            }

            if (scannedWord.Length >= 7)
            {
                bugControl = "";
                bugControl += scannedWord[4] + " " + scannedWord[5];

                if (bugControl=="FF Length:")
                {
                    bugNoDel = 1;
                }
                
            }

            if (foundWord== "BSmax: 0x00, STmin: 0x00 ms")
            {
                bugNoDel = 1;
            }

            if (bugCounter==4)
            {
                int indexno = mainList.IndexOf(foundWord);
                if (bugNoDel==1)
                {bugNoDel = 0;}
                else
                {
                    mainList.RemoveAt(indexno); // //1 den itibaren 4. sayılan itemi sil
                }

                mainList.RemoveAt(indexno - 1);
                mainList.RemoveAt(indexno - 2);
                mainList.RemoveAt(indexno - 3);
                bugCounter = 0;
            }

            if (foundWord=="// 1")
            {
                bugCounter++; // // 1 değeri ve sonraki 3 itemi silmek için sayaç ile her adımda sayarak gereksiz 4lüyü siliyoruz.
            }
       
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            grafikTool.Series["Series1"].Points.Clear();
            interValue = 2*interValue;
       


            if (interValue >= firstInterval)
            {
                interValue = firstInterval;
            }

            if (chTime.Checked == true || chRaw.Checked == true)
            {
                x = 1;
                dt4.Clear();
                grafikTool.Series["Series1"].Points.Clear();
                grafikFill();
            }
            else { 
            if (eksenS == 1)
            {
                if (parChList.CheckedItems.Count > 1)
                {
                    for (int i = 0; i < dt4.Rows.Count; i++)
                    {
                        DataPoint dp = new DataPoint();
                        dp.SetValueXY(resultList2[i], resultList1[i]);
                        grafikTool.Series["Series1"].Points.Add(dp);
                    }
                } // eksen default 0 ise
                else
                {
                    for (int i = 0; i < dt4.Rows.Count; i++)
                    {
                        DataPoint dp = new DataPoint();
                        dp.SetValueXY(resultList1[i], timeList[i]);
                        grafikTool.Series["Series1"].Points.Add(dp);
                    }
                }

                resultDG.DataSource = dt4;
                //grafikTool.DataSource = filter.dt4;
                //grafikTool.Series["Series1"].XValueMember = "Deger";
                //grafikTool.Series["Series1"].YValueMembers = "Zaman";
                grafikTool.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                grafikTool.ChartAreas[0].AxisY.LabelStyle.Format = "";

                grafikTool.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -45;
                grafikTool.ChartAreas["ChartArea1"].AxisY.LabelStyle.Angle = -45;

                grafikTool.ChartAreas["ChartArea1"].AxisX.Interval = interValue;

            }
            else
            {


                if (parChList.CheckedItems.Count > 1)
                {
                    for (int i = 0; i < dt4.Rows.Count; i++)
                    {
                        DataPoint dp = new DataPoint();
                        dp.SetValueXY(resultList1[i], resultList2[i]);
                        grafikTool.Series["Series1"].Points.Add(dp);
                    }
                } // eksen default 0 ise
                else
                {
                    for (int i = 0; i < dt4.Rows.Count; i++)
                    {
                        DataPoint dp = new DataPoint();
                        dp.SetValueXY(timeList[i], resultList1[i]);
                        grafikTool.Series["Series1"].Points.Add(dp);
                    }
                }

                resultDG.DataSource = dt4;
                //grafikTool.DataSource = dt4;
                //grafikTool.Series["Series1"].XValueMember = "Zaman";
                //grafikTool.Series["Series1"].YValueMembers = "Deger";
                grafikTool.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                grafikTool.ChartAreas[0].AxisY.LabelStyle.Format = "";

                grafikTool.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -45;
                grafikTool.ChartAreas["ChartArea1"].AxisY.LabelStyle.Angle = -45;

                grafikTool.ChartAreas["ChartArea1"].AxisX.Interval = interValue;



            }

            }



        }

        private void BtnFixPar_Click(object sender, EventArgs e)
        {

            try
            {
                fixParameter fp = new fixParameter();

                if (parChList.CheckedItems.Count > 1 )
                {
                    MessageBox.Show("Lütfen 1 adet parametre seçiniz.");
                }
                else
                {
                    fixParameter.parNo = parChList.Items.IndexOf(parChList.CheckedItems[0].ToString());
                    fixParameter.parameter = parChList.CheckedItems[0].ToString();



                    if (fp.ShowDialog() == DialogResult.OK)
                    {
                        refreshPar();
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen 1 adet parametre seçiniz.");
            }
          
        }

        private void ZoomScrool_ValueChanged(object sender, EventArgs e)
        {

            label5.Text = (zoomScrool.Value).ToString();
        }

        private void BtnSaveGra_Click(object sender, EventArgs e)
        {
            if (resultList1.Count>1)
            {
                SaveFileDialog savechart = new SaveFileDialog();
                savechart.Filter = "JPEG Dosyası |*.jpg";
                savechart.Title = "Grafiği kayıt et";
                savechart.RestoreDirectory = true;
                savechart.ShowDialog();
                try
                {
                    if (savechart.FileName != "")
                    {
                        System.IO.FileStream fs = (System.IO.FileStream)savechart.OpenFile();
                        this.grafikTool.SaveImage(fs, System.Drawing.Imaging.ImageFormat.Jpeg);

                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Lütfen dosya yolu belirtiniz.");
                }
               
            }
            else
            {
                MessageBox.Show("Lütfen grafik çizdiriniz...");
            }
            
        }

        private void ParChList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (parChList.CheckedItems.Count >= 2)
            {
                chTime.Enabled = false;
            }
            else
            {
                chTime.Enabled = true;
            }
        }

        private void ParChList_DoubleClick(object sender, EventArgs e)
        {
            if (parChList.CheckedItems.Count >= 2)
            {
                chTime.Enabled = false;
                txtZamBit.Enabled = false;
                txtZamBas.Enabled = false;
            }
            else
            {
                chTime.Enabled = true;
                txtZamBit.Enabled = true;
                txtZamBas.Enabled = true;
            }
        }

        private void ParChList_Click(object sender, EventArgs e)
        {
            try
            {
                string[] selected = parChList.SelectedItem.ToString().Split(',');
                lblSeciliPar.Text = selected[0];
                
                if (parChList.CheckedItems.Count >=2)
                {
                    chTime.Checked = false;
                    txtZamBit.Enabled = false;
                    txtZamBas.Enabled = false;

                }
                else
                {
                    chTime.Enabled = true;
                    txtZamBit.Enabled = true;
                    txtZamBas.Enabled = true;
                }




            }
            catch { }
            
        }

        private void BtnSonuc_Click(object sender, EventArgs e)
        {
           

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            
      
        }

        void search()   // ara ve doldur
        {
            timeList.Clear();
            infoList.Clear();
            resultList1.Clear();
            dt4.Clear();
            if (parChList.CheckedItems.Count==1) // tek item seçili ise
            {
                for (int i = 0; i < dt2.Rows.Count; i++) // filter list sayısı kadar
                {
                    if (dt2.Rows[i][0].ToString() == parID1)
                    {
                        string[] time = (dt2.Rows[(i - 1)][0].ToString().Trim().Split(' ')); // zaman ı split yap

                        string info = dt2.Rows[(i + 1)][0].ToString().Trim().Substring(2); // gelen bilgi

                        if (timeS=="1")
                        {
                            double timeValue = double.Parse(time[0].Replace('.', ',').Trim());
                            if (timeValue>Int32.Parse(timeSt))
                            {
                                if (timeValue < Int32.Parse(timeF))
                                {
                                    timeList.Add(double.Parse(time[0].Replace('.', ',').Trim())); // zamanı double olarak ekle
                                    infoList.Add(info.Replace(" ", string.Empty)); // bilgiyi string ekle
                                }
                            }
                        }
                        else
                        {
                            timeList.Add(double.Parse(time[0].Replace('.', ',').Trim())); // zamanı double olarak ekle
                            infoList.Add(info.Replace(" ", string.Empty)); // bilgiyi string ekle
                        }
 

                        

                        bS.Add(info.Substring(0, 1));

                        


                    }
                }
                if (parS1=="b")
                {
                    calculate1();
                }
                else
                {
                    littleCalculate1();
                }
            } // tek item seçili ise

            if (parChList.CheckedItems.Count == 2) // iki item seçili ise
            {
                for (int i = 0; i < dt2.Rows.Count; i++) // filter list sayısı kadar
                {
                    if (dt2.Rows[i][0].ToString() == parID1)
                    {
                   //     string[] time = (dt2.Rows[(i - 1)][0].ToString().Trim().Split(' ')); // zaman ı split yap

                        string info = dt2.Rows[(i + 1)][0].ToString().Trim().Substring(2); // gelen bilgi

                   //     timeList.Add(double.Parse(time[0].Replace('.', ',').Trim())); // zamanı double olarak ekle

                        infoList.Add(info.Replace(" ", string.Empty)); // bilgiyi string ekle

                        bS.Add(info.Substring(0, 1));




                    }
                }

                for (int i = 0; i < dt2.Rows.Count; i++) // filter list sayısı kadar
                {
                    if (dt2.Rows[i][0].ToString() == parID2)
                    {
                   //     string[] time = (dt2.Rows[(i - 1)][0].ToString().Trim().Split(' ')); // zaman ı split yap

                        string info = dt2.Rows[(i + 1)][0].ToString().Trim().Substring(2); // gelen bilgi

                   //     timeList2.Add(double.Parse(time[0].Replace('.', ',').Trim())); // zamanı double olarak ekle (iki item seçili ise time a gerek yok 

                        infoList2.Add(info.Replace(" ", string.Empty)); // bilgiyi string ekle

                        bS2.Add(info.Substring(0, 1));




                    }
                }

                if (parS1 == "b")
                {
                    calculate1();
                }
                else
                {
                    littleCalculate1();
                }

                if (parS2 == "b")
                {
                    calculate2();
                }
                else
                {
                    littleCalculate2();
                }


            }

            if (parChList.CheckedItems.Count==1)
            {
                if (infoList.Count > 0)
                {
                    grafikFill();
                }
                else
                {
                    MessageBox.Show("Aranılan ID: " + parID1 + " bulunamadı.");
                }
            }

            if (parChList.CheckedItems.Count>1)
            {
                if (infoList.Count>0)
                {
                    if (infoList2.Count>0)
                    {
                        grafikFill();
                    }
                    else
                    {
                        MessageBox.Show("Aranılan 2. ID: " + parID2 + " bulunamadı.");
                    }
                }
                else
                {
                    MessageBox.Show("Aranılan  ID: " + parID1 + " bulunamadı.");
                }
            }
            

        }

        

       

        void calculate1()
        {

            for (int t = 0; t < infoList.Count; t++)
            {
                hexValue = infoList[t].Substring(1);
                binaryValue = String.Join(String.Empty, hexValue.Select(c => Convert.ToString(Convert.ToInt64(c.ToString(), 16), 2).PadLeft(4, '0'))); // hex value convert to binary
                a = 0;
                for (int i = 0; i < 8; i++)
                {

                    sepBin.Add(binaryValue.Substring(a, 8));
                    a = a + 8;

                }

                if ((parLt1 - parSt1) != 0) // BAŞLANGIÇ BİTİŞ BYTELARI AYNI DEĞİL İSE BİTİŞ BYTE DA İSTENENLERİ YAZ
                {
                    decValue += (sepBin[(parLt1)]).Substring(8 - parLtBit1-1);
                }
                else
                {
                    decValue += (sepBin[(parLt1)]).Substring((8 - parLtBit1-1), (parLtBit1 - parStBit1+1));
                }

                b = parLt1 - 1; // BYTE LAR ARASI TAM LARI YAZMAK İÇİN

                for (int i = 0; i < parLt1 - parSt1 - 1; i++) // 
                {
                    decValue += sepBin[b];
                    b--;
                }

                if ((parLt1 - parSt1) != 0) // BAŞLANGIÇ BİTİŞ AYNI BYTE DA DEĞİL İSE BAŞLANGIÇ BYTE DA İSTENİLENLERİ YAZ
                {
                    decValue += sepBin[(parSt1)].Substring(0, (8 - parStBit1));
                }

                resultList1.Add( (( (Convert.ToInt64(decValue,2)) * factor1)) );
                decValue = "";
                hexValue = "";
                binaryValue = "";
                sepBin.Clear();
            }

           
            

        }

        void calculate2()
        {

            for (int t = 0; t < infoList2.Count; t++)
            {
                hexValue = infoList2[t].Substring(1);
                binaryValue = String.Join(String.Empty, hexValue.Select(c => Convert.ToString(Convert.ToInt64(c.ToString(), 16), 2).PadLeft(4, '0')));
                a = 0;
                for (int i = 0; i < 8; i++)
                {

                    sepBin.Add(binaryValue.Substring(a, 8));
                    a = a + 8;

                }

                if ((parLt2 - parSt2) != 0) // BAŞLANGIÇ BİTİŞ BYTELARI AYNI DEĞİL İSE BİTİŞ BYTE DA İSTENENLERİ YAZ
                {
                    decValue += (sepBin[(parLt2)]).Substring(8 - parLtBit2-1);
                }
                else
                {
                    decValue += (sepBin[(parLt2)]).Substring((8 - parLtBit2-1), (parLtBit2 - parStBit2+1));
                }

                b = parLt2 - 1; // BYTE LAR ARASI TAM LARI YAZMAK İÇİN

                for (int i = 0; i < parLt2 - parSt2 - 1; i++) // 
                {
                    decValue += sepBin[b];
                    b--;
                }

                if ((parLt2 - parSt2) != 0) // BAŞLANGIÇ BİTİŞ AYNI BYTE DA DEĞİL İSE BAŞLANGIÇ BYTE DA İSTENİLENLERİ YAZ
                {
                    decValue += sepBin[(parSt2)].Substring(0, (8 - parStBit2));
                }

                resultList2.Add(((Convert.ToInt64(decValue, 2)) * factor2 ));
                decValue = "";
                hexValue = "";
                binaryValue = "";
                sepBin.Clear();
            }




        }

        void littleCalculate1()
        {

            for (int t = 0; t < infoList.Count; t++)
            {
                hexValue = infoList[t].Substring(1);
                binaryValue = String.Join(String.Empty, hexValue.Select(c => Convert.ToString(Convert.ToInt64(c.ToString(), 16), 2).PadLeft(4, '0')));
                a = 0;
                for (int i = 0; i < 8; i++)
                {

                    sepBin.Add(binaryValue.Substring(a, 8));
                    a = a + 8;

                }

                if ((parLt1 - parSt1) != 0) // BAŞLANGIÇ BİTİŞ AYNI BYTE DA DEĞİL İSE BAŞLANGIÇ BYTE DA İSTENİLENLERİ YAZ
                {
                    decValue += sepBin[(parSt1)].Substring(0, (8 - parStBit1));
                }

                b = parSt1 + 1; // BYTE LAR ARASI TAM LARI YAZMAK İÇİN

                for (int i = 0; i < parLt1 - parSt1 - 1; i++) // 
                {
                    decValue += sepBin[b];
                    b++;
                }

                if ((parLt1 - parSt1) != 0) // BAŞLANGIÇ BİTİŞ BYTELARI AYNI DEĞİL İSE BİTİŞ BYTE DA İSTENENLERİ YAZ
                {
                   decValue += (sepBin[(parLt1)]).Substring(8 - parLtBit1 - 1);
                  
                }
                else
                {
                    decValue += (sepBin[(parLt1)]).Substring((8 - parLtBit1 - 1), (parLtBit1 - parStBit1 + 1));
                }

               

              

              

                resultList1.Add(((Convert.ToInt64(decValue, 2)) * factor1 ));
                decValue = "";
                hexValue = "";
                binaryValue = "";
                sepBin.Clear();
            }




        }

        void littleCalculate2()
        {

            for (int t = 0; t < infoList2.Count; t++)
            {
                hexValue = infoList2[t].Substring(1);
                binaryValue = String.Join(String.Empty, hexValue.Select(c => Convert.ToString(Convert.ToInt64(c.ToString(), 16), 2).PadLeft(4, '0')));
                a = 0;
                for (int i = 0; i < 8; i++)
                {

                    sepBin.Add(binaryValue.Substring(a, 8));
                    a = a + 8;

                }

                if ((parLt2 - parSt2) != 0) // BAŞLANGIÇ BİTİŞ AYNI BYTE DA DEĞİL İSE BAŞLANGIÇ BYTE DA İSTENİLENLERİ YAZ
                {
                    decValue += sepBin[(parSt2)].Substring(0, (8 - parStBit2));
                }

                b = parSt1 + 1; // BYTE LAR ARASI TAM LARI YAZMAK İÇİN

                for (int i = 0; i < parLt2 - parSt2 - 1; i++) // 
                {
                    decValue += sepBin[b];
                    b++;
                }

                if ((parLt1 - parSt1) != 0) // BAŞLANGIÇ BİTİŞ BYTELARI AYNI DEĞİL İSE BİTİŞ BYTE DA İSTENENLERİ YAZ
                {
                    decValue += (sepBin[(parLt2)]).Substring(8 - parLtBit2 - 1);

                }
                else
                {
                    decValue += (sepBin[(parLt2)]).Substring((8 - parLtBit2 - 1), (parLtBit2 - parStBit2 + 1));
                }







                resultList2.Add(( (Convert.ToInt64(decValue, 2) * factor2)  ));
                decValue = "";
                hexValue = "";
                binaryValue = "";
                sepBin.Clear();
            }




        }

        void grafikFill()
        {
            
           
            if (parChList.CheckedItems.Count==1) 
            {
                int tryNo;
                
                if (resultList1.Count < timeList.Count) // for döngülerinde her i değerinin liste itemine denk gelmesi için az sayısı olan list sayısını referans alıyoruz
                {
                    tryNo = resultList1.Count;
                }
                else
                {
                    tryNo = timeList.Count;
                }

                if (timeS=="1")
                {
                   
                    if (eksenS==0)
                    {
                        for (int i = Int32.Parse(timeSt); i < timeList.Count; i++)
                        {
                            DataPoint dp = new DataPoint();
                            dt4.Rows.Add(resultList1[i], timeList[i]);
                            dp.SetValueXY(timeList[i], resultList1[i]);
                            grafikTool.Series["Series1"].Points.Add(dp);
                        }
                        if (interValue == 0) { interValue = (timeList.Max()) / 8; }
                        maxValue = Convert.ToInt32(timeList.Max());
                        grafikTool.ChartAreas["ChartArea1"].AxisX.Interval = interValue;


                        grafikTool.ChartAreas["ChartArea1"].AxisY.Title = parName1 + "(" + birim1 + ")" + " Faktör: " + factor1.ToString();
                        grafikTool.ChartAreas["ChartArea1"].AxisX.Title = "Zaman" + " (mS)";

                        firstInterval = (timeList.Max()) / 8;
                    }
                    else
                    {
                        for (int i = 0; i < timeList.Count; i++)
                        {
                            DataPoint dp = new DataPoint();
                            dt4.Rows.Add(resultList1[i], timeList[i]);
                            dp.SetValueXY(resultList1[i], timeList[i]);
                            grafikTool.Series["Series1"].Points.Add(dp);
                        }
                        if (interValue == 0) { interValue = (resultList1.Max()) / 8; }
                        maxValue = Convert.ToInt32(resultList1.Max());
                        grafikTool.ChartAreas["ChartArea1"].AxisX.Interval = interValue;

                        grafikTool.ChartAreas["ChartArea1"].AxisX.Title = parName1 + "(" + birim1 + ")" + " Faktör: " + factor1.ToString();
                        grafikTool.ChartAreas["ChartArea1"].AxisY.Title = "Zaman" + " (mS)";

                        firstInterval = (resultList1.Max()) / 8;
                    }
                    // grafik özellikleri
                    grafikTool.ChartAreas["ChartArea1"].AxisX.TitleForeColor = Color.Red;
                    grafikTool.ChartAreas["ChartArea1"].AxisY.TitleForeColor = Color.Red;
                    grafikTool.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("myFont", 8, FontStyle.Bold);
                    grafikTool.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("myFont", 8, FontStyle.Bold);
                    grafikTool.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    grafikTool.ChartAreas[0].AxisY.LabelStyle.Format = "";
                    grafikTool.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -45;
                    grafikTool.ChartAreas["ChartArea1"].AxisY.LabelStyle.Angle = -45;


                }
             


                if (chRaw.Checked==true)
                {
                    rawSt = txtSatBas.Text.Trim();
                    rawF = txtSatBit.Text.Trim();
                    if (Int32.Parse(rawF) > tryNo) { rawF = tryNo.ToString(); }
                   
                        if (Int32.Parse(rawSt) < tryNo) // satır başlangıç en son değerden büyük ise birşey yapma
                        {
                           
                        if (eksenS==0)
                        {
                            for (int i = Int32.Parse(rawSt); i < Int32.Parse(rawF); i++)
                            {
                                DataPoint dp = new DataPoint();
                                dt4.Rows.Add(resultList1[i], timeList[i]);
                                dp.SetValueXY(timeList[i], resultList1[i]);
                                grafikTool.Series["Series1"].Points.Add(dp);
                            }
                            if (interValue == 0) { interValue = (timeList.Max()) / 8; }
                            maxValue = Convert.ToInt32(timeList.Max());
                            grafikTool.ChartAreas["ChartArea1"].AxisX.Interval = interValue;

                            grafikTool.ChartAreas["ChartArea1"].AxisX.Interval = interValue;

                            grafikTool.ChartAreas["ChartArea1"].AxisY.Title = parName1 + "(" + birim1 + ")" + " Faktör: " + factor1.ToString();
                            grafikTool.ChartAreas["ChartArea1"].AxisX.Title = "Zaman" + " (mS)";

                            firstInterval = (timeList.Max()) / 8;

                        }
                        else
                        {
                            for (int i = Int32.Parse(rawSt); i < Int32.Parse(rawF); i++)
                            {
                                DataPoint dp = new DataPoint();
                                dt4.Rows.Add(resultList1[i], timeList[i]);
                                dp.SetValueXY(resultList1[i], timeList[i]);
                                grafikTool.Series["Series1"].Points.Add(dp);
                            }
                            if (interValue == 0) { interValue = (resultList1.Max()) / 8; }
                            maxValue = Convert.ToInt32(resultList1.Max());
                            grafikTool.ChartAreas["ChartArea1"].AxisX.Interval = interValue;

                            grafikTool.ChartAreas["ChartArea1"].AxisX.Title = parName1 + "(" + birim1 + ")" + " Faktör: " + factor1.ToString();
                            grafikTool.ChartAreas["ChartArea1"].AxisY.Title = "Zaman"  + " (mS)";

                            firstInterval = (resultList1.Max()) / 8;
                        }
                        // grafik özellikleri
                        grafikTool.ChartAreas["ChartArea1"].AxisX.TitleForeColor = Color.Red;
                        grafikTool.ChartAreas["ChartArea1"].AxisY.TitleForeColor = Color.Red;
                        grafikTool.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("myFont", 8, FontStyle.Bold);
                        grafikTool.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("myFont", 8, FontStyle.Bold);
                        grafikTool.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        grafikTool.ChartAreas[0].AxisY.LabelStyle.Format = "";
                        grafikTool.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -45;
                        grafikTool.ChartAreas["ChartArea1"].AxisY.LabelStyle.Angle = -45;


                    }

                }
                if (chTime.Checked==false && chRaw.Checked==false)
                {
                    for (int i = 0; i < resultList1.Count; i++)
                    {
                        DataPoint dp = new DataPoint();
                        dt4.Rows.Add(resultList1[i], timeList[i]);
                        dp.SetValueXY(timeList[i], resultList1[i]);
                        grafikTool.Series["Series1"].Points.Add(dp);
                    }
                    grafikDraw();
                }

             
            }

            if (parChList.CheckedItems.Count == 2)
            {
                int tryNo;

                if (resultList1.Count < resultList2.Count)
                {
                    tryNo = resultList1.Count;
                }
                else
                {
                    tryNo = resultList2.Count;
                }

                if (rawS=="1")
                {
                    if (Int32.Parse(rawF) > tryNo) { rawF = tryNo.ToString(); } // son satır filtresi, listeden yüksekse birbirine eşitle

                    if (Int32.Parse(rawSt)<tryNo)
                        {

                        if (eksenS==0)
                        {
                            for (int i = Int32.Parse(rawSt); i < Int32.Parse(rawF); i++)
                            {
                                DataPoint dp = new DataPoint();
                                dt4.Rows.Add(resultList1[i], resultList2[i]);
                                dp.SetValueXY(resultList1[i], resultList2[i]);

                                grafikTool.Series["Series1"].Points.Add(dp);
                            }
                            grafikTool.ChartAreas["ChartArea1"].AxisX.Title = parName1 + "(" + birim1 + ")" + " Faktör: " + factor1.ToString();
                            grafikTool.ChartAreas["ChartArea1"].AxisY.Title = parName2 + "(" + birim2 + ")" + " Faktör: " + factor2.ToString();

                            firstInterval = (resultList1.Max()) / 8;
                            if (interValue == 0) { interValue = (resultList1.Max()) / 8; }
                            maxValue = Convert.ToInt32(resultList1.Max());
                            if (x==0)
                            {
                                grafikTool.ChartAreas["ChartArea1"].AxisX.Interval = (resultList1.Max()) / 8;
                            }
                            else
                            {
                                grafikTool.ChartAreas["ChartArea1"].AxisX.Interval = interValue;
                            }
                            
                        }
                        else
                        {
                            for (int i = Int32.Parse(rawSt); i < Int32.Parse(rawF); i++)
                            {
                                DataPoint dp = new DataPoint();
                                dt4.Rows.Add(resultList1[i], resultList2[i]);
                                dp.SetValueXY(resultList2[i], resultList1[i]);

                                grafikTool.Series["Series1"].Points.Add(dp);
                            }

                            grafikTool.ChartAreas["ChartArea1"].AxisY.Title = parName1 + "(" + birim1 + ")" + " Faktör: " + factor1.ToString();
                            grafikTool.ChartAreas["ChartArea1"].AxisX.Title = parName2 + "(" + birim2 + ")" + " Faktör: " + factor2.ToString();

                            firstInterval = (resultList2.Max()) / 8;
                            if (interValue == 0) { interValue = (resultList2.Max()) / 8; }
                            maxValue = Convert.ToInt32(resultList2.Max());
                            grafikTool.ChartAreas["ChartArea1"].AxisX.Interval = interValue;
                        }
                        // grafik özellikleri
                        grafikTool.ChartAreas["ChartArea1"].AxisX.TitleForeColor = Color.Red;
                        grafikTool.ChartAreas["ChartArea1"].AxisY.TitleForeColor = Color.Red;
                        grafikTool.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("myFont", 8, FontStyle.Bold);
                        grafikTool.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("myFont", 8, FontStyle.Bold);
                        grafikTool.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        grafikTool.ChartAreas[0].AxisY.LabelStyle.Format = "";
                        grafikTool.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -45;
                        grafikTool.ChartAreas["ChartArea1"].AxisY.LabelStyle.Angle = -45;

                    }
                       
                    
                   
                }
                else
                {
                    for (int i = 0; i < tryNo; i++)
                    {
                        DataPoint dpp = new DataPoint();
                        dt4.Rows.Add(resultList1[i], resultList2[i]);
                        dpp.SetValueXY(resultList2[i], resultList1[i]);
                        grafikTool.Series["Series1"].Points.Add(dpp);
                    }
                    grafikDraw();
                }

              
            }
           
        }

        void grafikDraw()
        {
            grafikTool.Series["Series1"].Points.Clear();

            if (eksenS==0)
            {


                grafikTool.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("myFont", 8, FontStyle.Bold);
                grafikTool.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("myFont", 8, FontStyle.Bold);

                resultDG.DataSource = dt4;
                //grafikTool.DataSource = dt4;

                if (parChList.CheckedItems.Count>1)
                {
                    for (int i = 0; i < dt4.Rows.Count; i++)
                    {
                        DataPoint dp = new DataPoint();
                        dp.SetValueXY(resultList1[i], resultList2[i]);
                        grafikTool.Series["Series1"].Points.Add(dp);
                    }
                    maxValue = Convert.ToInt32(resultList1.Max());
                    grafikTool.ChartAreas["ChartArea1"].AxisX.Interval = (resultList1.Max())/8;
                } // eksen default 0 ise
                else
                {
                    for (int i = 0; i < dt4.Rows.Count; i++)
                    {
                        DataPoint dp = new DataPoint();
                        dp.SetValueXY(timeList[i], resultList1[i]);
                        grafikTool.Series["Series1"].Points.Add(dp);
                    }
                    maxValue= Convert.ToInt32(timeList.Max());
                    grafikTool.ChartAreas["ChartArea1"].AxisX.Interval = (timeList.Max()) / 8;
                }

                

                //grafikTool.Series["Series1"].XValueMember = "Zaman";
                //grafikTool.Series["Series1"].YValueMembers = "Deger";
                grafikTool.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                grafikTool.ChartAreas[0].AxisY.LabelStyle.Format = "";
                grafikTool.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -45;
                grafikTool.ChartAreas["ChartArea1"].AxisY.LabelStyle.Angle = -45;

                grafikTool.ChartAreas["ChartArea1"].AxisX.TitleForeColor = Color.Red;
                grafikTool.ChartAreas["ChartArea1"].AxisY.TitleForeColor = Color.Red;
               

                if (parChList.CheckedItems.Count >= 2)
                {
                    grafikTool.ChartAreas["ChartArea1"].AxisX.Title = parName1 + "(" + birim1 + ")" + " Faktör: " + factor1.ToString();
                    grafikTool.ChartAreas["ChartArea1"].AxisY.Title = parName2 + "(" + birim2 + ")" + " Faktör: " + factor2.ToString();

                    firstInterval = (resultList1.Max()) / 8;
                    interValue = (resultList1.Max()) / 8;

                   
                    
                }
                else
                {
                    grafikTool.ChartAreas["ChartArea1"].AxisY.Title = parName1 + "(" + birim1 + ")" + " Faktör: " + factor1.ToString();
                    grafikTool.ChartAreas["ChartArea1"].AxisX.Title = "Zaman";

                    firstInterval = (timeList.Max()) / 8;
                    interValue = (timeList.Max()) / 8;
                }
            }
            else
            {
                if (parChList.CheckedItems.Count > 1)
                {
                    for (int i = 0; i < dt4.Rows.Count; i++)
                    {
                        DataPoint dp = new DataPoint();
                        dp.SetValueXY(resultList2[i], resultList1[i]);
                        grafikTool.Series["Series1"].Points.Add(dp);
                    }
                    maxValue= Convert.ToInt32(resultList2.Max());
                    grafikTool.ChartAreas["ChartArea1"].AxisX.Interval = (resultList2.Max()) / 8;
                } //eksen 1 oldu ise
                else
                {
                    for (int i = 0; i < dt4.Rows.Count; i++)
                    {
                        DataPoint dp = new DataPoint();
                        dp.SetValueXY(resultList1[i], timeList[i]);
                        grafikTool.Series["Series1"].Points.Add(dp);
                    }
                    maxValue= Convert.ToInt32(resultList1.Max());
                    grafikTool.ChartAreas["ChartArea1"].AxisX.Interval = (resultList1.Max()) / 8;
                }



                grafikTool.ChartAreas["ChartArea1"].AxisX.TitleForeColor = Color.Red;
                grafikTool.ChartAreas["ChartArea1"].AxisY.TitleForeColor = Color.Red;

                grafikTool.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("myFont", 8, FontStyle.Bold);
                grafikTool.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("myFont", 8, FontStyle.Bold);

                resultDG.DataSource = dt4;
                //grafikTool.DataSource = dt4;
                //grafikTool.Series["Series1"].XValueMember = "Deger";
                //grafikTool.Series["Series1"].YValueMembers = "Zaman";
                grafikTool.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                //grafikTool.ChartAreas[0].AxisY.LabelStyle.Format = "";
                grafikTool.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -45;
                grafikTool.ChartAreas["ChartArea1"].AxisY.LabelStyle.Angle = -45;

                grafikTool.ChartAreas["ChartArea1"].AxisY.Title = parName1 + "(" + birim1 + ")" + " Faktör: " + factor1.ToString();
                if (parChList.CheckedItems.Count >= 2)
                {
                    grafikTool.ChartAreas["ChartArea1"].AxisX.Title = parName2 + "(" + birim2 + ")" + " Faktör: " + factor2.ToString();
                }
                else
                {
                    grafikTool.ChartAreas["ChartArea1"].AxisY.Title = "Zaman";
                }

            }


            zValue = maxValue / 10; // zoom degeri default olarak  Onda bir
           


        }

        void axisChange()
        {
            grafikTool.Series["Series1"].Points.Clear();
            interValue = 0;

            if (chRaw.Checked == true || chTime.Checked == true)
            {
                if (eksenS == 0) { eksenS = 1; } else { eksenS = 0; }
                dt4.Clear();
                grafikFill();
            }
            else { 
            if (eksenS == 0)
            {

                

                grafikTool.ChartAreas["ChartArea1"].AxisX.TitleForeColor = Color.Red;
                grafikTool.ChartAreas["ChartArea1"].AxisY.TitleForeColor = Color.Red;

                grafikTool.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("myFont", 8, FontStyle.Bold);
                grafikTool.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("myFont", 8, FontStyle.Bold);


                if (parChList.CheckedItems.Count > 1)
                {
                    for (int i = 0; i < dt4.Rows.Count; i++)
                    {
                        DataPoint dp = new DataPoint();
                        dp.SetValueXY(resultList2[i], resultList1[i]);
                        grafikTool.Series["Series1"].Points.Add(dp);
                    }
                    grafikTool.ChartAreas["ChartArea1"].AxisX.Interval = (resultList2.Max())/8;
                } // eksen default 0 ise
                else
                {
                    for (int i = 0; i < dt4.Rows.Count; i++)
                    {
                        DataPoint dp = new DataPoint();
                        dp.SetValueXY(resultList1[i], timeList[i]);
                        grafikTool.Series["Series1"].Points.Add(dp);
                    }
                    grafikTool.ChartAreas["ChartArea1"].AxisX.Interval = (resultList1.Max()) / 8;
                }



                resultDG.DataSource = dt4;
                //grafikTool.DataSource = dt4;
                //grafikTool.Series["Series1"].XValueMember = "Zaman";
                //grafikTool.Series["Series1"].YValueMembers = "Deger";
                grafikTool.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                grafikTool.ChartAreas[0].AxisY.LabelStyle.Format = "";
                grafikTool.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -45;
                grafikTool.ChartAreas["ChartArea1"].AxisY.LabelStyle.Angle = -45;
                eksenS = 1;


                
                if (parChList.CheckedItems.Count >= 2)
                {
                    grafikTool.ChartAreas["ChartArea1"].AxisY.Title = parName1 + "(" + birim1 + ")" + " Faktör: " + factor1.ToString();
                    grafikTool.ChartAreas["ChartArea1"].AxisX.Title = parName2 + "(" + birim2 + ")" + " Faktör: "+factor2.ToString();
                }
                else
                {
                    grafikTool.ChartAreas["ChartArea1"].AxisX.Title = parName1 + "(" + birim1 + ")" + " Faktör: " + factor1.ToString();
                    grafikTool.ChartAreas["ChartArea1"].AxisY.Title = "Zaman";
                }

            }
            else
            {
              

                grafikTool.ChartAreas["ChartArea1"].AxisX.TitleForeColor = Color.Red;
                grafikTool.ChartAreas["ChartArea1"].AxisY.TitleForeColor = Color.Red;

                grafikTool.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("myFont", 8, FontStyle.Bold);
                grafikTool.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("myFont", 8, FontStyle.Bold);

                if (parChList.CheckedItems.Count > 1)
                {
                    for (int i = 0; i < dt4.Rows.Count; i++)
                    {
                        DataPoint dp = new DataPoint();
                        dp.SetValueXY(resultList1[i], resultList2[i]);
                        grafikTool.Series["Series1"].Points.Add(dp);
                    }
                    grafikTool.ChartAreas["ChartArea1"].AxisX.Interval = (resultList1.Max()) / 8;
                } // eksen default 0 ise
                else
                {
                    for (int i = 0; i < dt4.Rows.Count; i++)
                    {
                        DataPoint dp = new DataPoint();
                        dp.SetValueXY(timeList[i], resultList1[i]);
                        grafikTool.Series["Series1"].Points.Add(dp);
                    }
                    grafikTool.ChartAreas["ChartArea1"].AxisX.Interval = (timeList.Max()) / 8;
                }


                resultDG.DataSource = dt4;
                //grafikTool.DataSource = filter.dt4;
                //grafikTool.Series["Series1"].XValueMember = "Deger";
                //grafikTool.Series["Series1"].YValueMembers = "Zaman";
                grafikTool.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                grafikTool.ChartAreas[0].AxisY.LabelStyle.Format = "";
                grafikTool.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -45;
                grafikTool.ChartAreas["ChartArea1"].AxisY.LabelStyle.Angle = -45;
                eksenS = 0;

               
                if (parChList.CheckedItems.Count >= 2)
                {
                    grafikTool.ChartAreas["ChartArea1"].AxisX.Title = parName1 + "(" + birim1 + ")" + " Faktör: " + factor1.ToString();
                    grafikTool.ChartAreas["ChartArea1"].AxisY.Title = parName2 + "(" + birim2 + ")" + " Faktör: " + factor2.ToString();
                }
                else
                {
                    grafikTool.ChartAreas["ChartArea1"].AxisY.Title = parName1 + "(" + birim1 + ")" + " Faktör: " + factor1.ToString();
                    grafikTool.ChartAreas["ChartArea1"].AxisX.Title = "Zaman";
                }


            }
            }




        }

        void timeRaWrite()
        {
            //status ve değişkenleri yazma
            if (chTime.Checked = true)
            {
                timeS = "1";
                timeSt = txtZamBas.Text.Trim();
                timeF = txtZamBit.Text.Trim();
            }
            else
            {
                timeS = "0";
                timeS = "";
                timeF = "";
            }
            if (chRaw.Checked=true)
            {
                rawS = "1";
                rawSt = txtSatBas.Text.Trim();
                rawF = txtSatBit.Text.Trim();
            }
            else
            {
                rawS = "0";

                rawSt = "";
                rawF = "";
            }
        }

        void timeRawRead()
        {
            //status ve değişkenleri yazma
            if (timeS=="1")
            {
                chTime.Checked = true;
                txtZamBas.Enabled = true;
                txtZamBit.Enabled = true;
                txtZamBas.Text = timeSt;
                txtZamBit.Text = timeF;
            }
            else
            {
                chTime.Checked = false;
                txtZamBas.Enabled = false;
                txtZamBit.Enabled = false;
                txtZamBas.Text = "";
                txtZamBit.Text = "";
            }

            if (rawS == "1")
            {
                chRaw.Checked = true;
                txtSatBas.Enabled = true;
                txtSatBit.Enabled = true;
                txtSatBas.Text = rawSt;
                txtSatBit.Text = rawF;
            }
            else
            {
                chRaw.Checked = false;
                txtSatBas.Enabled = false;
                txtSatBit.Enabled = false;
                txtSatBas.Text = "";
                txtSatBit.Text = "";
            }
        }

        void selectedProRead()
        {

           
            string[] genelAyar = profile_raw[profilIndex+1].Split(','); // genel ayar satırı yazıldı
            rawS = genelAyar[0];
            rawSt = genelAyar[1];
            rawF = genelAyar[2];
            timeS = genelAyar[3];
            timeSt = genelAyar[4];
            timeF = genelAyar[5];

            proParNo = 0;

            for (int i = profilIndex+2; i < profile_raw.Count; i++)
            {
               

                    if (profile_raw[i] == "---" || profile_raw[i] == "END")
                    {
                        break;
                    }
                    parametersL.Add(profile_raw[i]);

                proParNo++;
            }  


        }
        void profileRead()
        {

            if (System.IO.File.Exists(Application.StartupPath.ToString() + "\\profil.txt"))
            {
            }
            else
            {
                
                
                using (StreamWriter sw = File.CreateText(Application.StartupPath.ToString() + "\\profil.txt"))
                {
                    sw.WriteLine("---");
                    sw.WriteLine("PROFIL");
                    sw.WriteLine("0,0,0,0,0,0");
                    sw.WriteLine("END");

                    
                }
            }
            exeFileWay = Application.StartupPath.ToString() + "\\profil.txt";
           string[] profilDizi = System.IO.File.ReadAllLines(exeFileWay);
            profile_raw = profilDizi.ToList();

            for (int i = 0; i < profile_raw.Count; i++)
            {
                if (profile_raw[i]=="---")
                {
                    profilNames.Add(profile_raw[i + 1]);
                }
            }

           
          
        }

        void newProfile()
        {
            profile_raw.RemoveAt(profile_raw.Count - 1); // END SİLME

            //uygulama konumu alma ve yol yazma
            exeFileWay = Application.StartupPath.ToString() + "\\profil.txt";
            //  File.WriteAllText(exeFileWay, null); // txt içini temizleme

            FileStream fs = new FileStream(exeFileWay, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            profile_raw.Add("---");
            profile_raw.Add(profilNames[profilNames.Count - 1]);
            profile_raw.Add(rawS.ToString() + "," + rawSt.ToString() + "," + rawF.ToString() + "," + timeS.ToString() + "," + timeSt.ToString() + "," + timeF);

            for (int i = 0; i < parametersL.Count; i++)
            {
                profile_raw.Add(parametersL[i]);
            }

            profile_raw.Add("END");

            for (int i = 0; i < profile_raw.Count; i++)
            {
                sw.WriteLine(profile_raw[i]);
            }

            sw.Flush();
            sw.Close();
            fs.Close();
        }

        void profileWrite()
        {

            //uygulama konumu alma ve yol yazma
            exeFileWay = Application.StartupPath.ToString() + "\\profil.txt";
           File.WriteAllText(exeFileWay, null); // txt içini temizleme

            FileStream fs = new FileStream(exeFileWay, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
           
            for (int i = 0; i < profilIndex; i++) // profil öncesi bölümü alma --- hariç
            {
                sw.WriteLine(profile_raw[i]);
                
            }


            if (profile_raw[profilIndex + 1 + proParNo +1]!="END") // kaydolacak profil son blokta değil ise devam et
            {
                for (int i = profilIndex + 1 + proParNo + 1 +1; i < profile_raw.Count - 1; i++) // profil sonrası bölüm END HARİÇ
                {
                    sw.WriteLine(profile_raw[i]);
                }
                sw.WriteLine("---");
            }
            
            
            sw.WriteLine(cbProfil.SelectedItem.ToString());
            if (chRaw.Checked==true)
            {
                rawS = "1";
            }
            else
            {
                rawS = "0";
            }
            if (chTime.Checked==true)
            {
                timeS = "1";
            }
            else
            {
                timeS = "0";
            }
            if (txtSatBas.Text.Trim() != "") { rawSt = txtSatBas.Text.Trim(); } else { rawSt = "0"; }
            if (txtSatBit.Text.Trim() != "") { rawF = txtSatBit.Text.Trim(); } else { rawF = "0"; }
            if (txtZamBas.Text.Trim() != "") { timeSt = txtZamBas.Text.Trim(); } else { timeSt = "0"; }
            if (txtZamBit.Text.Trim() != "") { timeF = txtZamBit.Text.Trim(); } else { timeF = "0"; }






            sw.WriteLine(rawS.ToString() + "," + rawSt + "," + rawF + "," + timeS.ToString() + "," + timeSt + "," + timeF);

            for (int i = 0; i < parametersL.Count; i++)
            {
                sw.WriteLine(parametersL[i]);
            }

            sw.WriteLine("END");
            sw.Flush(); // metin dosyasına yazma
            sw.Close();
            fs.Close();
        }
        void parWrite()
        {
            if (parChList.CheckedItems.Count==0 || parChList.CheckedItems.Count>2)
            {
                MessageBox.Show("Lütfen bir veya iki parametre seçiniz!");
            }
            else
            {
                if (parChList.CheckedItems.Count == 1)
                {
                    pSelected = parChList.CheckedItems[0].ToString().Split(',');

                    parName1 = pSelected[0];
                    parID1 = pSelected[1];
                    parSt1 = Int32.Parse(pSelected[2]);
                    parStBit1 = Int32.Parse(pSelected[3]);
                    parLt1 = Int32.Parse(pSelected[4]);
                    parLtBit1 = Int32.Parse(pSelected[5]);
                    parS1 = pSelected[6];
                    factor1 = Double.Parse(pSelected[7].Replace('.',','));
                    birim1 = pSelected[8];

                    timeSt = txtZamBas.Text.Trim();
                    timeF = txtZamBit.Text.Trim();

                    rawS = "0";

                    resultDG.Columns[0].HeaderText = pSelected[0] +"("+birim1+")";
                    resultDG.Columns[1].HeaderText = "Zaman";
                    search();
                }
                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (i == 0)
                        {
                            pSelected = parChList.CheckedItems[0].ToString().Split(',');

                            parName1 = pSelected[0];
                            parID1 = pSelected[1];
                            parSt1 = Int32.Parse(pSelected[2]);
                            parStBit1 = Int32.Parse(pSelected[3]);
                            parLt1 = Int32.Parse(pSelected[4]);
                            parLtBit1 = Int32.Parse(pSelected[5]);
                            parS1 = pSelected[6];
                            factor1 = Double.Parse(pSelected[7].Replace('.',','));
                            birim1 = pSelected[8];

                            resultDG.Columns[0].HeaderText = pSelected[0]+"("+birim1+")";
                        }

                        if (i == 1)
                        {
                            pSelected = parChList.CheckedItems[1].ToString().Split(',');

                            parName2 = pSelected[0];
                            parID2 = pSelected[1];
                            parSt2 = Int32.Parse(pSelected[2]);
                            parStBit2 = Int32.Parse(pSelected[3]);
                            parLt2 = Int32.Parse(pSelected[4]);
                            parLtBit2 = Int32.Parse(pSelected[5]);
                            parS2 = pSelected[6];
                            factor2 = Double.Parse(pSelected[7].Replace('.',','));
                            birim2 = pSelected[8];

                            resultDG.Columns[1].HeaderText = pSelected[0]+"("+birim2+")";
                        }

                        if (chRaw.Checked==true)
                        {
                            rawS = "1";
                        }
                        rawSt = txtSatBas.Text.Trim();
                        rawF = txtSatBit.Text.Trim();

                        timeS = "0";
                    }
                   
                   
                    search();
                }
            }
           
            
        }

      public  void refreshPar()
        {
            parChList.Items.Clear();

            foreach (var item in parametersL)
            {
                parChList.Items.Add(item);
            }
        }

        void loadFile()
        {
            if (fileWay != null && fileWay !="")
            {
                progBar.Value = 0;
                uploadFile();
            }
            else
            {
                MessageBox.Show("Lütfen dosya yükleyiniz!");
            }
        }

        void save()
        {
            // zaman kaydetmek için

        }
    }
}
