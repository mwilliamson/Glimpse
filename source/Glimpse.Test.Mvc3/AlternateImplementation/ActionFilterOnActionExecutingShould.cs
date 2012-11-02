﻿using System;
using System.Web.Mvc;
using Glimpse.Core;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Message;
using Glimpse.Mvc.AlternateImplementation;
using Glimpse.Test.Common;
using Moq;
using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;

namespace Glimpse.Test.Mvc3.AlternateImplementation
{
    public class ActionFilterOnActionExecutingShould
    {
        [Fact]
        public void ReturnProperMethodToImplement()
        {
            var impl = new ActionFilter.OnActionExecuting();

            Assert.Equal("OnActionExecuting", impl.MethodToImplement.Name);
        }

        [Theory, AutoMock]
        public void ReturnWhenRuntimePolicyIsOff(IAlternateImplementationContext context)
        {
            context.Setup(c => c.RuntimePolicyStrategy).Returns(() => RuntimePolicy.Off);

            var impl = new ActionFilter.OnActionExecuting();

            impl.NewImplementation(context);

            context.Verify(c => c.Proceed());
        }

        [Theory, AutoMock]
        public void PublishMessageWhenExecuted([Frozen] IExecutionTimer timer, ActionExecutingContext argument, IAlternateImplementationContext context)
        {
            context.Setup(c => c.Arguments).Returns(new[] { argument });

            var impl = new ActionFilter.OnActionExecuting();

            impl.NewImplementation(context);

            timer.Verify(t => t.Time(It.IsAny<Action>()));
            context.MessageBroker.Verify(mb => mb.Publish(It.IsAny<ActionFilter.OnActionExecuting.Message>()));
            context.MessageBroker.Verify(mb => mb.Publish(It.IsAny<TimerResultMessage>()));
        }
    }
}