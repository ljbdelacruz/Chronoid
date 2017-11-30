angular.module('modules.Main')
.controller('MainCtrl',
            ['$scope', '$http','$route',
                /*services*/
               'UtilityRequestService',
               'UsersInfoRequestService',
               'UserBreakService',
               'UserAttendanceService',
               'AlertUtility',
               'CustomTimout',
               /*objects*/
              'ModalAlertObject',
              'TimeObject',
              'TimeInsObject',
             function ($scope, $http,$route,
                       /*Services*/
                       UtilityRequestService,
                       UsersInfoRequestService,
                       UserBreakService,
                       UserAttendanceService,
                       AlertUtility,
                       CustomTimout,
                       /*Objects*/
                       ModalAlertObject,
                       TimeObject,
                       TimeInsObject) {
                 //employee ui/inputs controller
                 $scope.employeeController = {};
                 $scope.employeeController.employeeName = "";
                 $scope.employeeController.loginID = "";
                 //time controller
                 $scope.clockController = {};
                 $scope.clockController.timeObject = new TimeObject(0, 0, 0);
                 $scope.clockController.date = "";
                 $scope.clockController.time = "";
                 $scope.clockController.RequestTime=function(){
                     UtilityRequestService(1, {}, function(data){
                         $scope.clockController.timeObject = new TimeObject(Number(data.hours), Number(data.minutes), Number(data.seconds),
                                                                            data.Day, data.day, data.Year, data.Month, data.month);
                         $scope.clockController.invokeStart();
                     });
                 }
                 //data controller
                 $scope.dataController = {};
                 $scope.dataController.timeIns = [];
                 //this one gets the list of users time in today
                 $scope.dataController.GetUserAttendanceToday = function () {
                     $scope.dataController.timeIns = [];
                     UserAttendanceService(1, {}, function (data) {
                         console.log(data);
                         for (var i = 0; i < data.data.length; i++) {
                             $scope.dataController.timeIns.push(new TimeInsObject(data.data[i].name,
                                                                                  data.data[i].profileImage,
                                                                                  data.data[i].schedule,
                                                                                  data.data[i].actualLoginImage, data.data[i].actualLoginTime, data.data[i].actualLogoutImage,
                                                                                  data.data[i].actualLogoutTime));
                         }
                     });
                 }
                 //camera controller
                 $scope.cameraController = {};
                 $scope.cameraController.imageData = "";
                 $scope.cameraController.UploadImage = function () {
                     console.log(cameraController.imageData);
                 }
                 $scope.cameraController.EnterKey = function () {
                     $scope.cameraController.snap();
                 }
                 $scope.cameraController.IsImageReady = function (data) {

                     UserAttendanceService(3, { Code: $scope.employeeController.loginID, imageUri: data },
                         function (data) {
                                     $scope.dataController.GetUserAttendanceToday();
                         }, function () {
                             console.log(data.message);
                         })
                     //UserAttendanceService(3, { image: data, option: '1', loginID: $scope.employeeController.loginID }, function (data) {
                     //    if (data.success) {
                     //        $scope.dataController.GetUserAttendanceToday();
                     //    } else {
                     //        console.log(data.message);
                     //    }
                     //})
                 }
                 //end here
                 $scope.constructor = function () {
                     //this one request the time today
                     $scope.clockController.RequestTime();
                     //this one request the list of users attendance today
                     $scope.dataController.GetUserAttendanceToday();
                 }
                 $scope.$on('$routeChangeSuccess', function () {
                     $http.get("/TimeClock#/")
                       .success(function (data) {
                           //invoke constructor after loading up the page
                           $scope.constructor();
                       })
                        .error(function (data) {
                            console.log("Error " + data);
                        });
                 });

}]);