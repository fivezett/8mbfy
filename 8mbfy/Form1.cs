using System.Diagnostics;

namespace _8mbfy
{
    public partial class Form1 : Form
    {
        private int targettingFileSize = 1024 * 1024 * 8;
        private int targettingFileSizeOriginal = 1024 * 1024 * 8;

        public Form1()
        {
            InitializeComponent();
        }

        private void formDragDrop(object sender, DragEventArgs e)
        {
            this.BackColor = SystemColors.ActiveCaption;
            //コントロール内にドロップされたとき実行される
            //ドロップされたすべてのファイル名を取得する
            string[] fileName =
                (string[])e.Data.GetData(DataFormats.FileDrop, false);

            progressBar1.Maximum = fileName.Length;
            progressBar1.Value = 0;
            this.Text = "8mbfy";

            DirectoryInfo di = new DirectoryInfo(".\\output");
            FileInfo[] files = di.GetFiles();
            foreach (FileInfo file in files)
            {
                file.Delete();
            }

            Console.WriteLine("dragAndDrop filelist");
            Task conv = new Task(() =>
            {
                Parallel.For(0, fileName.Length, i =>
                  {
                      string name = fileName[i];
                      Debug.WriteLine(name);
                      long filesize = new FileInfo(name).Length;
                      if (Path.GetExtension(name).ToLower() != ".jpg" && Path.GetExtension(name).ToLower() != ".jpeg" && Path.GetExtension(name).ToLower() != ".png") {
                          progressBar1.BeginInvoke(new Action(() => { progressBar1.Value++; }));
                          return;
                      }
                      if (filesize < targettingFileSizeOriginal)
                      {
                          Debug.WriteLine("Skipped.");
                          File.Copy(name, ".\\output\\" + i + Path.GetExtension(name), true);
                          progressBar1.BeginInvoke(new Action(() => { progressBar1.Value++; }));
                          return;
                      }
                      double persent = (double)filesize / targettingFileSize;
                      Image image = Image.FromFile(name);
                      Image outputImage = (Image)(new Bitmap(image, new Size((int)Math.Round((double)image.Width / persent), (int)Math.Round((double)image.Height / persent))));
                      Debug.WriteLine((int)Math.Round((double)image.Width / persent));
                      outputImage.Save(".\\output\\" + i + ".png");
                      compressLoop(outputImage, ".\\output\\" + i + ".png");
                      outputImage.Dispose();
                      image.Dispose();
                      Debug.WriteLine("img done.");
                      this.BeginInvoke(new Action(() => { progressBar1.Value++; Application.DoEvents(); }));
                  });
            });
            conv.Start();
        }

        private void compressLoop(Image image, String name)
        {
            Debug.WriteLine("Comp");
            long filesize = new FileInfo(name).Length;
            Debug.WriteLine(filesize);
            if (filesize < targettingFileSizeOriginal)
                return;
            Image outputImage = (Image)(new Bitmap(image, new Size((int)Math.Round((double)image.Width * 0.9), (int)Math.Round((double)image.Height * 0.9))));
            image.Dispose();
            outputImage.Save(name);
            compressLoop(outputImage, name);
            outputImage.Dispose();
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
            }
            else {
                copyButton.Enabled = false;
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(".\\output");
            IEnumerable<FileInfo> files = di.EnumerateFiles("*", SearchOption.AllDirectories);

            List<String> clipboardList =  new List<String>();
            foreach (FileInfo f in files)
            {
                Debug.WriteLine(f.FullName);
                clipboardList.Add(f.FullName);
            }

            IDataObject data = new DataObject(DataFormats.FileDrop, clipboardList.ToArray());
            Clipboard.SetDataObject(data);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = checkBox1.Checked;
        }
    }
}