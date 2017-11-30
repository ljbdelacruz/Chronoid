'use strict';

/* Create module for navbar directive */
angular.module('directives.textBox4', [])
    .directive('textBox4', ['$http',
        '$location',
        function ($http, $location) {
            function preFn(scope, element, attr) {
            }
            /* Do the directive's logic here */
            function postFn(scope, element, attr) {
                if (scope.type == "") {
                    scope.type = "text";
                }
                scope.enterKeyPress = function (event) {
                    if (event.keyCode == 13) {
                        scope.event();
                    }
                }
            }

            return {
                restrict: 'E',
                transclude:true,
                scope: {
                    output: '=',
                    label:'=',
                    placeholder: '=',
                    type: '=',
                    icon: '=',
                    fontSize:'=',
                    event:'&',
                },
                replace: true,
                templateUrl: 'Assets/angularjs/components/UserInputs/Textbox4/Textbox4.html',
                compile: function(scope, element, attr) {
                    return {
                        pre: preFn,
                        post: postFn
                    }
                }
            };
        }
    ]);