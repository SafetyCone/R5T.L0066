using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Note: keep all the grayed-out <TContextA, TContextB, ...> type parameter lists of In_ContextSet<>() method calls, since they aid in spotting mis-specifications of context type parameters.
// (Such as not awaiting asynchronous constructors and thus feeding a Task<TContext> instead of a TContext to the call, which results in "missing" method runs.)


namespace R5T.L0066
{
    public partial interface IContextOperations
    {
        public Func<Task<TContextA>> Construct_Context<TContextA>(
            IEnumerable<Func<TContextA, Task>> operations)
            where TContextA : new()
        {
            return async () =>
            {
                var contextA = new TContextA();

                await Instances.ContextOperator.In_ContextSet<TContextA>(
                    contextA,
                    operations);

                return contextA;
            };
        }

        public Func<Task<TContextA>> Construct_Context<TContextA>(
            params Func<TContextA, Task>[] operations)
            where TContextA : new()
            => this.Construct_Context_A_A<TContextA>(
                operations.AsEnumerable());

        public Func<Task<TContextA>> Construct_Context_A_A<TContextA>(
            IEnumerable<Func<TContextA, Task>> operations)
            where TContextA : new()
        {
            return async () =>
            {
                var contextA = new TContextA();

                await Instances.ContextOperator.In_ContextSet<TContextA>(
                    contextA,
                    operations);

                return contextA;
            };
        }

        public Func<Task<TContextA>> Construct_Context_A_A<TContextA>(
            params Func<TContextA, Task>[] operations)
            where TContextA : new()
            => this.Construct_Context_A_A<TContextA>(
                operations.AsEnumerable());

        public Func<TContextA, Task<TContextB>> Construct_Context_B_AB<TContextA, TContextB>(
            IEnumerable<Func<TContextA, TContextB, Task>> operations)
            where TContextB : new()
        {
            return async contextA =>
            {
                var contextB = new TContextB();

                await Instances.ContextOperator.In_ContextSet<TContextA, TContextB>(
                    contextA,
                    contextB,
                    operations);

                return contextB;
            };
        }

        public Func<TContextA, Task<TContextB>> Construct_Context_B_AB<TContextA, TContextB>(
            params Func<TContextA, TContextB, Task>[] operations)
            where TContextB : new()
            => this.Construct_Context_B_AB<TContextA, TContextB>(
                operations.AsEnumerable());

        public Func<TContextA, Task<TContextB>> Construct_Context_B_BA<TContextB, TContextA>(
            IEnumerable<Func<TContextB, TContextA, Task>> operations)
            where TContextB : new()
        {
            return async contextA =>
            {
                var contextB = new TContextB();

                await Instances.ContextOperator.In_ContextSet<TContextB, TContextA>(
                    contextB,
                    contextA,
                    operations);

                return contextB;
            };
        }

        public Func<TContextA, Task<TContextB>> Construct_Context_B_BA<TContextB, TContextA>(
            params Func<TContextB, TContextA, Task>[] operations)
            where TContextB : new()
            => this.Construct_Context_B_BA<TContextB, TContextA>(
                operations.AsEnumerable());


        public Func<TContextA, TContextB, Task<TContextC>> Construct_Context_C_ABC<TContextA, TContextB, TContextC>(
            IEnumerable<Func<TContextA, TContextB, TContextC, Task>> operations)
            where TContextC : new()
        {
            return async (contextA, contextB) =>
            {
                var contextC = new TContextC();

                await Instances.ContextOperator.In_ContextSet<TContextA, TContextB, TContextC>(
                    contextA,
                    contextB,
                    contextC,
                    operations);

                return contextC;
            };
        }

        public Func<TContextA, TContextB, Task<TContextC>> Construct_Context_C_ABC<TContextA, TContextB, TContextC>(
            params Func<TContextA, TContextB, TContextC, Task>[] operations)
            where TContextC : new()
            => this.Construct_Context_C_ABC<TContextA, TContextB, TContextC>(
                operations.AsEnumerable());


