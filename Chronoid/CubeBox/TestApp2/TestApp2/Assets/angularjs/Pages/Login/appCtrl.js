angular.module('ngStarterKit')
.controller('LoginAppCtrl',
            ['$scope', 'dbLoginControllerService', 'windowReload',
             function ($scope, dbLoginControllerService, windowReload) {
                 //preloaderController
                 $scope.preLoaderController = {};
                 $scope.preLoaderController.Toggle = {};
                 //Login Controller
                 $scope.loginController = {};
                 $scope.loginController.options = [{ label: 'Administrator', icon: 'mdi mdi-action-face-unlock', option: 1 },
                                                   { label: 'Employee', icon: 'mdi mdi-social-group', option: 2 },
                                                   { label: 'Time Clock', icon: 'mdi mdi-image-timer', option: 3 }]
                 $scope.loginController.model = { userType: '', username: '', password: '', flagLogin :0, flagDisplay:'', response:''};
                 $scope.loginController.Login = function () {
                     $scope.preLoaderController.Toggle();
                     dbLoginControllerService(1,
                        {
                            username: $scope.loginController.model.username,
                            password: $scope.loginController.model.password,
                            accessType: $scope.loginController.model.userType
                        }, function (data) { if (data.success) { windowReload(); } else { $scope.loginController.model.response = data.message; $scope.preLoaderController.Toggle(); } },
                           function (data) { $scope.loginController.model.response = data.message; $scope.preLoaderController.Toggle(); }
                        );
                 }
                 //This will identify which option you picked
                 $scope.loginController.ShowLogin = function (id, option) {
                     $scope.loginController.model.response = "";
                     $scope.loginController.model.flagLogin = 1;
                     $scope.loginController.model.userType = option
                     $scope.loginController.model.flagDisplay = $scope.loginController.model.userType == 1 ? "Admin" : $scope.loginController.model.userType == 2 ? "Employee" : "Timeclock"
                 }
                 //flags

                 //0 admin
                 
                 //1 employee
                 
                 //2 timeclock



             }]);

