using System;

namespace TestPercep
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Size of Perceptron source code?");
            string aSource = Console.ReadLine();
            int nSource = Convert.ToInt16(aSource);


            float[] source = new float[nSource];
            Perceptron perceptron = new Perceptron();

            Console.WriteLine("Perceptron Learning Rate? ex. 0.1");
            string aLR = Console.ReadLine();
            float nLR = (float)Convert.ToDouble(aLR);
            perceptron.learningRate = nLR;

            int target = -1;
            int gen = 0;
            bool targetHit = false;


            for (int i = 0;i < source.Length;i++)
            {
                Random random = new Random();
                float input = (float)random.NextDouble();
                source[i] = input;
            }


            Console.WriteLine("Start Perceptron? (yes)(no)  Target = -1, when Target is reached weight values will not change.");

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
                Console.WriteLine("Press Enter to train again, or reply no to stop.");
                string response = Console.ReadLine();
                if (response == "no")
                {
                    answer = response;
                }
            }
        }
    }
}