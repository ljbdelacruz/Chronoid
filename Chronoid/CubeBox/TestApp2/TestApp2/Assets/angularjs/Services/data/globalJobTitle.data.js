angular.module('otherApp')
.factory('GlobalJobTitle', ['$location', 'ButtonObject', function ($location, ButtonObject) {
    var Globalization = {
        jobs: []
    };
    return Globalization;
}]);