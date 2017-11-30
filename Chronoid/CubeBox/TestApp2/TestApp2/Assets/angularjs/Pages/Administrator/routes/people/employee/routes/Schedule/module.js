angular.module('modules.Schedule', [])
.config(['$routeProvider',
         function ($routeProvider) {
             /* Handle route on location path is '/' */
             $routeProvider.when('/Employee/Schedule', {
                 templateUrl: '/Assets/angularjs/Pages/Administrator/routes/people/employee/routes/Schedule/Schedule.page.html',
                 controller: 'ScheduleCtrl'
             });
         }
]);