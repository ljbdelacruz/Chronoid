'use strict';

//this app is for login page
angular.element(document)
    .ready(function () {
        angular.bootstrap(document, ['ngStarterKit']);
    });
angular.module('ngStarterKit', [
            'ngRoute',
            /*Modules*/
            'modules.Main',
            'modules.Company',
            'modules.Users',
            /*Widgets*/
            'directives.loader1',

            /*Services*/
            'otherApp'
])
.config(['$routeProvider',
                 function ($routeProvider) {
                     $routeProvider.otherwise({ redirectTo: '/' });
                 }
]);