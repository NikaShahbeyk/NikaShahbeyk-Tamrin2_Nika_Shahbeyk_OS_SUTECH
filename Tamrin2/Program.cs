//Tamrin 2_Nika Shahbeyk_Shiraz University Of Technology_Student ID: 400213013
using System;
using System.Management;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("====================================================");
        Console.WriteLine("Program is Runnning");

        //making a Management Event Watcher
        ManagementEventWatcher eventwatcher = new ManagementEventWatcher();

        //making a String for query
        String query1 = "SELECT * FROM __InstanceCreationEvent WITHIN 1 WHERE TargetInstance ISA 'Win32_DiskDrive'";

        //making Wql Event Query
        WqlEventQuery query = new WqlEventQuery(query1);

        eventwatcher.Query = query;

        eventwatcher.Start();

        Console.WriteLine("Please Enter a USB into your Device!");
        Console.WriteLine("note: Every time that you do not want to continue press a key to exit!!! ");

        USBINSYSTEM(eventwatcher);

        Console.ReadKey();
  
        eventwatcher.Stop();

    }

    static bool USB = false;

    static void USBINSYSTEM(ManagementEventWatcher eventwatcher)
    {
        eventwatcher.EventArrived += (sender, e) =>
        {
            Console.WriteLine("USB is connected!");
            String program = "mspaint";
            USB = true;
            StartingProcess(program);
        };
    }


    static void StartingProcess(String name)
    {
        Console.WriteLine(name + " is running!" );
        try
        {
          Process.Start(name);
        }
        catch(Exception e)
        {
            Console.WriteLine("error message: " , e.Message);
        }
    }

}
