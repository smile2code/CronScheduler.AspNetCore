﻿using CronScheduler.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CronScheduler.UnitTest
{
    public class BackgroundQueueTests
    {
        [Fact]
        public async Task Dequeue_With_Susseful_WorkItemName()
        {
            var workItemName = "TestItem";

            var service = new BackgroundTaskQueue();

            service.QueueBackgroundWorkItem(async token =>
            {
                await new TaskCompletionSource<object>().Task;
            }
            , workItemName);

            var task = await service.DequeueAsync(CancellationToken.None);

            await task.workItem(CancellationToken.None);

            Assert.Equal(workItemName, task.workItemName);
        }
    }
}