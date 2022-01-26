using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

public static class HardwareInfo
{

    public static String GetProcessorId()
    {

        ManagementClass mc = new ManagementClass("win32_processor");
        ManagementObjectCollection moc = mc.GetInstances();
        String Id = String.Empty;
        foreach (ManagementObject mo in moc)
        {

            Id = mo.Properties["processorID"].Value.ToString();
            break;
        }
        return Id;

    }

    public static String GetHDDSerialNo()
    {
        ManagementClass mangnmt = new ManagementClass("Win32_LogicalDisk");
        ManagementObjectCollection mcol = mangnmt.GetInstances();
        string result = "";
        foreach (ManagementObject strt in mcol)
        {
            result += Convert.ToString(strt["VolumeSerialNumber"]);
        }
        return result;
    }

    public static string GetMACAddress()
    {
        ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
        ManagementObjectCollection moc = mc.GetInstances();
        string MACAddress = String.Empty;
        foreach (ManagementObject mo in moc)
        {
            if (MACAddress == String.Empty)
            {
                if ((bool)mo["IPEnabled"] == true) MACAddress = mo["MacAddress"].ToString();
            }
            mo.Dispose();
        }

        MACAddress = MACAddress.Replace(":", "");
        return MACAddress;
    }

    public static string GetCdRomDrive()
    {

        ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_CDROMDrive");

        foreach (ManagementObject wmi in searcher.Get())
        {
            try
            {
                return wmi.GetPropertyValue("Drive").ToString();

            }

            catch { }

        }

        return "CD ROM Drive Letter: Unknown";

    }

    public static string GetBIOSmaker()
    {

        ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");

        foreach (ManagementObject wmi in searcher.Get())
        {
            try
            {
                return wmi.GetPropertyValue("Manufacturer").ToString();

            }

            catch { }

        }

        return "BIOS Maker: Unknown";

    }

    public static string GetBIOSserNo()
    {

        ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");

        foreach (ManagementObject wmi in searcher.Get())
        {
            try
            {
                return wmi.GetPropertyValue("SerialNumber").ToString();

            }

            catch { }

        }

        return "BIOS Serial Number: Unknown";

    }

    public static string GetBIOScaption()
    {

        ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");

        foreach (ManagementObject wmi in searcher.Get())
        {
            try
            {
                return wmi.GetPropertyValue("Caption").ToString();

            }
            catch { }
        }
        return "BIOS Caption: Unknown";
    }

    public static string GetAccountName()
    {

        ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_UserAccount");

        foreach (ManagementObject wmi in searcher.Get())
        {
            try
            {

                return wmi.GetPropertyValue("Name").ToString();
            }
            catch { }
        }
        return "User Account Name: Unknown";

    }

    public static string GetNoRamSlots()
    {

        int MemSlots = 0;
        ManagementScope oMs = new ManagementScope();
        ObjectQuery oQuery2 = new ObjectQuery("SELECT MemoryDevices FROM Win32_PhysicalMemoryArray");
        ManagementObjectSearcher oSearcher2 = new ManagementObjectSearcher(oMs, oQuery2);
        ManagementObjectCollection oCollection2 = oSearcher2.Get();
        foreach (ManagementObject obj in oCollection2)
        {
            MemSlots = Convert.ToInt32(obj["MemoryDevices"]);

        }
        return MemSlots.ToString();
    }

    #region "CPU SHIT"