        public Func<TContextA, TContextB, Task<TContextC>> Construct_Context_C_CAB<TContextC, TContextA, TContextB>(
            IEnumerable<Func<TContextC, TContextA, TContextB, Task>> operations)
            where TContextC : new()
        {
            return async (contextA, contextB) =>
            {
                var contextC = new TContextC();

                await Instances.ContextOperator.In_ContextSet<TContextC, TContextA, TContextB>(
                    contextC,
                    contextA,
                    contextB,
                    operations);

                return contextC;
            };
        }

        public Func<TContextA, TContextB, Task<TContextC>> Construct_Context_C_CAB<TContextC, TContextA, TContextB>(
            params Func<TContextC, TContextA, TContextB, Task>[] operations)
            where TContextC : new()
            => this.Construct_Context_C_CAB<TContextC, TContextA, TContextB>(
                operations.AsEnumerable());

        public Func<TContextA, TContextB, TContextC, Task<TContextD>> Construct_Context_D_DABC<TContextD, TContextA, TContextB, TContextC>(
            IEnumerable<Func<TContextD, TContextA, TContextB, TContextC, Task>> operations)
            where TContextD : new()
        {
            return async (contextA, contextB, contextC) =>
            {
                var contextD = new TContextD();

                await Instances.ContextOperator.In_ContextSet<TContextD, TContextA, TContextB, TContextC>(
                    contextD,
                    contextA,
                    contextB,
                    contextC,
                    operations);

                return contextD;
            };
        }

        public Func<TContextA, TContextB, TContextC, Task<TContextD>> Construct_Context_D_DABC<TContextD, TContextA, TContextB, TContextC>(
            params Func<TContextD, TContextA, TContextB, TContextC, Task>[] operations)
            where TContextD : new()
            => this.Construct_Context_D_DABC<TContextD, TContextA, TContextB, TContextC>(
                operations.AsEnumerable());


        public Func<TContextA, TContextB, TContextC, TContextD, Task<TContextE>> Construct_Context_E_EABCD<TContextE, TContextA, TContextB, TContextC, TContextD>(
            IEnumerable<Func<TContextE, TContextA, TContextB, TContextC, TContextD, Task>> operations)
            where TContextE : new()
        {
            return async (contextA, contextB, contextC, contextD) =>
            {
                var contextE = new TContextE();

                await Instances.ContextOperator.In_ContextSet<TContextE, TContextA, TContextB, TContextC, TContextD>(
                    contextE,
                    contextA,
                    contextB,
                    contextC,
                    contextD,
                    operations);

                return contextE;
            };
        }

        public Func<TContextA, TContextB, TContextC, TContextD, Task<TContextE>> Construct_Context_E_EABCD<TContextE, TContextA, TContextB, TContextC, TContextD>(
            params Func<TContextE, TContextA, TContextB, TContextC, TContextD, Task>[] operations)
            where TContextE : new()
            => this.Construct_Context_E_EABCD<TContextE, TContextA, TContextB, TContextC, TContextD>(
                operations.AsEnumerable());

        /// <summary>
        /// Applies the provided asynchronous operations to an instance of context set type,
        /// an instance constructed by the provided asynchronous constructor function.
        /// </summary>
        public Func<Task> In_ContextSet<TContextSet>(
            Func<Task<TContextSet>> contextSetConstructor,
            IEnumerable<Func<TContextSet, Task>> operations)
        {
            return () => Instances.ContextOperator.In_ContextSet(
                contextSetConstructor,
                operations);
        }

        public Func<Task> In_ContextSet<TContextSet>(
            Func<Task<TContextSet>> contextSetConstructor,
            params Func<TContextSet, Task>[] operations)
        {
            return this.In_ContextSet<TContextSet>(
                contextSetConstructor,
                operations.AsEnumerable());
        }

