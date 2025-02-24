﻿using System;
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
        private bool[] _firingInputs;
        private double _learningRate;
        private double _maxSynapseWeight;

        public Neuron(int numInputs, double learningRate, double maxSynapseWeight, int )
        {
            _synapseWeights = new double[numInputs];
            _firingInputs = new bool[numInputs];
            _learningRate = learningRate;
            _maxSynapseWeight = maxSynapseWeight;
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
                _firingInputs[index] = inputs[index] > 0;
                accum += _synapseWeights[index]*inputs[index];
            }

            var output = accum - _bias;
            return  output > 0 ? output : 0;
        }

        public void Train()
        {
            for (int index = 0; index < _firingInputs.Length; index++)
            {
                var change = (_maxSynapseWeight - _synapseWeights[index]) * _learningRate;
                
                if (!_firingInputs[index])
                {
                    change *= -1;
                }

                _synapseWeights[index] += change;
            }
        }
    }
}
