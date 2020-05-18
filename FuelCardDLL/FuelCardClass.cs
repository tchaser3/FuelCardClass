/* Title:           Fuel Card Class
 * Date:            5-18-20
 * Author:          Terry Holmes
 * 
 * Descripion:      This is used to great for the fuel */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace FuelCardDLL
{
    public class FuelCardClass
    {
        //setting up the clases
        EventLogClass TheEventLogClass = new EventLogClass();

        FuelCardAssignmentDataSet aFuelCardAssignmentDataSet;
        FuelCardAssignmentDataSetTableAdapters.fuelcardassignmentTableAdapter aFuelCardAssignmentTableAdapter;

        InsertFuelCardEntryTableAdapters.QueriesTableAdapter aInsertFuelCardTableAdapter;

        UpdateFuelCardActiveEntryTableAdapters.QueriesTableAdapter aUpdateFuelCardActiveTableAdapter;

        FindActiveFuelCardNumbersDataSet aFindActiveFuelCardNumbersDataSet;
        FindActiveFuelCardNumbersDataSetTableAdapters.FindActiveFuelCardNumberTableAdapter aFindActiveFuelCardNumbersTableAdapter;

        FindFuelCardEmployeeDataSet aFindFuelCardEmployeeDataSet;
        FindFuelCardEmployeeDataSetTableAdapters.FindFuelCardEmployeeTableAdapter aFindFuelCardEmployeeTableAdapter;

        FindEmployeeActiveFuelCardNumberDataSet aFindEmployeeActiveFuelCardNumberDataSet;
        FindEmployeeActiveFuelCardNumberDataSetTableAdapters.FindEmployeeActiveFuelCardNumberTableAdapter aFindEmployeeActiveFuelCardNumberTableAdapter;

        public FindEmployeeActiveFuelCardNumberDataSet FindEmployeeActiveFuelCardNumber(int intEmployeeID)
        {
            try
            {
                aFindEmployeeActiveFuelCardNumberDataSet = new FindEmployeeActiveFuelCardNumberDataSet();
                aFindEmployeeActiveFuelCardNumberTableAdapter = new FindEmployeeActiveFuelCardNumberDataSetTableAdapters.FindEmployeeActiveFuelCardNumberTableAdapter();
                aFindEmployeeActiveFuelCardNumberTableAdapter.Fill(aFindEmployeeActiveFuelCardNumberDataSet.FindEmployeeActiveFuelCardNumber, intEmployeeID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Fuel Card Class // Find Employee Active Fuel Card Number " + Ex.Message);
            }

            return aFindEmployeeActiveFuelCardNumberDataSet;
        }
        public FindFuelCardEmployeeDataSet FindFuelCardEmployee(int intFuelCardNumber)
        {
            try
            {
                aFindFuelCardEmployeeDataSet = new FindFuelCardEmployeeDataSet();
                aFindFuelCardEmployeeTableAdapter = new FindFuelCardEmployeeDataSetTableAdapters.FindFuelCardEmployeeTableAdapter();
                aFindFuelCardEmployeeTableAdapter.Fill(aFindFuelCardEmployeeDataSet.FindFuelCardEmployee, intFuelCardNumber);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Fuel Card Class // Find Fuel Card Employee " + Ex.Message);
            }

            return aFindFuelCardEmployeeDataSet;
        }
        public FindActiveFuelCardNumbersDataSet FindActiveFuelCardNumbers()
        {
            try
            {
                aFindActiveFuelCardNumbersDataSet = new FindActiveFuelCardNumbersDataSet();
                aFindActiveFuelCardNumbersTableAdapter = new FindActiveFuelCardNumbersDataSetTableAdapters.FindActiveFuelCardNumberTableAdapter();
                aFindActiveFuelCardNumbersTableAdapter.Fill(aFindActiveFuelCardNumbersDataSet.FindActiveFuelCardNumber);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Fuel Card Class // Find Active Fuel Card Numbers " + Ex.Message);
            }

            return aFindActiveFuelCardNumbersDataSet;
        }
        public bool UpdateFuelCardActive(int intFuelCardNumber, bool blnCodeActive)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateFuelCardActiveTableAdapter = new UpdateFuelCardActiveEntryTableAdapters.QueriesTableAdapter();
                aUpdateFuelCardActiveTableAdapter.UpdateFuelCardActive(intFuelCardNumber, blnCodeActive);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Fuel Card Class // Update Fuel Card Active " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public bool InsertFuelCard(int intEmployeeID, int intFuelCardNumber)
        {
            bool blnFatalError = false;

            try
            {
                aInsertFuelCardTableAdapter = new InsertFuelCardEntryTableAdapters.QueriesTableAdapter();
                aInsertFuelCardTableAdapter.InsertFuelCard(intEmployeeID, DateTime.Now, intFuelCardNumber, true);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Fuel Card Class // Insert Fuel Card " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public FuelCardAssignmentDataSet GetFuelCardAssignmentInfo()
        {
            try
            {
                aFuelCardAssignmentDataSet = new FuelCardAssignmentDataSet();
                aFuelCardAssignmentTableAdapter = new FuelCardAssignmentDataSetTableAdapters.fuelcardassignmentTableAdapter();
                aFuelCardAssignmentTableAdapter.Fill(aFuelCardAssignmentDataSet.fuelcardassignment);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Fuel Card Class // Get Fuel Card Assignment Info " + Ex.Message);
            }

            return aFuelCardAssignmentDataSet;
        }
        public void UpdateFuelCardAssignmentDB(FuelCardAssignmentDataSet aFuelCardAssignmentDataSet)
        {
            try
            {
                aFuelCardAssignmentTableAdapter = new FuelCardAssignmentDataSetTableAdapters.fuelcardassignmentTableAdapter();
                aFuelCardAssignmentTableAdapter.Update(aFuelCardAssignmentDataSet.fuelcardassignment);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Fuel Card Class // Update Fuel Card Assignment DB " + Ex.Message);
            }
        }
    }
}
