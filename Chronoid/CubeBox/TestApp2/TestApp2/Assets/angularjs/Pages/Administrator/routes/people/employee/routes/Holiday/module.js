angular.module('modules.Holiday', [])
.config(['$routeProvider',
         function ($routeProvider) {
             /* Handle route on location path is '/' */
             $routeProvider.when('/Employee/Holiday', {
                 templateUrl: '/Assets/angularjs/Pages/Administrator/routes/people/employee/routes/Holiday/Holiday.page.html',
                 controller: 'HolidayCtrl'
             });
         }
]);