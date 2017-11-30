angular.module('otherApp')
.factory('JobTitleService', ['$http', 'PostDataService', 'RequestService', function ($http, PostDataService, RequestService) {
    return function (dbRequestNumber, param, success, failed) {
        var temp;
        switch (Number(dbRequestNumber)) {
            /*Get*/
            case 1:
                //gets the current user break times
                temp = RequestService('JobTitle/GetAll', param)
                    .success(function (data, status, headers, config) {
                        success(data);
                    }).error(function (data, status, headers, config) {
                        failed(data);
                    });
                break;
                /*Post*/
                //insert new job
            case 2:
                var temp3 = PostDataService('JobTitle/Insert', param)
                    .success(function (data, status, headers, config) {
                        success(data);
                    }).error(function (data, status, headers, config) {
                        failed(data);
                    });
                break;
            case 3:
                var temp3 = PostDataService('JobTitle/Update', param)
                    .success(function (data, status, headers, config) {
                        success(data);
                    }).error(function (data, status, headers, config) {
                        failed(data);
                    });
                break;

        }
    }


}]);