namespace USM_Model
{
    public class PaddleField : Field
    {


        public PaddleField(string name, TerrainType type, decimal price)
        {
            Name = name;
            Terrain = type;
            Sport = SportType.Paddle;
            Price = price;
        }
    }
}