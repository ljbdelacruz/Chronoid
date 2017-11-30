'use strict';
/* Create module for navbar directive */
angular.module('directives.modal1', [])
    .directive('modal1', ['$http',
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
                /*the purpose of this modal here is to notify if this button is pressed or not if pressed
                    then invoke the function that will be executed when this button is pressed
                */
                scope.controller.CloseModal = function () {
                    scope.HideModal();
                }
                scope.ConfirmModal = function () {
                    console.log("Save Event");
                    scope.saveFunc();
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
                    title:'=',
                    control: '=',
                    /*invokable function when button is pressed in this modal and if you want to execute something*/
                    saveFunc: '&',
                    cancelFunc: '&',
                    confirmLabel: '=',
                    cancelLabel:'=',
                },
                replace: true,
                templateUrl: 'Assets/angularjs/components/Modals/Modal1/Modal1.html',
                compile: function (scope, element, attr) {
                    return {
                        pre: preFn,
                        post: postFn
                    }
                }
            };
        }
    ]);