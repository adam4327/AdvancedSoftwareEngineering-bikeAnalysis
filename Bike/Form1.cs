using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Bike
{
    public partial class Form1 : Form
    {
        // hr data
        int maxhr, maxp, maxa = 0;
        double maxs = 0;
        int minhr = 1000000;
        int count = 0;

        double sumHR, sumSpeed, sumAltitude, sumPower;
        double averageHeartRate, averageSpeed, averageAltitude, averagePower;
        double maxSpeed;
        double convertHR, convertSpeed, convertCadence, convertAltitude, convertPower;

        string heartRate, time, speed, cadence, altitude, power, powerBalanceAndPedallingIndex;

        //Times
        char[] characters;
        double timeInterval;

        //Dates
        string theDate;
        DateTime theStartTime;
        DateTime dt;
        TimeSpan theLength;

        //Labels
        string maxSpeedLabel = "";

        GraphPane pane;
        PointPairList heartRateArray = new PointPairList();
        PointPairList speedArray = new PointPairList();
        PointPairList altitudeArray = new PointPairList();  
        PointPairList powerArray = new PointPairList();
        PointPairList cadenceArray = new PointPairList();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {Application.Exit();}
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "f:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {

                            string filename = openFileDialog1.FileName;
                            string[] lines = File.ReadAllLines(filename);

                            for (int i = 0; i < lines.Length; i++)
                            {
                                string splitLine = lines[i];

                                //find the date
                                if (splitLine.Contains("Date"))
                                {
                                    string[] splitTitle = lines[i].Split('=');
                                    theDate = splitTitle[1];
                                }


                                //find the start time
                                if (splitLine.Contains("StartTime"))
                                {
                                    string[] splitTitle = lines[i].Split('=');
                                    StartTime.Text = splitTitle[1]; //label name

                                    theStartTime = new DateTime(
                                        Int32.Parse(theDate.Substring(0, 4)), // year
                                        Int32.Parse(theDate.Substring(4, 2)), // month
                                        Int32.Parse(theDate.Substring(6, 2)), // day
                                        Int32.Parse(splitTitle[1].Substring(0, 2)), // hours
                                        Int32.Parse(splitTitle[1].Substring(3, 2)), // minutes
                                        Int32.Parse(splitTitle[1].Substring(6, 2)), // seconds
                                        (Int32.Parse(splitTitle[1].Substring(9, 1))*100) // milliseconds 
                                    );

                                    Date.Text = theStartTime.ToString("dd/MM/yyyy"); //label name
                                }


                                //find the interval
                                if (splitLine.Contains("Interval"))
                                {
                                    string[] splitTitle = lines[i].Split('=');
                                    timeInterval = Double.Parse(splitTitle[1]);
                                    Interval.Text = timeInterval.ToString(); //label name
                                }


                                if (splitLine.Contains("Length"))
                                {
                                    string[] splitTitle = lines[i].Split('=');
                                    string time = splitTitle[1]; //label name

                                    theLength = new TimeSpan(
                                        0, // day
                                        Int32.Parse(splitTitle[1].Substring(0, 2)), // hours
                                        Int32.Parse(splitTitle[1].Substring(3, 2)), // minutes
                                        Int32.Parse(splitTitle[1].Substring(6, 2)), // seconds
                                        (Int32.Parse(splitTitle[1].Substring(9, 1)) * 100) // milliseconds 
                                    );
                                }

                                if (splitLine.Contains("SMode"))
                                {
                                    string[] splitTitle = lines[i].Split('=');
                                    string smode = splitTitle[1]; //label name
                                    characters = smode.ToCharArray();
                                }


                                if (splitLine.Contains("[HRData]"))
                                {

                                    


                                    

                                }
                            }

                            // ZedGraph generate pane

                            

                           

                        }
                    }
                }
                
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Unable to open file. Original error: " + ex.Message);
                }
            }
        }



      


    }
}
