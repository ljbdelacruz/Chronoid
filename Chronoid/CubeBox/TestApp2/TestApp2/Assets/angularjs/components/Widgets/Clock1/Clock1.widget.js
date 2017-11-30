'use strict';

/* Create module for navbar directive */
angular.module('directives.clock1Widget', [])
    .directive('clock1Widget', ['$http',
        '$location','$interval','$window',
        function($http, $location, $interval, $window) {
            function preFn(scope, element, attr) {
            }
            /* Do the directive's logic here */
            function postFn(scope, element, attr) {
                scope.controller = scope.control || {};
                scope.displayTimer = "00:00:00 AM";
                scope.stop = undefined;
                scope.dayTime = "AM";
                scope.temp = Number(0);

                scope.controller.invokeStart = function () {
                    scope.seconds = Number(scope.gsecs);
                    scope.minutes = Number(scope.gmins);
                    scope.hours = Number(scope.ghours);
                    scope.stop = $interval(function () {
                        if (Number(scope.gsecs) > 59) {
                            scope.gsecs = Number(0);
                            scope.gmins += Number(1);
                            if (Number(scope.gmins) > 59) {
                                scope.gmins = Number(0);
                                scope.ghours += Number(1);
                                if (Number(scope.ghours) > 24) {
                                    scope.ghours = Number(1);
                                }
                            }
                        }
                        scope.temp = Number(scope.ghours);
                        if (scope.ghours > 11) {
                            scope.dayTime = "PM";
                            if (scope.ghours > 12) {
                                scope.temp -= Number(12);
                            }
                        } else {
                            scope.dayTime = "AM";
                        }

                        var tempHour = ("" + scope.temp).length <= 1 ? "0" + scope.temp : "" + scope.temp;
                        var tempMin = ("" + scope.gmins).length <= 1 ? "0" + scope.gmins : "" + scope.gmins;
                        var tempSec = ("" + scope.gsecs).length <= 1 ? "0" + scope.gsecs : "" + scope.gsecs;
                        scope.displayTimer = tempHour + ":" + tempMin + ":" + tempSec+" "+scope.dayTime;
                        scope.gsecs += Number(1);
                    }, 1000);
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
                    ghours:'=',
                    gmins: '=',
                    gsecs:'=',
                    control:'=',
                },
                replace: true,
                templateUrl: 'Assets/angularjs/components/Widgets/Timer1/Timer1.widget.html',
                compile: function(scope, element, attr) {
                    return {
                        pre: preFn,
                        post: postFn
                    }
                }
            };
        }
    ]);