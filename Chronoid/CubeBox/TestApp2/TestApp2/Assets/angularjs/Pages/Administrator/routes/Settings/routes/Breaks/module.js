angular.module('modules.Break', [])
.config(['$routeProvider',
         function ($routeProvider) {
             /* Handle route on location path is '/' */
             $routeProvider.when('/Settings/Breaks', {
                 templateUrl: '/Assets/angularjs/Pages/Administrator/routes/Settings/routes/Breaks/Break.page.html',
                 controller: 'BreakCtrl'
             });
         }
]);