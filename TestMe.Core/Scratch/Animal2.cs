using System;

namespace TestMe.Core.Scratch2
{
    public interface IAnimal
    {
        string Name { get; }
        string Noise { get; }
    }

    public interface IMakeAnimalNoise
    {
        string MakeNoise(IAnimal animal);
    }

    public class AnimalNoiseMaker : IMakeAnimalNoise
    {
        public virtual string MakeNoise(IAnimal animal)
        {
            return String.Format("The {0} says {1}", animal.Name, animal.Noise);
        }
    }

    public class Dog : IAnimal
    {
        public string Name 
        {
            get { return "Doggy"; }
        }

        public string Noise
        {
            get { return "Bark"; }
        }
    }

    public class Cat : IAnimal
    {
        public string Name
        {
            get { return "Cat"; }
        }

        public string Noise
        {
            get { return "Meow"; }
        }
    }
}
