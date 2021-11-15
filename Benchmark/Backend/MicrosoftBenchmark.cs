using Benchmark.Backend.Entities;
using System;
using System.Collections.Generic;
using System.Management;

namespace Benchmark.Backend
{
    public class MicrosoftBenchmark
    {
        public static CpuInformation CpuData()
        {
            ManagementObjectCollection moc;
            CpuInformation cpuInformation = new CpuInformation();

            try
            {
                moc = new ManagementObjectSearcher("select * from Win32_Processor").Get();
            }
            catch
            {
                return cpuInformation;
            }

            foreach (ManagementObject obj in moc)
            {
                cpuInformation.ProcName = obj["Name"].ToString();
                cpuInformation.Manufacturer = obj["Manufacturer"].ToString();
                cpuInformation.Version = obj["Version"].ToString();
                cpuInformation.NrCores = obj["NumberOfCores"].ToString();
                cpuInformation.NrLogicalProcessors = obj["NumberOfLogicalProcessors"].ToString();
                cpuInformation.NrThreads = obj["ThreadCount"].ToString();
                cpuInformation.CurrentClockSpeed = obj["CurrentClockSpeed"].ToString();
                cpuInformation.MaximumClockSpeed = obj["MaxClockSpeed"].ToString();
            }

            return cpuInformation;
        }

        public static List<RamInformation> RamData()
        {
            ManagementObjectCollection moc;
            List<RamInformation> ramInformationList = new List<RamInformation>();

            try
            {
                moc = new ManagementObjectSearcher("select * from Win32_PhysicalMemory").Get();
            }
            catch
            {
                return ramInformationList;
            }

            foreach (ManagementObject obj in moc)
            {
                RamInformation ramInformation = new RamInformation();

                if(obj["Name"] != null) ramInformation.Name = obj["Name"].ToString();
                if (obj["Speed"] != null) ramInformation.Speed = obj["Speed"].ToString();
                if (obj["Status"] != null) ramInformation.Status = obj["Status"].ToString();
                if (obj["MinVoltage"] != null) ramInformation.MinVoltage = obj["MinVoltage"].ToString();
                if (obj["MaxVoltage"] != null) ramInformation.MaxVoltage = obj["MaxVoltage"].ToString();
                if (obj["Capacity"] != null) ramInformation.Capacity = obj["Capacity"].ToString();

                ramInformationList.Add(ramInformation);
            }

            return ramInformationList;
        }

        public static BatteryInformation BatteryData()
        {
            ManagementObjectCollection moc;
            BatteryInformation batteryInformation = new BatteryInformation();

            try
            {
                moc = new ManagementObjectSearcher(new ObjectQuery("select * from Win32_Battery")).Get();
            }
            catch
            {
                return batteryInformation;
            }

            foreach (ManagementObject obj in moc)
            {
                if (obj["Name"] != null)  batteryInformation.Name = obj["Name"].ToString();
                if (obj["Status"] != null)  batteryInformation.Status = obj["Status"].ToString();
                if (obj["EstimatedChargeRemaining"] != null)  batteryInformation.EstimatedChargeRemaining = obj["EstimatedChargeRemaining"].ToString();
                if (obj["FullChargeCapacity"] != null)  batteryInformation.FullChargeCapacity = obj["FullChargeCapacity"].ToString();
                if (obj["DesignCapacity"] != null)  batteryInformation.DesignCapacity = obj["DesignCapacity"].ToString();
                if (obj["DesignVoltage"] != null)  batteryInformation.DesignVoltage = obj["DesignVoltage"].ToString();
                if (obj["MaxRechargeTime"] != null)  batteryInformation.MaxRechargeTime = obj["MaxRechargeTime"].ToString();
            }

            return batteryInformation;
        }

