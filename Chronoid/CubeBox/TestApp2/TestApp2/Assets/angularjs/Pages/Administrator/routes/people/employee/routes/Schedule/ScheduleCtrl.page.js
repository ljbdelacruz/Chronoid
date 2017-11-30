angular.module('modules.Schedule')
.controller('ScheduleCtrl',
            ['$scope', '$http','$route',
                /*services*/
               'UtilityRequestService',
               'UsersInfoRequestService',
               'UserBreakService',
               'UserAttendanceService',
               'ScheduleService',
               'DepartmentService',
               'ShiftService',
               'AddOnService',
               'AttendanceStatusService',
               'AlertUtility',
               'CustomTimout',
               /*globalization*/
               'GlobalizationEmployeeNavigation',
               'GlobalizationUser',
               'GlobalDepartment',
               'GlobalAddOn',
               'GlobalShift',
               'GlobalAttendanceStatus',
               /*Objects*/
               'Selection1Object',

             function ($scope, $http,$route,
                       /*Services*/
                       UtilityRequestService,
                       UsersInfoRequestService,
                       UserBreakService,
                       UserAttendanceService,
                       ScheduleService,
                       DepartmentService,
                       ShiftService,
                       AddOnService,
                       AttendanceStatusService,
                       AlertUtility,
                       CustomTimout,
                       /*Globalization*/
                       GlobalizationEmployeeNavigation,
                       GlobalizationUser,
                       GlobalDepartment,
                       GlobalAddOn,
                       GlobalShift,
                       GlobalAttendanceStatus,
                       /*Objects*/
                       Selection1Object) {
                 //schedule controller
                 $scope.scheduleController = {};
                 //assign schedule
                 $scope.scheduleController.AssignSchedule = function () {
                     $scope.employeeController.user.schedule.TimeIn = $scope.employeeController.user.schedule.TimeIn.Hours + ":" + $scope.employeeController.user.schedule.TimeIn.Minutes;
                     $scope.employeeController.user.schedule.TimeOut = $scope.employeeController.user.schedule.TimeOut.Hours + ":" + $scope.employeeController.user.schedule.TimeOut.Minutes;
                 }
                 $scope.scheduleController.isAdd = false;
                 $scope.scheduleController.schedules = [];
                 $scope.scheduleController.Edit = function (data) {
                     console.log(data);
                 }
                 $scope.scheduleController.Update = function (data) {
                     console.log(data);
                     UserAttendanceService(5, { vm: data }, function (result) {
                         alert("Success Saving");
                     }, function (result) { console.log("Failed"); });
                 }

                 //filter controller
                 $scope.filterController = {};
                 $scope.filterController.dateFilter = { fromDate: '', toDate: '' };
                 $scope.filterController.Filter = function () {
                     UserAttendanceService(2, {
                         id: $scope.employeeController.model.ID,
                         fromDate: $scope.filterController.dateFilter.fromDate,
                         toDate: $scope.filterController.dateFilter.toDate
                     }, function (data) {
                         if (data.success) {
                             console.log(data.data);
                             $scope.scheduleController.schedules = data.data;
                         }
                     }, function (data) { console.log("FAILED"); });
                 }
                 $scope.filterController.user = {};
                 $scope.filterController.user.OnChange = function (id) {
                     if (id == "null") {
                         $scope.employeeController.model.ID = null;
                     } else {
                         $scope.employeeController.model.ID = id;
                     }
                 }
                 //optionController
                 $scope.optionController = {};
                 $scope.optionController.schedules = [];
                 $scope.optionController.schedSelected = "";
                 $scope.optionController.SchedOnChange = function (id) {
                     console.log(id);
                 }

                 //employeeController
                 $scope.employeeController = {};
                 $scope.employeeController.model = {ID:''};
                 $scope.employeeController.lists = [];
                 $scope.employeeController.LoadData = function () {
                     if (GlobalizationUser.users.length <= 0) {
                         UsersRequestService(1, {}, function (data) {
                             console.log(data.data);
                             $scope.employeeController.lists = data.data;
                             GlobalizationUser.users = data.data;
                             GlobalizationUser.count = data.count; }, function (data) { });
                     } else {
                         $scope.employeeController.lists = GlobalizationUser.users;
                     }
                 }
                 $scope.employeeController.AssignModel = function (data) {
                     $scope.employeeController.model = data.ID;
                 }
                 $scope.employeeController.OnChange = function (data) {
                     console.log(data);
                 }

                 //shift controller
                 $scope.shiftController = {};
                 $scope.shiftController.model = {ID:''};
                 $scope.shiftController.list = [];
                 $scope.shiftController.LoadData = function () {
                     if (GlobalShift.shifts.length <= 0) {
                         ShiftService(1, {}, function (data) {
                             if (data.success) {
                                 GlobalShift.shifts = data.data;
                                 $scope.shiftController.list = data.data;
                             }
                         }, function (data) {

                         });
                     } else {
                         $scope.shiftController.list = GlobalShift.shifts;
                     }
                 }
                 $scope.shiftController.Assign = function (data) {
                 }
                 $scope.shiftController.OnChange = function (data) {
                    
                 }
                 //addOns controller
                 $scope.addOnsController = {};
                 $scope.addOnsController.list = [];
                 $scope.addOnsController.LoadData = function () {
                     if (GlobalAddOn.list.length <= 0) {
                         AddOnService(1, {}, function (data) {
                             if (data.success) {
                                 console.log(data.data);
                                 GlobalAddOn.list = data.data;
                                 $scope.addOnsController.list = data.data;
                             }
                         }, function () { });
                     } else {
                         $scope.addOnsController.list = GlobalAddOn.list;
                     }
                 }
                 //navigation controller
                 $scope.navController = {};
                 $scope.navController.optionButtons = GlobalizationEmployeeNavigation.navigation;
                 //departmentController
                 $scope.departmentController = {};
                 $scope.departmentController.items = [];
                 $scope.departmentController.LoadData = function () {
                     if (GlobalDepartment.departments.length <= 0) {
                         DepartmentService(1, {}, function (data) {
                             GlobalDepartment.departments = data.data;
                             $scope.departmentController.items = GlobalDepartment.departments;
                         }, function (data) {
                             console.log("failed");
                         });
                     } else {
                         $scope.departmentController.items = GlobalDepartment.departments;
                     }
                 }
                 //attendanceStatus Controller
                 $scope.attendanceStatusController = {};
                 $scope.attendanceStatusController.list = [];
                 $scope.attendanceStatusController.LoadData = function () {
                     if (GlobalAttendanceStatus.list.length <= 0) {
                         AttendanceStatusService(1, {}, function (data) {
                             if (data.success) {
                                 console.log("Success");
                                 console.log(data.data);
                                 GlobalAttendanceStatus.list = data.data;
                                 $scope.attendanceStatusController.list = data.data;
                             }
                         }, function (data) { console.log("Failed"); })
                     } else {
                         $scope.attendanceStatusController.list = data.data;
                     }
                 }



                 //constructors
                 $scope.constructor = function () {
                     //loads department data
                     $scope.departmentController.LoadData();
                     //loads user data
                     $scope.employeeController.LoadData();
                     //loads shifts
                     $scope.shiftController.LoadData();
                     ////addOns data
                     //$scope.addOnsController.LoadData();
                     //attendanceStatus data
                     $scope.attendanceStatusController.LoadData();
                 }
                 //interval destroyers
                 $scope.$on('$destroy', function () {
                 });
                 //loads all data and execute the statement inside
                 $scope.$on('$routeChangeSuccess', function () {
                     $http.get("/Administrator#/Employee/Schedule")
                       .success(function (data) {
                           //invoke constructor after loading up the page
                           $scope.constructor();
                       })
                       .error(function (data) {
                            console.log("Error " + data);
                       });
                 });
}]);