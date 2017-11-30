﻿angular.module('modules.Main', [])
.config(['$routeProvider',
         function ($routeProvider) {
             /* Handle route on location path is '/' */
             $routeProvider.when('/', {
                 templateUrl: '/Assets/angularjs/Pages/TimeClock/routes/main/Main.page.html',
                 controller: 'MainCtrl'
             });
         }
]);