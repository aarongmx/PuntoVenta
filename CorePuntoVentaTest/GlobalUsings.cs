global using NUnit.Framework;
using AutoFixture;
using CorePuntoVenta;
using EntityFrameworkCore.Testing.Moq;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

[SetUpFixture]
public class SetupTrace
{
    [OneTimeSetUp]
    public void StartTest()
    {
        Trace.Listeners.Add(new ConsoleTraceListener());
    }

    [OneTimeTearDown]
    public void EndTest()
    {
        Trace.Flush();
    }
}