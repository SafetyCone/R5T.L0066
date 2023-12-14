using System;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IRandomOperator : IFunctionalityMarker
    {
        public Random WithDefaultSeed()
        {
            var output = this.WithSeed(Instances.Seeds.Default);
            return output;
        }

        public Random WithDefaultSeed(int offset)
        {
            var output = this.WithSeed(Instances.Seeds.Default + offset);
            return output;
        }

        // Uses the hashcode of the seed phrase as the seed of the random.
        public Random WithSeed(string seedPhrase)
        {
            var hashcode = Instances.StringOperator.GetHashCode_Deterministic(seedPhrase);

            var output = this.WithSeed(hashcode);
            return output;
        }

        public Random WithSeed(int seed)
        {
            var output = new Random(seed);
            return output;
        }
    }
}
