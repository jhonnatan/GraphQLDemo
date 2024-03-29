﻿using System;

namespace GraphQLDemo.Tests.TestCaseOrdering
{
    class TestPriorityAttribute : Attribute
    {
        public TestPriorityAttribute(int priority)
        {
            Priority = priority;
        }

        public int Priority { get; private set; }
    }
}
