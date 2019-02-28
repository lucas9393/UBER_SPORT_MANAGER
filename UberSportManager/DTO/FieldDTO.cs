using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USM_Model;

namespace UberSportManager.DTO
{
    public class FieldDTO
    {
        public string Name { get; set; }
        public TerrainType Terrain { get; set; }
        public SportType Sport { get; set; }
        public decimal Price { get; set; }
    }
}
