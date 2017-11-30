angular.module('modules.Users')
.controller('UsersCtrl',
            ['$scope', '$http', '$route', '$location',
             'CompanyService',
             'UsersRequestService',
             /*globalization*/
             'GlobalCompany',
             'GlobalizationUser',
             function ($scope, $http,$route,$location,
                 /*Services*/
                 CompanyService,
                 UsersRequestService,
                 /*Globalization*/
                 GlobalCompany,
                 GlobalizationUser) {

                 //usersController
                 $scope.usersController = {};
                 $scope.usersController.list = [];
                 $scope.usersController.LoadData = function () {
                     if (GlobalizationUser.users.length <= 0) {
                         UsersRequestService(7, {}, function (data) {
                             if (data.success) {
                                 GlobalizationUser.users = data.data;
                                 $scope.usersController.list = data.data;
                             }
                         }, function (data) { });
                     } else {
                         console.log("WHAT");
                         console.log(GlobalizationUser.users)
                         $scope.usersController.list = GlobalizationUser.users;
                     }
                 }


                 $scope.constructor = function () {
                     //loads user data
                     $scope.usersController.LoadData();
                 }
                 //interval destroyers
                 $scope.$on('$destroy', function () {
                 });
                 //loads all data and execute the statement inside
                 $scope.$on('$routeChangeSuccess', function () {
                     $http.get("/SuperAdmin#/Users")
                       .success(function (data) {
                           //invoke constructor after loading up the page
                           $scope.constructor();
                       })
                        .error(function (data) {
                            console.log("Error " + data);
                        });
                 });
}]);