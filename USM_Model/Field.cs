﻿namespace USM_Model
{
    public abstract class Field
    {
        public string Name { get; set; }
        public TerrainType Terrain { get; set; }
        public SportType Sport { get; set; }
        public decimal Price { get; set; }


    }

    public enum TerrainType{Grass, Sinthetic, Clay, Tarmac, Concrete}
    public enum SportType {Tennis, Paddle, Soccer }
}