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

                                    averageHeartRate = sumHR;
                                    averageSpeed = sumSpeed;
                                    averageAltitude = sumAltitude;
                                    averagePower = sumPower;
                                    int counter = 0;

                                    //finds the line number of HRData then reads the rest of the file after that
                                    for (int a = (i + 1); a < lines.Length; a++)
                                    {
                                        //split lines after the title [HRData]
                                        string splitA = lines[a];
                                        string[] splitTabs = splitA.Split('\t'); //split tabs

                                        dt = theStartTime.AddMilliseconds((timeInterval * counter) * 1000);

                                        time = dt.ToString("HH:mm:ss.f");
                                        double axisTime = (double)new XDate(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
                                        counter++;

                                        //split the catergories
                                        heartRate = splitTabs[0];
                                        speed = splitTabs[1];
                                        cadence = splitTabs[2];
                                        altitude = splitTabs[3];
                                        power = splitTabs[4];
                                        powerBalanceAndPedallingIndex = splitTabs[5];

                                        //covert string array to integers
                                        convertHR = Convert.ToInt32(splitTabs[0]);
                                        convertSpeed = Convert.ToInt32(splitTabs[1]);
                                        convertCadence = Convert.ToInt32(splitTabs[2]);
                                        convertAltitude = Convert.ToInt32(splitTabs[3]);
                                        convertPower = Convert.ToInt32(splitTabs[4]);

                                        //sum all of the arrays
                                        sumHR += (convertHR);
                                        sumSpeed += (convertSpeed);
                                        sumAltitude += (convertAltitude);
                                        sumPower += (convertPower);
                                        count++;

                                        // Find the min/max values
                                        //HR
                                        int maxHeartRate = Int32.Parse(heartRate);
                                        int minHeartRate = Int32.Parse(heartRate);

                                        if (maxHeartRate > maxhr)
                                        { maxhr = maxHeartRate; }

                                        if (minHeartRate < minhr)
                                        { minhr = minHeartRate; }

                                        // speed
                                        maxSpeed = Int32.Parse(speed);
                                        if (maxSpeed > maxs)
                                        { maxs = maxSpeed; }

                                        // power
                                        int maxPower = Int32.Parse(power);
                                        if (maxPower > maxp)
                                        { maxp = maxPower; }

                                        // altitude
                                        int maxAltitude = Int32.Parse(altitude);
                                        if (maxAltitude > maxa)
                                        { maxa = maxAltitude; }

                                        // Data Table
                                        this.dataGridView1.Rows.Add(time, heartRate, speed, cadence, altitude, power, powerBalanceAndPedallingIndex);

                                        
                                        // speed
                                        if (characters[0] == '0')
                                        {
                                            this.dataGridView1.Columns[2].Visible = false;
                                        }

                                        // cadence
                                        if (characters[1] == '0')
                                        {
                                            this.dataGridView1.Columns[3].Visible = false;
                                        }
                                        
                                        // Altitude
                                        if (characters[2] == '0')
                                        {
                                            this.dataGridView1.Columns[4].Visible = false;
                                        }

                                        // Power
                                        if (characters[3] == '0')
                                        {
                                            this.dataGridView1.Columns[5].Visible = false;
                                        }

                                        /*
                                        // power Left Right balance
                                        if (characters[4] == '0')
                                        {
                                            this.dataGridView1.Columns[1].Visible = false;
                                        }*/

                                        // Power pedalling index
                                        if (characters[5] == '0')
                                        {
                                            this.dataGridView1.Columns[6].Visible = false;
                                        }

                                        // HR/CC data
                                        if (characters[6] == '0')
                                        {
                                            this.dataGridView1.Columns[2].Visible = false;
                                            this.dataGridView1.Columns[3].Visible = false;
                                            this.dataGridView1.Columns[4].Visible = false;
                                            this.dataGridView1.Columns[5].Visible = false;
                                            this.dataGridView1.Columns[6].Visible = false;
                                        }


                                        /*
                                        // Air Pressure
                                        if (characters[8] == '0')
                                        {
                                            this.dataGridView1.Columns[1].Visible = false;
                                        } */



                                    }



                                    // Labels
                                    // HR
                                    string maxLabel = maxhr.ToString();
                                    string minLabel = minhr.ToString();
                                    averageHeartRate = sumHR / count;
                                    HeartRate.Text = averageHeartRate.ToString("#.##") + " (bpm)";
                                    maxHR.Text = maxLabel + " (bpm)";
                                    minHR.Text = minLabel + " (bpm)";



                                    // US unit
                                    if (characters[7] == '0')
                                    {
                                        // Speed
                                        maxs = maxs / 10;
                                        maxSpeedLabel = maxs.ToString("#.##");
                                        averageSpeed = (sumSpeed / count) / 10;
                                        AverageSpeed.Text = averageSpeed.ToString("#.##") + " (Mph)";
                                        MaxSpeed.Text = maxSpeedLabel + " (Mph)";

                                        // Total distance
                                        double totalDistance = (averageSpeed / 3600) * theLength.TotalMilliseconds / 1000; // 60 x 60 (mins and secs)
                                        TotalDistance.Text = totalDistance.ToString("#.##") + " (Miles)";

                                        // Altitude
                                        string maxAltitudeLabel = maxa.ToString();
                                        averageAltitude = sumAltitude / count;
                                        AverageAltitude.Text = averageAltitude.ToString("#.##");
                                        MaxAltitude.Text = maxAltitudeLabel;
                                    }
                                    else if(characters[7] == '1')
                                    {
                                        // Speed
                                        maxs = (maxs * 1.60934) / 10;
                                        maxSpeedLabel = maxs.ToString("#.##");
                                        averageSpeed = (((sumSpeed / count) / 10) * 1.60934);
                                        AverageSpeed.Text = averageSpeed.ToString("#.##") + " (Kph)";
                                        MaxSpeed.Text = maxSpeedLabel + " (Kph)";

                                        double totalDistance = (averageSpeed / 3600) * theLength.TotalMilliseconds / 1000; // 60 x 60 (mins and secs)
                                        TotalDistance.Text = totalDistance.ToString("#.##") + " (Kilometers)";

                                        // Altitude
                                        string maxAltitudeLabel = maxa.ToString();
                                        averageAltitude = sumAltitude / count;
                                        AverageAltitude.Text = averageAltitude.ToString("#.##");
                                        MaxAltitude.Text = maxAltitudeLabel;
                                    }

                                    // Power
                                    string maxPowerLabel = maxp.ToString();
                                    averagePower = sumPower / count;
                                    AveragePower.Text = averagePower.ToString("#.##") + " (W)";
                                    MaxPower.Text = maxPowerLabel + " (W)";

                                    

                                    

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

        private void milesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (maxSpeed > maxs)
            { maxs = maxSpeed; }
            maxs = maxs / 10;
            maxSpeedLabel = maxs.ToString();
            averageSpeed = ((sumSpeed / count) / 10);
            AverageSpeed.Text = averageSpeed.ToString("#.##");
            MaxSpeed.Text = maxSpeedLabel + " (Mph)";
        }

        private void KilometersRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Speed
            maxs = maxs * 1.60934;
            maxSpeedLabel = maxs.ToString();
            averageSpeed = (((sumSpeed / count) / 10) * 1.60934);
            AverageSpeed.Text = averageSpeed.ToString("#.##");
            MaxSpeed.Text = maxSpeedLabel + " (Kph)";
        }


      


    }
}
