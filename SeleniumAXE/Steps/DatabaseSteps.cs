using DnsClient.Protocol;
using SeleniumAXE.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;

namespace SeleniumAXE.Steps
{
    [Binding]
    public class DatabaseSteps : TechTalk.SpecFlow.Steps
    {
        //[When(@"I run this query:")]
        //public void WhenIRunThisQuery(string multilineText)
        //{
        //    multilineText = multilineText.ReplaceDynamicValues();
        //    DatabaseHelper.RunSQLQuery(multilineText);
        //}

        //[When(@"I run this query and record the ""(.*)"" column as ""(.*)"":")]
        //public void WhenIRunThisQueryAndRecordTheColumnAs(string columnName, string variable, string multilineText)
        //{
        //    DataTable dt = DatabaseHelper.RunSQLQuery(multilineText);

        //    string value = null;
        //    foreach (DataColumn column in dt.Columns)
        //    {
        //        if (column.ColumnName.Equals(columnName))
        //            value = dt.Rows[0][column].ToString();
        //    }

        //    ScenarioContext.Current[variable] = value;
        //}

        //[When(@"I extract the password from the Email table in the database as ""(.*)""")]
        //public void WhenIExtractThePasswordFromTheEmailTableInTheDatabaseAs(string variable)
        //{
        //    WhenIRunThisQueryAndRecordTheColumnAs("Body", variable, "SELECT top 1 Body FROM dbo.Email WHERE Subject = 'DVA Customer Portal - Welcome (2 of 2)' ORDER BY Id DESC");
        //    string password = Strings.GetMatchFromString(ScenarioContext.Current.Get<String>(variable), "<td><b>Password: </b>(.*)</td>");
        //    ScenarioContext.Current[variable] = password;

        //}

        //[When(@"I extract the Confirm Email URL from the Email table in the database as ""(.*)""")]
        //public void WhenIExtractTheConfirmEmailURLFromTheEmailTableInTheDatabaseAs(string variable)
        //{
        //    WhenIRunThisQueryAndRecordTheColumnAs("Body", variable, "SELECT top 1 Body FROM dbo.Email WHERE Subject = 'DVA Customer Portal - Welcome (1 of 2)' ORDER BY Id DESC");
        //    string confirmURL = Strings.GetMatchFromString(ScenarioContext.Current.Get<String>(variable), "<a href=\"(.*)\" target=\"_blank\">Confirm Email Address</a>");
        //    ScenarioContext.Current[variable] = confirmURL;

        //}

        //[Then(@"the following record is logged to the ""(.*)"" table:")]
        //public void ThenTheFollowingRecordIsLoggedToTheTable(string tableName, Table table)
        //{
        //    List<string> fields = new List<string>();
        //    List<string> values = new List<string>();
        //    foreach (var tableRow in table.Rows)
        //    {
        //        fields.Add(tableRow["Field"]);
        //        values.Add(tableRow["Value"]);
        //    }

        //    int i = 0;
        //    foreach (string field in fields)
        //    {
        //        WhenIRunThisQueryAndRecordTheColumnAs(field, field, "SELECT TOP (1) " + field + " FROM dbo." + tableName + " ORDER BY Id DESC");
        //        if (!ScenarioContext.Current.Get<String>(field).Contains(values[i]))
        //            throw new Exception("Record for " + field + " is not logged to the table. It was " + ScenarioContext.Current.Get<String>(field));
        //        i++;
        //    }
        //}

        //[Then(@"an email with subject of ""(.*)"" is addressed to ""(.*)""")]
        //public void ThenAnEmailWithSubjectOfIsAddressedTo(string subject, string email)
        //{
        //    subject = subject.ReplaceDynamicValues();
        //    email = email.ReplaceDynamicValues();
        //    WhenIRunThisQueryAndRecordTheColumnAs("Body", "email", "SELECT TOP (1) Body FROM dbo.Email WHERE [To] = '" + email + "' AND Subject = '" + subject + "' ORDER BY Id DESC");
        //}


