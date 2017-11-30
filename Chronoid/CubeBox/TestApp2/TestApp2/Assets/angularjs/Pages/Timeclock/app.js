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
            /*directives*/
            /*user inputs*/
            'directives.textBox3',
            'directives.textBox4',
            'directives.button1',
            /*containers*/
            'directives.cardContainer1',
            'directives.cardContainer2',
            /*Widgets*/
            'directives.clock1Widget',
            'directives.burningIcon1',
            'widget.webcam1',
            /*Modals*/
            'directives.modal1',
            /*3rd Party Directives*/
            'webcam',
            'otherApp',
])
.config(['$routeProvider',
                 function ($routeProvider) {
                     $routeProvider.otherwise({ redirectTo: '/' });
                 }
]);