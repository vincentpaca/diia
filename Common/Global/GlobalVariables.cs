using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EchoSystems.Common.Global
{
    public class GlobalVariables
    {
        public static MySqlConnection goMySqlConnection;

        public static Form goMainMDI;

        public static string goLoggedInUser;

        public static string goFileServer;

        public static string goImageServer;

        public static string goRecycleBin;

        public static string goBackup;

        public static string gPassword;

        public static int gLimit = 10;

        public static string goAppDLL;

        public static Microsoft.Office.Interop.Word.Application goApplication;
        public static Microsoft.Office.Interop.Word.Document goDocument;

        public enum OperationMode
        {
            Add,
            Edit
        }

        public enum ConfigUIMode
        {
            View,
            Edit
        }
    }
}
