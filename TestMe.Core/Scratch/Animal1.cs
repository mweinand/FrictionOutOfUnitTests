using System;

namespace TestMe.Core.Scratch
{
    public abstract class Animal
    {
        protected virtual string Name 
        {
            get
            {
                return GetType().Name;
            }
        }

        protected abstract string Noise { get; }

        public virtual string MakeNoise()
        {
            return String.Format("The {0} says {1}", Name, Noise);
        }
    }

    public class Dog : Animal
    {
        protected override string Name
        {
            get { return "Doggy"; }
        }

        protected override string Noise
        {
            get { return "Bark"; }
        }
    }

    public class Cat : Animal
    {
        protected override string Noise
        {
            get { return "Meow"; }
        }

        public override string MakeNoise()
        {
            return "Cat says: Meow meow meow meow!";
        }
    }
}
