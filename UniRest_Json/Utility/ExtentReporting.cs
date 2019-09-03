﻿using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System.IO;
using UniRest_Json.Utility;

namespace UniRest_Json
{
    class ExtentReporting
    {
        private static ExtentTest _testCase;
        private ExtentReports _report;
        private ExtentHtmlReporter _htmlReporter;
        private static string browser;
        public ReadExcel _readExcel = new ReadExcel();



        public object LogStatus { get; private set; }

        public ExtentReporting(string reportName, string documentTitle)
        {
            setupExtentReport(reportName, documentTitle);
        }

        public ExtentReporting(string reportName, string documentTitle, string browserType)
        {
            setupExtentReport(reportName, documentTitle, browserType);
        }
        public void createTest(string testName)
        {
            _testCase = _report.CreateTest(testName);
        }

        public void logReportStatement(Status status, string message)
        {
            _testCase.Log(status, message);
        }

        public void flushReport()
        {
            _report.Flush();
        }
       
        public void testStatusWithMsg(string status, string message)
        {
            if (status.Equals("Pass"))
            {
                _testCase.Pass(message);
            }
            else
            {
                _testCase.Fail(message);
            }
        }

        private void setupExtentReport(string reportName, string documentTitle, string browserType)
        {
            string currentTime = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss");
            // _htmlReporter = new ExtentHtmlReporter(Directory.GetCurrentDirectory() + "\\" + currentTime +"-" + browserType + ".html");
            _htmlReporter = new ExtentHtmlReporter(_readExcel.getSolutionPath() + "\\Reports\\" + currentTime + "-" + browserType + ".html");
            _htmlReporter.Configuration().Theme = Theme.Dark;
            _htmlReporter.Configuration().DocumentTitle = documentTitle;
            _htmlReporter.Configuration().ReportName = reportName + " Execution Browser: " + browserType;
            _report = new ExtentReports();
            _report.AttachReporter(_htmlReporter);
        }
        private void setupExtentReport(string reportName, string documentTitle)
        {
            string currentTime = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss");
            //_htmlReporter = new ExtentHtmlReporter(Directory.GetCurrentDirectory() + "\\" + currentTime +"-" + _configurator.getBrowser() + ".html");
            _htmlReporter = new ExtentHtmlReporter(_readExcel.getSolutionPath() + "\\Reports\\" + reportName + "_" + currentTime + "-" + ".html");
            _htmlReporter.Configuration().Theme = Theme.Dark;
            _htmlReporter.Configuration().DocumentTitle = documentTitle;
            // _htmlReporter.Configuration().ReportName = reportName + " Execution Browser: " + _configurator.getBrowser();
            _htmlReporter.Configuration().ReportName = reportName;
            _report = new ExtentReports();
            _report.AttachReporter(_htmlReporter);
        }
    }
}
