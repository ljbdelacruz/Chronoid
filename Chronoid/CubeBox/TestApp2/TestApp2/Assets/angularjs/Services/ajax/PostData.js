
angular.module('otherApp')
.factory('PostDataService', ['$http', function ($http) {
    /*PATH TO POST THE DATA AND PARAM IS FOR THE PARAMETER OF THAT API*/
    var data = function (path, param) {
        console.log(path);
        console.log(param);
        return $http.post(path, param );
    }
    return data;
}]);