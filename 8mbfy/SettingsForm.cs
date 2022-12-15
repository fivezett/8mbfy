using System.Xml.Linq;

namespace _8mbfy
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Load("appsettings.xml");
            doc.Root.Element("targetSize").Value = target_size.Value.ToString();
            doc.Root.Element("alphaImgCnvJpg").Value = cnv_jpg.Checked.ToString();
            doc.Root.Element("jpgQuality").Value = jpg_q.Value.ToString();
            doc.Root.Element("fixidTop").Value = top_def.Checked.ToString();
            doc.Root.Element("autoCopy").Value = auto_copy.Checked.ToString();
            doc.Root.Element("autoDelete").Value = auto_delete.Checked.ToString();
            doc.Root.Element("autoExit").Value = auto_exit.Checked.ToString();
            doc.Root.Element("autoStart").Value = auto_start.Checked.ToString();
            doc.Root.Element("skipCopy").Value = file_skip.Checked.ToString();
            doc.Save("appsettings.xml");
            this.Close();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            var settings = ReadXML.main();
            target_size.Value = (decimal)settings.targetSize;
            cnv_jpg.Checked = settings.alphaImgCnvJpg;
            jpg_q.Value = settings.jpgQuality;
            top_def.Checked = settings.fixidTop;
            auto_copy.Checked = settings.autoCopy;
            auto_delete.Checked = settings.autoDelete;
            auto_exit.Checked = settings.autoExit;
            auto_start.Checked = settings.autoStart;
            file_skip.Checked = settings.skipCopy;
        }
    }
}
