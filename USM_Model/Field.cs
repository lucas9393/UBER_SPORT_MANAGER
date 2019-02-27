using System.Collections.Generic;

namespace USM_Model
{
    public abstract class Field
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TerrainType Terrain { get; set; }
        public SportType Sport { get; set; }
        public decimal Price { get; set; }
        public int MaxPlayer { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }

    public enum TerrainType{Grass, Sinthetic, Clay, Tarmac, Concrete}
    public enum SportType {Tennis, Paddle, Soccer}
}