using System;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Organism organism = new Fish();
            organism.HowdoIMove();

            Organism organism1 = new Hawk();
            organism1.HowdoIMove();

            Organism organism2 = new Tiger();
            organism2.HowdoIMove();
        }
    }

    /* Strategy Pattern
     * ----------------
     * 
     * There are different Living Organisms : Fish, Hawk, Tiger, etc
     * There are differernt Transportation/Locomotion modes (Strategy/Behavior): Run, Fly, Swim, Crawl, etc 
     * 
     * Objective is to configure living organisms to locomotion modes
     * 
     * Organism o = new Fish()
     * o.Locomote() ----> should return Swim
     *  
     */

    // 1. Define th Behavioaral Strategy and its sub classes.
    public interface ILocomotionBehaviour
    {
        void Locomote();
    }

    public class RunBehaviour : ILocomotionBehaviour
    {
        public void Locomote()
        {
            Console.WriteLine("I am Running");
        }
    }

    public class FlyBehaviour : ILocomotionBehaviour
    {
        public void Locomote()
        {
            Console.WriteLine("I am Flying");
        }
    }

    public class SwimBehaviour : ILocomotionBehaviour
    {
        public void Locomote()
        {
            Console.WriteLine("I am Swimming");
        }
    }

    // 2. Configure the organism (Context) and its Sub classes. (Total Configurations = m < m x n, where as in abstract factory class = m x n)

    public abstract class Organism
    {
        public ILocomotionBehaviour locomotionBehaviour;

        public void HowdoIMove()
        {
            locomotionBehaviour.Locomote();
        }
    }

    public class Tiger : Organism
    {
        public Tiger()
        {
            locomotionBehaviour = new RunBehaviour();
        }
    }

    public class Fish : Organism
    {
        public Fish()
        {
            locomotionBehaviour = new SwimBehaviour();
        }
    }

    public class Hawk : Organism
    {
        public Hawk()
        {
            locomotionBehaviour = new FlyBehaviour();
        }
    }


}
