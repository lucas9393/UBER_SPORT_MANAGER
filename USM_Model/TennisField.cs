namespace USM_Model
{
    public class TennisField : Field
    {
  
        public TennisField(string name, TerrainType terrainType, decimal price)
        {
            Name = name;
            Terrain = terrainType;
            Sport = SportType.Tennis;
            Price = price;
            MaxPlayer = 2;
        }
    }
}