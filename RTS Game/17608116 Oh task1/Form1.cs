using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace _17608116_Oh_task1
{
    public partial class RTSGame : Form
    {
        bool team1 = false;
        Timer t = new Timer();
        int T = 0;
        public Map RTSmap = new Map();
        public RangedUnit Runit = new RangedUnit();
        public MeleeUnit Munit = new MeleeUnit();
        ResourceBuilding RBuilding = new ResourceBuilding();
        FactoryBuilding FBuilding;
        

        public RTSGame()
        {
            InitializeComponent();
        }

        private void RTSGame_Load(object sender, EventArgs e)
        {
            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_Tick);
            createMap();
            FBuilding = new FactoryBuilding(this);
        }
        public void updatemap()
        {
            Button BT = new Button();
            if (RTSmap.arrMap[0, 2] == "M1")
            {
                BT.Text = "M1";
                BT.Width = 40;
                BT.Height = 40;
                BT.Click += new EventHandler(this.buttonM1_Click);
                Mapgrid.Controls.Add(BT);
            }
        }
        public void createMap()
        {
            Mapgrid.Controls.Clear();
            RTSmap.createU();



            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Button BT = new Button();
                    if (RTSmap.arrMap[i, j] == "E")
                    {
                        BT.Text = "o";
                        BT.Width = 40;
                        BT.Height = 40;
                        BT.Click += new EventHandler(this.button_Click);
                        Mapgrid.Controls.Add(BT);
                    }
                    if (RTSmap.arrMap[i, j] == "FB1")
                    {
                        BT.Text = "FB1";
                        BT.Width = 40;
                        BT.Height = 40;
                        BT.Click += new EventHandler(this.buttonFB1_Click);
                        Mapgrid.Controls.Add(BT);
                    }
                    if (RTSmap.arrMap[i, j] == "FB2")
                    {
                        BT.Text = "FB2";
                        BT.Width = 40;
                        BT.Height = 40;
                        BT.Click += new EventHandler(this.buttonFB2_Click);
                        Mapgrid.Controls.Add(BT);
                    }
                    if (RTSmap.arrMap[i, j] == "RB1")
                    {
                        BT.Text = "RB1";
                        BT.Width = 40;
                        BT.Height = 40;
                        BT.Click += new EventHandler(this.buttonRB1_Click);
                        Mapgrid.Controls.Add(BT);
                    }
                    if (RTSmap.arrMap[i, j] == "RB2")
                    {
                        BT.Text = "RB2";
                        BT.Width = 40;
                        BT.Height = 40;
                        BT.Click += new EventHandler(this.buttonRB2_Click);
                        Mapgrid.Controls.Add(BT);
                    }
                    if (RTSmap.arrMap[i, j] == "M1")
                    {
                        BT.Text = "M1";
                        BT.Width = 40;
                        BT.Height = 40;
                        BT.Click += new EventHandler(this.buttonM1_Click);
                        Mapgrid.Controls.Add(BT);
                    }
                    if (RTSmap.arrMap[i, j] == "M2")
                    {
                        BT.Text = "M2";
                        BT.Width = 40;
                        BT.Height = 40;
                        BT.Click += new EventHandler(this.buttonM2_Click);
                        Mapgrid.Controls.Add(BT);
                    }
                    if (RTSmap.arrMap[i, j] == "R1")
                    {
                        BT.Text = "R1";
                        BT.Width = 40;
                        BT.Height = 40;
                        BT.Click += new EventHandler(this.buttonR1_Click);
                        Mapgrid.Controls.Add(BT);
                    }
                    if (RTSmap.arrMap[i, j] == "R2")
                    {
                        BT.Text = "R2";
                        BT.Width = 40;
                        BT.Height = 40;
                        BT.Click += new EventHandler(this.buttonR2_Click);
                        Mapgrid.Controls.Add(BT);
                    }
                }
            }
        }
        public void loadfile()
        {
            string Filename = @"D:\Map array.txt";

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(Filename, FileMode.Open, FileAccess.Write);
            formatter.Serialize(stream, RTSmap.arrMap);
            stream.Close();
            createMap();
        }
        public void savefile()
        {
            string Filename = @"D:\Map array.txt";

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(Filename, FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, RTSmap.arrMap);
            stream.Close();
            //StreamWriter streamWriter = new StreamWriter(@"D:\Doc.txt");
            //string output = "";
            //for (int i = 0; i < RTSmap.arrMap.GetUpperBound(0); i++)
            //{
            //    for (int j = 0; j < RTSmap.arrMap.GetUpperBound(1); j++)
            //    {
            //        output += RTSmap.arrMap[i, j].ToString();
            //    }
            //    streamWriter.WriteLine(output);
            //    output = "";
            //}
            //streamWriter.Close();
        }

        
        private void t_Tick(object sender, EventArgs e)
        {
            timerL.Text = "";

            T++;
            RBuilding.GenerateR();
            FBuilding.SpawnNewUnit();
            if (T == 5)
            {
                updatemap();
            }

            //RBuilding.ResRemaining = T * RBuilding.ResTick;
            timerL.Text += T.ToString();
            ResourceL.Text = RBuilding.ResType + ": " + RBuilding.ResRemainingT1;
            ResourceL2.Text = RBuilding.ResType + ": " + RBuilding.ResRemainingT2;
        }
        private void button_Click(object sender, EventArgs e)
        {
            unitStats.Text = "empty";
        }
        private void buttonFB1_Click(object sender, EventArgs e)
        {
            unitStats.Text = "Factory Building" + Environment.NewLine + "Team1";
        }
        private void buttonFB2_Click(object sender, EventArgs e)
        {
            unitStats.Text = "Factory Building" + Environment.NewLine + "Team2";
        }
        private void buttonRB1_Click(object sender, EventArgs e)
        {
            unitStats.Text = "Resource Building" + Environment.NewLine + "Team1";
        }
        private void buttonRB2_Click(object sender, EventArgs e)
           
        {
            unitStats.Text = "Resource Building" + Environment.NewLine + "Team2";
        }
        private void buttonM1_Click(object sender, EventArgs e)
        {
            unitStats.Text = "MeleeUnit" + Environment.NewLine + "Team1";
        }
        private void buttonM2_Click(object sender, EventArgs e)
        {
            unitStats.Text = "MeleeUnit" + Environment.NewLine + "Team2";
        }
        private void buttonR1_Click(object sender, EventArgs e)
        {
            unitStats.Text = "RangedUnit" + Environment.NewLine + "Team1";
        }
        private void buttonR2_Click(object sender, EventArgs e)
        {
            unitStats.Text = "RangedUnit" + Environment.NewLine + "Team2";
        }
        private void timer_TextChanged(object sender, EventArgs e)
        {

        }

        private void Start_Click(object sender, EventArgs e)
        {
            //createMap();
            

            t.Start();
           
        }

        private void Stop_Click(object sender, EventArgs e)
        {

            t.Stop();

        }

        //private void Reset_Click(object sender, EventArgs e)
        //{
        //    createMap();
        //    T = 0;
        //    timerL.Text = "0";
        //}

        private void Mapgrid_Paint(object sender, PaintEventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            savefile();
        }

        private void load_Click(object sender, EventArgs e)
        {
            loadfile();
        }
    }

    public class Unit
    {
        protected string TypeUnit;
        private int xPostion;
        private int yPosition;
        private int health;
        private int speed;
        private int attack;
        private int attackRange;
        private int team;
        private string symbol;
        public string typeUnit
        {
            get { return TypeUnit; }
            set { TypeUnit = value; }
        }
        public int XPosition
        {
            get { return xPostion; }
            set { xPostion = value; }
        }
        public int YPosition
        {
            get { return yPosition; }
            set { yPosition = value; }
        }
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }
        public int AttackRange
        {
            get { return attackRange; }
            set { attackRange = value; }
        }
        public int Team
        {
            get { return team; }
            set { team = value; }
        }
        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        public Unit()
        {

        }
        public virtual void NewPosition()
        {

        }

        public virtual void Combet()
        {

        }

        public virtual void AttackRangeU()
        {

        }

        public virtual void Return()
        {

        }

        public virtual void Death()
        {

        }

        public virtual void Tostring()
        {

        }
    }

    public class MeleeUnit : Unit
    {
        int Runaway;
        double x, y, z;
        bool range = false;
        bool death = false;
        public override void NewPosition()
        {

        }

        public override void Combet()
        {

            Health = 20;
            Attack = 2;
            AttackRangeU();
            while (death == false)
            {
                NewPosition();
                if (range == true)
                {
                    Health = Health - Attack;
                }

            }
        }

        public override void AttackRangeU()
        {
            AttackRange = 1;

            z = Math.Sqrt(x * x + y * y);

            if (z == AttackRange)
            {
                range = true;
            }
        }

        public override void Return()
        {
            int Runaway = Health / 4;
            if (Health <= Runaway)
            {

            }
        }

        public override void Death()
        {
            if (Health <= 0)
            {
                death = true;
            }
        }


        public override void Tostring()
        {
            TypeUnit = "Knight";
        }
        

    }
    public class RangedUnit : Unit
    {

        /*public string[,] arrMapR = new string[20, 20];            just tried to build another array to assign unit top of the map array
        int m, n;
        public void createU()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    arrMapR[i, j] = "E";
                }
            }
            for (int i = 0; i < 20; i++)
            {
                Random Ran = new Random(Guid.NewGuid().GetHashCode());
                m = Ran.Next(0, 20);
                n = Ran.Next(0, 20);
                arrMapR[m, n] = "R";
            }
        }*/

        int Runaway;
        double x, y, z;
        bool range = false;
        bool death = false;
        public override void NewPosition()
        {

        }

        public override void Combet()
        {

            Health = 20;
            Attack = 1;
            AttackRangeU();
            while (death == false)
            {
                NewPosition();
                if (range == true)
                {
                    Health = Health - Attack;
                }
            }


        }

        public override void AttackRangeU()
        {
            AttackRange = 3;

            z = Math.Sqrt(x * x + y * y);

            if (z == AttackRange)
            {
                range = true;
            }

        }

        public override void Return()
        {



            int Runaway = Health / 4;
            if (Health <= Runaway)
            {

            }

        }

        public override void Death()
        {
            if (Health <= 0)
            {
                death = true;
            }
        }


        public override void Tostring()
        {
            TypeUnit = "Archer";
        }
    }

    public class Map
    {
        int m, n;
        public string[,] arrMap = new string[20, 20];

        public Map()
        {

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    arrMap[i, j] = "E"; // using for loops to assign the empty space as "E"
                }
            }
        }
        public void createU()
        {
            arrMap[0, 1] = "FB1";
            arrMap[19, 18] = "FB2";
            arrMap[0, 0] = "RB1";
            arrMap[19, 19] = "RB2";
            for (int i = 0; i < 20; i++)
            {
                Random Ran = new Random(Guid.NewGuid().GetHashCode());
                m = Ran.Next(0, 20);
                n = Ran.Next(0, 20);
                if ( arrMap[m, n] != "RB1" && arrMap[m, n] != "RB2" && arrMap[m, n] != "FB1" && arrMap[m, n] != "FB2")
                {
                    arrMap[m, n] = "M1";
                }
            }
            for (int i = 0; i < 20; i++)
            {
                Random Ran = new Random(Guid.NewGuid().GetHashCode());
                m = Ran.Next(0, 20);
                n = Ran.Next(0, 20);
                if (arrMap[m, n] != "M1" && arrMap[m, n] != "RB1" && arrMap[m, n] != "RB2" && arrMap[m, n] != "FB1" && arrMap[m, n] != "FB2")
                {
                    arrMap[m, n] = "M2";
                }
            }
            for (int i = 0; i < 20; i++)
            {
                Random Ran = new Random(Guid.NewGuid().GetHashCode());
                m = Ran.Next(0, 20);
                n = Ran.Next(0, 20);
                if (arrMap[m, n] != "M1" && arrMap[m, n] != "M2" && arrMap[m, n] != "RB1" && arrMap[m, n] != "RB2" && arrMap[m, n] != "FB1" && arrMap[m, n] != "FB2")
                {
                    arrMap[m, n] = "R1";
                }
            }
            for (int i = 0; i < 20; i++)
            {
                Random Ran = new Random(Guid.NewGuid().GetHashCode());
                m = Ran.Next(0, 20);
                n = Ran.Next(0, 20);
                if (arrMap[m, n] != "M" && arrMap[m, n] != "M2" && arrMap[m, n] != "R1" && arrMap[m, n] != "RB1" && arrMap[m, n] != "RB2" && arrMap[m, n] != "FB1" && arrMap[m, n] != "FB2")
                {
                    arrMap[m, n] = "R2";
                }
            }

        }
        public void moveU()
        {

        }

        public class GameEngine
        {


            public GameEngine()
            {


            }

        }
    }
    abstract class Building
    {
        protected int Xpositon;
        protected int Ypositon;
        protected int Health = 100;
        protected int Team;
        protected string Symbol;

        public Building()
        {

        }

        public abstract void Death();

        public abstract void toString();
    }
    class ResourceBuilding : Building
    {
        private string ResourceType = "Gold";
        private int ResourceTick = 3;
        private int ResourceRemainingT1 = 0;
        private int ResourceRemainingT2 = 0;

        public int ResTick
        {
            get { return ResourceTick; }
            set { ResourceTick = value; }
        }
        public string ResType
        {
            get { return ResourceType; }
            set { ResourceType = value; }
        }

        public int ResRemainingT1
        {
            get { return ResourceRemainingT1; }
            set { ResourceRemainingT1 = value; }
        }
        public int ResRemainingT2
        {
            get { return ResourceRemainingT2; }
            set { ResourceRemainingT2 = value; }
        }
        public override void Death()
        {

        }

        public override void toString()
        {
            
        }
        /*private void RType()
        {
            
        }
        private void RGameTick()
        {
            
        }
        private void RRemaining()
        {
            
        }*/
        public void GenerateR()
        {
            ResourceRemainingT1 += ResourceTick;
            ResourceRemainingT2 += ResourceTick;
        }

    }
    class FactoryBuilding : Building
    {
        private string UnitP1 = "M1";
        private string UnitP2 = "M2";
        private int GametickPT = 0;
        //private int[,] SpawnP = new int[20,20];
        RTSGame rtsGame;

        public FactoryBuilding(RTSGame rtsGame)
        {
            this.rtsGame = rtsGame;

            rtsGame.RTSmap.arrMap[0, 0] = "";
        }


        public void SpawnNewUnit()
        {
            GametickPT += 1;
            if (GametickPT % 1 == 0)
            {
                if(rtsGame.RTSmap.arrMap[0, 2]=="E")
                {
                    rtsGame.RTSmap.arrMap[0, 2] = UnitP1;
                }
                if(rtsGame.RTSmap.arrMap[19, 17] == "E")
                {
                    rtsGame.RTSmap.arrMap[19, 17] = UnitP2;
                }
            }
        }
        public override void Death()
        {
            
        }

        public override void toString()
        {
            
        }
    }
}

