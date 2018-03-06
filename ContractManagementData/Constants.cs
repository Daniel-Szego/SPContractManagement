using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ContractManagementData
{
    /// <summary>
    /// Statische Klasse um die verschienden Konstante zu administrieren. 
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Name der StartImport_ByProfile Stored Procedure
        /// </summary>
        public static string StartImport_SalesActualProcName = "StartImport_ByProfile";

        /// <summary>
        /// Input Parameter der StartImport_ByProfile Stored Procedure
        /// </summary>
        public static string StartImport_SalesActualParName = "@importProfile";
    }
}
