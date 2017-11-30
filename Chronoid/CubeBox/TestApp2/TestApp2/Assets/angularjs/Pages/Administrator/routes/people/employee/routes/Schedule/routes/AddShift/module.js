angular.module('modules.AddShift', [])
.config(['$routeProvider',
         function ($routeProvider) {
             /* Handle route on location path is '/' */
             $routeProvider.when('/Employee/Schedule/AddShift', {
                 templateUrl: '/Assets/angularjs/Pages/Administrator/routes/people/employee/routes/Schedule/routes/AddShift/AddShift.page.html',
                 controller: 'AddShiftCtrl'
             });
         }
]);