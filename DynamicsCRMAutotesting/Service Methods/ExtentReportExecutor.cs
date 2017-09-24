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

        /// <summary>
        /// The method starts reporting
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="author"></param>
        public void StartReport(string name, string description, string author)
        {
            test = autotestreport.CreateTest(name, description);
            test.AssignAuthor(author);
        }

        /// <summary>
        /// The method adds information to the report columns
        /// </summary>
        /// <param name="status"></param>
        /// <param name="stepname"></param>
        public void WriteLog(Status status, string stepname)
        {
            test.Log(status, stepname);
        }

        /// <summary>
        /// The method finishes reporting
        /// </summary>
        public void FinishReport()
        {
            autotestreport.Flush();
        }
    }
}
