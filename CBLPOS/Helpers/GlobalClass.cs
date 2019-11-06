using System;
namespace CBLPOS.Helpers
{
    static class GlobalClass
    {
        public static string _Employee = "";
        public static string myGlobalEmployee
        {
            get
            {
                return _Employee;
            }
            set
            {
                _Employee = value;
            }
        }


        public static string _Employeename = "";
        public static string myGlobalEmployeename
        {
            get
            {
                return _Employeename;
            }
            set
            {
                _Employeename = value;
            }
        }



        public static string _Customer = "";
        public static string myGlobalCustomer
        {
            get
            {
                return _Customer;
            }
            set
            {
                _Customer = value;
            }
        }


        public static string _Customername = "";
        public static string myGlobalCustomername
        {
            get
            {
                return _Customername;
            }
            set
            {
                _Customername = value;
            }
        }


        public static string _Isession = "";
        public static string myGlobalIsession
        {
            get
            {
                return _Isession;
            }
            set
            {
                _Isession = value;
            }
        }


        public static int _clicks = 0;
        public static int myGlobalClick
        {
            get
            {
                return _clicks;
            }
            set
            {
                _clicks = value;
            }
        }
    }



}
