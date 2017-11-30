angular.module('modules.PublicView', [])
.config(['$routeProvider',
         function ($routeProvider) {
             /* Handle route on location path is '/' */
             $routeProvider.when('/PublicView', {
                 templateUrl: '/Assets/angularjs/Pages/Administrator/routes/people/publicView/PublicView.page.html',
                 controller: 'PublicViewCtrl'
             });
         }
]);