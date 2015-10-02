using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Drawing;

namespace PLMNFCQueuingApp
{
    public partial class Form1 : Form
    {
        Color colorTrans = Color.Transparent;
        Color colGreen = System.Drawing.ColorTranslator.FromHtml("#1e4200");
        
        string conect = String.Empty;
        DateTime last_update = new DateTime();
        //-----Database Connection               
    
        int retCode;
        int hCard;
        int hContext;
        int Protocol;
        public bool connActive = false;
        string readername = "ACS ACR122 0";      // change depending on reader
        public byte[] SendBuff = new byte[263];
        public byte[] RecvBuff = new byte[263];
        public int SendLen, RecvLen, nBytesRet, reqType, Aprotocol, dwProtocol, cbPciLength;
        public ModWinsCard.SCARD_READERSTATE RdrState;
        public ModWinsCard.SCARD_IO_REQUEST pioSendRequest;
        //-----NFC Declarations

        SoundPlayer simpleSound = new SoundPlayer(@"C:\Program Files\PLMNFCQueuingApp\PLMNFCQueuingApp\WarningSiren.wav");
         

        private void Form1_Load(object sender, EventArgs e)
        {
            lblSmartcardStatus.Hide();
            simpleSound.Stop();
            lblDate.Text = System.DateTime.Now.ToLongDateString();
            lblLongTime.Text = System.DateTime.Now.ToLongTimeString();
            label1.Text = " ";
            label2.Text = " ";
            label3.Text = " ";
            label4.Text = " ";

            tbRemarks.BackColor = colGreen;
        
        }//formLoad

        //Declarations
        public Form1()
        {
            InitializeComponent();
            Connection connect = new Connection();
            conect = connect.ConnectionString;
            
            //---------textboxinit
            string strCurrentText = "--------";
            textBox1.Text = strCurrentText;
            pictureBox1.Image = null;
            //Device Connection Establishment
            SelectDevice();
            establishContext();
            //view();
            newView();
            retainLabelValues();
            trackAndCountViolation();
            trackViolationMemo();
           // insertLabelValues();
            
            //init reader
            this.RdrState = new ModWinsCard.SCARD_READERSTATE();

            timer3.Stop();
        }

        void newView()
        //=============================================================//
        //========    Views Student Info then feeds to label   ========//
        //=============================================================//
        {
            SqlConnection con = new SqlConnection(conect);
            try
            {
                string strQuery = "SELECT STUDENT.Student_Id as [Student No], STUDENT.Student_FName + ' ' + STUDENT.Student_LName as [--Full Name--], COLLEGE.College_Name as [--College Name--], COURSE.Course_Abbrev as [Course Abbrev],SMARTCARD.Smartcard_UID, STUDENT.Student_Image FROM STUDENT, COLLEGE, COURSE, SMARTCARD WHERE STUDENT.College_Id = COLLEGE.College_Id AND COURSE.Course_ID = STUDENT.Course_ID AND STUDENT.Smartcard_UID = SMARTCARD.Smartcard_UID AND SMARTCARD.Smartcard_Status = 'Activated' AND SMARTCARD.Smartcard_UID='" + textBox1.Text + "'"; //change to textbox
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand cmd = new SqlCommand(strQuery, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                if(rdr.HasRows)
                {
                    label1.Text = rdr[0].ToString();
                    label2.Text = rdr[1].ToString();
                    label3.Text = rdr[2].ToString();
                    label4.Text = rdr[3].ToString();
                    lblStudSmartCardUID.Text = rdr[4].ToString();
                    byte[] img = (byte[])(rdr[5]);
                    if (img == null)
                        pictureBox1.Image = null;
                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                    con.Close();
                }//if
                
            }//try

            catch(Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message);
            }
        }

