using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace ffmpeg_launcher
{
    public partial class Form1 : Form
    {
        private string app = String.Empty;
        private string args = String.Empty;
        private int procId = -1;
        private int updown = 1 ;
        private Timer watchdog;
        private bool runminimized = false;
        private bool showOnce = false;
        private bool procRun = false;
        private bool runProcAtStartApp = false;

        // Автозапуск в реестре 
        RegistryKey registryApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        

        public Form1()
        {
            InitializeComponent();
            CfgLoad();

            
            
            if (updown > 1) UpDownTimeout.Value = updown;

            AppTextBox.Text = app;
            ArgsTextBox.Text = args;
            
            if (runminimized)
            {
                RunMinimized.Checked = true;
            }
            else
            {
                RunMinimized.Checked = false;
            }

            if (procId == -1)
            {
                toolStripLabelApp.Text = "Процесс не выбран";
            }
            else
            {
                if (CheckIfProcessIsRunning(procId))
                {
                    StatusTextBox.Text = "Продолжаю наблюдение.\r\n";
                    InitTimer();
                }
                
                toolStripLabelApp.Text = procId.ToString();
            }

            if (CheckIfProcessIsRunning(procId))
            {
                procRun = true;
                if (runProcAtStartApp)
                {
                    
                    chkAutostartProc.Checked = true;
                }
                else
                {
                    chkAutostartProc.Checked = false;
                }
            }
            else
            {
                procRun = false;
                if (runProcAtStartApp)
                {
                    ProcStart(app, args);
                    chkAutostartProc.Checked = true;
                    InitTimer();
                }
                else
                {
                    chkAutostartProc.Checked = false;
                }
            }

            if (registryApp.GetValue(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name) == null)
            {
                // The value doesn't exist, the application is not set to run at startup
                runWithWindows.Checked = false;
            }
            else
            {
                // The value exists, the application is set to run at startup
                runWithWindows.Checked = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ArgsTextBox_TextChanged(object sender, EventArgs e)
        {
            args = ArgsTextBox.Text;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Executable|*.exe"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                AppTextBox.Text = openFileDialog.FileName;
                app = openFileDialog.FileName;
               

            }
        }

        private void btnRunStop_Click(object sender, EventArgs e)
        {
            if (!procRun)
            {
                
                if (AppTextBox.Text.Length != 0)
                {
                    ProcStart(app, args);
                    InitTimer();
                    procRun = true;

                }
                else
                {
                    MessageBox.Show("Выберите приложение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (UpDownTimeout.Value % 10 == 1)
            {
                labelSeconds.Text = "секунду";
            }
            else if (UpDownTimeout.Value % 10 >= 2 && UpDownTimeout.Value <= 4)
            {
                labelSeconds.Text = "секунды";
            }
            else
            {
                labelSeconds.Text = "секунд";
            }
            updown = (int)UpDownTimeout.Value;
        }

        private void AppTextBox_TextChanged(object sender, EventArgs e)
        {
            app = AppTextBox.Text;
        }
        /// <summary>
        /// Запускает процесс
        /// </summary>
        /// <param name="application">Приложение</param>
        /// <param name="arguments">Параметры</param>
        private void ProcStart(string application, string arguments)
        {
            if (File.Exists(application))
            {
                var proc = new Process();

            proc.StartInfo.FileName = application;
            proc.StartInfo.Arguments = arguments;
            if(runminimized) proc.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;

            procRun = proc.Start();

            
                try
                {
                    procId = proc.Id;
                    toolStripLabelApp.Text = $"{procId}";
                    StatusTextBox.AppendText($"{DateTime.Now}\r\n{app} {ArgsTextBox.Text}\r\n\r\n");
                    CfgSave();
                    procRun = true;

                    // Парсим строку аргументов, если находим в последнем аргументе .m3u8, то удаляем из каталога,
                    // куда ссылкается плейлист, все файлы .ts и сам плейлист

                    if (ArgsTextBox.Text.Length > 0)
                    {
                        Regex appRegex = new Regex(@"\S+\.m3u8$", RegexOptions.IgnoreCase);
                        MatchCollection matches;
                        matches = appRegex.Matches(ArgsTextBox.Text);
                        if (matches.Count > 0)
                        {
                            foreach (Match a in matches)
                            {
                                string tempPath = String.Empty;

                                string[] tempStr = a.Value.Split('\\');
                                string fileName = tempStr[tempStr.Length - 1];
                                for (byte i = 0; i < tempStr.Length - 1; i++)
                                {
                                    tempPath += $"{tempStr[i]}\\";
                                }
                                try
                                {


                                    if (File.Exists(tempPath + fileName)) File.Delete(tempPath + fileName);
                                    string[] nameBodyTemp = fileName.Split('.');
                                    string nameBody = String.Empty;
                                    for (byte i = 0; i < nameBodyTemp.Length - 1; i++)
                                    {
                                        nameBody += $"{nameBodyTemp[i]}";
                                    }

                                    var tsFiles = Directory.EnumerateFiles(tempPath, $"{nameBody}*.ts");
                                    foreach (string currentFile in tsFiles)
                                    {
                                        File.Delete(currentFile);
                                    }
                                }
                                catch
                                {
                                    return;
                                }
                            }

                        }

                    }

                }
                catch (InvalidOperationException)
                {
                    procRun = false;
                }
                catch (Exception ex)
                {
                    procRun = false;
                }
            }
            else
            {
                MessageBox.Show($"Файл {application} не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        // Таймер
        public void InitTimer()
        {
            watchdog = new Timer();
            watchdog.Tick += new EventHandler(timer1_Tick);
            watchdog.Interval = updown * 1000; // in miliseconds
            watchdog.Start();
        }

        // событие, которое случается по истечении таймера
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!CheckIfProcessIsRunning(procId))
            {
                ProcStart(app, args);
            }
        }
        /// <summary>
        /// Проверяет, запущен ли процесс
        /// </summary>
        /// <param name="pid">PID процесса</param>
        /// <returns></returns>
        private bool CheckIfProcessIsRunning(int pid)
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.Id == pid)
                {
                    return true;
                    
                }
            }
            return false;
            

        }

            private void labelSeconds_Click(object sender, EventArgs e)
        {

        }

        private void RunMinimized_CheckedChanged(object sender, EventArgs e)
        {
            if (RunMinimized.Checked)
            {
                runminimized = true;
                CfgSave();
            }
            else
            {
                runminimized = false;
                CfgSave();
            }
        }
        /// <summary>
        /// Сохраняет параметр конфигурации
        /// </summary>
        
        private void CfgSave()
        {
            
            string confName = AppDomain.CurrentDomain.BaseDirectory + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".conf";
            try
            {
         
            using (StreamWriter writer = new StreamWriter(confName))
            {
                writer.WriteLine($"app = {app}");
                writer.WriteLine($"args = {args}");
                writer.WriteLine($"PID = {procId}");
                writer.WriteLine($"isMinimized = {runminimized}");
                writer.WriteLine($"timeout = {updown}");
                writer.WriteLine($"runProcAtStart = {runProcAtStartApp}");
            }
            }
            catch
            {
                if (!showOnce)
                {
                    MessageBox.Show($"Не могу записать в {confName}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    showOnce = true;
                }
            }
        }

        /// <summary>
        /// Загружает сохраненные параметры
        /// </summary>

        private void CfgLoad()
        {
            string confName = AppDomain.CurrentDomain.BaseDirectory + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".conf";
            
            if (File.Exists(confName))
            {
                string[] lines = File.ReadAllLines(confName);
                string appPat = @"(app)(\s?=\s?)(.*)";
                string argPat = @"(args)(\s?=\s?)(.*)";
                string pidPat = @"(PID)(\s?=\s?)(.*)";
                string minPat = @"(isMinimized)(\s?=\s?)(.*)";
                string timePat = @"(timeout)(\s?=\s?)(.*)";
                string runProcAtStart = @"(runProcAtStart)(\s?=\s?)(.*)";

                MatchCollection matches;

                Regex regex = new Regex(appPat, RegexOptions.IgnoreCase);
                foreach (string line in lines)
                {
                    matches = regex.Matches(line);
                    if(matches.Count > 0)
                    {
                        foreach (Match a in matches)
                        {
                            app = a.Groups[3].Value;

                        }
                    }
                }

                regex = new Regex(argPat, RegexOptions.IgnoreCase);
                foreach (string line in lines)
                {
                    matches = regex.Matches(line);
                    if (matches.Count > 0)
                    {
                        foreach (Match a in matches)
                        {
                            args = a.Groups[3].Value;

                        }
                    }
                }

                regex = new Regex(pidPat, RegexOptions.IgnoreCase);
                foreach (string line in lines)
                {
                    matches = regex.Matches(line);
                    if (matches.Count > 0)
                    {
                        foreach (Match a in matches)
                        {
                            int.TryParse(a.Groups[3].Value, out procId);

                        }
                    }
                }

                regex = new Regex(minPat, RegexOptions.IgnoreCase);
                foreach (string line in lines)
                {
                    matches = regex.Matches(line);
                    if (matches.Count > 0)
                    {
                        foreach (Match a in matches)
                        {
                            bool.TryParse(a.Groups[3].Value, out runminimized);

                        }
                    }
                }

                regex = new Regex(timePat, RegexOptions.IgnoreCase);
                foreach (string line in lines)
                {
                    matches = regex.Matches(line);
                    if (matches.Count > 0)
                    {
                        foreach (Match a in matches)
                        {
                            int.TryParse(a.Groups[3].Value, out updown);

                        }
                    }
                }

                regex = new Regex(runProcAtStart, RegexOptions.IgnoreCase);
                foreach (string line in lines)
                {
                    matches = regex.Matches(line);
                    if (matches.Count > 0)
                    {
                        foreach (Match a in matches)
                        {
                            bool.TryParse(a.Groups[3].Value, out runProcAtStartApp);

                        }
                    }
                }

            }
        }

        private void chkAutostartProc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutostartProc.Checked)
            {
                runProcAtStartApp = true;
                CfgSave();
            }
            else
            {
                runProcAtStartApp = false;
                CfgSave();
            }
        }

        private void runWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            if (runWithWindows.Checked)
            {
                // Add the value in the registry so that the application runs at startup
                if (registryApp.GetValueNames().Contains(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name))
                {
                    int compare = String.Compare(registryApp.GetValue(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name).ToString(), Application.ExecutablePath, true);
                    //MessageBox.Show($"{registryApp.GetValue(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name).ToString()}, {Application.ExecutablePath}, {compare}");
                    if (compare == 0)
                    {

                    }
                    //MessageBox.Show($"{registryApp.Name} = {registryApp.GetValue(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name)}");
                }
                
                //if (registryApp.Name && String.Compare)
                //{
                registryApp.SetValue(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, Application.ExecutablePath);
                //}
                
                
                //MessageBox.Show($"{registryApp.Name} = {registryApp.GetValue(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name)}");
            }
            else
            {
                // Remove the value from the registry so that the application doesn't start
                
                    registryApp.DeleteValue(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, false);
            }
        }
    }
        
    
}
