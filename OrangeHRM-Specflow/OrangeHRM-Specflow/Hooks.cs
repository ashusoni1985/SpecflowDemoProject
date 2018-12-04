using ALD_Belgium;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace OrangeHRM_Specflow
{
    [Binding]
    [TestFixture]
    class Hooks
    {
        public static ExtentTest featureName;
        public static ExtentReports extent;
        public static ExtentHtmlReporter htmlReporter;
        public static ExtentTest test;

        public static object Theme { get; private set; }

        static Hooks()
        {
            if (extent == null)
            {
                BasicSetUp();
            }

        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);

        }

        [BeforeScenario]
        public static void Setup()
        {
            BasePage.Intitialize();
            BasePage.Navigate();
            //  test = extent.CreateTest(ScenarioContext.Current.ScenarioInfo.Title);
            test = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void TearDown()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                var error = ScenarioContext.Current.TestError;
                var errormessage = "<pre>" + error.Message + "</pre>";

                extent.AddTestRunnerLogs(errormessage);
                test.Log(Status.Error, errormessage);
                test.Fail(errormessage);

            }
            BasePage.Quit();
        }

        [OneTimeSetUp]
        public static void BasicSetUp()
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            // string pth = System.IO.Directory.GetCurrentDirectory();
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            Console.WriteLine(" -----------Project Path--------------------------------------");
            Console.WriteLine(projectPath);
            string reportPath = projectPath + "Reports\\TestExecutionRunReport.html";
            // Console.WriteLine("Report Path is " + reportPath);


            htmlReporter = new ExtentHtmlReporter(reportPath);
            //htmlReporter.Configuration().Theme = Theme.Dark;


            htmlReporter.Configuration().DocumentTitle = "SpecFlow Test Resport Document";

            htmlReporter.Configuration().ReportName = "Feature Run Results";

            extent = new ExtentReports();

            extent.AttachReporter(htmlReporter);
            //extent.LoadConfig(projectPath + "Extent-Config.xml");

        }


        [AfterTestRun]
        public static void EndReport()
        {
            extent.Flush();

        }

        [AfterStep]
        public static void InsertReportingSteps()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();


            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    test.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    test.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    test.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    test.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);

            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                    test.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                else if (stepType == "When")
                    test.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                else if (stepType == "And")
                    test.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                else if (stepType == "Then")
                    test.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);

            }

        }
    }
}
