'use strict';

/* Create module for navbar directive */
angular.module('directives.burningIcon1', [])
    .directive('burningIcon1', ['$interval',
        function($interval) {
            function preFn(scope, element, attr) {
            }
            /* Do the directive's logic here */
            function postFn(scope, element, attr) {
                scope.controller = scope.control || {};
                scope.counter = 0;
                scope.color = "";
                scope.controller.invokeStart = function () {
                    scope.color = scope.colors[0].color;
                    var index=0;
                    scope.stop = $interval(function () {
                        scope.counter++;
                        if (scope.counter > scope.intervals) {
                            index++;
                            if (index > scope.colors.length - 1) {
                                index = 0;
                            }
                            scope.color = scope.colors[index].color;
                            console.log(scope.color);
                            scope.counter = 0;
                        }
                    }, 800);
                }
                scope.controller.invokeDestroy = function () {
                    if (angular.isDefined(scope.stop)) {
                        $interval.cancel(scope.stop);
                        scope.stop = undefined;
                    }
                };

            }
            return {
                restrict: 'E',
                transclude:true,
                scope: {
                    intervals:'=',
                    icon:'=',
                    colors:'=',
                    control: '=',

                },
                replace: true,
                templateUrl: 'Assets/angularjs/components/Widgets/BurningIcon/BurningIcon.widget.html',
                compile: function(scope, element, attr) {
                    return {
                        pre: preFn,
                        post: postFn
                    }
                }
            };
        }
    ]);