        //[Then(@"an email with subject of ""(.*)"" addressed to ""(.*)"" contains the following test centre:")]
        //public void ThenAnEmailWithSubjectOfAddressedToContainsTheFollowing(string subject, string email, string testCentre)
        //{
        //    subject = subject.ReplaceDynamicValues();
        //    email = email.ReplaceDynamicValues();
        //    testCentre = testCentre.ReplaceDynamicValues();
        //    WhenIRunThisQueryAndRecordTheColumnAs("Body", "BodyFieldContent", "SELECT top 1 Body FROM dbo.Email WHERE [To] = '" + email + "' AND Subject = '" + subject + "' ORDER BY Id DESC");
        //    string emailTestCentre = Strings.GetMatchFromString(ScenarioContext.Current.Get<String>("BodyFieldContent"), "appointment at (.*) (Mon|Tues|Wednes|Thurs|Fri|Satur|Sun)day");
        //    Assert.AreEqual(testCentre, emailTestCentre);
        //}

        //[Then(@"an email with subject of ""(.*)"" addressed to ""(.*)"" contains the following text:")]
        //public void ThenAnEmailWithSubjectOfAddressedToContainsTheFollowingText(string subject, string email, string text)
        //{
        //    subject = subject.ReplaceDynamicValues();
        //    email = email.ReplaceDynamicValues();
        //    text = text.ReplaceDynamicValues();
        //    WhenIRunThisQueryAndRecordTheColumnAs("Body", "BodyFieldContent", "SELECT top 1 Body FROM dbo.Email WHERE [To] = '" + email + "' AND Subject = '" + subject + "' ORDER BY Id DESC");
        //    if (!ScenarioContext.Current.Get<String>("BodyFieldContent").Contains(text))
        //        throw new Exception("Email with subject " + subject + " to " + email + " should have contained " + text + " but did not.");
        //}

        //[Then(@"an email with reference ""(.*)"" with subject of ""(.*)"" addressed to ""(.*)"" contains the following text:")]
        //public void ThenAnEmailWithSubjectOfAddressedToWithReferenceAndContainsTheFollowingText(string reference, string subject, string email, string text)
        //{
        //    subject = subject.ReplaceDynamicValues();
        //    email = email.ReplaceDynamicValues();
        //    text = text.ReplaceDynamicValues();
        //    reference = reference.ReplaceDynamicValues();
        //    WhenIRunThisQueryAndRecordTheColumnAs("Body", "BodyFieldContent", "SELECT top 1 Body FROM dbo.Email WHERE [To] = '" + email + "' AND Subject = '" + subject + "' AND Reference = '" + reference + "' ORDER BY Id DESC");
        //    if (!ScenarioContext.Current.Get<String>("BodyFieldContent").Contains(text))
        //        throw new Exception("Email with subject " + subject + " to " + email + " and reference " + reference + " should have contained " + text + " but did not.");
        //}

        //[Then(@"an email with subject of ""(.*)"" addressed to ""(.*)"" is not sent")]
        //public void ThenAnEmailWithSubjectOfAddressedToIsNotSent(string subject, string email)
        //{
        //    subject = subject.ReplaceDynamicValues();
        //    email = email.ReplaceDynamicValues();
        //    string queryString = "SELECT COUNT (*) FROM dbo.Email WHERE [To] = '" + email + "' AND Subject = '" + subject + "'";
        //    var emailCount = DatabaseHelper.RunSQLCountQuery(queryString);
        //    if (emailCount > 0)
        //    {
        //        throw new Exception("Email was sent");
        //    }
        //}

