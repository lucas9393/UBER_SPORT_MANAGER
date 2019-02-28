using System;
using System.Collections.Generic;
using Xunit;
using USM_Model;
using System.Linq;
using Moq;

namespace USM_Model_Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test_Field_Constructors()
        {

            Field campo1 = new TennisField(name: "pippo", terrainType: TerrainType.Grass, price: 70.00m);
            Field campo2 = new PaddleField(name: "pippo", terrainType: TerrainType.Grass, price: 70.00m);
            Field campo3 = new SoccerField(name: "pippo", terrainType: TerrainType.Grass, price: 70.00m, isSeven: true);

            Assert.IsType<TennisField>(campo1);
            Assert.IsType<PaddleField>(campo2);
            Assert.IsType<SoccerField>(campo3);
        }

        [Fact]
        public void Test_User_Constructors()
        {

            Member user1 = new Member(name: "Luca", surname: "Vaccaro", dor: DateTime.Now);

            Assert.IsType<Member>(user1);

        }

        [Fact]
        public void Test_Challenge_Creation()
        {
            Member user1 = new Member(name: "Luca", surname: "Vaccaro", dor: DateTime.Now);

            Challenge challenge1 = new Challenge(challenger: user1, availableMembers: 13);

            Assert.IsType<Challenge>(challenge1);
            int count = challenge1.ATeam.Count();
            Assert.Equal(1, count);
            Assert.Equal(user1, challenge1.ATeam[0]);
        }

        [Fact]
        public void Test_Challenge_Add_Player()
        {
            Member user1 = new Member(name: "Luca", surname: "Vaccaro", dor: DateTime.Now);
            Member user2 = new Member(name: "Gianluca", surname: "Marino", dor: DateTime.Now);

            Challenge challenge1 = new Challenge(challenger: user1, availableMembers: 13);

            challenge1.AddPlayer(user2);

            int count = challenge1.BTeam.Count();
            Assert.Equal(1, count);
            Assert.Equal(user2, challenge1.BTeam[0]);
            Assert.Equal(12, challenge1.AvailableMembers);
        }

        [Fact]
        public void Test_Reservation_Constructor()
        {
            Member user1 = new Member(name: "Luca", surname: "Vaccaro", dor: DateTime.Now);
            Field campo1 = new TennisField(name: "pippo", terrainType: TerrainType.Grass, price: 70.00m);

            Reservation reservation1 = new Reservation(field: campo1, member: user1, date: DateTime.Now, isDouble: false);

            Assert.IsType<Reservation>(reservation1);
        }

        [Fact]
        public void Test_Reservation_Get_Price()
        {
            Member user1 = new Member(name: "Luca", surname: "Vaccaro", dor: DateTime.Now);
            Field campo1 = new TennisField(name: "pippo", terrainType: TerrainType.Grass, price: 70.00m);

            Reservation reservation1 = new Reservation(field: campo1, member: user1, date: DateTime.Now, isDouble: false);

            Assert.Equal(reservation1.Price(), campo1.Price);

            reservation1.IsDouble = true;

            Assert.Equal(reservation1.Price(), campo1.Price * 1.25m);
        }

        [Fact]
        public void Test_Get_Max_Player()
        {
            Member user1 = new Member(name: "Luca", surname: "Vaccaro", dor: DateTime.Now);
            Field campo3 = new SoccerField(name: "pippo", terrainType: TerrainType.Grass, price: 70.00m, isSeven: true);
            Field campo1 = new TennisField(name: "pippo", terrainType: TerrainType.Grass, price: 70.00m);
            Reservation reservation1 = new Reservation(field: campo1, member: user1, date: DateTime.Now, isDouble: false);
            Reservation reservation2 = new Reservation(field: campo3, member: user1, date: DateTime.Now, isDouble: false);


            var maxPlayer1 = reservation1.MaxPlayer();
            var maxPlayer2 = reservation2.MaxPlayer();


            Assert.Equal(2, maxPlayer1);
            Assert.Equal(14, maxPlayer2);
        }

        [Fact]
        public void Test_Get_All_Member()
        {
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(m => m.Members).Returns(new Member[] {
                new Member(name: "Luca", surname: "Vaccaro", dor: DateTime.Now),
                new Member(name: "Gianluca", surname: "Marino", dor: DateTime.Now)
            });

            IUnitOfWork unitOfWork = mockUnitOfWork.Object;

            IEnumerable<Member> pippo = unitOfWork.Members;

            Assert.Equal(2, pippo.Count());
        }
    }
}
