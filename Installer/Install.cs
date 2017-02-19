using System;
using System.IO;
using Microsoft.Win32;

namespace Installer
{

    class Install
    {

        static void Main(string[] args)
        {

            string exPath = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
            string modPath = exPath;
            string system32 = "C:\\Windows\\System32\\";
            string installPath;
            string motes = "Motes.exe";
            string ico = "smiling.ico";


            if (Environment.Is64BitOperatingSystem)
            {
                Console.WriteLine("x64 OS detected, installing x64 version.");
                modPath += "\\x64\\";
                installPath = "C:\\Program Files\\Motes\\";
            }
            else
            {
                Console.WriteLine("x86 OS detected, installing x86 version.");
                modPath += "\\x86\\";
                installPath = "C:\\Program Files (x86)\\Motes\\";
            }

            try
            {
                Directory.CreateDirectory(installPath);
                File.Copy(modPath + motes, system32 + motes, true);
                File.Copy(modPath + motes, installPath + motes, true);
                File.Copy(modPath + motes, installPath + ico, true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Registry.SetValue("HKEY_CURRENT_USER\\Software\\Classes\\motes\\shell\\open\\command", "", "\"" + system32 + motes + "\"" + " \"%1\"");
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\Classes\\.mot", "", "motes");
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\Classes\\.mot", "DefaultIcon", installPath + ico);
            Registry.SetValue("HKEY_CLASSES_ROOT\\.mot", "", "motes");
            Registry.SetValue("HKEY_CLASSES_ROOT\\motes\\DefaultIcon", "", installPath + ico);
            Registry.SetValue("HKEY_CLASSES_ROOT\\motes\\shell\\open\\command", "", "\"" + system32 + motes + "\"" + " \"%1\"");

            Console.WriteLine("Installation complete! \nMake sure to restart your computer for changes to work!\n<Press any key to finish>");
            Console.ReadKey();
        }
    }
}
