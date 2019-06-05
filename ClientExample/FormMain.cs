using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Windows.Forms.DataVisualization.Charting;
using ClientExample;


namespace ClientExample
{
    public partial class FormMain : Form
    {
        List<int> indexes = new List<int>() { 0,0,0};
        List<List<double>> values = new List<List<double>>();
        List<List<double>> diffs = new List<List<double>>();
        bool[] strain = new bool[2];
        bool gameStarted = false;
        bool playersReady = false;
        bool leftTurn = false;
        Game game;
        Image leftFighter = Image.FromFile(Environment.CurrentDirectory + @"\Pictures\leftFighter.jpg");
        Image rightFighter = Image.FromFile(Environment.CurrentDirectory + @"\Pictures\rightFighter.jpg");
        Image attackLeft = Image.FromFile(Environment.CurrentDirectory + @"\Pictures\attackLeft.jpg");
        Image attackRight = Image.FromFile(Environment.CurrentDirectory + @"\Pictures\attackRight.jpg");
        Image winner = Image.FromFile(Environment.CurrentDirectory + @"\Pictures\winner.jpg");
        Image loser = Image.FromFile(Environment.CurrentDirectory + @"\Pictures\loser.jpg");
        int border;
        double timingstart = 0;
        int range = 1000;
        int[] _channelNumbers = new int[2] { 2, 13};
        int _channelCount = 2;
        int[] k = new int[] {0, 0};
        double timing = 0;
        bool gameEnded = false;
        public FormMain()
        {
            InitializeComponent();
            myClientControl.Client.Reseive += Client_Reseive;
            myClientControl.Client.Error += Client_Error;
            label1.Font = new Font("Aerial", 16, FontStyle.Bold);
            LabelTurn.Font = new Font("Aerial", 16, FontStyle.Bold);
            LabelDamage.Font = new Font("Aerial", 16, FontStyle.Bold);
            //ChartFOr1.ChartAreas[0].AxisY.Maximum = 6000;
            //ChartFOr1.ChartAreas[0].AxisY.Minimum = -2000;
            SetFighters();
            border = Convert.ToInt16(NUDBorder.Value);
            for (int i = 0; i < _channelCount; i++)
            {
                values.Add(new List<double>());
                diffs.Add(new List<double>());
            }
            game = new Game();
            groupBox1.Text = game.FighterLeft.Name;
            groupBox2.Text = game.FighterRight.Name;
            SetHP();
        }

        

