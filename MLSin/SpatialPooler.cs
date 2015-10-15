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
        public int _maxActive;

        public SpatialPooler(int numNeurons, int numInputs, int maxActive)
        {
            _neurons = Enumerable.Range(0, numNeurons).Select(i => new Neuron(numInputs, 0.01, numInputs)).ToArray();
            _maxActive = maxActive;
        }

        public double[] ProcessInput(double[] input)
        {
            var activations = _neurons
                .Select((neuron, index) => new {Activation = neuron.ProcessInput(input), Index = index})
                .OrderBy(ni => ni.Activation)
                .Where(ai => ai.Activation > 0)
                .Take(_maxActive)
                .Select(ni => ni.Index);

            var output = new double[_neurons.Length];
            foreach (var index in activations)
            {
                output[index] = 1;
                _neurons[index].Train();
            }

            return output;
        }
    }
}
