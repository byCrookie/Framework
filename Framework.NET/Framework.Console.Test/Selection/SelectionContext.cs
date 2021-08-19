using Framework.Workflow;

namespace Framework.Console.Test.Selection
{
    internal class SelectionContext : WorkflowBaseContext, ISelectionContext
    {
        public short Selection { get; set; }
        public string Input { get; set; }
    }
}