        private void Client_Error(object sender, NetManager.EventMsgArgs e)
        {
            MessageBox.Show(e.Msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Client_Reseive(object sender, NetManager.EventClientMsgArgs e)
        {
            int n = BitConverter.ToInt32(e.Msg, 0);

            //int _channelNumber = 23;
            if (n == 6)
            {
                if (!game.IsGameEnded)
                {
                    Frame dataFrame = new Frame(e.Msg);
                    List<int> dataStart = new List<int>();
                    timing += Frame.LengthData;
                    setTime();
                    if (!playersReady)
                    {
                        for (int i = 0; i < _channelCount; i++)
                        {
                            dataStart.Add(_channelNumbers[i] * Frame.LengthData);
                        }

                        for (int j = 0; j < dataStart.Count; j++)
                        {
                            values[j].Add(dataFrame.Data[dataStart[j]]);
                            k[j]++;
                        }

                        if (values[0].Count % 21 == 0)
                        {
                            for (int i = 0; i < _channelCount; i++)
                            {
                                List<double> l = setArr(values[i], values[i].Count - 21, values[i].Count);
                                double s = SquareDiff.GetSquareDiff(l);
                                diffs[i].Add(s);
                                strain[i] = CheckMuscles(s);
                            }
                            if (strain[0] == true && strain[1] == true)
                            {
                                playersReady = true;
                                timingstart = timing;
                            }

                        }
                        if (values[0].Count % 105 == 0)
                        {
                            showAllres();
                        }
                    }
                    else
                    {
                        if (!gameStarted)
                        {
                            label1.Text = "Приготовтесь: первый ход игрока 1";
                            if (timing - timingstart > 10000)
                            {
                                label1.Text = "FIGHT";
                                gameStarted = true;
                                timingstart = timing;
                               // leftTurn = false;
                                ChangeState();
                                values[0].Clear();
                                values[1].Clear();
                                diffs[0].Clear();
                                diffs[1].Clear();
                                foreach (Series s in ChartForDiff.Series)
                                {
                                    s.Points.Clear();
                                }
                            }
                        }
                        else // идет игра
                        {
                            int k = getChannel();
                            if (timing - timingstart > 30000)
                            {
                                values[k].Clear();
                                game.makeTurn((int)findMax(diffs[k]), leftTurn);
                                diffs[k].Clear();
                                ChangeState();
                                SetHP();
                            }
                            else
                            {
                                dataStart.Add(_channelNumbers[k] * Frame.LengthData);
                                for (int i = 0; i < Frame.LengthData; i++)
                                {
                                    values[k].Add(dataFrame.Data[k + i]);
                                }
                                if (values[k].Count % 21 == 0)
                                {
                                    List<double> l = setArr(values[k], values[k].Count - 21, values[k].Count);
                                    double s = SquareDiff.GetSquareDiff(l);
                                    diffs[k].Add(s);
                                }
                                if (values[k].Count % 105 == 0)
                                    showAllres();
                            }

                        }
                    }
                }
                else
                {
                    if (!gameEnded)
                    {
                       
                        PlaceResults();
                        gameEnded = true;
                    }
                                     
                }
            }
        }

        private void PlaceResults()
        {
            label1.Text = "Поздравляем " + game.winner.Name + " с победой";
            if (game.winner.Pos == 0)
            {
                PBLeft.Image = winner;
                PBRight.Image = loser;
            }
            else
            {
                PBRight.Image = winner;
                PBLeft.Image = loser;
            }
        }

        private void SetHP()
        {
            rightHp.Text = "HP: " + game.FighterRight.HP;
            LeftHP.Text = "HP: " + game.FighterLeft.HP;
        }

        private void showAllres()
        {
            if (diffs[0].Count != 0 && diffs[1].Count!=0)
            {
                if (diffs[0].Count > range / 5)
                {
                    ChartForDiff.Series[0].Points.Clear();
                    ChartForDiff.Series[1].Points.Clear();
                    ChartForDiff.Series[2].Points.Clear();
                    for (int i = diffs[0].Count - range / 5; i < diffs[0].Count; i++)
                    {
                        ChartForDiff.Series[0].Points.AddXY(i, diffs[0][i]);
                        ChartForDiff.Series[1].Points.AddXY(i, border);
                        ChartForDiff.Series[2].Points.AddXY(i, diffs[1][i]);
                    }
                }
                else
                {
                    ChartForDiff.Series[1].Points.AddXY(diffs[0].Count - 1, border);
                    ChartForDiff.Series[0].Points.AddXY(diffs[0].Count - 1, diffs[0][diffs[0].Count - 1]);
                    ChartForDiff.Series[2].Points.AddXY(diffs[1].Count - 1, diffs[1][diffs[1].Count - 1]);
                }
            }
            else
            {
                if (diffs[0].Count != 0)
                {
                    if (diffs[0].Count > range / 5)
                    {
                        
                        ChartForDiff.Series[0].Points.Clear();
                        ChartForDiff.Series[1].Points.Clear();
                        for (int i = diffs[0].Count - range / 5; i < diffs[0].Count; i++)
                        {
                            ChartForDiff.Series[0].Points.AddXY(i, diffs[0][i]);
                            ChartForDiff.Series[1].Points.AddXY(i, border);
                        }
                    }
                    else
                    {
                        ChartForDiff.Series[2].Points.Clear();
                        ChartForDiff.Series[1].Points.AddXY(diffs[0].Count - 1, border);
                        ChartForDiff.Series[0].Points.AddXY(diffs[0].Count - 1, diffs[0][diffs[0].Count - 1]);

                    }
                }
                else
                {

                    if (diffs[1].Count != 0)
                    {
                        if (diffs[1].Count > range / 5)
                        {
                            ChartForDiff.Series[2].Points.Clear();
                            ChartForDiff.Series[0].Points.Clear();
                            ChartForDiff.Series[1].Points.Clear();
                            for (int i = diffs[1].Count - range / 5; i < diffs[1].Count; i++)
                            {
                                ChartForDiff.Series[2].Points.AddXY(i, diffs[1][i]);
                                ChartForDiff.Series[1].Points.AddXY(i, border);
                            }
                        }
                        else
                        {
                            ChartForDiff.Series[0].Points.Clear();
                            ChartForDiff.Series[1].Points.AddXY(diffs[1].Count - 1, border);
                            ChartForDiff.Series[2].Points.AddXY(diffs[1].Count - 1, diffs[1][diffs[1].Count - 1]);

                        }
                    }
                }
            }
           


        }

        private void SetFighters()
        {
            PBLeft.Image = leftFighter;
            PBRight.Image = rightFighter;
        }

        private double findMax(List<double> l)
        {
            double max = 0;
            foreach(double x in l)
            {
                if (x > max)
                {
                    max = x;
                }
            }
            return max;
        }

        private int getChannel()
        {
            if (leftTurn)
                return 0;
            else
                return 1;
        }

        private void ChangeState()
        {
            leftTurn = !leftTurn; 
            if (leftTurn)
            {
                label1.Text = "Ход игрока 1";
                PBRight.Image = attackRight;
                PBLeft.Image = null;
            }
            else
            {
                label1.Text = "Ход игрока 2";
                PBLeft.Image = attackLeft;
                PBRight.Image = null;
            }
           
            timingstart = timing;
        }

        private bool CheckMuscles(double s)
        {
            return s > border;
        }

        private List<double> setArr(List<double> l, int left, int right)
        {
            List<double> arr = new List<double>();

            for (int i = left; i < right; i++)
            {
                arr.Add(l[i]);

            }
            return arr;
        }
        private void setTime()
        {
            double time = timing * 1 / 5000;
            TimingLabel.Text = time.ToString();
        }
        private double[] setArr(List<int> l, int left, int right)
        {
            double[] arr = new double[right - left];
            int k = 0;
            for (int i = left; i < right; i++)
            {
                arr[k] = l[i];
                k++;
            }
            return arr;
        }
       
     
       
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadState();
        }

        private void LoadState()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(InitFileName);
                XmlElement netManager = xmlDoc["Settings"]["NetManager"];
                myClientControl.LoadState(netManager);
            }
            catch { }
        }

        private string InitFileName = "Settings.xml";

        private void SaveState()
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(InitFileName);
            }
            catch
            {
                xmlDoc.AppendChild(xmlDoc.CreateElement("Settings"));
            }

            XmlElement root = xmlDoc.DocumentElement;

            XmlElement netManager = root["NetManager"];
            if (netManager == null)
            {
                netManager = xmlDoc.CreateElement("NetManager");
                root.AppendChild(netManager);
            }

            myClientControl.SaveState(netManager);

            xmlDoc.Save(InitFileName);
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveState();
        }

        private void myClientControl_Load(object sender, EventArgs e)
        {

        }

        private void ChartFor2_Click(object sender, EventArgs e)
        {

        }

        private void NUDBorder_ValueChanged(object sender, EventArgs e)
        {
            border = Convert.ToInt16(NUDBorder.Value);
        }
    }
}
