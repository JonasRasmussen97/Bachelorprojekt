using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCareBackend.Helpers
{
    public class Globals
    {
        // GLOBAL OBJECTS.
        public static AuthHelper auth = new AuthHelper();

        // STATUS MESSAGES
        public static string GlobalInvalidType = "You are not allowed!";
        public static string GlobalValidType = "Success!";
        public static string GlobalInvalidCredentials = "Wrong username or password. Try again!";
        public static string GlobalValidCrendetials = "You have been logged in!";

        // USER NAMING
        public static string GlobalInterCareAdmin = "InterCare Admin";
        public static string GlobalOrganizationAdmin = "Organization Admin";
        public static string GlobalLocationManager = "Location Manager";
        public static string GlobalClient = "Client";
        
        // 
    }
}
