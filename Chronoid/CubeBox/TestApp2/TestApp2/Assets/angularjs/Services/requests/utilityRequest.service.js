angular.module('otherApp')
.factory('UtilityRequestService', ['$http', 'PostDataService', 'RequestService', function ($http, PostDataService, RequestService) {
    return function (dbRequestNumber, param, successEvent) {
        var temp;
        switch (Number(dbRequestNumber)) {
            /*Get*/
            case 1:
                temp = RequestService('Utility/GetServerTime', param)
                    .success(function (data, status, headers, config) {
                        successEvent(data);
                    }).error(function (data, status, headers, config) {
                        console.log(data);
                    });
                break;
            case 2:
                break;
            /*Post*/
        }

        
    }

    
 }]);