angular.module('modules.Settings', [])
.config(['$routeProvider',
         function ($routeProvider) {
             /* Handle route on location path is '/' */
             $routeProvider.when('/Settings', {
                 templateUrl: '/Assets/angularjs/Pages/Administrator/routes/people/users/users.page.html',
                 controller: 'SettingsCtrl'
             });
         }
]);