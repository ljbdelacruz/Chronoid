angular.module('otherApp')
.factory('UsersInfoRequestService', ['$http', 'PostDataService', 'RequestService', function ($http, PostDataService, RequestService) {
    return function (dbRequestNumber, param, successEvent) {
        var temp;
        switch (Number(dbRequestNumber)) {
            /*Get*/
            case 1:
                //gets the current user break times
                temp = RequestService('UserBreakTime/GetBreaksToday', param)
                    .success(function (data, status, headers, config) {
                        successEvent(data);
                    }).error(function (data, status, headers, config) {
                        console.log(data);
                    });
                break;
            case 2:
                //gets the current user time in
                temp = RequestService('Attendance/GetTimeInToday', param)
                    .success(function (data, status, headers, config) {
                        successEvent(data);
                    }).error(function (data, status, headers, config) {
                        console.log(data);
                    });
                break;
            case 3:
                //checks if the user is on break
                temp = RequestService('UserBreakTime/IsUserOnBreak', param)
                    .success(function (data, status, headers, config) {
                        successEvent(data);
                    }).error(function (data, status, headers, config) {
                        console.log(data);
                    });
                break;
            case 4:
                temp = RequestService('Users/GetCurrentUser', param)
                    .success(function (data, status, headers, config) {
                        successEvent(data);
                    }).error(function (data, status, headers, config) {
                        console.log(data);
                    });
                break;
            /*Post*/
        }    
    }

 }]);