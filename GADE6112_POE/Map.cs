using System;
using System.Collections.Generic;

namespace GADE6112_POE
{
    //Ryan Kennedy
    //19013266

    [Serializable]

    class Map
    {
        public string[,] map = new string[20, 20];

        Random rd = new Random();

        public List<Building> buildings = new List<Building>();
        public List<FactoryBuilding> factories = new List<FactoryBuilding>();
        public List<ResourceBuilding> mines = new List<ResourceBuilding>();

        public List<Unit> units = new List<Unit>();
        public List<RangedUnit> rangedUnits = new List<RangedUnit>();
        public List<MeleeUnit> meleeUnits = new List<MeleeUnit>();

        public Unit[,] unitMap = new Unit[20, 20];
        public Building[,] buildingMap = new Building[20, 20];


        int unitNum;
        int buildingNum;
        public int round = 1;


        //Constructor called with the number of units as a parameter
        public Map(int unitN, int buildingN)
        {
            unitNum = unitN;
            buildingNum = buildingN;
        }

        //Creates the unit objects and randomises thier x and y positions
        public void GenerateBattlefeild()
        {
            //Buildings spawning
            for (int i = 0; i < buildingNum; i++)
            {
                int unitTypeN = rd.Next(0, 2);
                string unitName;

                if (unitTypeN == 0)
                {
                    unitName = "Ranged";
                }
                else
                {
                    unitName = "Melee";
                }

                FactoryBuilding factory = new FactoryBuilding(0, 0, 100, "|^|", Faction.Dire, rd.Next(3, 10), unitName);
                factories.Add(factory);

                ResourceBuilding mine = new ResourceBuilding(0, 0, 100, "|V|", Faction.Dire, rd.Next(3, 10), ResourceType.Gold);
                mines.Add(mine);
            }

            for (int i = 0; i < buildingNum; i++)
            {
                int unitTypeN = rd.Next(0, 2);
                string unitName;

                if (unitTypeN == 0)
                {
                    unitName = "Ranged";
                }
                else
                {
                    unitName = "Melee";
                }

                FactoryBuilding factory = new FactoryBuilding(0, 0, 100, "|^|", Faction.Radient, rd.Next(3, 10), unitName);
                factories.Add(factory);

                ResourceBuilding mine = new ResourceBuilding(0, 0, 100, "|V|", Faction.Radient, rd.Next(3, 10), ResourceType.Gold);
                mines.Add(mine);
            }

            foreach (FactoryBuilding u in factories)
            {
                for (int i = 0; i < factories.Count; i++)
                {
                    int xPos = rd.Next(0, 20);
                    int yPos = rd.Next(0, 20);

                    while (xPos == factories[i].PosX && yPos == factories[i].PosY && xPos == mines[i].PosX && yPos == mines[i].PosY)
                    {
                        xPos = rd.Next(0, 20);
                        yPos = rd.Next(0, 20);
                    }

                    u.PosX = xPos;
                    u.PosY = yPos;
                }

                buildingMap[u.PosY, u.PosX] = (Building)u;
                buildings.Add(u);

                u.SpawnPointY = u.PosY;

                if (u.PosX < 19)
                {
                    u.SpawnPointX = u.PosX + 1;
                }
                else
                {
                    u.SpawnPointX = u.PosX - 1;
                }
            }

            foreach (ResourceBuilding u in mines)
            {
                for (int i = 0; i < mines.Count; i++)
                {
                    int xPos = rd.Next(0, 20);
                    int yPos = rd.Next(0, 20);

                    while (xPos == mines[i].PosX && yPos == mines[i].PosY && xPos == factories[i].PosX && yPos == factories[i].PosY)
                    {
                        xPos = rd.Next(0, 20);
                        yPos = rd.Next(0, 20);
                    }

                    u.PosX = xPos;
                    u.PosY = yPos;
                }

                buildingMap[u.PosY, u.PosX] = (Building)u;
                buildings.Add(u);
            }

            PlaceUnits();
            PlaceBuildings();
        }

        public void SpawnUnit(string unitType, int x, int y, Faction fac)
        {
            if(unitType == "Melee")
            {
                MeleeUnit knight = new MeleeUnit("Knight", x, y, fac, 40, 1, 5, 1, "/", false);
                meleeUnits.Add(knight);
                units.Add(knight);
            }
            else if(unitType == "Ranged")
            {
                RangedUnit archer = new RangedUnit("Archer", x, y, fac, 30, 1, 3, 3, "{|", false);
                rangedUnits.Add(archer);
                units.Add(archer);
            }
        }

        //Places the units on a string representation of the 20x20 map
        public void PlaceUnits()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    map[i, j] = " ";
                }
            }

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    unitMap[i, j] = null;
                }
            }

            foreach (Unit u in units)
            {
                if(u is RangedUnit)
                {
                    RangedUnit r = (RangedUnit)u;
                    unitMap[r.PosY, r.PosX] = u;
                }
                else if(u is MeleeUnit)
                {
                    MeleeUnit m = (MeleeUnit)u;
                    unitMap[m.PosY, m.PosX] = u;
                }
            }

            foreach (RangedUnit u in rangedUnits)
            {
                map[u.PosY, u.PosX] = "R";
            }

            foreach (MeleeUnit u in meleeUnits)
            {
                map[u.PosY, u.PosX] = "M";
            }
        }

        public void PlaceBuildings()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    buildingMap[i, j] = null;
                }
            }

            foreach (Building b in buildings)
            {
                if(b is FactoryBuilding)
                {
                    FactoryBuilding build = (FactoryBuilding)b;
                    buildingMap[build.PosY, build.PosX] = b;
                }
                else if(b is ResourceBuilding)
                {
                    ResourceBuilding build = (ResourceBuilding)b;
                    buildingMap[build.PosY, build.PosX] = b;
                }   
            }

            foreach (FactoryBuilding b in factories)
            {
                map[b.PosY, b.PosX] = "FB";
            }

            foreach (ResourceBuilding b in mines)
            {
                map[b.PosY, b.PosX] = "RB";
            }
        }
    }
}

