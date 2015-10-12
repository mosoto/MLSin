using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLSin
{
    public class Neuron
    {
        private double[] _synapseWeights;
        private double _bias;

        public Neuron()
        {
            
        }

        public double ProcessInput(double[] inputs)
        {
            if (inputs.Length != _synapseWeights.Length)
            {
                throw new ArgumentException("There were more inputs than synapse weights.", nameof(inputs));
            }

            double accum = 0;
            for (int index = 0; index < inputs.Length; index++)
            {
                accum += _synapseWeights[index]*inputs[index];
            }

            if (accum > _bias)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
