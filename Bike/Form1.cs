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
                        int maxhr, maxp, maxhr1, maxp1 = 0;
                        double maxs, maxa, maxs1, maxa1 = 0;
                        int minhr = 100000, minhr1 = 1000000;
                        int count = 0;

                        double sumHR, sumSpeed, sumAltitude, sumPower, sumLeftFoot, sumRightFoot;
                        double averageHeartRate, averageSpeed, averageAltitude, averagePower, averageLeftFoot, averageRightFoot;
                        double maxSpeed;
                        double convertHR, convertSpeed, convertCadence, convertAltitude, convertPower, convertPowerBalanceAndPedallingIndex;
                        double convertHR1, convertSpeed1, convertCadence1, convertAltitude1, convertPower1;

                        //double normalizedPower;

                        string kRadioButton, mRadioButton, averagekRadioButton, averagemRadioButton;
                        string metersRadioButton, feetRadioButton, averagemetersRadioButton, averagefeetRadioButton, mtotalDistanceRadioButton, ktotalDistanceRadioButton;
                        string heartRate, time, speed, cadence, altitude, power, powerBalanceAndPedallingIndex;

                        int leftFoot, rightFoot, powerIndex, counter;

                        //Times
                        char[] characters;
                        double timeInterval;

                        private float x, y;
                        string[] lines, splitTabs;
                        string filename, splitLine;
                        int numOfLines;
                        double axisTime, axisTime1;
                        Stream myStream = null;



                        List<double> powerList;
                        double[] powerArrayList;

                        List<double> speedList;
                        double[] speedArrayList;

                        List<double> heartRateList;
                        double[] heartRateArrayList;

                        List<double> altitudeList;
                        double[] altitudeArrayList;

                        List<double> cadenceList;
                        double[] cadenceArrayList;

                        List<string> timeList;
                        string[] timeArrayList;







                        double averagePowerArray, sumPowerArray, sum4thPower, normalizedPower, intensityFactor;

                        string version1, version2, version3, version4, version5, version6, version7, version8, version9, version10;


                        float mdx, mdy;

                        bool version1Bool, version2Bool, version3Bool, version4Bool, version5Bool, version6Bool, version7Bool, version8Bool, version9Bool, version10Bool;


        

                        //Dates
                        string theDate;
                        DateTime theStartTime;
                        DateTime dt, dt1;
                        TimeSpan theLength;

                        //Labels
                        string maxSpeedLabel = "";

                        GraphPane pane;
                        PointPairList heartRateArray = new PointPairList();
                        PointPairList speedArray = new PointPairList();
                        PointPairList kmspeedArray = new PointPairList();
                        PointPairList altitudeArray = new PointPairList();
                        PointPairList ftaltitudeArray = new PointPairList();
                        PointPairList powerArray = new PointPairList();
                        PointPairList cadenceArray = new PointPairList();

                        PointPairList heartRateArray1 = new PointPairList();
                        PointPairList speedArray1 = new PointPairList();
                        PointPairList kmspeedArray1 = new PointPairList();
                        PointPairList altitudeArray1 = new PointPairList();
                        PointPairList ftaltitudeArray1 = new PointPairList();
                        PointPairList powerArray1 = new PointPairList();
                        PointPairList cadenceArray1 = new PointPairList();

                        LineItem speedCurve, heartRateCurve, powerCurve, cadenceCurve, altitudeCurve;




                        public Form1()
                        {
                            InitializeComponent();


                            string[] files = Directory.GetFiles(@"F:\August2012DataForCalandar", "*.hrm");
                            string[] splitTitle;
                            string datePicked;
                            DateTime myDate = new DateTime();
                            string splitLine;

                            powerList = new List<double>();
                            speedList = new List<double>();
                            heartRateList = new List<double>();
                            altitudeList = new List<double>();
                            cadenceList = new List<double>();
                            timeList = new List<string>();

                            List<DateTime> cDates = new List<DateTime>();

                            int f = 0;

                            foreach (string file in files)
                            {

                                splitLine = files[f];
                                if (splitLine.Contains("\\"))
                                {
                                    splitTitle = files[f].Split(new Char[] { '\\', '.' });
                                    datePicked = splitTitle[2].Substring(0, 6);
                                    myDate = DateTime.ParseExact(datePicked, "yyMMdd",
                                    System.Globalization.CultureInfo.InvariantCulture);

                                    cDates.Add(myDate);
                                }
                                f++;
                            }

                            monthCalendar1.BoldedDates = cDates.ToArray();

                        }


                        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
                        {
                            string[] splitTitle;
                            string datePicked;
                            DateTime myDate = new DateTime();
                            string splitLine;
                            string[] files = Directory.GetFiles(@"F:\August2012DataForCalandar", "*.hrm");

                            List<DateTime> cDates = new List<DateTime>();

                            int f = 0;
                            int v = 0;

                            fileVersion1.Text = "...";
                            fileVersion2.Text = "...";
                            fileVersion3.Text = "...";
                            fileVersion4.Text = "...";
                            fileVersion5.Text = "...";
                            fileVersion6.Text = "...";
                            fileVersion7.Text = "...";
                            fileVersion8.Text = "...";
                            fileVersion9.Text = "...";
                            fileVersion10.Text = "...";

                            foreach (string file in files)
                            {

                                splitLine = files[f];
                                if (splitLine.Contains("\\"))
                                {
                                    splitTitle = files[f].Split(new Char[] { '\\', '.' });
                                    datePicked = splitTitle[2].Substring(0, 6);
                                    myDate = DateTime.ParseExact(datePicked, "yyMMdd",
                                    System.Globalization.CultureInfo.InvariantCulture);

                                    if (myDate == monthCalendar1.SelectionRange.Start)
                                    {
                                        v++;
                                        if (v == 1)
                                        {
                                            fileVersion1.Text = myDate.ToString() + " - Version " + v;
                                            version1 = splitTitle[2].ToString();
                                        }
                                        else if (v == 2)
                                        {
                                            fileVersion2.Text = myDate.ToString() + " - Version " + v;
                                            version2 = splitTitle[2].ToString();
                                        }
                                        else if (v == 3)
                                        {
                                            fileVersion3.Text = myDate.ToString() + " - Version " + v;
                                            version3 = splitTitle[2].ToString();
                                        }
                                        else if (v == 4)
                                        {
                                            fileVersion4.Text = myDate.ToString() + " - Version " + v;
                                            version4 = splitTitle[2].ToString();
                                        }
                                        else if (v == 5)
                                        {
                                            fileVersion5.Text = myDate.ToString() + " - Version " + v;
                                            version5 = splitTitle[2].ToString();
                                        }
                                        else if (v == 6)
                                        {
                                            fileVersion6.Text = myDate.ToString() + " - Version " + v;
                                            version6 = splitTitle[2].ToString();
                                        }
                                        else if (v == 7)
                                        {
                                            fileVersion7.Text = myDate.ToString() + " - Version " + v;
                                            version7 = splitTitle[2].ToString();
                                        }
                                        else if (v == 8)
                                        {
                                            fileVersion8.Text = myDate.ToString() + " - Version " + v;
                                            version8 = splitTitle[2].ToString();
                                        }
                                        else if (v == 9)
                                        {
                                            fileVersion9.Text = myDate.ToString() + " - Version " + v;
                                            version9 = splitTitle[2].ToString();
                                        }
                                        else if (v == 10)
                                        {
                                            fileVersion10.Text = myDate.ToString() + " - Version " + v;
                                            version10 = splitTitle[2].ToString();
                                        }

                                    }
                                }
                                f++;
                            }

                        }

                        private void fileVersion1_Click(object sender, EventArgs e)
                        {
                            version1Bool = true;
                            version2Bool = false; version3Bool = false; version4Bool = false; version5Bool = false; version6Bool = false; version7Bool = false; version8Bool = false; version9Bool = false; version10Bool = false;
                            openVersions();
                        }

                        private void fileVersion2_Click(object sender, EventArgs e)
                        {
                            version2Bool = true;
                            version1Bool = false; version3Bool = false; version4Bool = false; version5Bool = false; version6Bool = false; version7Bool = false; version8Bool = false; version9Bool = false; version10Bool = false;
                            openVersions();
                        }

                        private void fileVersion3_Click(object sender, EventArgs e)
                        {
                            version3Bool = true;
                            version1Bool = false; version2Bool = false; version4Bool = false; version5Bool = false; version6Bool = false; version7Bool = false; version8Bool = false; version9Bool = false; version10Bool = false;
                            openVersions();
                        }

                        private void fileVersion4_Click(object sender, EventArgs e)
                        {
                            version4Bool = true;
                            version2Bool = false; version3Bool = false; version1Bool = false; version5Bool = false; version6Bool = false; version7Bool = false; version8Bool = false; version9Bool = false; version10Bool = false;
                            openVersions();
                        }

                        private void fileVersion5_Click(object sender, EventArgs e)
                        {
                            version5Bool = true;
                            version2Bool = false; version3Bool = false; version4Bool = false; version1Bool = false; version6Bool = false; version7Bool = false; version8Bool = false; version9Bool = false; version10Bool = false;
                            openVersions();
                        }

                        private void fileVersion6_Click(object sender, EventArgs e)
                        {
                            version6Bool = true;
                            version2Bool = false; version3Bool = false; version4Bool = false; version5Bool = false; version1Bool = false; version7Bool = false; version8Bool = false; version9Bool = false; version10Bool = false;
                            openVersions();
                        }

                        private void fileVersion7_Click(object sender, EventArgs e)
                        {
                            version7Bool = true;
                            version2Bool = false; version3Bool = false; version4Bool = false; version5Bool = false; version6Bool = false; version1Bool = false; version8Bool = false; version9Bool = false; version10Bool = false;
                            openVersions();
                        }

                        private void fileVersion8_Click(object sender, EventArgs e)
                        {
                            version8Bool = true;
                            version2Bool = false; version3Bool = false; version4Bool = false; version5Bool = false; version6Bool = false; version7Bool = false; version1Bool = false; version9Bool = false; version10Bool = false;
                            openVersions();
                        }

                        private void fileVersion9_Click(object sender, EventArgs e)
                        {
                            version9Bool = true;
                            version2Bool = false; version3Bool = false; version4Bool = false; version5Bool = false; version6Bool = false; version7Bool = false; version8Bool = false; version1Bool = false; version10Bool = false;
                            openVersions();
                        }

                        private void fileVersion10_Click(object sender, EventArgs e)
                        {
                            version10Bool = true;
                            version2Bool = false; version3Bool = false; version4Bool = false; version5Bool = false; version6Bool = false; version7Bool = false; version8Bool = false; version9Bool = false; version1Bool = false;
                            openVersions();
                        }





                        private void openVersions()
                        {

                            try
                            {

                                if (version1Bool == true)
                                {
                                    lines = File.ReadAllLines("F:/August2012DataForCalandar/" + version1 + ".hrm");
                                }
                                else if (version2Bool == true)
                                {
                                    lines = File.ReadAllLines("F:/August2012DataForCalandar/" + version2 + ".hrm");
                                }
                                else if (version3Bool == true)
                                {
                                    lines = File.ReadAllLines("F:/August2012DataForCalandar/" + version3 + ".hrm");
                                }
                                else if (version4Bool == true)
                                {
                                    lines = File.ReadAllLines("F:/August2012DataForCalandar/" + version4 + ".hrm");
                                }
                                else if (version5Bool == true)
                                {
                                    lines = File.ReadAllLines("F:/August2012DataForCalandar/" + version5 + ".hrm");
                                }
                                else if (version6Bool == true)
                                {
                                    lines = File.ReadAllLines("F:/August2012DataForCalandar/" + version6 + ".hrm");
                                }
                                else if (version7Bool == true)
                                {
                                    lines = File.ReadAllLines("F:/August2012DataForCalandar/" + version7 + ".hrm");
                                }
                                else if (version8Bool == true)
                                {
                                    lines = File.ReadAllLines("F:/August2012DataForCalandar/" + version8 + ".hrm");
                                }
                                else if (version9Bool == true)
                                {
                                    lines = File.ReadAllLines("F:/August2012DataForCalandar/" + version9 + ".hrm");
                                }
                                else if (version10Bool == true)
                                {
                                    lines = File.ReadAllLines("F:/August2012DataForCalandar/" + version10 + ".hrm");
                                }

                                for (int i = 0; i < lines.Length; i++)
                                {

                    

                                    splitLine = lines[i];

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
                                            (Int32.Parse(splitTitle[1].Substring(9, 1)) * 100) // milliseconds 
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
                                        characters = smode.ToCharArray(); // split smode into char array
                                    }


                                    if (splitLine.Contains("[HRData]"))
                                    {

                                        averageHeartRate = sumHR;
                                        averageSpeed = sumSpeed;
                                        averageAltitude = sumAltitude;
                                        averagePower = sumPower;

                                        //finds the line number of HRData then reads the rest of the file after that
                                        for (int a = (i + 1); a < lines.Length; a++)
                                        {


                                            //split lines after the title [HRData]
                                            string splitA = lines[a];
                                            splitTabs = splitA.Split('\t'); //split tabs
                                            numOfLines = a;

                                            // time
                                            dt = theStartTime.AddMilliseconds((timeInterval * counter) * 1000);

                                            time = dt.ToString("HH:mm:ss.f");
                                            axisTime = (double)new XDate(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
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


                                            powerList.Add(convertPower);
                                            speedList.Add(convertSpeed);
                                            heartRateList.Add(convertHR);
                                            altitudeList.Add(convertAltitude);
                                            cadenceList.Add(convertCadence);
                                            timeList.Add(time);


                                            powerArrayList = powerList.ToArray();
                                            speedArrayList = speedList.ToArray();
                                            heartRateArrayList = heartRateList.ToArray();
                                            altitudeArrayList = altitudeList.ToArray();
                                            cadenceArrayList = cadenceList.ToArray();
                                            timeArrayList = timeList.ToArray();




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
                                            if (characters[7] == '1')
                                            {
                                                this.dataGridView1.Columns[2].HeaderText = "Speed (Kph)";
                                                this.dataGridView1.Columns[4].HeaderText = "Altitude (ft)";
                                                this.dataGridView1.Rows.Add(time, heartRate, speed, cadence, altitude, power, powerBalanceAndPedallingIndex, leftFoot, rightFoot, powerIndex);
                                            }
                                            else
                                            {
                                                this.dataGridView1.Rows.Add(time, heartRate, speed, cadence, altitude, power, powerBalanceAndPedallingIndex);
                                            }

                                            // speed
                                            if (characters[0] == '0')
                                            {
                                                speed = "0";
                                                this.dataGridView1.Columns[2].Visible = false;
                                            }

                                            // cadence
                                            if (characters[1] == '0')
                                            {
                                                cadence = "0";
                                                this.dataGridView1.Columns[3].Visible = false;
                                            }

                                            // Altitude
                                            if (characters[2] == '0')
                                            {
                                                altitude = "0";
                                                this.dataGridView1.Columns[4].Visible = false;
                                            }

                                            // Power
                                            if (characters[3] == '0')
                                            {
                                                power = "0";
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
                                                powerBalanceAndPedallingIndex = "0";
                                                this.dataGridView1.Columns[6].Visible = false;
                                            }

                                            // HR/CC data
                                            if (characters[6] == '0')
                                            {
                                                cadence = "0";
                                                speed = "0";
                                                power = "0";
                                                altitude = "0";
                                                powerBalanceAndPedallingIndex = "0";
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


                                            // Display Lines in Graph

                                            // Titles
                                            string[] xaxis = { "Time" };
                                            pane = zedGraphControl1.GraphPane;



                                            pane.Title.Text = "Bike Data";
                                            pane.XAxis.Title.Text = "Time";
                                            pane.YAxis.Title.Text = "Data";

                                            // xAxis
                                            pane.XAxis.Type = AxisType.Date;
                                            pane.XAxis.Scale.Format = "HH:mm:ss";
                                            pane.XAxis.Scale.MajorUnit = DateUnit.Minute;
                                            pane.XAxis.Scale.MinorUnit = DateUnit.Minute;




                                            // Add Intervals and points
                                            //heartRateArray.Add(axisTime1, convertHR);

                                            heartRateArray.Add(axisTime, convertHR);
                                            speedArray.Add(axisTime, convertSpeed);
                                            kmspeedArray.Add(axisTime, convertSpeed * 1.60934);
                                            altitudeArray.Add(axisTime, convertAltitude);
                                            ftaltitudeArray.Add(axisTime, convertAltitude * 3.28084);
                                            powerArray.Add(axisTime, convertPower);
                                            cadenceArray.Add(axisTime, convertCadence);






                                            int convertPowerBalanceAndPedallingIndex = Convert.ToInt32(powerBalanceAndPedallingIndex);
                                            string result = Convert.ToString(convertPowerBalanceAndPedallingIndex, 2).PadLeft(16, '0');//converts to binary
                                            string PI = result.Substring(0, 8); //(skip number, read how many numbers) // This is PI
                                            string LRB = result.Substring(8, 8); //(skip number, read how many numbers) // This is LRB

                                            leftFoot = Convert.ToInt32(LRB, 2);
                                            rightFoot = 100 - leftFoot;
                                            powerIndex = Convert.ToInt32(PI, 2);

                                            sumLeftFoot += (leftFoot);
                                            sumRightFoot += (rightFoot);

                                            /*Console.WriteLine("binary " + result);
                                            Console.WriteLine("upper mask " + PI);
                                            Console.WriteLine("lower mask " + LRB);
                                            Console.WriteLine("left foot " + leftFoot);
                                            Console.WriteLine("right foot " + rightFoot);
                                            Console.WriteLine("Power Index " + powerIndex);*/


                                            count++;
                                        }

                                        List<double> cPower = new List<double>();

                                        // Interval detection
                                        for (int a = 0; a < powerArrayList.Length - 29; a++)
                                        {
                                            sumPowerArray = powerArrayList[a];
                                            //cPower.Add(sumPowerArray);
                                        }




                                        // Interval Detection

                                        int intervalCount = 0;

                                        Boolean inInt = false;

                                        int currentIntCount = 0;
                                        double sumIntPower = 0;
                                        double sumIntSpeed = 0;
                                        double sumIntHeartRate = 0;
                                        double sumIntAltitude = 0;
                                        double sumIntCadence = 0;
                                        string saveStartTime = "";

                                        // if power array list increases or decreases by 10 detect interval
                                        //double[] list = cPower.ToArray();
                                        for (int a = 5; a < powerArrayList.Length; a++)
                                        {
                                            if (inInt)
                                            {
                                                if (powerArrayList[a - 5] > (powerArrayList[a] + 100))
                                                {
                                                    this.dataGridView2.Rows.Add(intervalCount, saveStartTime, timeArrayList[a], (sumIntPower / currentIntCount).ToString("#.##"),
                                                        (sumIntSpeed / currentIntCount).ToString("#.##"), (sumIntHeartRate / currentIntCount).ToString("#.##"), (sumIntAltitude / currentIntCount).ToString("#.##"), (sumIntCadence / currentIntCount).ToString("#.##"));
                                                    currentIntCount = 0;
                                                    sumIntPower = 0;
                                                    sumIntSpeed = 0;
                                                    sumIntHeartRate = 0;
                                                    sumIntAltitude = 0;
                                                    sumIntCadence = 0;
                                                    inInt = false;
                                                }
                                                else
                                                {
                                                    currentIntCount++;
                                                    sumIntPower += powerArrayList[a];
                                                    sumIntSpeed += speedArrayList[a];
                                                    sumIntHeartRate += heartRateArrayList[a];
                                                    sumIntAltitude += altitudeArrayList[a];
                                                    sumIntCadence += cadenceArrayList[a];
                                                }
                                            }
                                            else
                                            {
                                                if (powerArrayList[a - 5] < (powerArrayList[a] - 100))
                                                {
                                                    saveStartTime = timeArrayList[a];
                                                    inInt = true;
                                                    intervalCount++;
                                                }
                                            }

                                        }



















                                        // Normalized Power

                                        for (int a = 0; a < powerArrayList.Length - 29; a++)
                                        {
                                            sumPowerArray += Math.Pow(((
                                                powerArrayList[a] + powerArrayList[a + 1] + powerArrayList[a + 2]
                                                + powerArrayList[a + 3] + powerArrayList[a + 4] + powerArrayList[a + 5] + powerArrayList[a + 6]
                                                + powerArrayList[a + 7] + powerArrayList[a + 8] + powerArrayList[a + 9] + powerArrayList[a + 10]
                                                + powerArrayList[a + 11] + powerArrayList[a + 12] + powerArrayList[a + 13] + powerArrayList[a + 14]
                                                + powerArrayList[a + 15] + powerArrayList[a + 16] + powerArrayList[a + 17] + powerArrayList[a + 18]
                                                + powerArrayList[a + 19] + powerArrayList[a + 20] + powerArrayList[a + 21] + powerArrayList[a + 22]
                                                + powerArrayList[a + 23] + powerArrayList[a + 24] + powerArrayList[a + 25] + powerArrayList[a + 26]
                                                + powerArrayList[a + 27] + powerArrayList[a + 28] + powerArrayList[a + 29]
                                                ) / 30), 4.0);

                                        }
                                        /*Console.WriteLine(sumPowerArray);
                                        Console.WriteLine("4th "+sum4thPower);
                                        Console.WriteLine("AVP "+averagePowerArray);
                                        Console.WriteLine("NP "+normalizedPower);
                                        Console.WriteLine(powerArrayList.Length);*/
                                        //Console.WriteLine("Sum 4th power " + sum4thPower + "avergae power array " + averagePowerArray + " normailized power " + normalizedPower);
                                        averagePowerArray = (sumPowerArray / (powerArrayList.Length - 29));
                                        normalizedPower = Math.Pow(averagePowerArray, (1.0 / 4.0));
                                        Console.WriteLine(normalizedPower);

                                        // Labels
                                        // HR
                                        string maxLabel = maxhr.ToString();
                                        string minLabel = minhr.ToString();
                                        averageHeartRate = sumHR / count;
                                        HeartRate.Text = averageHeartRate.ToString("#.##") + " (bpm)";
                                        maxHR.Text = maxLabel + " (bpm)";
                                        minHR.Text = minLabel + " (bpm)";

                                        Console.Out.WriteLine("Average HR before " + averageHeartRate);


                                        // US unit
                                        if (characters[7] == '0')
                                        {
                                            // Speed
                                            maxs = maxs / 10;
                                            maxSpeedLabel = maxs.ToString("#.##");
                                            averageSpeed = (sumSpeed / count) / 10;
                                            AverageSpeed.Text = averageSpeed.ToString("#.##") + " (Mph)";
                                            MaxSpeed.Text = maxSpeedLabel + " (Mph)";

                                            double kiloSpeed = maxs * 1.60934;
                                            double averageKiloSpeed = averageSpeed * 1.60934;
                                            mRadioButton = maxSpeedLabel;
                                            averagemRadioButton = averageSpeed.ToString("#.##") + " (Mph)";
                                            kRadioButton = kiloSpeed.ToString("#.##");
                                            averagekRadioButton = averageKiloSpeed.ToString("#.##");

                                            // Total distance
                                            double totalDistance = (averageSpeed / 3600) * theLength.TotalMilliseconds / 1000; // 60 x 60 (mins and secs)
                                            double kiloTotalDistance = (averageKiloSpeed / 3600) * theLength.TotalMilliseconds / 1000;
                                            TotalDistance.Text = totalDistance.ToString("#.##") + " (Miles)";
                                            mtotalDistanceRadioButton = totalDistance.ToString("#.##") + " (Miles)";
                                            ktotalDistanceRadioButton = kiloTotalDistance.ToString("#.##") + " (Kilometers)";

                                            // Altitude
                                            string maxAltitudeLabel = maxa.ToString();
                                            averageAltitude = sumAltitude / count;
                                            AverageAltitude.Text = averageAltitude.ToString("#.##") + " (m)";
                                            MaxAltitude.Text = maxAltitudeLabel + " (m)";

                                            double feet = maxa * 3.28084;
                                            double averagefeet = averageAltitude * 3.28084;
                                            averagemetersRadioButton = averageAltitude.ToString("#.##") + " (m)";
                                            metersRadioButton = maxAltitudeLabel + " (m)";
                                            averagefeetRadioButton = averagefeet.ToString("#.##") + " (ft)";
                                            feetRadioButton = feet.ToString("#.##") + " (ft)";

                                            milesRadioButton.Checked = true;
                                            MetersRadioButton.Checked = true;
                                            radioButton1.Checked = true;


                                        }
                                        else if (characters[7] == '1')
                                        {
                                            // Speed
                                            maxs = (maxs * 1.60934) / 10;
                                            maxSpeedLabel = maxs.ToString("#.##");
                                            averageSpeed = (((sumSpeed / count) / 10) * 1.60934);
                                            AverageSpeed.Text = averageSpeed.ToString("#.##") + " (Kph)";
                                            MaxSpeed.Text = maxSpeedLabel + " (Kph)";

                                            double milesSpeed = maxs / 1.60934;
                                            double averageMilesSpeed = averageSpeed / 1.60934;
                                            mRadioButton = milesSpeed.ToString("#.##");
                                            averagemRadioButton = averageSpeed.ToString("#.##") + " (Mph)";
                                            kRadioButton = maxSpeedLabel;
                                            averagekRadioButton = averageSpeed.ToString("#.##") + " (Kph)";

                                            double totalDistance = (averageSpeed / 3600) * theLength.TotalMilliseconds / 1000; // 60 x 60 (mins and secs)
                                            double milesTotalDistance = (averageMilesSpeed / 3600) * theLength.TotalMilliseconds / 1000;
                                            TotalDistance.Text = totalDistance.ToString("#.##") + " (Kilometers)";
                                            ktotalDistanceRadioButton = totalDistance.ToString("#.##") + " (Kilometers)";
                                            mtotalDistanceRadioButton = milesTotalDistance.ToString("#.##") + " (Miles)";

                                            // Altitude
                                            maxa = maxa * 3.28084;
                                            string maxAltitudeLabel = maxa.ToString("#.##");
                                            averageAltitude = (sumAltitude / count) * 3.28084;
                                            AverageAltitude.Text = averageAltitude.ToString("#.##") + " (ft)";
                                            MaxAltitude.Text = maxAltitudeLabel + " (ft)";

                                            double meters = maxa / 3.28084;
                                            double averagemeters = averageAltitude / 3.28084;
                                            averagefeetRadioButton = averageAltitude.ToString("#.##") + " (ft)";
                                            feetRadioButton = maxAltitudeLabel + " (ft)";
                                            averagemetersRadioButton = averagemeters.ToString("#.##") + " (m)";
                                            metersRadioButton = meters.ToString() + " (m)";

                                            //set radiobuttons to true
                                            KilometersRadioButton.Checked = true;
                                            FeetRadioButton.Checked = true;
                                            radioButton2.Checked = true;

                                        }

                                        // Power
                                        string maxPowerLabel = maxp.ToString();
                                        averagePower = sumPower / count;
                                        AveragePower.Text = averagePower.ToString("#.##") + " (W)";
                                        MaxPower.Text = maxPowerLabel + " (W)";

                                        averageLeftFoot = sumLeftFoot / count;
                                        averageRightFoot = sumRightFoot / count;
                                        PBRL.Text = averageLeftFoot.ToString("#.##") + " (W)";
                                        PBLL.Text = averageRightFoot.ToString("#.##") + " (W)";

                                        NormalizedPowerLabel.Text = normalizedPower.ToString("#.##");
                                    }
                                }






                                // ZedGraph generate pane

                                if (characters[7] == '0')
                                {


                                    heartRateCurve = pane.AddCurve("Heart Rate", heartRateArray, Color.Black, SymbolType.Circle);
                                    heartRateCurve.Line.IsVisible = true;
                                    heartRateCurve.Line.Width = 1.0F;
                                    heartRateCurve.Symbol.Size = 0F;

                                    speedCurve = pane.AddCurve("Speed", speedArray, Color.Red, SymbolType.Circle);
                                    speedCurve.Line.IsVisible = true;
                                    speedCurve.Line.Width = 1.0F;
                                    speedCurve.Symbol.Size = 0F;


                                    altitudeCurve = pane.AddCurve("Altitude", altitudeArray, Color.Blue, SymbolType.Circle);
                                    altitudeCurve.Line.IsVisible = true;
                                    altitudeCurve.Line.Width = 1.0F;
                                    altitudeCurve.Symbol.Size = 0F;

                                    powerCurve = pane.AddCurve("Power", powerArray, Color.Green, SymbolType.Circle);
                                    powerCurve.Line.IsVisible = true;
                                    powerCurve.Line.Width = 1.0F;
                                    powerCurve.Symbol.Size = 0F;

                                    cadenceCurve = pane.AddCurve("Cadence", cadenceArray, Color.Yellow, SymbolType.Circle);
                                    cadenceCurve.Line.IsVisible = true;
                                    cadenceCurve.Line.Width = 1.0F;
                                    cadenceCurve.Symbol.Size = 0F;
                                    pane.Legend.IsVisible = true;

                                    pane.AxisChange();

                                    if (characters[0] == '0')
                                    {
                                        speedCurve.Line.IsVisible = false;
                                    }

                                    if (characters[1] == '0')
                                    { cadenceCurve.Line.IsVisible = false; }

                                    if (characters[2] == '0')
                                    { altitudeCurve.Line.IsVisible = false; }

                                    if (characters[3] == '0')
                                    { powerCurve.Line.IsVisible = false; }

                                    if (characters[6] == '0')
                                    {
                                        speedCurve.Line.IsVisible = false;
                                        heartRateCurve.Line.IsVisible = false;
                                        cadenceCurve.Line.IsVisible = false;
                                        altitudeCurve.Line.IsVisible = false;
                                    }
                                }


                                if (characters[7] == '1')
                                {
                                    speedCurve = pane.AddCurve("Speed", kmspeedArray, Color.Red, SymbolType.Circle); //draw the line/points
                                    speedCurve.Line.IsVisible = true;
                                    speedCurve.Line.Width = 1.0F;
                                    speedCurve.Symbol.Size = 0F;

                                    heartRateCurve = pane.AddCurve("Heart Rate", heartRateArray, Color.Black, SymbolType.Circle); //draw the line/points
                                    heartRateCurve.Line.IsVisible = true;
                                    heartRateCurve.Line.Width = 1.0F;
                                    heartRateCurve.Symbol.Size = 0F;

                                    altitudeCurve = pane.AddCurve("Altitude", ftaltitudeArray, Color.Blue, SymbolType.Circle); //draw the line/points
                                    altitudeCurve.Line.IsVisible = true;
                                    altitudeCurve.Line.Width = 1.0F;
                                    altitudeCurve.Symbol.Size = 0F;

                                    powerCurve = pane.AddCurve("Power", powerArray, Color.Green, SymbolType.Circle); //draw the line/points
                                    powerCurve.Line.IsVisible = true;
                                    powerCurve.Line.Width = 1.0F;
                                    powerCurve.Symbol.Size = 0F;

                                    cadenceCurve = pane.AddCurve("Cadence", cadenceArray, Color.Yellow, SymbolType.Circle); //draw the line/points
                                    cadenceCurve.Line.IsVisible = true;
                                    cadenceCurve.Line.Width = 1.0F;
                                    cadenceCurve.Symbol.Size = 0F;
                                    pane.Legend.IsVisible = true;



                                    pane.AxisChange();  //changes scale of axis depending on the points

                                    if (characters[0] == '0')
                                    { speedCurve.Line.IsVisible = false; }

                                    if (characters[1] == '0')
                                    { cadenceCurve.Line.IsVisible = false; }

                                    if (characters[2] == '0')
                                    { altitudeCurve.Line.IsVisible = false; }

                                    if (characters[3] == '0')
                                    { powerCurve.Line.IsVisible = false; }

                                    if (characters[6] == '0')
                                    {
                                        speedCurve.Line.IsVisible = false;
                                        heartRateCurve.Line.IsVisible = false;
                                        cadenceCurve.Line.IsVisible = false;
                                        altitudeCurve.Line.IsVisible = false;
                                    }
                                }

                                zedGraphControl1.Refresh();
                                this.Controls.Add(zedGraphControl1);
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show("Error: Unable to open file. Original error: " + ex.Message);
                            }
                        }
            
        























































                        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
                        {
                            if (MessageBox.Show("Are you sure you want to quit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            { Application.Exit(); }
                        }

                        private void openToolStripMenuItem_Click(object sender, EventArgs e)
                        {
                            OpenFileDialog openFileDialog1 = new OpenFileDialog();

                            openFileDialog1.InitialDirectory = "f:\\";
                            openFileDialog1.Filter = "hrm files (*.hrm)|*.hrm|All files (*.*)|*.*";
                            openFileDialog1.FilterIndex = 1;
                            openFileDialog1.RestoreDirectory = true;

                            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    if ((myStream = openFileDialog1.OpenFile()) != null)
                                    {
                                        using (myStream)
                                        {

                                            filename = openFileDialog1.FileName;
                                            lines = File.ReadAllLines(filename);

                                            for (int i = 0; i < lines.Length; i++)
                                            {

                                                if(version1Bool == true)
                                                {
                                                    lines = File.ReadAllLines("F:/August2012DataForCalandar/" + version1 + ".hrm");
                                                }

                                                splitLine = lines[i];


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
                                                        (Int32.Parse(splitTitle[1].Substring(9, 1)) * 100) // milliseconds 
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
                                                    characters = smode.ToCharArray(); // split smode into char array
                                                }


                                                if (splitLine.Contains("[HRData]"))
                                                {

                                                    averageHeartRate = sumHR;
                                                    averageSpeed = sumSpeed;
                                                    averageAltitude = sumAltitude;
                                                    averagePower = sumPower;

                                                    //finds the line number of HRData then reads the rest of the file after that
                                                    for (int a = (i + 1); a < lines.Length; a++)
                                                    {
                                        

                                                        //split lines after the title [HRData]
                                                        string splitA = lines[a];
                                                        splitTabs = splitA.Split('\t'); //split tabs
                                                        numOfLines = a;

                                                        // time
                                                        dt = theStartTime.AddMilliseconds((timeInterval * counter) * 1000);

                                                        time = dt.ToString("HH:mm:ss.f");
                                                        axisTime = (double)new XDate(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
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


                                                        powerList.Add(convertPower);
                                                        speedList.Add(convertSpeed);
                                                        heartRateList.Add(convertHR);
                                                        altitudeList.Add(convertAltitude);
                                                        cadenceList.Add(convertCadence);
                                                        timeList.Add(time);


                                                        powerArrayList = powerList.ToArray();
                                                        speedArrayList = speedList.ToArray();
                                                        heartRateArrayList = heartRateList.ToArray();
                                                        altitudeArrayList = altitudeList.ToArray();
                                                        cadenceArrayList = cadenceList.ToArray();
                                                        timeArrayList = timeList.ToArray();




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
                                                        if (characters[7] == '1')
                                                        {
                                                            this.dataGridView1.Columns[2].HeaderText = "Speed (Kph)";
                                                            this.dataGridView1.Columns[4].HeaderText = "Altitude (ft)";
                                                            this.dataGridView1.Rows.Add(time, heartRate, speed, cadence, altitude, power, powerBalanceAndPedallingIndex, leftFoot, rightFoot, powerIndex);
                                                        }
                                                        else
                                                        {
                                                            this.dataGridView1.Rows.Add(time, heartRate, speed, cadence, altitude, power, powerBalanceAndPedallingIndex);
                                                        }

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


                                                        // Display Lines in Graph

                                                        // Titles
                                                        string[] xaxis = { "Time" };
                                                        pane = zedGraphControl1.GraphPane;



                                                        pane.Title.Text = "Bike Data";
                                                        pane.XAxis.Title.Text = "Time";
                                                        pane.YAxis.Title.Text = "Data";

                                                        // xAxis
                                                        pane.XAxis.Type = AxisType.Date;
                                                        pane.XAxis.Scale.Format = "HH:mm:ss";
                                                        pane.XAxis.Scale.MajorUnit = DateUnit.Minute;
                                                        pane.XAxis.Scale.MinorUnit = DateUnit.Minute;

                                      


                                                        // Add Intervals and points
                                                        //heartRateArray.Add(axisTime1, convertHR);

                                                        heartRateArray.Add(axisTime, convertHR);
                                                        speedArray.Add(axisTime, convertSpeed);
                                                        kmspeedArray.Add(axisTime, convertSpeed * 1.60934);
                                                        altitudeArray.Add(axisTime, convertAltitude);
                                                        ftaltitudeArray.Add(axisTime, convertAltitude * 3.28084);
                                                        powerArray.Add(axisTime, convertPower);
                                                        cadenceArray.Add(axisTime, convertCadence);






                                                        int convertPowerBalanceAndPedallingIndex = Convert.ToInt32(powerBalanceAndPedallingIndex);
                                                        string result = Convert.ToString(convertPowerBalanceAndPedallingIndex, 2).PadLeft(16, '0');//converts to binary
                                                        string PI = result.Substring(0, 8); //(skip number, read how many numbers) // This is PI
                                                        string LRB = result.Substring(8, 8); //(skip number, read how many numbers) // This is LRB

                                                        leftFoot = Convert.ToInt32(LRB, 2);
                                                        rightFoot = 100 - leftFoot;
                                                        powerIndex = Convert.ToInt32(PI, 2);

                                                        sumLeftFoot += (leftFoot);
                                                        sumRightFoot += (rightFoot);

                                                        /*Console.WriteLine("binary " + result);
                                                        Console.WriteLine("upper mask " + PI);
                                                        Console.WriteLine("lower mask " + LRB);
                                                        Console.WriteLine("left foot " + leftFoot);
                                                        Console.WriteLine("right foot " + rightFoot);
                                                        Console.WriteLine("Power Index " + powerIndex);*/


                                                        count++;
                                                    }

                                                    List<double> cPower = new List<double>();
                                    
                                                    // Interval detection
                                                    for (int a = 0; a < powerArrayList.Length - 29; a++)
                                                    {
                                                        sumPowerArray = powerArrayList[a];
                                                        //cPower.Add(sumPowerArray);
                                                    }




                                                    // Interval Detection

                                                    int intervalCount = 0;

                                                    Boolean inInt = false;

                                                    int currentIntCount = 0;
                                                    double sumIntPower = 0;
                                                    double sumIntSpeed = 0;
                                                    double sumIntHeartRate = 0;
                                                    double sumIntAltitude = 0;
                                                    double sumIntCadence = 0;
                                                    string saveStartTime = "";

                                                    // if power array list increases or decreases by 10 detect interval
                                                    //double[] list = cPower.ToArray();
                                                    for (int a = 5; a < powerArrayList.Length; a++)
                                                    {
                                                        if (inInt)
                                                        {
                                                            if (powerArrayList[a - 5] > (powerArrayList[a] + 100))
                                                            {
                                                                this.dataGridView2.Rows.Add(intervalCount, saveStartTime, timeArrayList[a], (sumIntPower / currentIntCount).ToString("#.##"),
                                                                    (sumIntSpeed / currentIntCount).ToString("#.##"), (sumIntHeartRate / currentIntCount).ToString("#.##"), (sumIntAltitude / currentIntCount).ToString("#.##"), (sumIntCadence / currentIntCount).ToString("#.##"));
                                                                currentIntCount = 0;
                                                                sumIntPower = 0;
                                                                sumIntSpeed = 0;
                                                                sumIntHeartRate = 0;
                                                                sumIntAltitude = 0;
                                                                sumIntCadence = 0;
                                                                inInt = false;
                                                            }
                                                            else
                                                            {
                                                                currentIntCount++;
                                                                sumIntPower += powerArrayList[a];
                                                                sumIntSpeed += speedArrayList[a];
                                                                sumIntHeartRate += heartRateArrayList[a];
                                                                sumIntAltitude += altitudeArrayList[a];
                                                                sumIntCadence += cadenceArrayList[a];
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (powerArrayList[a - 5] < (powerArrayList[a] - 100))
                                                            {
                                                                saveStartTime = timeArrayList[a];
                                                                inInt = true;
                                                                intervalCount++;
                                                            }
                                                        }

                                                    }



















                                                    // Normalized Power

                                                    for (int a = 0; a < powerArrayList.Length - 29; a++)
                                                    {
                                                        sumPowerArray += Math.Pow(((
                                                            powerArrayList[a] + powerArrayList[a+1] + powerArrayList[a + 2]
                                                            + powerArrayList[a + 3] + powerArrayList[a + 4] + powerArrayList[a + 5] + powerArrayList[a + 6]
                                                            + powerArrayList[a + 7] + powerArrayList[a + 8] + powerArrayList[a + 9] + powerArrayList[a + 10]
                                                            + powerArrayList[a + 11] + powerArrayList[a + 12] + powerArrayList[a + 13] + powerArrayList[a + 14]
                                                            + powerArrayList[a + 15] + powerArrayList[a + 16] + powerArrayList[a + 17] + powerArrayList[a + 18]
                                                            + powerArrayList[a + 19] + powerArrayList[a + 20] + powerArrayList[a + 21] + powerArrayList[a + 22]
                                                            + powerArrayList[a + 23] + powerArrayList[a + 24] + powerArrayList[a + 25] + powerArrayList[a + 26]
                                                            + powerArrayList[a + 27] + powerArrayList[a + 28] + powerArrayList[a + 29]
                                                            )/ 30), 4.0);

                                                    }
                                                    /*Console.WriteLine(sumPowerArray);
                                                    Console.WriteLine("4th "+sum4thPower);
                                                    Console.WriteLine("AVP "+averagePowerArray);
                                                    Console.WriteLine("NP "+normalizedPower);
                                                    Console.WriteLine(powerArrayList.Length);*/
                                                    //Console.WriteLine("Sum 4th power " + sum4thPower + "avergae power array " + averagePowerArray + " normailized power " + normalizedPower);
                                                    averagePowerArray = (sumPowerArray / (powerArrayList.Length - 29));
                                                    normalizedPower = Math.Pow(averagePowerArray, (1.0 / 4.0));
                                                    Console.WriteLine(normalizedPower);

                                                    // Labels
                                                    // HR
                                                    string maxLabel = maxhr.ToString();
                                                    string minLabel = minhr.ToString();
                                                    averageHeartRate = sumHR / count;
                                                    HeartRate.Text = averageHeartRate.ToString("#.##") + " (bpm)";
                                                    maxHR.Text = maxLabel + " (bpm)";
                                                    minHR.Text = minLabel + " (bpm)";

                                                    Console.Out.WriteLine("Average HR before " + averageHeartRate);


                                                    // US unit
                                                    if (characters[7] == '0')
                                                    {
                                                        // Speed
                                                        maxs = maxs / 10;
                                                        maxSpeedLabel = maxs.ToString("#.##");
                                                        averageSpeed = (sumSpeed / count) / 10;
                                                        AverageSpeed.Text = averageSpeed.ToString("#.##") + " (Mph)";
                                                        MaxSpeed.Text = maxSpeedLabel + " (Mph)";

                                                        double kiloSpeed = maxs * 1.60934;
                                                        double averageKiloSpeed = averageSpeed * 1.60934;
                                                        mRadioButton = maxSpeedLabel;
                                                        averagemRadioButton = averageSpeed.ToString("#.##") + " (Mph)";
                                                        kRadioButton = kiloSpeed.ToString("#.##");
                                                        averagekRadioButton = averageKiloSpeed.ToString("#.##");

                                                        // Total distance
                                                        double totalDistance = (averageSpeed / 3600) * theLength.TotalMilliseconds / 1000; // 60 x 60 (mins and secs)
                                                        double kiloTotalDistance = (averageKiloSpeed / 3600) * theLength.TotalMilliseconds / 1000;
                                                        TotalDistance.Text = totalDistance.ToString("#.##") + " (Miles)";
                                                        mtotalDistanceRadioButton = totalDistance.ToString("#.##") + " (Miles)";
                                                        ktotalDistanceRadioButton = kiloTotalDistance.ToString("#.##") + " (Kilometers)";

                                                        // Altitude
                                                        string maxAltitudeLabel = maxa.ToString();
                                                        averageAltitude = sumAltitude / count;
                                                        AverageAltitude.Text = averageAltitude.ToString("#.##") + " (m)";
                                                        MaxAltitude.Text = maxAltitudeLabel + " (m)";

                                                        double feet = maxa * 3.28084;
                                                        double averagefeet = averageAltitude * 3.28084;
                                                        averagemetersRadioButton = averageAltitude.ToString("#.##") + " (m)";
                                                        metersRadioButton = maxAltitudeLabel + " (m)";
                                                        averagefeetRadioButton = averagefeet.ToString("#.##") + " (ft)";
                                                        feetRadioButton = feet.ToString("#.##") + " (ft)";

                                                        milesRadioButton.Checked = true;
                                                        MetersRadioButton.Checked = true;
                                                        radioButton1.Checked = true;


                                                    }
                                                    else if (characters[7] == '1')
                                                    {
                                                        // Speed
                                                        maxs = (maxs * 1.60934) / 10;
                                                        maxSpeedLabel = maxs.ToString("#.##");
                                                        averageSpeed = (((sumSpeed / count) / 10) * 1.60934);
                                                        AverageSpeed.Text = averageSpeed.ToString("#.##") + " (Kph)";
                                                        MaxSpeed.Text = maxSpeedLabel + " (Kph)";

                                                        double milesSpeed = maxs / 1.60934;
                                                        double averageMilesSpeed = averageSpeed / 1.60934;
                                                        mRadioButton = milesSpeed.ToString("#.##");
                                                        averagemRadioButton = averageSpeed.ToString("#.##") + " (Mph)";
                                                        kRadioButton = maxSpeedLabel;
                                                        averagekRadioButton = averageSpeed.ToString("#.##") + " (Kph)";

                                                        double totalDistance = (averageSpeed / 3600) * theLength.TotalMilliseconds / 1000; // 60 x 60 (mins and secs)
                                                        double milesTotalDistance = (averageMilesSpeed / 3600) * theLength.TotalMilliseconds / 1000;
                                                        TotalDistance.Text = totalDistance.ToString("#.##") + " (Kilometers)";
                                                        ktotalDistanceRadioButton = totalDistance.ToString("#.##") + " (Kilometers)";
                                                        mtotalDistanceRadioButton = milesTotalDistance.ToString("#.##") + " (Miles)";

                                                        // Altitude
                                                        maxa = maxa * 3.28084;
                                                        string maxAltitudeLabel = maxa.ToString("#.##");
                                                        averageAltitude = (sumAltitude / count) * 3.28084;
                                                        AverageAltitude.Text = averageAltitude.ToString("#.##") + " (ft)";
                                                        MaxAltitude.Text = maxAltitudeLabel + " (ft)";

                                                        double meters = maxa / 3.28084;
                                                        double averagemeters = averageAltitude / 3.28084;
                                                        averagefeetRadioButton = averageAltitude.ToString("#.##") + " (ft)";
                                                        feetRadioButton = maxAltitudeLabel + " (ft)";
                                                        averagemetersRadioButton = averagemeters.ToString("#.##") + " (m)";
                                                        metersRadioButton = meters.ToString() + " (m)";

                                                        //set radiobuttons to true
                                                        KilometersRadioButton.Checked = true;
                                                        FeetRadioButton.Checked = true;
                                                        radioButton2.Checked = true;

                                                    }

                                                    // Power
                                                    string maxPowerLabel = maxp.ToString();
                                                    averagePower = sumPower / count;
                                                    AveragePower.Text = averagePower.ToString("#.##") + " (W)";
                                                    MaxPower.Text = maxPowerLabel + " (W)";

                                                    averageLeftFoot = sumLeftFoot / count;
                                                    averageRightFoot = sumRightFoot / count;
                                                    PBRL.Text = averageLeftFoot.ToString("#.##") + " (W)";
                                                    PBLL.Text = averageRightFoot.ToString("#.##") + " (W)";

                                                    NormalizedPowerLabel.Text = normalizedPower.ToString("#.##");
                                                }
                                            }

                          




                                            // ZedGraph generate pane

                                            if (characters[7] == '0')
                                            {


                                                heartRateCurve = pane.AddCurve("Heart Rate", heartRateArray, Color.Black, SymbolType.Circle);
                                                heartRateCurve.Line.IsVisible = true;
                                                heartRateCurve.Line.Width = 1.0F;
                                                heartRateCurve.Symbol.Size = 0F;

                                                speedCurve = pane.AddCurve("Speed", speedArray, Color.Red, SymbolType.Circle);
                                                speedCurve.Line.IsVisible = true;
                                                speedCurve.Line.Width = 1.0F;
                                                speedCurve.Symbol.Size = 0F;


                                                altitudeCurve = pane.AddCurve("Altitude", altitudeArray, Color.Blue, SymbolType.Circle);
                                                altitudeCurve.Line.IsVisible = true;
                                                altitudeCurve.Line.Width = 1.0F;
                                                altitudeCurve.Symbol.Size = 0F;

                                                powerCurve = pane.AddCurve("Power", powerArray, Color.Green, SymbolType.Circle);
                                                powerCurve.Line.IsVisible = true;
                                                powerCurve.Line.Width = 1.0F;
                                                powerCurve.Symbol.Size = 0F;

                                                cadenceCurve = pane.AddCurve("Cadence", cadenceArray, Color.Yellow, SymbolType.Circle);
                                                cadenceCurve.Line.IsVisible = true;
                                                cadenceCurve.Line.Width = 1.0F;
                                                cadenceCurve.Symbol.Size = 0F;
                                                pane.Legend.IsVisible = true;

                                                pane.AxisChange();

                                                if (characters[0] == '0')
                                                {
                                                    speedCurve.Line.IsVisible = false;
                                                }

                                                if (characters[1] == '0')
                                                { cadenceCurve.Line.IsVisible = false; }

                                                if (characters[2] == '0')
                                                { altitudeCurve.Line.IsVisible = false; }

                                                if (characters[3] == '0')
                                                { powerCurve.Line.IsVisible = false; }

                                                if (characters[6] == '0')
                                                {
                                                    speedCurve.Line.IsVisible = false;
                                                    heartRateCurve.Line.IsVisible = false;
                                                    cadenceCurve.Line.IsVisible = false;
                                                    altitudeCurve.Line.IsVisible = false;
                                                }
                                            }


                                            if (characters[7] == '1')
                                            {
                                                speedCurve = pane.AddCurve("Speed", kmspeedArray, Color.Red, SymbolType.Circle); //draw the line/points
                                                speedCurve.Line.IsVisible = true;
                                                speedCurve.Line.Width = 1.0F;
                                                speedCurve.Symbol.Size = 0F;

                                                heartRateCurve = pane.AddCurve("Heart Rate", heartRateArray, Color.Black, SymbolType.Circle); //draw the line/points
                                                heartRateCurve.Line.IsVisible = true;
                                                heartRateCurve.Line.Width = 1.0F;
                                                heartRateCurve.Symbol.Size = 0F;

                                                altitudeCurve = pane.AddCurve("Altitude", ftaltitudeArray, Color.Blue, SymbolType.Circle); //draw the line/points
                                                altitudeCurve.Line.IsVisible = true;
                                                altitudeCurve.Line.Width = 1.0F;
                                                altitudeCurve.Symbol.Size = 0F;

                                                powerCurve = pane.AddCurve("Power", powerArray, Color.Green, SymbolType.Circle); //draw the line/points
                                                powerCurve.Line.IsVisible = true;
                                                powerCurve.Line.Width = 1.0F;
                                                powerCurve.Symbol.Size = 0F;

                                                cadenceCurve = pane.AddCurve("Cadence", cadenceArray, Color.Yellow, SymbolType.Circle); //draw the line/points
                                                cadenceCurve.Line.IsVisible = true;
                                                cadenceCurve.Line.Width = 1.0F;
                                                cadenceCurve.Symbol.Size = 0F;
                                                pane.Legend.IsVisible = true;



                                                pane.AxisChange();  //changes scale of axis depending on the points

                                                if (characters[0] == '0')
                                                { speedCurve.Line.IsVisible = false; }

                                                if (characters[1] == '0')
                                                { cadenceCurve.Line.IsVisible = false; }

                                                if (characters[2] == '0')
                                                { altitudeCurve.Line.IsVisible = false; }

                                                if (characters[3] == '0')
                                                { powerCurve.Line.IsVisible = false; }

                                                if (characters[6] == '0')
                                                {
                                                    speedCurve.Line.IsVisible = false;
                                                    heartRateCurve.Line.IsVisible = false;
                                                    cadenceCurve.Line.IsVisible = false;
                                                    altitudeCurve.Line.IsVisible = false;
                                                }
                                            }

                                            zedGraphControl1.Refresh();
                                            this.Controls.Add(zedGraphControl1);
                                        }
                                    }
                                }

                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error: Unable to open file. Original error: " + ex.Message);
                                }
                            }
                        }




                        /*
      
                        private void zedGraphControl1_MouseDownEvent(ZedGraphControl sender, MouseEventArgs e)
                        {
                            GraphPane graphPane = zedGraphControl1.GraphPane;
                            double x, y;

                            graphPane.ReverseTransform(e.Location, out x, out y);
                            LineObj threshHoldLine = new LineObj(Color.Red, mMouseDownX, mMouseDownY, x, y);
                            graphPane.GraphObjList.Add(threshHoldLine);
                            zedGraphControl1.Refresh();

                            return;
                        }


                        private void zedGraphControl1_MouseUpEvent(ZedGraphControl sender, MouseEventArgs e)
                        {
                            GraphPane graphPane = pane.GraphPane;
                            graphPane.ReverseTransform(e.Location, out mMouseDownX, out mMouseDownY);
                            zedGraphControl1.Refresh();
                            return;
                        }


                    */


                        private bool zedGraphControl1_MouseDownEvent(ZedGraphControl sender, MouseEventArgs e)
                        {

                            mdx = e.X;
                            mdy = e.Y;


                            PointF point1 = new PointF(mdx, mdy);
                            //Console.WriteLine("Point 1 " + point1);


                            int index = 0;
                            object nearestobject = null;
                            PointF clickedPoint = new PointF(e.X, e.Y);
                            zedGraphControl1.GraphPane.FindNearestObject(clickedPoint, this.CreateGraphics(), out
                            nearestobject, out index);

                            double x;
                            double y;
                            double x1;
                            double x2;
                            pane.ReverseTransform(point1, out x, out y, out x1, out x2);
                            Console.Out.WriteLine(x + " " + y +" " + x1 + " " + x2);




                            return false;
                        }


                        private bool zedGraphControl1_MouseUpEvent(ZedGraphControl sender, MouseEventArgs e)
                        {

                            /*int index,i = 0;
                            object nearestobject = null;

                            PointF clickedPoint = new PointF(e.X, e.Y);
                            zedGraphControl1.GraphPane.FindNearestObject(ab, this.CreateGraphics(), out
                            nearestobject, out index);
                            Console.Out.WriteLine(" index " + index);

                            double x;
                            double y;

            
                            pane.ReverseTransform(ab, out x, out y);
                            Console.Out.WriteLine(zedGraphControl1.GraphPane.FindNearestObject(clickedPoint, this.CreateGraphics(), out
                            nearestobject, out index));
                            Console.Out.WriteLine(x + " x " + y);



                            Console.WriteLine("Index " + index);

                    */

                            return false;
                        }

                        public void ReverseTransform(object sender, MouseEventArgs e, PointF ptF)
                        {
                            ptF = new PointF(x, y);
                            Console.WriteLine("PTF " + ptF);
                        }

                        public IPointList Points { get; set; }









                        private void zedGraphControl1_MouseMove(object sender, MouseEventArgs e)
                        {
                            int x = e.X;
                            int y = e.Y;
                        }





                        // radio buttons to alter units
                        private void milesRadioButton_CheckedChanged(object sender, EventArgs e)
                        {
                            // Speed
                            AverageSpeed.Text = averagemRadioButton;
                            MaxSpeed.Text = mRadioButton + " (Mph)";

                        }

                        private void KilometersRadioButton_CheckedChanged(object sender, EventArgs e)
                        {

                            // Speed
                            AverageSpeed.Text = averagekRadioButton + " (kph)";
                            MaxSpeed.Text = kRadioButton + " (Kph)";

                        }

                        //kilometers
                        private void radioButton2_CheckedChanged(object sender, EventArgs e)
                        {
                            TotalDistance.Text = ktotalDistanceRadioButton;
                        }
                        //meters
                        private void radioButton1_CheckedChanged(object sender, EventArgs e)
                        {
                            TotalDistance.Text = mtotalDistanceRadioButton;
                        }

                        private void FeetRadioButton_CheckedChanged(object sender, EventArgs e)
                        {
                            AverageAltitude.Text = averagefeetRadioButton;
                            MaxAltitude.Text = feetRadioButton;
                        }

                        private void MetersRadioButton_CheckedChanged(object sender, EventArgs e)
                        {
                            AverageAltitude.Text = averagemetersRadioButton;
                            MaxAltitude.Text = metersRadioButton;
                        }

                        //graph radio buttons
                        private void powerGraphRadioButton_CheckedChanged(object sender, EventArgs e)
                        {
                            pane.Title.Text = "Power Data";
                            pane.YAxis.Title.Text = "Power (Watts)";

                            powerCurve.Line.IsVisible = true;
                            heartRateCurve.Line.IsVisible = false;
                            speedCurve.Line.IsVisible = false;
                            altitudeCurve.Line.IsVisible = false;
                            cadenceCurve.Line.IsVisible = false;

                            zedGraphControl1.Refresh();
                            this.Controls.Add(zedGraphControl1);
                        }


                        private void altitudeGraphRadioButton_CheckedChanged(object sender, EventArgs e)
                        {
                            pane.Title.Text = "Altitude Data";

                            if (characters[7] == '0')
                            { pane.YAxis.Title.Text = "Altitude (m)"; }
                            else if (characters[7] == '1')
                            { pane.YAxis.Title.Text = "Altitude (ft)"; }

                            altitudeCurve.Line.IsVisible = true;
                            heartRateCurve.Line.IsVisible = false;
                            speedCurve.Line.IsVisible = false;
                            powerCurve.Line.IsVisible = false;
                            cadenceCurve.Line.IsVisible = false;

                            zedGraphControl1.Refresh();
                            this.Controls.Add(zedGraphControl1);
                        }

                        private void cadenceGraphRadioButton_CheckedChanged(object sender, EventArgs e)
                        {
                            pane.Title.Text = "Cadence Data";
                            pane.YAxis.Title.Text = "Cadence (rpm)";

                            cadenceCurve.Line.IsVisible = true;
                            heartRateCurve.Line.IsVisible = false;
                            speedCurve.Line.IsVisible = false;
                            altitudeCurve.Line.IsVisible = false;
                            powerCurve.Line.IsVisible = false;

                            zedGraphControl1.Refresh();
                            this.Controls.Add(zedGraphControl1);
                        }

                        private void heartRateGraphRadioButton_CheckedChanged(object sender, EventArgs e)
                        {
                            pane.Title.Text = "Heart Rate Data";
                            pane.YAxis.Title.Text = "Heart Rate (bpm)";

                            heartRateCurve.Line.IsVisible = true;
                            powerCurve.Line.IsVisible = false;
                            speedCurve.Line.IsVisible = false;
                            altitudeCurve.Line.IsVisible = false;
                            cadenceCurve.Line.IsVisible = false;

                            zedGraphControl1.Refresh();
                            this.Controls.Add(zedGraphControl1);
                        }

                        private void speedGraphRadioButton_CheckedChanged(object sender, EventArgs e)
                        {
                            pane.Title.Text = "Speed Data";

                            if (characters[7] == '0')
                            { pane.YAxis.Title.Text = "Speed (Mph)"; }
                            else if (characters[7] == '1')
                            { pane.YAxis.Title.Text = "Speed (Kph)"; }


                            speedCurve.Line.IsVisible = true;
                            heartRateCurve.Line.IsVisible = false;
                            powerCurve.Line.IsVisible = false;
                            altitudeCurve.Line.IsVisible = false;
                            cadenceCurve.Line.IsVisible = false;

                            zedGraphControl1.Refresh();
                            this.Controls.Add(zedGraphControl1);
                        }

                        private void allGraphsRadioButton_CheckedChanged(object sender, EventArgs e)
                        {
                            pane.Title.Text = "Bike Data";
                            pane.YAxis.Title.Text = "All Data";

                            heartRateCurve.Line.IsVisible = true;
                            speedCurve.Line.IsVisible = true;
                            altitudeCurve.Line.IsVisible = true;
                            cadenceCurve.Line.IsVisible = true;
                            powerCurve.Line.IsVisible = true;

                            zedGraphControl1.Refresh();
                            this.Controls.Add(zedGraphControl1);
                        }


                        //Calculating the metrics
                        // If null statement needed
                        private void calculateFTPButton_Click(object sender, EventArgs e)
                        {
                            //FTP
                            double FTP = Convert.ToDouble(FTPTextBox.Text);
                            FTPLabel.Text = FTPTextBox.Text;

                            // Intensity Factor
                            string h = FTPTextBox.Text.ToString();
                            double y = Convert.ToDouble(h);
                            intensityFactor = normalizedPower / y;
                            IntensityFactorLabel.Text = intensityFactor.ToString("0.##");

                            //TSS TSS = (sec x NP® x IF®)/(FTP x 3600) x 100
                            // if IF = 1 tss 100 at an hour
                            double TSS = ((timeInterval * normalizedPower * intensityFactor) / ((FTP * 3600))*100);
                            TSSLabel.Text = TSS.ToString("#.##");



                            Console.WriteLine("Time " + timeInterval);
                            Console.WriteLine("NP " + normalizedPower);
                            Console.WriteLine("IF " + intensityFactor);
                            Console.WriteLine("FTP " + FTP);
                            Console.WriteLine("TSS " + TSS);

                        }


                        private void calculateIntervalButton_Click(object sender, EventArgs e)
                        {

                            int startInterval1 = Convert.ToInt32(startTimeTextBox.Text);
                            int endInterval = Convert.ToInt32(endTimeTextBox.Text);
                            string splitLines = "";
                            counter = 0;

                            DateTime myDate = new DateTime();

                            myDate = DateTime.ParseExact(startTimeTextBox.Text, "hhMMms",
                                    System.Globalization.CultureInfo.InvariantCulture);


                            try
                            {

                                for (int i = 0; i < lines.Length; i++)
                                {
                                    splitLine = lines[i];
                                    if (splitLine.Contains("[HRData]"))
                                    {
                                        for (int a = (i + startInterval1); a < (lines.Length - endInterval); a++)
                                        {


                                            //split lines after the title [HRData]
                                            splitLines = lines[a];
                                            splitTabs = splitLines.Split('\t'); //split tabs


                                            // Add Intervals and points
                                            convertHR1 = Convert.ToInt32(splitTabs[0]);
                                            convertSpeed1 = Convert.ToInt32(splitTabs[1]);
                                            convertCadence1 = Convert.ToInt32(splitTabs[2]);
                                            convertAltitude1 = Convert.ToInt32(splitTabs[3]);
                                            convertPower1 = Convert.ToInt32(splitTabs[4]);



                                            //sum all of the arrays
                                            sumHR += (convertHR);
                                            sumSpeed += (convertSpeed);
                                            sumAltitude += (convertAltitude);
                                            sumPower += (convertPower);





                                            // Find the min/max values
                                            //HR
                                            int maxHeartRate = (int)(convertHR1);
                                            int minHeartRate = (int)(convertHR1);

                                            if (maxHeartRate > maxhr1)
                                            { maxhr1 = maxHeartRate; }

                                            if (minHeartRate < minhr1)
                                            { minhr1 = minHeartRate; }

                                            // speed
                                            maxSpeed = (int)(convertSpeed1);
                                            if (maxSpeed > maxs1)
                                            { maxs1 = maxSpeed; }


                                            // power
                                            int maxPower = (int)(convertPower1);
                                            if (maxPower > maxp1)
                                            { maxp1 = maxPower; }

                                            // altitude
                                            int maxAltitude = (int)(convertAltitude1);
                                            if (maxAltitude > maxa1)
                                            { maxa1 = maxAltitude; }



                                            // Set Time (xaxis)
                                            dt1 = theStartTime.AddMilliseconds(((timeInterval * counter) * 1000));
                                            time = dt1.ToString("HH:mm:ss.f");
                                            axisTime1 = (double)new XDate(dt1.Year, dt1.Month, dt1.Day, dt1.Hour, dt1.Minute, dt1.Second + startInterval1, dt1.Millisecond);

                                            // Add points into point list
                                            heartRateArray1.Add(axisTime1, convertHR1);
                                            speedArray1.Add(axisTime1, convertSpeed1);
                                            kmspeedArray1.Add(axisTime1, convertSpeed1 * 1.60934);
                                            altitudeArray1.Add(axisTime1, convertAltitude1);
                                            ftaltitudeArray1.Add(axisTime1, convertAltitude1 * 3.28084);
                                            powerArray1.Add(axisTime1, convertPower1);
                                            cadenceArray1.Add(axisTime1, convertCadence1);


                          

                                            counter++;
                                        }




                                        // Labels
                                        // HR
                                        string maxLabel = maxhr1.ToString();
                                        string minLabel = minhr1.ToString();
                                        averageHeartRate = sumHR / count;
                                        HeartRate.Text = averageHeartRate.ToString("#.##") + " (bpm)";
                                        maxHR.Text = maxLabel + " (bpm)";
                                        minHR.Text = minLabel + " (bpm)";
                                        Console.Out.WriteLine("Average HR " + averageHeartRate);


                                        // US unit
                                        if (characters[7] == '0')
                                        {
                                            // Speed
                                            maxs1 = maxs1 / 10;
                                            maxSpeedLabel = maxs1.ToString("#.##");
                                            averageSpeed = (sumSpeed / count) / 10;
                                            AverageSpeed.Text = averageSpeed.ToString("#.##") + " (Mph)";
                                            MaxSpeed.Text = maxSpeedLabel + " (Mph)";

                                            double kiloSpeed = maxs1 * 1.60934;
                                            double averageKiloSpeed = averageSpeed * 1.60934;
                                            mRadioButton = maxSpeedLabel;
                                            averagemRadioButton = averageSpeed.ToString("#.##") + " (Mph)";
                                            kRadioButton = kiloSpeed.ToString("#.##");
                                            averagekRadioButton = averageKiloSpeed.ToString("#.##");

                                            // Total distance
                                            double totalDistance = (averageSpeed / 3600) * theLength.TotalMilliseconds / 1000; // 60 x 60 (mins and secs)
                                            double kiloTotalDistance = (averageKiloSpeed / 3600) * theLength.TotalMilliseconds / 1000;
                                            TotalDistance.Text = totalDistance.ToString("#.##") + " (Miles)";
                                            mtotalDistanceRadioButton = totalDistance.ToString("#.##") + " (Miles)";
                                            ktotalDistanceRadioButton = kiloTotalDistance.ToString("#.##") + " (Kilometers)";

                                            // Altitude
                                            string maxAltitudeLabel = maxa1.ToString();
                                            averageAltitude = sumAltitude / count;
                                            AverageAltitude.Text = averageAltitude.ToString("#.##") + " (m)";
                                            MaxAltitude.Text = maxAltitudeLabel + " (m)";

                                            double feet = maxa1 * 3.28084;
                                            double averagefeet = averageAltitude * 3.28084;
                                            averagemetersRadioButton = averageAltitude.ToString("#.##") + " (m)";
                                            metersRadioButton = maxAltitudeLabel + " (m)";
                                            averagefeetRadioButton = averagefeet.ToString("#.##") + " (ft)";
                                            feetRadioButton = feet.ToString("#.##") + " (ft)";

                                            milesRadioButton.Checked = true;
                                            MetersRadioButton.Checked = true;
                                            radioButton1.Checked = true;


                                        }
                                        else if (characters[7] == '1')
                                        {
                                            // Speed
                                            maxs1 = (maxs1 * 1.60934) / 10;
                                            maxSpeedLabel = maxs1.ToString("#.##");
                                            averageSpeed = (((sumSpeed / count) / 10) * 1.60934);
                                            AverageSpeed.Text = averageSpeed.ToString("#.##") + " (Kph)";
                                            MaxSpeed.Text = maxSpeedLabel + " (Kph)";

                                            double milesSpeed = maxs1 / 1.60934;
                                            double averageMilesSpeed = averageSpeed / 1.60934;
                                            mRadioButton = milesSpeed.ToString("#.##");
                                            averagemRadioButton = averageSpeed.ToString("#.##") + " (Mph)";
                                            kRadioButton = maxSpeedLabel;
                                            averagekRadioButton = averageSpeed.ToString("#.##") + " (Kph)";

                                            double totalDistance = (averageSpeed / 3600) * theLength.TotalMilliseconds / 1000; // 60 x 60 (mins and secs)
                                            double milesTotalDistance = (averageMilesSpeed / 3600) * theLength.TotalMilliseconds / 1000;
                                            TotalDistance.Text = totalDistance.ToString("#.##") + " (Kilometers)";
                                            ktotalDistanceRadioButton = totalDistance.ToString("#.##") + " (Kilometers)";
                                            mtotalDistanceRadioButton = milesTotalDistance.ToString("#.##") + " (Miles)";

                                            // Altitude
                                            maxa1 = maxa1 * 3.28084;
                                            string maxAltitudeLabel = maxa1.ToString("#.##");
                                            averageAltitude = (sumAltitude / count) * 3.28084;
                                            AverageAltitude.Text = averageAltitude.ToString("#.##") + " (ft)";
                                            MaxAltitude.Text = maxAltitudeLabel + " (ft)";

                                            double meters = maxa1 / 3.28084;
                                            double averagemeters = averageAltitude / 3.28084;
                                            averagefeetRadioButton = averageAltitude.ToString("#.##") + " (ft)";
                                            feetRadioButton = maxAltitudeLabel + " (ft)";
                                            averagemetersRadioButton = averagemeters.ToString("#.##") + " (m)";
                                            metersRadioButton = meters.ToString() + " (m)";

                                            //set radiobuttons to true
                                            KilometersRadioButton.Checked = true;
                                            FeetRadioButton.Checked = true;
                                            radioButton2.Checked = true;

                                        }

                                        // Power
                                        string maxPowerLabel = maxp1.ToString();
                                        averagePower = sumPower / count;
                                        AveragePower.Text = averagePower.ToString("#.##") + " (W)";
                                        MaxPower.Text = maxPowerLabel + " (W)";

                                        NormalizedPowerLabel.Text = normalizedPower.ToString("#.##");
                                    }


                                }
                        
                


             



                                // xAxis
                                pane.XAxis.Type = AxisType.Date;
                                pane.XAxis.Scale.Format = "HH:mm:ss";
                                pane.XAxis.Scale.MajorUnit = DateUnit.Minute;
                                pane.XAxis.Scale.MinorUnit = DateUnit.Minute;


                                // ZedGraph generate pane

                                if (characters[7] == '0')
                                {
                                    heartRateCurve.Line.IsVisible = false;
                                    speedCurve.Line.IsVisible = false;
                                    powerCurve.Line.IsVisible = false;
                                    cadenceCurve.Line.IsVisible = false;
                                    altitudeCurve.Line.IsVisible = false;


                                    heartRateCurve = pane.AddCurve("Heart Rate", heartRateArray1, Color.Black, SymbolType.Circle);
                                    heartRateCurve.Line.IsVisible = true;
                                    heartRateCurve.Line.Width = 1.0F;
                                    heartRateCurve.Symbol.Size = 0F;

                                    speedCurve = pane.AddCurve("Speed", speedArray1, Color.Brown, SymbolType.Circle);
                                    speedCurve.Line.IsVisible = true;
                                    speedCurve.Line.Width = 1.0F;
                                    speedCurve.Symbol.Size = 0F;


                                    altitudeCurve = pane.AddCurve("Altitude", altitudeArray1, Color.Blue, SymbolType.Circle);
                                    altitudeCurve.Line.IsVisible = true;
                                    altitudeCurve.Line.Width = 1.0F;
                                    altitudeCurve.Symbol.Size = 0F;

                                    powerCurve = pane.AddCurve("Power", powerArray1, Color.Green, SymbolType.Circle);
                                    powerCurve.Line.IsVisible = true;
                                    powerCurve.Line.Width = 1.0F;
                                    powerCurve.Symbol.Size = 0F;

                                    cadenceCurve = pane.AddCurve("Cadence", cadenceArray1, Color.Yellow, SymbolType.Circle);
                                    cadenceCurve.Line.IsVisible = true;
                                    cadenceCurve.Line.Width = 1.0F;
                                    cadenceCurve.Symbol.Size = 0F;
                                    pane.Legend.IsVisible = true;

                                    pane.AxisChange();

                                    if (characters[0] == '0')
                                    {
                                        speedCurve.Line.IsVisible = false;
                                    }

                                    if (characters[1] == '0')
                                    { cadenceCurve.Line.IsVisible = false; }

                                    if (characters[2] == '0')
                                    { altitudeCurve.Line.IsVisible = false; }

                                    if (characters[3] == '0')
                                    { powerCurve.Line.IsVisible = false; }

                                    if (characters[6] == '0')
                                    {
                                        speedCurve.Line.IsVisible = false;
                                        heartRateCurve.Line.IsVisible = false;
                                        cadenceCurve.Line.IsVisible = false;
                                        altitudeCurve.Line.IsVisible = false;
                                    }
                                }






                                pane.AxisChange();
                                //Refresh Graph     
                                zedGraphControl1.Refresh();
                                this.Controls.Add(zedGraphControl1);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error: Unable to open file. Original error: " + ex.Message);
                            }

            








                        }



                    }
                }
