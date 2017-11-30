'use strict';

/* Create module for navbar directive */
angular.module('directives.button2', [])
    .directive('button2', ['$http',
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
                    event: '&',
                    icon: '=',
                    //id: '=',
                    option: '=',
                },
                replace: true,
                templateUrl: 'Assets/angularjs/components/UserInputs/Button2/Button2.html',
                compile: function (scope, element, attr) {
                    return {
                        pre: preFn,
                        post: postFn
                    }
                }
            };
        }
    ]);