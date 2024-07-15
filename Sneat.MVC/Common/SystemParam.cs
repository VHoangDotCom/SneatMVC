using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sneat.MVC.Common
{
    public class SystemParam
    {
        #region Datetime param
        public const string CONVERT_DATETIME = "dd/MM/yyyy";
        public const string CONVERT_DATETIME_HAVE_HOUR = "yyyy-MM-dd HH:mm";
        public const string CONVERT_DATETIME_HOUR = "HH:mm";
        public const string CONVERT_DATETIME_EXCEL = "dd_MM_yyyy";
        #endregion

        #region Common status param
        public const int ACTIVE = 1;
        public const int IN_ACTIVE = 0;
        public const int IS_DELETED = 1;
        public const int IS_NOT_DELETED = 0;
        #endregion

        #region Paging
        public const int PAGE_DEFAULT = 1;
        public const int MAX_ROW_IN_LIST_WEB = 20;
        #endregion

        #region Returned data status
        public const int SUCCESS = 1;
        public const int FAILED = -1;
        public const int ERROR = 0;
        public const int RETURN_TRUE = 1;
        public const int RETURN_FALSE = 0;
        #endregion

        #region Https status 
        public const int SUCCESS_CODE = 200;
        public const string MESSAGE_SUCCESS = "Thành công";
        public const int SERVER_ERROR_CODE = 500;
        public const string SERVER_ERROR = "Hệ thống đang bảo trì";
        public const int TOKEN_INVALID_CODE = 401;
        public const string MESSAGE_TOKEN_INVALID = "Đăng nhập để thực hiện chức năng này";
        public const int PERMISSION_INVALID = 402;
        public const string MESSAGE_PERMISSION_INVALID = "Bạn không có quyền thực hiện chức năng này";
        public const int TOKEN_ERROR = 403;
        public const string MESSAGE_TOKEN_ERROR = "Tài khoản của bạn đã đăng nhập ở nơi khác";
        #endregion

        #region Config System
        public const string SESSION_LOGIN = "Login";
        #endregion

        #region Authentication
        public const int INVALID_EMAIL_OR_PASSWORD_ERR = -1;
        public const int ACCOUNT_HAD_BEEN_BLOCKED_ERR = -2;
        #endregion

        #region User
        public const int EMAIL_USED_ERR = -1;
        public const int PHONE_USED_ERR = -2;
        public const int ACCOUNT_NOT_FOUND_ERR = -3;
        #endregion
    }
}