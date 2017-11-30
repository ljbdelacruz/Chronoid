angular.module('otherApp', [])
.factory('windowReload', ['$window', function ($window) {
    /*PATH TO POST THE DATA AND PARAM IS FOR THE PARAMETER OF THAT API*/
    var data = function () {
        $window.location.reload();
    }
    return data;
}]);
