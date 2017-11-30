'use strict';

/* Create module for navbar directive */
angular.module('directives.timer1Widget', [])
    .directive('timer1Widget', ['$http',
        '$location','$interval','$window',
        function($http, $location, $interval, $window) {
            function preFn(scope, element, attr) {
            }
            /* Do the directive's logic here */
            function postFn(scope, element, attr) {
                scope.controller = scope.control || {};
                scope.displayTimer = "00:00";
                scope.total_seconds = 0;
                scope.seconds = 0;
                scope.minutes = 0;
                scope.stop = undefined;
                scope.minLeft = scope.total_seconds % 60;
                scope.controller.invokeStart = function () {
                    console.log("Invoke");
                    scope.total_seconds += Number(Number(scope.timeObject.hour) * 3600);
                    scope.total_seconds += Number(Number(scope.timeObject.minute) * 60);
                    scope.total_seconds += Number(scope.timeObject.second);
                    scope.stop = $interval(function () {
                        scope.total_seconds+=Number(1);
                        scope.seconds = (Number(scope.seconds) >= 59) ? Number(0) : Number(Number(scope.seconds) + 1);
                        scope.minutes = $window.Math.floor(Number(scope.total_seconds) / 60);
                        scope.seconds = Number(scope.total_seconds) % 60;
                        var tempMin = ("" + scope.minutes).length <= 1 ? "0" + scope.minutes : "" + scope.minutes;
                        var tempSec = ("" + scope.seconds).length <= 1 ? "0" + scope.seconds : "" + scope.seconds;
                        scope.displayTimer = tempMin + ":" + tempSec;
                        scope.calculateTimeConsumed(scope.total_seconds, scope.limitation);
                    }, 1000);
                }
                scope.calculateTimeConsumed = function (consumed, limit) {
                    scope.percentConsumed = Number(consumed) / Number(limit);
                    var left = $window.Math.floor(((Number(limit) - Number(consumed)) / 60))+1;

                    if (scope.minLeft != left) {
                        scope.minLeft = left;
                        if (scope.minLeft <= 5) {
                            var remMin = scope.minLeft;
                            scope.warningInvoke(remMin);
                        }
                    } else {

                    }


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
                    timeObject:'=',
                    control: '=',
                    displayTimer: '=',
                    limitation:'=',
                    percentConsumed: '=',
                    warningInvoke:'=',
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