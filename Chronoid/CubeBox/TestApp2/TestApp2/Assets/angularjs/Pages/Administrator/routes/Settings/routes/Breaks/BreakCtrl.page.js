angular.module('modules.Break')
.controller('BreakCtrl',
            ['$scope', '$http', '$route', '$location',
                /*services*/
               'UtilityRequestService',
               'UsersInfoRequestService',
               'UserBreakService',
               'BreakTypeService',
               'AlertUtility',
               'CustomTimout',
               /*global*/
               'GlobalizationUser',
               'GlobalBreakType',
             function ($scope, $http,$route,$location,
                       /*Services*/
                       UtilityRequestService,
                       UsersInfoRequestService,
                       UserBreakService,
                       BreakTypeService,
                       AlertUtility,
                       CustomTimout,
                       GlobalizationUser,
                       GlobalBreakType) {
                 $scope.breakController = {};
                 $scope.breakController.model = { Description: "", EnableTime: '', DisableTime: '', HexColor: '', OrderNumber : 1, TimeLimit:0};

                 $scope.breakController.list = [];
                 $scope.breakController.LoadData = function () {
                     if (GlobalBreakType.list.length <= 0) {
                         BreakTypeService(1, {}, function (data) {
                             console.log(data);
                             if (data.success) {
                                 console.log(data.data);
                                 GlobalBreakType.list = data.data;
                                 $scope.breakController.list = GlobalBreakType.list;
                                 angular.forEach($scope.breakController.list, function (obj) {
                                     obj.isEdit = false;
                                 });

                             }
                         }, function (data) { });
                     } else {
                         $scope.breakController.list = GlobalBreakType.list;
                     }
                 }
                 $scope.breakController.OnClick = function (obj, index, option) {
                     obj.isEdit = !obj.isEdit;
                     switch (option) {
                         case 1:
                             //update
                             BreakTypeService(2, {vm:obj}, function (data) {
                                 GlobalBreakType.list[index] = data.data;
                                 $scope.breakController.list = GlobalBreakType.list;
                             }, function (data) { });
                             break;
                         case 2:
                             //delete
                             BreakTypeService(3, { vm: obj, isArchived:true }, function (data) {
                                 GlobalBreakType.list.splice(index, 1);
                                 $scope.breakController.list = GlobalBreakType.list;
                             }, function (data) { });
                             break;
                     }
                 }
                 $scope.breakController.Insert = function () {
                     BreakTypeService(4, { vm: $scope.breakController.model }, function (data) {
                         if (data.success) {
                             GlobalBreakType.list.push(data.data);
                             $scope.breakController.list = GlobalBreakType.list;
                         }
                     }, function (data) { });
                 }



                 //constructors
                 $scope.constructor = function () {
                     //loads breaks available
                     $scope.breakController.LoadData();
                 }
                 //interval destroyers
                 $scope.$on('$destroy', function () {
                 });
                 //loads all data and execute the statement inside
                 $scope.$on('$routeChangeSuccess', function () {
                     $http.get("/Administrator#/")
                       .success(function (data) {
                           //invoke constructor after loading up the page
                           $scope.constructor();
                       })
                        .error(function (data) {
                            console.log("Error " + data);
                        });
                 });
}]);