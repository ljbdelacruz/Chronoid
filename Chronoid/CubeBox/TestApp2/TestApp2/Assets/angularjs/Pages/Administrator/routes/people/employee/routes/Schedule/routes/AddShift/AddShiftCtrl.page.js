angular.module('modules.AddShift')
.controller('AddShiftCtrl',
            ['$scope', '$http','$route','$q', 
                /*services*/
               'UtilityRequestService',
               'UsersInfoRequestService',
               'UserBreakService',
               'UsersRequestService',
               'ShiftService',
               /*Utility*/
               'AlertUtility',
               'CustomTimout',
               /*Objects*/
               'UserViewModelObject',
               'Selection1Object',
               'ModalAlertObject',
               /*globalization*/
               'GlobalizationEmployeeNavigation',
               'GlobalChoices',
               'GlobalizationUser',
               'GlobalShift',
             function ($scope, $http,$route,$q,
                       /*Services*/
                       UtilityRequestService,
                       UsersInfoRequestService,
                       UserBreakService,
                       UsersRequestService,
                       ShiftService,
                       /*Utility*/
                       AlertUtility,
                       CustomTimout,
                       /*Objects*/
                       UserViewModelObject,
                       Selection1Object,
                       ModalAlertObject,
                       /*Globalization*/
                       GlobalizationEmployeeNavigation,
                       GlobalChoices,
                       GlobalizationUser,
                       GlobalShift) {
                 //filter
                 $scope.filterController = {};
                 $scope.filterController.SearchText = "";


                 //scheduleController
                 $scope.scheduleController = {};
                 $scope.scheduleController.model = { from: '', to: '', users: [] };
                 $scope.scheduleController.model.options = [
                     { id: 1, label: 'SUN', isSelected: false },
                     { id: 2, label: 'MON', isSelected: true },
                     { id: 3, label: 'TUE', isSelected: true },
                     { id: 4, label: 'WED', isSelected: true },
                     { id: 5, label: 'THU', isSelected: true },
                     { id: 6, label: 'FRI', isSelected: true },
                     { id: 7, label: 'SAT', isSelected: true }
                 ];
                 $scope.scheduleController.DaysOnChange = function (data) {
                     data.isSelected = !data.isSelected;
                 }

                 //shiftController
                 $scope.shiftController = {};
                 $scope.shiftController.model = { Name: '', TimeIn: '', TimeOut: '', TotalWorkedHours:''};
                 $scope.shiftController.list = [];
                 $scope.shiftController.LoadData = function () {
                     if (GlobalShift.shifts.length <= 0) {
                         ShiftService(1, {}, function (data) {
                             if (data.success) {
                                 console.log("Success");
                                 GlobalShift.shifts = data.data;
                                 $scope.shiftController.list = data.data;
                                 angular.forEach($scope.shiftController.list, function (obj) {
                                     obj.isEdit = false;
                                 });
                             }
                         }, function (data) {

                         });
                     } else {
                         console.log("Success");
                         $scope.shiftController.list = GlobalShift.shifts;
                     }
                 }
                 $scope.shiftController.OnClick = function (obj, option, index) {
                     obj.isEdit = !obj.isEdit;
                     switch (option) {
                         case 1:
                             //update
                             ShiftService(3, { model: obj }, function (data) {
                                 if (data.success) {
                                     alert("Success");
                                     GlobalShift.shifts[index] = data.data;
                                     $scope.shiftController.list = GlobalShift.shifts;
                                 }
                             }, function (data) { });
                             break;
                         case 2:
                             //delete
                             ShiftService(4, { model: obj, archive : true}, function (data) {
                                 if (data.success) {
                                     alert("Success");
                                     GlobalShift.shifts.splice(index, 1);
                                     $scope.shiftController.list = GlobalShift.shifts;
                                 }
                             }, function (data) { });
                             break;
                     }
                 }
                 $scope.shiftController.Insert = function () {
                     ShiftService(2, { model: $scope.shiftController.model }, function (data) {
                         if (data.success) {
                             alert("Success");
                             GlobalShift.shifts.push(data.data);
                             $scope.shiftController.list.push(data.data);
                         }
                     }, function (data) {});
                 }



                 //constructors
                 $scope.constructor = function () {
                     //loads shift available
                     $scope.shiftController.LoadData();
                 }
                 //interval destroyers
                 $scope.$on('$destroy', function () {
                 });
                 //loads all data and execute the statement inside
                 $scope.$on('$routeChangeSuccess', function () {
                     $http.get("/Administrator#/Employee/Schedule/AddShift")
                       .success(function (data) {
                           //invoke constructor after loading up the page
                           $scope.constructor();
                       })
                        .error(function (data) {
                            console.log("Error " + data);
                        });
                 });
}]);