using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using unirest_net.http;
using UniRest_Json.Utility;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace UniRest_Json.SpecFlow.StepDefenition
{
    [Binding]
    public class GetSingleResourceSteps
    {
        LoadJsonfile jsonRead = new LoadJsonfile();
        Excel readExcelReader = new Excel();
        string response;
        string responseStatus;
        ReadExcel filePath = new ReadExcel();
        ExtentReporting extentReporting = new ExtentReporting("Unirest_CREATE_Request_TestReport", "APITestResultsDoc");
        [OneTimeSetUp]

        [Given(@"I have API url for get the resource")]
        public string GivenIHaveAPIUrlForGetTheResource()
        {
            return readExcelReader.readExcel(filePath.filePathToExcel(), 1, 1, 2);
        }
        
        [When(@"I send the request with send parameter")]
        public void WhenISendTheRequestWithSendParameter()
        {
            HttpResponse<string> jsonResponse = Unirest.get(GivenIHaveAPIUrlForGetTheResource()).asString();
            response = jsonResponse.Body.ToString();
            responseStatus = jsonResponse.Code.ToString();
        }
        
        [Then(@"resource details should display")]
        public void ThenResourceDetailsShouldDisplay()
        {
            extentReporting.createTest("GET_Request_Test");
            dynamic results = JObject.Parse(response);
            dynamic array = jsonRead.LoadJson();
            dynamic results2 = JObject.Parse(array);
            //jsonRead.LoadJson();

            try
            {
               
                Assert.AreEqual((string)results2["data"][0]["id"], (string)results["data"][0]["id"]);
                Assert.AreEqual((string)results2["data"][0]["name"], (string)results["data"][0]["name"]);


                extentReporting.testStatusWithMsg("Pass", "GET_Request_TestPassed");
            }
            catch (AssertionException e)
            {
                extentReporting.logReportStatement(AventStack.ExtentReports.Status.Error, e.Message);
                extentReporting.testStatusWithMsg("Fail", "GET_Request_TestFailed");
            }

            extentReporting.flushReport();

        }
    }
    
}
