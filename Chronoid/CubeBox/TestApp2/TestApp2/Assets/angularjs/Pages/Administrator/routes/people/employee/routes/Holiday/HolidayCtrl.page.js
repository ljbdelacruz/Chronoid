angular.module('modules.Holiday')
.controller('HolidayCtrl',
            ['$scope', '$http','$route',
                /*services*/
               'UtilityRequestService',
               'UsersInfoRequestService',
               'UserBreakService',
               'HolidayService',
               'AlertUtility',
               'CustomTimout',
               /*globalization*/
               'GlobalizationEmployeeNavigation',
               'GlobalHoliday',
             function ($scope, $http,$route,
                       /*Services*/
                       UtilityRequestService,
                       UsersInfoRequestService,
                       UserBreakService,
                       HolidayService,
                       AlertUtility,
                       CustomTimout,
                       /*Globalization*/
                       GlobalizationEmployeeNavigation,
                       GlobalHoliday) {
                 //navigation controller
                 $scope.navController = {};
                 $scope.navController.view = 0;
                 $scope.navController.optionButtons = GlobalizationEmployeeNavigation.navigation;
                 $scope.navController.SwitchView = function (option) {
                     switch (option) {
                         case 0:
                             $scope.navController.view = 0;
                             break;
                         case 1:
                             $scope.navController.view = 1;
                             break;
                     }
                     console.log($scope.navController.view);
                 }

                 $scope.holidayController = {};
                 $scope.holidayController.list = [];
                 $scope.holidayController.model = { ID: '', Description: '', StartDate: '', EndDate: '', Company: {ID:''}};
                 $scope.holidayController.LoadData = function () {
                     if (GlobalHoliday.list.length <= 0) {
                         HolidayService(1, {}, function (data) {
                             console.log("Holidays");
                             console.log(data);
                             if (data.success) {
                                 GlobalHoliday.list = data.data;
                                 $scope.holidayController.list = data.data;
                             }
                         }, function (data) { });
                     } else {
                         $scope.holidayController.list = GlobalHoliday.list;
                     }
                 }
                 $scope.holidayController.Insert = function () {
                     HolidayService(2, { vm: $scope.holidayController.model }, function (data) {
                         if (data.success) {
                             alert("Successfully Saved");
                         }
                     }, function (data) {
                         alert("failed to save");
                     })
                 }
                 //constructors
                 $scope.constructor = function () {
                     $scope.holidayController.LoadData();
                 }
                 //interval destroyers
                 $scope.$on('$destroy', function () {
                 });
                 //loads all data and execute the statement inside
                 $scope.$on('$routeChangeSuccess', function () {
                     $http.get("/Administrator#/Employee/Holiday")
                       .success(function (data) {
                           //invoke constructor after loading up the page
                           $scope.constructor();
                       })
                        .error(function (data) {
                            console.log("Error " + data);
                        });
                 });
}]);