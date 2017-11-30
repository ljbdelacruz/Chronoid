angular.module('ngStarterKit')
.controller('AdminAppCtrl',
            ['$scope', '$window', '$location',
             'GlobalizationUser',
             'GlobalizationRoute',
             'GlobalChoices',
             /*Requests*/
             'UsersRequestService',
             'UsersInfoRequestService',
             'JobTitleService',
             /*Objects*/
             'Selection1Object',
             function ($scope,$window,$location,
                 /*data*/
                 GlobalizationUser,
                 GlobalizationRoute,
                 GlobalChoices,
                 /*Request*/
                 UsersRequestService,
                 UsersInfoRequestService,
                 JobTitleService,
                 /*Objects*/
                 Selection1Object) {

                 //navcontroller
                 $scope.navController = {};
                 $scope.navController.username = "";
                 $scope.navController.isShowPeopleNavbar = false;

                 //datacontroller
                 $scope.dataController = {};
                 //loads users available for this company
                 //loads list of users
                 $scope.dataController.LoadUsers = function () {
                     UsersRequestService(1, {}, function (data) {
                         console.log(data);
                         GlobalizationUser.users = data.data;
                         GlobalizationUser.count = data.count;
                     }, function (data) {
                         console.log("Failed");
                     });
                 }


                 //loads user information
                 $scope.dataController.LoadCurrentUserInfo = function () {
                     UsersInfoRequestService(4, {}, function (data) {
                         GlobalizationUser.currentUser.ID = data.ID;
                         $scope.navController.username = data.FirstName;
                         GlobalizationUser.currentUser.FirstName = data.FirstName;
                         GlobalizationUser.currentUser.LastName=data.LastName;
                         GlobalizationUser.currentUser.ExtensionName = data.ExtensionName;
                     });
                     //loads current user information
                     UsersRequestService(4, {}, function (data) {
                         if (data.success) {
                             GlobalizationUser.userInfo = data.data;
                         }
                     }, function (data) { })

                 }
                 //loads list of job titles
                 $scope.dataController.LoadJobTitles = function () {
                     JobTitleService(1, {}, function (data) {
                         if (data.success) {
                             GlobalChoices.jobtitles=[];
                             for (var i = 0; i < data.data.length; i++) {
                                 GlobalChoices.jobtitles.push(new Selection1Object(data.data[i].ID, data.data[i].Description, data.data[i].ID));
                             }
                         }
                     }, function (data) {
                         console.log("Failed");
                     })
                 }

                 $scope.dropDownController = {};
                 $scope.dropDownController.items = [{ label: 'Logout', link: '/Logout' }];
                 $scope.dropDownController.Toggle = {};
                 $scope.dropDownController.Navigate = function (path) {
                     if (path == "/Logout") {
                         $window.location = "/Logout";
                     } else {
                         $location.path(path);
                     }
                 }


                 $scope.constructor = function () {
                     //Loads Users
                     $scope.dataController.LoadUsers();
                     $scope.dataController.LoadCurrentUserInfo();
                     //loads job titles
                     $scope.dataController.LoadJobTitles();
                 }
                 $scope.constructor();
}]);

