namespace USM_Model
{
    public class SoccerField : Field
    {

        public SoccerField(string name, TerrainType type, decimal price)
        {
            Name = name;
            Terrain = type;
            Sport = SportType.Soccer;
            Price = price;
        }
    }
}