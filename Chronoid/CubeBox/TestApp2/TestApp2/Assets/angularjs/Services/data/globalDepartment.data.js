angular.module('otherApp')
.factory('GlobalDepartment', ['$location', 'ButtonObject', function ($location, ButtonObject) {
    var Globalization = {
        departments: []
    };
    return Globalization;
}]);