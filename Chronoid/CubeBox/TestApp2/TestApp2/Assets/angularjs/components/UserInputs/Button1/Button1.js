'use strict';

/* Create module for navbar directive */
angular.module('directives.button1', [])
    .directive('button1', ['$http',
        '$location',
        function($http, $location) {
            function preFn(scope, element, attr) {
            }
            /* Do the directive's logic here */
            function postFn(scope, element, attr) {
                scope.ButtonClick = function () {
                    scope.event();
                }
            }
            return {
                restrict: 'E',
                transclude:true,
                scope: {
                    label: '=',
                    option: '=',
                    event: '&',
                    icon: '='
                },
                replace: true,
                templateUrl: 'Assets/angularjs/components/UserInputs/Button1/Button1.html',
                compile: function(scope, element, attr) {
                    return {
                        pre: preFn,
                        post: postFn
                    }
                }
            };
        }
    ]);