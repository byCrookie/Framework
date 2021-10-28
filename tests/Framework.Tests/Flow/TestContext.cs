using System.Collections.Generic;
using Framework.Tests.Flow.ConfigStep;
using Workflow;

namespace Framework.Tests.Flow
{
    internal class TestContext : WorkflowBaseContext
    {
        public TestContext()
        {
            Results = new List<string>();
        }

        public List<string> Results { get; set; }
        public TestStepOptions Config { get; set; }
    }
}