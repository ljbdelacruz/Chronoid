'use strict';

//this app is for login page
angular.element(document)
    .ready(function () {
        angular.bootstrap(document, ['ngStarterKit']);
    });
angular.module('ngStarterKit', [
            'ngRoute',
            'directives.textBox3',
            'directives.button1',
            'directives.cardContainer1',
            'directives.dropDown2',
            /*widgets*/
            'directives.loadingScreen1',
            'otherApp',
])
.config(['$routeProvider',
                 function ($routeProvider) {
                     $routeProvider.otherwise({ redirectTo: '/' });
                 }
]);