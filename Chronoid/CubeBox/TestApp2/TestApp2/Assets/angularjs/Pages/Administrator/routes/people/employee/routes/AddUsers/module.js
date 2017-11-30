angular.module('modules.AddUsers', [])
.config(['$routeProvider',
         function ($routeProvider) {
             /* Handle route on location path is '/' */
             $routeProvider.when('/Employee/AddUsers', {
                 templateUrl: '/Assets/angularjs/Pages/Administrator/routes/people/employee/routes/AddUsers/AddUsers.page.html',
                 controller: 'AddUsersCtrl'
             });
         }
]);