        public static List<GpuInformation> GpuData()
        {
            ManagementObjectCollection moc;
            List<GpuInformation> gpuInformationList = new List<GpuInformation>();

            try
            {
                moc = new ManagementObjectSearcher("select * from Win32_VideoController").Get();
            }
            catch
            {
                return gpuInformationList;
            }

            foreach (ManagementObject obj in moc)
            {
                GpuInformation gpuInformation = new GpuInformation();

                if (obj["Name"] != null) gpuInformation.Name = obj["Name"].ToString();
                if (obj["DriverVersion"] != null) gpuInformation.DriverVersion = obj["DriverVersion"].ToString();
                if (obj["MinRefreshRate"] != null) gpuInformation.MinRefreshRate = obj["MinRefreshRate"].ToString();
                if (obj["MaxRefreshRate"] != null) gpuInformation.MaxRefreshRate = obj["MaxRefreshRate"].ToString();
                if (obj["Status"] != null) gpuInformation.Status = obj["Status"].ToString();
                if (obj["VideoArchitecture"] != null)
                {
                    gpuInformation.VideoArchitecture = GetVideoArchitecture(obj);
                }
                if (obj["VideoMemoryType"] != null)
                {
                    gpuInformation.VideoMemoryType = GetVideoMemoryType(obj);
                }
                if (obj["VideoProcessor"] != null) gpuInformation.VideoProcessor = obj["VideoProcessor"].ToString();
                if (obj["AdapterRAM"] != null) gpuInformation.VideoProcessor = obj["AdapterRAM"].ToString();

                gpuInformationList.Add(gpuInformation);
            }

            return gpuInformationList;
        }

        public static List<StorageInformation> StorageData()
        {
            ManagementObjectCollection moc;
            List<StorageInformation> storageInformationList = new List<StorageInformation>();

            try
            {
                moc = new ManagementObjectSearcher("select * from Win32_DiskDrive").Get();
            }
            catch
            {
                return storageInformationList;
            }

            foreach (ManagementObject obj in moc)
            {
                StorageInformation storageInformation = new StorageInformation();

                if (obj["Name"] != null) storageInformation.Name = obj["Name"].ToString();
                if (obj["Model"] != null) storageInformation.Model = obj["Model"].ToString();
                if (obj["BytesPerSector"] != null) storageInformation.BytesPerSector = obj["BytesPerSector"].ToString();
                if (obj["Size"] != null) storageInformation.Size = obj["Size"].ToString();
                if (obj["Status"] != null) storageInformation.Status = obj["Status"].ToString();
                if (obj["TotalSectors"] != null) storageInformation.TotalSectors = obj["TotalSectors"].ToString();
                if (obj["Partitions"] != null) storageInformation.TotalSectors = obj["Partitions"].ToString();
                if (obj["Manufacturer"] != null) storageInformation.TotalSectors = obj["Manufacturer"].ToString();

                storageInformationList.Add(storageInformation);
            }
            return storageInformationList;
        }

        private static string GetVideoMemoryType(ManagementObject obj)
        {
            string videoMemoryType = obj["VideoMemoryType"].ToString();
            switch (videoMemoryType)
            {
                case "1":
                    return "Other";

                case "2":
                    return "Unknown";

                case "3":
                    return "VRAM";

                case "4":
                    return "DRAM";

                case "5":
                    return "SRAM";

                case "6":
                    return "WRAM";

                case "7":
                    return "EDO RAM";

                case "8":
                    return "Burst Synchronous DRAM";

                case "9":
                    return "Pipelined Burst SRAM";

                case "10":
                    return "CDRAM";

                case "11":
                    return "3DRAM";

                case "12":
                    return "SDRAM";

                case "13":
                    return "SGRAM";

                default:
                    return "Error";

            }
        }
        private static string GetVideoArchitecture(ManagementObject obj)
        {
            string videoArchitecture = obj["VideoArchitecture"].ToString();
            switch (videoArchitecture)
            {
                case "1":
                    return "Other";

                case "2":
                    return "Unknown";

                case "3":
                    return "CGA";

                case "4":
                    return "EGA";

                case "5":
                    return "VGA";

                case "6":
                    return "SVGA";

                case "7":
                    return "MDA";

                case "8":
                    return "HGC";

                case "9":
                    return "MCGA";

                case "10":
                    return "8514A";

                case "11":
                    return "XGA";

                case "12":
                    return "Linear Frame Buffer";

                case "160":
                    return "PC-98";

                default:
                    return "Error";

            }
        }
    }
}
