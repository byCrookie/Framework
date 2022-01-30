using System.Threading.Tasks;
using FluentAssertions;
using Framework.DependencyInjection.Factory;
using Framework.Jab.Boot;
using Framework.Jab.Boot.Jab;
using Framework.Jab.Boot.Logger;
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
            .ThenAsync<IWorkflowTestOptionsStep<WorkflowTestContext, WorkflowTestStepOptions>, WorkflowTestStepOptions>(options => { options.IsValid = true; })
            .Build();

        var result = await workflow.RunAsync(new WorkflowTestContext()).ConfigureAwait(false);

        result.Valid.Should().BeTrue();
    }

    [TestMethod]
    public async Task Resolve_WhenWorkflowWasAdded_ThenCanBuildWorkflowWithLoggerOptionsSteps()
    {
        var bootScope = BootConfiguration.Configure<BootContext>(_serviceProvider);

        var workflow = bootScope.WorkflowBuilder
            .ThenAsync<ILoggerBootStep<BootContext, LoggerBootStepOptions>, LoggerBootStepOptions>(options => options
                .Configuration.MinimumLevel.Verbose()
            )
            .Build();

        var result = await workflow.RunAsync(new BootContext(bootScope)).ConfigureAwait(false);

        result.Should().NotBeNull();
        result.ServiceProvider.Should().Be(_serviceProvider);
    }
}