'use strict';

/* Create module for navbar directive */
angular.module('directives.modal4', [])
    .directive('modal4', ['$http',
        '$location',
        function ($http, $location) {
            function preFn(scope, element, attr) {
            }
            /* Do the directive's logic here */
            function postFn(scope, element, attr) {
                scope.isShow = true;
                scope.show = function () {
                    scope.isShow = !scope.isShow;
                }
            }
            return {
                restrict: 'E',
                transclude: true,
                scope: {
                    title: '=',
                    show: '=',
                    buttons: '='
                },
                replace: true,
                templateUrl: 'Assets/angularjs/components/Modals/Modal4/Modal4.html',
                compile: function (scope, element, attr) {
                    return {
                        pre: preFn,
                        post: postFn
                    }
                }
            };
        }
    ]);