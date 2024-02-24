using System;
using System.Threading.Tasks;


namespace R5T.L0066.Contexts
{
    public static class ContextOperationExtensions
    {
        public static Func<TContextA, TContextB, Task> In_ContextSet_A_AB<TContextA, TContextB>(this Func<TContextA, Task> operation)
        {
            // Don't use this method, as it has too much internal structure.
            //return Instances.ContextOperations.In_ContextSet_AB_A<TContextA, TContextB>(operation);

            return (contextA, _B) => operation(contextA);
        }

        public static Func<TContextA, TContextB, Task> In<TContextA, TContextB>(this Func<TContextA, Task> operation,
            Tuple<TContextA, TContextB> _)
        {
            // Don't use this method, as it has too much internal structure.
            //return Instances.ContextOperations.In_ContextSet_AB_A<TContextA, TContextB>(operation);

            return (contextA, _B) => operation(contextA);
        }

        public static Func<TContextA, TContextB, Task> In<TContextA, TContextB>(this Func<TContextB, Task> operation,
            Tuple<TContextA, TContextB> _)
        {
            // Don't use this method, as it has too much internal structure.
            //return Instances.ContextOperations.In_ContextSet_AB_A<TContextA, TContextB>(operation);

            return (_A, contextB) => operation(contextB);
        }

        public static Func<TContextA, TContextB, Task> In_ContextSet_A_AB<TContextA, TContextB>(this Func<TContextA, Task> operation,
            Tuple<TContextA, TContextB> _)
        {
            // Don't use this method, as it has too much internal structure.
            //return Instances.ContextOperations.In_ContextSet_AB_A<TContextA, TContextB>(operation);

            return (contextA, _B) => operation(contextA);
        }

        public static Func<TContextA, TContextB, TContextC, Task> In_ContextSet_AB_ABC<TContextA, TContextB, TContextC>(this Func<TContextA, TContextB, Task> operation,
            Tuple<TContextA, TContextB, TContextC> _)
        {
            // Don't use this method, as it has too much internal structure.
            //return Instances.ContextOperations.In_ContextSet_AB_A<TContextA, TContextB>(operation);

            return (contextA, contextB, _C) => operation(contextA, contextB);
        }

        public static Func<TContextA, TContextB, TContextC, Task> In<TContextA, TContextB, TContextC>(this Func<TContextA, Task> operation,
            Tuple<TContextA, TContextB, TContextC> _)
        {
            // Don't use this method, as it has too much internal structure.
            //return Instances.ContextOperations.In_ContextSet_AB_A<TContextA, TContextB>(operation);

            return (contextA, _B, _C) => operation(contextA);
        }

        public static Func<TContextA, TContextB, TContextC, Task> In<TContextA, TContextB, TContextC>(this Func<TContextA, TContextB, Task> operation,
            Tuple<TContextA, TContextB, TContextC> _)
        {
            // Don't use this method, as it has too much internal structure.
            //return Instances.ContextOperations.In_ContextSet_AB_A<TContextA, TContextB>(operation);

            return (contextA, contextB, _C) => operation(contextA, contextB);
        }

        public static Func<TContextA, TContextB, TContextC, TContextD, Task> In_ContextSet_A_ABCD<TContextA, TContextB, TContextC, TContextD>(this Func<TContextA, Task> operation,
            Tuple<TContextA, TContextB, TContextC, TContextD> _)
        {
            // Don't use this method, as it has too much internal structure.
            //return Instances.ContextOperations.In_ContextSet_AB_A<TContextA, TContextB>(operation);

            return (contextA, _B, _C, _D) => operation(contextA);
        }

        public static Func<TContextA, TContextB, TContextC, TContextD, Task> In<TContextA, TContextB, TContextC, TContextD>(this Func<TContextA, Task> operation,
            Tuple<TContextA, TContextB, TContextC, TContextD> _)
        {
            // Don't use this method, as it has too much internal structure.
            //return Instances.ContextOperations.In_ContextSet_AB_A<TContextA, TContextB>(operation);

            return (contextA, _B, _C, _D) => operation(contextA);
        }

        public static Func<TContextA, TContextB, TContextC, TContextD, Task> In<TContextA, TContextB, TContextC, TContextD>(this Func<TContextA, TContextB, Task> operation,
            Tuple<TContextA, TContextB, TContextC, TContextD> _)
        {
            // Don't use this method, as it has too much internal structure.
            //return Instances.ContextOperations.In_ContextSet_AB_A<TContextA, TContextB>(operation);

            return (contextA, contextB, _C, _D) => operation(contextA, contextB);
        }

        public static Func<TContextA, TContextB, TContextC, TContextD, TContextE, Task> In<TContextA, TContextB, TContextC, TContextD, TContextE>(this Func<TContextA, Task> operation,
            Tuple<TContextA, TContextB, TContextC, TContextD, TContextE> _)
        {
            // Don't use this method, as it has too much internal structure.
            //return Instances.ContextOperations.In_ContextSet_AB_A<TContextA, TContextB>(operation);

            return (contextA, _B, _C, _D, _E) => operation(contextA);
        }

        public static Func<TContextA, TContextB, TContextC, TContextD, TContextE, Task> In<TContextA, TContextB, TContextC, TContextD, TContextE>(this Func<TContextA, TContextB, Task> operation,
            Tuple<TContextA, TContextB, TContextC, TContextD, TContextE> _)
        {
            // Don't use this method, as it has too much internal structure.
            //return Instances.ContextOperations.In_ContextSet_AB_A<TContextA, TContextB>(operation);

            return (contextA, contextB, _C, _D, _E) => operation(contextA, contextB);
        }

        public static Func<TContextA, TContextB, TContextC, TContextD, TContextE, Task> In<TContextA, TContextB, TContextC, TContextD, TContextE>(this Func<TContextA, TContextC, Task> operation,
            Tuple<TContextA, TContextB, TContextC, TContextD, TContextE> _)
        {
            // Don't use this method, as it has too much internal structure.
            //return Instances.ContextOperations.In_ContextSet_AB_A<TContextA, TContextB>(operation);

            return (contextA, _B, contextC, _D, _E) => operation(contextA, contextC);
        }
    }
}
