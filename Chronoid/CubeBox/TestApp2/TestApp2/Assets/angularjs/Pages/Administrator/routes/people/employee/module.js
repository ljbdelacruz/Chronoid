angular.module('modules.Employee', [])
.config(['$routeProvider',
         function ($routeProvider) {
             /* Handle route on location path is '/' */
             $routeProvider.when('/Employee', {
                 templateUrl: '/Assets/angularjs/Pages/Administrator/routes/people/employee/Employee.page.html',
                 controller: 'EmployeeCtrl'
             });
         }
]);