        //[Then(@"I confirm no ""(.*)"" sms sent for booking reference ""(.*)""")]
        //[Then(@"an SMS is not sent for ""(.*)"" booking reference ""(.*)""")]
        //public void ThenIConfirmNoSmsSentForBookingReference(string appointmentType, string bookingRef)
        //{
        //    bookingRef = bookingRef.ReplaceDynamicValues();
        //    string driverQueryString = @"SELECT COUNT(*)
        //        FROM [dbo].[DriverAppointments] da 
        //        JOIN [dbo].[DriverAppointmentSms] das on da.id = das.DriverAppointmentId 
        //        JOIN [dbo].[SmsCommunication] sc on sc.Id = das.SmsCommunicationId 
        //        where BookingReference = '" + bookingRef + "'";

        //    string vehicleQueryString = @"SELECT COUNT(*) 
        //        FROM [dbo].VehicleAppointments va 
        //        JOIN [dbo].[VehicleAppointmentSms] vas on va.id = vas.VehicleAppointmentId 
        //        JOIN [dbo].[SmsCommunication] sc on sc.Id = vas.SmsCommunicationId 
        //        where BookingReference = '" + bookingRef + "'";

        //    string queryString = "";
        //    if (appointmentType.ToLower().Equals("driver"))
        //        queryString = driverQueryString;
        //    if (appointmentType.ToLower().Equals("vehicle"))
        //        queryString = vehicleQueryString;

        //    int smsCount = DatabaseHelper.RunSQLCountQuery(queryString);
        //    if (smsCount > 0)
        //        throw new Exception("SMS was sent for reference " + bookingRef);
        //}

        //[Then(@"an SMS is not sent to ""(.*)""")]
        //public void ThenAnSMSIsNotSentTo(string number)
        //{
        //    int smsCount = DatabaseHelper.RunSQLCountQuery("SELECT COUNT(*) AS CountOfSMS FROM dbo.SmsCommunication WHERE MobileNumber = '" + number + "' AND DateSent >= '" + DateTime.Today.AddMinutes(-2).ToString("yyyy-MM-dd HH:mm:ss") + "'");
        //    if (smsCount > 0)
        //        throw new Exception("An SMS was sent to " + number + " in the past 2 minutes.");
        //}

        [Then(@"customer ""([^""]*)"" is assigned to store ""([^""]*)""")]
        public void ThenCustomerIsAssignedToStore(string custId, string storeId)
        {
            int recordCount = DatabaseHelper.RunSQLCountQuery("SELECT COUNT(*) AS CountofRecord FROM Sales.Customer WHERE CustomerID = '" + custId + "' AND StoreID >= '" + storeId + "'");
            Console.WriteLine(recordCount);
            Assert.That(recordCount, Is.EqualTo(1), $"Customer {custId} is not assigned to store {storeId}");

        }

        [Then(@"there are ""([^""]*)"" records for store ""([^""]*)""")]
        public void ThenThereAreRecordsForStore(int records, string storeId)
        {
            int count = DatabaseHelper.RunSQLCountQuery($"SELECT COUNT(*) AS RecordCount FROM Sales.Customer WHERE StoreID = {storeId}");
            Console.WriteLine(count);
            Assert.That(count, Is.EqualTo(records), $"Records for store {storeId} equal {count} and not {records}");
            
        }

        [Then(@"the ""([^""]*)"" department has a Group Name of ""([^""]*)""")]
        public void ThenTheDepartmentHasAGroupNameOf(string deptName, string grpName)
        {
            int count = DatabaseHelper.RunSQLCountQuery($"SELECT COUNT(*) AS RecordCount FROM HumanResources.Department WHERE Name = '{deptName}' AND GroupName = '{grpName}'");
            Console.WriteLine(count);
            Assert.That(count, Is.EqualTo(1), $"There is no record to show {deptName} under the group name of {grpName}");
        }





