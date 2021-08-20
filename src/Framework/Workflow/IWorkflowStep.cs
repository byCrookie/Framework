using System.Threading.Tasks;

namespace Framework.Workflow
{
    public interface IWorkflowStep<in TContext> where TContext : WorkflowBaseContext
    {
        Task ExecuteAsync(TContext context);
        Task<bool> ShouldExecuteAsync(TContext context);
    }
}