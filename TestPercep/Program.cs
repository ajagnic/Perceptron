using System;

namespace TestPercep
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Number of connections: ");
            string aConn = Console.ReadLine();
            int nConn = Convert.ToInt16(aConn);

            Console.WriteLine("Size of Perceptron source code?");
            string aSource = Console.ReadLine();
            int nSource = Convert.ToInt16(aSource);


            float[] source = new float[nSource];
            Perceptron perceptron = new Perceptron(nConn);

            Console.WriteLine("Perceptron Learning Rate? ex. 0.1");
            string aLR = Console.ReadLine();
            float nLR = (float)Convert.ToDouble(aLR);
            perceptron.learningRate = nLR;

            int target = -1;
            int gen = 0;
            bool targetHit = false;
            Random random = new Random();


            for (int i = 0;i < source.Length;i++)
            {
                float input = (float)random.NextDouble();
                source[i] = input;
            }


            Console.WriteLine("Start Perceptron? (yes)(no)  Target = -1, when Target is reached weight values will not change.");
            float[] initialOutputWeights = perceptron.GetWeights();
            for (int i = 0; i < initialOutputWeights.Length; i++)
            {
                Console.WriteLine("Initial Weight: " + initialOutputWeights[i]);
            }


            string answer = Console.ReadLine();

            while (answer == "yes")
            {
                perceptron.Train(source, target);
                if (targetHit == false)
                {
                    gen += 1;
                }
                float[] outputWeights = perceptron.GetWeights();
                for (int i = 0;i < outputWeights.Length;i++)
                {
                    Console.WriteLine("Weight: " + outputWeights[i]);
                }
                int guess = perceptron.Guess(source);
                if (guess == target)
                {
                    targetHit = true;
                }
                Console.WriteLine("Generation: " + gen);
                Console.WriteLine("Guess: " + guess);
                if (targetHit)
                {
                    answer = "no";
                }
            }
            Console.ReadLine();
        }
    }
}