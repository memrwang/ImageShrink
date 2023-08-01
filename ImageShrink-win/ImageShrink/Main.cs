using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ImageShrink
{
    public partial class Main : Form
    {
        /// <summary>
        /// 主窗口启动加载
        /// </summary>
        public Main()
        {
            InitializeComponent();
        }

        // 配置文件路径
        string SettingFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ImageShrink.ini");
        // 跟踪当前语言选中的菜单项
        private ToolStripMenuItem selectedMenuItem;

        string AboutTitle = "About"; // 关于Title
        string ErrorTitle = "Error"; // 错误Title
        string ErrorInfo1 = "Please enter a number with a quality value of 0-100"; // 错误信息1
        string ErrorInfo2 = "Quality value cannot be greater than 100"; // 错误信息2

        /// <summary>
        /// 程序加载
        /// </summary>
        private void Main_Load(object sender, EventArgs e)
        {
            // 获取Language文件夹中的所有txt语言文件
            string[] txtFiles = Directory.GetFiles("Language", "*.txt");

            // 加载全部并添加相应的menuItem
            foreach (string filePath in txtFiles)
            {
                // 获取文件名（不包括扩展名）
                string languageName = Path.GetFileNameWithoutExtension(filePath);

                // 创建并添加menuItem
                ToolStripMenuItem menuItem = new ToolStripMenuItem(languageName);
                LanguageToolStripMenuItem.DropDownItems.Add(menuItem);
            }
            // 绑定所有menuItem到同一个事件
            foreach (ToolStripMenuItem menuItem in LanguageToolStripMenuItem.DropDownItems)
            {
                menuItem.Click += MenuItem_Click;
            }

            // 修改当前Language值
            Dictionary<string, string> setting = LoadResources(SettingFilePath);
            string CurrentLanguage = GetResourceValue(setting, "Language");

            // 切换当前语言
            SwitchLanguage(CurrentLanguage);

            // 设置语言初始选中状态
            foreach (ToolStripMenuItem menuItem in LanguageToolStripMenuItem.DropDownItems)
            {
                if (menuItem.Text == CurrentLanguage)
                {
                    menuItem.Checked = true;
                    selectedMenuItem = menuItem;
                }
                else
                {
                    menuItem.Checked = false;
                }
            }

            // 如果没有任务隐藏列表视图
            FileListViewVisible(); 
            // 设置允许选择的文件类型
            OpenFileDialog.Filter = "image|*.jpg;*.jpeg;*.png;*.gif;";
            // 设置允许多选
            OpenFileDialog.Multiselect = true;

            // 设置默认保存路径
            OutputTextBox.Text = "C:\\ISOutput\\";

            // 设置质量选择项
            QualityComboBox.Items.Add("100");
            QualityComboBox.Items.Add("80");
            QualityComboBox.Items.Add("60");
            QualityComboBox.Items.Add("40");
            QualityComboBox.Items.Add("20");
            QualityComboBox.SelectedIndex = 1; //默认选择质量80
        }

        /// <summary>
        /// 切换软件语言,并重新调整部分视图位置
        /// </summary>
        /// <param name="CurrentLanguage"></param>
        private void SwitchLanguage(string CurrentLanguage)
        {
            // 加载对应语言的文本文件
            string LanguageFilePath = Path.Combine("Language", CurrentLanguage + ".txt");
            Dictionary<string, string> language = LoadResources(LanguageFilePath);

            // 修改视图语言

            // Menu
            HelpToolStripDropDownButton.Text = GetResourceValue(language, "Help");
            LanguageToolStripMenuItem.Text = GetResourceValue(language, "Language");
            WebsiteToolStripMenuItem.Text = GetResourceValue(language, "Website");
            AboutToolStripMenuItem.Text = GetResourceValue(language, "About");

            // ToolStrip
            AddToolStripButton.Text = GetResourceValue(language, "Add");
            ClearToolStripButton.Text = GetResourceValue(language, "Clear");
            QualityToolStripLabel.Text = GetResourceValue(language, "Quality");
            StartToolStripButton.Text = GetResourceValue(language, "Start");

            // FileListView
            StateColumnHeader.Text = GetResourceValue(language, "State");
            FileColumnHeader.Text = GetResourceValue(language, "File");
            OriginalSizeColumnHeader.Text = GetResourceValue(language, "OriginalSize");
            AfterSizeColumnHeader.Text = GetResourceValue(language, "AfterSize");

            // SavePath
            SavePathLabel.Text = GetResourceValue(language, "SavePathLabel");
            BrowseFileButton.Text = GetResourceValue(language, "BrowseFile");
            OpenOutputButton.Text = GetResourceValue(language, "OpenOutput");

            // 弹窗
            AboutTitle = GetResourceValue(language, "AboutTitle");
            ErrorTitle = GetResourceValue(language, "ErrorTitle");
            ErrorInfo1 = GetResourceValue(language, "ErrorInfo1");
            ErrorInfo2 = GetResourceValue(language, "ErrorInfo2");

            // 修改视图组件位置
            // 调整SavePathLabel的位置
            int SavePathLabel_Y = OutputTextBox.Top + (OutputTextBox.Height - SavePathLabel.Height) / 2;
            SavePathLabel.Location = new Point(OutputTextBox.Left - SavePathLabel.Width - 5, SavePathLabel_Y);

            EditResources(SettingFilePath, "Language", CurrentLanguage);
        }

        /// <summary>
        /// 点击语言切换
        /// </summary>
        private void MenuItem_Click(object sender, EventArgs e)
        {
            // 获取当前按下的menuItem
            ToolStripMenuItem clickedMenuItem = (ToolStripMenuItem)sender;
            // 获取当前按下的menuItem的名称
            string menuItemName = clickedMenuItem.Text;
            // 如果已经有选中的菜单项，则取消其选中状态
            if (selectedMenuItem != null)
            {
                selectedMenuItem.Checked = false;
            }

            // 切换语言
            SwitchLanguage(menuItemName);

            // 设置当前语言菜单项为选中状态
            clickedMenuItem.Checked = true;
            selectedMenuItem = clickedMenuItem; // 更新选中的菜单项
        }

        /// <summary>
        /// 加载资源文件
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        static Dictionary<string, string> LoadResources(string FilePath)
        {
            Dictionary<string, string> resources = new Dictionary<string, string>();

            if (File.Exists(FilePath))
            {
                string[] lines = File.ReadAllLines(FilePath);

                foreach (string line in lines)
                {
                    int separatorIndex = line.IndexOf('=');
                    if (separatorIndex > 0)
                    {
                        string key = line.Substring(0, separatorIndex);
                        string value = line.Substring(separatorIndex + 1);
                        resources[key] = value;
                    }
                }
            }

            return resources;
        }

        /// <summary>
        /// 编辑资源文件
        /// </summary>
        /// <param name="FilePath">修改文件的路径</param>
        /// <param name="key"></param>
        /// <param name="value">新值</param>
        static void EditResources(string FilePath, string key, string value)
        {
            string[] lines = File.ReadAllLines(FilePath);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(key))
                {
                    int equalsIndex = lines[i].IndexOf("=");
                    string modifiedLine = lines[i].Substring(0, equalsIndex + 1) + value;
                    lines[i] = modifiedLine;
                    break;
                }
            }

            File.WriteAllLines(FilePath, lines);
        }

        /// <summary>
        /// 获取加载的资源值
        /// </summary>
        /// <param name="resources"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        static string GetResourceValue(Dictionary<string, string> resources, string key)
        {
            if (resources.ContainsKey(key))
            {
                return resources[key];
            }

            return string.Empty;
        }


        /// <summary>
        /// 获取系统类型
        /// </summary>
        public static string libs = Environment.Is64BitOperatingSystem ? "x64" : "x86";

        /// <summary>
        /// 压缩图片
        /// </summary>
        /// <param name="source">原文件位置</param>
        /// <param name="output">新文件位置</param>
        /// /// <param name="fileName">文件名</param>
        /// <param name="quality">图片质量，范围0-100</param>
        public static void Compress(string source, string output, string fileName, int quality)
        {
            // 获取文件格式
            string extension = Path.GetExtension(fileName).ToLower();

            // 判断文件格式使用对应处理方法
            if (extension == ".jpg" || extension == ".jpeg")
            {
                // 处理JPG文件
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = libs + "\\cjpeg.exe";
                startInfo.Arguments = "-quality " + quality + " -outfile " + output + " " + source;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
            }
            else if (extension == ".png")
            {
                // 处理PNG文件
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = libs + "\\pngquant.exe";
                startInfo.Arguments = "--force " + "--quality=" + quality + " \"" + source + "\" -o \"" + output + "\"";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();

            }
            else if (extension == ".gif")
            {
                // 处理GIF文件
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = libs + "\\gifski.exe";
                startInfo.Arguments = "--quality " + quality + " \"" + source + "\" -o \"" + output + "\"";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
            }
        }

        /// <summary>
        /// 检查文件列表是否显示
        /// </summary>
        private void FileListViewVisible()
        {
            if (FileListView.Items.Count == 0)
            {
                FileListView.Visible = false;
            }
            else
            {
                FileListView.Visible = true;
            }
        }

        // 添加按钮_添加图像
        private void AddToolStripButton_Click(object sender, EventArgs e)
        {
            // 显示对话框
            DialogResult result = OpenFileDialog.ShowDialog();

            // 如果用户选择了文件
            if (result == DialogResult.OK)
            {
                string[] files = OpenFileDialog.FileNames;
                AddFileListItem(files);
            }
        }

        

        // 清空列表
        private void ClearToolStripButton_Click(object sender, EventArgs e)
        {
            FileListView.Items.Clear(); //清空列表
            FileListViewVisible(); //如果没有任务隐藏列表视图
        }

        // 开始按钮
        private void StartToolStripButton_Click(object sender, EventArgs e)
        {
            //如果目录不存在自动创建
            Directory.CreateDirectory(OutputTextBox.Text);
            //如果保存路径后面没有\结尾需要加\
            if (!OutputTextBox.Text.EndsWith(@"\"))
            {
                OutputTextBox.Text += @"\";
            }

            //输出目录
            string output = OutputTextBox.Text;

            //图片质量
            int quality = int.Parse(QualityComboBox.Text);

            int i = 0;

            foreach (ListViewItem item in FileListView.Items)
            {
                string path = item.SubItems[0].Text;
                string fileName = item.SubItems[2].Text;
                string source = path;

                // 开始压缩
                Compress(source, output + fileName, fileName, quality);

                FileListView.Items[i].SubItems[1].Text = "✔"; //状态完成符合

                FileInfo fileInfo = new FileInfo(output + fileName);
                double size = fileInfo.Length;
                string[] sizes = { "B", "KB", "MB", "GB", "TB" };
                int order = 0;
                while (size >= 1024 && order < sizes.Length - 1)
                {
                    order++;
                    size /= 1024;
                }

                FileListView.Items[i].SubItems[4].Text = string.Format("{0:0.##} {1}", size, sizes[order]);
                i++;
            }
        }



        // 质量值如果不符合提示
        private void QualityComboBox_TextChanged(object sender, EventArgs e)
        {
            if (QualityComboBox.Text != "" && !System.Text.RegularExpressions.Regex.IsMatch(QualityComboBox.Text, "^[0-9]*$"))
            {
                MessageBox.Show(ErrorInfo1, ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                QualityComboBox.Text = "80";
            }
            int value;
            if (Int32.TryParse(QualityComboBox.Text, out value))
            {
                if (value > 100)
                {
                    MessageBox.Show(ErrorInfo2, ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    QualityComboBox.Text = "80";
                }
            }
        }


        // 拖入事件
        private void ImageFileDragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            AddFileListItem(files);
        }
        // 拖入规则
        private void ImageFileDragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    if (fileInfo.Extension == ".jpg" || fileInfo.Extension == ".png" || fileInfo.Extension == ".jpeg" || fileInfo.Extension == ".gif")
                    {
                        e.Effect = DragDropEffects.Copy;
                        return;
                    }
                }
            }
            e.Effect = DragDropEffects.None;
        }

        // 添加图像信息到列表事件
        private void AddFileListItem(string[] files)
        {
            // 创建新行并将文件路径添加到ListView中
            foreach (string file in files)
            {
                //获取图片文件大小
                FileInfo fileInfo = new FileInfo(file);
                if (fileInfo.Extension == ".jpg" || fileInfo.Extension == ".png" || fileInfo.Extension == ".jpeg" || fileInfo.Extension == ".gif")
                {
                    double size = fileInfo.Length;
                    string[] sizes = { "B", "KB", "MB", "GB", "TB" };
                    int order = 0;
                    while (size >= 1024 && order < sizes.Length - 1)
                    {
                        order++;
                        size /= 1024;
                    }

                    string file_path = file; //文件路径
                    string file_name = Path.GetFileName(file); //文件名
                    string file_Length = string.Format("{0:0.##} {1}", size, sizes[order]); //图片文件大小

                    ListViewItem item = new ListViewItem();
                    item.SubItems[0].Text = file_path;
                    item.SubItems.Add("");
                    item.SubItems.Add(file_name);
                    item.SubItems.Add(file_Length);
                    item.SubItems.Add("");
                    FileListView.Items.Add(item);
                }
            }
            FileListViewVisible(); //如果没有任务隐藏列表视图
        }

        /// <summary>
        /// 保存路径
        /// </summary>
        // 浏览按钮
        private void BrowseFileButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                OutputTextBox.Text = dialog.SelectedPath;
                //如果保存路径后面没有\结尾需要加\
                if (!OutputTextBox.Text.EndsWith(@"\"))
                {
                    OutputTextBox.Text += @"\";
                }
            }
        }

        // 打开按钮
        private void OpenOutputButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", OutputTextBox.Text);
        }

        // 帮助
        private void WebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://ialong.cn");
        }

        // 关于
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ImageShrink 1.0 \n\nMozJPEG      4.0.3 \npngquant    2.17.0 \nGifski            1.11.0 \n\nCopyright © ialong.cn", AboutTitle);
        }
    }
}
