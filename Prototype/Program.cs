using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype {
    class Program {
        static void Main(string[] args) {
            ColorManager colormanager = new ColorManager();

            // Initialize with standard colors

            colormanager["red"] = new Color(255, 0, 0);
            colormanager["green"] = new Color(0, 255, 0);
            colormanager["blue"] = new Color(0, 0, 255);

            // User adds personalized colors

            colormanager["angry"] = new Color(255, 54, 0);
            colormanager["peace"] = new Color(128, 211, 128);
            colormanager["flame"] = new Color(211, 34, 20);

            // User clones selected colors

            Color color1 = colormanager["red"].Clone() as Color;
            Color color2 = colormanager["peace"].Clone() as Color;
            Color color3 = colormanager["flame"].Clone() as Color;

            // Wait for user

            Console.ReadKey();
        }
    }

    abstract class ColorPrototype {
        public abstract ColorPrototype Clone();
    }

    class Color : ColorPrototype {
        private int _red;
        private int _green;
        private int _blue;

        public Color(int red, int green, int blue) {
            _red = red;
            _green = green;
            _blue = blue;
        }
        public override ColorPrototype Clone() {
            Console.WriteLine($"Cloning color RGB: {_red},{_green},{_blue}");
            return (ColorPrototype)this.MemberwiseClone();
        }
    }

    class ColorManager {
        private Dictionary<string, ColorPrototype> _colors = new Dictionary<string, ColorPrototype>();

     public ColorPrototype this[string key] {
            get { return _colors[key]; }
            set { _colors.Add(key, value); }
        }
    }
}
