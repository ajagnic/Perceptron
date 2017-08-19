using System;
using System.Collections.Generic;
using System.Text;

namespace TestPercep
{
    class Perceptron
    {
        private float[] weights = new float[2];
        public float learningRate = 0.1f;

        public Perceptron()
        {
            for (int i = 0; i < weights.Length; i++)
            {
                Random num = new Random();
                weights[i] = (float)num.NextDouble();
            }
        }

        public int Guess(float[] inputs)
        {
            float sum = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                sum += inputs[i] * weights[i];
            }

            int output = sign(sum);
            return output;
        }

        public void Train(float[] inputs, int target)
        {
            int guess = Guess(inputs);
            int error = target - guess;

            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] += error * inputs[i] * learningRate;
            }
        }

        public float[] GetWeights()
        {
            return weights;
        }

        public int sign(float n)
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
