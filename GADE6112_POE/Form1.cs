using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GADE6112_POE
{
    //Ryan Kennedy
    //19013266

    public enum Faction
    {
        Dire,
        Radient
    }

    public enum ResourceType
    {
        Gold,
        Iron
    }

    public partial class Form1 : Form
    {
        Button[,] buttons = new Button[20,20]; 

        static int unitNum = 8;
        static int buildingNum = 8;

        Map m = new Map(unitNum, buildingNum);

        public Form1()
        {
            InitializeComponent();
        }

        //Runs when the form loads to set up the map
        private void Form1_Load(object sender, EventArgs e)
        {
            m.GenerateBattlefeild();
            Placebuttons();
        }

        //Places the buttons on the form and puts the units in the buttons 
        public void Placebuttons()
        {
            gbMap.Controls.Clear();

            Size btnSize = new Size(30, 30);

            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    Button btn = new Button();

                    btn.Size = btnSize;
                    btn.Location = new Point(x * 30, y * 30);

                    if (m.map[x, y] == "R")
                    {
                        if(m.unitMap[x,y] is MeleeUnit)
                        {
                            MeleeUnit M = (MeleeUnit)m.unitMap[x, y];
                            btn.Text = M.Symbol;
                            if (M.FactionType == Faction.Dire)
                            {
                                btn.BackColor = Color.Red;
                            }
                            else
                            {
                                btn.BackColor = Color.Green;
                            }
                        }
                        else if(m.unitMap[x,y] is RangedUnit)
                        {
                            RangedUnit R = (RangedUnit)m.unitMap[x, y];
                            btn.Text = R.Symbol;
                            if (R.FactionType == Faction.Dire)
                            {
                                btn.BackColor = Color.Red;
                            }
                            else
                            {
                                btn.BackColor = Color.Green;
                            }
                        }
                        
                        btn.Name = m.unitMap[x, y].ToString();
                        btn.Click += MyButtonClick;
                    }
                    else if (m.map[x, y] == "M")
                    {
                        if (m.unitMap[x, y] is MeleeUnit)
                        {
                            MeleeUnit M = (MeleeUnit)m.unitMap[x, y];
                            btn.Text = M.Symbol;
                            if (M.FactionType == Faction.Dire)
                            {
                                btn.BackColor = Color.Red;
                            }
                            else
                            {
                                btn.BackColor = Color.Green;
                            }
                        }
                        else if (m.unitMap[x, y] is RangedUnit)
                        {
                            RangedUnit R = (RangedUnit)m.unitMap[x, y];
                            btn.Text = R.Symbol;
                            if (R.FactionType == Faction.Dire)
                            {
                                btn.BackColor = Color.Red;
                            }
                            else
                            {
                                btn.BackColor = Color.Green;
                            }
                        }
                        btn.Name = m.unitMap[x, y].ToString();
                        btn.Click += MyButtonClick;
                    }
                    else if (m.map[x,y] == "FB")
                    {
                        if (m.buildingMap[x, y] is FactoryBuilding)
                        {
                            FactoryBuilding FB = (FactoryBuilding)m.buildingMap[x, y];
                            btn.Text = FB.Symbol;
                            if (FB.FactionType == Faction.Dire)
                            {
                                btn.BackColor = Color.Red;
                            }
                            else
                            {
                                btn.BackColor = Color.Green;
                            }
                        }
                        else if (m.buildingMap[x, y] is ResourceBuilding)
                        {
                            ResourceBuilding RB = (ResourceBuilding)m.buildingMap[x, y];
                            btn.Text = RB.Symbol;
                            if (RB.FactionType == Faction.Dire)
                            {
                                btn.BackColor = Color.Red;
                            }
                            else
                            {
                                btn.BackColor = Color.Green;
                            }
                        }

                        btn.Name = m.buildingMap[x, y].ToString();
                        btn.Click += MyButtonClick;
                    }
                    else if (m.map[x,y] == "RB")
                    {
                        if (m.buildingMap[x, y] is FactoryBuilding)
                        {
                            FactoryBuilding FB = (FactoryBuilding)m.buildingMap[x, y];
                            btn.Text = FB.Symbol;
                            if (FB.FactionType == Faction.Dire)
                            {
                                btn.BackColor = Color.Red;
                            }
                            else
                            {
                                btn.BackColor = Color.Green;
                            }
                        }
                        else if (m.buildingMap[x, y] is ResourceBuilding)
                        {
                            ResourceBuilding RB = (ResourceBuilding)m.buildingMap[x, y];
                            btn.Text = RB.Symbol;
                            if (RB.FactionType == Faction.Dire)
                            {
                                btn.BackColor = Color.Red;
                            }
                            else
                            {
                                btn.BackColor = Color.Green;
                            }
                        }

                        btn.Name = m.buildingMap[x, y].ToString();
                        btn.Click += MyButtonClick;
                    }
                    else
                    {
                        btn.Text = "";
                    }

                    buttons[x,y] = btn;
                }
            }

            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    gbMap.Controls.Add(buttons[x, y]);
                }
            }
        }

        //Starts the timer when the button is clicked
        private void btnStart_Click(object sender, EventArgs e)
        {
            GameTick.Enabled = true;
        }

        //Pauses the timer when the button is clicked
        private void btnPause_Click(object sender, EventArgs e)
        {
            GameTick.Enabled = false;
        }

        //Timer to run every second
        private void GameTick_Tick(object sender, EventArgs e)
        {
            GameLogic();
            

            lblRound.Text = "Round: " + m.round; 
        }

        //Runs all the logic behind the game
        public void GameLogic()
        {

            //Working out if both teams are alive
            int dire = 0;
            int radiant = 0;

            foreach (ResourceBuilding RB in m.mines)
            {
                if (RB.FactionType == Faction.Dire)
                {
                    dire++;
                }
                else
                {
                    radiant++;
                }
            }

            foreach (FactoryBuilding FB in m.factories)
            {
                if (FB.FactionType == Faction.Dire)
                {
                    dire++;
                }
                else
                {
                    radiant++;
                }
            }

            foreach (MeleeUnit u in m.meleeUnits)
            {
                if(u.FactionType == Faction.Dire)
                {
                    dire++;
                }
                else
                {
                    radiant++;
                }
            }

            foreach (RangedUnit u in m.rangedUnits)
            {
                if (u.FactionType == Faction.Dire)
                {
                    dire++;
                }
                else
                {
                    radiant++;
                }
            }

            if (dire > 0 && radiant > 0)//Checks to see if both teams are still alive
            {
                foreach (ResourceBuilding RB in m.mines)
                {
                    RB.GenerateResource();
                }

                foreach (FactoryBuilding FB in m.factories)
                {
                    if (m.round % FB.SpawnSpeed == 0)
                    {
                        m.SpawnUnit(FB.SpawnUnit(), FB.SpawnPointX, FB.SpawnPointY, FB.FactionType);
                    }
                }

                foreach (Unit u in m.units)
                {
                    u.CheckAttackRange(m.units, m.buildings);
                }

                m.round++;
                m.PlaceUnits();
                m.PlaceBuildings();
                Placebuttons();


            }
            else
            {
                m.PlaceUnits();
                m.PlaceBuildings();
                Placebuttons();
                GameTick.Enabled = false;

                if (dire > radiant)
                {
                    MessageBox.Show("Dire Wins in " + m.round + " rounds");
                }
                else
                {
                    MessageBox.Show("Radiant Wins in " + m.round + " rounds");
                }
            }

            //Checks to see who has died and needs to be deleted
            for (int i = 0; i < m.rangedUnits.Count; i++)
            {
                if (m.rangedUnits[i].Death())
                {
                    m.map[m.rangedUnits[i].PosX, m.rangedUnits[i].PosY] = "";
                    m.rangedUnits.RemoveAt(i);
                    
                }
            }

            for (int i = 0; i < m.meleeUnits.Count; i++)
            {
                if (m.meleeUnits[i].Death())
                {
                    m.map[m.meleeUnits[i].PosX, m.meleeUnits[i].PosY] = "";
                    m.meleeUnits.RemoveAt(i);

                }
            }

            for (int i = 0; i < m.units.Count; i++)
            {
                if (m.units[i].Death())
                {
                    if(m.units[i] is MeleeUnit)
                    {
                        MeleeUnit M = (MeleeUnit)m.units[i];
                        m.map[M.PosX, M.PosY] = "";
                    }
                    else if (m.units[i] is RangedUnit)
                    {
                        RangedUnit R = (RangedUnit)m.units[i];
                        m.map[R.PosX, R.PosY] = "";
                    }

                    
                    m.units.RemoveAt(i);
                }
            }

            for (int i = 0; i < m.factories.Count; i++)
            {
                if (m.factories[i].Death())
                {
                    m.map[m.factories[i].PosX, m.factories[i].PosY] = "";
                    m.factories.RemoveAt(i);

                }
            }

            for (int i = 0; i < m.mines.Count; i++)
            {
                if (m.mines[i].Death())
                {
                    m.map[m.mines[i].PosX, m.mines[i].PosY] = "";
                    m.mines.RemoveAt(i);

                }
            }

            for (int i = 0; i < m.buildings.Count; i++)
            {
                if (m.buildings[i].Death())
                {
                    if (m.buildings[i] is FactoryBuilding)
                    {
                        FactoryBuilding FB = (FactoryBuilding)m.buildings[i];
                        m.map[FB.PosX, FB.PosY] = "";
                    }
                    else if (m.buildings[i] is ResourceBuilding)
                    {
                        ResourceBuilding RB = (ResourceBuilding)m.buildings[i];
                        m.map[RB.PosX, RB.PosY] = "";
                    }

                    m.buildings.RemoveAt(i);
                }
            }


        }

        //The on click event of the buttons with the units
        public void MyButtonClick(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);

            foreach (Unit u in m.units)
            {
                if(btn.Name == u.ToString())
                {
                    txtOutput.Text = u.ToString();
                }
            }

            foreach (Building b in m.buildings)
            {
                if (btn.Name == b.ToString())
                {
                    txtOutput.Text = b.ToString();
                }
            }
        }

        //Saves the game state when the button is clicked
        private void btnSave_Click(object sender, EventArgs e)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("Save.dat", FileMode.Create, FileAccess.Write, FileShare.None);

            try
            {
                using (fs)
                {
                    bf.Serialize(fs, m);
                }

                MessageBox.Show("Save successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Loads the saved game state when the button is clicked
        private void btnRead_Click(object sender, EventArgs e)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("Save.dat", FileMode.Open, FileAccess.Read, FileShare.None);

            try
            {
                using (fs)
                {
                    Map mp = (Map)bf.Deserialize(fs);
                    m = mp;
                }

                Placebuttons();
                lblRound.Text = "Round: " + m.round;

                MessageBox.Show("Loading successful");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