        public Func<TContextSet, Task> In_ContextSet<TContextSet>(
            IEnumerable<Func<TContextSet, Task>> operations)
        {
            return contextSet => Instances.ActionOperator.Run_Actions(
                contextSet,
                operations);
        }

        public Func<TContextSet, Task> In_ContextSet<TContextSet>(
            params Func<TContextSet, Task>[] operations)
            => this.In_ContextSet<TContextSet>(
                operations.AsEnumerable());

        public Func<TContextA, TContextB, Task> In_ContextSet<TContextA, TContextB>(
            IEnumerable<Func<TContextA, TContextB, Task>> operations)
        {
            return (contextA, contextB)
                => Instances.ContextOperator.In_ContextSet(
                    contextA,
                    contextB,
                    operations);
        }

        public Func<TContextA, TContextB, Task> In_ContextSet<TContextA, TContextB>(
            params Func<TContextA, TContextB, Task>[] operations)
        {
            return this.In_ContextSet<TContextA, TContextB>(
                operations.AsEnumerable());
        }

        public Func<TContextA, Task> In_ContextSet_A_AB<TContextA, TContextB>(
            Func<TContextA, Task<TContextB>> contextBConstructor,
            IEnumerable<Func<TContextA, TContextB, Task>> operations)
        {
            return async contextA =>
            {
                var contextB = await contextBConstructor(contextA);

                await Instances.ContextOperator.In_ContextSet(
                    contextA,
                    contextB,
                    operations);
            };
        }

        public Func<TContextA, Task> In_ContextSet_A_AB<TContextA, TContextB>(
            Func<TContextA, Task<TContextB>> contextBConstructor,
            params Func<TContextA, TContextB, Task>[] operations)
        {
            return this.In_ContextSet_A_AB<TContextA, TContextB>(
                contextBConstructor,
                operations.AsEnumerable());
        }

        public Func<TContextA, Task> In_ContextSet_A_BA<TContextB, TContextA>(
            Func<TContextA, Task<TContextB>> contextBConstructor,
            IEnumerable<Func<TContextB, TContextA, Task>> operations)
        {
            return async contextA =>
            {
                var contextB = await contextBConstructor(contextA);

                await Instances.ContextOperator.In_ContextSet(
                    contextB,
                    contextA,
                    operations);
            };
        }

        public Func<TContextA, Task> In_ContextSet_A_BA<TContextB, TContextA>(
            Func<TContextA, Task<TContextB>> contextBConstructor,
            params Func<TContextB, TContextA, Task>[] operations)
        {
            return this.In_ContextSet_A_BA<TContextB, TContextA>(
                contextBConstructor,
                operations.AsEnumerable());
        }

        public Func<TContextA, TContextB, Task> In_ContextSet_AB<TContextA, TContextB>(
            IEnumerable<Func<TContextA, TContextB, Task>> operations)
        {
            return (contextA, contextB) =>
            {
                return Instances.ContextOperator.In_ContextSet<TContextA, TContextB>(
                    contextA,
                    contextB,
                    operations);
            };
        }

        public Func<TContextA, TContextB, Task> In_ContextSet_AB<TContextA, TContextB>(
            params Func<TContextA, TContextB, Task>[] operations)
        {
            return this.In_ContextSet_AB<TContextA, TContextB>(
                operations.AsEnumerable());
        }

        public Func<TContextA, TContextB, Task> In_ContextSet_AB_A<TContextA, TContextB>(
            IEnumerable<Func<TContextA, Task>> operations)
        {
            return (contextA, _) =>
            {
                return Instances.ContextOperator.In_ContextSet<TContextA>(
                    contextA,
                    operations);
            };
        }

        public Func<TContextA, TContextB, Task> In_ContextSet_AB_A<TContextA, TContextB>(
            params Func<TContextA, Task>[] operations)
        {
            return this.In_ContextSet_AB_A<TContextA, TContextB>(
                operations.AsEnumerable());
        }

