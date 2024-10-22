using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        #region Blog Messages
        public static string BlogIsAdded = "Blog is added";
        public static string BlogIsRemoved = "Blog is removed";
        public static string BlogIsUpdated = "Blog is updated";
        public static string BlogIsListed = "Blog is listed";
        public static string BlogsAreListed = "Blogs are added";
        #endregion

        #region Login Messages
        public static string loginSuccessful = "Login is successful";
        public static string accessTokenCreated = "Access token is created";
        public static string authorizationDenied = "Authorization is denied";
        #endregion

        #region User Messages
        public static string userDidNotFound = "User did not found";
        public static string userIsRegistered = "User has been registered";
        public static string userExists = "This user already exists";
        public static string userIsAdded = "User has been added";
        #endregion
    }
}
