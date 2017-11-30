angular.module('otherApp')
.factory('dbLoginControllerService', ['$http', 'PostDataService', 'RequestService', function ($http, PostDataService, RequestService) {
    /*CHOOSE A REQUEST YOU WANT AND PARAM IS FOR THE PARAMETER OF A API YOU WILL BE ACCESSING AND 
      SUCCESSEVENT IS WHEN THE OPERATION SUCCEED THEN EXECUTE 
      THIS FUNCTION THAT RECEIVE A PARAMETER DATA THAT WAS REQUESTED
    */
    //the success even must always have assigned value since this will be the receiver of the response of the ajax event
    return function (dbRequestNumber, param, successEvent, failedEvent) {
        switch (dbRequestNumber) {
            case 1:
                //request for get all users
                var result = PostDataService("Login/Authenticate", param)
				   .success(function (data, status, headers, config) {
				       if (data.success) {
				           successEvent(data);
				       } else {
				           failedEvent(data);
				       }
				   }).error(function (data, status, headers, config) {
				       window.alert("Error " + status);
				   });
                break;
        }
    }
}]);