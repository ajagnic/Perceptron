using System;

namespace TestPercep
{
    class Perceptron
    {
        public float learningRate = 0.1f; //rate of change, also prevents output of 0
        Random num = new Random();
        public float[] Weights;

        public Perceptron(int conns)
        {
            Weights = new float[conns];
            for (int i = 0; i < Weights.Length; i++)
            {
                Weights[i] = (float)num.NextDouble(); //initialize weights with random values as starting point
            }
        }

        public int Guess(float[] inputs)
        {
            float sum = 0;
            for (int i = 0; i < Weights.Length; i++)
            {
                sum += inputs[i] * Weights[i]; //make a guess based on the current weights
            }

            int output = sign(sum); //convert sum to either 1 or -1
            return output;
        }

        public void Train(float[] inputs, int target)
        {
            int guess = Guess(inputs);
            int error = target - guess; //reference for increasing or decreasing weight values in order to reach target

            for (int i = 0; i < Weights.Length; i++)
            {
                Weights[i] += error * inputs[i] * learningRate; //calculate amount of error in e. input and multiply by LR
            }
        }

        public float[] GetWeights()
        {
            return Weights;
        }

        public int sign(float n) //Activation function or the FeedForward process
        {
            if (n >= 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
