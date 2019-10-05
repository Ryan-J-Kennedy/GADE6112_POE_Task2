using System;

namespace GADE6112_POE
{
    //Ryan Kennedy
    //19013266

    [Serializable]

    class ResourceBuilding : Building
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

        private ResourceType resource;
        private int resourcesGenerated = 0;
        private int resourcesPerRound;
        private int resourcesRemaining = 1000;


        public ResourceBuilding(int x, int y, int hp, string sym, Faction faction, int resPerRound, ResourceType res)
            : base(x, y, hp, sym, faction)
        {
            resource = res;
            resourcesPerRound = resPerRound;
        }

        //Mines the resources adding them and then removing them from the resources left
        public void GenerateResource()
        {
            if(resourcesRemaining > 10)
            {
                resourcesGenerated += resourcesPerRound;
                resourcesRemaining -= resourcesPerRound;
            }
            else if(resourcesRemaining > 0)
            {
                resourcesGenerated += resourcesRemaining;
                resourcesRemaining = 0;
            }
            
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
            return "Mine: X: " + PosX + " Y: " + PosY 
                + "\nHP: " + Health
                + "\nFaction " + FactionType
                + "\nResource: " + resource + ": " + resourcesGenerated
                + "\n" + resource + " remaining: " + resourcesRemaining;
        }
    }
}
