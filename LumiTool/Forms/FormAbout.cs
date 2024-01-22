using System.Diagnostics;
using System.Reflection;

namespace LumiTool.Forms
{
    public partial class FormAbout : Form
    {
        private static readonly string githubLink = "https://github.com/SaltContainer/LumiTool";
        private static readonly List<string> authors = new List<string>()
        {
            "SaltContainer"
        };
        private static readonly List<string> imgs = new List<string>()
        {
            "dj_base",
            "dj_blush",
            "dj_dab",
            "dj_happy",
            "dj_pls",
            "dj_shrug",
            "dj_surprised",
            "dj_thumbsup",
        };

        public FormAbout()
        {
            InitializeComponent();

            lbAbout.Text = "LumiTool version " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            lbDev.Text = "Developed by " + string.Join(",", authors);

            imgDJ.Image = GetRandomImage();
        }

        private Image GetRandomImage()
        {
            Random rand = new Random();
            int index = rand.Next(imgs.Count());
            Bitmap pin = Resources.Resources.ResourceManager.GetObject(imgs[index]) as Bitmap;
            return pin;
        }

        private void linklbRepo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = githubLink,
                UseShellExecute = true
            });
        }
    }
}
