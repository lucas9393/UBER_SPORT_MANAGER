namespace USM_Model
{
    public class PaddleField : Field
    {
        public PaddleField() { }

        public PaddleField(string name, TerrainType terrainType, decimal price)
        {
            Name = name;
            Terrain = terrainType;
            Sport = SportType.Paddle;
            Price = price;
            MaxPlayer = 2;
        }
    }
}