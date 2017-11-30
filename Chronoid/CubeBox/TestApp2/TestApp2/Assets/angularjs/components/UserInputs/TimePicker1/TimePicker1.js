'use strict';

/* Create module for timePicker1 directive */
angular.module('directives.timePicker1', [])
    .directive('timePicker1', ['$http',
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
                    label: '=',
                    event: '=',
                    icon: '=',
                    checked: '=',
                    placeholder: '='
                },
                replace: true,
                templateUrl: 'Assets/angularjs/components/UserInputs/TimePicker1/TimePicker1.html',
                compile: function (scope, element, attr) {
                    return {
                        pre: preFn,
                        post: postFn
                    }
                }
            };
        }
    ]);