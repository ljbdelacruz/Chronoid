'use strict';

/* Create module for badge directive */
angular.module('directives.badge', [])
    .directive('badge', ['$http',
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
                    icon: '='
                },
                replace: true,
                templateUrl: 'Assets/angularjs/components/Widgets/Badge/Badge.html',
                compile: function(scope, element, attr) {
                    return {
                        pre: preFn,
                        post: postFn
                    }
                }
            };
        }
    ]);