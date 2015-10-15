using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLSin
{
    public class SpatialPooler
    {
        public Neuron[] _neurons;

        private const int numNeurons = 16;
        private const int maxActive = 2;

        public SpatialPooler()
        {
            _neurons = Enumerable.Range(0, numNeurons).Select(i => new Neuron()).ToArray();
        }

        public double[] ProcessInput(double[] input)
        {
            var activations = _neurons
                .Select((neuron, index) => new {Activation = neuron.ProcessInput(input), Index = index})
                .ToArray();
            var activationIndexes = activations
                .OrderBy(ni => ni.Activation)
                .Where(ai => ai.Activation > 0)
                .Take(maxActive)
                .Select(ni => ni.Index)
                .ToArray();

            var output = new double[_neurons.Length];
            foreach (var index in activationIndexes)
            {
                output[index] = 1;
                _neurons[index].Train();
            }

            return output;
        }
    }
}
