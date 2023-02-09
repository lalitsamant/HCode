using HCode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

#region Startup
string filePath = @"c:\hcode\Sample Activities.csv";
IEnumerable<string> strCSV = File.ReadLines(filePath);

var results = from str in strCSV
              let tmp = str.Split(',')
              select new ActClass
              {
                  ActRef = tmp[0],
                  ActStartdate = tmp[1],
                  ActEnddate = tmp[2],
                  ActWeekPattern = tmp[3],
                  Activity = tmp[4]
              };

var query = results.Skip(1).ToList();
ArrayList ActList = new ArrayList();

foreach (var x in query)
{
    string ARef = x.ActRef;
    var WPlen = x.ActWeekPattern.Length;
    var i = 1;
    var ActDate = x.ActStartdate;
    var ActSDate = x.ActStartdate;
    var ActEDate = x.ActEnddate;
    
    ActList.Add(new Activity { ActRef = ARef, ActDate = ActSDate, ActActivity = x.Activity });
    ActList.Add(new Activity { ActRef = ARef, ActDate = ActEDate, ActActivity = x.Activity });

    while (i < WPlen-1) 
    {
        string WP = x.ActWeekPattern.Substring(i, 1);
        if (!string.IsNullOrWhiteSpace(WP)) 
        {
            ActList.Add(new Activity { ActRef = ARef, ActDate = DateTime.Parse(ActDate).AddDays(7).ToString(), ActActivity = x.Activity });
            ActDate = DateTime.Parse(ActDate).AddDays(7).ToString();
        }
        else
        {
            ActDate = DateTime.Parse(ActDate).AddDays(7).ToString();
        }
        i++;
    }
}

foreach (var x in query)
{
    string ARef1 = x.ActRef;
    string ASDate = x.ActStartdate;

    List<Activity> list1 = ActList.Cast<Activity>().ToList();
    Console.WriteLine("Activity :" + ARef1);
    Console.WriteLine("Clashes With :");
    foreach (var y in list1)
    {
        if (ARef1 == y.ActRef && ASDate == y.ActDate) 
        {           
        }
        else 
        {
            if (ASDate == y.ActDate)
            {
                Console.WriteLine("     " + y.ActRef + " on " + y.ActDate + " - " + y.ActActivity);
            }
        }
    }
    Console.WriteLine("");
}
Console.WriteLine("_____________");
Console.WriteLine("End of Report");
#endregion