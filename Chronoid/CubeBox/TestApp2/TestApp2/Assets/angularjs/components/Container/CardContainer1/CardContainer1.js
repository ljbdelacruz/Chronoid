'use strict';

/* Create module for navbar directive */
angular.module('directives.cardContainer1', [])
    .directive('cardContainer1', ['$http',
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
                },
                replace: true,
                templateUrl: 'Assets/angularjs/components/Container/CardContainer1/CardContainer1.html',
                compile: function(scope, element, attr) {
                    return {
                        pre: preFn,
                        post: postFn
                    }
                }
            };
        }
    ]);