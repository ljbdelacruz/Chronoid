'use strict';

/* Create module for navbar directive */
angular.module('directives.dropDown3', [])
    .directive('dropDown3', ['$http',
        '$location',
        function($http, $location) {
            function preFn(scope, element, attr) {
                /* TODO: Do something here before post function */
            }
            /* Do the directive's logic here */
            function postFn(scope, element, attr) {
                scope.isHide = true;
                scope.toggle = function () {
                    scope.isHide = !scope.isHide;
                }
            }
            return {
                restrict: 'E',
                transclude:false,
                scope: {
                    items: '=',
                    toggle:'=',
                    /*event must access paramter the action and the item selected*/
                    event:'=',
                },
                replace: true,
                //change path if will be used on other projects
                templateUrl: 'Assets/angularjs/components/Navigation/DropDown3/dropDown3.html',
                compile: function(scope, element, attr) {
                    return {
                        pre: preFn,
                        post: postFn
                    }
                }
            };
        }
    ]);