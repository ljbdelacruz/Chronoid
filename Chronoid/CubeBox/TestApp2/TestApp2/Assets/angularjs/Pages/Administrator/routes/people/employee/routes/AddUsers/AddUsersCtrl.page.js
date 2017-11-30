angular.module('modules.AddUsers')
.controller('AddUsersCtrl',
            ['$scope', '$http','$route','$q',
                /*services*/
               'UtilityRequestService',
               'UsersInfoRequestService',
               'UserBreakService',
               'UsersRequestService',
               'JobTitleService',
               'DepartmentService',
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
               'GlobalDepartment',
             function ($scope, $http,$route,$q,
                       /*Services*/
                       UtilityRequestService,
                       UsersInfoRequestService,
                       UserBreakService,
                       UsersRequestService,
                       JobTitleService,
                       DepartmentService,
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
                       GlobalDepartment) {
                 //navigation controller
                 $scope.navController = {};
                 $scope.navController.optionButtons = GlobalizationEmployeeNavigation.navigation;
                 //employeecontroller
                 $scope.employeeController = {};
                 $scope.employeeController.createModel = new UserViewModelObject();
                 $scope.employeeController.AddNewCustomer = function () {
                     //adds new customer
                     $scope.AssignValueModalObject("mdi mdi-alert-error",
                                                     "Are You Sure?",
                                                     "Save New User?",
                                                     function () {
                                                         //success
                                                         UsersRequestService(2, $scope.employeeController.createModel,
                                                                             function (data) {
                                                                                 console.log("Success! " + data);
                                                                                 if (data.success) {
                                                                                     GlobalizationUser.users.push(data.data);
                                                                                     $scope.employeeController.ClearModel();
                                                                                     alert("Success Save");
                                                                                 }
                                                                             },
                                                                             function (data) {
                                                                                 console.log("Failed! " + data);
                                                                             });
                                                     },
                                                     function () {
                                                         //failed
                                                     },
                                                     [{ color: "blue" }, { color: "red" }],
                                                     "Save",
                                                     "Cancel"
                     );
                     CustomTimout($scope.modalController.invokeModal, 100);
                 }
                 $scope.employeeController.ClearModel = function () {
                     $scope.employeeController.createModel = new UserViewModelObject();
                 }
                 $scope.navController.jobTitles = [];
                 $scope.navController.Assign=function(){
                     $scope.navController.jobTitles = GlobalChoices.jobtitles;
                 }
                 //modal controller
                 $scope.modalController = {};
                 $scope.modalController.icon = {};
                 //invoke the modal
                 $scope.modalController.invokeModal = function () {
                     $scope.modalController.icon.invokeDestroy();
                     $scope.modalController.icon.invokeStart();
                     $scope.modalController.ShowModal();
                 }

                 //Modal Object
                 $scope.ModalObject = new ModalAlertObject();
                 $scope.AssignValueModalObject = function (icon, title, description, succeedEvent, failedEvent, colors, button1, button2) {
                     $scope.ModalObject.icon = icon;
                     $scope.ModalObject.title = title;
                     $scope.ModalObject.description = description;
                     $scope.ModalObject.succeedEvent = succeedEvent;
                     $scope.ModalObject.failedEvent = failedEvent;
                     $scope.ModalObject.colors = colors;
                     $scope.ModalObject.button1 = button1;
                     $scope.ModalObject.button2 = button2;
                 }

                 //modal controller2

                 //job titles
                 $scope.jobTitleController = {};
                 $scope.jobTitleController.model = { ID: '', Description: '' };
                 $scope.jobTitleController.list = [];
                 $scope.jobTitleController.LoadData = function () {
                     if (GlobalChoices.jobtitles.length <= 0) {
                         JobTitleService(1, {}, function (data) {
                             if (data.success) {
                                 console.log(data);
                                 GlobalChoices.jobtitles = data.data;
                                 $scope.jobTitleController.list = GlobalChoices.jobtitles;
                                 CustomTimout(function () { $scope.navController.Assign(); }, 100);
                                 
                             }
                         }, function (data) { });
                     } else {
                         $scope.jobTitleController.list = GlobalChoices.jobtitles;
                     }
                 }

                 //modalController4
                 $scope.modalController4 = {};
                 $scope.modalController4.Show = {};
                 $scope.modalController4.buttons = [
                     {
                         label: 'Add', invoke: function (data) {
                             $scope.modalController4.Show();
                             JobTitleService(2, { vm: $scope.jobTitleController.model }, function (obj) {
                                 console.log(obj);
                                 if (obj.success) {
                                     GlobalChoices.jobtitles.push(obj.data);
                                     $scope.jobTitleController.list.push(obj.data);
                                     $scope.navController.jobTitles.push(obj.data);
                                 }
                             }, function (data) { });
                         }
                     },
                     { label: 'Cancel', invoke: function (data) { $scope.modalController4.Show(); } }
                 ];

                 //jobtitleController
                 $scope.jobTitleController = {};
                 $scope.jobTitleController.model = { Description: '', Department: {ID:''}};

                 //departmentController
                 $scope.departmentController = {};
                 $scope.departmentController.model = { id: '' };
                 $scope.departmentController.list=[];
                 $scope.departmentController.LoadData = function () {
                     if (GlobalDepartment.departments.length <= 0) {
                         DepartmentService(1, {},
                             function (data) {
                                 if (data.success) {
                                     GlobalDepartment.departments = data.data;
                                     $scope.departmentController.list = data.data;
                                 }
                             },
                             function (data) {});
                     } else {
                         $scope.departmentController.list = GlobalDepartment.departments;
                     }
                 }
                 //watcher controller
                 $scope.watcherController = {};
                 //this watches the values change in count
                 $scope.$watch(GlobalChoices.jobtitles, $scope.navController.Assign());
                 //constructors
                 $scope.constructor = function () {
                     $scope.navController.Assign();
                     //loads job titles available
                     $scope.jobTitleController.LoadData
                     //loads department data
                     $scope.departmentController.LoadData();
                 }
                 //interval destroyers
                 $scope.$on('$destroy', function () {

                 });
                 //loads all data and execute the statement inside
                 $scope.$on('$routeChangeSuccess', function () {
                     $http.get("/Administrator#/Employee/AddUsers")
                       .success(function (data) {
                           //invoke constructor after loading up the page
                           $scope.constructor();
                       })
                        .error(function (data) {
                            console.log("Error " + data);
                        });
                 });
}]);