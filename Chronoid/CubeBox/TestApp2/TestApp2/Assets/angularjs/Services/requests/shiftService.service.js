angular.module('otherApp')
.factory('ShiftService', ['$http', 'PostDataService', 'RequestService', function ($http, PostDataService, RequestService) {
    return function (dbRequestNumber, param, success, failed) {
        var temp;
        switch (Number(dbRequestNumber)) {
            /*Get*/
            case 1:
                //get the user break available for this user
                temp = RequestService('Shift/GetAllByCompany', param)
                .success(function (data, status, headers, config) {
                    success(data);
                }).error(function (data, status, headers, config) {
                    failed(result);
                });
                break;
                /*Post*/
            case 2:
                //insert new shift
                var temp3 = PostDataService('Shift/Insert', param)
                    .success(function (data, status, headers, config) {
                        success(data);
                    }).error(function (data, status, headers, config) {
                        failed(data);
                    });
                break;
            case 3:
                //insert new shift
                var temp3 = PostDataService('Shift/Update', param)
                    .success(function (data, status, headers, config) {
                        success(data);
                    }).error(function (data, status, headers, config) {
                        failed(data);
                    });
                break;
            case 4:
                //remove shift
                var temp3 = PostDataService('Shift/Archived', param)
                    .success(function (data, status, headers, config) {
                        success(data);
                    }).error(function (data, status, headers, config) {
                        failed(data);
                    });
                break;
        }
    }
}]);