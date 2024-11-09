using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;

namespace AssetManagement.Core.Utilities
{
    public class ReportHelper
    {
        static ExtentReports ExtentManager;

        [ThreadStatic]
        public static ExtentTest ExtentTest;

        [ThreadStatic]
        public static ExtentTest Node;

        public static void InitializeReport(
            string reportPath,
            string hostName,
            string environment,
            string browser
        )
        {
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath);
            ExtentManager = new ExtentReports();
            ExtentManager.AttachReporter(htmlReporter);
            ExtentManager.AddSystemInfo("Host Name", hostName);
            ExtentManager.AddSystemInfo("Environment", environment);
            ExtentManager.AddSystemInfo("Browser", browser);
            Console.WriteLine("Initialize report");
        }

        public static void Flush()
        {
            Console.WriteLine("Before flush");
            ExtentManager.Flush();
            Console.WriteLine("After flush");
        }

        public static void CreateTest(string name)
        {
            ExtentTest = ExtentManager.CreateTest(name);
            Console.WriteLine("Create Test");
        }

        public static void CreateNode(string name)
        {
            Node = ExtentTest.CreateNode(name);
            Console.WriteLine("Create Node");
        }

        public static void LogTestStep(string step)
        {
            Node.Info(step);
        }

        public static void CreateTestResult(
            TestStatus status,
            string stackTrace,
            string className,
            string testName
        )
        {
            Status logStatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logStatus = Status.Fail;
                    Node.Fail("#Test Name: " + testName + " #Status: " + logStatus + stackTrace);
                    break;
                case TestStatus.Inconclusive:
                    logStatus = Status.Warning;
                    Node.Log(logStatus, "#Test Name: " + testName + " #Status: " + logStatus);
                    break;
                case TestStatus.Skipped:
                    logStatus = Status.Skip;
                    Node.Skip("#Test Name: " + testName + " #Status: " + logStatus);
                    break;
                default:
                    logStatus = Status.Pass;
                    Node.Log(logStatus, "#Test Name: " + testName + " #Status: " + logStatus);
                    break;
            }
        }
    }
}
