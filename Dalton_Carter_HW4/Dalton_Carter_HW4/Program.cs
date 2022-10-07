/*
 * Dalton Carter
 * This program shows the principles of Object Oriented Programming
 * for a computer company that makes different types of computers
 * with varying fields.
 */
using System;
using System.Collections.Generic;

namespace Dalton_Carter_HW4
{
    abstract class Machine
    {
        // Variable for ram capacity of Machine
        protected int Ram { get; set; }
        // Reference for Storage Device of Machine.
        protected StorageDevice Storage { get; set; }
        // Reference for CPU of Machine.
        protected CPU cpu { get; set; }

        /// <summary>
        /// Constructor for Abstract Machine class.
        /// </summary>
        /// <param name="cpu"></param>
        /// <param name="Storage"></param>
        /// <param name="Ram"></param>
        public Machine(CPU cpu, StorageDevice Storage, int Ram)
        {
            this.cpu = cpu;
            this.Storage = Storage;
            this.Ram = Ram;
        }
        // Abstract method for all subclasses.
        public abstract string GetDescription();
    }
    
    abstract class Desktop : Machine 
    {
        /// <summary>
        /// Constructor for Abstract Desktop class.
        /// </summary>
        /// <param name="cpu"></param>
        /// <param name="Storage"></param>
        /// <param name="Ram"></param>
        public Desktop(CPU cpu, StorageDevice Storage, int Ram) : base(cpu, Storage, Ram)
        {
            this.cpu = cpu;
            this.Storage = Storage;
            this.Ram = Ram;
        }
        public override string GetDescription()
        {
            return ("\nLaptop:\nCPU type: " + cpu.Type +
                "\nCPU Speed: " + cpu.Speed +
                "\nStorage Type: " + Storage.Type +
                "\nStorage Capacity: " + Storage.Capacity +
                "\nRAM Capacity: " + Ram);
        }
        // Virtual methods for polymorphism of Desktop to use methods in Regular Desktop classes.
        public virtual void AddSD(StorageDevice Storage) 
        { 
            this.Storage = Storage; 
        }

        public virtual string PrintSD()
        {
            return ("\nStorage Type: " + Storage.Type +
                "\nStorage Capacity: " + Storage.Capacity);
        }
    }

    class Laptop : Machine
    {
        // Reference to screen.
        private Screen screen;
        // Variable for Laptop's wificard
        private string wificard { get; set; }
        // Variable for Laptop's speaker
        private string speaker { get; set; }
        /// <summary>
        /// Constructor for Laptop class.
        /// </summary>
        /// <param name="cpu"></param>
        /// <param name="Storage"></param>
        /// <param name="screen"></param>
        /// <param name="wificard"></param>
        /// <param name="speaker"></param>
        /// <param name="Ram"></param>
        public Laptop(CPU cpu, StorageDevice Storage, Screen screen,
            string wificard, string speaker, int Ram) : base(cpu, Storage, Ram)
        {
            this.cpu = cpu;
            this.screen = screen;
            this.Storage = Storage;
            this.wificard = wificard;
            this.Ram = Ram;
            this.speaker = speaker;
        }
        /// <summary>
        /// Returns description of Laptop object.
        /// </summary>
        /// <returns></returns>
        public override string GetDescription()
        {
            return ("\nLaptop:\nCPU type: " + cpu.Type +
                "\nCPU Speed: " + cpu.Speed +
                "\nStorage Type: " + Storage.Type +
                "\nStorage Capacity: " + Storage.Capacity +
                "\nRAM Capacity: " + Ram +
                "\nScreen Type: " + screen.Type +
                "\nScreen Size: " + screen.Size +
                "\nSpeaker Type: " + speaker +
                "\nWifi Card Type: " + wificard);
        }
    }

