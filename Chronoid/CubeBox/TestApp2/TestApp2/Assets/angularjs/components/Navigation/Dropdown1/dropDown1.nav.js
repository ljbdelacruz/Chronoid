'use strict';

/* Create module for navbar directive */
angular.module('directives.dropDown1', [])
    .directive('dropDown1', ['$http',
        '$location',
        function($http, $location) {
            function preFn(scope, element, attr) {
                /* TODO: Do something here before post function */
            }
            /* Do the directive's logic here */
            function postFn(scope, element, attr) {
                scope.class = "dropdown-content";
                scope.isToggle = false;
                scope.style = "width: 100%; position: absolute; top: 57px; left: 101.233px; opacity: 1; display: none;";
                scope.ToggleNav = function () {
                    scope.isToggle = !scope.isToggle;
                    if (scope.isToggle) {
                        scope.class = "dropdown-content active";
                        scope.style = "width: 100%; position: absolute; top: 57px; left: 101.233px; opacity: 1; display: block;";
                    } else {
                        scope.class = "dropdown-content";
                        scope.style = "width: 100%; position: absolute; top: 57px; left: 101.233px; opacity: 1; display: none;";
                    }
                }
                scope.SelectedOption = function (item) {
                    scope.eventController.EventDropDown(item.path);
                }
            }
            return {
                restrict: 'E',
                transclude:true,
                scope: {
                    title: '=',
                    items: '=',
                    items2: '=',
                    output: '=',
                    eventController:'='
                },
                replace: true,
                //change path if will be used on other projects
                templateUrl: 'Assets/angularjs/components/Navigation/DropDown1/dropDown1.html',
                compile: function(scope, element, attr) {
                    return {
                        pre: preFn,
                        post: postFn
                    }
                }
            };
        }
    ]);