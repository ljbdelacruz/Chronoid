angular.module('modules.Main', [])
.config(['$routeProvider',
         function ($routeProvider) {
             /* Handle route on location path is '/' */
             $routeProvider.when('/', {
                 templateUrl: '/Assets/angularjs/Pages/Administrator/routes/main/Main.page.html',
                 controller: 'MainCtrl'
             });
         }
]);