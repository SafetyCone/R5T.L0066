using System;


namespace R5T.L0066
{
    public class CharacterOperator : ICharacterOperator
    {
        #region Infrastructure

        public static ICharacterOperator Instance { get; } = new CharacterOperator();


        private CharacterOperator()
        {
        }

        #endregion
    }
}
