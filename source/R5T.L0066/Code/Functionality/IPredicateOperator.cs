using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IPredicateOperator : IFunctionalityMarker
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Short-circuiting.
        /// </remarks>
        public Func<T, bool> And<T>(
            IEnumerable<Func<T, bool>> predicates)
        {
            bool Internal(T meal)
            {
                foreach (var predicate in predicates)
                {
                    var stool = predicate(meal);
                    if(!stool)
                    {
                        return false;
                    }
                }

                // Else, if all predicates pass.
                return true;
            }

            return Internal;
        }

        public Func<T, bool> And<T>(
            params Func<T, bool>[] predicates)
            => this.And(predicates.AsEnumerable());

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

        /// <summary>
        /// Returns a typed predicates value instance (<see cref="IPredicates{T}"/>).
        /// </summary>
        public IPredicates<T> For<T>()
            => Predicates<T>.Instance;

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
