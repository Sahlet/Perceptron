using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron {
    class Perceptron {
        Neuron[][] layers;
        private class Inputer {
            public double value = 0;
            public double call(double x, double alpha = 0.5) {
                return value;
            }
        }
        private Inputer[] inputers;
        public class NeuronData {
            public double[] weights;
            public NeuronData(double[] weights) { this.weights = weights; }
        }
        public Perceptron(uint[] Neuron_layers_sizes) {
            if (Neuron_layers_sizes == null || Neuron_layers_sizes.Length < 2) throw new Exception("bad args");
            foreach (uint count in Neuron_layers_sizes) {
                if (count == 0) throw new Exception("bad args");
            }

            NeuronData[][] neurons_data = new NeuronData[Neuron_layers_sizes.Length][];
            for (int i = 0; i < Neuron_layers_sizes.Length; i++) {
                neurons_data[i] = new NeuronData[Neuron_layers_sizes[i]];
                if (i > 0) {
                    double[] weights = new double[Neuron_layers_sizes[i - 1]];
                    for (int j = 0; j < Neuron_layers_sizes[i]; j++) {
                        neurons_data[i][j] = new NeuronData(weights);
                    }
                }
            }

            construct(neurons_data);
        }

        public Perceptron(NeuronData[][] neurons) {
            if (neurons == null || neurons.Length < 2) throw new Exception("bad args");
            for (int i = 0; i < neurons.Length; i++) {
                NeuronData[] layer = neurons[i];
                if (layer == null || layer.Length == 0) throw new Exception("bad args");
                if (i > 0) {
                    NeuronData[] pred_layer = neurons[i - 1];
                    foreach (NeuronData data in layer) {
                        if (data == null || data.weights == null || data.weights.Length != pred_layer.Length) throw new Exception("bad args");
                    }
                }
            }

            construct(neurons);
        }
        private void construct(NeuronData[][] neurons) {
            layers = new Neuron[neurons.Length][];
            //the first layer
            inputers = new Inputer[neurons[0].Length];
            layers[0] = new Neuron[inputers.Length];
            for (int j = 0; j < inputers.Length; j++) {
                inputers[j] = new Inputer();
                Neuron neuron = new Neuron(new Neuron.activation_functions.activation_function_type(inputers[j].call));
                layers[0][j] = neuron;
                neuron.children_count = Convert.ToUInt32(neurons[1].Length);
            }
            //rest of layers
            uint children_count = 0;
            for (int i = 1; i < neurons.Length; i++) {
                layers[i] = new Neuron[neurons[i].Length];
                if (i + 1 < neurons.Length) children_count = Convert.ToUInt32(neurons[i + 1].Length);
                else children_count = 0;
                for (int j = 0; j < neurons[i].Length; j++) {
                    Neuron neuron = new Neuron();
                    layers[i][j] = neuron;
                    neuron.children_count = children_count;
                    for (int k = 0; k < neurons[i - 1].Length; k++) {
                        neuron.add_parent(layers[i - 1][k], neurons[i][j].weights[k]);
                    }
                }
            }

            reinit();
        }
        private uint epoch;
        //количество эпох обучения
        public uint Epoch { get { return epoch; } }
        public void reinit() {
            epoch = 0;

            for (int i = layers.Length - 1; i >= 0 ; i--) {
                for (int j = 0; j < layers[i].Length; j++) {
                    layers[i][j].inited = false;
                }
            }
        	var rand = new Random((int)System.DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
        	for (int i = 0; i < layers[layers.Length - 1].Length; i++) {
                layers[layers.Length - 1][i].start_init(rand);
            }
        }

        public double[] get_output() {
            double[] res = new double[layers[layers.Length - 1].Length];
            for (int i = 0; i < res.Length; i++) {
                layers[layers.Length - 1][i].set_need_recount();
            }
            for (int i = 0; i < res.Length; i++) {
                res[i] = layers[layers.Length - 1][i].count();
            }
            return res;
        }
        public void set_input(double[] input) {
            if (input == null || input.Length != layers[0].Length) throw new Exception("bad args");
            for (int i = 0; i < inputers.Length; i++) {
                inputers[i].value = input[i];
            }
        }
        public class Patern {
            public double[] inputs;
            public double[] outputs;
        };
        public void study(Patern[] paterns, double eps = 0.005, uint max_epoch = uint.MaxValue) {
            if (paterns == null || paterns.Length == 0 || max_epoch == 0) throw new Exception("bad args");
            Neuron[] outers = layers[layers.Length - 1];
            Neuron[] synapses = layers[0];
            foreach (Patern patern in paterns) {
                if (
                    patern.inputs == null ||
                    patern.outputs == null ||
                    patern.inputs.Length != synapses.Length ||
                    patern.outputs.Length != outers.Length
                   )
                {
                    throw new Exception("bad args");
                }
            }

            epoch = 0;
            eps = Math.Abs(eps);
            double global_ERROR = 0;
            do {
                epoch++;
                global_ERROR = 0;
                foreach (Patern patern in paterns) {
                    set_input(patern.inputs);
                    double[] outs = get_output();
                    for (int i = 0; i < outs.Length; i++) {
                        double err = (patern.outputs[i] - outs[i]);
                        outers[i].BackPropagation(err);
                        global_ERROR += err * err;
                    }
                }
            } while (global_ERROR >= eps && epoch < max_epoch);
        }

        public override string ToString() {
            NeuronData[][] neurons = new NeuronData[layers.Length][];
            for (int i = 0; i < neurons.Length; i++) {
                neurons[i] = new NeuronData[layers[i].Length];
                for (int j = 0; j < neurons[i].Length; j++) {
                    neurons[i][j] = new NeuronData(layers[i][j].get_weights());
                }
            }

            return JsonConvert.SerializeObject(neurons);
        }
        static public Perceptron FromString(string str) {
            return new Perceptron(JsonConvert.DeserializeObject<NeuronData[][]>(str));
        }
    }
}
