angular.module('modules.EditUsers')
.controller('EditUsersCtrl',
            ['$scope', '$http','$route','$location',
                /*services*/
               'UtilityRequestService',
               'UsersInfoRequestService',
               'UserBreakService',
               'UsersRequestService',
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
             function ($scope, $http,$route,$location,
                       /*Services*/
                       UtilityRequestService,
                       UsersInfoRequestService,
                       UserBreakService,
                       UsersRequestService,
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
                       GlobalizationUser) {
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
                                                     "Update User?",
                                                     function () {
                                                         //success
                                                         UsersRequestService(3, $scope.employeeController.createModel,
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
                 //this one clears the data inside the edit page
                 $scope.employeeController.ClearModel = function () {
                     $scope.employeeController.createModel = new UserViewModelObject();
                 }
                 //this one assigns the model to the data that will be modified
                 $scope.employeeController.AssignModel = function () {
                     $scope.employeeController.createModel = GlobalizationUser.editUsers;
                     if ($scope.employeeController.createModel.ID == '' || $scope.employeeController.createModel.ID == undefined) {
                         $location.path("/Employee");
                     }
                 }
                 $scope.navController.jobTitles = [];
                 $scope.navController.Assign=function(){
                     $scope.navController.jobTitles = GlobalChoices.jobtitles;
                     $scope.employeeController.AssignModel();
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

                 //watcher controller
                 $scope.watcherController = {};
                 //this watches the values change in count
                 $scope.$watch(GlobalChoices.jobtitles, $scope.navController.Assign());
                 //constructors
                 $scope.constructor = function () {
                     $scope.navController.Assign();

                 }
                 //interval destroyers
                 $scope.$on('$destroy', function () {
                 });
                 //loads all data and execute the statement inside
                 $scope.$on('$routeChangeSuccess', function () {
                     $http.get("/Administrator#/Employee/EditUsers")
                       .success(function (data) {
                           //invoke constructor after loading up the page
                           $scope.constructor();
                       })
                        .error(function (data) {
                            console.log("Error " + data);
                        });
                 });
}]);