        void view()
        //=============================================================//
        //===========    Obsolete Viewing Function   ==================//
        //=============================================================//
        {
            SqlConnection con = new SqlConnection(conect);
            con.Open();
            try
            {
                string strQuery = "SELECT STUDENT.Student_Id as [Student No], STUDENT.Student_FName + ' ' + STUDENT.Student_LName as [--Full Name--], COLLEGE.College_Name as [--College Name--], COURSE.Course_Abbrev as [Course Abbrev],SMARTCARD.Smartcard_UID, STUDENT.Student_Image FROM STUDENT, COLLEGE, COURSE, SMARTCARD WHERE STUDENT.College_Id = COLLEGE.College_Id AND COURSE.Course_ID = STUDENT.Course_ID AND STUDENT.Smartcard_UID = SMARTCARD.Smartcard_UID AND SMARTCARD.Smartcard_UID='" + textBox1.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(strQuery, con);
                DataTable ds = new DataTable();
                da.Fill(ds);
                label1.Text = ds.Rows[0][0].ToString();
                label2.Text = ds.Rows[0][1].ToString();
                label3.Text = ds.Rows[0][2].ToString();
                label4.Text = ds.Rows[0][3].ToString();
                
                lblStudSmartCardUID.Text = ds.Rows[0][4].ToString();
                con.Close();
            }
            catch (IndexOutOfRangeException ie)
            {
                MessageBox.Show(ie.GetBaseException().Message);
            }
        }

