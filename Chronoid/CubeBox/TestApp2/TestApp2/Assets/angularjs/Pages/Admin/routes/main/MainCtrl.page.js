angular.module('modules.Main')
.controller('MainCtrl',
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
                                 $scope.loaderController.itemToggle2();
                             }
                         }, function (data) { });
                     } else {
                         $scope.usersController.list = GlobalizationUser.users;
                         $scope.loaderController.itemToggle2();
                     }
                 }

                 //companyController
                 $scope.companyController = {};
                 $scope.companyController.list=[];
                 $scope.companyController.LoadData = function () {
                     if (GlobalCompany.list.length <= 0) {
                         CompanyService(1, {}, function (data) {
                             GlobalCompany.list = data.data;
                             $scope.companyController.list = data.data;
                             $scope.loaderController.itemToggle1();
                         }, function (data) { console.log("failed fetching company"); });
                     } else {
                         $scope.companyController.list = GlobalCompany.list;
                         $scope.loaderController.itemToggle1()
                     }
                 }
                 $scope.navigate = function (value) {
                     console.log("Navigate");
                     console.log(value);
                     $location.path(value);
                 }


                 //loaderController
                 $scope.loaderController = {};
                 $scope.loaderController.itemToggle1 = {};
                 $scope.loaderController.itemToggle2 = {};

                 $scope.constructor = function () {
                     //loads company data
                     $scope.loaderController.itemToggle1();
                     $scope.loaderController.itemToggle2();
                     $scope.companyController.LoadData();
                     $scope.usersController.LoadData();
                 }
                 //interval destroyers
                 $scope.$on('$destroy', function () {
                 });
                 //loads all data and execute the statement inside
                 $scope.$on('$routeChangeSuccess', function () {
                     $http.get("/SuperAdmin#/")
                       .success(function (data) {
                           //invoke constructor after loading up the page
                           $scope.constructor();
                       })
                        .error(function (data) {
                            console.log("Error " + data);
                        });
                 });
}]);