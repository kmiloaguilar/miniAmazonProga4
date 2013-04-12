using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace MiniAmazon.Domain.Specs
{
    public class when_something
    {
        private Establish context = () =>
            {
                context
            };

        private Because of = () => {
                                       _result = null;
        };

        private It should_do_something = () =>
            {
                it
            };
    }
}
