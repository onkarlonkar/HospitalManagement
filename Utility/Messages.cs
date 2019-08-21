using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Messages
    {
        public static string savedSuccessfully = "Record Saved successfully";
        public static string deletedSuccessfully = "Record Deleted successfully";
        public static string DoYouWantToSave = "Do you want to Save the Changes !";
        public static string DoYouWantDelete = "Do you want to Delete selected Records!";
        public static string DoYouWantToSaveandPrint = "Do you want to Save the Changes and Print Bill !";
        public static string AddPatientToOPDQueue = "Do you want add Patient to OPD Queue ?";
        public static string AddedPatientToOPDQueue = "Patient added to OPD Queue successfully ?";
        public static string alreadyExistsinQueue = "Patient already exists in Queue !";
        public static string printCompleted = "Details Printed successfully";
        public static string reportCompleted = "Copy saved at ";

    }

    public class ErrorMessages
    {
        public static string selectPrintOption = "Please select print option.";
        public static string PleaseenterUserName = "Please enter user name.";
        public static string PleaseenterPassword = "Please enter Password.";
        public static string incorrectuserpassword = "incorrect username or password.";
        public static string FromDateToDate = "From date should be less then To date.";
        public static string PleaseenterName = "Please enter Name.";
        public static string PleaseenterCasePaperNumber = "Please enter Case Paper Number.";
        public static string PleaseenterAge = "Please enter Age.";
        public static string PleaseenterMobileNumber = "Please enter Mobile Number.";
        public static string PleaseenterDiagnose = "Please enter Diagnose.";
        public static string PleaseenterMedicine = "Please enter Medicine.";
        public static string DueAmountShouldBeZero = "To proceed Due Amount should be Zero.";
        public static string pleaseSelectCasepaperIssueDate = "In case of Follow up, Please set Case Paper Issue Date or it will charge as per new Case Paper charges.";

    }
}
