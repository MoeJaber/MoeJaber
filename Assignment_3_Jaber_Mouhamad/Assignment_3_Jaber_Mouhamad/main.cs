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

//http://open.canada.ca/en/open-government-licence-canada 

namespace Assignment_3_Jaber_Mouhamad
{
    public partial class main : MetroForm
    {
        private static ObservableCollection<DataFromCSV> rowResults = new ObservableCollection<DataFromCSV>();
      

        public main()
        {
            InitializeComponent();
            ReadCSV();
            PopulateGrid();
        
            //foreach(var s in rowResults)
            //{
            //    Console.WriteLine("---------\n" + s.Ref_Date + "\n" + s.GEO + "\n" + s.EST + "\n" + s.Vector + "\n" + s.Coordinate + "\n" + s.Value + "\n" + s.Geography + "\n" + s.Area + "\n-------- ");
            //}

           
        }//end of main

        public void ReadCSV()
        {
            int numOfColumns = 6;
            string loc = "";
            string production = "";

            using (TextFieldParser parser = new TextFieldParser(@"C:\Users\Jaber.M.GDC\Downloads\00010014-eng\00010014-eng.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
               
                    //Processing row
                    string[] col = parser.ReadFields();

                    for (var x = 0; x < numOfColumns; x++)
                    {
                        ColNames.Columns.Add(col[x]);
                    }

                while (!parser.EndOfData)
                {
                   
                    string[] fields = parser.ReadFields();

                    string [] array = fields[4].Split(new char[] { '.' }).Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                    var geography = Convert.ToInt16(array[0]);
                    var area = Convert.ToInt16(array[1]);                  

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

                    rowResults.Add(new DataFromCSV() { Ref_Date = fields[0], GEO = fields[1], EST = fields[2], Vector = fields[3], Coordinate = fields[4], Value = fields[5], Geography = loc, Area = production });
               }
            }
        }//end of ReadCSV

        public void PopulateGrid()
        {
            metroGrid1.ColumnCount = 6;
            metroGrid1.Columns[0].Name = ColNames.Columns[0];
            metroGrid1.Columns[1].Name = ColNames.Columns[1];
            metroGrid1.Columns[2].Name = ColNames.Columns[2];
            metroGrid1.Columns[3].Name = ColNames.Columns[3];
            metroGrid1.Columns[4].Name = ColNames.Columns[4];
            metroGrid1.Columns[5].Name = ColNames.Columns[5];

            foreach(var row in rowResults)
            {
                metroGrid1.Rows.Add(row.Ref_Date, row.GEO, row.EST, row.Vector,row.Coordinate, row.Value);
            }

        }//end of populategrid

        public class ColNames
        {
            public static List<String> Columns = new List<string>();
        }

        internal class DataFromCSV
        {
            public String Ref_Date { get; set; }
            public String GEO { get; set; }
            public String EST { get; set; }
            public String Vector { get; set; }
            public String Coordinate { get; set; }
            public String Value { get; set; }
            public String Geography { get; set; }
            public String Area { get; set; }
        }
    }
}
