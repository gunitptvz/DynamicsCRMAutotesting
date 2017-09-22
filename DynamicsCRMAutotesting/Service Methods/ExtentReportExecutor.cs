using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;

namespace DynamicsCRMAutotesting.Service_Methods
{
    class ExtentReportExecutor
    {
        ExtentReports autotestreport;
        ExtentTest test;

        public ExtentReportExecutor(string host)
        {
            ExtentXReporter reporter = new ExtentXReporter(host);
            autotestreport = new ExtentReports();
            autotestreport.AttachReporter(reporter);
        }

        public void StartReport(string name, string description, string author)
        {
            test = autotestreport.CreateTest(name, description);
            test.AssignAuthor(author);
        }

        public void WriteLog(Status status, string stepname)
        {
            test.Log(status, stepname);
        }

        public void FinishReport()
        {
            autotestreport.Flush();
        }
    }
}
