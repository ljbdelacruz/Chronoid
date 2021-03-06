'use strict';

/* Create module for navbar directive */
angular.module('directives.common.peopleNavbar', [])
    .directive('commonPeopleNavbar', ['$interval',
        function($interval) {
            function preFn(scope, element, attr) {
            }
            /* Do the directive's logic here */
            function postFn(scope, element, attr) {
            }
            return {
                restrict: 'E',
                transclude:true,
                scope: {
                    items:"="
                },
                replace: true,
                templateUrl: 'Assets/angularjs/Pages/Administrator/routes/people/common/peopleNavbar/peopleNavbar.common.html',
                compile: function(scope, element, attr) {
                    return {
                        pre: preFn,
                        post: postFn
                    }
                }
            };
        }
    ]);