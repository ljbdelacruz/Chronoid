angular.module('ngStarterKit')
.controller('EmployeeAppCtrl',
            ['$scope', '$location', '$window','IconNavigationObject',
             function ($scope, $location, $window,IconNavigationObject) {
                 //ui stuff
                 //navigation options
                 $scope.navOptions = [new IconNavigationObject("", "mdi-social-person", "/Profile"),
                                      new IconNavigationObject("", "mdi-image-edit", "/"),
                                      new IconNavigationObject("", "mdi-maps-directions-bus", "/"),
                                      new IconNavigationObject("", "mdi-action-trending-up", "/"),
                                      new IconNavigationObject("", "mdi-action-input", "/Logout")];
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

