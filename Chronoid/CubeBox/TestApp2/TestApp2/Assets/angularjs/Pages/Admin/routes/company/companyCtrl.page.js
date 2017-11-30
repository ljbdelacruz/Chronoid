angular.module('modules.Company')
.controller('CompanyCtrl',
            ['$scope', '$http', '$route', '$location',
             'CompanyService',
             /*globalization*/
             'GlobalCompany',
             function ($scope, $http,$route,$location,
                 /*Services*/
                 CompanyService,
                 /*Globalization*/
                 GlobalCompany) {

                 //companyController
                 $scope.companyController = {};
                 $scope.companyController.list = [];
                 $scope.companyController.LoadData = function () {
                     if (GlobalCompany.list.length <= 0) {
                         CompanyService(1, {}, function (data) {
                             GlobalCompany.list = data.data;
                             $scope.companyController.list = data.data;
                         }, function (data) { console.log("failed fetching company"); });
                     } else {
                         $scope.companyController.list = GlobalCompany.list;
                     }
                 }


                 $scope.constructor = function () {
                     //loads company data
                     $scope.companyController.LoadData();
                 }
                 //interval destroyers
                 $scope.$on('$destroy', function () {
                 });
                 //loads all data and execute the statement inside
                 $scope.$on('$routeChangeSuccess', function () {
                     $http.get("/SuperAdmin#/Company")
                       .success(function (data) {
                           //invoke constructor after loading up the page
                           $scope.constructor();
                       })
                        .error(function (data) {
                            console.log("Error " + data);
                        });
                 });
}]);