namespace UiTests
{
    using System;
    using System.IO;
    using System.Reflection;

    using NUnit.Framework;

    using UiTests.Framework;

    public abstract class LoginTestBase : ApplicationTestBase
    {
        private const string RESOURCES = "Resources";

        protected string ResourcesPath { get; private set; }

        [SetUp]
        public new void SetUp()
        {
            PassLogin();

            var uiTestAssemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (string.IsNullOrEmpty(uiTestAssemblyDir))
                throw new InvalidOperationException("Directory of UiTests assembly cannot be located.");

            ResourcesPath = Path.Combine(uiTestAssemblyDir, RESOURCES);
        }
    }
}