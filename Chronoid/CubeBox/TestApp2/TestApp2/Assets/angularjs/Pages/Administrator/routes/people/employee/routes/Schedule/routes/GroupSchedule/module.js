angular.module('modules.GroupSchedule', [])
.config(['$routeProvider',
         function ($routeProvider) {
             /* Handle route on location path is '/' */
             $routeProvider.when('/Employee/Schedule/GroupSchedule', {
                 templateUrl: '/Assets/angularjs/Pages/Administrator/routes/people/employee/routes/Schedule/routes/GroupSchedule/GroupSchedule.page.html',
                 controller: 'GroupScheduleCtrl'
             });
         }
]);