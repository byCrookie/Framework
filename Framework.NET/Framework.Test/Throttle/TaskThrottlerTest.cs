using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using Framework.Throttle;
using log4net;
using NUnit.Framework;

namespace Framework.Test.Throttle
{
    public class TaskThrottlerTest
    {
        private TaskThrottler _testee;

        [SetUp]
        public void Setup()
        {
            var log = A.Fake<ILog>();
            _testee = new TaskThrottler(log);
        }

        [Test]
        public async Task METHOD_WHEN_THEN()
        {
            var tasks = CreateTasks();
            var results = (await _testee.ThrottleAsync(tasks, new ThrottleLimit(1, 2, 10), CancellationToken.None)
                .ConfigureAwait(false)).ToList();

            var dic = results.ToDictionary(r => r.Name, r => r);

            var item1 = dic["1"];
            var item2 = dic["2"];
            var item3 = dic["3"];
            var item4 = dic["4"];
            var item5 = dic["5"];
            
            // Durations
            (item1.End.Second - item1.Start.Second).Should().Be(1);
            (item2.End.Second - item2.Start.Second).Should().Be(2);
            (item3.End.Second - item3.Start.Second).Should().Be(1);
            (item4.End.Second - item4.Start.Second).Should().Be(4);
            (item5.End.Second - item5.Start.Second).Should().Be(1);
            
            // Dependent on
            (item2.End.Second - item1.End.Second).Should().Be(1);
            (item4.End.Second - item3.End.Second).Should().Be(3);

            // Start next group after 10s
            item3.Start.Second.Should().Be(item1.Start.Second + 10);
            item4.Start.Second.Should().Be(item1.Start.Second + 10);
            
            // start last group after 20s
            item5.Start.Second.Should().Be(item1.Start.Second + 20);
        }

        private static IEnumerable<Func<Task<TaskExecutionResult>>> CreateTasks()
        {
            yield return () => CreateTaskAsync(1000, "1");
            yield return () => CreateTaskAsync(2000, "2");
            yield return () => CreateTaskAsync(1000, "3");
            yield return () => CreateTaskAsync(4000, "4");
            yield return () => CreateTaskAsync(1000, "5");
        }

        private static async Task<TaskExecutionResult> CreateTaskAsync(int delay, string name)
        {
            var start = DateTime.Now;
            Console.WriteLine($"Item: {name} Delay: {delay} Start: {start}");
            await Task.Delay(delay).ConfigureAwait(false);
            var end = DateTime.Now;
            Console.WriteLine($"Item: {name} Delay: {delay} End: {end}");
            return new TaskExecutionResult
            {
                Start = start,
                Delay = delay,
                Name = name,
                End = end
            };
        }
    }

    internal class TaskExecutionResult
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Delay { get; set; }
        public string Name { get; set; }
    }
}