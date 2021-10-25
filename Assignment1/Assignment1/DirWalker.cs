using System;
using System.IO;

namespace Assignment1
{
  

    public class DirWalker
    {

        public void walk(String path, ref string content,ref int errorcount, ref int normalcount)
        {

            string[] list = Directory.GetDirectories(path);

            if (list == null) return;

            foreach (string dirpath in list)
            {
                if (Directory.Exists(dirpath))
                {
                    walk(dirpath, ref content,ref errorcount,ref normalcount);
                   // Console.WriteLine("Dir:" + dirpath);
                }
            }
            string[] fileList = Directory.GetFiles(path,"*.csv");
            foreach (string filepath in fileList)
            {
                SimpleCSVParser csv = new SimpleCSVParser();
                csv.parse(filepath, ref content, ref errorcount, ref normalcount);
                    //Console.WriteLine("File:" + filepath);
            }
            File.AppendAllText("E:\\SoftwareClass\\output\\result\\.csv", content);
            content = "";
        }

        public static void Main(String[] args)
        {

            string content = "";
            int errorcount = 0;int normalcount = 0;
            File.WriteAllText("E:\\SoftwareClass\\output\\result.csv", "");


            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();

            

            watch.Stop();

           long time = watch.ElapsedMilliseconds;

            DirWalker fw = new DirWalker();
            fw.walk("E:\\SoftwareClass\\Sample Data", ref content, ref errorcount,ref normalcount);

            File.AppendAllText("E:\\SoftwareClass\\output\\result.csv", "total skipped records-" + errorcount + " total records-" + normalcount + " time taken ms:" + time);
            
        }

    }
}
