angular.module('modules.Main')
.controller('MainCtrl',
            ['$scope', '$http','$route',
                /*services*/
               'UtilityRequestService',
               'UsersInfoRequestService',
               'UserBreakService',
               'BreakTypeService',
               'AlertUtility',
               'CustomTimout',
               /*objects*/
              'BreakButtonObject',
              'TimeObject',
              'UserBreakInfoObject',
              'ModalAlertObject',
              /*Globalization*/
              'GlobalBreakType',
             function ($scope, $http,$route,
                       /*Services*/
                       UtilityRequestService,
                       UsersInfoRequestService,
                       UserBreakService,
                       BreakTypeService,
                       AlertUtility,
                       CustomTimout,
                       /*Objects*/
                       BreakButtonObject,
                       TimeObject,
                       UserBreakInfoObject,
                       ModalAlertObject,
                       /*Globalization*/
                       GlobalBreakType) {
                 //UI stuff
                 // Break Buttons
                 $scope.roundProgressData = {
                     label: 11,
                     percentage: 0.0,
                     limitation:0,
                 };
                 $scope.userController = {};
                 $scope.userController.isLogon = true;
                 $scope.userController.userBreaksList = [];
                 $scope.ModalObject = new ModalAlertObject();
                 //assign value to modal object
                 $scope.AssignValueModalObject=function(icon, title, description, succeedEvent, failedEvent, colors, button1,button2){
                     $scope.ModalObject.icon = icon;
                     $scope.ModalObject.title = title; 
                     $scope.ModalObject.description = description;
                     $scope.ModalObject.succeedEvent = succeedEvent;
                     $scope.ModalObject.failedEvent = failedEvent;
                     $scope.ModalObject.colors = colors;
                     $scope.ModalObject.button1 = button1;
                     $scope.ModalObject.button2 = button2;
                 }
                 //end here
                 //timer controller for timer
                 $scope.timerController = {};
                 $scope.timerController.enableBreak = false;
                 $scope.timerController.timeConsumed = new TimeObject(0, 0, 0);
                 $scope.timerController.Invoke = function () {
                     $scope.timerController.invokeDestroy();
                     $scope.timerController.invokeStart();
                 }
                 $scope.timerController.InvokeWarning = function (remMin) {
                     console.log("Remaining "+remMin);
                     $scope.AssignValueModalObject("mdi mdi-alert-error",
                              "Warning",
                              remMin<=0 ? "Please End Your Break You Have No Time Left" : remMin+ " Minutes Remaining Please End Your Break",
                              $scope.dataController.EndBreakRequest,
                              function () { },
                              [{ color: "blue" }, { color: "red" }],
                              "END BREAK!",
                              "Nah Not Yet"
                             );
                     CustomTimout($scope.modalController.invokeModal, 100);
                 }
                 //clock controller
                 $scope.clockController = {};
                 $scope.clockController.timeObject = new TimeObject(0, 0, 0);
                 $scope.clockController.SuccessTimeFetch = function (data) {
                     $scope.clockController.timeObject = new TimeObject(Number(data.hours), Number(data.minutes), Number(data.seconds),
                                                                        data.Day, data.day, data.Year, data.Month, data.month);
                     $scope.clockController.invokeStart();
                 }
                 $scope.clockController.RequestTime = function () {
                     UtilityRequestService(1, {}, $scope.clockController.SuccessTimeFetch);
                 }
                 

                 //button breaks
                 $scope.breakController = {};
                 $scope.breakController.buttons = [];
                 //this variable is for identifying the break that will be displayed on the modal
                 $scope.breakSelected = {};
                 $scope.breakController.breakType = 0;
                 $scope.breakController.BreakStarted = function (option, timeLimit) {
                     //this identify which message will be displayed on prompt
                     $scope.breakSelected = AlertUtility(option);
                     $scope.roundProgressData.limitation = timeLimit;
                     $scope.breakController.breakType = option;
                     //this one enables the icon to glow and change color
                     $scope.AssignValueModalObject("mdi mdi-action-info", 
                                                   $scope.breakSelected.title + " Break",
                                                   "Are you sure you want to go on a " + $scope.breakSelected.title + " break?",
                                                   $scope.breakController.StartBreak,
                                                   function () { },
                                                   [{ color: "blue" }, { color: "red" }, {color:"green"}],
                                                   "Ok Lets Go!",
                                                   "Nah Not Yet"
                                                  );
                     CustomTimout($scope.modalController.invokeModal, 100);
                 }
                 //ajax post request in inserting new break
                 $scope.breakController.StartBreak = function () {
                     var event=function(data){
                         console.log(data);
                         if (data.success) {
                             $scope.timerController.enableBreak = !$scope.timerController.enableBreak;
                             $scope.timerController.Invoke();
                         } else {
                             $scope.AssignValueModalObject("mdi mdi-action-info",
                              $scope.breakSelected.title + "Break Unavailable",
                              data.message,
                              function () { },
                              function () { },
                              [{ color: "blue" }, { color: "red" }, {color:"yellow"}],
                              "",
                              "Close"
                             );
                             CustomTimout($scope.modalController.invokeModal, 100);
                         }
                     }
                     $scope.dataController.RequestDataBreak(3, { vm:{Type:{ID:$scope.breakController.breakType}}}, event);
                 }
                 $scope.breakController.LoadData = function () {
                     if (GlobalBreakType.list.length <= 0) {
                         BreakTypeService(1, {}, function (data) {
                             if (data.success) {
                                 GlobalBreakType.list = data.data;
                                 angular.forEach(data.data, function (value) {
                                     $scope.breakController.buttons.push(new BreakButtonObject(value.Description, value.ID, value.HexColor, value.EnableHours, value.EnableMinutes, value.DisableHours, value.DisableMinutes, value.TimeLimit, true));
                                 });
                             }
                         }, function (data) {
                             console.log("Failed");
                         })
                     } else {
                         angular.forEach(GlobalBreakType.list, function (value) {
                             $scope.breakController.buttons.push(new BreakButtonObject(value.Description, value.ID, value.HexColor, value.EnableHours, value.EnableMinutes, value.DisableHours, value.DisableMinutes, value.TimeLimit, true));
                         });
                     }
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
                 //ajax loaders
                 $scope.dataController = {};
                 //gets the current users breaks
                 $scope.dataController.LoadUserBreaks = function () {
                     var event = function (data) {
                         if (data.success) {
                             $scope.userController.userBreaksList = [];
                             for (var i = 0; i < data.data.length; i++) {
                                 $scope.userController.userBreaksList.push(new UserBreakInfoObject(data.data[i].id,
                                                                                    data.data[i].timeStarted,
                                                                                    data.data[i].timeEnded,
                                                                                    data.data[i].breakType));
                             }
                         } 
                     }
                     //closure type service callback
                     $scope.dataController.RequestDataUsers(1, { }, event);
                 }
                 //gets the current user time in
                 $scope.dataController.timeIn;
                 $scope.dataController.LoadUserTimeIn = function () {
                     var event = function (data) {
                         //closure type service callback
                         console.log(data);
                         if (data.success) {
                             console.log(data.data);
                             $scope.dataController.timeIn = data.data;
                             $scope.userController.isLogon = true;
                             console.log(data.data);
                         } else {
                             $scope.userController.isLogon = false;
                         }
                     }
                     $scope.dataController.RequestDataUsers(2, {}, event);
                 }
                 $scope.dataController.AssignTimeConsumedObject=function(hours, minutes, seconds){
                     $scope.timerController.timeConsumed.hour = hours;
                     $scope.timerController.timeConsumed.minute = minutes;
                     $scope.timerController.timeConsumed.second = seconds;
                 }

                 //here checks if the user is currently on break
                 $scope.dataController.IsUserOnBreak = function () {
                     var event=function(data){
                         if (data.success) {
                            $scope.dataController.AssignTimeConsumedObject(data.data.Hours, data.data.Minutes, data.data.Seconds);
                            $scope.roundProgressData.limitation = data.timeLimit;
                            $scope.breakController.breakType = data.type;
                            $scope.timerController.enableBreak = !$scope.timerController.enableBreak;
                            $scope.timerController.Invoke();
                         }else {
                            $scope.timerController.timeConsumed=new TimeObject(0, 0, 0);
                         }
                     }
                     $scope.dataController.RequestDataUsers(3, {}, event);
                 }
                 //end break
                 $scope.dataController.EndBreakRequest = function () {
                     var event = function (data) {
                         if (data.success) {
                             $route.reload();
                         } else {
                         }
                     }
                     $scope.dataController.RequestDataBreak(4, { type: $scope.breakController.breakType }, event);
                 }
                 $scope.dataController.RequestDataUsers=function(type, param,action){
                     UsersInfoRequestService(type, param, action);
                 }
                 $scope.dataController.RequestDataBreak = function (type, param, action) {
                     UserBreakService(type, param, action);
                 }
                 //audio control
                 $scope.audioController = {};
                 $scope.audioController.selectedAudio = 0;
                 $scope.audioController.audioList = [{ id: 1, description: 'Lainel', value: 1 }, {id:2, description:'Pikachu', value:2}];
                 $scope.audioController.RetrieveDataFromSelection = function (data) {
                     console.log(data);
                 }
                 //constructors
                 $scope.constructor = function () {
                     //checks if user is login or not
                     //loads user time in
                     $scope.dataController.LoadUserTimeIn();
                     //request time from server
                     $scope.clockController.RequestTime();
                     //loads users list of breaks
                     $scope.dataController.LoadUserBreaks();
                     //checks if user is on break
                     $scope.dataController.IsUserOnBreak();
                     //fetch the breaks for this user
                     $scope.breakController.LoadData();
                 }
                 //interval destroyers
                 $scope.$on('$destroy', function () {
                     //$ interval in timer directive is disposed when you leave the page or goes somewhere
                     $scope.timerController.invokeDestroy();
                     $scope.clockController.invokeDestroy();
                 });
                 //loads all data and execute the statement inside
                 $scope.$on('$routeChangeSuccess', function () {
                     $http.get("/Home#/")
                       .success(function (data) {
                           //invoke constructor after loading up the page
                           $scope.constructor();
                       })
                        .error(function (data) {
                            console.log("Error " + data);
                        });
                 });
}]);