angular.module('otherApp')
.factory('AddOnService', ['$http', 'PostDataService', 'RequestService', function ($http, PostDataService, RequestService) {
    return function (dbRequestNumber, param, success, failed) {
        var temp;
        switch (Number(dbRequestNumber)) {
            /*Get*/
            case 1:
                //get the user break available for this user
                temp = RequestService('AddOn/GetAllByCompany', param)
                .success(function (data, status, headers, config) {
                    success(data);
                }).error(function (data, status, headers, config) {
                    failed(result);
                });
                break;
                /*Post*/
        }
    }
}]);