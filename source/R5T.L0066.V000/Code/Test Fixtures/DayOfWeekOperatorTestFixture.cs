using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using R5T.T0243;
using R5T.V0002;


namespace R5T.L0066.V000
{
    [TestClass, TestFixtureImplementationMarker]
    public class DayOfWeekOperatorTestFixture : DayOfWeekOperatorTestFixture<DayOfWeekOperatorTestArticle>
    {
        public override DayOfWeekOperatorTestArticle TestArticle { get; } = new DayOfWeekOperatorTestArticle();
    }
}
