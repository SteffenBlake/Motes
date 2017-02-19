using System;
using System.IO;
using System.Diagnostics;

namespace InstallSetup
{
    class Setup
    {
        static void Main(string[] args)
        {


            string exPath = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);


            string motes = "\\Motes.exe";
            string install = "\\Installer.exe";
            string icon = "\\smiling.ico";
            string readme = "\\README.md";
            string ver = "\\VersionHistory.txt";

            string x64 = exPath + "\\x64" + motes;
            string x86 = exPath + "\\x86" + motes;
            string version = FileVersionInfo.GetVersionInfo(x64).FileVersion;

            string installpath = exPath + install;
            string iconpath = exPath.Replace("\\bin", "") + icon;
            string readmepath = exPath.Replace("\\Motes\\bin", "") + readme;
            string verpath = exPath.Replace("\\Motes\\bin", "") + ver;

            string Desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Motes - v" + version;

            CheckFile(installpath);
            CheckFile(x64);
            CheckFile(x86);
            CheckFile(readmepath);
            CheckFile(verpath);
            CheckFile(iconpath);

            if (Directory.Exists(Desktop))
            {
                Console.WriteLine("This version already exists, please update assembly info!");
                End();
            }
            Directory.CreateDirectory(Desktop);
            Directory.CreateDirectory(Desktop + "\\x64");
            Directory.CreateDirectory(Desktop + "\\x86");
            File.Copy(installpath, Desktop + install );
            File.Copy(readmepath, Desktop + readme);
            File.Copy(verpath, Desktop + ver);
            File.Copy(iconpath, Desktop + icon);
            File.Copy(iconpath, Desktop + "\\x64" + motes);
            File.Copy(iconpath, Desktop + "\\x86" + motes);


            Console.WriteLine("Setup complete, folder deposited on the Desktop!");
            End();
        }

        public static void CheckFile(string dir)
        {
            if (File.Exists(dir))
                return;

            Console.WriteLine("Unable to find:" + dir);
            End();
        }

        public static void End()
        {
            Console.WriteLine("<Press any key to finish!>");
            Console.ReadKey();
            Environment.Exit(00);
        }
    }
}
