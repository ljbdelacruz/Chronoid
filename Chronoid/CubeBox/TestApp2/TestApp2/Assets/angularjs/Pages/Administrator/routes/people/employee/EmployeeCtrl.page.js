angular.module('modules.Employee')
.controller('EmployeeCtrl',
            ['$scope', '$http','$route','$location',
                /*services*/
               'UtilityRequestService',
               'UsersInfoRequestService',
               'UserBreakService',
               'UsersRequestService',
               'AlertUtility',
               'CustomTimout',
               /*globalization*/
               'GlobalizationUser',
               'GlobalizationRoute',
               'GlobalizationEmployeeNavigation',
               /*Objects*/
               'ButtonObject',
               'UserViewModelObject',
             function ($scope, $http,$route,$location,
                       /*Services*/
                       UtilityRequestService,
                       UsersInfoRequestService,
                       UserBreakService,
                       UsersRequestService,
                       AlertUtility,
                       CustomTimout,
                       GlobalizationUser,
                       GlobalizationRoute,
                       GlobalizationEmployeeNavigation,
                       /*Object*/
                       ButtonObject,
                       UserViewModelObject) {
                 //sub route controller
                 $scope.subRouteController = {};
                 $scope.subRouteController.mode = 0;

                 //modal controller
                 $scope.modalController = {};
                 $scope.modalController.icon = {};
                 $scope.modalController.Submit = function (option) {
                     console.log(option);
                     console.log("Submit Button");
                 }
                 //navigation controller
                 $scope.navController = {};
                 $scope.navController.optionButtons = GlobalizationEmployeeNavigation.navigation;
                 //employee data
                 $scope.employeeController = {};
                 $scope.employeeController.createModel = new UserViewModelObject();
                 //adds new customer
                 $scope.employeeController.AddNewCustomer = function () {
                     console.log($scope.employeeController.createModel.Gender);
                 }
                 $scope.employeeController.searchPerson = "";
                 $scope.employeeController.data = [];
                 $scope.employeeController.displayData = [];
                 $scope.employeeController.AssignData = function (data) {
                     $scope.employeeController.data = data;
                     $scope.employeeController.SegregateData();
                 }
                 $scope.employeeController.SegregateData = function () {
                     $scope.employeeController.displayData = [];
                     for (var i = 0; i < $scope.employeeController.data.length; i++) {
                         $scope.employeeController.displayData.push(
                         {
                             0: $scope.employeeController.data[i].ID,
                             1: $scope.employeeController.data[i].LastName + ", " + $scope.employeeController.data[i].FirstName + " " + $scope.employeeController.data[i].ExtensionName,
                             2: $scope.employeeController.data[i].Jobtitle.Description,
                             3: $scope.employeeController.data[i].JobStatus.Description,
                             4:$scope.employeeController.data[i].Code
                         });
                     }
                 }
                 $scope.employeeController.FindListModelByID = function (id, event) {
                     angular.forEach($scope.employeeController.data, function (value) {
                         if (value.ID == id) {
                             event(value);
                         }
                     })
                 }
                 $scope.employeeController.FindIndexByID = function (data, event) {
                     event($scope.employeeController.data.findIndex(x=>x.ID == data.ID));
                 }
                 $scope.employeeController.optionButtons = [
                     new ButtonObject("mdi mdi-editor-mode-edit", "", "1", function (data) {
                         $scope.employeeController.FindListModelByID(data[0], function (model) {
                             GlobalizationUser.editUsers = model;
                             $location.path("/Employee/EditUsers");
                         });
                     }), new ButtonObject("mdi mdi-action-visibility", "", "2", function (data) {
                         console.log(data);
                     }), new ButtonObject("mdi mdi-hardware-laptop-chromebook", "", "3", function (data) {
                         $scope.employeeController.FindListModelByID(data[0], function (obj) {
                             $scope.credsController.model.ID = obj.aspNetUser.ID;
                             $scope.credsController.model.Username = obj.aspNetUser.UserName;
                             $scope.modalController4.Show();
                         })
                     }), new ButtonObject("mdi mdi-action-delete", "", "4", function (data) {
                         $scope.employeeController.FindListModelByID(data[0], function (obj) {
                             var item = obj;
                             UsersRequestService(6, { vm: item }, function (arData) {
                                 console.log("Result Data");
                                 console.log(arData);
                                 if (arData.success) {
                                     $scope.employeeController.FindIndexByID(item, function (index) {
                                         GlobalizationUser.users.splice(index, 1);
                                         CustomTimout(function () {
                                             $scope.employeeController.AssignData(GlobalizationUser.users);
                                         }, 100);
                                     });
                                 }
                             }, function (data) { });
                         })
                     })];
                 //ajaxController
                 $scope.ajaxController = {};
                 $scope.ajaxController.Request=function(option, reqOption, param, success, failed){
                     switch(option){
                         case 1:
                             UsersRequestService(reqOption, param, success, failed);
                             break;
                     }
                 }
                 //modalController4
                 $scope.modalController4 = {};
                 //modal controller for modifying credentials
                 $scope.modalController4.Show = {};
                 $scope.modalController4.buttons = [
                     {
                         label: 'Confirm', invoke: function (data) {
                             console.log("Sending Data");
                             console.log($scope.credsController.model);
                             UsersRequestService(5, { vm: $scope.credsController.model },
                                 function (data) {
                                 if (data.success) {
                                     alert("Success Updating Credentials");
                                     $scope.modalController4.Show();
                                 }
                             }, function (data) {
                                 alert("Failed");
                             });
                         }
                     },
                     { label: 'Cancel', invoke: function (data) { $scope.modalController4.Show(); } }
                 ]
                 //credsController
                 $scope.credsController = {};
                 $scope.credsController.model = { ID: '', Username: '', Password: '' };
                 $scope.constructor = function () {
                     $scope.employeeController.AssignData(GlobalizationUser.users);
                 }
                 //interval destroyers
                 $scope.$on('$destroy', function () {
                 });
                 //loads all data and execute the statement inside
                 $scope.$on('$routeChangeSuccess', function () {
                     $http.get("/Administrator#/Employee")
                       .success(function (data) {
                           //invoke constructor after loading up the page
                           GlobalizationRoute.route = 1;
                           $scope.constructor();
                       })
                       .error(function (data){
                            console.log("Error " + data);
                       });
                 });
}]);