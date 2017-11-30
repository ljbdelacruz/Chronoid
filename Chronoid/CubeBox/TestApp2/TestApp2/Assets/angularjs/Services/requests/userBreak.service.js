angular.module('otherApp')
.factory('UserBreakService', ['$http', 'PostDataService', 'RequestService', function ($http, PostDataService, RequestService) {
    return function (dbRequestNumber, param, successEvent) {
        var temp;
        switch (Number(dbRequestNumber)) {
            /*Get*/
            case 1:
                //get the user break available for this user
                temp = RequestService('UserBreakTime/GetUserBreaksAvailable', param)
                .success(function (data, status, headers, config) {
                    successEvent(data);
                }).error(function (data, status, headers, config) {
                    console.log(data);
                });
                break;
            case 2:
                break;
                /*Post*/
            case 3:
                //inserting new record in UserBreakTime database
                var temp3 = PostDataService('UserBreakTime/Insert', param)
                    .success(function (data, status, headers, config) {
                        successEvent(data);
                    }).error(function (data, status, headers, config) {
                        window.alert("Error " + status);
                    });
                break;
            case 4:
                //end user break time
                var temp3 = PostDataService('UserBreakTime/EndBreak', param)
                .success(function (data, status, headers, config) {
                    successEvent(data);
                }).error(function (data, status, headers, config) {
                    window.alert("Error " + status);
                });
                break;
        }
    }
}]);