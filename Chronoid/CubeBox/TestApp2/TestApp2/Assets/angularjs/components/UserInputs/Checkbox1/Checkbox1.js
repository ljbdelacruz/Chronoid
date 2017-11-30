'use strict';

/* Create module for checkbox1 directive */
angular.module('directives.checkbox1', [])
    .directive('checkbox1', ['$http',
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
                    item:'=',
                    value: '=',
                    event: '=',
                    label: '='
                },
                replace: true,
                templateUrl: 'Assets/angularjs/components/UserInputs/Checkbox1/Checkbox1.html',
                compile: function (scope, element, attr) {
                    return {
                        pre: preFn,
                        post: postFn
                    }
                }
            };
        }
    ]);