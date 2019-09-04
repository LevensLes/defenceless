using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Defenceless
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Windows Defender Disabler by LevensLes#4590";
            menu();

        }

        static void menu()
        {

            Console.WriteLine("Disable: Disables windows defender services");
            Console.WriteLine("Enable: Removes the patches made to the defender services.");

            string choice = Console.ReadLine();
            switch (choice.ToLower())
            {
                case "disable":
                    {
                        if (Registry.GetValue(
                                @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection",
                                "DisableRealtimeMonitoring", null) == null)
                        {
                            Registry.LocalMachine.CreateSubKey(
                                @"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection");
                            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender",
                                "DisableAntiSpyware", "1", RegistryValueKind.DWord);
                            Registry.SetValue(
                                @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection",
                                "DisableRealtimeMonitoring", "1", RegistryValueKind.DWord);

                            Console.WriteLine(
                                "Services disabled, restart is required to take effect.\n");

                    
                            Console.WriteLine("Would you like to restart now ? (y/n)");
                            string input2 = Console.ReadLine();
                            if (input2.ToLower().Contains("y"))
                            {
                                Process.Start("shutdown",
                                    "/r /t 0");
                                Console.Read();
                            }
                            else if (input2.ToLower().Contains("n"))
                            {

                            }
                            else
                            {
                                Console.WriteLine("Invalid choice");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Already Disabled");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        menu();
                        break;
                    }
                case "enable":
                    {
                        if (Registry.GetValue(
                                @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection",
                                "DisableRealtimeMonitoring", null) == null)
                        {
                            Console.WriteLine("Already Enabled");
                        }
                        else
                        {
                            Registry.LocalMachine.CreateSubKey(
                                @"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection");
                            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender",
                                "DisableAntiSpyware", "0", RegistryValueKind.DWord);
                            Registry.SetValue(
                                @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection",
                                "DisableRealtimeMonitoring", "0", RegistryValueKind.DWord);

                            Console.WriteLine(
                                "Services enabled, restart is required to take effect.");

                            Console.WriteLine();
                            Console.WriteLine("Would you like to restart now ? (y/n)");
                            string input2 = Console.ReadLine();
                            if (input2.ToLower().Contains("y"))
                            {
                                Process.Start("shutdown",
                                    "/r /t 0");
                                Console.Read();
                            }
                            else if (input2.ToLower().Contains("n"))
                            {

                            }
                            else
                            {
                                Console.WriteLine("Invalid choice");
                            }
                        }


                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        menu();
                        break;

                    }
                default:
                    {
                        menu();
                        return;
                    }
            }


        }

    }
}
