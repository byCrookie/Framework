using System.Threading.Tasks;
using Autofac;
using FluentAssertions;
using Framework.DependencyInjection.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Workflow;
using IContainer = Autofac.IContainer;

namespace Framework.Autofac.Tests;

[TestClass]
public class FrameworkAutofacTest
{
    private IContainer _container = null!;

    [TestInitialize]
    public void Initialize()
    {
        var containerBuilder = new ContainerBuilder();
        containerBuilder.RegisterModule<FrameworkModule>();
        containerBuilder.RegisterGeneric(typeof(WorkflowTestStep<>)).As(typeof(IWorkflowTestStep<>));
        containerBuilder.RegisterGeneric(typeof(WorkflowTestOptionsStep<,>)).As(typeof(IWorkflowTestOptionsStep<,>));
        _container = containerBuilder.Build();
    }

    [TestMethod]
    public void Resolve_WhenWorkflowWasAdded_ThenCanResolveWorkflowBuilder()
    {
        var factory = _container.Resolve<IFactory>();
        var workflowBuilder = factory.Create<IWorkflowBuilder<WorkflowTestContext>>();

        workflowBuilder.Should().NotBeNull();
    }

    [TestMethod]
    public async Task Resolve_WhenWorkflowWasAdded_ThenCanBuildWorkflowWithCustomSteps()
    {
        var factory = _container.Resolve<IFactory>();
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
        var factory = _container.Resolve<IFactory>();
        var workflowBuilder = factory.Create<IWorkflowBuilder<WorkflowTestContext>>();

        var workflow = workflowBuilder
            .ThenAsync<IWorkflowTestOptionsStep<WorkflowTestContext, WorkflowTestStepOptions>, WorkflowTestStepOptions>(options => { options.IsValid = true; })
            .Build();

        var result = await workflow.RunAsync(new WorkflowTestContext()).ConfigureAwait(false);

        result.Valid.Should().BeTrue();
    }
}