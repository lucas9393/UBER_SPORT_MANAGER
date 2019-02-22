namespace USM_Model
{
    public class SoccerField : Field
    {

        public SoccerField(string name, TerrainType terrainType, decimal price)
        {
            Name = name;
            Terrain = terrainType;
            Sport = SportType.Soccer;
            Price = price;
        }
    }
}