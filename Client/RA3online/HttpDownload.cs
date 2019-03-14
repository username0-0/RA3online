using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace RA3online
{
        public class HttpDownLoad
        {

        //ToDo : async this class!
        //白学："大概就是在MainWindow.xaml.cs里调用这个DownloadFileByAria2，[创建一个线程]，想办法让[UI线程]和[这个task]通信得到[下载进度之类的信息]。"
        public static bool DownloadFileByAria2(string url, string strFileName)
            {
                var tool = "aria2c.exe";
                var fi = new FileInfo(strFileName);
                var command = " -c -s 10 -x 10  --file-allocation=none --check-certificate=false -d " + fi.DirectoryName + " -o " + fi.Name + " " + url;
                using (var p = new Process())
                {
                    RedirectExcuteProcess(p, tool, command, (s, e) => ShowInfo(url, e.Data));
                }
                return File.Exists(strFileName) && new FileInfo(strFileName).Length > 0;
            }
        //ShowInfo
            private static void ShowInfo(string url, string a)
            {
                if (a == null) return;

                const string re1 = ".*?"; // Non-greedy match on filler
                const string re2 = "(\\(.*\\))"; // Round Braces 1

                var r = new Regex(re1 + re2, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                var m = r.Match(a);
                if (m.Success)
                {
                    var rbraces1 = m.Groups[1].ToString().Replace("(", "").Replace(")", "").Replace("%", "").Replace("s", "0");
                    if (rbraces1 == "OK")
                    {
                        rbraces1 = "100";
                    }
                    Console.WriteLine(DateTime.Now.ToString().Replace("/", "-") + "    " + url + "    下载进度:" + rbraces1 + "%");
                }
            }
        //RedirectExcuteProcess
            private static void RedirectExcuteProcess(Process p, string exe, string arg, DataReceivedEventHandler output)
            {
                p.StartInfo.FileName = exe;
                p.StartInfo.Arguments = arg;

                p.StartInfo.UseShellExecute = false;    //redirect
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardOutput = true;

                p.OutputDataReceived += output;
                p.ErrorDataReceived += output;

                p.Start();                    //launch tasks
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
                p.WaitForExit();            //wait for tasks
            }
        }
}
