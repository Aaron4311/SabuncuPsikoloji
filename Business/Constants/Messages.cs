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

        #region Service Messages
        public static string serviceIsAdded = "Service is Added";
        public static string serviceIsDeleted = "Service is Deleted";
        public static string servicesAreListed = "Services are Listed";
        public static string serviceIsListed = "Service is Listed";
        public static string serviceIsUpdated = "Service is Updated";
        #endregion

        #region Message Messages
        public static string messageIsAdded = "Message is Added";
        public static string messageIsDeleted = "Service is Deleted";
        public static string messagesAreListed = "Services are Listed";
        public static string messageIsListed = "Service is Listed";
        public static string messageIsUpdated = "Service is Updated";
        #endregion

        #region Psychologist Messages
        public static string psychologistIsAdded = "Psychologist is Added";
        public static string psychologistIsDeleted = "Psychologist is Deleted";
        public static string psychologistsAreListed = "Psychologists are Listed";
        public static string psychologistIsListed = "Psychologist is Listed";
        public static string psychologistIsUpdated = "Psychologist is Updated";
        #endregion

        #region Slider Content Messages
        public static string sliderIsUpdated = "Slider is Updated";
        public static string sliderIsListed = "Slider is Listed";
        public static string slidersAreListed = "Sliders are Listed";
        public static string sliderIsDeleted = "Slider is deleted";
        public static string sliderIsAdded = "Slider is Added";
        #endregion
    }
}
