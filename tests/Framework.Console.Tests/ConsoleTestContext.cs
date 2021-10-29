using System;
using Framework.Console.Tests.Selection;
using Workflow;

namespace Framework.Console.Tests
{
    public class ConsoleTestContext : WorkflowBaseContext, ISelectionContext
    {
        public string MultiLineInput { get; set; }
        public string SingleInput { get; set; }
        public short Selection { get; set; }
        public ConsoleKeyInfo Key { get; set; }
    }
}