        public Func<TContextA, TContextB, Task> In_ContextSet_AB_B<TContextA, TContextB>(
            IEnumerable<Func<TContextB, Task>> operations)
        {
            return (_, contextB) =>
            {
                return Instances.ContextOperator.In_ContextSet<TContextB>(
                    contextB,
                    operations);
            };
        }

        public Func<TContextA, TContextB, Task> In_ContextSet_AB_B<TContextA, TContextB>(
            params Func<TContextB, Task>[] operations)
        {
            return this.In_ContextSet_AB_B<TContextA, TContextB>(
                operations.AsEnumerable());
        }

        public Func<TContextA, TContextB, Task> In_ContextSet_AB_BA<TContextA, TContextB>(
            IEnumerable<Func<TContextB, TContextA, Task>> operations)
        {
            return (contextA, contextB) =>
            {
                return Instances.ContextOperator.In_ContextSet<TContextB, TContextA>(
                    contextB,
                    contextA,
                    operations);
            };
        }

        public Func<TContextA, TContextB, Task> In_ContextSet_AB_BA<TContextA, TContextB>(
            params Func<TContextB, TContextA, Task>[] operations)
        {
            return this.In_ContextSet_AB_BA(
                operations.AsEnumerable());
        }


        public Func<TContextA, TContextB, Task> In_ContextSet_AB_ABC<TContextA, TContextB, TContextC>(
            Func<TContextA, TContextB, Task<TContextC>> contextCConstructor,
            IEnumerable<Func<TContextA, TContextB, TContextC, Task>> operations)
        {
            return async (contextA, contextB) =>
            {
                var contextC = await contextCConstructor(contextA, contextB);

                await Instances.ContextOperator.In_ContextSet<TContextA, TContextB, TContextC>(
                    contextA,
                    contextB,
                    contextC,
                    operations);
            };
        }

        public Func<TContextA, TContextB, Task> In_ContextSet_AB_ABC<TContextA, TContextB, TContextC>(
            Func<TContextA, TContextB, Task<TContextC>> contextCConstructor,
            params Func<TContextA, TContextB, TContextC, Task>[] operations)
        {
            return this.In_ContextSet_AB_ABC(
                contextCConstructor,
                operations.AsEnumerable());
        }


        public Func<TContextA, TContextB, Task> In_ContextSet_AB_CAB<TContextC, TContextA, TContextB>(
            Func<TContextA, TContextB, Task<TContextC>> contextCConstructor,
            IEnumerable<Func<TContextC, TContextA, TContextB, Task>> operations)
        {
            return async (contextA, contextB) =>
            {
                var contextC = await contextCConstructor(contextA, contextB);

                await Instances.ContextOperator.In_ContextSet<TContextC, TContextA, TContextB>(
                    contextC,
                    contextA,
                    contextB,
                    operations);
            };
        }

        public Func<TContextA, TContextB, Task> In_ContextSet_AB_CAB<TContextC, TContextA, TContextB>(
            Func<TContextA, TContextB, Task<TContextC>> contextCConstructor,
            params Func<TContextC, TContextA, TContextB, Task>[] operations)
        {
            return this.In_ContextSet_AB_CAB(
                contextCConstructor,
                operations.AsEnumerable());
        }

        public Func<TContextA, TContextB, TContextC, Task> In_ContextSet_ABC_A<TContextA, TContextB, TContextC>(
            IEnumerable<Func<TContextA, Task>> operations)
        {
            return (contextA, contextB, _) =>
            {
                return Instances.ContextOperator.In_ContextSet<TContextA>(
                    contextA,
                    operations);
            };
        }

        public Func<TContextA, TContextB, TContextC, Task> In_ContextSet_ABC_A<TContextA, TContextB, TContextC>(
            params Func<TContextA, Task>[] operations)
        {
            return this.In_ContextSet_ABC_A<TContextA, TContextB, TContextC>(
                operations.AsEnumerable());
        }

