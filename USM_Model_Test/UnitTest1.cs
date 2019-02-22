using System;
using Xunit;
using USM_Model;
using System.Linq;

namespace USM_Model_Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test_Field_Constructors()
        {
            Field campo1 = new TennisField(name: "pippo", terrainType: TerrainType.Grass, price: 70.00m);
            Field campo2 = new PaddleField(name: "pippo", terrainType: TerrainType.Grass, price: 70.00m);
            Field campo3 = new SoccerField(name: "pippo", terrainType: TerrainType.Grass, price: 70.00m);

            Assert.IsType<TennisField>(campo1);
            Assert.IsType<PaddleField>(campo2);
            Assert.IsType<SoccerField>(campo3);
        }

        [Fact]
        public void Test_User_Constructors()
        {

            Member user1 = new Member(nome: "Luca", cognome: "Vaccaro");

            Assert.IsType<Member>(user1); 
        
        }

        [Fact]
        public void Test_Challenge_Creation()
        {
            Member user1 = new Member(nome: "Luca", cognome: "Vaccaro");

            Challenge challenge1 = new Challenge(challenger: user1, availableMembers: 13);

            Assert.IsType<Challenge>(challenge1);
            int count = challenge1.ATeam.Count();
            Assert.Equal(1, count);
            Assert.Equal(user1, challenge1.ATeam[0]);
        }

        [Fact]
        public void Test_Challenge_Add_Player()
        {
            Member user1 = new Member(nome: "Luca", cognome: "Vaccaro");
            Member user2 = new Member(nome: "Gianluca", cognome: "Marino");

            Challenge challenge1 = new Challenge(challenger: user1, availableMembers: 13);

            challenge1.AddPlayer(user2);
            
            int count = challenge1.BTeam.Count();
            Assert.Equal(1, count);
            Assert.Equal(user2, challenge1.BTeam[0]);
            Assert.Equal(12, challenge1.AvailableMembers);
        }
    }
}
