using System.Diagnostics;
using System.IO;
using System.Xml.Linq;

namespace _8mbfy
{
    public partial class Form1 : Form
    {
        private AppSettings settings;
        private int taskFinish = 0;
        private bool finishedRuned = true;
        private List<string> Skipped = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void formDragDrop(object sender, DragEventArgs e)
        {
            string[] fileName = Pickup.main((string[])e.Data.GetData(DataFormats.FileDrop, false)).ToArray();
            conveter(fileName);
        }

        private void conveter(string[] fileName)
        {
            timer1.Enabled = true;
            this.BackColor = SystemColors.ActiveCaption;
            button2.Enabled = false;
            Debug.WriteLine(fileName.Length);
            progressBar1.Maximum = fileName.Length;
            progressBar1.Value = 0;
            this.Text = "8mbfy";

            deleteOutput();
            taskFinish = 0;
            Skipped.Clear();
            ImageCompressor imgCmp = new ImageCompressor(settings);
            Console.WriteLine("dragAndDrop filelist");
            Task conv = new Task(() =>
            {
                Parallel.For(0, fileName.Length, (i) =>
                {
                    string name = fileName[i];
                    Debug.WriteLine(name);

                    //nameのファイルが有るか？
                    if (!File.Exists(name))
                    {
                        taskFinish++;
                        return;
                    }
                    long filesize = new FileInfo(name).Length;
                    if (filesize < (1024 * 1024 * settings.targetSize))
                    {
                        Debug.WriteLine("Skipped.");
                        if (settings.skipCopy)
                            File.Copy(name, ".\\output\\" + i + Path.GetExtension(name), true);
                        else
                            Skipped.Add(name);
                        taskFinish++;
                        return;
                    }
                    Debug.WriteLine("CNV");
                    var ms = imgCmp.cnv(name);
                    Debug.WriteLine("CNVEND");

                    Debug.WriteLine("FILESIZE = " + ms.Key.Length.ToString());
                    FileStream fileStream = new FileStream(".\\output\\" + i + ms.Value, FileMode.Create, FileAccess.Write);
                    ms.Key.WriteTo(fileStream);
                    fileStream.Close();
                    Debug.WriteLine("CLOSE");
                    taskFinish++;
                });
            });
            conv.Start();
        }

        private void deleteOutput()
        {
            DirectoryInfo di = new DirectoryInfo(".\\output");
            FileInfo[] files = di.GetFiles();
            foreach (FileInfo file in files)
            {
                file.Delete();
            }
        }

        private void formDragEnter(object sender, DragEventArgs e)
        {

            //コントロール内にドラッグされたとき実行される
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                //ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
                e.Effect = DragDropEffects.Copy;
            else
                //ファイル以外は受け付けない
                e.Effect = DragDropEffects.None;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == progressBar1.Maximum && progressBar1.Value != 0)
            {
                this.BackColor = SystemColors.Control;
                this.Text = "8mbfy complete";
                copyButton.Enabled = true;
                timer1.Enabled = false;
                button2.Enabled = true;
                if (settings.autoCopy)
                    copyButton_Click(new object(), new EventArgs());
                if (settings.autoExit)
                    this.Close();
            }
            else
            {
                this.Text = "8mbfy " + taskFinish + "/" + progressBar1.Maximum;
                copyButton.Enabled = false;
                progressBar1.Value = taskFinish;
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(".\\output");
            IEnumerable<FileInfo> files = di.EnumerateFiles("*", SearchOption.AllDirectories);

            List<String> clipboardList = new List<String>();
            foreach (FileInfo f in files)
            {
                Debug.WriteLine(f.FullName);
                clipboardList.Add(f.FullName);
            }

            Skipped.ForEach((s) => clipboardList.Add(s));

            IDataObject data = new DataObject(DataFormats.FileDrop, clipboardList.ToArray());
            Clipboard.SetDataObject(data, true);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = checkBox1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SettingsForm settingForm = new SettingsForm();
            settingForm.ShowDialog();
            settings = ReadXML.main();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            settings = ReadXML.main();
            checkBox1.Checked = settings.fixidTop;
            if (settings.autoStart)
            {
                button2_Click(new object(), new EventArgs());
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (settings.autoDelete)
            {
                deleteOutput();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //クリップボードがファイルデータかどうか
            var files = Clipboard.GetFileDropList();
            //取得したファイル名を列挙する
            string[] stringArray = new string[files.Count];
            files.CopyTo(stringArray, 0);
            var li = Pickup.main(stringArray);
            if (li.Count() != 0)
                conveter(li.ToArray());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //outputフォルダを開く
            Process.Start("explorer.exe", ".\\output");
        }
    }
}