        //[Then(@"I confirm that only (.*) email with subject of ""(.*)"" addressed to ""(.*)"" was sent")]
        //public void ThenIConfirmThatOnlyEmailWithSubjectOfAddressedToWasSent(int emailNumber, string subject, string email)
        //{
        //    subject = subject.ReplaceDynamicValues();
        //    email = email.ReplaceDynamicValues();
        //    string queryString = "SELECT COUNT (*) FROM dbo.Email WHERE [To] = '" + email + "' AND Subject = '" + subject + "'";
        //    var emailCount = DatabaseHelper.RunSQLCountQuery(queryString);
        //    if (emailCount > emailNumber)
        //    {
        //        throw new Exception(emailCount + "emails were sent when " + emailNumber + " should have been sent");
        //    }
        //}

        //[Then(@"an SMS is sent to ""(.*)"" for ""(.*)"" booking reference ""(.*)""")]
        //public void ThenAnSMSIsSentToForBookingReference(string number, string appointmentType, string bookingRef)
        //{
        //    number = number.ReplaceDynamicValues();
        //    bookingRef = bookingRef.ReplaceDynamicValues();
        //    string driverQueryString = @"SELECT COUNT(*)
        //        FROM [dbo].[DriverAppointments] da 
        //        JOIN [dbo].[DriverAppointmentSms] das on da.id = das.DriverAppointmentId 
        //        JOIN [dbo].[SmsCommunication] sc on sc.Id = das.SmsCommunicationId 
        //        where BookingReference = '" + bookingRef + "' and mobilenumber = '" + number + "'";

        //    string vehicleQueryString = @"SELECT COUNT(*) 
        //        FROM [dbo].VehicleAppointments va 
        //        JOIN [dbo].[VehicleAppointmentSms] vas on va.id = vas.VehicleAppointmentId 
        //        JOIN [dbo].[SmsCommunication] sc on sc.Id = vas.SmsCommunicationId 
        //        where BookingReference = '" + bookingRef + "' and mobilenumber = '" + number + "'";


        //    string stateDriverQueryString = @"SELECT StateId
        //        FROM [dbo].[DriverAppointments] da 
        //        JOIN [dbo].[DriverAppointmentSms] das on da.id = das.DriverAppointmentId 
        //        JOIN [dbo].[SmsCommunication] sc on sc.Id = das.SmsCommunicationId 
        //        where BookingReference = '" + bookingRef + "' and mobilenumber = '" + number + "'";

        //    string stateVehicleQueryString = @"SELECT StateId 
        //        FROM [dbo].VehicleAppointments va 
        //        JOIN [dbo].[VehicleAppointmentSms] vas on va.id = vas.VehicleAppointmentId 
        //        JOIN [dbo].[SmsCommunication] sc on sc.Id = vas.SmsCommunicationId 
        //        where BookingReference = '" + bookingRef + "' and mobilenumber = '" + number + "'";

        //    string queryString = "";
        //    string stateQueryString = "";
        //    if (appointmentType.ToLower().Equals("driver"))
        //    {
        //        queryString = driverQueryString;
        //        stateQueryString = stateDriverQueryString;
        //    }
        //    if (appointmentType.ToLower().Equals("vehicle"))
        //    {
        //        queryString = vehicleQueryString;
        //        stateQueryString = stateVehicleQueryString;
        //    }

        //    int smsCount = DatabaseHelper.RunSQLCountQuery(queryString);
        //    if (smsCount == 0)
        //        throw new Exception("No SMS was sent to " + number + " for reference " + bookingRef);

        //    WhenIRunThisQueryAndRecordTheColumnAs("StateId", "StateId", stateQueryString);
        //    string stateId = ScenarioContext.Current.Get<String>("StateId");
        //    if (!stateId.Equals("2"))
        //        throw new Exception("SMS sent should have a StateId of 2 (sent) but actual StateId was " + stateId);

        //}