    class RegDesktop : Desktop
    {
        // List for all possible storage device for Regular Desktop object.
        private List<StorageDevice> SecondaryStorage = new List<StorageDevice>();
        // Variable for Regular desktop's Form Factor.
        private string FormFactor { get; set; }
        /// <summary>
        /// Constructor for Regular Desktop class.
        /// </summary>
        /// <param name="cpu"></param>
        /// <param name="Storage"></param>
        /// <param name="FormFactor"></param>
        /// <param name="Ram"></param>
        public RegDesktop(CPU cpu, StorageDevice Storage, string FormFactor, int Ram)
            : base(cpu, Storage, Ram)
        {
            this.cpu = cpu;
            // Add storage to list.
            SecondaryStorage.Add(Storage);
            this.Ram = Ram;
            this.FormFactor = FormFactor;
        }
        /// <summary>
        /// Returns description of Regular Desktop object.
        /// </summary>
        /// <returns></returns>
        public override string GetDescription()
        {
            return ("\nRegular Desktop:\nCPU type: " + cpu.Type +
                "\nCPU Speed: " + cpu.Speed +
                // Call method to print all Storage Devices.
                PrintSD() + 
                "\nRAM Capacity: " + Ram +
                "\nForm Factor: " + FormFactor);
        }
        /// <summary>
        /// Adds a storage device to the list for object.
        /// </summary>
        /// <param name="storage"></param>
        public override void AddSD(StorageDevice storage)
        {
            SecondaryStorage.Add(storage);
        }
        /// <summary>
        /// Returns all Storage Devices in list as a string.
        /// </summary>
        /// <returns></returns>
        public override string PrintSD()
        {
            // Instantiate object to hold all devices in string.
            string devices = "";
            // Counter for number of Storage Devices.
            int counter = 1;
            // Loop through all Storage Devices in list.
            foreach(StorageDevice i in SecondaryStorage)
            {
                devices += "\nStorage Device #" + counter + ":";
                devices += "\nStorage Type: " + i.Type + "\nStorage Capacity: " + i.Capacity;
                counter++;
            }
            return devices;
        }
    }

    class AIODesktop : Desktop
    {
        // Reference to Screen.
        private Screen screen;
        // Variable for AIO Desktop's speaker.
        private string speaker { get; set; }
        /// <summary>
        /// Constructor for All in One Desktop class.
        /// </summary>
        /// <param name="cpu"></param>
        /// <param name="Storage"></param>
        /// <param name="screen"></param>
        /// <param name="speaker"></param>
        /// <param name="Ram"></param>
        public AIODesktop(CPU cpu, StorageDevice Storage, Screen screen, string speaker, int Ram) 
            : base(cpu, Storage, Ram)
        {
            this.cpu = cpu;
            this.Storage = Storage;
            this.Ram = Ram;
            this.screen = screen;
            this.speaker = speaker;
        }
        /// <summary>
        /// Returns description of All in One Desktop object.
        /// </summary>
        /// <returns></returns>
        public override string GetDescription()
        {
            return ("\nAIO Desktop:\nCPU type: " + cpu.Type +
                "\nCPU Speed: " + cpu.Speed +
                "\nStorage Type: " + Storage.Type +
                "\nStorage Capacity: " + Storage.Capacity +
                "\nRAM Capacity: " + Ram +
                "\nScreen Type: " + screen.Type +
                "\nScreen Size: " + screen.Size +
                "\nSpeaker Type: " + speaker);
        }
    }

    class StorageDevice
    {
        /// <summary>
        /// Constructor for Storage Device class.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="capacity"></param>
        public StorageDevice(string type, double capacity)
        {
            Type = type;
            Capacity = capacity;
        }
        // Variable for Storage Device's type.
        public string Type { get; set; }
        // Variable for Storage Device's capacity.
        public double Capacity { get; set; }
    }

    class CPU
    {
        /// <summary>
        /// Constructor for CPU class.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="speed"></param>
        public CPU(string type, double speed)
        {
            Type = type;
            Speed = speed;
        }
        // Variable for CPU's type.
        public string Type { get; set; }
        // Variable for CPU's Speed.
        public double Speed { get; set; }
    }

    class Screen
    {
        /// <summary>
        /// Constructor for Screen class.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        public Screen(double size, string type)
        {
            Size = size;
            Type = type;
        }
        // Variable for Screen's size.
        public double Size { get; set; }
        // Variable for Screen's type.
        public string Type { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Two types of CPU references.
            CPU i7 = new CPU("I7", 34.5);
            CPU i9 = new CPU("I9", 65.3);

            // Two types of Screen references.
            Screen sc = new Screen(10, "touch");            
            Screen nsc = new Screen(16, "non-touch");

            // Two types of Storage references.
            StorageDevice sd = new StorageDevice("SSD", 512.4);
            StorageDevice hsd = new StorageDevice("HDD", 1000.88);

            // Laptop object.
            Machine m = new Laptop(i7, sd, sc, "NIC", "Fender", 16);
            // AIO Desktop object.
            Machine m2 = new AIODesktop(i9, hsd, nsc, "JBL", 32);
            // Regular Desktop object.
            Desktop m3 = new RegDesktop(i9, sd, "ATX", 64);
            // Add a Storage device to Regular Desktop.
            m3.AddSD(hsd);
            // Print descriptions of all objects.
            Console.WriteLine(m.GetDescription());
            Console.WriteLine(m2.GetDescription());
            Console.WriteLine(m3.GetDescription());
        }
    }
}
