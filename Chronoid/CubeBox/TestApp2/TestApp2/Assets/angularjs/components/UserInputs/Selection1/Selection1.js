'use strict';
/* Create module for navbar directive */
angular.module('directives.selection1', [])
    .directive('selection1', ['$http',
        '$location', '$timeout', '$q',
        function ($http, $location, $timeout, $q) {
            function preFn(scope, element, attr) {
                /* TODO: Do something here before post function */
            }
            /* Do the directive's logic here */
            function postFn(scope, element, attr) {
            }
            return {
                restrict: 'E',
                transclude: true,
                scope: {
                    label: '=',
                    items: '=',
                    event: '=',
                    output: '=',
                    icon: '=',
                },
                replace: true,
                templateUrl: 'Assets/angularjs/components/UserInputs/Selection1/Selection1.html',
                compile: function (scope, element, attr) {
                    return {
                        pre: preFn,
                        post: postFn
                    }
                }
            };
        }
    ]);