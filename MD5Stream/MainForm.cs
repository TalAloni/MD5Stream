using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MD5Stream
{
    public partial class MainForm : Form
    {
        private bool m_isBusy = false;
        private bool m_isClosing = false;

        private int m_correctCount;
        private int m_incorrectCount;
        private int m_createdCount;
        private int m_updatedCount;
        private int m_invalidCount;
        private int m_inaccessibleCount;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            m_isBusy = true;
            txtPath.Enabled = false;
            btnBrowse.Enabled = false;
            btnStart.Enabled = false;
            listCorrect.Items.Clear();
            listIncorrect.Items.Clear();
            listAdded.Items.Clear();
            listUpdated.Items.Clear();
            listInvalid.Items.Clear();
            listInaccessible.Items.Clear();
            m_correctCount = 0;
            m_incorrectCount = 0;
            m_createdCount = 0;
            m_updatedCount = 0;
            m_invalidCount = 0;
            m_inaccessibleCount = 0;
            tabCorrect.Text = String.Format("Correct ({0})", m_correctCount);
            tabIncorrect.Text = String.Format("Incorrect ({0})", m_incorrectCount);
            tabAdded.Text = String.Format("Added ({0})", m_createdCount);
            tabUpdated.Text = String.Format("Updated ({0})", m_updatedCount);
            tabInvalid.Text = String.Format("Invalid ({0})", m_invalidCount);
            tabInaccessible.Text = String.Format("Inaccessible ({0})", m_inaccessibleCount);
            statusBarLabelProgress.Text = "Building file list...";

            Thread thread1 = new Thread
            (delegate()
            {
                List<string> fileList = null;
                try
                {
                    fileList = BuildFileList(txtPath.Text);
                }
                catch (DirectoryNotFoundException ex)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show(ex.Message, "Error");
                    });
                }
                catch (UnauthorizedAccessException ex)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show(ex.Message, "Error");
                    });
                }
                
                if (fileList != null)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        statusBarLabelProgress.Text = String.Format("{0} files added to queue", fileList.Count);
                    });
                    ProcessFileList(fileList);
                }
                this.Invoke((MethodInvoker)delegate
                {
                    txtPath.Enabled = true;
                    btnBrowse.Enabled = true;
                    btnStart.Enabled = true;
                    m_isBusy = false;
                    if (m_isClosing)
                    {
                        this.Close();
                    }
                });
            });
            thread1.Start();
        }

        public void ProcessFileList(List<string> fileList)
        {
            DateTime startDT = DateTime.Now;
            long bytesHashed = 0;
            for(int index = 0; index < fileList.Count; index++)
            {
                string path = fileList[index];
                
                FileInfo fileInfo = new FileInfo(path);
                bool isSystemFile = (fileInfo.Attributes & FileAttributes.System) > 0;
                bool isReadOnly = fileInfo.IsReadOnly;
                if (isSystemFile)
                {
                    fileList.RemoveAt(index);
                    index--;
                    continue;
                }
                MD5StreamStatus status;
                try
                {
                    if (isReadOnly)
                    {
                        fileInfo.IsReadOnly = false;
                    }
                    status = MD5StreamHelper.TestMD5Stream(fileInfo);
                    if (isReadOnly)
                    {
                        fileInfo.IsReadOnly = true;
                    }
                }
                catch (FileNotFoundException)
                {
                    AddFileToInaccessible(path);
                    continue;
                }
                catch (DirectoryNotFoundException)
                {
                    AddFileToInaccessible(path);
                    continue;
                }
                catch (UnauthorizedAccessException)
                {
                    AddFileToInaccessible(path);
                    continue;
                }
                catch (IOException)
                {
                    AddFileToInaccessible(path);
                    continue;
                }

                switch(status)
                {
                    case MD5StreamStatus.Correct:
                    {
                        AddFileToCorrect(path);
                        break;
                    }
                    case MD5StreamStatus.Incorrect:
                    {
                        AddFileToIncorrect(path);
                        break;
                    }
                    case MD5StreamStatus.Created:
                    {
                        AddFileToCreated(path);
                        break;
                    }
                    case MD5StreamStatus.Updated:
                    {
                        AddFileToUpdated(path);
                        break;
                    }
                    case MD5StreamStatus.Invalid:
                    {
                        AddFileToInvalid(path);
                        break;
                    }
                }

                bytesHashed += fileInfo.Length;
                UpdateStatusBar(index + 1, fileList.Count, bytesHashed, startDT);
                if (m_isClosing)
                {
                    return;
                }
            }
            // If the last file was inaccessible we did not yet updated the status bar
            UpdateStatusBar(fileList.Count, fileList.Count, bytesHashed, startDT);
        }

        private void AddFileToCorrect(string path)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    AddFileToCorrect(path);
                });
            }
            else
            {
                m_correctCount++;
                tabCorrect.Text = String.Format("Correct ({0})", m_correctCount);
                listCorrect.Items.Add(path);
            }
        }

        private void AddFileToIncorrect(string path)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    AddFileToIncorrect(path);
                });
            }
            else
            {
                m_incorrectCount++;
                tabIncorrect.Text = String.Format("Incorrect ({0})", m_incorrectCount);
                listIncorrect.Items.Add(path);
            }
        }

        private void AddFileToCreated(string path)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    AddFileToCreated(path);
                });
            }
            else
            {
                m_createdCount++;
                tabAdded.Text = String.Format("Added ({0})", m_createdCount);
                listAdded.Items.Add(path);
            }
        }

        private void AddFileToUpdated(string path)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    AddFileToUpdated(path);
                });
            }
            else
            {
                m_updatedCount++;
                tabUpdated.Text = String.Format("Updated ({0})", m_updatedCount);
                listUpdated.Items.Add(path);
            }
        }

        private void AddFileToInvalid(string path)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    AddFileToInvalid(path);
                });
            }
            else
            {
                m_invalidCount++;
                tabInvalid.Text = String.Format("Invalid ({0})", m_invalidCount);
                listInvalid.Items.Add(path);
            }
        }


        private void AddFileToInaccessible(string path)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    AddFileToInaccessible(path);
                });
            }
            else
            {
                m_inaccessibleCount++;
                tabInaccessible.Text = String.Format("Inaccessible ({0})", m_inaccessibleCount);
                listInaccessible.Items.Add(path);
            }
        }

        private void UpdateStatusBar(int filesHashed, int filesTotal, long bytesHashed, DateTime startDT)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    UpdateStatusBar(filesHashed, filesTotal, bytesHashed, startDT);
                });
            }
            else
            {
                double totalSeconds = ((TimeSpan)(DateTime.Now - startDT)).TotalSeconds;
                totalSeconds = Math.Max(totalSeconds, 1);
                double speed = (double)bytesHashed / totalSeconds / 1024 / 1024;
                string progressBarText = String.Format("Hashed: {0} Files, {1:###,###,##0} MB, Speed: {2:0.0} MB/s", filesHashed, bytesHashed / 1024 / 1024, speed);
                if (filesHashed < filesTotal)
                {
                    progressBarText += String.Format(" ({0} files remaining)", filesTotal - filesHashed);
                }
                statusBarLabelProgress.Text = progressBarText;
            }
        }

        private static List<string> BuildFileList(string path)
        {
            List<string> fileList = new List<string>();
            if (File.Exists(path))
            {
                fileList.Add(path);
                return fileList;
            }
            else if (Directory.Exists(path))
            {
                List<string> directories = new List<string>();
                directories.Add(path);
                while (directories.Count > 0)
                {
                    string currentPath = directories[0];
                    fileList.AddRange(Directory.GetFiles(currentPath));
                    directories.AddRange(Directory.GetDirectories(currentPath));
                    directories.RemoveAt(0);
                }
                return fileList;
            }
            else
            {
                throw new DirectoryNotFoundException(String.Format("Could not find a part of the path '{0}'.", path));
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_isBusy)
            {
                e.Cancel = true;
                statusBarLabelProgress.Text = "Aborting...";
                m_isClosing = true;
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            tabControl.Width = this.Width - 32;
            tabControl.Height = this.Height - 95;
        }

        private void tabControl_Resize(object sender, EventArgs e)
        {
            listCorrect.Width = tabControl.Width - 20;
            listIncorrect.Width = tabControl.Width - 20;
            listAdded.Width = tabControl.Width - 20;
            listUpdated.Width = tabControl.Width - 20;
            listInvalid.Width = tabControl.Width - 20;
            listInaccessible.Width = tabControl.Width - 20;

            listCorrect.Height = tabControl.Height - 29;
            listIncorrect.Height = tabControl.Height - 29;
            listAdded.Height = tabControl.Height - 29;
            listUpdated.Height = tabControl.Height - 29;
            listInvalid.Height = tabControl.Height - 29;
            listInaccessible.Height = tabControl.Height - 29;
        }
    }
}