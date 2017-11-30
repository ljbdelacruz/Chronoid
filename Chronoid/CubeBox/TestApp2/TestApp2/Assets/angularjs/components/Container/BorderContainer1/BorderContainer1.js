'use strict';

/* Create module for navbar directive */
angular.module('directives.borderContainer1', [])
    .directive('borderContainer1', ['$http',
        '$location',
        function($http, $location) {
            function preFn(scope, element, attr) {
            }
            /* Do the directive's logic here */
            function postFn(scope, element, attr) {
            }
            return {
                restrict: 'E',
                transclude:true,
                scope: {
                    header:'=',
                },
                replace: true,
                templateUrl: '/Assets/angularjs/components/Container/BorderContainer1/BorderContainer1.html',
                compile: function(scope, element, attr) {
                    return {
                        pre: preFn,
                        post: postFn
                    }
                }
            };
        }
    ]);