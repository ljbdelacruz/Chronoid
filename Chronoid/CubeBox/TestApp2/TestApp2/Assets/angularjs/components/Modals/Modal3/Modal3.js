'use strict';
/* Create module for navbar directive */
angular.module('directives.modal3', [])
    .directive('modal3', ['$http',
        '$location','$timeout',
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
                scope.ShowModal = function () {
                    console.log("Show");
                    scope.controller.isShow = true;
                    scope.controller.class = "my-show-modal";
                }

                scope.controller.CloseModal = function () {
                    scope.cancelFunc();
                    scope.HideModal();
                }
                scope.controller.SaveModal = function () {
                    scope.confirmFunc();
                    scope.HideModal();
                }
                scope.HideModal = function () {
                    scope.controller.class = "my-hide-modal";
                    scope.controller.isShow = false;
                }
            }
            return {
                restrict: 'E',
                transclude: true,
                scope: {
                    icon:'=',
                    title: '=',
                    message:"=",
                    control: '=',
                    /*invokable function when button is pressed in this modal and if you want to execute something*/
                    confirmFunc: '=',
                    cancelFunc: '=',
                    ShowModal:'='
                },
                replace: true,
                templateUrl: 'Assets/angularjs/components/Modals/Modal3/Modal3.html',
                compile: function (scope, element, attr) {
                    return {
                        pre: preFn,
                        post: postFn
                    }
                }
            };
        }
    ]);