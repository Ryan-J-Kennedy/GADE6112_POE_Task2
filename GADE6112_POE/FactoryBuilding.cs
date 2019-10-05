using System;

namespace GADE6112_POE
{
    //Ryan Kennedy
    //19013266

    [Serializable]

    class FactoryBuilding : Building
    {
        public int PosX
        {
            get { return base.posX; }
            set { base.posX = value; }
        }

        public int PosY
        {
            get { return base.posY; }
            set { base.posY = value; }
        }

        public int Health
        {
            get { return base.health; }
            set { base.health = value; }
        }

        public string Symbol
        {
            get { return base.symbol; }
        }

        public Faction FactionType
        {
            get { return base.factionType; }
        }

        private int spawnSpeed;

        public int SpawnSpeed
        {
            get { return spawnSpeed; }
        }

        public string UnitType
        {
            get { return unitType; }
        }

        public int SpawnPointX
        {
            get { return spawnPointX; }
            set { spawnPointX = value; }
        }

        public int SpawnPointY
        {
            get { return spawnPointY; }
            set { spawnPointY = value; }
        }

        private string unitType;
        private int spawnPointX, spawnPointY;

        public FactoryBuilding(int x, int y, int hp, string sym, Faction faction, int sSpeed, string uType)
            : base(x, y, hp, sym, faction)
        {
            spawnSpeed = sSpeed;
            unitType = uType;
        }

        //Returns what unit needs to be spawned
        public string SpawnUnit()
        {
            return unitType;
        }

        //Returns if the building has more than 0 health of not
        public override bool Death()
        {
            if (Health <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //The info of the building
        public override string ToString()
        {
            return "Barracks: X: " + PosX + " Y: " + PosY
                + "\nHP: " + Health
                + "\nFaction " + FactionType
                + "\nSpawn speed: " + SpawnSpeed
                + "\nUnit spawning: " + unitType;
        }
    }
}
