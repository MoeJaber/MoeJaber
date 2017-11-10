using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using MetroFramework.Forms;
using LiveCharts.Defaults;
using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.ObjectModel;
using System.Threading;

//http://open.canada.ca/en/open-government-licence-canada 

/**
 * Author : Mouhamad Jaber
 * Assignment 3
 * */
namespace Assignment_3_Jaber_Mouhamad
{
    public partial class main : MetroForm
    {
        //initialize a collection og DataFromCSV objects
        private static ObservableCollection<DataFromCSV> rowResults = new ObservableCollection<DataFromCSV>();
      

        public main()
        {
            //peform initial building
            InitializeComponent();
            //read the excel document 
            ReadCSV();
            //populate the datarowgrid component on the GUI
            PopulateGrid();
        
            //foreach(var s in rowResults)
            //{
            //    Console.WriteLine("---------\n" + s.Ref_Date + "\n" + s.GEO + "\n" + s.EST + "\n" + s.Vector + "\n" + s.Coordinate + "\n" + s.Value + "\n" + s.Geography + "\n" + s.Area + "\n-------- ");
            //}

           
        }//end of main

        private void main_Load(object sender, EventArgs e)
        {
            //execute thread on a ThreadStart delegate on a instance method for counter 1
            ThreadStart readFileThread = new ThreadStart(ReadCSV);
            //create thread1 using the threadCounter1 delegate
            Thread IOthread = new Thread(readFileThread);
            //start the thread to a status of running when the form is loaded.
            IOthread.Start();
        }
        /// <returns> no value</returns>
        public void ReadCSV()
        {
            //initial max number of columns expected
            int numOfColumns = 6;

            try
            {
                //use microsoft visual basic object TextFieldParser to parse excel file
                using (TextFieldParser parser = new TextFieldParser(@"C:\Users\Moe\Desktop\00010014-eng.csv"))
                {
                    //set type to be delimited
                    parser.TextFieldType = FieldType.Delimited;
                    //set delimiter on commas
                    parser.SetDelimiters(",");

                    //Processing row
                    try
                    {
                        //stored the parsed object into a string array
                        string[] col = parser.ReadFields();


                        for (var x = 0; x < numOfColumns; x++)
                        {
                            //add the first 6 values as the columns
                            ColNames.Columns.Add(col[x]);
                        }
                    }
                    //check for an exception null objects
                    catch (Exception ex) { Console.WriteLine(ex); }

                    //while the object has data
                    while (!parser.EndOfData)
                    {
                        //stored the parsed object into a string array
                        string[] fields = parser.ReadFields();
                        //split the vector columns on periods
                        string[] array = fields[4].Split(new char[] { '.' }).Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                        //send the array to be decrypted into meaniful values
                        var result = decrypt(array);
                        //add the row values to the collection rowResults
                        rowResults.Add(new DataFromCSV() { Ref_Date = fields[0], GEO = fields[1], EST = fields[2], Vector = fields[3], Coordinate = fields[4], Value = fields[5], Geography = result.Item1, Area = result.Item2 });
                    }
                }
            }
            catch (Exception e) { }
        }//end of ReadCSV
        /// <returns>two strings as tuple</returns>
        public Tuple<string, string> decrypt(string[] x)
        {
            string loc = "";
            string production = "";
            //convert the two strings parameters to integers
            var geography = Convert.ToInt16(x[0]);
            var area = Convert.ToInt16(x[1]);

            //replace the loc properties based on the geography value
            switch (geography)
            #region                   
            {
                case 1: //Canada
                    loc = "Canada";
                    break;
                case 2: //Newfoundland and Labrador
                    loc = "Newfoundland and Labrador";
                    break;
                case 3: //Prince Edward Island
                    loc = "Prince Edward Island";
                    break;
                case 4: //Nova Scotia
                    loc = "Nova Scotia";
                    break;
                case 5: //New Brunswick
                    loc = "New Brunswick";
                    break;
                case 6: //Quebec
                    loc = "Quebec";
                    break;
                case 7: //Ontario
                    loc = "Ontario";
                    break;
                case 8: //Manitoba
                    loc = "Manitoba";
                    break;
                case 9: //Saskatchewan
                    loc = "Saskatchewan";
                    break;
                case 10: //Alberta
                    loc = "Alberta";
                    break;
                case 11: //British Columbia
                    loc = "British Columbia";
                    break;
                    #endregion
            }

            //replace the production properties based on the area value
            switch (area)
            #region                   
            {
                case 1: //Seeded area, potatoes (acres) 
                    production = "Seeded area, potatoes (acres) ";
                    break;
                case 2: //Average yield, potatoes (hundredweight per harvested acres)
                    production = "Average yield, potatoes (hundredweight per harvested acres)";
                    break;
                case 3: //Production, potatoes (hundredweight)
                    production = "Production, potatoes (hundredweight)";
                    break;
                case 4: //Average farm price, potatoes (dollars per hundredweight)                        
                    production = "Average farm price, potatoes (dollars per hundredweight)";
                    break;
                case 5: //Total farm value, potatoes (dollars)
                    production = "Total farm value, potatoes (dollars)";
                    break;
                case 6: //Harvested area, potatoes (acres)
                    production = "Harvested area, potatoes (acres)";
                    break;
                case 7: //Amount sold, consumed, seeded or fed to livestock, potatoes (hundredweight)
                    production = "Amount sold, consumed, seeded or fed to livestock, potatoes (hundredweight)";
                    break;
                #endregion
          
            }
            //stored the loc and production values into a tuple
            Tuple<string, string> info = new Tuple<string, string>(loc, production);
            //return tuple
            return info;
        }
        //bind data the the datagrid
        public void PopulateGrid()
        {
            try
            {
                //initialize max columns
                metroGrid1.ColumnCount = 6;
                //declare the column names
                metroGrid1.Columns[0].HeaderText = ColNames.Columns[0];
                metroGrid1.Columns[1].HeaderText = ColNames.Columns[1];
                metroGrid1.Columns[2].HeaderText = ColNames.Columns[2];
                metroGrid1.Columns[2].Width = 300;
                metroGrid1.Columns[3].HeaderText = ColNames.Columns[3];
                metroGrid1.Columns[4].HeaderText = ColNames.Columns[4];
                metroGrid1.Columns[5].HeaderText = ColNames.Columns[5];

                //access each row in the collection and bind them as a row in the datagrid
                foreach (var row in rowResults)
                {
                    metroGrid1.Rows.Add(row.Ref_Date, row.GEO, row.EST, row.Vector, row.Coordinate, row.Value);
                }
            }
            catch (Exception e) { }
        }//end of populategrid
        //initialize a public class to store column names
        public class ColNames
        {
            public static List<String> Columns = new List<string>();
        }

