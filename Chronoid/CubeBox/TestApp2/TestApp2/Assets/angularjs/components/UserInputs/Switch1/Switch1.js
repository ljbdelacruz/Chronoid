'use strict';

/* Create module for switch1 directive */
angular.module('directives.switch1', [])
    .directive('switch1', ['$http',
        '$location',
        function ($http, $location) {
            function preFn(scope, element, attr) {
            }
            /* Do the directive's logic here */
            function postFn(scope, element, attr) {
            }
            return {
                restrict: 'E',
                transclude: true,
                scope: {
                    option1: '=',
                    option2: '=',
                    event: '=',
                    label: '='
                },
                replace: true,
                templateUrl: 'Assets/angularjs/components/UserInputs/Switch1/Switch1.html',
                compile: function (scope, element, attr) {
                    return {
                        pre: preFn,
                        post: postFn
                    }
                }
            };
        }
    ]);