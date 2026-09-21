using System;

namespace Probabilities
{
    public class WeightedChances<T>
    {
        private System.Random random;

        public WeightedChances(int? Seed = null)
        {
            random = Seed == null ? new System.Random(Guid.NewGuid().GetHashCode()) : new System.Random(Seed.Value);
        }

        public T RandomizeWeight(params int[] weights)
        {
            throw new NotImplementedException();
        }

        public T RandomizeWeight(params Weights<T>[] weights)
        {
            InternalWeights<T>[] weightedList = CreateInternalWeights(out int cumulativeWeight, weights);

            int value = random.Next(cumulativeWeight-1);

            foreach(InternalWeights<T> w in weightedList)
            {
                if(value < w.CumulativeWeight)
                {
                    return w.IndividualWeight.Element;
                }
            }

            throw new Exception("Cannot find weight in sequel");
        }


#region TESTS
        public string TEST_RunSample()
        {
            WeightedChances<string> chances = new WeightedChances<string>();

            int totalTest = 1_000_000;
            System.Collections.Generic.Dictionary<string, Int32> countingDictControl = new();

            var weights = new Weights<string>[]
            {
                new("05%", 05),
                new("10%", 10),
                new("15%", 15),
                new("30%", 30),
                new("40%", 40),
            };

            foreach(Weights<string> coutingStarter in weights)
            {
                countingDictControl.Add(coutingStarter.Element, 0);
            }

            for(int i=0; i < totalTest; i++)
            {
                string element = chances.RandomizeWeight(weights);
                countingDictControl[element]++;
            }

            System.Text.StringBuilder stringBuilder = new();
            stringBuilder.AppendLine("Probability results:");
            foreach(System.Collections.Generic.KeyValuePair<string, int> countingPair in countingDictControl)
            {
                stringBuilder.Append($"{countingPair.Key} == {((countingPair.Value/(float)totalTest)*100):##.##}%     ");
            }

            return stringBuilder.ToString();
        }
#endregion

        private InternalWeights<internalT>[] CreateInternalWeights<internalT>(out int cumulativeWeight, params Weights<internalT>[] weights)
        {
            // TODO - possibly optimize with finer data structs https://github.com/sestoft/C5/?tab=readme-ov-file
            InternalWeights<internalT>[] calculatedWeights = new InternalWeights<internalT>[weights.Length];

            cumulativeWeight = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                Weights<internalT> weight = weights[i];
                cumulativeWeight += weight.Weight;

                calculatedWeights[i] = new InternalWeights<internalT>(weight, cumulativeWeight);
            }
            return calculatedWeights;
        }

        private struct InternalWeights<interntalT>
        {
            public Weights<interntalT> IndividualWeight;
            public int CumulativeWeight;

            public InternalWeights(Weights<interntalT> weight, int cumulativeWeight)
            {
                IndividualWeight = weight;
                this.CumulativeWeight = cumulativeWeight;
            }
        }
    }

    public struct Weights<T>
    {
        public T Element;
        public int Weight;

        public Weights(T element, int weight)
        {
            Element = element;
            Weight = weight;
        }
    }
}
