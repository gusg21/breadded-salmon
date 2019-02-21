using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Utilities
{
    public struct Circle : IEquatable<Circle>
    {
        public int X;
        public int Y;
        public int Radius { get; set; }
        public int Diameter;
        private static Circle emptyCircle = new Circle();
        public Circle(Point location, int radius) : this(location.X, location.Y, radius)
        {

        }
        public Circle(int x, int y, int radius)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
            this.Diameter = Radius * 2;
        }

        public bool Equals(Circle other)
        {
            throw new NotImplementedException();
        }

        public static Circle Empty
        {
            get { return emptyCircle; }
        }

        public int Left
        {
            get { return this.X; }
        }

        public int Right
        {
            get { return this.X + Diameter; }
        }

        public int Top
        {
            get { return this.Y; }
        }

        public int Bottom
        {
            get { return this.Y + Diameter; }
        }

        public bool IsEmpty
        {
            get
            {
                return ((this.Radius == 0) && (this.X == 0) && (this.Y == 0));
            }
        }

        public Point Location
        {
            get { return new Point(this.X, this.Y); }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }
        public Point Center
        {
            get
            {
                return new Point(this.X + (this.Radius), this.Y + (this.Radius));
            }
        }

        internal string DebugDisplayString
        {
            get
            {
                return string.Concat(
                    this.X, "  ",
                    this.Y, "  ",
                    this.Radius
                    );
            }
        }

        public static bool operator ==(Circle a, Circle b)
        {
            return ((a.X == b.X) && (a.Y == b.Y) && (a.Radius == b.Radius));
        }

        public static bool operator !=(Circle a, Circle b)
        {
            return !(a == b);
        }
    }
}
