using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using SpeechLib;
using System.IO;
using System.IO.Ports;



namespace ivrs
{
    public partial class Form1 : Form
    {
        int read;
        string con = @"Data Source=rags-PC\SQLEXPRESS;Initial Catalog=stud;Integrated Security=True";
        SqlConnection co;
        SqlCommand cmd;
        SqlDataReader dr;
        
       
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
                // serial port setup
                SerialPort myport = new SerialPort();
                myport.PortName = "COM20";
                myport.BaudRate = 9600;
                myport.DataBits = 8;
                myport.Parity = Parity.None;
                myport.StopBits = StopBits.One;
                myport.Open();
            
                SpVoice objspeech = new SpVoice();
                //WELCOME
                objspeech.Rate = -3;
                objspeech.Speak("WELCOME TO COLL BASE VERSION 1.0", SpeechVoiceSpeakFlags.SVSFlagsAsync);
                objspeech.WaitUntilDone(msTimeout: 10000);
                
                objspeech.Speak("ENTER YOUR REGISTER NUMBER AFTER THE BEEP", SpeechVoiceSpeakFlags.SVSFlagsAsync);
                objspeech.WaitUntilDone(msTimeout: 10000);
            
                //BEEP
                objspeech.Speak("BEEP", SpeechVoiceSpeakFlags.SVSFlagsAsync);
                objspeech.WaitUntilDone(msTimeout: 10); 

                //delay
                System.Threading.Thread.Sleep(3000);
                read = myport.ReadChar();
                read = Convert.ToInt32(read);
                read = read - 48;
                myport.Close();

                label2.Text = read.ToString();

                string query = "select * from Table1 where REGNO = '" + label2.Text + "'";
                co = new SqlConnection(con);
                co.Open();
                cmd = new SqlCommand(query, co);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    label4.Text = dr["NAME"].ToString();
                    label8.Text = dr["EC1101"].ToString();
                    label10.Text = dr["EC1102"].ToString();
                    label12.Text = dr["EC1103"].ToString();
                    label14.Text = dr["EC1104"].ToString();
                    label16.Text = dr["EC1105"].ToString();
                    label18.Text = dr["EC1106"].ToString();
                }
                co.Close();

                System.Threading.Thread.Sleep(1000);
                objspeech.Speak("YOUR NUMBER AND NAME IS", SpeechVoiceSpeakFlags.SVSFlagsAsync);
                objspeech.WaitUntilDone(msTimeout: 10);
                objspeech.Speak(label2.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
                objspeech.WaitUntilDone(msTimeout: 10);
                objspeech.Speak(label4.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
                objspeech.WaitUntilDone(msTimeout: 10);

                objspeech.Speak("YOUR MARKS IN THIS SUBJECT ARE", SpeechVoiceSpeakFlags.SVSFlagsAsync);
                objspeech.WaitUntilDone(msTimeout: 10);

                objspeech.Speak(label9.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
                objspeech.WaitUntilDone(msTimeout: 10);
                objspeech.Speak(label8.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
                objspeech.WaitUntilDone(msTimeout: 10);

                objspeech.Speak(label11.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
                objspeech.WaitUntilDone(msTimeout: 10);
                objspeech.Speak(label10.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
                objspeech.WaitUntilDone(msTimeout: 10);

                objspeech.Speak(label13.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
                objspeech.WaitUntilDone(msTimeout: 10);
                objspeech.Speak(label12.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
                objspeech.WaitUntilDone(msTimeout: 10);

                objspeech.Speak(label15.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
                objspeech.WaitUntilDone(msTimeout: 10);
                objspeech.Speak(label14.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
                objspeech.WaitUntilDone(msTimeout: 10);

                objspeech.Speak(label17.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
                objspeech.WaitUntilDone(msTimeout: 10);
                objspeech.Speak(label16.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
                objspeech.WaitUntilDone(msTimeout: 10);

                objspeech.Speak(label19.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
                objspeech.WaitUntilDone(msTimeout: 10);
                objspeech.Speak(label18.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
                objspeech.WaitUntilDone(msTimeout: 10);


                objspeech.Speak("Thank you for using COLL BASE VERSION 1.0 , have a nice day", SpeechVoiceSpeakFlags.SVSFlagsAsync);
                objspeech.WaitUntilDone(msTimeout: 10);

  }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
