using System;
using Xunit;
using USM_Model;

namespace USM_Model_Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test_Field_GetPrice()
        {
            Field campo1 = new TennisField("pippo", TerrainType.Grass, 70.00m);
            Field campo2 = new PaddleField("pluto", TerrainType.Grass, 70.00m);
            Field campo3 = new SoccerField("topolino", TerrainType.Grass, 70.00m);
        }
    }
}
