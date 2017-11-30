angular.module('ngStarterKit')
.controller('TimeClockAppCtrl',
            ['$scope', '$location', '$window',
             function ($scope, $location, $window) {
                 //ui stuff
                 //navigation options
                 $scope.navController = {};
                 //this one navigates through the routes available in  employee
                 $scope.navController.OptionSelect = function (path) {
                     if (path == "/Logout") {
                         $window.location = "/Logout";
                     } else {
                         $location.path(path);
                     }
                 }



}]);

