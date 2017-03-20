using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;



namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        string[] lines, splitTabs;
        string splitLine;
        double convertHR;

        

        /// <summary>
        /// store points pair list
        /// </summary>
        [TestMethod]
        public void Testpointlist()
        {
            List<double> heartRateList = new List<double>();
            double[] heartRateArrayList;

            string[] lines, splitTabs;
            string splitLine;
            double convertHR;

            lines = File.ReadAllLines("F:/August2012DataForCalandar/12080101.hrm");
            for (int i = 0; i < lines.Length; i++)
            {

                splitLine = lines[i];
                if (splitLine.Contains("[HRData]"))
                {
                    for (int a = (i + 1); a < lines.Length; a++)
                    {
                        string splitA = lines[a];
                        splitTabs = splitA.Split('\t');
                        convertHR = Convert.ToInt32(splitTabs[0]);
                        heartRateList.Add(convertHR);
                        heartRateArrayList = heartRateList.ToArray();
                    }
                }
            }

        }



        /// <summary>
        /// High score
        /// </summary>
        [TestMethod]

        public void TestHighest()
        {
            // altitude
            int altitude = 300;
            int maxa = 100;
            int maxAltitude = altitude;
            if (maxAltitude > maxa)
            { maxa = maxAltitude; }
        }

        /// <summary>
        /// Split line
        /// </summary>
        [TestMethod]

        public void TestSplit()
        {
            string[] lines;
            string splitLine;
            char[] characters;
            lines = File.ReadAllLines("F:/August2012DataForCalandar/12080101.hrm");

            for (int i = 0; i < lines.Length; i++)
            {
                splitLine = lines[i];
                
                if (splitLine.Contains("SMode"))
                {
                    string[] splitTitle = lines[i].Split('=');
                    string smode = splitTitle[1]; //label name
                    characters = smode.ToCharArray(); // split smode into char array
                }
            }
        }


        /// <summary>
        /// sum arrays
        /// </summary>
        [TestMethod]

        public void TestSumArrays()
        {
            string[] lines, splitTabs;
            string splitLine;
            double convertHR, sumHR = 0;

            lines = File.ReadAllLines("F:/August2012DataForCalandar/12080101.hrm");
            for (int i = 0; i < lines.Length; i++)
            {
                
                splitLine = lines[i];
                if (splitLine.Contains("[HRData]"))
                {
                    for (int a = (i + 1); a < lines.Length; a++)
                    {
                        string splitA = lines[a];
                        splitTabs = splitA.Split('\t');
                        convertHR = Convert.ToInt32(splitTabs[0]);
                        sumHR += (convertHR);
                    }
                }
            }
        }
    }
}
