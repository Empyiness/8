using System;

namespace Sets
{
    public class Pair : ICalculate, IComparable, ICloneable
    {
        public Pair()
        {
            Random random = new Random();
            FirstNumber = random.Next(0, 100);
            SecondNumber = random.Next(0, 100);
        }
        public Pair(int firstNumber, int secondNumber)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
        }
        public int FirstNumber { get; private set;}
        public int SecondNumber { get; private set;}
        public int CompareTo(Object obj)
        {
            Pair otherPair = (Pair)obj;
            if (FirstNumber + SecondNumber > otherPair.FirstNumber + otherPair.SecondNumber)
            {
                return 1;
            }
            if (FirstNumber + SecondNumber < otherPair.FirstNumber + otherPair.SecondNumber)
            {
                return -1;
            }
            return 0;
        }

        public object Clone()
        {
            return new Pair
            {
                FirstNumber = FirstNumber,
                SecondNumber = SecondNumber
            };
        }
        public override string ToString()
        {
            return FirstNumber + " " + SecondNumber;
        }
        public Pair Addition(Pair otherPair)
        {
            return new Pair
            {
                FirstNumber = FirstNumber + otherPair.FirstNumber,
                SecondNumber = SecondNumber + otherPair.SecondNumber
            };
        }
        public Pair Subtraction(Pair otherPair)
        {
            return new Pair
            {
                FirstNumber = FirstNumber - otherPair.FirstNumber,
                SecondNumber = SecondNumber - otherPair.SecondNumber
            };
        }
        public Pair Multiplication(Pair otherPair)
        {
            return new Pair
            {
                FirstNumber = FirstNumber * otherPair.FirstNumber,
                SecondNumber = SecondNumber * otherPair.SecondNumber
            };
        }
        public Pair Devision(Pair otherPair)
        {
            return new Pair
            {
                FirstNumber = FirstNumber / otherPair.FirstNumber,
                SecondNumber = SecondNumber / otherPair.SecondNumber
            };
        }
    }

    public interface ICalculate
    {
        Pair Addition(Pair otherPair);
        Pair Subtraction(Pair otherPair);
        Pair Multiplication(Pair otherPair);
        Pair Devision(Pair otherPair);
    }
}

