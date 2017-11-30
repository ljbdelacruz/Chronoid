angular.module('modules.GroupSchedule')
.controller('GroupScheduleCtrl',
            ['$scope', '$http','$route',
                /*services*/
               'UtilityRequestService',
               'UsersInfoRequestService',
               'UserBreakService',
               'DepartmentService',
               'ShiftService',
               'AddOnService',
               'UserAttendanceService',
               'AlertUtility',
               'CustomTimout',
               /*globalization*/
               'GlobalizationEmployeeNavigation',
               'GlobalizationUser',
               'GlobalDepartment',
               'GlobalShift',
               'GlobalAddOn',
             function ($scope, $http,$route,
                       /*Services*/
                       UtilityRequestService,
                       UsersInfoRequestService,
                       UserBreakService,
                       DepartmentService,
                       ShiftService,
                       AddOnService,
                       UserAttendanceService,
                       AlertUtility,
                       CustomTimout,
                       /*Globalization*/
                       GlobalizationEmployeeNavigation,
                       GlobalizationUser,
                       GlobalDepartment,
                       GlobalShift,
                       GlobalAddOn) {

                 //navigation controller
                 $scope.navController = {};
                 $scope.navController.optionButtons = GlobalizationEmployeeNavigation.navigation;
                 //scheduleController
                 $scope.scheduleController = {};
                 $scope.scheduleController.model = { from: '', to: '', users: [] };
                 $scope.scheduleController.model.options = [
                     { id: 0, Day: 'SUN', isSelected: false },
                     { id: 1, Day: 'MON', isSelected: false },
                     { id: 2, Day: 'TUE', isSelected: false },
                     { id: 3, Day: 'WED', isSelected: false },
                     { id: 4, Day: 'THU', isSelected: false },
                     { id: 5, Day: 'FRI', isSelected: false },
                     { id: 6, Day: 'SAT', isSelected: false }
                 ];
                 $scope.scheduleController.DaysOnChange = function (data) {
                     data.isSelected = !data.isSelected;
                 }
                 $scope.scheduleController.Insert = function () {
                     UserAttendanceService(6,
                         {
                             vm: {
                                 Users: $scope.usersController.selected,
                                 from: $scope.scheduleController.model.from,
                                 to: $scope.scheduleController.model.to,
                                 Week: $scope.scheduleController.model.options,
                                 shiftID: $scope.shiftController.model.ID
                             }
                         },
                         function (data) {
                         if (data.success) {
                             alert("Success");
                         }
                     }, function (data) {  })
                 }



                 //department controller
                 $scope.departmentController = {};
                 $scope.departmentController.model = { id: '' };
                 $scope.departmentController.OnChange = function (data) {
                     $scope.departmentController.GetUsersByDepartmentID(data);
                 }
                 $scope.departmentController.lists = [];
                 $scope.departmentController.LoadData = function () {
                     if (GlobalDepartment.departments.length <= 0) {
                         DepartmentService(1, {}, function (data) {
                             GlobalDepartment.departments = data.data;
                             $scope.departmentController.lists = data.data;
                         }, function (data) { });
                     } else {
                         $scope.departmentController.lists = GlobalDepartment.departments;
                     }
                 }

                 $scope.departmentController.GetUsersByDepartmentID = function (id) {
                     $scope.usersController.selected = [];
                     angular.forEach($scope.usersController.list, function (data) {
                         //if (data.Department.ID == id) {
                         //    $scope.usersController.selected.push(data);
                         //}
                         if (data.Jobtitle.Department.ID == id) {
                            $scope.usersController.selected.push(data);
                         }
                     });
                 }
                 //users controller
                 $scope.usersController = {};
                 $scope.usersController.model = { id: '' };
                 $scope.usersController.list = [];
                 $scope.usersController.selected = [];
                 $scope.usersController.LoadData = function () {
                     if (GlobalizationUser.users.length <= 0) {
                         UsersRequestService(1, {}, function (data) {
                             GlobalizationUser.users = data.data;
                             GlobalizationUser.count = data.count;
                         }, function (data) { });
                     } else {
                         $scope.usersController.list = GlobalizationUser.users;
                     }
                 }
                 $scope.usersController.OnChange = function (id) {
                     $scope.usersController.FindSelectedByID(id, function (isExist) {
                         if (isExist == false) {
                             $scope.usersController.FindListByID(id, function (data) {
                                 $scope.usersController.selected.push(data);
                             });
                         }
                     });
                 }
                 $scope.usersController.Remove = function (index) {
                     $scope.usersController.selected.splice(index, 1);
                 }
                 $scope.usersController.FindListByID = function (id, event) {
                     angular.forEach($scope.usersController.list, function (data) {
                         if (data.ID == id) {
                             event(data);
                         }
                     });
                 }
                 $scope.usersController.FindSelectedByID = function (id, event) {
                     var index = 0;
                     if ($scope.usersController.selected.length <= 0) {
                         event(false);
                     } else {
                         var isExist = false;
                         angular.forEach($scope.usersController.selected, function (data) {
                             if (data.ID == id) {
                                 event(true);
                                 isExist = true;
                             }
                             index++;
                             if(index == $scope.usersController.selected.length && isExist==false){
                                 event(false);
                             }
                         });
                     }
                 }
                 //shift controller
                 $scope.shiftController = {};
                 $scope.shiftController.model = { ID: '', TotalWorkedHours: 0 };
                 $scope.shiftController.OnChange = function (id) {
                     $scope.shiftController.FindListByID(id, function (data) {
                         $scope.shiftController.Assign(data);
                     });
                 }
                 $scope.shiftController.Assign=function(data){
                     $scope.shiftController.model.ID = data.ID;
                     $scope.shiftController.model.Name = data.Name;
                     $scope.shiftController.model.TimeIn = data.TimeIn;
                     $scope.shiftController.model.TimeOut = data.TimeOut;
                     $scope.shiftController.model.TotalWorkedHours = data.TotalWorkedHours;
                 }
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
                 $scope.shiftController.FindListByID = function (id, event) {
                     angular.forEach($scope.shiftController.list, function (obj) {
                         if (obj.ID == id) {
                             event(obj);
                         }
                     });
                 }

                 //add on service
                 $scope.addOnController = {};
                 $scope.addOnController.model = {ID:'', description:''};
                 $scope.addOnController.list = [];
                 $scope.addOnController.LoadData = function () {
                     if (GlobalAddOn.list.length <= 0) {
                         AddOnService(1, {}, function (data) {
                             if (data.success) {
                                 $scope.addOnController.list = data.data;
                                 GlobalAddOn.list = data.data;
                             }
                         }, function (data) { });
                     } else {
                         GlobalAddOn.list = data.data;
                     }
                 }
                 $scope.addOnController.OnChange = function (id) {
                     console.log(id);
                 }
                 $scope.addOnController.Assign = function (data) {
                     $scope.addOnController.model.ID = data.ID;
                     $scope.addOnController.model.Description = data.Description;
                 }
                 //modalController
                 $scope.modalController4 = {};
                 $scope.modalController4.Show = {};
                 $scope.modalController4.model = { Name:''};
                 $scope.modalController4.buttons = [
                     {
                         label: 'Add', invoke: function (data) {
                             $scope.modalController4.Show();
                             DepartmentService(2, { vm: $scope.modalController4.model }, function (data) {
                                 if (data.success) {
                                     alert("Success Adding Department");

                                 }
                             }, function (data) { });
                         }
                     },
                     { label: 'Cancel', invoke: function (data) { $scope.modalController4.Show(); } }
                 ];



                 //constructors
                 $scope.constructor = function () {
                     //users
                     $scope.usersController.LoadData();
                     //departments
                     $scope.departmentController.LoadData();
                     //loads shifts
                     $scope.shiftController.LoadData();
                     //loads addOns
                     $scope.addOnController.LoadData();
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
                        });
                 });
}]);