angular.module('otherApp')
.factory('ScheduleService', ['$http', 'PostDataService', 'RequestService', function ($http, PostDataService, RequestService) {
    return function (dbRequestNumber, param, success, failed) {
        var temp;
        switch (Number(dbRequestNumber)) {
            /*Get*/

            /*Post*/
            case 3:
                //inserting new record in UserBreakTime database
                var temp3 = PostDataService('Schedule/Insert', param)
                    .success(function (data, status, headers, config) {
                        success(data);
                    }).error(function (data, status, headers, config) {
                        failed(data);
                    });
                break;
            case 4:
                //inserting new record in UserBreakTime database
                var temp3 = PostDataService('Schedule/Update', param)
                    .success(function (data, status, headers, config) {
                        success(data);
                    }).error(function (data, status, headers, config) {
                        failed(data);
                    });
                break;
        }
    }
}]);