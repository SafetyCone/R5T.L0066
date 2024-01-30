using System;

using R5T.T0141;


namespace R5T.L0066.Q000
{
    [ExperimentsMarker]
    public partial interface IExperiments : IExperimentsMarker
    {
        /// <summary>
        /// What does the <see cref="IStringOperator.Get_LastCharacter(string)"/> do with the <see cref="IStrings.Empty"/> string?
        /// <para>
        /// Result: System.IndexOutOfRangeException: 'Index was outside the bounds of the array.'
        /// </para>
        /// </summary>
        public void Get_LastCharacter_OfEmptyString()
        {
            /// Inputs.
            var @string = Instances.Strings.Empty;


            /// Run.
            var lastCharacter = Instances.StringOperator.Get_LastCharacter(@string);
        }
    }
}
