angular.module('otherApp')
.factory('RequestService', ['$http', '$q', function ($http, $q) {
    /*PATH TO GET THE DATA AND PARAM IS FOR THE PARAMETER OF THAT API */
    var result = function(path, param) {
        console.log(path);
        return $http.get(path, {params:param});
    }
    return result;
}]);