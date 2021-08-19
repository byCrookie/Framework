using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using Framework.Autofac.Factory;
using Framework.Test.Flow.ConfigStep;
using Framework.Workflow;
using NUnit.Framework;

namespace Framework.Test.Flow
{
    public class WorkflowTest
    {
        private IFactory _factory;
        private WorkflowBuilder<TestContext> _workflowBuilder;

        [SetUp]
        public void Setup()
        {
            _factory = A.Fake<IFactory>();
            _workflowBuilder = new WorkflowBuilder<TestContext>(_factory);
        }

        [Test]
        public async Task METHOD_WHEN_THEN()
        {
            A.CallTo(() => _factory.Create<ITestOptionsStep<TestContext, TestStepOptions>>())
                .Returns(new TestOptionsStep<TestContext, TestStepOptions>());
            
            var workflow = _workflowBuilder
                .If(_ => true, c => c.Results.Add("If"))
                .IfAsync(_ => Task.FromResult(true), c => AddAsync(c, "IfAsync"))
                .Then(c => c.Results, c => c.Results.Concat(new List<string> {"Then"}).ToList())
                .ThenAsync(c => AddAsync(c, "ThenAsync"))
                .IfElse(_ => false, c => c.Results.Add("IfElseIf"), c => c.Results.Add("IfElseElse"))
                .IfElseAsync(_ => Task.FromResult(true), c => AddAsync(c, "IfElseIfAsync"),
                    c => AddAsync(c, "IfElseElseAsync"))
                .ThenAsync<ITestOptionsStep<TestContext, TestStepOptions>, TestStepOptions>(config => config
                    .SetParam1("conf1")
                    .SetParam2("conf2")
                )
                .Build();

            var context = await workflow.RunAsync(new TestContext()).ConfigureAwait(false);

            var expectedResults = new List<string>
            {
                "If",
                "IfAsync",
                "Then",
                "ThenAsync",
                "IfElseElse",
                "IfElseIfAsync",
            };

            context.Results.Should().BeEquivalentTo(expectedResults, options => options.WithStrictOrdering());
            context.Config.Param1.Should().Be("conf1");
            context.Config.Param2.Should().Be("conf2");
        }

        private static Task AddAsync(TestContext context, string message)
        {
            context.Results.Add(message);
            return Task.CompletedTask;
        }
    }
}