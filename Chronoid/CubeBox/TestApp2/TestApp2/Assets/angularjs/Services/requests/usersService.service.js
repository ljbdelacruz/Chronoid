angular.module('otherApp')
.factory('UsersRequestService', ['$http', 'PostDataService', 'RequestService', function ($http, PostDataService, RequestService) {
    return function (dbRequestNumber, param, success, failed) {
        var temp;
        console.log(dbRequestNumber);
        switch (Number(dbRequestNumber)) {
            /*Get*/
            case 7:
                temp = RequestService('Users/GetAll', param)
                 .success(function (data, status, headers, config) {
                     success(data);
                 }).error(function (data, status, headers, config) {
                     failed(data);
                 });
                break;
            case 1:
                //gets the current user break times
                temp = RequestService('Users/GetAllByCompanyID', param)
                    .success(function (data, status, headers, config) {
                        success(data);
                    }).error(function (data, status, headers, config) {
                        failed(data);
                    });
                break;
            case 4:
                //gets the current information of user login
                temp = RequestService('Users/GetUserInformation', param)
                .success(function (data, status, headers, config) {
                    success(data);
                }).error(function (data, status, headers, config) {
                    failed(data);
                });
                break;
                /*Post*/
            case 2:
                temp = PostDataService('Users/Insert', param)
                    .success(function (data, status, headers, config) {
                        success(data);
                    }).error(function (data, status, headers, config) {
                        failed(data);
                    });
                break;
            case 3:
                //update user information
                temp = PostDataService('Users/Update', param)
                .success(function (data, status, headers, config) {
                    success(data);
                }).error(function (data, status, headers, config) {
                    failed(data);
                });
                break;
            case 5:
                //change user creds 
                var temp = PostDataService('Users/UpdateCredentials', param)
                .success(function (data, status, headers, config) {
                    success(data);
                }).error(function (data, status, headers, config) {
                    failed(data);
                });
                break;
            case 6:
                //archive user
                var temp = PostDataService('Users/Archive', param)
                .success(function (data, status, headers, config) {
                    success(data);
                }).error(function (data, status, headers, config) {
                    failed(data);
                });
                break;
        }
    }


}]);