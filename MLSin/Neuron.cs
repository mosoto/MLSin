using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLSin
{
    public class Neuron
    {
        private double[] _synapseStrength;
        private double _bias;
        private bool[] _firingInputs;
        private int _untrainedCycles = 0;

        private const double _learningRate = 0.1;
        private const double _maxSynapseStrength = 1;
        private const double _connectionBar = 0.25;
        private const int _maxUntrainedCycles = 10;
        private const int numInputs = 8;
        Random random = new Random();

        public Neuron()
        {
            _synapseStrength = new double[numInputs];
            _firingInputs = new bool[numInputs];
            _bias = 0;
        }

        public double ProcessInput(double[] inputs)
        {
            if (inputs.Length != _synapseStrength.Length)
            {
                throw new ArgumentException("There were more inputs than synapse weights.", nameof(inputs));
            }

            double accum = 0;
            for (int index = 0; index < inputs.Length; index++)
            {
                _firingInputs[index] = inputs[index] > 0;

                if (inputs[index] > 0 && _synapseStrength[index] > _connectionBar)
                {
                    accum++;
                }
            }

            if (_untrainedCycles++ > _maxUntrainedCycles)
            {
                _bias -= _learningRate;
            }


            var output = accum - _bias;
            return  output > 0 ? output : 0;
        }

        public void Train()
        {
            _untrainedCycles = 0;

            var connectedSynapses = _synapseStrength.Where(s => s > _connectionBar).Count();

            if (_bias + _learningRate < connectedSynapses)
            {
                _bias += _learningRate;
            }

            for (int index = 0; index < _firingInputs.Length; index++)
            {
                var change = random.NextDouble() * _learningRate;
                
                if (!_firingInputs[index])
                {
                    change *= -1;
                }

                _synapseStrength[index] += change;

                if (_synapseStrength[index] > _maxSynapseStrength)
                {
                    _synapseStrength[index] = _maxSynapseStrength;
                }

                if (_synapseStrength[index] < 0)
                {
                    _synapseStrength[index] = 0;
                }
            }
        }
    }
}
