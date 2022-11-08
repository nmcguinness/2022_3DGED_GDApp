using System;

namespace GD.Core.Types
{
    public class Integer2 : ICloneable
    {
        private int x, y;
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public Integer2(int x, int y)
        {
            this.x = x; this.y = y;
        }

        //TODO - operators(==,!=,<,<=), ToString, Equals, GetHashCode, Clone
        public new string ToString()
        {
            return $"[{x}, {y}]";
        }

        public object Clone()
        {
            //shallow - original and clone point to same object in RAM
            //deep - original and clone point to DIFFERENT objects in RAM
            //when we see 'new' realise that we are allocating new space in RAM
            return new Integer2(x, y);
        }

        public object GetShallowCopy()
        {
            //shallow returns a reference to the existing object
            return this;
        }
    }
}