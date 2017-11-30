'use strict';

/* Create module for navbar directive */
angular.module('directives.cardContainer2', [])
    .directive('cardContainer2', ['$http',
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
                    header:'='
                },
                replace: true,
                templateUrl: '/Assets/angularjs/components/Container/CardContainer2/CardContainer2.html',
                compile: function(scope, element, attr) {
                    return {
                        pre: preFn,
                        post: postFn
                    }
                }
            };
        }
    ]);