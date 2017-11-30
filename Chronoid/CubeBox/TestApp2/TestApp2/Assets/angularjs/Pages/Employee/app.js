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
            'modules.Profile',
            /*directives*/
            /*user inputs*/
            'directives.button1',
            'directives.selection1',
            /*containers*/
            'directives.cardContainer1',
            'directives.cardContainer2',
            /*Widgets*/
            'directives.timer1Widget',
            'directives.clock1Widget',
            'directives.navbarTieBoxWidget',
            'directives.burningIcon1',
            /*Modals*/
            'directives.modal1',
            /*3rd Party*/
            'angular.directives-round-progress',
            'otherApp',
])
.config(['$routeProvider',
                 function ($routeProvider) {
                     $routeProvider.otherwise({ redirectTo: '/' });
                 }
]);