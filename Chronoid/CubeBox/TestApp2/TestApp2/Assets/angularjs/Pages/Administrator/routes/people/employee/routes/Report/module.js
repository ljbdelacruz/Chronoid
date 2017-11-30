angular.module('modules.Report', [])
.config(['$routeProvider',
         function ($routeProvider) {
             /* Handle route on location path is '/' */
             $routeProvider.when('/Employee/Report', {
                 templateUrl: '/Assets/angularjs/Pages/Administrator/routes/people/employee/routes/Report/Report.page.html',
                 controller: 'ReportCtrl'
             });
         }
]);