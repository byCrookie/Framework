using System.Collections.Generic;
using Framework.Test.Flow.ConfigStep;
using Framework.Workflow;

namespace Framework.Test.Flow
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