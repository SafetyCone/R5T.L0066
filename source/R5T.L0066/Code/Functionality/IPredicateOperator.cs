using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.L0066
{
    [FunctionalityMarker]
    public partial interface IPredicateOperator : IFunctionalityMarker
    {
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
    }
}
