angular.module('modules.Report')
.controller('ReportCtrl',
            ['$scope', '$http','$route','$window',
                /*services*/
               'UtilityRequestService',
               'UsersInfoRequestService',
               'UserBreakService',
               'UsersRequestService',
               'UserAttendanceService',
               'AttendanceStatusService',
               'AlertUtility',
               'CustomTimout',
               /*globalization*/
               'GlobalizationEmployeeNavigation',
               'GlobalizationUser',
               'GlobalAttendanceStatus',
             function ($scope, $http,$route, $window,
                       /*Services*/
                       UtilityRequestService,
                       UsersInfoRequestService,
                       UserBreakService,
                       UsersRequestService,
                       UserAttendanceService,
                       AttendanceStatusService,
                       AlertUtility,
                       CustomTimout,
                       /*Globalization*/
                       GlobalizationEmployeeNavigation,
                       GlobalizationUser,
                       GlobalAttendanceStatus) {

                 //users controller
                 $scope.usersController = {};
                 $scope.usersController.model = {id:'', from:'', to:''};
                 $scope.usersController.list = [];
                 $scope.usersController.LoadData = function () {
                     if (GlobalizationUser.users.length <= 0) {
                         UsersRequestService(1, {}, function (data) {
                             if (data.success) {
                                 GlobalizationUser.users = data.data;
                                 $scope.usersController.list = GlobalizationUser.users;
                             }
                         }, function (data) { })
                     } else {
                         console.log("FUK");
                         console.log(GlobalizationUser.users);
                         $scope.usersController.list = GlobalizationUser.users;
                     }
                 }
                 $scope.usersController.OnChange=function(id){
                     console.log(id);
                 }

                 //attendanceStatus
                 $scope.attendanceStatusController = {};
                 $scope.attendanceStatusController.list = [];
                 $scope.attendanceStatusController.LoadData=function(){
                     if (GlobalAttendanceStatus.list.length <= 0) {
                         AttendanceStatusService(1, {}, function (data) {
                             if (data.success) {
                                 console.log(data.data);
                                 GlobalAttendanceStatus.list = data.data;
                                 $scope.attendanceStatusController.list = GlobalAttendanceStatus.list;
                             }
                         }, function () { });
                     } else {
                         console.log("Status");
                         console.log(GlobalAttendanceStatus.list);
                         $scope.attendanceStatusController.list = GlobalAttendanceStatus.list;
                     }
                 }

                 
                 //navigation controller
                 $scope.navController = {};
                 $scope.navController.optionButtons = GlobalizationEmployeeNavigation.navigation;

                 //attendanceController
                 $scope.attendanceController = {};
                 $scope.attendanceController.model = {};
                 $scope.attendanceController.list = [];
                 $scope.attendanceController.FilterAttendance = function () {
                     UserAttendanceService(2, { id: $scope.usersController.model.id, fromDate: $scope.usersController.model.from, toDate: $scope.usersController.model.to },
                         function (data) {
                             if (data.success) {
                                 $scope.attendanceController.list = data.data;
                             }
                         }, function (data) { })
                 }
                 //Generate CSV Result
                 $scope.reportController = {};
                 $scope.reportController.GenerateReport = function () {
                     UserAttendanceService(7, { list: $scope.attendanceController.list }, function (data) {
                         if (data.success) {
                             $window.open(data.path, '_blank');
                         }
                     }, function (data) {
                         alert("FAILED");
                     });
                 }



                 //constructors
                 $scope.constructor = function () {
                     //loads users data
                     $scope.usersController.LoadData();
                     //loads attendanceStatus data
                     $scope.attendanceStatusController.LoadData();

                 }
                 //interval destroyers
                 $scope.$on('$destroy', function () {

                 });
                 //loads all data and execute the statement inside
                 $scope.$on('$routeChangeSuccess', function () {
                     $http.get("/Administrator#/Employee/Report")
                       .success(function (data) {
                           //invoke constructor after loading up the page
                           $scope.constructor();
                       })
                        .error(function (data) {
                            console.log("Error " + data);
                        });
                 });
}]);