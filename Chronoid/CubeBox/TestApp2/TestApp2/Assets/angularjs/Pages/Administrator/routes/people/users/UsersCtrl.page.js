angular.module('modules.Settings')
.controller('SettingsCtrl',
            ['$scope', '$http', '$route', '$location',
                /*services*/
                'UsersRequestService',
                /*globalization*/
                'GlobalizationUser',
                'GlobalTimeZone',
             function ($scope, $http,$route,$location,
                 /*Services*/
                 UsersRequestService,
                 /*Globalization*/
                 GlobalizationUser,
                 GlobalTimeZone) {
                 //global timeZone
                 $scope.timeZoneController = {};
                 $scope.timeZoneController.list = [];
                 $scope.timeZoneController.LoadData = function () {
                     $scope.timeZoneController.list = GlobalTimeZone.list;
                 }
                 //user controller
                 $scope.usersController = {};
                 $scope.usersController.LoadData = function () {
                     console.log("Users Info");
                     if (GlobalizationUser.userInfo == {} || GlobalizationUser.userInfo == undefined) {
                         UsersRequestService(4, {}, function (data) {
                             if (data.success) {
                                 GlobalizationUser.userInfo = data.data;
                             }
                         }, function (data) { });
                     } else {
                         console.log(GlobalizationUser);
                     }
                 }

                 //constructors
                 $scope.constructor = function () {
                     //loads user info
                     $scope.usersController.LoadData();

                     //loads timezone
                     $scope.timeZoneController.LoadData();
                 }
                 //interval destroyers
                 $scope.$on('$destroy', function () {
                 });
                 //loads all data and execute the statement inside
                 $scope.$on('$routeChangeSuccess', function () {
                     $http.get("/Administrator#/Settings")
                       .success(function (data) {
                           //invoke constructor after loading up the page
                           $scope.constructor();
                       })
                        .error(function (data) {
                            console.log("Error " + data);
                        });
                 });
}]);