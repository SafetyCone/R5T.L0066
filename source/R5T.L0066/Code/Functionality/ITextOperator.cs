using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface ITextOperator : IFunctionalityMarker
    {
        public string Join_AsSeparatedList<T>(
            string separator,
            IEnumerable<T> values)
        {
            var strings = values
                .Select(x => x.ToString())
                ;

            var output = Instances.StringOperator.Join(
                separator,
                strings);

            return output;
        }

        public string Join_AsSeparatedList<T>(
            string separator,
            params T[] values)
        {
            var output = this.Join_AsSeparatedList(
                separator,
                values.AsEnumerable());

            return output;
        }

        /// <summary>
        /// Chooses <see cref="Join_AsList_CommaSpaceSeparated{T}(IEnumerable{T})"/> as the default.
        /// </summary>
        public string Join_AsList<T>(IEnumerable<T> values)
        {
            var output = this.Join_AsList_CommaSpaceSeparated(values);
            return output;
        }

        /// <inheritdoc cref="Join_AsList{T}(IEnumerable{T})"/>
        public string Join_AsList<T>(params T[] values)
        {
            var output = this.Join_AsList(values.AsEnumerable());
            return output;
        }

        public string Join_AsList_CommaSpaceSeparated<T>(IEnumerable<T> values)
        {
            var output = this.Join_AsSeparatedList(
                Instances.Strings.CommaSpaceSeparatedListSeparator,
                values);

            return output;
        }

        public string Join_AsList_CommaSpaceSeparated<T>(params T[] values)
        {
            var output = this.Join_AsList_CommaSpaceSeparated(values.AsEnumerable());
            return output;
        }
    }
}
