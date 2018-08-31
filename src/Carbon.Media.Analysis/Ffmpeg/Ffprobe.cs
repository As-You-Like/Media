using System;
using System.Text;

namespace Carbon.Media.Analysis
{
    public class Ffprobe
    {
        // https://gist.github.com/nrk/2286511
        // ffprobe -hide_banner -loglevel fatal -show_error -show_format -show_streams -show_programs -show_chapters -show_private_data -print_format json

        private readonly string exePath;
        private readonly Bash bash = new Bash();

        public Ffprobe()
        {
           this.exePath = AppDomain.CurrentDomain.BaseDirectory + "ffprobe.exe";
        }

        public Ffprobe(string exePath)
        {
            this.exePath = exePath;
        }

        public string Get(string url)
        {
            var sb = new StringBuilder();

            bash.Execute(exePath, "-hide_banner -loglevel fatal -show_error -show_format -show_streams -show_programs -show_chapters -show_private_data -print_format json " + url, (s, e) => sb.Append(e.Data));

            return sb.ToString();
        }
    }
}
