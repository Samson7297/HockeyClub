using System;

namespace HockeyClub.Model
{
    public class Stick
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Bend { get; set; }
        public int Flex { get; set; }
        public string Grip { get; set; }

        public Stick(int id, string brand, string model, int flex, int bend, string grip)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Flex = flex;
            Bend = bend;
            Grip = grip;
        }
    }
}
