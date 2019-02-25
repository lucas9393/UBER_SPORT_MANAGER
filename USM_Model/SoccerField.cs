namespace USM_Model
{
    public class SoccerField : Field
    {
        public bool IsSeven { get; set; }
        public SoccerField(string name, TerrainType terrainType, decimal price, bool isSeven)
        {
            Name = name;
            Terrain = terrainType;
            Sport = SportType.Soccer;
            Price = price;
            IsSeven = isSeven;
            MaxPlayer = IsSeven ? 14 : 10;
        }
    }
}