using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IPredicateOperator : IFunctionalityMarker,
        F10Y.L0000.IPredicateOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0000.IPredicateOperator _F10Y_L0000 => F10Y.L0000.PredicateOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Short-circuiting.
        /// </remarks>
        public Func<T, bool> Or<T>(
            IEnumerable<Func<T, bool>> predicates)
        {
            bool Internal(T meal)
            {
                foreach (var predicate in predicates)
                {
                    var stool = predicate(meal);
                    if (stool)
                    {
                        return true;
                    }
                }

                // Else, if no predicates pass.
                return false;
            }

            return Internal;
        }

        public Func<T, bool> Or<T>(
            params Func<T, bool>[] predicates)
            => this.Or(predicates.AsEnumerable());

        public bool Where<T>(
            T input,
            IEnumerable<Func<T, bool>> predicates)
            => this.And(predicates)(input);

        public bool Where<T>(
            T input,
            params Func<T, bool>[] predicates)
            => this.And(predicates)(input);

        public Func<string, bool> Get_Predicate_ForEquals(string value)
        {
            bool Internal(string otherValue)
            {
                var output = otherValue == value;
                return output;
            }

            return Internal;
        }

        public Func<T, bool> Get_Where<T, TValue>(
            Func<T, TValue> valueSelector,
            Func<TValue, bool> valuePredicate)
            => obj =>
            {
                var value = valueSelector(obj);

                var output = valuePredicate(value);
                return output;
            };
    }
}
