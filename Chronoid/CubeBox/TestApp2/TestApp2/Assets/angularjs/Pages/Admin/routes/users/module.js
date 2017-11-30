angular.module('modules.Users', [])
.config(['$routeProvider',
         function ($routeProvider) {
             /* Handle route on location path is '/' */
             $routeProvider.when('/Users', {
                 templateUrl: '/Assets/angularjs/Pages/Admin/routes/users/users.page.html',
                 controller: 'UsersCtrl'
             });
         }
]);