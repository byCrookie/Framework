using System;
using Framework.Console.Test.Selection;
using Framework.Workflow;

namespace Framework.Console.Test
{
    public class ConsoleTestContext : WorkflowBaseContext, ISelectionContext
    {
        public string MultiLineInput { get; set; }
        public string SingleInput { get; set; }
        public short Selection { get; set; }
        public ConsoleKeyInfo Key { get; set; }
    }
}