        public Func<TContextA, TContextB, TContextC, Task> In_ContextSet_ABC_AB<TContextA, TContextB, TContextC>(
            IEnumerable<Func<TContextA, TContextB, Task>> operations)
        {
            return (contextA, contextB, _) =>
            {
                return Instances.ContextOperator.In_ContextSet<TContextA, TContextB>(
                    contextA,
                    contextB,
                    operations);
            };
        }

        public Func<TContextA, TContextB, TContextC, Task> In_ContextSet_ABC_AB<TContextA, TContextB, TContextC>(
            params Func<TContextA, TContextB, Task>[] operations)
        {
            return this.In_ContextSet_ABC_AB<TContextA, TContextB, TContextC>(
                operations.AsEnumerable());
        }

        public Func<TContextA, TContextB, TContextC, Task> In_ContextSet_ABC_DABC<TContextD, TContextA, TContextB, TContextC>(
            Func<TContextA, TContextB, TContextC, Task<TContextD>> contextDConstructor,
            IEnumerable<Func<TContextD, TContextA, TContextB, TContextC, Task>> operations)
        {
            return async (contextA, contextB, contextC) =>
            {
                var contextD = await contextDConstructor(contextA, contextB, contextC);

                await Instances.ContextOperator.In_ContextSet<TContextD, TContextA, TContextB, TContextC>(
                    contextD,
                    contextA,
                    contextB,
                    contextC,
                    operations);
            };
        }

        public Func<TContextA, TContextB, TContextC, Task> In_ContextSet_ABC_DABC<TContextD, TContextA, TContextB, TContextC>(
            Func<TContextA, TContextB, TContextC, Task<TContextD>> contextDConstructor,
            params Func<TContextD, TContextA, TContextB, TContextC, Task>[] operations)
        {
            return this.In_ContextSet_ABC_DABC(
                contextDConstructor,
                operations.AsEnumerable());
        }

        public Func<TContextA, TContextB, TContextC, TContextD, Task> In_ContextSet_ABCD_A<TContextA, TContextB, TContextC, TContextD>(
            IEnumerable<Func<TContextA, Task>> operations)
        {
            return (contextA,
                // Unable to use feature lambda discard parameter in C# 8 (netstandard2.1).
                // So just indicate discard.
                _B, _C, _D) =>
            {
                return Instances.ContextOperator.In_ContextSet<TContextA>(
                    contextA,
                    operations);
            };
        }

        public Func<TContextA, TContextB, TContextC, TContextD, Task> In_ContextSet_ABCD_A<TContextA, TContextB, TContextC, TContextD>(
            params Func<TContextA, Task>[] operations)
        {
            return this.In_ContextSet_ABCD_A<TContextA, TContextB, TContextC, TContextD>(
                operations.AsEnumerable());
        }

        public Func<TContextA, TContextB, TContextC, TContextD, Task> In_ContextSet_ABCD_AB<TContextA, TContextB, TContextC, TContextD>(
            IEnumerable<Func<TContextA, TContextB, Task>> operations)
        {
            // Unable to use feature lambda discard parameter in C# 8 (netstandard2.1).
            // So just indicate discard.
            return (contextA, contextB,
                _C, _D) =>
            {
                return Instances.ContextOperator.In_ContextSet<TContextA, TContextB>(
                    contextA,
                    contextB,
                    operations);
            };
        }

        public Func<TContextA, TContextB, TContextC, TContextD, Task> In_ContextSet_ABCD_AB<TContextA, TContextB, TContextC, TContextD>(
            params Func<TContextA, TContextB, Task>[] operations)
        {
            return this.In_ContextSet_ABCD_AB<TContextA, TContextB, TContextC, TContextD>(
                operations.AsEnumerable());
        }

