angular.module('otherApp')
.factory('CustomTimout', ['$timeout',function ($timeout) {
    return function (event, delaySeconds) {
        $timeout(function () {
            console.log("TIME OUT");
            event();
        }, delaySeconds);
    }
}]);