using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    class Neuron {
        //функции активации
        public class activation_functions {
            public delegate double activation_function_type(double x, double alpha = 0.5);
            public static double sigmoid(double x, double alpha = 0.5) { return 1 / (1 + Math.Exp(-2*alpha*x)); }
            public static double lin(double x, double alpha = 0.5) { return x; }
            public static double hyperbolic_tangens(double x, double alpha = 0.5) { return (Math.Exp(2 * x / alpha) - 1) / (Math.Exp(2 * x / alpha) + 1); }
        }
        public class Link {
            public Neuron neuron = null;
            public double weight = 0;
            public double weight_delta = 0;
            public Link(Neuron neuron = null, double weight = 0) {
                this.neuron = neuron;
                this.weight = weight;
            }
        }
        //константы
        private const double speed = 0.5, alpha = 0.5;
        //ссылки на родителей и веса на связях
        private List<Link> parents = new List<Link>();
        public List<Link> Parents { get { return parents; } }
        //функция активации
        private activation_functions.activation_function_type func = activation_functions.sigmoid;
        //нужно пересчитывать
        private bool need_recount = true;
        //значение на выходе
        private double output = 0;
        public double Output { get { return output; } }
        //смещщение значения
        private double value_shift = 0;
        //количество детей
        public uint children_count = 0;
        public bool inited = false;
        //количество вызовов BackPropagation
        public uint BackPropagation_call_count = 0;

        public Neuron(activation_functions.activation_function_type func = null, double speed = 0.5, double alpha = 0.5) {
            if (func != null) this.func = func;
        }
        public double[] get_weights() {
            double[] weights = new double[parents.Count];
            int i = 0;
            foreach (Link link in parents) {
                weights[i++] = link.weight;
            }
            return weights;
        }

        public void add_parent(Neuron neuron, double weight = 0) {
            if (neuron != null) {
                Link link = new Link(neuron, weight);
                link.neuron = neuron;
                parents.Add(link);
            }
        }

        //начальная инициализация
        public void start_init(Random rand = null) {
            if (inited) return;
            inited = true;
            if (rand == null) rand = new Random((int)System.DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
            //if (rand == null) rand = new Random(1);
            foreach (Link link in parents) {
                link.neuron.start_init(rand);
                link.weight = 0.1 + rand.NextDouble() * 0.1;
            }
        }
        //поднять флаг need_recount (чтоб в следующий раз пересчитать все)
        public void set_need_recount() {
            if (need_recount) return;
            need_recount = true;
            foreach (Link link in parents) {
                link.neuron.set_need_recount();
            }
        }
        //посчитать
        public double count() {
            if (!need_recount) return output;
            need_recount = false;
            double input = 0;
            foreach (Link link in parents) {
                input += link.neuron.count() * link.weight;
            }

            output = func(input);
            return output;
        }
        //передать ошибку назад
        //формулы взято с https://goo.gl/kr9MZq
        public void BackPropagation(double err) {
            if (parents.Count == 0) return;
            if (BackPropagation_call_count > children_count || (children_count > 0 && BackPropagation_call_count == children_count)) {
                BackPropagation_call_count = 0;
                value_shift = 0;
                return;
            }
            value_shift += err;
            ++BackPropagation_call_count;
            if (BackPropagation_call_count == children_count || children_count == 0) {
                BackPropagation_call_count = 0;
                value_shift *= 2*alpha*output*(1 - output);
                foreach (Link link in parents) {
                    link.neuron.BackPropagation(value_shift * link.weight);
                    link.weight_delta = speed * value_shift * link.neuron.output;
                    //link.weight_delta = alpha * link.weight_delta + (1 - alpha) * speed * value_shift * link.neuron.output;
                    link.weight += link.weight_delta;
                }
                value_shift = 0;
            }
        }
    }
}