        public Func<TContextA, TContextB, TContextC, TContextD, Task> In_ContextSet_ABCD_AC<TContextA, TContextB, TContextC, TContextD>(
            IEnumerable<Func<TContextA, TContextC, Task>> operations)
        {
            // Unable to use feature lambda discard parameter in C# 8 (netstandard2.1).
            // So just indicate discard.
            return (contextA, _B, contextC, _D) =>
            {
                return Instances.ContextOperator.In_ContextSet<TContextA, TContextC>(
                    contextA,
                    contextC,
                    operations);
            };
        }

        public Func<TContextA, TContextB, TContextC, TContextD, Task> In_ContextSet_ABCD_AC<TContextA, TContextB, TContextC, TContextD>(
            params Func<TContextA, TContextC, Task>[] operations)
        {
            return this.In_ContextSet_ABCD_AC<TContextA, TContextB, TContextC, TContextD>(
                operations.AsEnumerable());
        }

        public Func<TContextA, TContextB, TContextC, TContextD, Task> In_ContextSet_ABCD_EAC<TContextE, TContextA, TContextB, TContextC, TContextD>(
            Func<TContextA, TContextB, TContextC, TContextD, Task<TContextE>> contextEConstructor,
            IEnumerable<Func<TContextE, TContextA, TContextC, Task>> operations)
        {
            // Unable to use feature lambda discard parameter in C# 8 (netstandard2.1).
            // So just indicate discard.
            return async (contextA, contextB, contextC, contextD) =>
            {
                var contextE = await contextEConstructor(
                    contextA,
                    contextB,
                    contextC,
                    contextD);

                await Instances.ContextOperator.In_ContextSet<TContextE, TContextA, TContextC>(
                    contextE,
                    contextA,
                    contextC,
                    operations);
            };
        }

        public Func<TContextA, TContextB, TContextC, TContextD, Task> In_ContextSet_ABCD_EAC<TContextE, TContextA, TContextB, TContextC, TContextD>(
            Func<TContextA, TContextB, TContextC, TContextD, Task<TContextE>> contextEConstructor,
            params Func<TContextE, TContextA, TContextC, Task>[] operations)
        {
            return this.In_ContextSet_ABCD_EAC<TContextE, TContextA, TContextB, TContextC, TContextD>(
                contextEConstructor,
                operations.AsEnumerable());
        }

        public Func<TContextA, TContextB, TContextC, TContextD, Task> In_ContextSet_ABCD_EABCD<TContextE, TContextA, TContextB, TContextC, TContextD>(
            Func<TContextA, TContextB, TContextC, TContextD, Task<TContextE>> contextEConstructor,
            IEnumerable<Func<TContextE, TContextA, TContextB, TContextC, TContextD, Task>> operations)
        {
            // Unable to use feature lambda discard parameter in C# 8 (netstandard2.1).
            // So just indicate discard.
            return async (contextA, contextB, contextC, contextD) =>
            {
                var contextE = await contextEConstructor(
                    contextA,
                    contextB,
                    contextC,
                    contextD);

                await Instances.ContextOperator.In_ContextSet<TContextE, TContextA, TContextB, TContextC, TContextD>(
                    contextE,
                    contextA,
                    contextB,
                    contextC,
                    contextD,
                    operations);
            };
        }

        public Func<TContextA, TContextB, TContextC, TContextD, Task> In_ContextSet_ABCD_EABCD<TContextE, TContextA, TContextB, TContextC, TContextD>(
            Func<TContextA, TContextB, TContextC, TContextD, Task<TContextE>> contextEConstructor,
            params Func<TContextE, TContextA, TContextB, TContextC, TContextD, Task>[] operations)
        {
            return this.In_ContextSet_ABCD_EABCD<TContextE, TContextA, TContextB, TContextC, TContextD>(
                contextEConstructor,
                operations.AsEnumerable());
        }

