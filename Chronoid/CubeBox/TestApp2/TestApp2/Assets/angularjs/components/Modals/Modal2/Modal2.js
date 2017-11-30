'use strict';
/* Create module for navbar directive */
angular.module('directives.modal2', [])
    .directive('modal2', ['$http',
        '$location', '$timeout',
        function ($http, $location, $timeout) {
            function preFn(scope, element, attr) {
                /* TODO: Do something here before post function */
            }
            /* Do the directive's logic here */
            function postFn(scope, element, attr) {
                scope.controller = scope.control || {};
                scope.controller.class = "my-hide-modal";
                scope.controller.isShow = false;
                scope.controller.ShowModal = function () {
                    scope.controller.isShow = true;
                    scope.controller.class = "my-show-modal";
                }
                /*the purpose of this modal here is to notify if this button is pressed or not if pressed
                    then invoke the function that will be executed when this button is pressed
                */
                scope.controller.CloseModal = function () {
                    scope.cancelFunc();
                    scope.HideModal();
                }
                scope.HideModal = function () {
                    scope.controller.class = "my-hide-modal";
                    $timeout(function () {
                        scope.controller.isShow = false;
                    }, 500);
                }
            }
            return {
                restrict: 'E',
                transclude: true,
                scope: {
                    title: '=',
                    control: '=',
                    /*invokable function when button is pressed in this modal and if you want to execute something*/
                    saveFunc: '&',
                    cancelFunc: '&',
                    /*Label*/
                    label1:"="
                },
                replace: true,
                templateUrl: 'Assets/angularjs/components/Modals/Modal2/Modal2.html',
                compile: function (scope, element, attr) {
                    return {
                        pre: preFn,
                        post: postFn
                    }
                }
            };
        }
    ]);