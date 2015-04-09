using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace Shift_2_Fix
{
    class Program
    {
        private static List<String> keysList = new List<string>();
        private static string keyname = "{5E6F93E4-59E3-56F4-5896-5DE400A8A6C0}";
        private static string user;

        private static void Main(string[] args)
        {
            var CurrentUser = Registry.ClassesRoot;
            Console.WriteLine("This program was made by wax911 to address NFS SHIFT 2 Go **** Problem");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine();

            var SubKey = CurrentUser.OpenSubKey("Wow6432Node");
            if (SubKey != null)
            {
                var rk = SubKey.OpenSubKey("Interface",RegistryKeyPermissionCheck.ReadWriteSubTree);
                if (FindKey(rk))
                {
                    Console.WriteLine("Key has been found!");
                    DeleteSubKey(rk);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Key has not been found!");
                }
            }
            else
            {
                Console.WriteLine("Failed to open sub directories!");
            }
            Console.ReadKey();
            Environment.Exit(0);

        }

        private static bool FindKey(RegistryKey regKey)
        {
            Console.WriteLine("Subkeys of {0}",regKey.Name);
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            foreach (var keys in regKey.GetSubKeyNames())
            {
                keysList.Add(keys);
            }
            Console.WriteLine();
            Console.WriteLine("Searching for key: {0} in {1}",keyname,regKey.Name);

            if (keysList.Contains(keyname))
            {
                return true;
            }
            regKey.Close();
            return false;
        }

        private static void DeleteSubKey(RegistryKey key)
        {
            Console.WriteLine();
            Console.WriteLine("Attempting to delete key! To fix NFS Go **** yourself DLC problem");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine();

            if (key != null)
            {
                key.DeleteSubKey(keyname);
            }
            else
            {
                Console.WriteLine("The requested key seems to be null :(");
            }
            Console.WriteLine(!KeyDeleted(key) ? "Success, the key has been deleted!" : "Failed to Delete!");
            Console.ReadKey();
            Environment.Exit(0);
        }

        private static bool KeyDeleted(RegistryKey key)
        {
            keysList.Clear();
            foreach (var keys in key.GetSubKeyNames())
            {
                keysList.Add(keys);
            }

            return keysList.Contains(keyname);
        }
    }
}
