angular.module('modules.EditUsers', [])
.config(['$routeProvider',
         function ($routeProvider) {
             /* Handle route on location path is '/' */
             $routeProvider.when('/Employee/EditUsers', {
                 templateUrl: '/Assets/angularjs/Pages/Administrator/routes/people/employee/routes/EditUsers/EditUsers.page.html',
                 controller: 'EditUsersCtrl'
             });
         }
]);