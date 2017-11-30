angular.module('otherApp')
.factory('HolidayService', ['$http', 'PostDataService', 'RequestService', function ($http, PostDataService, RequestService) {
    return function (dbRequestNumber, param, success, failed) {
        switch (Number(dbRequestNumber)) {
            /*Get*/
            case 1:
                //get the user break available for this user
                var temp = RequestService('Holiday/GetAllByCompany', param)
                .success(function (data, status, headers, config) {
                    success(data);
                }).error(function (data, status, headers, config) {
                    failed(result);
                });
                break;
                /*Post*/
            case 2:
                var temp3 = PostDataService('Holiday/Insert', param)
                .success(function (data, status, headers, config) {
                    success(data);
                }).error(function (data, status, headers, config) {
                    failed(data);
                });
                break;
            case 3:
                var temp3 = PostDataService('Holiday/Update', param)
                .success(function (data, status, headers, config) {
                    success(data);
                }).error(function (data, status, headers, config) {
                    failed(data);
                });
                break;
        }
    }
}]);