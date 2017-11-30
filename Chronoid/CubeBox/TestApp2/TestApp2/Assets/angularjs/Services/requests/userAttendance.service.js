angular.module('otherApp')
.factory('UserAttendanceService', ['$http', 'PostDataService', 'RequestService', function ($http, PostDataService, RequestService) {
    return function (dbRequestNumber, param, success, failed) {
        var temp;
        switch (Number(dbRequestNumber)) {
            /*Get*/
            case 1:
                //get the user break available for this user
                temp = RequestService('Attendance/GetAllUsersTimeInToday', param)
                .success(function (data, status, headers, config) {
                    success(data);
                }).error(function (data, status, headers, config) {
                    failed(result);
                });
                break;
            case 2:
                //this one gets the attendance by user ID and with date from and to filter
                temp = RequestService('Attendance/GetByUserIDDate', param)
                    .success(function (data, status, headers, config) {
                        success(data);
                    }).error(function (data, status, headers, config) {
                        failed(result);
                    });
                break;
            //post request
            case 3:
                //this is for time in user from system
                var temp3 = PostDataService('Attendance/LoginUser', param)
                .success(function (data, status, headers, config) {
                    success(data);
                }).error(function (data, status, headers, config) {
                    failed(data);
                });
            case 4:
                //insert new attendance
                var temp3 = PostDataService('Attendance/Insert', param)
                    .success(function (data, status, headers, config) {
                        success(data);
                    }).error(function (data, status, headers, config) {
                        failed(data);
                    });
                break;
            case 5:
                //insert new attendance
                var temp3 = PostDataService('Attendance/Update', param)
                    .success(function (data, status, headers, config) {
                        success(data);
                    }).error(function (data, status, headers, config) {
                        failed(data);
                    });
                break;
            case 6:
                var temp3 = PostDataService('Attendance/GroupSchedule', param)
                .success(function (data, status, headers, config) {
                    success(data);
                }).error(function (data, status, headers, config) {
                    failed(data);
                });
                break;
            case 7:
                var temp3 = PostDataService('Attendance/GenerateReportCSV', param)
                .success(function (data, status, headers, config) {
                    success(data);
                }).error(function (data, status, headers, config) {
                    failed(data);
                });
                break;
        }
    }
}]);