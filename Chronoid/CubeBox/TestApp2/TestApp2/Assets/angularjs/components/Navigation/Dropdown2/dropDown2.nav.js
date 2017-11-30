'use strict';

/* Create module for navbar directive */
angular.module('directives.dropDown2', [])
    .directive('dropDown2', ['$http',
        '$location',
        function($http, $location) {
            function preFn(scope, element, attr) {
                /* TODO: Do something here before post function */
            }
            /* Do the directive's logic here */
            function postFn(scope, element, attr) {
                /*
                    Json in items and items2
                        [{label:'Help', icon:'mdi-communication-live-help', option:1}]
                */
                scope.dpBGColor = "";
                scope.class = "hidden";
                scope.Hover = function () {
                    scope.class = "show";
                    //scope.dpBGColor = "red lighten-5";
                }
                scope.Out = function () {
                    scope.class = "hidden";
                    scope.dpBGColor = "";
                }
                scope.SelectedOption = function (option) {
                    if (option != null || option != undefined) {
                        //alert("test " + option);
                        scope.event(scope.id, option);
                    }
                }
            }
            return {
                restrict: 'E',
                transclude:true,
                scope: {
                    icon: '=',
                    items: '=',
                    id: '=',
                    /*event must access paramter the action and the item selected*/
                    event:'=',
                },
                replace: true,
                //change path if will be used on other projects
                templateUrl: 'Assets/angularjs/components/Navigation/DropDown2/dropDown2.html',
                compile: function(scope, element, attr) {
                    return {
                        pre: preFn,
                        post: postFn
                    }
                }
            };
        }
    ]);