angular.module('otherApp')
.factory('BreakTypeService', ['$http', 'PostDataService', 'RequestService', function ($http, PostDataService, RequestService) {
    return function (dbRequestNumber, param, success, failed) {
        var temp;
        switch (Number(dbRequestNumber)) {
            /*Get*/
            case 1:
                //gets the current user break times
                temp = RequestService('BreakType/GetAllByCompany', param)
                    .success(function (data, status, headers, config) {
                        success(data);
                    }).error(function (data, status, headers, config) {
                        failed(data);
                    });
                break;
                /*Post*/
            case 2:
                var temp3 = PostDataService('BreakType/Update', param)
                .success(function (data, status, headers, config) {
                    success(data);
                }).error(function (data, status, headers, config) {
                    failed(data);
                });
                break;
            case 3:
                var temp3 = PostDataService('BreakType/Archive', param)
                .success(function (data, status, headers, config) {
                    success(data);
                }).error(function (data, status, headers, config) {
                    failed(data);
                });
                break;
            case 4:
                var temp3 = PostDataService('BreakType/Insert', param)
                .success(function (data, status, headers, config) {
                    success(data);
                }).error(function (data, status, headers, config) {
                    failed(data);
                });
                break;
        }
    }
}]);