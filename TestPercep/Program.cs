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
                Console.WriteLine("Generation: " + gen);
                Console.WriteLine("Guess: " + guess);
                if (guess == target)
                {
                    targetHit = true;
                    answer = "no";
                }
            }

            Console.WriteLine("Train again? If yes, with how many source elements? Perceptron knowledge will be copied into new agent and weights will be mutated marginally. Also, the target is now 1.");
            string newSource = Console.ReadLine();
            if (newSource == "no")
            {
                Console.ReadLine();
            }
            else
            {
                targetHit = false;
                int sourceInt = Convert.ToInt16(newSource);
                float[] sourceTwo = new float[sourceInt];
                for (int i = 0;i < sourceTwo.Length;i++)
                {
                    float newI = (float)random.NextDouble();
                    sourceTwo[i] = newI;
                    Console.WriteLine("New Source: " + sourceTwo[i]);
                }
                float[] copyWeight = new float[perceptron.Weights.Length];
                for (int i = 0; i < perceptron.Weights.Length; i++)
                {
                    copyWeight[i] = perceptron.Weights[i];
                    Console.WriteLine("Copied Weights: " + copyWeight[i]);
                }
                Perceptron newPerceptron = new Perceptron(copyWeight);
                target = 1; //change new target here. Make corresponding changes to Perceptron.sign
                gen = 0;
                while (targetHit == false)
                {
                    newPerceptron.Train(source, target);
                    if (targetHit == false)
                    {
                        gen += 1;
                    }
                    float[] newOutputWeights = newPerceptron.GetWeights();
                    for (int i = 0; i < newOutputWeights.Length; i++)
                    {
                        Console.WriteLine("Weight: " + newOutputWeights[i]);
                    }
                    int Xguess = newPerceptron.Guess(source);
                    Console.WriteLine("Generation: " + gen);
                    Console.WriteLine("Guess: " + Xguess);
                    if (Xguess == target)
                    {
                        targetHit = true;
                    }
                }
                Console.ReadLine();
            }
        }
    }
}