        void retainLabelValues()
        //=============================================================//
        //== Retain Label Values to be used in Log details insertion ==//
        //=============================================================//
        {
            SqlConnection con = new SqlConnection(conect);
            try
            {
                string strQuery = "SELECT STUDENT.Student_Id as [Student No], STUDENT.Student_FName + ' ' + STUDENT.Student_LName as [--Full Name--], COLLEGE.College_Name as [--College Name--], COURSE.Course_Abbrev as [Course Abbrev],SMARTCARD.Smartcard_UID, STUDENT.Student_Image FROM STUDENT, COLLEGE, COURSE, SMARTCARD WHERE STUDENT.College_Id = COLLEGE.College_Id AND COURSE.Course_ID = STUDENT.Course_ID AND STUDENT.Smartcard_UID = SMARTCARD.Smartcard_UID AND SMARTCARD.Smartcard_Status = 'Activated' AND SMARTCARD.Smartcard_UID='" + textBox1.Text + "'"; //change to textbox
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand cmd = new SqlCommand(strQuery, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();


                if (rdr.HasRows)
                {
                    violationCounter.Show();
                    lblPendingViolation.Show();
                    lblSmartcardStatus.Show();
                    lblSmartcardStatus.ForeColor = Color.Green;
                    lblSmartcardStatus.Text = "Student have logged in!";

                    label1.Text = rdr[0].ToString();
                    label2.Text = rdr[1].ToString();
                    label3.Text = rdr[2].ToString();
                    label4.Text = rdr[3].ToString();
                    lblStudSmartCardUID.Text = rdr[4].ToString();
                    byte[] img = (byte[])(rdr[5]);
                    if (img == null)
                        pictureBox1.Image = null;
                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        pictureBox1.Image = Image.FromStream(ms);
                    }

                    simpleSound.Stop();
                    insertLabelValues();
                    
                    //resetFields();
                            
                    con.Close();
                }//if


                else if (!rdr.HasRows)
                {
                    resetFields();
                    lblSmartcardStatus.Hide();
                    //lblSmartcardStatus.ForeColor = Color.Red;
                    label1.Text = "Smartcard not yet registered/invalid!";
                    if (label1.Text == "Smartcard not yet registered/invalid!")
                    {
                        simpleSound.Play();
                        violationCounter.Hide();
                        lblPendingViolation.Hide();
                    }

                    con.Close();
                }//
            }//try
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message);
            }
        }

        void trackViolationMemo()
        {
            SqlConnection con = new SqlConnection(conect);
            try
            {
                string strQuery = "SELECT Violation_Memo_From, Violation_Remarks FROM VIOLATIONMEMO WHERE Violation_Status = 'Active' AND Student_ID = '" + label1.Text + "'"; //change to textbox
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand cmd = new SqlCommand(strQuery, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                if (rdr.HasRows)
                {
                    lblFrom.Text = "";
                    tbRemarks.Text = "";
                    lblFrom.Text = "FROM : " + rdr[0].ToString();
                    tbRemarks.Text = rdr[1].ToString();
                    con.Close();
                }//if
                else if (!rdr.HasRows)
                {
                    lblFrom.Text = "";
                    tbRemarks.Text = "";
                }
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message);
            }

        }
        void trackAndCountViolation()
        //=======================================================================================//
        //== Method that will count pending violation of student (If there is or there is none ==//
        //=======================================================================================//
        {
            SqlConnection con = new SqlConnection(conect);
            try
            {
                string strQuery = "SELECT COUNT(DISTINCT Violation_ID) AS [NUMBER OF VIOLATIONS] FROM VIOLATION WHERE Violation_Status = 'Unsettled' AND Student_ID = '" + label1.Text + "'"; //change to textbox
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand cmd = new SqlCommand(strQuery, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();


                if (rdr.HasRows)
                {
                    int violationCtrParse = Int32.Parse(rdr[0].ToString());
                    if (violationCtrParse.Equals(0))
                    {
                        violationCounter.ForeColor = Color.Green;
                        violationCounter.Text = violationCtrParse.ToString();
                    }

                    if (violationCtrParse != 0)
                    {
                        violationCounter.ForeColor = Color.Red;
                        violationCounter.Text = violationCtrParse.ToString();
                        //violationCounter.Text = rdr[0].ToString();
                    }
                }
                else if (lblSmartcardStatus.Text == "Smartcard not yet registered/invalid!")
                {
                    violationCounter.Hide();
                    lblPendingViolation.Hide();
                }

                    con.Close();
            }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.GetBaseException().Message);
            }
        }



        void insertLabelValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(conect);
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand insertStudCMD = new SqlCommand("INSERT INTO SMARTCARDLOGS(Student_ID, Student_FullName, Smartcard_UID, LogDate) VALUES (@STUDNO, @FULLNAME, @SMARTCARD, @DATE)", con);
                insertStudCMD.Parameters.AddWithValue("@STUDNO", label1.Text);
                insertStudCMD.Parameters.AddWithValue("@FULLNAME", label2.Text);
                insertStudCMD.Parameters.AddWithValue("@SMARTCARD", lblStudSmartCardUID.Text);
                insertStudCMD.Parameters.AddWithValue("@DATE", DateTime.Now);
                int ctr = insertStudCMD.ExecuteNonQuery();
               // MessageBox.Show(ctr.ToString() + " record(s) saved");
               //timer1.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message);
                //Catch here 
            }
        }

        

        void resetFields()
        {
            label1.Text = " ";
            label2.Text = " ";
            label3.Text = " ";
            label4.Text = " ";
            pictureBox1.Image = null;
            violationCounter.Hide();
            lblPendingViolation.Hide();

        }

        public void SelectDevice()
        {
            List<string> availableReaders = this.ListReaders();
            this.RdrState = new ModWinsCard.SCARD_READERSTATE();
            readername = availableReaders[0].ToString();//selecting first device
            this.RdrState.RdrName = readername;
        }//
        public List<string> ListReaders()

        {
            int ReaderCount = 0;
            List<string> AvailableReaderList = new List<string>();

            //Make sure a context has been established before 
            //retrieving the list of smartcard readers.
            retCode = ModWinsCard.SCardListReaders(hContext, null, null, ref ReaderCount);
            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                MessageBox.Show(ModWinsCard.GetScardErrMsg(retCode));
                //connActive = false;
            }

            byte[] ReadersList = new byte[ReaderCount];

            //Get the list of reader present again but this time add sReaderGroup, retData as 2rd & 3rd parameter respectively.
            retCode = ModWinsCard.SCardListReaders(hContext, null, ReadersList, ref ReaderCount);
            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                MessageBox.Show(ModWinsCard.GetScardErrMsg(retCode));
            }

            string rName = "";
            int indx = 0;
            if (ReaderCount > 0)
            {
                // Convert reader buffer to string
                while (ReadersList[indx] != 0)
                {

                    while (ReadersList[indx] != 0)
                    {
                        rName = rName + (char)ReadersList[indx];
                        indx = indx + 1;
                    }

                    //Add reader name to list
                    AvailableReaderList.Add(rName);
                    rName = "";
                    indx = indx + 1;
                }
            }
            return AvailableReaderList;
        }

        internal void establishContext()
        {
            retCode = ModWinsCard.SCardEstablishContext(ModWinsCard.SCARD_SCOPE_SYSTEM, 0, 0, ref hContext);
            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                MessageBox.Show("Check your device and please restart again", "Reader not connected");
                connActive = false;
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (connectCard())
            {
                //---------textboxinit
                string strCurrentText = "--------";
                textBox1.Text = strCurrentText;
                string cardUID = getcardUID();
                textBox1.Text = cardUID; //displaying on text block
                //view();
                newView();
                retainLabelValues();
                trackAndCountViolation();
                trackViolationMemo();
                //insertLabelValues();
                //timer1.Start();
                timer1.Stop();
                timer3.Start();
                
            }
            else
            {
                //resetFields();
               // insertLabelValues();
            }
        }

        private void thread3Implement(Object sender, EventArgs e) {
            if (!connectCard()) 
            {
                timer3.Stop();
                timer1.Start();
            }
        }

        public bool connectCard()
        {
            connActive = true;

            retCode = ModWinsCard.SCardConnect(hContext, readername, ModWinsCard.SCARD_SHARE_SHARED,
                      ModWinsCard.SCARD_PROTOCOL_T0 | ModWinsCard.SCARD_PROTOCOL_T1, ref hCard, ref Protocol);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
               // MessageBox.Show(ModWinsCard.GetScardErrMsg(retCode), "Card not available");
                textBox1.Text = "--------";
                connActive = false;
                return false;
            } 
            return true;
        }

        private string getcardUID()//only for mifare 1k cards
        {
            string cardUID = "";
            byte[] receivedUID = new byte[256];
            ModWinsCard.SCARD_IO_REQUEST request = new ModWinsCard.SCARD_IO_REQUEST();
            request.dwProtocol = ModWinsCard.SCARD_PROTOCOL_T1;
            request.cbPciLength = System.Runtime.InteropServices.Marshal.SizeOf(typeof(ModWinsCard.SCARD_IO_REQUEST));
            byte[] sendBytes = new byte[] { 0xFF, 0xCA, 0x00, 0x00, 0x00 }; //get UID command      for Mifare cards
            int outBytes = receivedUID.Length;
            int status = ModWinsCard.SCardTransmit(hCard, ref request, ref sendBytes[0], sendBytes.Length, ref request, ref receivedUID[0], ref outBytes);

            if (status != ModWinsCard.SCARD_S_SUCCESS)
            {
                //cardUID = "Error";

            }
            else
            {
                cardUID = BitConverter.ToString(receivedUID.Take(4).ToArray()).Replace("-", string.Empty).ToLower();
            }
            return cardUID;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1_Click(sender, e);
           // insertLabelValues();
            
            //switch (RdrState.RdrCurrState) {
            //    case ModWinsCard.SCARD_ABSENT: break;
            //    case ModWinsCard.SCARD_PRESENT: break;
            //}

            //this.RdrState = new ModWinsCard.SCARD_READERSTATE();
            //richTextBox1.Text = richTextBox1.Text + RdrState.RdrCurrState + RdrState.RdrEventState + "\n";


            
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            thread3Implement(sender, e);
        }

        private int getCardState() {
            connActive = true;

            retCode = ModWinsCard.SCardConnect(hContext, readername, ModWinsCard.SCARD_SHARE_SHARED,
                      ModWinsCard.SCARD_PROTOCOL_T0 | ModWinsCard.SCARD_PROTOCOL_T1, ref hCard, ref Protocol);

            //retCode = ModWinsCard.SCardState();

            return retCode;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblLongTime.Text = System.DateTime.Now.ToLongTimeString();
        }//Dynamic Time Function

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void lblStudSmartCardUID_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbRemarks_TextChanged(object sender, EventArgs e)
        {

        }
       
   }//Form
}//namespace

