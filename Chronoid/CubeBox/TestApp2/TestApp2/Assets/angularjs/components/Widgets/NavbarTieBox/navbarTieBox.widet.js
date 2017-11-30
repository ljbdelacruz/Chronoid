'use strict';


/*Accepts IconNavigationObject as parameter*/
/* Create module for navbar directive */
angular.module('directives.navbarTieBoxWidget', [])
    .directive('navbarTieBox', ['$http',
        '$location','$interval','$window',
        function($http, $location, $interval, $window) {
            function preFn(scope, element, attr) {
            }
            /* Do the directive's logic here */
            function postFn(scope, element, attr) {
                //this is how to solve event with parameter
                scope.event = scope.event();
            }
            return {
                restrict: 'E',
                transclude:true,
                scope: {
                    items:'=',
                    event: "&"
                },
                replace: true,
                templateUrl: 'Assets/angularjs/components/Widgets/NavbarTieBox/navbarTieBox.widget.html',
                compile: function(scope, element, attr) {
                    return {
                        pre: preFn,
                        post: postFn
                    }
                }
            };
        }
    ]);