        //[Then(@"an sms is sent for booking reference ""(.*)""")]
        //public void ThenAnSmsIsSentForBookingReference(string bookingRef)
        //{
        //    bookingRef = bookingRef.ReplaceDynamicValues();
        //    WhenIRunThisQueryAndRecordTheColumnAs("Id", "appointmentId", "SELECT TOP 1 Id FROM dbo.VehicleAppointments WHERE BookingReference = '" + bookingRef + "'");
        //    string appointmentId = ScenarioContext.Current.Get<String>("appointmentId");
        //    string queryString = "SELECT COUNT (*) FROM dbo.VehicleAppointmentSms WHERE VehicleAppointmentId = '" + appointmentId + "'";
        //    int smsCount = DatabaseHelper.RunSQLCountQuery(queryString);
        //    if (smsCount < 1)
        //    {
        //        throw new Exception("SMS was not sent");
        //    }
        //    WhenIRunThisQueryAndRecordTheColumnAs("SmsCommunicationId", "smsId", "SELECT TOP 1 SmsCommunicationId FROM dbo.VehicleAppointmentSms WHERE VehicleAppointmentId = '" + appointmentId + "'");
        //    string smsId = ScenarioContext.Current.Get<String>("smsId");
        //    WhenIRunThisQueryAndRecordTheColumnAs("StateId", "smsStateId", "SELECT TOP 1 StateId FROM dbo.SmsCommunication WHERE Id = '" + smsId + "'");
        //    string smsStateId = ScenarioContext.Current.Get<String>("smsStateId");
        //    if (smsStateId != "2")
        //    {
        //        throw new Exception("SMS should have stateId of 2 but actual stateId was'" + smsStateId + "'");
        //    }
        //}


        //[Then(@"I confirm that only (.*) sms was sent for booking reference ""(.*)""")]
        //public void ThenIConfirmThatOnlySmsWasSentForBookingReference(int smsNumber, string bookingRef)
        //{
        //    bookingRef = bookingRef.ReplaceDynamicValues();
        //    WhenIRunThisQueryAndRecordTheColumnAs("Id", "appointmentId", "SELECT TOP 1 Id FROM dbo.VehicleAppointments WHERE BookingReference = '" + bookingRef + "'");
        //    string appointmentId = ScenarioContext.Current.Get<String>("appointmentId");
        //    string queryString = "SELECT COUNT (*) FROM dbo.VehicleAppointmentSms WHERE VehicleAppointmentId = '" + appointmentId + "'";
        //    int smsCount = DatabaseHelper.RunSQLCountQuery(queryString);
        //    if (smsCount > smsNumber)
        //    {
        //        throw new Exception(smsCount + "SMSs were sent when " + smsNumber + " should have been sent");
        //    }
        //}

        //[Then(@"one refund for the booking reference of ""(.*)"" is processed successfully")]
        //public void ThenOneRefundForTheBookingReferenceOfIsProcessedSuccessfully(string bookingRef)
        //{
        //    bookingRef = bookingRef.ReplaceDynamicValues();
        //    int refundCount = 0;
        //    for (int i = 0; i < Settings.Default.DelayCycles; i++)
        //    {
        //        String queryString = "SELECT COUNT (*) FROM dbo.Payments WHERE PaymentType = '2' AND BookingReference = '" + bookingRef + "'";
        //        refundCount = DatabaseHelper.RunSQLCountQuery(queryString);

        //        if (refundCount > 0) break;
        //        Thread.Sleep(Settings.Default.Delays);
        //    }
        //    if (refundCount == 0)
        //        throw new Exception("Refund was not processed");
        //    if (refundCount > 1)
        //        throw new Exception("Refund was processed " + refundCount + " times");
        //}

        //[Then(@"there is no refund processed for the booking reference of ""(.*)""")]
        //public void ThenThereIsNoRefundProcessedForTheBookingReferenceOf(string bookingRef)
        //{
        //    bookingRef = bookingRef.ReplaceDynamicValues();
        //    string queryString = "SELECT COUNT (*) FROM dbo.Payments WHERE PaymentType = '2' AND BookingReference = '" + bookingRef + "'";
        //    var refundCount = DatabaseHelper.RunSQLCountQuery(queryString);
        //    if (refundCount > 0)
        //    {
        //        throw new Exception($"Refund was processed {refundCount} times");
        //    }
        //}
    }
}
