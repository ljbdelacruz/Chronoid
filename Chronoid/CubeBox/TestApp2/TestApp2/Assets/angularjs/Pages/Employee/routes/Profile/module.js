angular.module('modules.Profile', [])
.config(['$routeProvider',
         function ($routeProvider) {
             /* Handle route on location path is '/' */
             $routeProvider.when('/Profile', {
                 templateUrl: '/Assets/angularjs/Pages/Employee/routes/Profile/Profile.page.html',
                 controller: 'ProfileCtrl'
             });
         }
]);