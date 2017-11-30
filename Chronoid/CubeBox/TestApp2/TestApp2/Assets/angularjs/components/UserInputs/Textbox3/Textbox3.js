'use strict';

/* Create module for navbar directive */
angular.module('directives.textBox3', [])
    .directive('textBox3', ['$http',
        '$location',
        function ($http, $location) {

            $(document).ready(function () {
                Materialize.updateTextFields();
            });


            function preFn(scope, element, attr) {
                /*scope.activetext = "";

                if (scope.output != "") {
                    scope.class = "active !important";
                    console.log("Hi");
                }

                if (output != "") {
                    scope.activetext = "active";
                }*/

                Materialize.updateTextFields();
            }
            
            /* Do the directive's logic here */
            function postFn(scope, element, attr) {
                if (scope.type == "") {
                    scope.type = "text";
                }

                Materialize.updateTextFields();
            }

            return {
                restrict: 'E',
                transclude:true,
                scope: {
                    output: '=',
                    label:'=',
                    placeholder: '=',
                    type: '=',
                    icon:'=',
                },
                replace: true,
                templateUrl: 'Assets/angularjs/components/UserInputs/Textbox3/Textbox3.html',
                compile: function(scope, element, attr) {
                    return {
                        pre: preFn,
                        post: postFn
                    }
                }
            };
        }
    ]);