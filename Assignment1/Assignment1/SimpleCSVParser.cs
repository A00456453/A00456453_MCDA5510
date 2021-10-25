using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace Assignment1
{
    public class SimpleCSVParser
    {


        //       public static void Main(String[] args)
        //       {
        //           SimpleCSVParser parser = new SimpleCSVParser();
        //           parser.parse(@"/Users/dpenny/Projects/Assignment1/Assignment1/sampleFile.csv");
        //       }


        public void parse(String fileName, ref string content, ref int Skipped, ref int normalcount)
        {
            try
            {
                //int Header = 0;
                int i = 0;
                //int Skipped = 0;
                string result="";
                using (TextFieldParser parser = new TextFieldParser(fileName))
                {
                    i = 0;
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    while (!parser.EndOfData)
                    {
                        i = 0;
                        result = "";
                        //Process row
                        string[] fields = parser.ReadFields();
                        foreach (string field in fields)
                        {
                            if (field!="")
                            {
                                result +=  field + ",";
                            }
                            else
                            {
                                i = 1;
                                break;
                            }
                            //Console.WriteLine(field);
                        }

                        if (i != 1)
                        {
                            content += result;
                            content = content.Substring(0, content.Length - 1);
                            content += "\r\n";
                            normalcount++;
                        }
                        else
                            Skipped++;
                    }
                }

            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.StackTrace);
            }

        }


    }
}