    public static string GetCPUManufacturer()
    {
        string cpuMan = String.Empty;
        //create an instance of the Managemnet class with the
        //Win32_Processor class
        ManagementClass mgmt = new ManagementClass("Win32_Processor");
        //create a ManagementObjectCollection to loop through
        ManagementObjectCollection objCol = mgmt.GetInstances();
        //start our loop for all processors found
        foreach (ManagementObject obj in objCol)
        {
            if (cpuMan == String.Empty)
            {
                // only return manufacturer from first CPU
                cpuMan = obj.Properties["Manufacturer"].Value.ToString();
            }
        }
        return cpuMan;
    }
    public static string GetCPUName()
    {
        string cpuMan = String.Empty;
        ManagementClass mgmt = new ManagementClass("Win32_Processor");
        ManagementObjectCollection objCol = mgmt.GetInstances();
        foreach (ManagementObject obj in objCol)
        {
            if (cpuMan == String.Empty)
            {
                cpuMan = obj.Properties["Name"].Value.ToString();
            }
        }
        return cpuMan;
    }
    public static string GetCPUDescription()
    {
        string cpuMan = String.Empty;
        ManagementClass mgmt = new ManagementClass("Win32_Processor");
        ManagementObjectCollection objCol = mgmt.GetInstances();
        foreach (ManagementObject obj in objCol)
        {
            if (cpuMan == String.Empty)
            {
                cpuMan = obj.Properties["Description"].Value.ToString();
            }
        }
        return cpuMan;
    }
    public static string GetCPUCores()
    {
        string cpuMan = String.Empty;
        ManagementClass mgmt = new ManagementClass("Win32_Processor");
        ManagementObjectCollection objCol = mgmt.GetInstances();
        foreach (ManagementObject obj in objCol)
        {
            if (cpuMan == String.Empty)
            {
                cpuMan = obj.Properties["NumberOfCores"].Value.ToString();
            }
        }
        return cpuMan;
    }
    public static string GetCPUEnabledCores()
    {
        string cpuMan = String.Empty;
        ManagementClass mgmt = new ManagementClass("Win32_Processor");
        ManagementObjectCollection objCol = mgmt.GetInstances();
        foreach (ManagementObject obj in objCol)
        {
            if (cpuMan == String.Empty)
            {
                cpuMan = obj.Properties["NumberOfEnabledCore"].Value.ToString();
            }
        }
        return cpuMan;
    }
    public static string GetCPUPID()
    {
        string cpuMan = String.Empty;
        ManagementClass mgmt = new ManagementClass("Win32_Processor");
        ManagementObjectCollection objCol = mgmt.GetInstances();
        foreach (ManagementObject obj in objCol)
        {
            if (cpuMan == String.Empty)
            {
                cpuMan = obj.Properties["ProcessorId"].Value.ToString();
            }
        }
        return cpuMan;
    }
    public static string GetCPUThreads()
    {
        string cpuMan = String.Empty;
        ManagementClass mgmt = new ManagementClass("Win32_Processor");
        ManagementObjectCollection objCol = mgmt.GetInstances();
        foreach (ManagementObject obj in objCol)
        {
            if (cpuMan == String.Empty)
            {
                cpuMan = obj.Properties["ThreadCount"].Value.ToString();
            }
        }
        return cpuMan;
    }

    #endregion


    #region GPU SHIT

    public static string GetGPUName()
    {
        string cpuMan = String.Empty;
        //create an instance of the Managemnet class with the
        //Win32_Processor class
        ManagementClass mgmt = new ManagementClass("Win32_VideoController");
        //create a ManagementObjectCollection to loop through
        ManagementObjectCollection objCol = mgmt.GetInstances();
        //start our loop for all processors found
        foreach (ManagementObject obj in objCol)
        {
            if (cpuMan == String.Empty)
            {
                // only return manufacturer from first CPU
                cpuMan = obj.Properties["Name"].Value.ToString();
            }
        }
        return cpuMan;
    }
    public static string GetGPURefresh()
    {
        string cpuMan = String.Empty;
        //create an instance of the Managemnet class with the
        //Win32_Processor class
        ManagementClass mgmt = new ManagementClass("Win32_VideoController");
        //create a ManagementObjectCollection to loop through
        ManagementObjectCollection objCol = mgmt.GetInstances();
        //start our loop for all processors found
        foreach (ManagementObject obj in objCol)
        {
            if (cpuMan == String.Empty)
            {
                // only return manufacturer from first CPU
                cpuMan = obj.Properties["CurrentRefreshRate"].Value.ToString();
            }
        }
        return cpuMan;
    }
    public static string GetGPUDriverVersion()
    {
        string cpuMan = String.Empty;
        //create an instance of the Managemnet class with the
        //Win32_Processor class
        ManagementClass mgmt = new ManagementClass("Win32_VideoController");
        //create a ManagementObjectCollection to loop through
        ManagementObjectCollection objCol = mgmt.GetInstances();
        //start our loop for all processors found
        foreach (ManagementObject obj in objCol)
        {
            if (cpuMan == String.Empty)
            {
                // only return manufacturer from first CPU
                cpuMan = obj.Properties["DriverVersion"].Value.ToString();
            }
        }
        return cpuMan;
    }



    #endregion


    public static string GetMoboMan()
    {
        string cpuMan = String.Empty;
        ManagementClass mgmt = new ManagementClass("Win32_BaseBoard");
        ManagementObjectCollection objCol = mgmt.GetInstances();
        foreach (ManagementObject obj in objCol)
        {
            if (cpuMan == String.Empty)
            {

                cpuMan = obj.Properties["Manufacturer"].Value.ToString();
            }
        }
        return cpuMan;
    }
    public static string GetMoboProd()
    {
        string cpuMan = String.Empty;
        ManagementClass mgmt = new ManagementClass("Win32_BaseBoard");
        ManagementObjectCollection objCol = mgmt.GetInstances();
        foreach (ManagementObject obj in objCol)
        {
            if (cpuMan == String.Empty)
            {

                cpuMan = obj.Properties["Product"].Value.ToString();
            }
        }
        return cpuMan;
    }