        //getters and setters from each columns in the excel file
        internal class DataFromCSV
        {
            //initialize getters and setters
            public String Ref_Date { get; set; }
            public String GEO { get; set; }
            public String EST { get; set; }
            public String Vector { get; set; }
            public String Coordinate { get; set; }
            public String Value { get; set; }
            public String Geography { get; set; }
            public String Area { get; set; }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Bitmap map = new Bitmap(pictureBox1.Image);
            Color chosen = map.GetPixel(e.X, e.Y);
            Console.WriteLine(chosen.Name);
            String name = provinceDecrypt(chosen.Name);
            provinceLabel.Text = name;


        }

        public String provinceDecrypt(String chosen)
        {

            switch (chosen)
            #region                   
            {
                case "ff7b00ff": //Yukon
                    chosen = "Yukon";
                    break;
                case "ff2184ff": //Nunavut
                    chosen = "Nunavut";
                    break;
                case "ff9e6dff": //Northwest Territories
                    chosen = "Northwest Territories";
                    break;
                case "ff82b4ff": //Newfoundland and Labrador
                    chosen = "Newfoundland and Labrador";
                    break;
                case "ff00ff08": //Prince Edward Island
                    chosen = "Prince Edward Island";
                    break;
                case "ff0f0fff": //Nova Scotia
                    chosen = "Nova Scotia";
                    break;
                case "ffff476c": //New Brunswick
                    chosen = "New Brunswick";
                    break;
                case "ff51ff9c": //Quebec
                    chosen = "Quebec";
                    break;
                case "ffff0a0a": //Ontario
                    chosen = "Ontario";
                    break;
                case "ffff3593": //Manitoba
                    chosen = "Manitoba";
                    break;
                case "ffffbf00": //Saskatchewan
                    chosen = "Saskatchewan";
                    break;
                case "ffff8800": //Alberta
                    chosen = "Alberta";
                    break;
                case "ff46ff2d": //British Columbia
                    chosen = "British Columbia";
                    break;
                    #endregion
            }

            return chosen;
        }//end method
    }
}
