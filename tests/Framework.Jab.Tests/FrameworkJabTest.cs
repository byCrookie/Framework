using System.Threading.Tasks;
using FluentAssertions;
using Framework.DependencyInjection.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Workflow;

namespace Framework.Jab.Tests;

[TestClass]
public class FrameworkJabTest
{
    private WorkflowServiceProvider _serviceProvider = null!;

    [TestInitialize]
    public void Initialize()
    {
        _serviceProvider = new WorkflowServiceProvider();
    }

    [TestMethod]
    public void Resolve_WhenWorkflowWasAdded_ThenCanResolveWorkflowBuilder()
    {
        var factory = _serviceProvider.GetService<IFactory>();
        var workflowBuilder = factory.Create<IWorkflowBuilder<WorkflowTestContext>>();
        
        workflowBuilder.Should().NotBeNull();
    }
    
    [TestMethod]
    public async Task Resolve_WhenWorkflowWasAdded_ThenCanBuildWorkflowWithCustomSteps()
    {
        var factory = _serviceProvider.GetService<IFactory>();
        var workflowBuilder = factory.Create<IWorkflowBuilder<WorkflowTestContext>>();

        var workflow = workflowBuilder
            .ThenAsync<IWorkflowTestStep<WorkflowTestContext>>()
            .Build();

        var result = await workflow.RunAsync(new WorkflowTestContext()).ConfigureAwait(false);

        result.Valid.Should().BeTrue();
    }
    
    [TestMethod]
    public async Task Resolve_WhenWorkflowWasAdded_ThenCanBuildWorkflowWithCustomOptionsSteps()
    {
        var factory = _serviceProvider.GetService<IFactory>();
        var workflowBuilder = factory.Create<IWorkflowBuilder<WorkflowTestContext>>();

        var workflow = workflowBuilder
            .ThenAsync<IWorkflowTestOptionsStep<WorkflowTestContext, WorkflowTestStepOptions>, WorkflowTestStepOptions>(options =>
            {
                options.IsValid = true;
            })
            .Build();

        var result = await workflow.RunAsync(new WorkflowTestContext()).ConfigureAwait(false);

        result.Valid.Should().BeTrue();
    }
}