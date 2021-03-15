using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory {
    class Program {
        static void Main(string[] args) {
            ContinentFactory Afrika = new AfrikaFactory();
            AminalWorld world = new AminalWorld(Afrika);
            world.RunFoodChain();

            ContinentFactory Europe = new EuropeFactory();
            world = new AminalWorld(Europe);
            world.RunFoodChain();

            Console.Read();
        }

    }

    abstract class ContinentFactory {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }
    abstract class Herbivore {
    }

    abstract class Carnivore {
        public abstract void Eat(Herbivore herbivore);
    }

    class AfrikaFactory : ContinentFactory {
        public override Carnivore CreateCarnivore() {
            return new Lion();
        }

        public override Herbivore CreateHerbivore() {
            return new WildeBeest();
        }
    }

    class EuropeFactory : ContinentFactory {
        public override Carnivore CreateCarnivore() {
            return new Bear();
        }

        public override Herbivore CreateHerbivore() {
            return new Muisje();
        }
    }

    internal class Muisje : Herbivore {
    }

    internal class Bear : Carnivore {
        public override void Eat(Herbivore herbivore) {
            Console.WriteLine($"{this.GetType().Name} eats a juicy {herbivore.GetType().Name}");
        }
    }

    internal class WildeBeest : Herbivore {
    }

    internal class Lion : Carnivore {
        public override void Eat(Herbivore herbivore) {
            Console.WriteLine($"{this.GetType().Name} eats a juicy {herbivore.GetType().Name}");
        }
    }

    class AminalWorld {
        private Herbivore _herbivore;
        private Carnivore _carnivore;

        public AminalWorld(ContinentFactory factory) {
            _carnivore = factory.CreateCarnivore();
            _herbivore = factory.CreateHerbivore();
        }

        public void RunFoodChain() {
            _carnivore.Eat(_herbivore);
        }
    }
}