        public Func<TContextA, TContextB, TContextC, TContextD, TContextE, Task> In_ContextSet_ABCDE_A<TContextA, TContextB, TContextC, TContextD, TContextE>(
            IEnumerable<Func<TContextA, Task>> operations)
        {
            // Unable to use feature lambda discard parameter in C# 8 (netstandard2.1).
            // So just indicate discard.
            return (contextA, _B, _C, _D, _E) =>
            {
                return Instances.ContextOperator.In_ContextSet<TContextA>(
                    contextA,
                    operations);
            };
        }

        public Func<TContextA, TContextB, TContextC, TContextD, TContextE, Task> In_ContextSet_ABCDE_A<TContextA, TContextB, TContextC, TContextD, TContextE>(
            params Func<TContextA, Task>[] operations)
        {
            return this.In_ContextSet_ABCDE_A<TContextA, TContextB, TContextC, TContextD, TContextE>(
                operations.AsEnumerable());
        }

        public Func<TContextA, TContextB, TContextC, TContextD, TContextE, Task> In_ContextSet_ABCDE_AB<TContextA, TContextB, TContextC, TContextD, TContextE>(
            IEnumerable<Func<TContextA, TContextB, Task>> operations)
        {
            // Unable to use feature lambda discard parameter in C# 8 (netstandard2.1).
            // So just indicate discard.
            return (contextA, contextB, _C, _D, _E) =>
            {
                return Instances.ContextOperator.In_ContextSet<TContextA, TContextB>(
                    contextA,
                    contextB,
                    operations);
            };
        }

        public Func<TContextA, TContextB, TContextC, TContextD, TContextE, Task> In_ContextSet_ABCDE_AB<TContextA, TContextB, TContextC, TContextD, TContextE>(
            params Func<TContextA, TContextB, Task>[] operations)
        {
            return this.In_ContextSet_ABCDE_AB<TContextA, TContextB, TContextC, TContextD, TContextE>(
                operations.AsEnumerable());
        }

        public Func<TContextA, TContextB, TContextC, TContextD, TContextE, Task> In_ContextSet_ABCDE_AC<TContextA, TContextB, TContextC, TContextD, TContextE>(
            IEnumerable<Func<TContextA, TContextC, Task>> operations)
        {
            // Unable to use feature lambda discard parameter in C# 8 (netstandard2.1).
            // So just indicate discard.
            return (contextA, _B, contextC, _D, _E) =>
            {
                return Instances.ContextOperator.In_ContextSet<TContextA, TContextC>(
                    contextA,
                    contextC,
                    operations);
            };
        }

        public Func<TContextA, TContextB, TContextC, TContextD, TContextE, Task> In_ContextSet_ABCDE_AC<TContextA, TContextB, TContextC, TContextD, TContextE>(
            params Func<TContextA, TContextC, Task>[] operations)
        {
            return this.In_ContextSet_ABCDE_AC<TContextA, TContextB, TContextC, TContextD, TContextE>(
                operations.AsEnumerable());
        }

        public Func<TContextA, TContextB, TContextC, TContextD, TContextE, Task> In_ContextSet_ABCDE_ABD<TContextA, TContextB, TContextC, TContextD, TContextE>(
            IEnumerable<Func<TContextA, TContextB, TContextD, Task>> operations)
        {
            // Unable to use feature lambda discard parameter in C# 8 (netstandard2.1).
            // So just indicate discard.
            return (contextA, contextB, _C, contextD, _E) =>
            {
                return Instances.ContextOperator.In_ContextSet<TContextA, TContextB, TContextD>(
                    contextA,
                    contextB,
                    contextD,
                    operations);
            };
        }

        public Func<TContextA, TContextB, TContextC, TContextD, TContextE, Task> In_ContextSet_ABCDE_ABD<TContextA, TContextB, TContextC, TContextD, TContextE>(
            params Func<TContextA, TContextB, TContextD, Task>[] operations)
        {
            return this.In_ContextSet_ABCDE_ABD<TContextA, TContextB, TContextC, TContextD, TContextE>(
                operations.AsEnumerable());
        }
    }
}
