angular.module('ngStarterKit')
.controller('SuperAdminAppCtrl',
            ['$scope',
             function ($scope) {




                 $scope.constructor = function () {
                     console.log("Contructor Controller");
                 }
                 $scope.constructor();
}]);