    public static string GetPhysicalMemory()
    {
        ManagementScope oMs = new ManagementScope();
        ObjectQuery oQuery = new ObjectQuery("SELECT Capacity FROM Win32_PhysicalMemory");
        ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oMs, oQuery);
        ManagementObjectCollection oCollection = oSearcher.Get();

        long MemSize = 0;
        long MemSizeGB = 0;
        long mCap = 0;

        foreach (ManagementObject obj in oCollection)
        {
            mCap = Convert.ToInt64(obj["Capacity"]);
            MemSize += mCap;
            MemSizeGB += mCap;
        }
        MemSize = (MemSize / 1024) / 1024;
        MemSizeGB = ((MemSizeGB / 1024) / 1024) / 1024;
        return MemSize.ToString() + "MB (" + MemSizeGB + "GB)";
    }

    public static string GetRAMTest()
    {
        string cpuMan = String.Empty;
        ManagementClass mgmt = new ManagementClass("Win32_PhysicalMemory");
        ManagementObjectCollection objCol = mgmt.GetInstances();
        foreach (ManagementObject obj in objCol)
        {
            if (cpuMan == String.Empty)
            {
                cpuMan = obj.Properties["Speed"].Value.ToString();
            }
        }
        return cpuMan;
    }




    public static int GetCPUCurrentClockSpeed()
    {
        int cpuClockSpeed = 0;
        ManagementClass mgmt = new ManagementClass("Win32_Processor");
        ManagementObjectCollection objCol = mgmt.GetInstances();
        foreach (ManagementObject obj in objCol)
        {
            if (cpuClockSpeed == 0)
            {

                cpuClockSpeed = Convert.ToInt32(obj.Properties["CurrentClockSpeed"].Value.ToString());
            }
        }

        return cpuClockSpeed;
    }

    public static string GetDefaultIPGateway()
    {

        ManagementClass mgmt = new ManagementClass("Win32_NetworkAdapterConfiguration");
        ManagementObjectCollection objCol = mgmt.GetInstances();
        string gateway = String.Empty;
        foreach (ManagementObject obj in objCol)
        {
            if (gateway == String.Empty) // only return MAC Address from first card
            {

                if ((bool)obj["IPEnabled"] == true)
                {
                    gateway = obj["DefaultIPGateway"].ToString();
                }
            }
            //dispose of our object
            obj.Dispose();
        }
        //replace the ":" with an empty space, this could also
        //be removed if you wish
        gateway = gateway.Replace(":", "");
        //return the mac address
        return gateway;
    }

    public static double? GetCpuSpeedInGHz()
    {
        double? GHz = null;
        using (ManagementClass mc = new ManagementClass("Win32_Processor"))
        {
            foreach (ManagementObject mo in mc.GetInstances())
            {
                GHz = 0.001 * (UInt32)mo.Properties["CurrentClockSpeed"].Value;
                break;
            }
        }
        return GHz;
    }

    public static string GetCurrentLanguage()
    {

        ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");

        foreach (ManagementObject wmi in searcher.Get())
        {
            try
            {
                return wmi.GetPropertyValue("CurrentLanguage").ToString();

            }

            catch { }

        }

        return "BIOS Maker: Unknown";

    }

    public static string GetOSInformation()
    {
        ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
        foreach (ManagementObject wmi in searcher.Get())
        {
            try
            {
                return ((string)wmi["Caption"]).Trim() + ", " + (string)wmi["Version"] + ", " + (string)wmi["OSArchitecture"];
            }
            catch { }
        }
        return "BIOS Maker: Unknown";
    }

    public static String GetProcessorInformation()
    {
        ManagementClass mc = new ManagementClass("win32_processor");
        ManagementObjectCollection moc = mc.GetInstances();
        String info = String.Empty;
        foreach (ManagementObject mo in moc)
        {
            string name = (string)mo["Name"];
            name = name.Replace("(TM)", "™").Replace("(tm)", "™").Replace("(R)", "®").Replace("(r)", "®").Replace("(C)", "©").Replace("(c)", "©").Replace(" ", " ").Replace(" ", " ");

            info = name + ", " + (string)mo["Caption"] + ", " + (string)mo["SocketDesignation"];
            //mo.Properties["Name"].Value.ToString();
            //break;
        }
        return info;
    }
    public static String GetComputerName()
    {
        ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
        ManagementObjectCollection moc = mc.GetInstances();
        String info = String.Empty;
        foreach (ManagementObject mo in moc)
        {
            info = (string)mo["Name"];
            //mo.Properties["Name"].Value.ToString();
            //break;
        }
        return info;
    }

}