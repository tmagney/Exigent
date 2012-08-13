namespace ExigentFacts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;
    using FluentAssertions;
    using Exigent;

    public class ExigentFacts
    {
        [Fact]
        public void can_throw()
        {
            try
            {
                Exigent.Throw<Exception>("WTFH!");
            }
            catch (Exception ex)
            {

            }
        }

    }
}
