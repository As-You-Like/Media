using System.Diagnostics;

namespace Carbon.Media.Analysis
{
    internal class Bash
    {
        // ExcuteProcess("ffmpeg.exe", "-y -i 1.flv 1.mp3", (s, e) => Console.WriteLine(e.Data));

        public void Execute(string exe, string arg, DataReceivedEventHandler output)
        {
            using (var p = new Process())
            {
                p.StartInfo.FileName = exe;
                p.StartInfo.Arguments = arg;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.OutputDataReceived += output;
                p.ErrorDataReceived += output;
                p.Start();
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();

                p.WaitForExit();
            }
        }
    }
}
